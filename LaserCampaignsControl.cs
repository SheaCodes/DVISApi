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
    public partial class LaserCampaignsControl : UserControl
    {
	    readonly Action<string> _onMsg;
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

        int _sortColumn = -1;
        SortOrder _sortOrder = SortOrder.None;

        private string _lastCsvResult = null;
        private Button buttonSaveCsv;

        CheckBox checkBoxIncludeVessel;
        TextBox textBoxFilterString;

        public LaserCampaignsControl(Action<string> onMsg)
        {
	        _onMsg = onMsg;
            
	        InitializeComponent();
            InitializeCustomControls();
            listViewCampaigns.ColumnClick += ListViewCampaigns_ColumnClick;
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

			checkBoxIncludeVessel = new CheckBox
			{
				Text = "Include",
				Location = new Point(textBoxVessel.Right + 5, textBoxVessel.Top + 2),
				AutoSize = true,
				Checked = true
			};
			Controls.Add(checkBoxIncludeVessel);

			buttonQuery = new Button { Text = "Query", Location = new Point(80, 160), Width = 100 };
			buttonQuery.Click += ButtonQuery_Click;

			buttonCancel = new Button { Text = "Cancel", Location = new Point(190, 160), Width = 100, Enabled = false };
			buttonCancel.Click += ButtonCancel_Click;

			buttonSaveCsv = new Button { Text = "Save to CSV", Location = new Point(300, 160), Width = 120, Enabled = false };
			buttonSaveCsv.Click += ButtonSaveCsv_Click;

			textBoxFilterString = new TextBox
			{
				Location = new Point(10, buttonQuery.Bottom + 5),
				Width = this.Width - 20,
				ReadOnly = true,
				Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
			};
			Controls.Add(textBoxFilterString);

			listViewCampaigns = new ListView
			{
				View = View.Details,
				FullRowSelect = true,
				GridLines = true,
				Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right, // Anchor left and bottom
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
			Controls.Add(buttonSaveCsv);
			Controls.Add(listViewCampaigns);

			// Layout method for both initial and resize
			Action layoutControls = () =>
			{
				int topOfList = textBoxFilterString.Bottom + 5;
				int listWidth = this.Width / 2;
				int listHeight = this.Height - topOfList - 10;
				listViewCampaigns.SetBounds(10, topOfList, listWidth, listHeight);

				// Optionally, keep Save button aligned with others
				buttonSaveCsv.Top = buttonQuery.Top;
				buttonSaveCsv.Left = buttonCancel.Right + 10;

				textBoxFilterString.Width = 800;
				textBoxFilterString.Top = buttonQuery.Bottom + 5;
			};

			// Set up layout in the parent control's Resize event
			this.Resize += (s, e) => layoutControls();

			// Initial layout
			layoutControls();

			textBoxServer.TextChanged += (s, e) => UpdateFilterString();
			textBoxVessel.TextChanged += (s, e) => UpdateFilterString();
			checkBoxIncludeVessel.CheckedChanged += (s, e) => UpdateFilterString();
			textBoxDateStart.TextChanged += (s, e) => UpdateFilterString();
			textBoxDateEnd.TextChanged += (s, e) => UpdateFilterString();
			textBoxDb.TextChanged += (s, e) => UpdateFilterString();

			LoadSettings();
			UpdateFilterString();
		}

        async void ButtonQuery_Click(object sender, EventArgs e)
        {
            SaveSettings();
            OnMessage("ButtonQuery_Click");
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
                if (checkBoxIncludeVessel.Checked && !string.IsNullOrWhiteSpace(vessel))
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
                    OnMessage("Querying API: " + url.ToString());
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    var response = await client.GetAsync(url.ToString(), _cts.Token);
                    response.EnsureSuccessStatusCode();
                    var csv = await response.Content.ReadAsStringAsync();

                    // Check for error message instead of CSV
                    if (!IsCsvData(csv))
                    {
                        _lastCsvResult = null;
                        buttonSaveCsv.Enabled = false;
                        listViewCampaigns.Items.Clear();
                        OnMessage(csv.Trim());
                    }
                    else
                    {
                        int rowCount = DisplayCampaigns(csv);
                        sw.Stop();
                        OnMessage(string.Format("Retrieved {0} rows in {1:0.00} seconds", rowCount, sw.Elapsed.TotalSeconds));
                    }
                }
            }
            catch (OperationCanceledException)
            {
                OnMessage("Request was cancelled or timed out.");
            }
            catch (Exception ex)
            {
                OnMessage("Error querying API: " + ex.Message);
            }
            finally
            {
                EnableAllControls();
                buttonCancel.Enabled = false;
                _cts = null;
            }
        }

        // Add this helper method to your class
        private bool IsCsvData(string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return false;
			if (data.ToLower().Contains("Exception")) return false;
			// Heuristic: CSV should have at least one comma in the header line
			using (var reader = new StringReader(data))
            {
                string header = reader.ReadLine();
                return header != null && header.Contains(",");
            }
        }

        void OnMessage(string s)
        {
	        if (_onMsg != null) _onMsg(string.Format("LaserStatsControl: {0}", s));
        }

        void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }

        int DisplayCampaigns(string csv)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Func<string,int>(DisplayCampaigns), csv);
                return 0;
            }
            listViewCampaigns.Items.Clear();
            int rowCount = 0;
            using (var reader = new StringReader(csv))
            {
                string header = reader.ReadLine(); // skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var fields = line.Split(',');
                    if (fields.Length < 7) continue;

                    // Format StartDate and EndDate as yyyy-MM-dd
                    string startDate = fields[0];
                    string endDate = fields[1];
                    DateTime dt;
                    if (DateTime.TryParse(startDate, out dt))
                        startDate = dt.ToString("yyyy-MM-dd");
                    if (DateTime.TryParse(endDate, out dt))
                        endDate = dt.ToString("yyyy-MM-dd");

                    var item = new ListViewItem(startDate);
                    item.SubItems.Add(endDate);
                    for (int i = 2; i < 7; i++)
                        item.SubItems.Add(fields[i]);
                    listViewCampaigns.Items.Add(item);
                    rowCount++;
                }
            }
            // Store the CSV only if there are rows
            if (rowCount > 0)
            {
                _lastCsvResult = csv;
                buttonSaveCsv.Enabled = true;
            }
            else
            {
                _lastCsvResult = null;
                buttonSaveCsv.Enabled = false;
            }
            return rowCount;
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

        private void LoadSettings()
        {
            var settings = Properties.Settings.Default;
            textBoxServer.Text    = settings.LaserCampaignServer;
            textBoxVessel.Text    = settings.LaserCampaignVessel;
            textBoxDateStart.Text = settings.LaserCampaignDateStart;
            textBoxDateEnd.Text   = settings.LaserCampaignDateEnd;
            textBoxDb.Text        = settings.LaserCampaignDb;
        }

        private void SaveSettings()
        {
            var settings = Properties.Settings.Default;
            settings.LaserCampaignServer    = textBoxServer.Text;
            settings.LaserCampaignVessel    = textBoxVessel.Text;
            settings.LaserCampaignDateStart = textBoxDateStart.Text;
            settings.LaserCampaignDateEnd   = textBoxDateEnd.Text;
            settings.LaserCampaignDb        = textBoxDb.Text;
            settings.Save();
        }

        void ListViewCampaigns_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _sortColumn)
            {
                // Toggle sort order
                _sortOrder = _sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                _sortColumn = e.Column;
                _sortOrder = SortOrder.Ascending;
            }
            listViewCampaigns.ListViewItemSorter = new ListViewItemComparer(_sortColumn, _sortOrder);
            listViewCampaigns.Sort();
        }

        void ButtonSaveCsv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_lastCsvResult))
                return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.Title = "Save Campaigns CSV";
                sfd.FileName = "campaigns.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, _lastCsvResult, Encoding.UTF8);
                        OnMessage("Saved CSV to: " + sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        OnMessage("Error saving CSV: " + ex.Message);
                    }
                }
            }
        }

        void UpdateFilterString()
        {
            string server = textBoxServer.Text.Trim();
            if (string.IsNullOrEmpty(server))
            {
                textBoxFilterString.Text = "";
                return;
            }

            var url = new StringBuilder();
            url.Append("http://").Append(server).Append("/api/laser/campaigns");

            var parameters = new List<string>();
            if (checkBoxIncludeVessel.Checked && !string.IsNullOrWhiteSpace(textBoxVessel.Text))
                parameters.Add("vessel=" + Uri.EscapeDataString(textBoxVessel.Text.Trim()));
            if (!string.IsNullOrWhiteSpace(textBoxDateStart.Text))
                parameters.Add("dateStart=" + Uri.EscapeDataString(textBoxDateStart.Text.Trim()));
            if (!string.IsNullOrWhiteSpace(textBoxDateEnd.Text))
                parameters.Add("dateEnd=" + Uri.EscapeDataString(textBoxDateEnd.Text.Trim()));
            if (!string.IsNullOrWhiteSpace(textBoxDb.Text))
                parameters.Add("db=" + Uri.EscapeDataString(textBoxDb.Text.Trim()));

            if (parameters.Count > 0)
                url.Append("?").Append(string.Join("&", parameters));

            textBoxFilterString.Text = url.ToString();
        }

        class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private SortOrder order;

            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                string a = ((ListViewItem)x).SubItems[col].Text;
                string b = ((ListViewItem)y).SubItems[col].Text;

                // Try to compare as DateTime
                DateTime da, db;
                if (DateTime.TryParse(a, out da) && DateTime.TryParse(b, out db))
                {
                    int result = DateTime.Compare(da, db);
                    return order == SortOrder.Ascending ? result : -result;
                }

                // Try to compare as double
                double fa, fb;
                if (double.TryParse(a, out fa) && double.TryParse(b, out fb))
                {
                    int result = fa.CompareTo(fb);
                    return order == SortOrder.Ascending ? result : -result;
                }

                // Fallback to string comparison
                int stringResult = string.Compare(a, b, StringComparison.CurrentCultureIgnoreCase);
                return order == SortOrder.Ascending ? stringResult : -stringResult;
            }
        }
    }
}
