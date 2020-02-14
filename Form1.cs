using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

			var settings = Properties.Settings.Default;
			string server = settings.Server;
			string inputFile = settings.InputFile;
			string outputDir = settings.OutputDirectory;
			double hours = settings.Hours;
			DateTime dtStart = settings.StartTime;

			textBoxServer.Text = server;
			textBoxOutputDir.Text = outputDir;
			textBoxInputFile.Text = inputFile;
			textBoxDuration.Text = hours.ToString();
			if(dtStart != DateTime.MinValue)
				dateTimePickerStart.Value = dtStart;
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

			double hours;
			if (!TryGetHours(out hours))
			{
				OnMessage(string.Format("Can not parse: {0} as number", textBoxDuration.Text));
				return;
			}

			if (hours <= 0d)
			{
				OnMessage(string.Format("Hours ({0}) must be > 0", hours));
				return;
			}

			DateTime dtStartLocal = dateTimePickerStart.Value;
			DateTime dtEndLocal = dtStartLocal.AddHours(hours);

			if (dtStartLocal > DateTime.Now)
			{
				OnMessage("Start is later than now");
				return;
			}

			SaveSettings();

			buttonGo.Enabled     = false;
			buttonCancel.Enabled = true;

			ThreadPool.QueueUserWorkItem(delegate
			{
				try
				{
					TimeSpan tsBatchSize = TimeSpan.FromHours(4);

					var lines = File.ReadAllLines(signalFile);
					int todo = lines.Length;

					int batchesPerSignal = (int)((dtEndLocal - dtStartLocal).TotalSeconds / tsBatchSize.TotalSeconds) + 1;
					int totalBatches = batchesPerSignal * todo;

					int batchesComplete = 0;
					int signalsComplete = 0;

					foreach (string line in lines)
					{
						string signalName = line.Trim();

						Action onBatchComplete = delegate
						{
							batchesComplete++;
							int progress = (int)Math.Round(100d * batchesComplete / totalBatches);
							UpdateProgress(progress);
						};

						DateTime dtStartUtc = dtStartLocal.ToUniversalTime();
						DateTime dtEndUtc = dtEndLocal.ToUniversalTime();
						List<TSPointWeb> points = DoBatchedRequest(server, signalName, dtStartUtc, dtEndUtc, tsBatchSize, onBatchComplete);
						if (_cancel)
						{
							OnMessage("Cancelled");
							return;
						}

						if (points != null)
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
			});
		}

		private void OnClickCancel(object sender, EventArgs e)
		{
			OnMessage("Cancel request received");
			_cancel = true;
		}

		private static string CreateRequestString(string host, int port, string signal, DateTime dtStart, DateTime dtEnd)
		{
			return string.Format("http://{0}:{1}/api/dvis/signalData?signal={2}&dateStart={3:s}&dateEnd={4:s}", host, port, signal.Replace(" ", "%20"), dtStart, dtEnd);
		}

		private List<TSPointWeb> DoBatchedRequest(string server, string signal, DateTime dtStartUtc, DateTime dtEndUtc, TimeSpan tsBatchSize, Action onBatchComplete)
		{
			try
			{
				List<TSPointWeb> points = new List<TSPointWeb>();
				

				DateTime dtBatchStart = dtStartUtc;
				DateTime dtBatchEnd = dtBatchStart + tsBatchSize;

				while (true)
				{
					DateTime dtReqStart = dtBatchStart;
					DateTime dtReqEnd = dtBatchEnd > dtEndUtc ? dtEndUtc : dtBatchEnd;

					if (!DoRequest(server, signal, dtReqStart, dtReqEnd, points))
						return null;

					if (onBatchComplete != null)
						onBatchComplete();

					if (dtBatchEnd >= dtEndUtc)
						break;

					if (_cancel)
					{
						OnMessage("Cancel request acknowledged");
						return null;
					}

					dtBatchStart = dtBatchEnd;
					dtBatchEnd   = dtBatchStart + tsBatchSize;
				}

				return points;
			}
			catch (Exception e)
			{
				OnMessage(string.Format("Error {0}: {1}", signal, e));
			}

			return null;
		}

		private bool DoRequest(string server, string signal, DateTime dtReqStart, DateTime dtReqEnd, List<TSPointWeb> points)
		{
			WebClient webClient = new WebClient();

			string reqStr = CreateRequestString(server, 5123, signal, dtReqStart, dtReqEnd);
			string json = webClient.DownloadString(reqStr);

			if(json.StartsWith("Signal:") && json.EndsWith("not found"))
			{
				OnMessage(string.Format("Error: {0}. Try again.", json));
				return false;
			}

			JsonTextReader txtRdr = new JsonTextReader(new StringReader(json));
			TSTypeWeb type = TSTypeWeb.Flag;
			int count = 0;
			while (txtRdr.Read())
			{
				var val = txtRdr.Value;
				if (StringEquals(val, "Type"))
				{
					txtRdr.Read();
					var txtRdrValue = int.Parse(txtRdr.Value.ToString());
					type = (TSTypeWeb) txtRdrValue;
				}

				if (StringEquals(val, "Count"))
				{
					txtRdr.Read();
					count = int.Parse(txtRdr.Value.ToString());
					break;
				}
			}

			OnMessage(string.Format("{0}: {1:yyyy MM dd hh:mm:ss} (local) for {2:F0} hours. Type {3}. Count {4}", signal, dtReqStart.ToLocalTime(), (dtReqEnd - dtReqStart).TotalHours, type, count));

			object o = null;
			DateTime? dt = null;

			while (txtRdr.Read())
			{
				var val = txtRdr.Value;

				if (StringEquals(val, "Value"))
				{
					txtRdr.Read();
					o = txtRdr.Value;
				}

				if (StringEquals(val, "TimeStamp"))
				{
					dt = txtRdr.ReadAsDateTime();
				}

				if (o != null && dt != null)
				{
					points.Add(TSWebFactory.Create(type, o, dt.Value));
					o  = null;
					dt = null;
				}
			}

			return true;
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

		private static bool StringEquals(object val, string type)
		{
			return val != null && val.ToString() == type;
		}

		private void OnMessage(string msg)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<string>(OnMessage), msg);
				return;
			}

			ListViewItem item1 = new ListViewItem(string.Format("{0:hh:mm:ss.fff}", DateTime.Now.ToLocalTime()));
			item1.SubItems.Add(msg);

			listView1.Items.Insert(0, item1);

			if(listView1.Items.Count > 100)
				listView1.Items.RemoveAt(100);
		}

		private bool TryGetHours(out double hours)
		{
			return double.TryParse(textBoxDuration.Text, out hours);
		}

		private void SaveSettings()
		{
			var settings = Properties.Settings.Default;
			settings.Server          = textBoxServer.Text;
			settings.InputFile       = textBoxInputFile.Text;
			settings.OutputDirectory = textBoxOutputDir.Text;
			settings.OutputDirectory = textBoxOutputDir.Text;

			double hours;
			if (TryGetHours(out hours))
				settings.Hours = hours;

			settings.StartTime = dateTimePickerStart.Value;
			settings.Save();
		}
    }
}
