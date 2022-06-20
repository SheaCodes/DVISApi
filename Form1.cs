using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using DVISApi.TSTypes;
using Newtonsoft.Json;

namespace DVISApi
{
    public partial class Form1 : Form
    {
	    private bool _cancel;

	    public Form1()
        {
            InitializeComponent();

			OnMessage("Started");

			LoadSettings();
        }

	    protected override void OnClosing(CancelEventArgs e)
        {
	        SaveSettings();

	        base.OnClosing(e);
        }

        private void OnClickOutputDir(object sender, EventArgs e)
		{
			FolderBrowserDialog fb = new FolderBrowserDialog();
			if (fb.ShowDialog() == DialogResult.OK)
			{
				textBoxOutputDir.Text = fb.SelectedPath;
			}
		}

		private void OnClickSignalFile(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			textBoxInputFile.Text = dlg.FileName;
		}

		private void OnClickGo(object sender, EventArgs e)
		{
			_cancel = false;


			var server = textBoxServer.Text;
			var signalFile = textBoxInputFile.Text;
			var outputDir = textBoxOutputDir.Text;

			Ping ping = new Ping();
			PingReply reply = ping.Send(server);
			if (reply.Status != IPStatus.Success)
			{
				if (MessageBox.Show(string.Format("Ping {0} failed, continue?", server), "Hmmm", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
			}

			OnMessage(string.Format("Ping succeeded in: {0} ms", reply.RoundtripTime));

			if (!File.Exists(signalFile))
			{
				OnMessage("Signal file does not exist: " + signalFile);
				return;
			}

			try
			{
				if (!Directory.Exists(outputDir))
				{
					Directory.CreateDirectory(outputDir);
				}
			}
			catch (Exception exception)
			{
				OnMessage(string.Format("Error creating directory {0}: {1}", outputDir, exception));
				return;
			}

			int port;
			if (!TryGetPort(out port))
			{
				OnMessage(string.Format("Can not get port: {0}", textBoxPort.Text));
				return;
			}

			DateTime dtStartLocal = dateTimePickerStart.Value;
			DateTime dtEndLocal = dateTimePickerEnd.Value;

			if (dtStartLocal > DateTime.Now)
			{
				OnMessage("Start is later than now");
				return;
			}

			if (dtStartLocal > dtEndLocal)
			{
				OnMessage("Start is later than end");
				return;
			}

			SaveSettings();

			buttonGo.Enabled = false;
			buttonCancel.Enabled = true;

			bool oneFile = checkBoxCombineCSVs.Checked;

			ThreadPool.QueueUserWorkItem(delegate
			{
				if (oneFile)
				{
					DateTime dtStartUTC = dtStartLocal.ToUniversalTime();
					DateTime dtEndUTC = dtEndLocal.ToUniversalTime();

					string outputFile = string.Format(@"{0} {1:yyyy_MM_dd HHmm} {2:yyyy_MM_dd HHmm}.csv", outputDir, dtStartUTC, dtEndUTC);
					ExportArrayOneFile(signalFile, dtStartLocal, dtEndLocal, server, port, outputFile);
				}
				else
					ExportArrayIndividualFiles(signalFile, dtStartLocal, dtEndLocal, server, port, outputDir);
			});
		}

		private void OnClickCancel(object sender, EventArgs e)
		{
			OnMessage("Cancel request received");
			_cancel = true;
		}

		private void OnClickReadCurrentValue(object sender, EventArgs e)
		{
			var server = textBoxServer.Text;
			var signal = textBoxSignal.Text;

			if(string.IsNullOrEmpty(server))
			{
				OnMessage("Server is not set");
				return;
			}

			if (string.IsNullOrEmpty(signal))
			{
				OnMessage("Signal is not set");
				return;
			}

			int port;
			if(!TryGetPort(out port))
			{
				OnMessage(string.Format("Can not get port: {0}", textBoxPort.Text));
				return;
			}

			SaveSettings();

			ThreadPool.QueueUserWorkItem(delegate
			{
				TSPointWeb point = ReadPoint(server, port, signal, DateTime.UtcNow + TimeSpan.FromMinutes(1));
				if (point != null)
				{
					var o = point.ValueObject;
					if(o is double)
						OnMessage(string.Format("{0:HH:mm:ss.fff} {1:F2}", point.TimeStamp, (double)o));
					else
						OnMessage(string.Format("{0:HH:mm:ss.fff} {1}", point.TimeStamp, o));
				}
				else
				{
					OnMessage("Point is null");
				}
			});
		}

		private void OnGetCurrentFrame(object sender, EventArgs e)
		{
			DoGetFrame(DateTime.UtcNow + TimeSpan.FromMinutes(1));
		}

		private void OnGetFrameAtClick(object sender, EventArgs e)
		{
			DoGetFrame(dateTimePickerVideo.Value);
		}

		private void DoGetFrame(DateTime dt)
		{
			var server = textBoxServer.Text;
			var signal = textBoxVideo.Text;

			if (string.IsNullOrEmpty(server))
			{
				OnMessage("Server is not set");
				return;
			}

			if (string.IsNullOrEmpty(signal))
			{
				OnMessage("Signal is not set");
				return;
			}

			int port;
			if (!TryGetPort(out port))
			{
				OnMessage(string.Format("Can not get port: {0}", textBoxPort.Text));
				return;
			}

			SaveSettings();

			ThreadPool.QueueUserWorkItem(delegate
			{
				TSVideoWeb point = ReadVideo(server, port, signal, dt);
				if (point != null)
				{
					Bitmap bmp = point.Value;
					if (bmp != null)
					{
						BeginInvoke((MethodInvoker) delegate { pictureBox1.Image = bmp; });
					}
				}
				else
				{
					OnMessage("Point is null");
				}
			});
		}

		private ExportArrayResult ExportArrayOneFile(string signalFile, DateTime dtStartLocal, DateTime dtEndLocal, string server, int port, string outputFile)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				buttonGo.Enabled = false;
				buttonCancel.Enabled = true;
			});

			try
			{
				TimeSpan tsBatchSize = TimeSpan.FromHours(4);

				var signals = File.ReadAllLines(signalFile);
				int todo = signals.Length;

				int batchesPerSignal = (int)((dtEndLocal - dtStartLocal).TotalSeconds / tsBatchSize.TotalSeconds) + 1;
				int totalBatches = batchesPerSignal * todo;

				int batchesComplete = 0;
				int signalsComplete = 0;

				Dictionary<string, List<TSPointWeb>> dic = new Dictionary<string, List<TSPointWeb>>();

				DateTime dtStartUtc = dtStartLocal.ToUniversalTime();
				DateTime dtEndUtc = dtEndLocal.ToUniversalTime();


				foreach (string signal in signals)
				{
					string signalName = signal.Trim();

					Action onBatchComplete = delegate
					{
						batchesComplete++;
						int progress = (int)Math.Round(100d * batchesComplete / totalBatches);
						UpdateProgress(progress);
					};

					List<TSPointWeb> points = new List<TSPointWeb>();

					var firstPoint = ReadPoint(server, port, signalName, dtStartLocal);
					if (firstPoint != null)
					{
						points.Add(firstPoint);
					}

					bool success = ExportArrayBatchedRequest(server, port, signalName, dtStartUtc, dtEndUtc, tsBatchSize, points, onBatchComplete);
					if (_cancel)
					{
						OnMessage("Cancelled");
						return new ExportArrayResult("Cancelled");
					}

					if (success)
						dic.Add(signalName, points);
					else
						return new ExportArrayResult("Export failed on signal " + signalName);

					signalsComplete++;

					OnMessage("To do: " + (todo - signalsComplete));
				}

				if (dic.Any())
				{
					ExportArrayOneFileCombine(dic, dtStartUtc, dtEndUtc, outputFile);
				}

				UpdateProgress(100);
			}
			catch (Exception ex)
			{
				var err = string.Format("Problem: {0}", ex);
				OnMessage(err);
				return new ExportArrayResult(err);
			}
			finally
			{
				Thread.Sleep(2000);
				UpdateProgress(0);
				BeginInvoke((MethodInvoker)delegate
				{
					buttonGo.Enabled = true;
					buttonCancel.Enabled = false;
				});
			}

			return new ExportArrayResult();
		}

		private void ExportArrayOneFileCombine(Dictionary<string, List<TSPointWeb>> signalsToPoints, DateTime dtStartUTC, DateTime dtEndUTC, string outputFile)
		{
			Dictionary<string, TSPointWebIterator> signalsToIterators = new Dictionary<string, TSPointWebIterator>();
			foreach (var kvp in signalsToPoints)
			{
				signalsToIterators.Add(kvp.Key, new TSPointWebIterator(kvp.Value));
			}

			// Determine highest frequency
			int[] options = { 100, 250, 500, 750, 1000 };
			int highestFrequency = options.Last();
			foreach (var signal in signalsToIterators)
			{
				var list = signal.Value;
				double sum = 0d;
				int count = 0;
				for (int i = 2; i < 10 && i < list.Count; i++)
				{
					sum += Math.Round((list[i].TimeStamp - list[i - 1].TimeStamp).TotalMilliseconds);
					count++;
				}

				int avg = (int)Math.Round(sum / count);
				int closest = options.Last();
				for (int i = 0; i < options.Length; i++)
				{
					var diffToAvg = Math.Abs(avg - options[i]);
					var difToClosest = Math.Abs(avg - closest);
					if (diffToAvg < difToClosest)
					{
						closest = options[i];
					}
				}

				if (avg > 0 && closest < highestFrequency)
				{
					OnMessage(string.Format("Signal: {0} Avg Period ms: {1} Closest Period ms: {2}", signal.Key, avg, closest));
					highestFrequency = closest;
				}
			}

			TimeSpan tsAdvance = TimeSpan.FromMilliseconds(highestFrequency);

			OnMessage(string.Format("Using {0} ms", highestFrequency));

			DateTime dtCur = dtStartUTC;

			string dir = Path.GetDirectoryName(outputFile);

			if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			if (File.Exists(outputFile))
			{
				OnMessage("Deleting " + outputFile);
				File.Delete(outputFile);
			}

			List<string> signalNames = signalsToIterators.Keys.ToList();

			using (var fs = File.OpenWrite(outputFile))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					sw.Write("Time,");

					for (var index = 0; index < signalNames.Count; index++)
					{
						string signalName = signalNames[index];
						var isLast = index == signalNames.Count - 1;
						var post = isLast ? Environment.NewLine : ",";
						sw.Write(signalName + post);
					}

					while (true)
					{
						sw.Write("{0:O},", dtCur);

						for (var index = 0; index < signalNames.Count; index++)
						{
							string signalName = signalNames[index];
							var isLast = index == signalNames.Count - 1;
							var post = isLast ? Environment.NewLine : ",";
							var point = signalsToIterators[signalName].Get(dtCur);
							if (point == null)
								sw.Write(post);
							else
								sw.Write("{0}{1}", point.ValueObject, post);
						}

						dtCur += tsAdvance;
						if (dtCur > dtEndUTC)
							break;
					}

					sw.Flush();
					sw.Close();
				}
			}

			OnMessage(string.Format("Wrote data to: {0}", outputFile));
		}

		private void ExportArrayIndividualFiles(string signalFile, DateTime dtStartLocal, DateTime dtEndLocal, string server, int port, string outputDir)
		{
			try
			{
				TimeSpan tsBatchSize = TimeSpan.FromHours(4);

				var signals = File.ReadAllLines(signalFile);
				int todo = signals.Length;

				int batchesPerSignal = (int) ((dtEndLocal - dtStartLocal).TotalSeconds / tsBatchSize.TotalSeconds) + 1;
				int totalBatches = batchesPerSignal * todo;

				int batchesComplete = 0;
				int signalsComplete = 0;

				foreach (string signal in signals)
				{
					string signalName = signal.Trim();

					Action onBatchComplete = delegate
					{
						batchesComplete++;
						int progress = (int) Math.Round(100d * batchesComplete / totalBatches);
						UpdateProgress(progress);
					};

					List<TSPointWeb> points = new List<TSPointWeb>();

					DateTime dtStartUtc = dtStartLocal.ToUniversalTime();
					DateTime dtEndUtc = dtEndLocal.ToUniversalTime();

					var firstPoint = ReadPoint(server, port, signalName, dtStartLocal);
					if (firstPoint != null)
					{
						points.Add(firstPoint);
					}

					bool success = ExportArrayBatchedRequest(server, port, signalName, dtStartUtc, dtEndUtc, tsBatchSize, points, onBatchComplete);
					if (_cancel)
					{
						OnMessage("Cancelled");
						return;
					}

					if (success)
						WriteCSV(outputDir, signalName, dtStartLocal, dtEndLocal, points);
					signalsComplete++;

					OnMessage("To do: " + (todo - signalsComplete));
				}

				UpdateProgress(100);
			}
			catch (Exception ex)
			{
				OnMessage(string.Format("Problem: {0}", ex));
			}
			finally
			{
				Thread.Sleep(2000);
				UpdateProgress(0);
				BeginInvoke((MethodInvoker) delegate
				{
					buttonGo.Enabled     = true;
					buttonCancel.Enabled = false;
				});
			}
		}

		private bool ExportArrayBatchedRequest(string server, int port, string signal, DateTime dtStartUtc, DateTime dtEndUtc, TimeSpan tsBatchSize, List<TSPointWeb> addTo, Action onBatchComplete)
		{
			try
			{
				DateTime dtBatchStart = dtStartUtc;
				DateTime dtBatchEnd = dtBatchStart + tsBatchSize;

				while (true)
				{
					DateTime dtReqStart = dtBatchStart;
					DateTime dtReqEnd = dtBatchEnd > dtEndUtc ? dtEndUtc : dtBatchEnd;

					if (!ExportArrayReadArray(server, port, signal, dtReqStart, dtReqEnd, addTo))
						return false;

					if (onBatchComplete != null)
						onBatchComplete();

					if (dtBatchEnd >= dtEndUtc)
						break;

					if (_cancel)
					{
						OnMessage("Cancel request acknowledged");
						return false;
					}

					dtBatchStart = dtBatchEnd;
					dtBatchEnd   = dtBatchStart + tsBatchSize;
				}

				return true;
			}
			catch (Exception e)
			{
				OnMessage(string.Format("Error {0}: {1}", signal, e));
				return false;
			}
		}

		private bool ExportArrayReadArray(string server, int port, string signal, DateTime dtStart, DateTime dtEnd, List<TSPointWeb> addTo)
		{
			WebClient webClient = new WebClient();

			string reqStr = CreateRequestArray(server, port, signal, dtStart, dtEnd);
			string json = webClient.DownloadString(reqStr);

			if(json.StartsWith("Signal:") && json.Contains("not found"))
			{
				OnMessage(string.Format("Error: {0}. Try again.", json));
				return false;
			}

			if (json.StartsWith("Bad Request Status:"))
			{
				OnMessage(string.Format("Error: {0}", json));
				return false;
			}

			JsonTextReader txtRdr = new JsonTextReader(new StringReader(json));
			TSTypeWeb type = TSTypeWeb.Flag;
			int count = 0;
			while (txtRdr.Read())
			{
				var val = txtRdr.Value;
				if (ObjectAsStringEquals(val, "Type"))
				{
					txtRdr.Read();
					var txtRdrValue = int.Parse(txtRdr.Value.ToString());
					type = (TSTypeWeb) txtRdrValue;
				}

				if (ObjectAsStringEquals(val, "Count"))
				{
					txtRdr.Read();
					count = int.Parse(txtRdr.Value.ToString());
					break;
				}
			}

			OnMessage(string.Format("{0}: {1:yyyy MM dd hh:mm:ss} (local) for {2:F0} hours. Type {3}. Count {4}", signal, dtStart.ToLocalTime(), (dtEnd - dtStart).TotalHours, type, count));

			object o = null;
			DateTime? dt = null;

			while (txtRdr.Read())
			{
				var val = txtRdr.Value;

				if (ObjectAsStringEquals(val, "Value"))
				{
					txtRdr.Read();
					o = txtRdr.Value;
				}

				if (ObjectAsStringEquals(val, "TimeStamp"))
				{
					dt = txtRdr.ReadAsDateTime();
				}

				if (o != null && dt != null)
				{
					addTo.Add(TSWebFactory.Create(type, o, dt.Value));
					o  = null;
					dt = null;
				}
			}

			return true;
		}

		private TSPointWeb ReadPoint(string server, int port, string signal, DateTime dt)
		{
			try
			{
				WebClient webClient = new WebClient();

				string reqStr = CreateRequestPoint(server, port, signal, dt);
				string json = webClient.DownloadString(reqStr);

				if (json.StartsWith("Signal") && json.Contains("not found"))
				{
					OnMessage(string.Format("Error: {0}. Try again.", json));
					return null;
				}

				if (json.StartsWith("Bad Request Status:"))
				{
					OnMessage(string.Format("Error: {0}", json));
					return null;
				}

				if (json.StartsWith("Error: point not found"))
				{
					OnMessage(string.Format("Point not found for {0} at {1} (local)", signal, dt.ToLocalTime()));
					return null;
				}

				JsonTextReader txtRdr = new JsonTextReader(new StringReader(json));

				TSTypeWeb type = TSTypeWeb.Flag;
				int count = 0;
				object val;
				while (txtRdr.Read())
				{
					val = txtRdr.Value;
					if (ObjectAsStringEquals(val, "Type"))
					{
						txtRdr.Read();
						var txtRdrValue = int.Parse(txtRdr.Value.ToString());
						type = (TSTypeWeb)txtRdrValue;
						break;
					}
					else
					{
						if(val != null)
							OnMessage(val.ToString());
					}
				}

				object o = null;
				DateTime? rdt = null;

				while(txtRdr.Read())
				{
					val = txtRdr.Value;

					if (ObjectAsStringEquals(val, "Value"))
					{
						txtRdr.Read();
						o = txtRdr.Value;
					}
				
					if (ObjectAsStringEquals(val, "TimeStamp"))
					{
						rdt = txtRdr.ReadAsDateTime();
					}
				}

				if(o != null && rdt != null)
					return TSWebFactory.Create(type, o, rdt.Value);
				return null;
			}
			catch (Exception e)
			{
				OnMessage("Error: " + e);
				return null;
			}
		}

		private TSVideoWeb ReadVideo(string server, int port, string video, DateTime dt)
		{
			try
			{
				WebClient webClient = new WebClient();

				string reqStr = CreateRequestVideo(server, port, video, dt);

				var data = webClient.DownloadData(reqStr);

				OnMessage("Received data of size: " + data.Length);

				if(data.Length > 0)
				{
					return new TSVideoWeb(new Bitmap(new MemoryStream(data)),dt);
				}

				return null;
			}
			catch (Exception e)
			{
				OnMessage("Error: " + e);
				return null;
			}
		}

		private void WriteCSV(string dir, string signal, DateTime dtStart, DateTime dtEnd, List<TSPointWeb> points)
		{
			if(!dir.EndsWith("\\"))
				dir = dir + "\\";

			string outputFile = string.Format(@"{0}{1} {2:yyyy_MM_dd HHmm} {3:yyyy_MM_dd HHmm}.csv", dir, signal, dtStart, dtEnd);

			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			if (File.Exists(outputFile))
			{
				OnMessage("Deleting " + outputFile);
				File.Delete(outputFile);
			}

			using (var fs = File.OpenWrite(outputFile))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					sw.WriteLine("Time,Value");
					foreach (var p in points)
					{
						sw.WriteLine("{0:O},{1}", p.TimeStamp, p.ValueObject);
					}
					sw.Flush();
					sw.Close();
				}
			}
		}

		private void UpdateProgress(int progress)
		{
			BeginInvoke((MethodInvoker) delegate { progressBar1.Value = progress; });
		}

		private void OnMessage(string msg)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<string>(OnMessage), msg);
				return;
			}

			var time = string.Format("{0:hh:mm:ss.fff}", DateTime.Now.ToLocalTime());

			if (checkBoxLogMessages.Checked)
			{
				var dir = @"C:\temp";
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
				var fileName    = string.Format(@"{0}\{1:yyyy_MM_dd} dvisAPI.txt", dir,  DateTime.Now);
				var fileMessage = string.Format("{0}{1}{2}{3}",                    time, '\t', msg, Environment.NewLine);
				File.AppendAllText(fileName, fileMessage);
			}

			ListViewItem item1 = new ListViewItem(time);
			item1.SubItems.Add(msg);

			listView1.Items.Insert(0, item1);

			if (listView1.Items.Count > 100)
				listView1.Items.RemoveAt(100);
		}

		private bool TryGetPort(out int port)
		{
			return int.TryParse(textBoxPort.Text, out port);
		}

		private void LoadSettings()
		{
			var settings = Properties.Settings.Default;

			string server    = settings.Server;
			string inputFile = settings.InputFile;
			string outputDir = settings.OutputDirectory;


			DateTime dtStart = settings.StartTime;
			DateTime dtEnd   = settings.EndTime;
			DateTime dtVideo = settings.VideoTime;

			string signal = settings.Signal;

			textBoxServer.Text    = server;
			textBoxPort.Text      = settings.Port.ToString();
			textBoxOutputDir.Text = outputDir;
			textBoxInputFile.Text = inputFile;

			if (dtStart != DateTime.MinValue)
				dateTimePickerStart.Value = dtStart;

			if (dtEnd != DateTime.MinValue)
				dateTimePickerEnd.Value = dtEnd;

			if(dtVideo != DateTime.MinValue)
				dateTimePickerVideo.Value = dtVideo;

			textBoxSignal.Text = signal;
			textBoxVideo.Text = settings.VideoSignal;

			checkBoxCombineCSVs.Checked = settings.CombineCSVs;
		}

		private void SaveSettings()
		{
			var settings = Properties.Settings.Default;
			settings.Server          = textBoxServer.Text;
			settings.InputFile       = textBoxInputFile.Text;
			settings.OutputDirectory = textBoxOutputDir.Text;
			settings.OutputDirectory = textBoxOutputDir.Text;
			settings.Signal          = textBoxSignal.Text;
			settings.CombineCSVs     = checkBoxCombineCSVs.Checked;
			settings.VideoSignal     = textBoxVideo.Text;
			

			int port;
			if(TryGetPort(out port))
				settings.Port = port;

			settings.StartTime = dateTimePickerStart.Value;
			settings.EndTime = dateTimePickerEnd.Value;
			settings.VideoTime = dateTimePickerVideo.Value;
			settings.Save();
		}

		private static string CreateRequestPoint(string host, int port, string signal, DateTime dt)
		{
			return string.Format("http://{0}:{1}/api/dvis/signalValue?signal={2}&dt={3:s}", host, port, signal.Replace(" ", "%20"), dt);
		}

		private static string CreateRequestVideo(string host, int port, string signal, DateTime dt)
		{
			return string.Format("http://{0}:{1}/api/dvis/videoFrame?signal={2}&dt={3:s}", host, port, signal.Replace(" ", "%20"), dt);
		}

		private static string CreateRequestArray(string host, int port, string signal, DateTime dtStart, DateTime dtEnd)
		{
			return string.Format("http://{0}:{1}/api/dvis/signalData?signal={2}&dateStart={3:s}&dateEnd={4:s}", host, port, signal.Replace(" ", "%20"), dtStart, dtEnd);
		}

		private static bool ObjectAsStringEquals(object val, string s)
		{
			return val != null && string.Compare(val.ToString(), s, StringComparison.OrdinalIgnoreCase) == 0;
		}
    }

	public class ExportArrayResult
    {
	    public bool   Success { get; private set; }
	    public string Err     { get; private set; }

	    public ExportArrayResult()
	    {
		    Success = true;
	    }

	    public ExportArrayResult(string err)
	    {
		    Err = err;
	    }
    }
}
