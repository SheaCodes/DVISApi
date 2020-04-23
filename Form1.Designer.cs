namespace DVISApi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSignalFIle = new System.Windows.Forms.Label();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.buttonSignalFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEnd = new System.Windows.Forms.Label();
            this.checkBoxCombineCSVs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLocal = new System.Windows.Forms.Label();
            this.buttonOutputDir = new System.Windows.Forms.Button();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelSignal = new System.Windows.Forms.Label();
            this.textBoxSignal = new System.Windows.Forms.TextBox();
            this.buttonReadCurrentValue = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxLogMessages = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSignalFIle
            // 
            this.labelSignalFIle.AutoSize = true;
            this.labelSignalFIle.Location = new System.Drawing.Point(4, 27);
            this.labelSignalFIle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSignalFIle.Name = "labelSignalFIle";
            this.labelSignalFIle.Size = new System.Drawing.Size(55, 13);
            this.labelSignalFIle.TabIndex = 0;
            this.labelSignalFIle.Text = "Signal File";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(64, 24);
            this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(335, 20);
            this.textBoxInputFile.TabIndex = 1;
            // 
            // buttonSignalFile
            // 
            this.buttonSignalFile.Location = new System.Drawing.Point(401, 23);
            this.buttonSignalFile.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSignalFile.Name = "buttonSignalFile";
            this.buttonSignalFile.Size = new System.Drawing.Size(60, 20);
            this.buttonSignalFile.TabIndex = 2;
            this.buttonSignalFile.Text = "Choose";
            this.buttonSignalFile.UseVisualStyleBackColor = true;
            this.buttonSignalFile.Click += new System.EventHandler(this.OnClickSignalFile);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(1320, 238);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(1, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1318, 223);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxLogMessages);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dateTimePickerEnd);
            this.tabPage1.Controls.Add(this.labelEnd);
            this.tabPage1.Controls.Add(this.checkBoxCombineCSVs);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxPort);
            this.tabPage1.Controls.Add(this.labelServer);
            this.tabPage1.Controls.Add(this.buttonCancel);
            this.tabPage1.Controls.Add(this.textBoxInputFile);
            this.tabPage1.Controls.Add(this.labelLocal);
            this.tabPage1.Controls.Add(this.buttonSignalFile);
            this.tabPage1.Controls.Add(this.buttonOutputDir);
            this.tabPage1.Controls.Add(this.labelSignalFIle);
            this.tabPage1.Controls.Add(this.textBoxOutputDir);
            this.tabPage1.Controls.Add(this.dateTimePickerStart);
            this.tabPage1.Controls.Add(this.labelOutputDirectory);
            this.tabPage1.Controls.Add(this.labelStart);
            this.tabPage1.Controls.Add(this.textBoxServer);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.buttonGo);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1310, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Range";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "local";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "MMMM dd, yyyy - h:mm:ss tt";
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(64, 92);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(229, 21);
            this.dateTimePickerEnd.TabIndex = 21;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(30, 97);
            this.labelEnd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(26, 13);
            this.labelEnd.TabIndex = 22;
            this.labelEnd.Text = "End";
            // 
            // checkBoxCombineCSVs
            // 
            this.checkBoxCombineCSVs.AutoSize = true;
            this.checkBoxCombineCSVs.Location = new System.Drawing.Point(188, 120);
            this.checkBoxCombineCSVs.Name = "checkBoxCombineCSVs";
            this.checkBoxCombineCSVs.Size = new System.Drawing.Size(131, 17);
            this.checkBoxCombineCSVs.TabIndex = 20;
            this.checkBoxCombineCSVs.Text = "Combine CSVs to One";
            this.checkBoxCombineCSVs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(325, 1);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxPort.TabIndex = 18;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(4, 3);
            this.labelServer.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 11;
            this.labelServer.Text = "Server";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(124, 118);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 20);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(297, 75);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(29, 13);
            this.labelLocal.TabIndex = 16;
            this.labelLocal.Text = "local";
            // 
            // buttonOutputDir
            // 
            this.buttonOutputDir.Location = new System.Drawing.Point(401, 45);
            this.buttonOutputDir.Margin = new System.Windows.Forms.Padding(1);
            this.buttonOutputDir.Name = "buttonOutputDir";
            this.buttonOutputDir.Size = new System.Drawing.Size(60, 20);
            this.buttonOutputDir.TabIndex = 15;
            this.buttonOutputDir.Text = "Choose";
            this.buttonOutputDir.UseVisualStyleBackColor = true;
            this.buttonOutputDir.Click += new System.EventHandler(this.OnClickOutputDir);
            // 
            // textBoxOutputDir
            // 
            this.textBoxOutputDir.Location = new System.Drawing.Point(64, 47);
            this.textBoxOutputDir.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.Size = new System.Drawing.Size(335, 20);
            this.textBoxOutputDir.TabIndex = 14;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "MMMM dd, yyyy - h:mm:ss tt";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(64, 70);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(229, 21);
            this.dateTimePickerStart.TabIndex = 3;
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(4, 51);
            this.labelOutputDirectory.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(55, 13);
            this.labelOutputDirectory.TabIndex = 13;
            this.labelOutputDirectory.Text = "Output Dir";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(30, 75);
            this.labelStart.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(29, 13);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "Start";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(64, 1);
            this.textBoxServer.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(229, 20);
            this.textBoxServer.TabIndex = 12;
            this.textBoxServer.Text = "10.141.26.201";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Progress";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(62, 118);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(1);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(60, 20);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.OnClickGo);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(62, 147);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 24);
            this.progressBar1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelSignal);
            this.tabPage2.Controls.Add(this.textBoxSignal);
            this.tabPage2.Controls.Add(this.buttonReadCurrentValue);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1310, 197);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Single Point";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelSignal
            // 
            this.labelSignal.AutoSize = true;
            this.labelSignal.Location = new System.Drawing.Point(6, 12);
            this.labelSignal.Name = "labelSignal";
            this.labelSignal.Size = new System.Drawing.Size(36, 13);
            this.labelSignal.TabIndex = 2;
            this.labelSignal.Text = "Signal";
            // 
            // textBoxSignal
            // 
            this.textBoxSignal.Location = new System.Drawing.Point(48, 9);
            this.textBoxSignal.Name = "textBoxSignal";
            this.textBoxSignal.Size = new System.Drawing.Size(155, 20);
            this.textBoxSignal.TabIndex = 1;
            // 
            // buttonReadCurrentValue
            // 
            this.buttonReadCurrentValue.Location = new System.Drawing.Point(209, 7);
            this.buttonReadCurrentValue.Name = "buttonReadCurrentValue";
            this.buttonReadCurrentValue.Size = new System.Drawing.Size(145, 23);
            this.buttonReadCurrentValue.TabIndex = 0;
            this.buttonReadCurrentValue.Text = "Read Current Value";
            this.buttonReadCurrentValue.UseVisualStyleBackColor = true;
            this.buttonReadCurrentValue.Click += new System.EventHandler(this.OnClickReadCurrentValue);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderMsg});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 243);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1316, 542);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 90;
            // 
            // columnHeaderMsg
            // 
            this.columnHeaderMsg.Text = "Message";
            this.columnHeaderMsg.Width = 876;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1322, 788);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // checkBoxLogMessages
            // 
            this.checkBoxLogMessages.AutoSize = true;
            this.checkBoxLogMessages.Location = new System.Drawing.Point(330, 120);
            this.checkBoxLogMessages.Name = "checkBoxLogMessages";
            this.checkBoxLogMessages.Size = new System.Drawing.Size(126, 17);
            this.checkBoxLogMessages.TabIndex = 24;
            this.checkBoxLogMessages.Text = "Log Messages to File";
            this.checkBoxLogMessages.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 788);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "DVIS API";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSignalFIle;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.Button buttonSignalFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderMsg;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label labelOutputDirectory;
        private System.Windows.Forms.Button buttonOutputDir;
        private System.Windows.Forms.TextBox textBoxOutputDir;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonReadCurrentValue;
        private System.Windows.Forms.Label labelSignal;
        private System.Windows.Forms.TextBox textBoxSignal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.CheckBox checkBoxCombineCSVs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.CheckBox checkBoxLogMessages;
    }
}

