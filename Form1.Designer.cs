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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLocal = new System.Windows.Forms.Label();
            this.buttonOutputDir = new System.Windows.Forms.Button();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelFor = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSignalFIle
            // 
            this.labelSignalFIle.AutoSize = true;
            this.labelSignalFIle.Location = new System.Drawing.Point(11, 49);
            this.labelSignalFIle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSignalFIle.Name = "labelSignalFIle";
            this.labelSignalFIle.Size = new System.Drawing.Size(55, 13);
            this.labelSignalFIle.TabIndex = 0;
            this.labelSignalFIle.Text = "Signal File";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(71, 46);
            this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(335, 20);
            this.textBoxInputFile.TabIndex = 1;
            // 
            // buttonSignalFile
            // 
            this.buttonSignalFile.Location = new System.Drawing.Point(408, 45);
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
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.labelLocal);
            this.groupBox1.Controls.Add(this.buttonOutputDir);
            this.groupBox1.Controls.Add(this.textBoxOutputDir);
            this.groupBox1.Controls.Add(this.labelOutputDirectory);
            this.groupBox1.Controls.Add(this.labelServer);
            this.groupBox1.Controls.Add(this.textBoxServer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonGo);
            this.groupBox1.Controls.Add(this.textBoxDuration);
            this.groupBox1.Controls.Add(this.labelFor);
            this.groupBox1.Controls.Add(this.labelStart);
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Controls.Add(this.labelSignalFIle);
            this.groupBox1.Controls.Add(this.buttonSignalFile);
            this.groupBox1.Controls.Add(this.textBoxInputFile);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(822, 232);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(131, 140);
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
            this.labelLocal.Location = new System.Drawing.Point(304, 97);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(29, 13);
            this.labelLocal.TabIndex = 16;
            this.labelLocal.Text = "local";
            // 
            // buttonOutputDir
            // 
            this.buttonOutputDir.Location = new System.Drawing.Point(408, 67);
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
            this.textBoxOutputDir.Location = new System.Drawing.Point(71, 69);
            this.textBoxOutputDir.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.Size = new System.Drawing.Size(335, 20);
            this.textBoxOutputDir.TabIndex = 14;
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(11, 73);
            this.labelOutputDirectory.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(55, 13);
            this.labelOutputDirectory.TabIndex = 13;
            this.labelOutputDirectory.Text = "Output Dir";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(11, 25);
            this.labelServer.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 11;
            this.labelServer.Text = "Server";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(71, 23);
            this.textBoxServer.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(229, 20);
            this.textBoxServer.TabIndex = 12;
            this.textBoxServer.Text = "10.141.26.201";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(69, 169);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 24);
            this.progressBar1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hours";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(69, 140);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(1);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(60, 20);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.OnClickGo);
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(69, 118);
            this.textBoxDuration.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(35, 20);
            this.textBoxDuration.TabIndex = 6;
            this.textBoxDuration.Text = "24";
            // 
            // labelFor
            // 
            this.labelFor.AutoSize = true;
            this.labelFor.Location = new System.Drawing.Point(40, 122);
            this.labelFor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFor.Name = "labelFor";
            this.labelFor.Size = new System.Drawing.Size(22, 13);
            this.labelFor.TabIndex = 5;
            this.labelFor.Text = "For";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(37, 97);
            this.labelStart.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(29, 13);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "Start";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "MMMM dd, yyyy - h:mm:ss tt";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(71, 92);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(229, 21);
            this.dateTimePickerStart.TabIndex = 3;
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
            this.listView1.Size = new System.Drawing.Size(1043, 506);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1049, 752);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 752);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "DVIS API";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label labelFor;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
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
    }
}

