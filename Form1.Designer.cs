﻿namespace DVISApi
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
			this.checkBoxLogMessages = new System.Windows.Forms.CheckBox();
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
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonGetFrameAt = new System.Windows.Forms.Button();
			this.buttonGetCurrentFrame = new System.Windows.Forms.Button();
			this.dateTimePickerVideo = new System.Windows.Forms.DateTimePicker();
			this.textBoxVideo = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.buttonCancelPostImage = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.textboxPostImageSignalName = new System.Windows.Forms.TextBox();
			this.textboxPostImageFile = new System.Windows.Forms.TextBox();
			this.buttonChooseImage = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonGoPostImage = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelSignalFIle
			// 
			this.labelSignalFIle.AutoSize = true;
			this.labelSignalFIle.Location = new System.Drawing.Point(10, 64);
			this.labelSignalFIle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSignalFIle.Name = "labelSignalFIle";
			this.labelSignalFIle.Size = new System.Drawing.Size(149, 32);
			this.labelSignalFIle.TabIndex = 0;
			this.labelSignalFIle.Text = "Signal File";
			// 
			// textBoxInputFile
			// 
			this.textBoxInputFile.Location = new System.Drawing.Point(170, 58);
			this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxInputFile.Name = "textBoxInputFile";
			this.textBoxInputFile.Size = new System.Drawing.Size(886, 38);
			this.textBoxInputFile.TabIndex = 1;
			// 
			// buttonSignalFile
			// 
			this.buttonSignalFile.Location = new System.Drawing.Point(1070, 55);
			this.buttonSignalFile.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSignalFile.Name = "buttonSignalFile";
			this.buttonSignalFile.Size = new System.Drawing.Size(160, 48);
			this.buttonSignalFile.TabIndex = 2;
			this.buttonSignalFile.Text = "Choose";
			this.buttonSignalFile.UseVisualStyleBackColor = true;
			this.buttonSignalFile.Click += new System.EventHandler(this.OnClickSignalFile);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tabControl1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(2, 2);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(3522, 1554);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(2, 33);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(3518, 1519);
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
			this.tabPage1.Location = new System.Drawing.Point(10, 48);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.tabPage1.Size = new System.Drawing.Size(3498, 1461);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Range";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// checkBoxLogMessages
			// 
			this.checkBoxLogMessages.AutoSize = true;
			this.checkBoxLogMessages.Location = new System.Drawing.Point(880, 286);
			this.checkBoxLogMessages.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.checkBoxLogMessages.Name = "checkBoxLogMessages";
			this.checkBoxLogMessages.Size = new System.Drawing.Size(321, 36);
			this.checkBoxLogMessages.TabIndex = 24;
			this.checkBoxLogMessages.Text = "Log Messages to File";
			this.checkBoxLogMessages.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(792, 231);
			this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 32);
			this.label4.TabIndex = 23;
			this.label4.Text = "local";
			// 
			// dateTimePickerEnd
			// 
			this.dateTimePickerEnd.CustomFormat = "MMMM dd, yyyy - h:mm:ss tt";
			this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerEnd.Location = new System.Drawing.Point(170, 219);
			this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerEnd.Name = "dateTimePickerEnd";
			this.dateTimePickerEnd.Size = new System.Drawing.Size(604, 41);
			this.dateTimePickerEnd.TabIndex = 21;
			// 
			// labelEnd
			// 
			this.labelEnd.AutoSize = true;
			this.labelEnd.Location = new System.Drawing.Point(80, 231);
			this.labelEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelEnd.Name = "labelEnd";
			this.labelEnd.Size = new System.Drawing.Size(65, 32);
			this.labelEnd.TabIndex = 22;
			this.labelEnd.Text = "End";
			// 
			// checkBoxCombineCSVs
			// 
			this.checkBoxCombineCSVs.AutoSize = true;
			this.checkBoxCombineCSVs.Location = new System.Drawing.Point(502, 286);
			this.checkBoxCombineCSVs.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.checkBoxCombineCSVs.Name = "checkBoxCombineCSVs";
			this.checkBoxCombineCSVs.Size = new System.Drawing.Size(337, 36);
			this.checkBoxCombineCSVs.TabIndex = 20;
			this.checkBoxCombineCSVs.Text = "Combine CSVs to One";
			this.checkBoxCombineCSVs.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(792, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 32);
			this.label1.TabIndex = 19;
			this.label1.Text = "Port";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Location = new System.Drawing.Point(866, 2);
			this.textBoxPort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(260, 38);
			this.textBoxPort.TabIndex = 18;
			// 
			// labelServer
			// 
			this.labelServer.AutoSize = true;
			this.labelServer.Location = new System.Drawing.Point(10, 7);
			this.labelServer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new System.Drawing.Size(97, 32);
			this.labelServer.TabIndex = 11;
			this.labelServer.Text = "Server";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(330, 281);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(160, 48);
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnClickCancel);
			// 
			// labelLocal
			// 
			this.labelLocal.AutoSize = true;
			this.labelLocal.Location = new System.Drawing.Point(792, 179);
			this.labelLocal.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.labelLocal.Name = "labelLocal";
			this.labelLocal.Size = new System.Drawing.Size(74, 32);
			this.labelLocal.TabIndex = 16;
			this.labelLocal.Text = "local";
			// 
			// buttonOutputDir
			// 
			this.buttonOutputDir.Location = new System.Drawing.Point(1070, 107);
			this.buttonOutputDir.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOutputDir.Name = "buttonOutputDir";
			this.buttonOutputDir.Size = new System.Drawing.Size(160, 48);
			this.buttonOutputDir.TabIndex = 15;
			this.buttonOutputDir.Text = "Choose";
			this.buttonOutputDir.UseVisualStyleBackColor = true;
			this.buttonOutputDir.Click += new System.EventHandler(this.OnClickOutputDir);
			// 
			// textBoxOutputDir
			// 
			this.textBoxOutputDir.Location = new System.Drawing.Point(170, 112);
			this.textBoxOutputDir.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxOutputDir.Name = "textBoxOutputDir";
			this.textBoxOutputDir.Size = new System.Drawing.Size(886, 38);
			this.textBoxOutputDir.TabIndex = 14;
			// 
			// dateTimePickerStart
			// 
			this.dateTimePickerStart.CustomFormat = "MMMM dd, yyyy - h:mm:ss tt";
			this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerStart.Location = new System.Drawing.Point(170, 167);
			this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerStart.Name = "dateTimePickerStart";
			this.dateTimePickerStart.Size = new System.Drawing.Size(604, 41);
			this.dateTimePickerStart.TabIndex = 3;
			// 
			// labelOutputDirectory
			// 
			this.labelOutputDirectory.AutoSize = true;
			this.labelOutputDirectory.Location = new System.Drawing.Point(10, 122);
			this.labelOutputDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelOutputDirectory.Name = "labelOutputDirectory";
			this.labelOutputDirectory.Size = new System.Drawing.Size(143, 32);
			this.labelOutputDirectory.TabIndex = 13;
			this.labelOutputDirectory.Text = "Output Dir";
			// 
			// labelStart
			// 
			this.labelStart.AutoSize = true;
			this.labelStart.Location = new System.Drawing.Point(80, 179);
			this.labelStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStart.Name = "labelStart";
			this.labelStart.Size = new System.Drawing.Size(74, 32);
			this.labelStart.TabIndex = 4;
			this.labelStart.Text = "Start";
			// 
			// textBoxServer
			// 
			this.textBoxServer.Location = new System.Drawing.Point(170, 2);
			this.textBoxServer.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(604, 38);
			this.textBoxServer.TabIndex = 12;
			this.textBoxServer.Text = "10.141.26.201";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 365);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 32);
			this.label2.TabIndex = 4;
			this.label2.Text = "Progress";
			// 
			// buttonGo
			// 
			this.buttonGo.Location = new System.Drawing.Point(166, 281);
			this.buttonGo.Margin = new System.Windows.Forms.Padding(2);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(160, 48);
			this.buttonGo.TabIndex = 8;
			this.buttonGo.Text = "Go";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new System.EventHandler(this.OnClickGo);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(166, 351);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(898, 58);
			this.progressBar1.TabIndex = 5;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.labelSignal);
			this.tabPage2.Controls.Add(this.textBoxSignal);
			this.tabPage2.Controls.Add(this.buttonReadCurrentValue);
			this.tabPage2.Location = new System.Drawing.Point(10, 48);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.tabPage2.Size = new System.Drawing.Size(3498, 1461);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Single Point";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// labelSignal
			// 
			this.labelSignal.AutoSize = true;
			this.labelSignal.Location = new System.Drawing.Point(16, 29);
			this.labelSignal.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.labelSignal.Name = "labelSignal";
			this.labelSignal.Size = new System.Drawing.Size(95, 32);
			this.labelSignal.TabIndex = 2;
			this.labelSignal.Text = "Signal";
			// 
			// textBoxSignal
			// 
			this.textBoxSignal.Location = new System.Drawing.Point(128, 21);
			this.textBoxSignal.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.textBoxSignal.Name = "textBoxSignal";
			this.textBoxSignal.Size = new System.Drawing.Size(710, 38);
			this.textBoxSignal.TabIndex = 1;
			// 
			// buttonReadCurrentValue
			// 
			this.buttonReadCurrentValue.Location = new System.Drawing.Point(875, 15);
			this.buttonReadCurrentValue.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.buttonReadCurrentValue.Name = "buttonReadCurrentValue";
			this.buttonReadCurrentValue.Size = new System.Drawing.Size(386, 55);
			this.buttonReadCurrentValue.TabIndex = 0;
			this.buttonReadCurrentValue.Text = "Read Current Value";
			this.buttonReadCurrentValue.UseVisualStyleBackColor = true;
			this.buttonReadCurrentValue.Click += new System.EventHandler(this.OnClickReadCurrentValue);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tableLayoutPanel2);
			this.tabPage3.Location = new System.Drawing.Point(10, 48);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(3498, 1461);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Video Frame";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 928F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(3492, 1455);
			this.tableLayoutPanel2.TabIndex = 10;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.buttonGetFrameAt);
			this.panel1.Controls.Add(this.buttonGetCurrentFrame);
			this.panel1.Controls.Add(this.dateTimePickerVideo);
			this.panel1.Controls.Add(this.textBoxVideo);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(922, 1449);
			this.panel1.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(41, 35);
			this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 32);
			this.label3.TabIndex = 5;
			this.label3.Text = "Video";
			// 
			// buttonGetFrameAt
			// 
			this.buttonGetFrameAt.Location = new System.Drawing.Point(153, 150);
			this.buttonGetFrameAt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.buttonGetFrameAt.Name = "buttonGetFrameAt";
			this.buttonGetFrameAt.Size = new System.Drawing.Size(386, 55);
			this.buttonGetFrameAt.TabIndex = 9;
			this.buttonGetFrameAt.Text = "Get Frame At";
			this.buttonGetFrameAt.UseVisualStyleBackColor = true;
			this.buttonGetFrameAt.Click += new System.EventHandler(this.OnGetFrameAtClick);
			// 
			// buttonGetCurrentFrame
			// 
			this.buttonGetCurrentFrame.Location = new System.Drawing.Point(153, 80);
			this.buttonGetCurrentFrame.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.buttonGetCurrentFrame.Name = "buttonGetCurrentFrame";
			this.buttonGetCurrentFrame.Size = new System.Drawing.Size(386, 55);
			this.buttonGetCurrentFrame.TabIndex = 3;
			this.buttonGetCurrentFrame.Text = "Get Current Frame";
			this.buttonGetCurrentFrame.UseVisualStyleBackColor = true;
			this.buttonGetCurrentFrame.Click += new System.EventHandler(this.OnGetCurrentFrame);
			// 
			// dateTimePickerVideo
			// 
			this.dateTimePickerVideo.CustomFormat = "MMMM dd, yyyy - h:mm:ss tt";
			this.dateTimePickerVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerVideo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerVideo.Location = new System.Drawing.Point(153, 218);
			this.dateTimePickerVideo.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerVideo.Name = "dateTimePickerVideo";
			this.dateTimePickerVideo.Size = new System.Drawing.Size(604, 41);
			this.dateTimePickerVideo.TabIndex = 7;
			// 
			// textBoxVideo
			// 
			this.textBoxVideo.Location = new System.Drawing.Point(153, 28);
			this.textBoxVideo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.textBoxVideo.Name = "textBoxVideo";
			this.textBoxVideo.Size = new System.Drawing.Size(710, 38);
			this.textBoxVideo.TabIndex = 4;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(931, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(2558, 1449);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.buttonCancelPostImage);
			this.tabPage4.Controls.Add(this.label6);
			this.tabPage4.Controls.Add(this.textboxPostImageSignalName);
			this.tabPage4.Controls.Add(this.textboxPostImageFile);
			this.tabPage4.Controls.Add(this.buttonChooseImage);
			this.tabPage4.Controls.Add(this.label5);
			this.tabPage4.Controls.Add(this.buttonGoPostImage);
			this.tabPage4.Location = new System.Drawing.Point(10, 48);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(3498, 1461);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Post Image";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// buttonCancelPostImage
			// 
			this.buttonCancelPostImage.Location = new System.Drawing.Point(562, 158);
			this.buttonCancelPostImage.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancelPostImage.Name = "buttonCancelPostImage";
			this.buttonCancelPostImage.Size = new System.Drawing.Size(160, 48);
			this.buttonCancelPostImage.TabIndex = 18;
			this.buttonCancelPostImage.Text = "Cancel";
			this.buttonCancelPostImage.UseVisualStyleBackColor = true;
			this.buttonCancelPostImage.Click += new System.EventHandler(this.buttonCancelPostImage_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 94);
			this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(177, 32);
			this.label6.TabIndex = 14;
			this.label6.Text = "Signal Name";
			// 
			// textboxPostImageSignalName
			// 
			this.textboxPostImageSignalName.Location = new System.Drawing.Point(227, 91);
			this.textboxPostImageSignalName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.textboxPostImageSignalName.Name = "textboxPostImageSignalName";
			this.textboxPostImageSignalName.Size = new System.Drawing.Size(710, 38);
			this.textboxPostImageSignalName.TabIndex = 13;
			// 
			// textboxPostImageFile
			// 
			this.textboxPostImageFile.Location = new System.Drawing.Point(184, 32);
			this.textboxPostImageFile.Margin = new System.Windows.Forms.Padding(2);
			this.textboxPostImageFile.Name = "textboxPostImageFile";
			this.textboxPostImageFile.Size = new System.Drawing.Size(886, 38);
			this.textboxPostImageFile.TabIndex = 11;
			// 
			// buttonChooseImage
			// 
			this.buttonChooseImage.Location = new System.Drawing.Point(1094, 26);
			this.buttonChooseImage.Margin = new System.Windows.Forms.Padding(2);
			this.buttonChooseImage.Name = "buttonChooseImage";
			this.buttonChooseImage.Size = new System.Drawing.Size(160, 48);
			this.buttonChooseImage.TabIndex = 12;
			this.buttonChooseImage.Text = "Choose";
			this.buttonChooseImage.UseVisualStyleBackColor = true;
			this.buttonChooseImage.Click += new System.EventHandler(this.buttonChooseImage_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 35);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(146, 32);
			this.label5.TabIndex = 10;
			this.label5.Text = "Image File";
			// 
			// buttonGoPostImage
			// 
			this.buttonGoPostImage.Location = new System.Drawing.Point(388, 158);
			this.buttonGoPostImage.Margin = new System.Windows.Forms.Padding(2);
			this.buttonGoPostImage.Name = "buttonGoPostImage";
			this.buttonGoPostImage.Size = new System.Drawing.Size(160, 48);
			this.buttonGoPostImage.TabIndex = 9;
			this.buttonGoPostImage.Text = "Go";
			this.buttonGoPostImage.UseVisualStyleBackColor = true;
			this.buttonGoPostImage.Click += new System.EventHandler(this.buttonGoPostImage_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderMsg});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(8, 1565);
			this.listView1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(3510, 307);
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
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 321F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(3526, 1879);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(3526, 1879);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "DVIS API";
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
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
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxVideo;
		private System.Windows.Forms.Button buttonGetCurrentFrame;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonGetFrameAt;
		private System.Windows.Forms.DateTimePicker dateTimePickerVideo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button buttonGoPostImage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textboxPostImageSignalName;
		private System.Windows.Forms.TextBox textboxPostImageFile;
		private System.Windows.Forms.Button buttonChooseImage;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonCancelPostImage;
	}
}

