namespace DVISApi
{
    partial class LaserStatsControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxVessel;
        private System.Windows.Forms.TextBox textBoxDateStart;
        private System.Windows.Forms.TextBox textBoxDateEnd;
        private System.Windows.Forms.TextBox textBoxDb;
        private System.Windows.Forms.ComboBox comboBoxStat;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveCsv;
        private System.Windows.Forms.ListView listViewStats;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelVessel;
        private System.Windows.Forms.Label labelDateStart;
        private System.Windows.Forms.Label labelDateEnd;
        private System.Windows.Forms.Label labelDb;
        private System.Windows.Forms.Label labelStat;
        private System.Windows.Forms.CheckBox checkBoxIncludeVessel;
        private System.Windows.Forms.TextBox textBoxFilterString;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelServer = new System.Windows.Forms.Label();
            this.labelVessel = new System.Windows.Forms.Label();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.labelDb = new System.Windows.Forms.Label();
            this.labelStat = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxVessel = new System.Windows.Forms.TextBox();
            this.textBoxDateStart = new System.Windows.Forms.TextBox();
            this.textBoxDateEnd = new System.Windows.Forms.TextBox();
            this.textBoxDb = new System.Windows.Forms.TextBox();
            this.comboBoxStat = new System.Windows.Forms.ComboBox();
            this.checkBoxIncludeVessel = new System.Windows.Forms.CheckBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveCsv = new System.Windows.Forms.Button();
            this.textBoxFilterString = new System.Windows.Forms.TextBox();
            this.listViewStats = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(10, 10);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(41, 15);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "Server";
            // 
            // labelVessel
            // 
            this.labelVessel.AutoSize = true;
            this.labelVessel.Location = new System.Drawing.Point(10, 40);
            this.labelVessel.Name = "labelVessel";
            this.labelVessel.Size = new System.Drawing.Size(42, 15);
            this.labelVessel.TabIndex = 1;
            this.labelVessel.Text = "Vessel";
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Location = new System.Drawing.Point(10, 70);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(63, 15);
            this.labelDateStart.TabIndex = 2;
            this.labelDateStart.Text = "Date Start";
            // 
            // labelDateEnd
            // 
            this.labelDateEnd.AutoSize = true;
            this.labelDateEnd.Location = new System.Drawing.Point(10, 100);
            this.labelDateEnd.Name = "labelDateEnd";
            this.labelDateEnd.Size = new System.Drawing.Size(61, 15);
            this.labelDateEnd.TabIndex = 3;
            this.labelDateEnd.Text = "Date End";
            // 
            // labelDb
            // 
            this.labelDb.AutoSize = true;
            this.labelDb.Location = new System.Drawing.Point(10, 130);
            this.labelDb.Name = "labelDb";
            this.labelDb.Size = new System.Drawing.Size(24, 15);
            this.labelDb.TabIndex = 4;
            this.labelDb.Text = "DB";
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.Location = new System.Drawing.Point(10, 160);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(29, 15);
            this.labelStat.TabIndex = 5;
            this.labelStat.Text = "Stat";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(80, 10);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(200, 23);
            this.textBoxServer.TabIndex = 6;
            this.textBoxServer.Text = "10.28.13.71:5123";
            // 
            // textBoxVessel
            // 
            this.textBoxVessel.Location = new System.Drawing.Point(80, 40);
            this.textBoxVessel.Name = "textBoxVessel";
            this.textBoxVessel.Size = new System.Drawing.Size(200, 23);
            this.textBoxVessel.TabIndex = 7;
            // 
            // textBoxDateStart
            // 
            this.textBoxDateStart.Location = new System.Drawing.Point(80, 70);
            this.textBoxDateStart.Name = "textBoxDateStart";
            this.textBoxDateStart.Size = new System.Drawing.Size(200, 23);
            this.textBoxDateStart.TabIndex = 8;
            // 
            // textBoxDateEnd
            // 
            this.textBoxDateEnd.Location = new System.Drawing.Point(80, 100);
            this.textBoxDateEnd.Name = "textBoxDateEnd";
            this.textBoxDateEnd.Size = new System.Drawing.Size(200, 23);
            this.textBoxDateEnd.TabIndex = 9;
            // 
            // textBoxDb
            // 
            this.textBoxDb.Location = new System.Drawing.Point(80, 130);
            this.textBoxDb.Name = "textBoxDb";
            this.textBoxDb.Size = new System.Drawing.Size(200, 23);
            this.textBoxDb.TabIndex = 10;
            // 
            // comboBoxStat
            // 
            this.comboBoxStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStat.FormattingEnabled = true;
            this.comboBoxStat.Items.AddRange(new object[] {
                "Average",
                "Average10cmCylinderThinnestMargin",
                "Average10cmCylinderThickestMargin",
                "Average10cmCylinder",
                "AverageMax10cmCylinder",
                "EntireRegionAverageMargin",
                "ThinnestPointMargin",
                "NumPointsInRegion",
                "PercentCoverage"});
            this.comboBoxStat.Location = new System.Drawing.Point(80, 160);
            this.comboBoxStat.Name = "comboBoxStat";
            this.comboBoxStat.Size = new System.Drawing.Size(200, 23);
            this.comboBoxStat.TabIndex = 11;
            // 
            // checkBoxIncludeVessel
            // 
            this.checkBoxIncludeVessel.AutoSize = true;
            this.checkBoxIncludeVessel.Checked = true;
            this.checkBoxIncludeVessel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeVessel.Location = new System.Drawing.Point(285, 42);
            this.checkBoxIncludeVessel.Name = "checkBoxIncludeVessel";
            this.checkBoxIncludeVessel.Size = new System.Drawing.Size(65, 19);
            this.checkBoxIncludeVessel.TabIndex = 12;
            this.checkBoxIncludeVessel.Text = "Include";
            this.checkBoxIncludeVessel.UseVisualStyleBackColor = true;
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(80, 190);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(100, 23);
            this.buttonQuery.TabIndex = 13;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(190, 190);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSaveCsv
            // 
            this.buttonSaveCsv.Enabled = false;
            this.buttonSaveCsv.Location = new System.Drawing.Point(300, 190);
            this.buttonSaveCsv.Name = "buttonSaveCsv";
            this.buttonSaveCsv.Size = new System.Drawing.Size(120, 23);
            this.buttonSaveCsv.TabIndex = 15;
            this.buttonSaveCsv.Text = "Save to CSV";
            this.buttonSaveCsv.UseVisualStyleBackColor = true;
            this.buttonSaveCsv.Click += new System.EventHandler(this.ButtonSaveCsv_Click);
            // 
            // textBoxFilterString
            // 
            this.textBoxFilterString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilterString.Location = new System.Drawing.Point(10, 218);
            this.textBoxFilterString.Name = "textBoxFilterString";
            this.textBoxFilterString.ReadOnly = true;
            this.textBoxFilterString.Size = new System.Drawing.Size(0, 23);
            this.textBoxFilterString.TabIndex = 16;
            // 
            // listViewStats
            // 
            this.listViewStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewStats.FullRowSelect = true;
            this.listViewStats.GridLines = true;
            this.listViewStats.Location = new System.Drawing.Point(10, 246);
            this.listViewStats.Name = "listViewStats";
            this.listViewStats.Size = new System.Drawing.Size(0, 0);
            this.listViewStats.TabIndex = 17;
            this.listViewStats.UseCompatibleStateImageBehavior = false;
            this.listViewStats.View = System.Windows.Forms.View.Details;
            // 
            // LaserStatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewStats);
            this.Controls.Add(this.textBoxFilterString);
            this.Controls.Add(this.buttonSaveCsv);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.checkBoxIncludeVessel);
            this.Controls.Add(this.comboBoxStat);
            this.Controls.Add(this.textBoxDb);
            this.Controls.Add(this.textBoxDateEnd);
            this.Controls.Add(this.textBoxDateStart);
            this.Controls.Add(this.textBoxVessel);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.labelStat);
            this.Controls.Add(this.labelDb);
            this.Controls.Add(this.labelDateEnd);
            this.Controls.Add(this.labelDateStart);
            this.Controls.Add(this.labelVessel);
            this.Controls.Add(this.labelServer);
            this.Name = "LaserStatsControl";
            this.Size = new System.Drawing.Size(500, 400);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
