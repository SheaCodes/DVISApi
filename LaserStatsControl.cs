	using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DVISApi
{
    public partial class LaserStatsControl : UserControl
    {
	    TextBox textBoxServer;
	    TextBox textBoxVessel;
	    TextBox textBoxDateStart;
	    TextBox textBoxDateEnd;
	    TextBox textBoxDb;
	    Button buttonQuery;
	    Button buttonCancel;
	    ListView listViewCampaigns;
	    Label labelServer, labelVessel, labelDateStart, labelDateEnd, labelDb;

	    CancellationTokenSource _cts;

        public LaserStatsControl()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        void InitializeCustomControls()
        {
            labelServer = new Label { Text = "Server", Location = new Point(10, 10), AutoSize = true };
            labelVessel = new Label { Text = "Vessel", Location = new Point(10, 40), AutoSize = true };
            labelDateStart = new Label { Text = "Date Start", Location = new Point(10, 70), AutoSize = true };
            labelDateEnd = new Label { Text = "Date End", Location = new Point(10, 100), AutoSize = true };
            labelDb = new Label { Text = "DB", Location = new Point(10, 130), AutoSize = true };

            textBoxServer = new TextBox { Location = new Point(80, 10), Width = 200, Text = "10.28.13.71:5123" };
            textBoxVessel = new TextBox { Location = new Point(80, 40), Width = 200 };
            textBoxDateStart = new TextBox { Location = new Point(80, 70), Width = 200 };
            textBoxDateEnd = new TextBox { Location = new Point(80, 100), Width = 200 };
            textBoxDb = new TextBox { Location = new Point(80, 130), Width = 200 };

            buttonQuery = new Button { Text = "Query", Location = new Point(80, 160), Width = 100 };
            buttonQuery.Click += ButtonQuery_Click;

            buttonCancel = new Button { Text = "Cancel", Location = new Point(190, 160), Width = 100, Enabled = false };
            buttonCancel.Click += ButtonCancel_Click;

            listViewCampaigns = new ListView
            {
                Location = new Point(10, 200),
                Width = 700,
                Height = 300,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            listViewCampaigns.Columns.Add("StartDate", 140);
            listViewCampaigns.Columns.Add("EndDate", 140);
            listViewCampaigns.Columns.Add("VesselId", 70);
            listViewCampaigns.Columns.Add("NumScans", 70);
            listViewCampaigns.Columns.Add("FirstScan", 100);
            listViewCampaigns.Columns.Add("LastScan", 100);
            listViewCampaigns.Columns.Add("Heats", 70);

            Controls.Add(labelServer);
            Controls.Add(labelVessel);
            Controls.Add(labelDateStart);
            Controls.Add(labelDateEnd);
            Controls.Add(labelDb);
            Controls.Add(textBoxServer);
            Controls.Add(textBoxVessel);
            Controls.Add(textBoxDateStart);
            Controls.Add(textBoxDateEnd);
            Controls.Add(textBoxDb);
            Controls.Add(buttonQuery);
            Controls.Add(buttonCancel);
            Controls.Add(listViewCampaigns);
        }

        async void ButtonQuery_Click(object sender, EventArgs e)
        {
            DisableAllControls();
            buttonCancel.Enabled = true;
            _cts = new CancellationTokenSource();
            _cts.CancelAfter(TimeSpan.FromMinutes(1));

            try
            {
                string server = textBoxServer.Text.Trim();
                string vessel = textBoxVessel.Text.Trim();
                string dateStart = textBoxDateStart.Text.Trim();
                string dateEnd = textBoxDateEnd.Text.Trim();
                string db = textBoxDb.Text.Trim();

                var url = new StringBuilder();
                url.Append("http://").Append(server).Append("/api/laser/campaigns");

                var parameters = new List<string>();
                if (!string.IsNullOrEmpty(vessel))
                    parameters.Add("vessel=" + Uri.EscapeDataString(vessel));
                if (!string.IsNullOrEmpty(dateStart))
                    parameters.Add("dateStart=" + Uri.EscapeDataString(dateStart));
                if (!string.IsNullOrEmpty(dateEnd))
                    parameters.Add("dateEnd=" + Uri.EscapeDataString(dateEnd));
                if (!string.IsNullOrEmpty(db))
                    parameters.Add("db=" + Uri.EscapeDataString(db));

                if (parameters.Count > 0)
                    url.Append("?").Append(string.Join("&", parameters));

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url.ToString(), _cts.Token);
                    response.EnsureSuccessStatusCode();
                    var csv = await response.Content.ReadAsStringAsync();
                    DisplayCampaigns(csv);
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Request was cancelled or timed out.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error querying API: " + ex.Message);
            }
            finally
            {
                EnableAllControls();
                buttonCancel.Enabled = false;
                _cts = null;
            }
        }

        void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }

        void DisplayCampaigns(string csv)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(DisplayCampaigns), csv);
                return;
            }
            listViewCampaigns.Items.Clear();
            using (var reader = new StringReader(csv))
            {
                string header = reader.ReadLine(); // skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var fields = line.Split(',');
                    if (fields.Length < 7) continue;
                    var item = new ListViewItem(fields[0]);
                    for (int i = 1; i < 7; i++)
                        item.SubItems.Add(fields[i]);
                    listViewCampaigns.Items.Add(item);
                }
            }
        }

        void DisableAllControls()
        {
            foreach (Control c in Controls)
                if (c != buttonCancel)
                    c.Enabled = false;
        }

        void EnableAllControls()
        {
            foreach (Control c in Controls)
                c.Enabled = true;
        }
    }
}
