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
    public partial class LaserVolumesControl : UserControl
    {
        readonly Action<string> _onMsg;


        CancellationTokenSource _cts;
        int _sortColumn = -1;
        SortOrder _sortOrder = SortOrder.None;
        string _lastCsvResult = null;

        public LaserVolumesControl(Action<string> onMsg)
        {
            _onMsg = onMsg;
            InitializeComponent();
            InitializeAdditionalComponents();
            listViewVolumes.ColumnClick += ListViewVolumes_ColumnClick;
        }

        void InitializeAdditionalComponents()
        {
            Action layoutControls = () =>
            {
                int topOfList = textBoxFilterString.Bottom + 5;
                int listWidth = this.Width - 20;
                int listHeight = this.Height - topOfList - 10;
                listViewVolumes.SetBounds(10, topOfList, listWidth, listHeight);

                buttonSaveCsv.Top = buttonQuery.Top;
                buttonSaveCsv.Left = buttonCancel.Right + 10;

                textBoxFilterString.Width = listWidth;
                textBoxFilterString.Top = buttonQuery.Bottom + 5;
            };
            this.Resize += (s, e) => layoutControls();
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
                url.Append("http://").Append(server).Append("/api/laser/volumes");

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

                    if (!IsCsvData(csv))
                    {
                        _lastCsvResult = null;
                        buttonSaveCsv.Enabled = false;
                        listViewVolumes.Items.Clear();
                        listViewVolumes.Columns.Clear();
                        OnMessage(csv.Trim());
                    }
                    else
                    {
                        int rowCount = DisplayVolumes(csv);
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

        private bool IsCsvData(string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return false;
            if (data.ToLower().Contains("exception")) return false;
            using (var reader = new StringReader(data))
            {
                string header = reader.ReadLine();
                return header != null && header.Contains(",");
            }
        }

        void OnMessage(string s)
        {
            if (_onMsg != null) _onMsg(string.Format("LaserVolumesControl: {0}", s));
        }

        void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }

        int DisplayVolumes(string csv)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Func<string, int>(DisplayVolumes), csv);
                return 0;
            }

            listViewVolumes.Items.Clear();
            listViewVolumes.Columns.Clear();

            int rowCount = 0;
            using (var reader = new StringReader(csv))
            {
                string header = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(header)) return 0;
                var headers = header.Split(',');
                foreach (var h in headers)
                    listViewVolumes.Columns.Add(h.Trim(), 100);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var fields = line.Split(',');
                    var item = new ListViewItem(fields.Length > 0 ? fields[0] : "");
                    for (int i = 1; i < headers.Length; i++)
                        item.SubItems.Add(i < fields.Length ? fields[i] : "");
                    listViewVolumes.Items.Add(item);
                    rowCount++;
                }
            }

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
            textBoxServer.Text = settings.LaserVolumesServer;
            textBoxVessel.Text = settings.LaserVolumesVessel;
            textBoxDateStart.Text = settings.LaserVolumesDateStart;
            textBoxDateEnd.Text = settings.LaserVolumesDateEnd;
            textBoxDb.Text = settings.LaserVolumesDb;
        }

        private void SaveSettings()
        {
            var settings = Properties.Settings.Default;
            settings.LaserVolumesServer = textBoxServer.Text;
            settings.LaserVolumesVessel = textBoxVessel.Text;
            settings.LaserVolumesDateStart = textBoxDateStart.Text;
            settings.LaserVolumesDateEnd = textBoxDateEnd.Text;
            settings.LaserVolumesDb = textBoxDb.Text;
            settings.Save();
        }

        void ListViewVolumes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _sortColumn)
            {
                _sortOrder = _sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                _sortColumn = e.Column;
                _sortOrder = SortOrder.Ascending;
            }
            listViewVolumes.ListViewItemSorter = new ListViewItemComparer(_sortColumn, _sortOrder);
            listViewVolumes.Sort();
        }

void ButtonSaveCsv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_lastCsvResult))
                return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.Title = "Save Volumes CSV";
                sfd.FileName = "volumes.csv";
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
            url.Append("http://").Append(server).Append("/api/laser/volumes");

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

                DateTime da, db;
                if (DateTime.TryParse(a, out da) && DateTime.TryParse(b, out db))
                {
                    int result = DateTime.Compare(da, db);
                    return order == SortOrder.Ascending ? result : -result;
                }

                double fa, fb;
                if (double.TryParse(a, out fa) && double.TryParse(b, out fb))
                {
                    int result = fa.CompareTo(fb);
                    return order == SortOrder.Ascending ? result : -result;
                }

                int stringResult = string.Compare(a, b, StringComparison.CurrentCultureIgnoreCase);
                return order == SortOrder.Ascending ? stringResult : -stringResult;
            }
        }
    }
}
