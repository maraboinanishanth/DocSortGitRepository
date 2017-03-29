using System.Windows.Forms;
namespace DocSort_CPA.Forms
{
    partial class AutoSuggest_Original
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
            this.txtFilesFrom = new System.Windows.Forms.TextBox();
            this.lblAutoSuggestInptLoc = new System.Windows.Forms.Label();
            this.backgroundWorkerTag = new System.ComponentModel.BackgroundWorker();
            this.lblAutoSuggestNote = new System.Windows.Forms.Label();
            this.lalblSearch = new System.Windows.Forms.Label();
            this.chkBxCreateFldrForUnmatchFiles = new System.Windows.Forms.CheckBox();
            this.pnlAutoSuggestBottomControls = new System.Windows.Forms.Panel();
            this.btnAutoSuggestStart = new System.Windows.Forms.Button();
            this.lblAutoSuggestRemainingTime = new System.Windows.Forms.Label();
            this.progressBarTag = new QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx();
            this.btnAutoSuggestClear = new System.Windows.Forms.Button();
            this.lblAutoSuggestFileName = new System.Windows.Forms.Label();
            this.lblAutoSuggestSts = new System.Windows.Forms.Label();
            this.imgAutoSuggestProcessing = new System.Windows.Forms.PictureBox();
            this.btnAutoSuggestCancel = new System.Windows.Forms.Button();
            this.txtTypeOfSearchString = new System.Windows.Forms.TextBox();
            this.btnAutoSuggestSrc = new System.Windows.Forms.Button();
            this.WordsList = new System.Windows.Forms.ListBox();
            this.chbUnmatchfiles = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAutoSuggestError = new System.Windows.Forms.Label();
            this.pnlAutoSuggestError = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SelectedWordslist = new System.Windows.Forms.TextBox();
            this.outputLoacation = new System.Windows.Forms.Label();
            this.txtOutLocation = new System.Windows.Forms.TextBox();
            this.btnAutoSuggestDest = new System.Windows.Forms.Button();
            this.chbDefault = new System.Windows.Forms.CheckBox();
            this.btnImportExcelfile = new System.Windows.Forms.Button();
            this.txtAutoSuggPF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAutoSuggSF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAutoSuggestBottomControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAutoSuggestProcessing)).BeginInit();
            this.pnlAutoSuggestError.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilesFrom
            // 
            this.txtFilesFrom.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFilesFrom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilesFrom.Location = new System.Drawing.Point(318, 68);
            this.txtFilesFrom.Multiline = true;
            this.txtFilesFrom.Name = "txtFilesFrom";
            this.txtFilesFrom.Size = new System.Drawing.Size(403, 25);
            this.txtFilesFrom.TabIndex = 4;
            this.txtFilesFrom.TextChanged += new System.EventHandler(this.txtAutoSuggestInptLoc_TextChanged);
            this.txtFilesFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoSuggestInptLoc_KeyPress);
            // 
            // lblAutoSuggestInptLoc
            // 
            this.lblAutoSuggestInptLoc.AutoSize = true;
            this.lblAutoSuggestInptLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestInptLoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestInptLoc.ForeColor = System.Drawing.Color.DimGray;
            this.lblAutoSuggestInptLoc.Location = new System.Drawing.Point(101, 70);
            this.lblAutoSuggestInptLoc.Name = "lblAutoSuggestInptLoc";
            this.lblAutoSuggestInptLoc.Size = new System.Drawing.Size(104, 20);
            this.lblAutoSuggestInptLoc.TabIndex = 185;
            this.lblAutoSuggestInptLoc.Text = "Input Location";
            // 
            // backgroundWorkerTag
            // 
            this.backgroundWorkerTag.WorkerReportsProgress = true;
            this.backgroundWorkerTag.WorkerSupportsCancellation = true;
            this.backgroundWorkerTag.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerAutoSuggest_ProgressChanged);
            this.backgroundWorkerTag.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTag_RunWorkerCompleted);
            // 
            // lblAutoSuggestNote
            // 
            this.lblAutoSuggestNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAutoSuggestNote.AutoSize = true;
            this.lblAutoSuggestNote.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestNote.Location = new System.Drawing.Point(641, 8);
            this.lblAutoSuggestNote.Name = "lblAutoSuggestNote";
            this.lblAutoSuggestNote.Size = new System.Drawing.Size(381, 13);
            this.lblAutoSuggestNote.TabIndex = 195;
            this.lblAutoSuggestNote.Text = "Note: Please enter Type of AutoSuggest, Docs with comma(,) separated.";
            this.lblAutoSuggestNote.Visible = false;
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
            // chkBxCreateFldrForUnmatchFiles
            // 
            this.chkBxCreateFldrForUnmatchFiles.Location = new System.Drawing.Point(0, 0);
            this.chkBxCreateFldrForUnmatchFiles.Name = "chkBxCreateFldrForUnmatchFiles";
            this.chkBxCreateFldrForUnmatchFiles.Size = new System.Drawing.Size(104, 24);
            this.chkBxCreateFldrForUnmatchFiles.TabIndex = 0;
            // 
            // pnlAutoSuggestBottomControls
            // 
            this.pnlAutoSuggestBottomControls.Controls.Add(this.btnAutoSuggestStart);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.lblAutoSuggestRemainingTime);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.progressBarTag);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.btnAutoSuggestClear);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.lblAutoSuggestFileName);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.lblAutoSuggestSts);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.imgAutoSuggestProcessing);
            this.pnlAutoSuggestBottomControls.Controls.Add(this.btnAutoSuggestCancel);
            this.pnlAutoSuggestBottomControls.Location = new System.Drawing.Point(46, 494);
            this.pnlAutoSuggestBottomControls.Name = "pnlAutoSuggestBottomControls";
            this.pnlAutoSuggestBottomControls.Size = new System.Drawing.Size(950, 140);
            this.pnlAutoSuggestBottomControls.TabIndex = 204;
            // 
            // btnAutoSuggestStart
            // 
            this.btnAutoSuggestStart.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestStart.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.btnAutoSuggestStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoSuggestStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoSuggestStart.FlatAppearance.BorderSize = 0;
            this.btnAutoSuggestStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSuggestStart.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSuggestStart.ForeColor = System.Drawing.Color.White;
            this.btnAutoSuggestStart.Location = new System.Drawing.Point(260, 34);
            this.btnAutoSuggestStart.Name = "btnAutoSuggestStart";
            this.btnAutoSuggestStart.Size = new System.Drawing.Size(451, 35);
            this.btnAutoSuggestStart.TabIndex = 10;
            this.btnAutoSuggestStart.Text = "Start";
            this.btnAutoSuggestStart.UseVisualStyleBackColor = false;
            this.btnAutoSuggestStart.Click += new System.EventHandler(this.btnAutoSuggestStart_Click);
            // 
            // lblAutoSuggestRemainingTime
            // 
            this.lblAutoSuggestRemainingTime.AutoSize = true;
            this.lblAutoSuggestRemainingTime.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestRemainingTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestRemainingTime.ForeColor = System.Drawing.Color.Teal;
            this.lblAutoSuggestRemainingTime.Location = new System.Drawing.Point(370, 72);
            this.lblAutoSuggestRemainingTime.Name = "lblAutoSuggestRemainingTime";
            this.lblAutoSuggestRemainingTime.Size = new System.Drawing.Size(11, 17);
            this.lblAutoSuggestRemainingTime.TabIndex = 206;
            this.lblAutoSuggestRemainingTime.Text = ".lblAutoSuggestRemainingTime";
            this.lblAutoSuggestRemainingTime.Visible = true;
            // 
            // progressBarTag
            // 
            this.progressBarTag.BackColor = System.Drawing.Color.Teal;
            this.progressBarTag.ForeColor = System.Drawing.Color.White;
            this.progressBarTag.Location = new System.Drawing.Point(260, 72);
            this.progressBarTag.Name = "progressBarTag";
            this.progressBarTag.Size = new System.Drawing.Size(445, 12);
            this.progressBarTag.TabIndex = 204;
            this.progressBarTag.Visible = false;
            // 
            // btnAutoSuggestClear
            // 
            this.btnAutoSuggestClear.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAutoSuggestClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSuggestClear.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSuggestClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestClear.Location = new System.Drawing.Point(48, 38);
            this.btnAutoSuggestClear.Name = "btnAutoSuggestClear";
            this.btnAutoSuggestClear.Size = new System.Drawing.Size(114, 35);
            this.btnAutoSuggestClear.TabIndex = 11;
            this.btnAutoSuggestClear.Text = "Clear";
            this.btnAutoSuggestClear.UseVisualStyleBackColor = false;
            this.btnAutoSuggestClear.Visible = false;
            this.btnAutoSuggestClear.Click += new System.EventHandler(this.btnAutoSuggestClear_Click);
            // 
            // lblAutoSuggestFileName
            // 
            this.lblAutoSuggestFileName.AutoSize = true;
            this.lblAutoSuggestFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestFileName.ForeColor = System.Drawing.Color.Teal;
            this.lblAutoSuggestFileName.Location = new System.Drawing.Point(717, 34);
            this.lblAutoSuggestFileName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblAutoSuggestFileName.Name = "lblAutoSuggestFileName";
            this.lblAutoSuggestFileName.Size = new System.Drawing.Size(153, 17);
            this.lblAutoSuggestFileName.TabIndex = 203;
            this.lblAutoSuggestFileName.Text = ".lblAutoSuggestFileName";
            // 
            // lblAutoSuggestSts
            // 
            this.lblAutoSuggestSts.AutoSize = true;
            this.lblAutoSuggestSts.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestSts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestSts.ForeColor = System.Drawing.Color.Teal;
            this.lblAutoSuggestSts.Location = new System.Drawing.Point(256, 15);
            this.lblAutoSuggestSts.Name = "lblAutoSuggestSts";
            this.lblAutoSuggestSts.Size = new System.Drawing.Size(188, 17);
            this.lblAutoSuggestSts.TabIndex = 202;
            this.lblAutoSuggestSts.Text = "Processing (100000) / (100000)";
            this.lblAutoSuggestSts.Visible = false;
            // 
            // imgAutoSuggestProcessing
            // 
            this.imgAutoSuggestProcessing.BackColor = System.Drawing.Color.Transparent;
            this.imgAutoSuggestProcessing.Image = global::DocSort_CPA.Properties.Resources.process1;
            this.imgAutoSuggestProcessing.Location = new System.Drawing.Point(515, 102);
            this.imgAutoSuggestProcessing.Name = "imgAutoSuggestProcessing";
            this.imgAutoSuggestProcessing.Size = new System.Drawing.Size(25, 25);
            this.imgAutoSuggestProcessing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAutoSuggestProcessing.TabIndex = 204;
            this.imgAutoSuggestProcessing.TabStop = false;
            this.imgAutoSuggestProcessing.Visible = true;
            this.imgAutoSuggestProcessing.WaitOnLoad = true;
            // 
            // btnAutoSuggestCancel
            // 
            this.btnAutoSuggestCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestCancel.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewStart1;
            this.btnAutoSuggestCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoSuggestCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoSuggestCancel.FlatAppearance.BorderSize = 0;
            this.btnAutoSuggestCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSuggestCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSuggestCancel.ForeColor = System.Drawing.Color.White;
            this.btnAutoSuggestCancel.Location = new System.Drawing.Point(258, 92);
            this.btnAutoSuggestCancel.Name = "btnAutoSuggestCancel";
            this.btnAutoSuggestCancel.Size = new System.Drawing.Size(451, 35);
            this.btnAutoSuggestCancel.TabIndex = 205;
            this.btnAutoSuggestCancel.Text = "Cancel";
            this.btnAutoSuggestCancel.UseVisualStyleBackColor = false;
            this.btnAutoSuggestCancel.Visible = false;
            this.btnAutoSuggestCancel.Click += new System.EventHandler(this.btnAutoSuggestCancel_Click);
            // 
            // txtTypeOfSearchString
            // 
            this.txtTypeOfSearchString.Location = new System.Drawing.Point(0, 0);
            this.txtTypeOfSearchString.Name = "txtTypeOfSearchString";
            this.txtTypeOfSearchString.Size = new System.Drawing.Size(100, 20);
            this.txtTypeOfSearchString.TabIndex = 0;
            // 
            // btnAutoSuggestSrc
            // 
            this.btnAutoSuggestSrc.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestSrc.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse1;
            this.btnAutoSuggestSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoSuggestSrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoSuggestSrc.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAutoSuggestSrc.FlatAppearance.BorderSize = 0;
            this.btnAutoSuggestSrc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestSrc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSuggestSrc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSuggestSrc.ForeColor = System.Drawing.Color.White;
            this.btnAutoSuggestSrc.Image = global::DocSort_CPA.Properties.Resources.FromFolderIcon1;
            this.btnAutoSuggestSrc.Location = new System.Drawing.Point(725, 67);
            this.btnAutoSuggestSrc.Name = "btnAutoSuggestSrc";
            this.btnAutoSuggestSrc.Size = new System.Drawing.Size(45, 25);
            this.btnAutoSuggestSrc.TabIndex = 5;
            this.btnAutoSuggestSrc.UseVisualStyleBackColor = false;
            this.btnAutoSuggestSrc.Click += new System.EventHandler(this.btnAutoSuggestSrc_Click);
            // 
            // WordsList
            // 
            this.WordsList.FormattingEnabled = true;
            this.WordsList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.WordsList.Location = new System.Drawing.Point(816, 378);
            this.WordsList.Name = "WordsList";
            this.WordsList.Size = new System.Drawing.Size(127, 56);
            this.WordsList.TabIndex = 206;
            // 
            // chbUnmatchfiles
            // 
            this.chbUnmatchfiles.Location = new System.Drawing.Point(0, 0);
            this.chbUnmatchfiles.Name = "chbUnmatchfiles";
            this.chbUnmatchfiles.Size = new System.Drawing.Size(104, 24);
            this.chbUnmatchfiles.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(80, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 207;
            this.label2.Text = "Auto Suggestion Words";
            // 
            // lblAutoSuggestError
            // 
            this.lblAutoSuggestError.AutoSize = true;
            this.lblAutoSuggestError.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestError.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestError.ForeColor = System.Drawing.Color.Black;
            this.lblAutoSuggestError.Location = new System.Drawing.Point(76, 6);
            this.lblAutoSuggestError.Name = "lblAutoSuggestError";
            this.lblAutoSuggestError.Size = new System.Drawing.Size(39, 19);
            this.lblAutoSuggestError.TabIndex = 194;
            this.lblAutoSuggestError.Text = "label";
            // 
            // pnlAutoSuggestError
            // 
            this.pnlAutoSuggestError.Controls.Add(this.lblAutoSuggestError);
            this.pnlAutoSuggestError.Location = new System.Drawing.Point(242, 24);
            this.pnlAutoSuggestError.Name = "pnlAutoSuggestError";
            this.pnlAutoSuggestError.Size = new System.Drawing.Size(560, 25);
            this.pnlAutoSuggestError.TabIndex = 205;
            this.pnlAutoSuggestError.Visible = false;
            this.pnlAutoSuggestError.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAutoSuggestError_Paint);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.AllowColumnReorder = true;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Location = new System.Drawing.Point(316, 408);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(452, 80);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 208;
            this.listView1.TileSize = new System.Drawing.Size(75, 25);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // SelectedWordslist
            // 
            this.SelectedWordslist.Location = new System.Drawing.Point(816, 461);
            this.SelectedWordslist.Name = "SelectedWordslist";
            this.SelectedWordslist.Size = new System.Drawing.Size(206, 20);
            this.SelectedWordslist.TabIndex = 209;
            // 
            // outputLoacation
            // 
            this.outputLoacation.AutoSize = true;
            this.outputLoacation.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.outputLoacation.Location = new System.Drawing.Point(105, 99);
            this.outputLoacation.Name = "outputLoacation";
            this.outputLoacation.Size = new System.Drawing.Size(116, 20);
            this.outputLoacation.TabIndex = 210;
            this.outputLoacation.Text = "Output Location";
            // 
            // txtOutLocation
            // 
            this.txtOutLocation.BackColor = System.Drawing.SystemColors.Menu;
            this.txtOutLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOutLocation.Location = new System.Drawing.Point(318, 99);
            this.txtOutLocation.Multiline = true;
            this.txtOutLocation.Name = "txtOutLocation";
            this.txtOutLocation.Size = new System.Drawing.Size(403, 25);
            this.txtOutLocation.TabIndex = 211;
            // 
            // btnAutoSuggestDest
            // 
            this.btnAutoSuggestDest.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestDest.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse1;
            this.btnAutoSuggestDest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoSuggestDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoSuggestDest.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAutoSuggestDest.FlatAppearance.BorderSize = 0;
            this.btnAutoSuggestDest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestDest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAutoSuggestDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSuggestDest.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSuggestDest.ForeColor = System.Drawing.Color.White;
            this.btnAutoSuggestDest.Image = global::DocSort_CPA.Properties.Resources.ToFolderIcon1;
            this.btnAutoSuggestDest.Location = new System.Drawing.Point(727, 99);
            this.btnAutoSuggestDest.Name = "btnAutoSuggestDest";
            this.btnAutoSuggestDest.Size = new System.Drawing.Size(45, 25);
            this.btnAutoSuggestDest.TabIndex = 212;
            this.btnAutoSuggestDest.UseVisualStyleBackColor = false;
            this.btnAutoSuggestDest.Click += new System.EventHandler(this.btnAutoSuggestDest_Click);
            // 
            // chbDefault
            // 
            this.chbDefault.AutoSize = true;
            this.chbDefault.BackColor = System.Drawing.Color.Transparent;
            this.chbDefault.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDefault.ForeColor = System.Drawing.Color.DimGray;
            this.chbDefault.Location = new System.Drawing.Point(317, 130);
            this.chbDefault.Name = "chbDefault";
            this.chbDefault.Size = new System.Drawing.Size(119, 23);
            this.chbDefault.TabIndex = 213;
            this.chbDefault.Text = "Assign Cabinet";
            this.chbDefault.UseVisualStyleBackColor = false;
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
            this.btnImportExcelfile.Location = new System.Drawing.Point(795, 174);
            this.btnImportExcelfile.Name = "btnImportExcelfile";
            this.btnImportExcelfile.Size = new System.Drawing.Size(40, 40);
            this.btnImportExcelfile.TabIndex = 214;
            this.btnImportExcelfile.UseVisualStyleBackColor = false;
            // 
            // txtAutoSuggPF
            // 
            this.txtAutoSuggPF.BackColor = System.Drawing.SystemColors.Menu;
            this.txtAutoSuggPF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoSuggPF.ForeColor = System.Drawing.Color.Gray;
            this.txtAutoSuggPF.Location = new System.Drawing.Point(317, 159);
            this.txtAutoSuggPF.Multiline = true;
            this.txtAutoSuggPF.Name = "txtAutoSuggPF";
            this.txtAutoSuggPF.Size = new System.Drawing.Size(451, 111);
            this.txtAutoSuggPF.TabIndex = 215;
            this.txtAutoSuggPF.Text = "Import or type one or more keywords separated by commas(,)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(118, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 216;
            this.label3.Text = "Parent Folders";
            // 
            // txtAutoSuggSF
            // 
            this.txtAutoSuggSF.BackColor = System.Drawing.SystemColors.Menu;
            this.txtAutoSuggSF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoSuggSF.ForeColor = System.Drawing.Color.Gray;
            this.txtAutoSuggSF.Location = new System.Drawing.Point(318, 291);
            this.txtAutoSuggSF.Multiline = true;
            this.txtAutoSuggSF.Name = "txtAutoSuggSF";
            this.txtAutoSuggSF.Size = new System.Drawing.Size(451, 111);
            this.txtAutoSuggSF.TabIndex = 217;
            this.txtAutoSuggSF.Text = "Type one or more keywords separated by commas(,)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(141, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 218;
            this.label6.Text = "Sub-Folders";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(823, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Testing";
            // 
            // AutoSuggest_Original
            // 
            this.AcceptButton = this.btnAutoSuggestStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 762);
            this.Controls.Add(this.txtAutoSuggSF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnImportExcelfile);
            this.Controls.Add(this.txtAutoSuggPF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbDefault);
            this.Controls.Add(this.btnAutoSuggestDest);
            this.Controls.Add(this.txtOutLocation);
            this.Controls.Add(this.outputLoacation);
            this.Controls.Add(this.SelectedWordslist);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WordsList);
            this.Controls.Add(this.pnlAutoSuggestError);
            this.Controls.Add(this.pnlAutoSuggestBottomControls);
            this.Controls.Add(this.lalblSearch);
            this.Controls.Add(this.lblAutoSuggestNote);
            this.Controls.Add(this.btnAutoSuggestSrc);
            this.Controls.Add(this.txtFilesFrom);
            this.Controls.Add(this.lblAutoSuggestInptLoc);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoSuggest_Original";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoSuggest";
            this.Load += new System.EventHandler(this.AutoSuggest_Load);
            this.pnlAutoSuggestBottomControls.ResumeLayout(false);
            this.pnlAutoSuggestBottomControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAutoSuggestProcessing)).EndInit();
            this.pnlAutoSuggestError.ResumeLayout(false);
            this.pnlAutoSuggestError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        public System.Windows.Forms.Label lalblSearch;
        private System.Windows.Forms.Label lblAutoSuggestNote;

        private System.Windows.Forms.TextBox txtTypeOfSearchString;

        private System.Windows.Forms.Label lblAutoSuggestInptLoc;
        private System.Windows.Forms.TextBox txtFilesFrom;
        private System.Windows.Forms.Button btnAutoSuggestSrc;

        private System.Windows.Forms.Panel pnlAutoSuggestBottomControls;
        private System.Windows.Forms.Button btnAutoSuggestClear;
        private System.Windows.Forms.Button btnAutoSuggestStart;
        private System.Windows.Forms.PictureBox imgAutoSuggestProcessing;
        private System.Windows.Forms.CheckBox chkBxCreateFldrForUnmatchFiles;
        private System.Windows.Forms.Button btnAutoSuggestCancel;
        private System.Windows.Forms.Label lblAutoSuggestSts;
        private System.Windows.Forms.Label lblAutoSuggestRemainingTime;
        private System.Windows.Forms.Label lblAutoSuggestFileName;
        private QuantumConcepts.Common.Forms.UI.Controls.ProgressBarEx progressBarTag;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTag;
        private System.Windows.Forms.ListBox WordsList;
        private System.Windows.Forms.CheckBox chbUnmatchfiles;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblAutoSuggestError;
        private System.Windows.Forms.Panel pnlAutoSuggestError;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox SelectedWordslist;
        private Label outputLoacation;
        private TextBox txtOutLocation;
        private Button btnAutoSuggestDest;
        private CheckBox chbDefault;
        private Button btnImportExcelfile;
        private TextBox txtAutoSuggPF;
        private Label label3;
        private TextBox txtAutoSuggSF;
        private Label label6;
        private Label label1;
        //private System.Windows.Forms.ListBox SelectedWordsList;


    }
}