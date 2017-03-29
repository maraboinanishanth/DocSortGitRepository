namespace DocSort_CPA.Forms
{
    partial class TagSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagSearch));
            //this.lblFolderType = new System.Windows.Forms.Label();
            //this.comboBxFolderType = new System.Windows.Forms.ComboBox();
            //this.lblTag = new System.Windows.Forms.Label();
            //this.txtTag = new System.Windows.Forms.TextBox();
            //this.lblTagFormat = new System.Windows.Forms.Label();
            //this.txtTagFormat = new System.Windows.Forms.TextBox();
            //this.btnTagAdd = new System.Windows.Forms.Button();
            this.txtTagSrchSubFldr = new System.Windows.Forms.TextBox();
            this.lblTagSrchSubFldr = new System.Windows.Forms.Label();
            this.txtTagSrchParentFldr = new System.Windows.Forms.TextBox();
            this.lblTagSrchParentFldr = new System.Windows.Forms.Label();
            this.txtTagOtptLoc = new System.Windows.Forms.TextBox();
            this.txtTagInptLoc = new System.Windows.Forms.TextBox();
            this.lblTagOtptLoc = new System.Windows.Forms.Label();
            this.lblTagInptLoc = new System.Windows.Forms.Label();
            this.backgroundWorkerTag = new System.ComponentModel.BackgroundWorker();
            this.lblTagNote = new System.Windows.Forms.Label();
            this.lblTagError = new System.Windows.Forms.Label();
            this.lalblSearch = new System.Windows.Forms.Label();
            this.chkBxAssignCabinet = new System.Windows.Forms.CheckBox();
            this.pnlTagAssignCabinet = new System.Windows.Forms.Panel();
            this.lnkTagSelectCabinet = new System.Windows.Forms.LinkLabel();
            this.comboBxAssignCabinet = new System.Windows.Forms.ComboBox();
            this.lblSelectCabinet = new System.Windows.Forms.Label();
            this.pnlTagBottomControls = new System.Windows.Forms.Panel();
            this.lblTagRemainingTime = new System.Windows.Forms.Label();
            this.lblTagFileName = new System.Windows.Forms.Label();
            this.chkBxCreateFldrForUnmatchFiles = new System.Windows.Forms.CheckBox();
            this.lblTagSts = new System.Windows.Forms.Label();
            this.pnlTagError = new System.Windows.Forms.Panel();
            this.btnTagStart = new System.Windows.Forms.Button();
            this.btnTagClear = new System.Windows.Forms.Button();
            this.imgTagProcessing = new System.Windows.Forms.PictureBox();
            this.btnTagCancel = new System.Windows.Forms.Button();
            this.btnTagDest = new System.Windows.Forms.Button();
            this.btnTagSrc = new System.Windows.Forms.Button();
            this.progressBarTag = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.pnlTagAssignCabinet.SuspendLayout();
            this.pnlTagBottomControls.SuspendLayout();
            this.pnlTagError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTagProcessing)).BeginInit();
            this.SuspendLayout();

            // 
            // lblFolderType
            // 
            //this.lblFolderType.AutoSize = true;
            //this.lblFolderType.BackColor = System.Drawing.Color.Transparent;
            //this.lblFolderType.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblFolderType.ForeColor = System.Drawing.Color.DimGray;
            //this.lblFolderType.Location = new System.Drawing.Point(15, 55);
            //this.lblFolderType.Name = "lblFolderType";
            //this.lblFolderType.Size = new System.Drawing.Size(88, 20);
            //this.lblFolderType.TabIndex = 179;
            //this.lblFolderType.Text = "Select Folder Type";

            // 
            // comboBxFolderType
            // 
            //this.comboBxFolderType.BackColor = System.Drawing.SystemColors.Menu;
            //this.comboBxFolderType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.comboBxFolderType.FormattingEnabled = true;
            //this.comboBxFolderType.Location = new System.Drawing.Point(145, 55);
            //this.comboBxFolderType.Name = "cmbFileCabinet";
            //this.comboBxFolderType.Size = new System.Drawing.Size(160, 20);
            //this.comboBxFolderType.TabIndex = 80;
            //this.comboBxFolderType.SelectedIndexChanged += new System.EventHandler(this.comboBxAssignCabinet_SelectedIndexChanged);
            //this.comboBxFolderType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBxAssignCabinet_MouseClick);


            //this.comboBxFolderType.Visible = false;


            // 
            // lblTag
            // 
            //this.lblTag.AutoSize = true;
            //this.lblTag.BackColor = System.Drawing.Color.Transparent;
            //this.lblTag.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblTag.ForeColor = System.Drawing.Color.DimGray;
            //this.lblTag.Location = new System.Drawing.Point(318, 55);
            //this.lblTag.Name = "lblTag";
            //this.lblTag.Size = new System.Drawing.Size(88, 20);
            //this.lblTag.TabIndex = 179;
            //this.lblTag.Text = "Enter a Tag";
            // 
            // txtTag
            // 
            //this.txtTag.BackColor = System.Drawing.SystemColors.Menu;
            //this.txtTag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtTag.ForeColor = System.Drawing.Color.Gray;
            //this.txtTag.Location = new System.Drawing.Point(421, 55);
            //this.txtTag.Name = "txtTag";
            //this.txtTag.Size = new System.Drawing.Size(160, 30);
            //this.txtTag.TabIndex = 2;
            //this.txtTag.Text = "";
            //this.txtTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTag_KeyPress);

            // 
            // lblTagFormat
            // 
            //this.lblTagFormat.AutoSize = true;
            //this.lblTagFormat.BackColor = System.Drawing.Color.Transparent;
            //this.lblTagFormat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblTagFormat.ForeColor = System.Drawing.Color.DimGray;
            //this.lblTagFormat.Location = new System.Drawing.Point(596, 55);
            //this.lblTagFormat.Name = "lblTagFormat";
            //this.lblTagFormat.Size = new System.Drawing.Size(88, 20);
            //this.lblTagFormat.TabIndex = 179;
            //this.lblTagFormat.Text = "Enter Tag Format";
            // 
            // txtTagFormat
            // 
            //this.txtTagFormat.BackColor = System.Drawing.SystemColors.Menu;
            //this.txtTagFormat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtTagFormat.ForeColor = System.Drawing.Color.Gray;
            //this.txtTagFormat.Location = new System.Drawing.Point(740, 55);
            //this.txtTagFormat.Name = "txtTagFormat";
            //this.txtTagFormat.Size = new System.Drawing.Size(160, 30);
            //this.txtTagFormat.TabIndex = 2;
            //this.txtTagFormat.Text = "";
            //this.txtTagFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTagFormat_KeyPress);


            // 
            // btnTagStart
            // 
            //this.btnTagAdd.BackColor = System.Drawing.Color.Transparent;
            //this.btnTagAdd.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            //this.btnTagAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.btnTagAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            //this.btnTagAdd.FlatAppearance.BorderSize = 0;
            //this.btnTagAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            //this.btnTagAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            //this.btnTagAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.btnTagAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.btnTagAdd.ForeColor = System.Drawing.Color.White;
            //this.btnTagAdd.Location = new System.Drawing.Point(910, 55);
            //this.btnTagAdd.Name = "btnTagAdd";
            //this.btnTagAdd.Size = new System.Drawing.Size(70, 25);
            //this.btnTagAdd.TabIndex = 10;
            //this.btnTagAdd.Text = "Add";
            //this.btnTagAdd.UseVisualStyleBackColor = false;
            //this.btnTagAdd.Click += new System.EventHandler(this.btnTagAdd_Click);

            // 
            // lblTagSrchParentFldr
            // 
            this.lblTagSrchParentFldr.AutoSize = true;
            this.lblTagSrchParentFldr.BackColor = System.Drawing.Color.Transparent;
            this.lblTagSrchParentFldr.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagSrchParentFldr.ForeColor = System.Drawing.Color.DimGray;
            this.lblTagSrchParentFldr.Location = new System.Drawing.Point(101, 52);
            this.lblTagSrchParentFldr.Name = "lblTagSrchParentFldr";
            this.lblTagSrchParentFldr.Size = new System.Drawing.Size(103, 20);
            this.lblTagSrchParentFldr.TabIndex = 179;
            this.lblTagSrchParentFldr.Text = "Search Tags for Parent Folders";
            // 
            // txtTagSrchParentFldr
            // 
            this.txtTagSrchParentFldr.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTagSrchParentFldr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagSrchParentFldr.ForeColor = System.Drawing.Color.Gray;
            this.txtTagSrchParentFldr.Location = new System.Drawing.Point(318, 54);
            this.txtTagSrchParentFldr.Multiline = true;
            this.txtTagSrchParentFldr.Name = "txtTagSrchParentFldr";
            this.txtTagSrchParentFldr.Size = new System.Drawing.Size(451, 111);
            this.txtTagSrchParentFldr.TabIndex = 2;
            this.txtTagSrchParentFldr.Text = "Type one or more tag keywords separated by commas(,)";
            this.txtTagSrchParentFldr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTagSrchParentFldr_KeyPress);
            // 
            // lblTagSrchSubFldr
            // 
            this.lblTagSrchSubFldr.AutoSize = true;
            this.lblTagSrchSubFldr.BackColor = System.Drawing.Color.Transparent;
            this.lblTagSrchSubFldr.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagSrchSubFldr.ForeColor = System.Drawing.Color.DimGray;
            this.lblTagSrchSubFldr.Location = new System.Drawing.Point(101, 185);
            this.lblTagSrchSubFldr.Name = "lblTagSrchSubFldr";
            this.lblTagSrchSubFldr.Size = new System.Drawing.Size(88, 20);
            this.lblTagSrchSubFldr.TabIndex = 177;
            this.lblTagSrchSubFldr.Text = "Search Tags for Sub Folders";
            // 
            // txtTagSrchSubFldr
            // 
            this.txtTagSrchSubFldr.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTagSrchSubFldr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagSrchSubFldr.ForeColor = System.Drawing.Color.Gray;
            this.txtTagSrchSubFldr.Location = new System.Drawing.Point(318, 180);
            this.txtTagSrchSubFldr.Multiline = true;
            this.txtTagSrchSubFldr.Name = "txtTagSrchSubFldr";
            this.txtTagSrchSubFldr.Size = new System.Drawing.Size(451, 111);
            this.txtTagSrchSubFldr.TabIndex = 3;
            this.txtTagSrchSubFldr.Text = "Type one or more tag keywords separated by commas(,)";
            this.txtTagSrchSubFldr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTagSrchSubFldr_KeyPress);
            // 
            // lblTagInptLoc
            // 
            this.lblTagInptLoc.AutoSize = true;
            this.lblTagInptLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblTagInptLoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagInptLoc.ForeColor = System.Drawing.Color.DimGray;
            this.lblTagInptLoc.Location = new System.Drawing.Point(101, 308);
            this.lblTagInptLoc.Name = "lblTagInptLoc";
            this.lblTagInptLoc.Size = new System.Drawing.Size(104, 20);
            this.lblTagInptLoc.TabIndex = 185;
            this.lblTagInptLoc.Text = "Input Location";
            // 
            // txtTagInptLoc
            // 
            this.txtTagInptLoc.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTagInptLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagInptLoc.Location = new System.Drawing.Point(318, 306);
            this.txtTagInptLoc.Multiline = true;
            this.txtTagInptLoc.Name = "txtTagInptLoc";
            this.txtTagInptLoc.Size = new System.Drawing.Size(403, 25);
            this.txtTagInptLoc.TabIndex = 4;
            this.txtTagInptLoc.TextChanged += new System.EventHandler(this.txtTagInptLoc_TextChanged);
            this.txtTagInptLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTagInptLoc_KeyPress);
            // 
            // lblTagOtptLoc
            // 
            this.lblTagOtptLoc.AutoSize = true;
            this.lblTagOtptLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblTagOtptLoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagOtptLoc.ForeColor = System.Drawing.Color.DimGray;
            this.lblTagOtptLoc.Location = new System.Drawing.Point(101, 350);
            this.lblTagOtptLoc.Name = "lblTagOtptLoc";
            this.lblTagOtptLoc.Size = new System.Drawing.Size(116, 20);
            this.lblTagOtptLoc.TabIndex = 186;
            this.lblTagOtptLoc.Text = "Output Location";
            // 
            // txtTagOtptLoc
            // 
            this.txtTagOtptLoc.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTagOtptLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagOtptLoc.Location = new System.Drawing.Point(318, 346);
            this.txtTagOtptLoc.Multiline = true;
            this.txtTagOtptLoc.Name = "txtTagOtptLoc";
            this.txtTagOtptLoc.Size = new System.Drawing.Size(403, 25);
            this.txtTagOtptLoc.TabIndex = 6;
            this.txtTagOtptLoc.TextChanged += new System.EventHandler(this.txtTagOtptLoc_TextChanged);
            this.txtTagOtptLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTagOtptLoc_KeyPress);
            // 
            // backgroundWorkerTag
            // 
            this.backgroundWorkerTag.WorkerReportsProgress = true;
            this.backgroundWorkerTag.WorkerSupportsCancellation = true;
            this.backgroundWorkerTag.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTag_ProgressChanged);
            this.backgroundWorkerTag.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTag_RunWorkerCompleted);
            // 
            // lblTagNote
            // 
            this.lblTagNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTagNote.AutoSize = true;
            this.lblTagNote.BackColor = System.Drawing.Color.Transparent;
            this.lblTagNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagNote.Location = new System.Drawing.Point(629, 8);
            this.lblTagNote.Name = "lblTagNote";
            this.lblTagNote.Size = new System.Drawing.Size(378, 13);
            this.lblTagNote.TabIndex = 195;
            this.lblTagNote.Text = "Note: Please enter Type of TagSearch, Docs with comma(,) separated.";
            this.lblTagNote.Visible = false;
            // 
            // lblTagError
            // 
            this.lblTagError.AutoSize = true;
            this.lblTagError.BackColor = System.Drawing.Color.Transparent;
            this.lblTagError.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagError.ForeColor = System.Drawing.Color.Black;
            this.lblTagError.Location = new System.Drawing.Point(93, 4);
            this.lblTagError.Name = "lblTagError";
            this.lblTagError.Size = new System.Drawing.Size(39, 19);
            this.lblTagError.TabIndex = 194;
            this.lblTagError.Text = "label";
            // 
            // lalblSearch
            // 
            this.lalblSearch.AutoSize = true;
            this.lalblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lalblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalblSearch.ForeColor = System.Drawing.Color.Teal;
            this.lalblSearch.Location = new System.Drawing.Point(18, 8);
            this.lalblSearch.Name = "lalblSearch";
            this.lalblSearch.Size = new System.Drawing.Size(55, 20);
            this.lalblSearch.TabIndex = 197;
            this.lalblSearch.Text = "Search";
            this.lalblSearch.Visible = false;
            // 
            // chkBxAssignCabinet
            // 
            this.chkBxAssignCabinet.AutoSize = true;
            this.chkBxAssignCabinet.BackColor = System.Drawing.Color.Transparent;
            this.chkBxAssignCabinet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxAssignCabinet.ForeColor = System.Drawing.Color.DimGray;
            this.chkBxAssignCabinet.Location = new System.Drawing.Point(318, 383);
            this.chkBxAssignCabinet.Name = "chkBxAssignCabinet";
            this.chkBxAssignCabinet.Size = new System.Drawing.Size(119, 23);
            this.chkBxAssignCabinet.TabIndex = 8;
            this.chkBxAssignCabinet.Text = "Assign Cabinet";
            this.chkBxAssignCabinet.UseVisualStyleBackColor = false;
            this.chkBxAssignCabinet.CheckedChanged += new System.EventHandler(this.chkBxAssignCabinet_CheckedChanged);
            // 
            // pnlTagAssignCabinet
            // 
            this.pnlTagAssignCabinet.Controls.Add(this.lnkTagSelectCabinet);
            this.pnlTagAssignCabinet.Controls.Add(this.comboBxAssignCabinet);
            this.pnlTagAssignCabinet.Controls.Add(this.lblSelectCabinet);
            this.pnlTagAssignCabinet.Location = new System.Drawing.Point(130, 409);
            this.pnlTagAssignCabinet.Name = "pnlTagAssignCabinet";
            this.pnlTagAssignCabinet.Size = new System.Drawing.Size(780, 37);
            this.pnlTagAssignCabinet.TabIndex = 202;
            this.pnlTagAssignCabinet.Visible = false;
            // 
            // lnkTagSelectCabinet
            // 
            this.lnkTagSelectCabinet.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lnkTagSelectCabinet.AutoSize = true;
            this.lnkTagSelectCabinet.DisabledLinkColor = System.Drawing.Color.DimGray;
            this.lnkTagSelectCabinet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTagSelectCabinet.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkTagSelectCabinet.LinkColor = System.Drawing.Color.DimGray;
            this.lnkTagSelectCabinet.Location = new System.Drawing.Point(643, 11);
            this.lnkTagSelectCabinet.Name = "lnkTagSelectCabinet";
            this.lnkTagSelectCabinet.Size = new System.Drawing.Size(117, 15);
            this.lnkTagSelectCabinet.TabIndex = 179;
            this.lnkTagSelectCabinet.TabStop = true;
            this.lnkTagSelectCabinet.Text = "Create a new Cabinet";
            this.lnkTagSelectCabinet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTagSelectCabinet_LinkClicked);
            // 
            // comboBxAssignCabinet
            // 
            this.comboBxAssignCabinet.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBxAssignCabinet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBxAssignCabinet.FormattingEnabled = true;
            this.comboBxAssignCabinet.Location = new System.Drawing.Point(187, 6);
            this.comboBxAssignCabinet.Name = "comboBxAssignCabinet";
            this.comboBxAssignCabinet.Size = new System.Drawing.Size(447, 25);
            this.comboBxAssignCabinet.TabIndex = 9;
            this.comboBxAssignCabinet.SelectedIndexChanged += new System.EventHandler(this.comboBxAssignCabinet_SelectedIndexChanged);
            this.comboBxAssignCabinet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBxAssignCabinet_MouseClick);
            // 
            // lblSelectCabinet
            // 
            this.lblSelectCabinet.AutoSize = true;
            this.lblSelectCabinet.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectCabinet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCabinet.ForeColor = System.Drawing.Color.DimGray;
            this.lblSelectCabinet.Location = new System.Drawing.Point(10, 6);
            this.lblSelectCabinet.Name = "lblSelectCabinet";
            this.lblSelectCabinet.Size = new System.Drawing.Size(104, 20);
            this.lblSelectCabinet.TabIndex = 178;
            this.lblSelectCabinet.Text = "Select Cabinet";
            // 
            // pnlTagBottomControls
            // 
            this.pnlTagBottomControls.Controls.Add(this.btnTagStart);
            this.pnlTagBottomControls.Controls.Add(this.lblTagRemainingTime);
            this.pnlTagBottomControls.Controls.Add(this.progressBarTag);
            this.pnlTagBottomControls.Controls.Add(this.btnTagClear);
            this.pnlTagBottomControls.Controls.Add(this.lblTagFileName);
            this.pnlTagBottomControls.Controls.Add(this.chkBxCreateFldrForUnmatchFiles);
            this.pnlTagBottomControls.Controls.Add(this.lblTagSts);
            this.pnlTagBottomControls.Controls.Add(this.imgTagProcessing);
            this.pnlTagBottomControls.Controls.Add(this.btnTagCancel);
            this.pnlTagBottomControls.Location = new System.Drawing.Point(64, 448);
            this.pnlTagBottomControls.Name = "pnlTagBottomControls";
            this.pnlTagBottomControls.Size = new System.Drawing.Size(950, 140);
            this.pnlTagBottomControls.TabIndex = 204;
            // 
            // lblTagRemainingTime
            // 
            this.lblTagRemainingTime.AutoSize = true;
            this.lblTagRemainingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTagRemainingTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagRemainingTime.ForeColor = System.Drawing.Color.Teal;
            this.lblTagRemainingTime.Location = new System.Drawing.Point(370, 72);
            this.lblTagRemainingTime.Name = "lblTagRemainingTime";
            this.lblTagRemainingTime.Size = new System.Drawing.Size(11, 17);
            this.lblTagRemainingTime.TabIndex = 206;
            this.lblTagRemainingTime.Text = ".";
            this.lblTagRemainingTime.Visible = false;
            // 
            // lblTagFileName
            // 
            this.lblTagFileName.AutoSize = true;
            this.lblTagFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblTagFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagFileName.ForeColor = System.Drawing.Color.Teal;
            this.lblTagFileName.Location = new System.Drawing.Point(596, 32);
            this.lblTagFileName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblTagFileName.Name = "lblTagFileName";
            this.lblTagFileName.Size = new System.Drawing.Size(11, 17);
            this.lblTagFileName.TabIndex = 203;
            this.lblTagFileName.Text = ".";
            this.lblTagFileName.Visible = false;
            // 
            // chkBxCreateFldrForUnmatchFiles
            // 
            this.chkBxCreateFldrForUnmatchFiles.AutoSize = true;
            this.chkBxCreateFldrForUnmatchFiles.BackColor = System.Drawing.Color.Transparent;
            this.chkBxCreateFldrForUnmatchFiles.Checked = true;
            this.chkBxCreateFldrForUnmatchFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxCreateFldrForUnmatchFiles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxCreateFldrForUnmatchFiles.ForeColor = System.Drawing.Color.DimGray;
            this.chkBxCreateFldrForUnmatchFiles.Location = new System.Drawing.Point(254, 4);
            this.chkBxCreateFldrForUnmatchFiles.Name = "chkBxCreateFldrForUnmatchFiles";
            this.chkBxCreateFldrForUnmatchFiles.Size = new System.Drawing.Size(234, 23);
            this.chkBxCreateFldrForUnmatchFiles.TabIndex = 9;
            this.chkBxCreateFldrForUnmatchFiles.Text = "Create folder for Mismatched files";
            this.chkBxCreateFldrForUnmatchFiles.UseVisualStyleBackColor = false;
            // 
            // lblTagSts
            // 
            this.lblTagSts.AutoSize = true;
            this.lblTagSts.BackColor = System.Drawing.Color.Transparent;
            this.lblTagSts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagSts.ForeColor = System.Drawing.Color.Teal;
            this.lblTagSts.Location = new System.Drawing.Point(257, 32);
            this.lblTagSts.Name = "lblTagSts";
            this.lblTagSts.Size = new System.Drawing.Size(188, 17);
            this.lblTagSts.TabIndex = 202;
            this.lblTagSts.Text = "Processing (100000) / (100000)";
            this.lblTagSts.Visible = false;
            // 
            // pnlTagError
            // 
            this.pnlTagError.Controls.Add(this.lblTagError);
            this.pnlTagError.Location = new System.Drawing.Point(237, 12);
            this.pnlTagError.Name = "pnlTagError";
            this.pnlTagError.Size = new System.Drawing.Size(560, 25);
            this.pnlTagError.TabIndex = 205;
            this.pnlTagError.Visible = false;
            this.pnlTagError.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTagError_Paint);
            // 
            // btnTagStart
            // 
            this.btnTagStart.BackColor = System.Drawing.Color.Transparent;
            this.btnTagStart.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.btnTagStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTagStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTagStart.FlatAppearance.BorderSize = 0;
            this.btnTagStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTagStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTagStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagStart.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagStart.ForeColor = System.Drawing.Color.White;
            this.btnTagStart.Location = new System.Drawing.Point(254, 55);
            this.btnTagStart.Name = "btnTagStart";
            this.btnTagStart.Size = new System.Drawing.Size(451, 35);
            this.btnTagStart.TabIndex = 10;
            this.btnTagStart.Text = "Start";
            this.btnTagStart.UseVisualStyleBackColor = false;
            this.btnTagStart.Click += new System.EventHandler(this.btnTagStart_Click);
            // 
            // btnTagClear
            // 
            this.btnTagClear.BackColor = System.Drawing.Color.Transparent;
            this.btnTagClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTagClear.BackgroundImage")));
            this.btnTagClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTagClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagClear.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnTagClear.Location = new System.Drawing.Point(48, 38);
            this.btnTagClear.Name = "btnTagClear";
            this.btnTagClear.Size = new System.Drawing.Size(114, 35);
            this.btnTagClear.TabIndex = 11;
            this.btnTagClear.Text = "Clear";
            this.btnTagClear.UseVisualStyleBackColor = false;
            this.btnTagClear.Visible = false;
            this.btnTagClear.Click += new System.EventHandler(this.btnTagClear_Click);
            // 
            // imgTagProcessing
            // 
            this.imgTagProcessing.BackColor = System.Drawing.Color.Transparent;
            this.imgTagProcessing.Image = global::DocSort_CPA.Properties.Resources.process1;
            this.imgTagProcessing.Location = new System.Drawing.Point(511, 101);
            this.imgTagProcessing.Name = "imgTagProcessing";
            this.imgTagProcessing.Size = new System.Drawing.Size(25, 25);
            this.imgTagProcessing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTagProcessing.TabIndex = 204;
            this.imgTagProcessing.TabStop = false;
            this.imgTagProcessing.Visible = false;
            this.imgTagProcessing.WaitOnLoad = true;
            // 
            // btnTagCancel
            // 
            this.btnTagCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnTagCancel.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.btnTagCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTagCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTagCancel.FlatAppearance.BorderSize = 0;
            this.btnTagCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTagCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTagCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagCancel.ForeColor = System.Drawing.Color.White;
            this.btnTagCancel.Location = new System.Drawing.Point(254, 96);
            this.btnTagCancel.Name = "btnTagCancel";
            this.btnTagCancel.Size = new System.Drawing.Size(451, 35);
            this.btnTagCancel.TabIndex = 205;
            this.btnTagCancel.Text = "Cancel";
            this.btnTagCancel.UseVisualStyleBackColor = false;
            this.btnTagCancel.Visible = false;
            this.btnTagCancel.Click += new System.EventHandler(this.btnTagCancel_Click);
            // 
            // btnTagDest
            // 
            this.btnTagDest.BackColor = System.Drawing.Color.Transparent;
            this.btnTagDest.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse1;
            this.btnTagDest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTagDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTagDest.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnTagDest.FlatAppearance.BorderSize = 0;
            this.btnTagDest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTagDest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTagDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagDest.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagDest.ForeColor = System.Drawing.Color.White;
            this.btnTagDest.Image = global::DocSort_CPA.Properties.Resources.ToFolderIcon1;
            this.btnTagDest.Location = new System.Drawing.Point(725, 345);
            this.btnTagDest.Name = "btnTagDest";
            this.btnTagDest.Size = new System.Drawing.Size(45, 25);
            this.btnTagDest.TabIndex = 7;
            this.btnTagDest.UseVisualStyleBackColor = false;
            this.btnTagDest.Click += new System.EventHandler(this.btnTagDest_Click);
            // 
            // btnTagSrc
            // 
            this.btnTagSrc.BackColor = System.Drawing.Color.Transparent;
            this.btnTagSrc.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse1;
            this.btnTagSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTagSrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTagSrc.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnTagSrc.FlatAppearance.BorderSize = 0;
            this.btnTagSrc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTagSrc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTagSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagSrc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagSrc.ForeColor = System.Drawing.Color.White;
            this.btnTagSrc.Image = global::DocSort_CPA.Properties.Resources.FromFolderIcon1;
            this.btnTagSrc.Location = new System.Drawing.Point(725, 305);
            this.btnTagSrc.Name = "btnTagSrc";
            this.btnTagSrc.Size = new System.Drawing.Size(45, 25);
            this.btnTagSrc.TabIndex = 5;
            this.btnTagSrc.UseVisualStyleBackColor = false;
            this.btnTagSrc.Click += new System.EventHandler(this.btnTagSrc_Click);
            // 
            // progressBarTag1
            // 
            this.progressBarTag.BackColor = System.Drawing.Color.Teal;
            this.progressBarTag.ForeColor = System.Drawing.Color.White;
            this.progressBarTag.Location = new System.Drawing.Point(259, 56);
            this.progressBarTag.Name = "progressBarTag";
            this.progressBarTag.Size = new System.Drawing.Size(445, 12);
            this.progressBarTag.TabIndex = 204;
            this.progressBarTag.Visible = false;
            // 
            // TagSearch
            // 
            this.AcceptButton = this.btnTagStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.pnlTagError);
            //this.Controls.Add(this.lblFolderType);
            //this.Controls.Add(this.comboBxFolderType);
            //this.Controls.Add(this.lblTag);
            //this.Controls.Add(this.txtTag);
            //this.Controls.Add(this.lblTagFormat);
            //this.Controls.Add(this.txtTagFormat);
            //this.Controls.Add(this.btnTagAdd);
            this.Controls.Add(this.pnlTagBottomControls);
            this.Controls.Add(this.pnlTagAssignCabinet);
            this.Controls.Add(this.chkBxAssignCabinet);
            this.Controls.Add(this.lalblSearch);
            this.Controls.Add(this.lblTagNote);
            this.Controls.Add(this.btnTagDest);
            this.Controls.Add(this.btnTagSrc);
            this.Controls.Add(this.txtTagOtptLoc);
            this.Controls.Add(this.txtTagInptLoc);
            this.Controls.Add(this.lblTagOtptLoc);
            this.Controls.Add(this.lblTagInptLoc);
            this.Controls.Add(this.txtTagSrchParentFldr);
            this.Controls.Add(this.lblTagSrchParentFldr);
            this.Controls.Add(this.txtTagSrchSubFldr);
            this.Controls.Add(this.lblTagSrchSubFldr);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagSearch";
            this.Load += new System.EventHandler(this.TagSearch_Load);
            this.pnlTagAssignCabinet.ResumeLayout(false);
            this.pnlTagAssignCabinet.PerformLayout();
            this.pnlTagBottomControls.ResumeLayout(false);
            this.pnlTagBottomControls.PerformLayout();
            this.pnlTagError.ResumeLayout(false);
            this.pnlTagError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTagProcessing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lalblSearch;
        private System.Windows.Forms.Panel pnlTagError;
        public System.Windows.Forms.Label lblTagError;
        private System.Windows.Forms.Label lblTagNote;

        //private System.Windows.Forms.Label lblFolderType;
        //private System.Windows.Forms.ComboBox comboBxFolderType;
        //private System.Windows.Forms.ComboBox comboBxFormat;

        //private System.Windows.Forms.Label lblTag;
        //private System.Windows.Forms.TextBox txtTag;

        //private System.Windows.Forms.Label lblTagFormat;
        //private System.Windows.Forms.TextBox txtTagFormat;
        //private System.Windows.Forms.Button btnTagAdd;

        private System.Windows.Forms.Label lblTagSrchParentFldr;
        private System.Windows.Forms.TextBox txtTagSrchParentFldr;

        private System.Windows.Forms.Label lblTagSrchSubFldr;
        private System.Windows.Forms.TextBox txtTagSrchSubFldr;

        private System.Windows.Forms.Label lblTagInptLoc;
        private System.Windows.Forms.TextBox txtTagInptLoc;
        private System.Windows.Forms.Button btnTagSrc;

        private System.Windows.Forms.Label lblTagOtptLoc;
        private System.Windows.Forms.TextBox txtTagOtptLoc;
        private System.Windows.Forms.Button btnTagDest;

        private System.Windows.Forms.CheckBox chkBxAssignCabinet;

        private System.Windows.Forms.Panel pnlTagAssignCabinet;
        private System.Windows.Forms.Label lblSelectCabinet;
        private System.Windows.Forms.ComboBox comboBxAssignCabinet;
        private System.Windows.Forms.LinkLabel lnkTagSelectCabinet;

        private System.Windows.Forms.Panel pnlTagBottomControls;
        private System.Windows.Forms.Button btnTagClear;
        private System.Windows.Forms.Button btnTagStart;
        private System.Windows.Forms.PictureBox imgTagProcessing;
        private System.Windows.Forms.Button btnTagCancel;
        private System.Windows.Forms.CheckBox chkBxCreateFldrForUnmatchFiles;
        private System.Windows.Forms.Label lblTagSts;
        private System.Windows.Forms.Label lblTagRemainingTime;
        private System.Windows.Forms.Label lblTagFileName;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx progressBarTag;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTag;

    }
}