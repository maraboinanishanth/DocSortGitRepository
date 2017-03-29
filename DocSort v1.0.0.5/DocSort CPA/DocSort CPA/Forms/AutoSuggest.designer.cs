namespace DocSort_CPA.Forms
{
    partial class AutoSuggest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSuggest));
            this.txtCategoryValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTypeOfSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilesTo = new System.Windows.Forms.TextBox();
            this.txtFilesFrom = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbDefault = new System.Windows.Forms.CheckBox();
            this.pnlCabinet = new System.Windows.Forms.Panel();
            this.lnkNewCabinet = new System.Windows.Forms.LinkLabel();
            this.cmbFileCabinet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.lblAutoSuggestRemainingTime = new System.Windows.Forms.Label();
            this.lblAutoSuggestFileName = new System.Windows.Forms.Label();
            this.progressBarTag = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.btnMove = new System.Windows.Forms.Button();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picProcess = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbUnmatchfiles = new System.Windows.Forms.CheckBox();
            this.pnlError = new System.Windows.Forms.Panel();
            this.btnImportExcelfile = new System.Windows.Forms.Button();
            this.btnDestination = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblAutoSuggestion = new System.Windows.Forms.Label();
            this.lblChooseAutoSuggstFolder = new System.Windows.Forms.Label();
            this.rdCopyToParentFL = new System.Windows.Forms.RadioButton();
            this.rdCopyToSubFL = new System.Windows.Forms.RadioButton();
            this.pnlCabinet.SuspendLayout();
            this.pnlStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcess)).BeginInit();
            this.pnlError.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCategoryValue
            // 
            this.txtCategoryValue.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCategoryValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategoryValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryValue.ForeColor = System.Drawing.Color.Gray;
            this.txtCategoryValue.Location = new System.Drawing.Point(312, 187);
            this.txtCategoryValue.Multiline = true;
            this.txtCategoryValue.Name = "txtCategoryValue";
            this.txtCategoryValue.Size = new System.Drawing.Size(451, 65);
            this.txtCategoryValue.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(177, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 177;
            this.label6.Text = "Sub-Folders";
            // 
            // txtTypeOfSearchString
            // 
            this.txtTypeOfSearchString.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTypeOfSearchString.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTypeOfSearchString.ForeColor = System.Drawing.Color.Gray;
            this.txtTypeOfSearchString.Location = new System.Drawing.Point(311, 119);
            this.txtTypeOfSearchString.Multiline = true;
            this.txtTypeOfSearchString.Name = "txtTypeOfSearchString";
            this.txtTypeOfSearchString.Size = new System.Drawing.Size(451, 62);
            this.txtTypeOfSearchString.TabIndex = 2;
            this.txtTypeOfSearchString.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTypeOfSearchString_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(162, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 179;
            this.label1.Text = "Parent Folders";
            // 
            // txtFilesTo
            // 
            this.txtFilesTo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFilesTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilesTo.Location = new System.Drawing.Point(311, 89);
            this.txtFilesTo.Multiline = true;
            this.txtFilesTo.Name = "txtFilesTo";
            this.txtFilesTo.Size = new System.Drawing.Size(403, 25);
            this.txtFilesTo.TabIndex = 6;
            this.txtFilesTo.TextChanged += new System.EventHandler(this.txtFilesTo_TextChanged);
            this.txtFilesTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilesTo_KeyPress);
            // 
            // txtFilesFrom
            // 
            this.txtFilesFrom.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFilesFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilesFrom.Location = new System.Drawing.Point(311, 57);
            this.txtFilesFrom.Multiline = true;
            this.txtFilesFrom.Name = "txtFilesFrom";
            this.txtFilesFrom.Size = new System.Drawing.Size(403, 25);
            this.txtFilesFrom.TabIndex = 4;
            this.txtFilesFrom.TextChanged += new System.EventHandler(this.txtFilesFrom_TextChanged);
            this.txtFilesFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilesFrom_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(149, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 20);
            this.label16.TabIndex = 186;
            this.label16.Text = "Output Location";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(161, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 20);
            this.label17.TabIndex = 185;
            this.label17.Text = "Input Location";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(194, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(378, 13);
            this.lblNote.TabIndex = 195;
            this.lblNote.Text = "Note: Please enter Type of SearchString, Docs with comma(,) separated.";
            this.lblNote.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Black;
            this.lblError.Location = new System.Drawing.Point(93, 4);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 19);
            this.lblError.TabIndex = 194;
            this.lblError.Text = "label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(18, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 197;
            this.label2.Text = "Search";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(794, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 200;
            this.label3.Text = "Import from Excel";
            // 
            // chbDefault
            // 
            this.chbDefault.AutoSize = true;
            this.chbDefault.BackColor = System.Drawing.Color.Transparent;
            this.chbDefault.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDefault.ForeColor = System.Drawing.Color.DimGray;
            this.chbDefault.Location = new System.Drawing.Point(312, 378);
            this.chbDefault.Name = "chbDefault";
            this.chbDefault.Size = new System.Drawing.Size(119, 23);
            this.chbDefault.TabIndex = 8;
            this.chbDefault.Text = "Assign Cabinet";
            this.chbDefault.UseVisualStyleBackColor = false;
            this.chbDefault.CheckedChanged += new System.EventHandler(this.chbDefault_CheckedChanged);
            // 
            // pnlCabinet
            // 
            this.pnlCabinet.Controls.Add(this.lnkNewCabinet);
            this.pnlCabinet.Controls.Add(this.cmbFileCabinet);
            this.pnlCabinet.Controls.Add(this.label4);
            this.pnlCabinet.Location = new System.Drawing.Point(119, 420);
            this.pnlCabinet.Name = "pnlCabinet";
            this.pnlCabinet.Size = new System.Drawing.Size(780, 37);
            this.pnlCabinet.TabIndex = 202;
            this.pnlCabinet.Visible = false;
            // 
            // lnkNewCabinet
            // 
            this.lnkNewCabinet.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lnkNewCabinet.AutoSize = true;
            this.lnkNewCabinet.DisabledLinkColor = System.Drawing.Color.DimGray;
            this.lnkNewCabinet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNewCabinet.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkNewCabinet.LinkColor = System.Drawing.Color.DimGray;
            this.lnkNewCabinet.Location = new System.Drawing.Point(649, 11);
            this.lnkNewCabinet.Name = "lnkNewCabinet";
            this.lnkNewCabinet.Size = new System.Drawing.Size(117, 15);
            this.lnkNewCabinet.TabIndex = 179;
            this.lnkNewCabinet.TabStop = true;
            this.lnkNewCabinet.Text = "Create a new Cabinet";
            this.lnkNewCabinet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewCabinet_LinkClicked);
            // 
            // cmbFileCabinet
            // 
            this.cmbFileCabinet.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbFileCabinet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFileCabinet.FormattingEnabled = true;
            this.cmbFileCabinet.Location = new System.Drawing.Point(193, 6);
            this.cmbFileCabinet.Name = "cmbFileCabinet";
            this.cmbFileCabinet.Size = new System.Drawing.Size(447, 25);
            this.cmbFileCabinet.TabIndex = 9;
            this.cmbFileCabinet.SelectedIndexChanged += new System.EventHandler(this.cmbFileCabinet_SelectedIndexChanged);
            this.cmbFileCabinet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbFileCabinet_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(26, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 178;
            this.label4.Text = "Select Cabinet";
            // 
            // pnlStart
            // 
            this.pnlStart.Controls.Add(this.lblAutoSuggestRemainingTime);
            this.pnlStart.Controls.Add(this.lblAutoSuggestFileName);
            this.pnlStart.Controls.Add(this.progressBarTag);
            this.pnlStart.Controls.Add(this.btnMove);
            this.pnlStart.Controls.Add(this.lblRemainingTime);
            this.pnlStart.Controls.Add(this.btnClear);
            this.pnlStart.Controls.Add(this.lblFileName);
            this.pnlStart.Controls.Add(this.lblStatus);
            this.pnlStart.Controls.Add(this.picProcess);
            this.pnlStart.Controls.Add(this.btnCancel);
            this.pnlStart.Location = new System.Drawing.Point(61, 463);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(899, 158);
            this.pnlStart.TabIndex = 204;
            // 
            // lblAutoSuggestRemainingTime
            // 
            this.lblAutoSuggestRemainingTime.AutoSize = true;
            this.lblAutoSuggestRemainingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestRemainingTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestRemainingTime.ForeColor = System.Drawing.Color.Teal;
            this.lblAutoSuggestRemainingTime.Location = new System.Drawing.Point(364, 85);
            this.lblAutoSuggestRemainingTime.Name = "lblAutoSuggestRemainingTime";
            this.lblAutoSuggestRemainingTime.Size = new System.Drawing.Size(0, 17);
            this.lblAutoSuggestRemainingTime.TabIndex = 207;
            // 
            // lblAutoSuggestFileName
            // 
            this.lblAutoSuggestFileName.AutoSize = true;
            this.lblAutoSuggestFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestFileName.ForeColor = System.Drawing.Color.Teal;
            this.lblAutoSuggestFileName.Location = new System.Drawing.Point(538, 50);
            this.lblAutoSuggestFileName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblAutoSuggestFileName.Name = "lblAutoSuggestFileName";
            this.lblAutoSuggestFileName.Size = new System.Drawing.Size(0, 17);
            this.lblAutoSuggestFileName.TabIndex = 207;
            // 
            // progressBarTag
            // 
            this.progressBarTag.BackColor = System.Drawing.Color.Teal;
            this.progressBarTag.ForeColor = System.Drawing.Color.White;
            this.progressBarTag.Location = new System.Drawing.Point(254, 70);
            this.progressBarTag.Name = "progressBarTag";
            this.progressBarTag.Size = new System.Drawing.Size(450, 12);
            this.progressBarTag.TabIndex = 206;
            this.progressBarTag.Visible = false;
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.Color.Transparent;
            this.btnMove.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.btnMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.ForeColor = System.Drawing.Color.White;
            this.btnMove.Location = new System.Drawing.Point(254, 12);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(451, 35);
            this.btnMove.TabIndex = 10;
            this.btnMove.Text = "Start";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainingTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTime.ForeColor = System.Drawing.Color.Teal;
            this.lblRemainingTime.Location = new System.Drawing.Point(365, 50);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(11, 17);
            this.lblRemainingTime.TabIndex = 206;
            this.lblRemainingTime.Text = ".";
            this.lblRemainingTime.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(73, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 35);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.Teal;
            this.lblFileName.Location = new System.Drawing.Point(591, 10);
            this.lblFileName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(11, 17);
            this.lblFileName.TabIndex = 203;
            this.lblFileName.Text = ".";
            this.lblFileName.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Teal;
            this.lblStatus.Location = new System.Drawing.Point(251, 50);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(188, 17);
            this.lblStatus.TabIndex = 202;
            this.lblStatus.Text = "Processing (100000) / (100000)";
            this.lblStatus.Visible = false;
            // 
            // picProcess
            // 
            this.picProcess.BackColor = System.Drawing.Color.Transparent;
            this.picProcess.Image = global::DocSort_CPA.Properties.Resources.process1;
            this.picProcess.Location = new System.Drawing.Point(501, 115);
            this.picProcess.Name = "picProcess";
            this.picProcess.Size = new System.Drawing.Size(25, 25);
            this.picProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProcess.TabIndex = 204;
            this.picProcess.TabStop = false;
            this.picProcess.Visible = false;
            this.picProcess.WaitOnLoad = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(253, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(451, 35);
            this.btnCancel.TabIndex = 205;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chbUnmatchfiles
            // 
            this.chbUnmatchfiles.AutoSize = true;
            this.chbUnmatchfiles.BackColor = System.Drawing.Color.Transparent;
            this.chbUnmatchfiles.Checked = true;
            this.chbUnmatchfiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUnmatchfiles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUnmatchfiles.ForeColor = System.Drawing.Color.DimGray;
            this.chbUnmatchfiles.Location = new System.Drawing.Point(313, 397);
            this.chbUnmatchfiles.Name = "chbUnmatchfiles";
            this.chbUnmatchfiles.Size = new System.Drawing.Size(234, 23);
            this.chbUnmatchfiles.TabIndex = 9;
            this.chbUnmatchfiles.Text = "Create folder for Mismatched files";
            this.chbUnmatchfiles.UseVisualStyleBackColor = false;
            // 
            // pnlError
            // 
            this.pnlError.Controls.Add(this.lblError);
            this.pnlError.Controls.Add(this.lblNote);
            this.pnlError.Location = new System.Drawing.Point(237, 12);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(560, 25);
            this.pnlError.TabIndex = 205;
            this.pnlError.Visible = false;
            this.pnlError.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlError_Paint);
            // 
            // btnImportExcelfile
            // 
            this.btnImportExcelfile.BackColor = System.Drawing.Color.Transparent;
            this.btnImportExcelfile.BackgroundImage = global::DocSort_CPA.Properties.Resources.HomeScreen_VD_CPA_29;
            this.btnImportExcelfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImportExcelfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExcelfile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImportExcelfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnImportExcelfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnImportExcelfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcelfile.ForeColor = System.Drawing.Color.Transparent;
            this.btnImportExcelfile.Location = new System.Drawing.Point(797, 141);
            this.btnImportExcelfile.Name = "btnImportExcelfile";
            this.btnImportExcelfile.Size = new System.Drawing.Size(40, 40);
            this.btnImportExcelfile.TabIndex = 1;
            this.btnImportExcelfile.UseVisualStyleBackColor = false;
            this.btnImportExcelfile.Click += new System.EventHandler(this.btnImportExcelfile_Click);
            // 
            // btnDestination
            // 
            this.btnDestination.BackColor = System.Drawing.Color.Transparent;
            this.btnDestination.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse1;
            this.btnDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDestination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDestination.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnDestination.FlatAppearance.BorderSize = 0;
            this.btnDestination.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDestination.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestination.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestination.ForeColor = System.Drawing.Color.White;
            this.btnDestination.Image = global::DocSort_CPA.Properties.Resources.ToFolderIcon1;
            this.btnDestination.Location = new System.Drawing.Point(720, 89);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(45, 25);
            this.btnDestination.TabIndex = 7;
            this.btnDestination.UseVisualStyleBackColor = false;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // btnSource
            // 
            this.btnSource.BackColor = System.Drawing.Color.Transparent;
            this.btnSource.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse1;
            this.btnSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSource.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnSource.FlatAppearance.BorderSize = 0;
            this.btnSource.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSource.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.ForeColor = System.Drawing.Color.White;
            this.btnSource.Image = global::DocSort_CPA.Properties.Resources.FromFolderIcon1;
            this.btnSource.Location = new System.Drawing.Point(720, 57);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(45, 25);
            this.btnSource.TabIndex = 5;
            this.btnSource.UseVisualStyleBackColor = false;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.AllowColumnReorder = true;
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Gray;
            this.listView1.Location = new System.Drawing.Point(312, 284);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(449, 88);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 211;
            this.listView1.TileSize = new System.Drawing.Size(75, 25);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // lblAutoSuggestion
            // 
            this.lblAutoSuggestion.AutoSize = true;
            this.lblAutoSuggestion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAutoSuggestion.Location = new System.Drawing.Point(144, 284);
            this.lblAutoSuggestion.Name = "lblAutoSuggestion";
            this.lblAutoSuggestion.Size = new System.Drawing.Size(121, 20);
            this.lblAutoSuggestion.TabIndex = 212;
            this.lblAutoSuggestion.Text = "Auto-Sugegstion";
            // 
            // lblChooseAutoSuggstFolder
            // 
            this.lblChooseAutoSuggstFolder.AutoSize = true;
            this.lblChooseAutoSuggstFolder.Location = new System.Drawing.Point(312, 260);
            this.lblChooseAutoSuggstFolder.Name = "lblChooseAutoSuggstFolder";
            this.lblChooseAutoSuggstFolder.Size = new System.Drawing.Size(125, 13);
            this.lblChooseAutoSuggstFolder.TabIndex = 213;
            this.lblChooseAutoSuggstFolder.Text = "Copy Selected Words to ";
            // 
            // rdCopyToParentFL
            // 
            this.rdCopyToParentFL.AutoSize = true;
            this.rdCopyToParentFL.Location = new System.Drawing.Point(449, 258);
            this.rdCopyToParentFL.Name = "rdCopyToParentFL";
            this.rdCopyToParentFL.Size = new System.Drawing.Size(88, 17);
            this.rdCopyToParentFL.TabIndex = 214;
            this.rdCopyToParentFL.TabStop = true;
            this.rdCopyToParentFL.Text = "Parent Folder";
            this.rdCopyToParentFL.UseVisualStyleBackColor = true;
            // 
            // rdCopyToSubFL
            // 
            this.rdCopyToSubFL.AutoSize = true;
            this.rdCopyToSubFL.Location = new System.Drawing.Point(541, 258);
            this.rdCopyToSubFL.Name = "rdCopyToSubFL";
            this.rdCopyToSubFL.Size = new System.Drawing.Size(81, 17);
            this.rdCopyToSubFL.TabIndex = 215;
            this.rdCopyToSubFL.TabStop = true;
            this.rdCopyToSubFL.Text = "Sub-Folders";
            this.rdCopyToSubFL.UseVisualStyleBackColor = true;
            // 
            // AutoSuggest
            // 
            this.AcceptButton = this.btnMove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.rdCopyToSubFL);
            this.Controls.Add(this.rdCopyToParentFL);
            this.Controls.Add(this.lblChooseAutoSuggstFolder);
            this.Controls.Add(this.lblAutoSuggestion);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.pnlStart);
            this.Controls.Add(this.pnlCabinet);
            this.Controls.Add(this.chbUnmatchfiles);
            this.Controls.Add(this.chbDefault);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImportExcelfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTypeOfSearchString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.txtCategoryValue);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.txtFilesTo);
            this.Controls.Add(this.txtFilesFrom);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoSuggest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchString";
            this.Load += new System.EventHandler(this.AutoSuggest_Load);
            this.pnlCabinet.ResumeLayout(false);
            this.pnlCabinet.PerformLayout();
            this.pnlStart.ResumeLayout(false);
            this.pnlStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcess)).EndInit();
            this.pnlError.ResumeLayout(false);
            this.pnlError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCategoryValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTypeOfSearchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.TextBox txtFilesTo;
        private System.Windows.Forms.TextBox txtFilesFrom;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnDestination;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportExcelfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbDefault;
        private System.Windows.Forms.Panel pnlCabinet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFileCabinet;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.CheckBox chbUnmatchfiles;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox picProcess;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel lnkNewCabinet;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel pnlError;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx progressBarTag;
        private System.Windows.Forms.Label lblAutoSuggestFileName;
        private System.Windows.Forms.Label lblAutoSuggestRemainingTime;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblAutoSuggestion;
        private System.Windows.Forms.Label lblChooseAutoSuggstFolder;
        private System.Windows.Forms.RadioButton rdCopyToParentFL;
        private System.Windows.Forms.RadioButton rdCopyToSubFL;
       
    }
}