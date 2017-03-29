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
            this.txtAutoSuggestInptLoc = new System.Windows.Forms.TextBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAutoSuggestError = new System.Windows.Forms.Label();
            this.pnlAutoSuggestError = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SelectedWordsList = new System.Windows.Forms.ListBox();
            this.pnlAutoSuggestBottomControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAutoSuggestProcessing)).BeginInit();
            this.pnlAutoSuggestError.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAutoSuggestInptLoc
            // 
            this.txtAutoSuggestInptLoc.BackColor = System.Drawing.SystemColors.Menu;
            this.txtAutoSuggestInptLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoSuggestInptLoc.Location = new System.Drawing.Point(318, 68);
            this.txtAutoSuggestInptLoc.Multiline = true;
            this.txtAutoSuggestInptLoc.Name = "txtAutoSuggestInptLoc";
            this.txtAutoSuggestInptLoc.Size = new System.Drawing.Size(403, 25);
            this.txtAutoSuggestInptLoc.TabIndex = 4;
            this.txtAutoSuggestInptLoc.TextChanged += new System.EventHandler(this.txtAutoSuggestInptLoc_TextChanged);
            this.txtAutoSuggestInptLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoSuggestInptLoc_KeyPress);
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
            this.lblAutoSuggestNote.Location = new System.Drawing.Point(629, 8);
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
            this.pnlAutoSuggestBottomControls.Location = new System.Drawing.Point(64, 448);
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
            this.btnAutoSuggestStart.Location = new System.Drawing.Point(254, 55);
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
            this.lblAutoSuggestRemainingTime.Text = ".";
            this.lblAutoSuggestRemainingTime.Visible = false;
            // 
            // progressBarTag
            // 
            this.progressBarTag.BackColor = System.Drawing.Color.Teal;
            this.progressBarTag.ForeColor = System.Drawing.Color.White;
            this.progressBarTag.Location = new System.Drawing.Point(259, 56);
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
            this.lblAutoSuggestFileName.Location = new System.Drawing.Point(596, 32);
            this.lblAutoSuggestFileName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblAutoSuggestFileName.Name = "lblAutoSuggestFileName";
            this.lblAutoSuggestFileName.Size = new System.Drawing.Size(11, 17);
            this.lblAutoSuggestFileName.TabIndex = 203;
            this.lblAutoSuggestFileName.Text = ".";
            this.lblAutoSuggestFileName.Visible = false;
            // 
            // lblAutoSuggestSts
            // 
            this.lblAutoSuggestSts.AutoSize = true;
            this.lblAutoSuggestSts.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoSuggestSts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSuggestSts.ForeColor = System.Drawing.Color.Teal;
            this.lblAutoSuggestSts.Location = new System.Drawing.Point(257, 32);
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
            this.imgAutoSuggestProcessing.Location = new System.Drawing.Point(511, 101);
            this.imgAutoSuggestProcessing.Name = "imgAutoSuggestProcessing";
            this.imgAutoSuggestProcessing.Size = new System.Drawing.Size(25, 25);
            this.imgAutoSuggestProcessing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAutoSuggestProcessing.TabIndex = 204;
            this.imgAutoSuggestProcessing.TabStop = false;
            this.imgAutoSuggestProcessing.Visible = false;
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
            this.btnAutoSuggestCancel.Location = new System.Drawing.Point(254, 96);
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
            this.WordsList.Location = new System.Drawing.Point(318, 119);
            this.WordsList.Name = "WordsList";
            this.WordsList.Size = new System.Drawing.Size(127, 316);
            this.WordsList.TabIndex = 206;

            // 
            // chbUnmatchfiles
            // 
            this.chbUnmatchfiles.Location = new System.Drawing.Point(0, 0);
            this.chbUnmatchfiles.Name = "chbUnmatchfiles";
            this.chbUnmatchfiles.Size = new System.Drawing.Size(104, 24);
            this.chbUnmatchfiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(101, 119);
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
            this.lblAutoSuggestError.Location = new System.Drawing.Point(93, 4);
            this.lblAutoSuggestError.Name = "lblAutoSuggestError";
            this.lblAutoSuggestError.Size = new System.Drawing.Size(39, 19);
            this.lblAutoSuggestError.TabIndex = 194;
            this.lblAutoSuggestError.Text = "label";
            // 
            // pnlAutoSuggestError
            // 
            this.pnlAutoSuggestError.Controls.Add(this.lblAutoSuggestError);
            this.pnlAutoSuggestError.Location = new System.Drawing.Point(237, 12);
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
            this.listView1.Location = new System.Drawing.Point(465, 119);
            this.listView1.Name = "listView1";
            //this.listView1.OwnerDraw = true;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(475, 125);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 208;
            this.listView1.TileSize = new System.Drawing.Size(100, 25);
            //this.listView1.UseCompatibleStateImageBehavior = false;
            //this.listView1.View = System.Windows.Forms.View.Tile;
            //this.listView1.Bounds = new System.Drawing.Rectangle(new System.Drawing.Point(50, 50), new System.Drawing.Size(500, 200));
            //this.listView1.GridLines = true;
            //this.listView1.Click += new System.EventHandler(this.listview1_selectedindexchanged);
            //manual control    // 
            // Selected WordsList
            // 
            this.SelectedWordsList.FormattingEnabled = true;
            //this.SelectedWordsList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SelectedWordsList.Location = new System.Drawing.Point(318, 119);
            this.SelectedWordsList.Name = "SelectedWordsList";
            this.SelectedWordsList.Size = new System.Drawing.Size(127, 316);
            this.SelectedWordsList.TabIndex = 209;
            // AutoSuggest
            // 
            this.AcceptButton = this.btnAutoSuggestStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SelectedWordsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WordsList);
            this.Controls.Add(this.pnlAutoSuggestError);
            this.Controls.Add(this.pnlAutoSuggestBottomControls);
            this.Controls.Add(this.lalblSearch);
            this.Controls.Add(this.lblAutoSuggestNote);
            this.Controls.Add(this.btnAutoSuggestSrc);
            this.Controls.Add(this.txtAutoSuggestInptLoc);
            this.Controls.Add(this.lblAutoSuggestInptLoc);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoSuggest";
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

        //private System.Windows.Forms.Label lblFolderType;
        //private System.Windows.Forms.ComboBox comboBxFolderType;
        //private System.Windows.Forms.ComboBox comboBxFormat;

        //private System.Windows.Forms.Label lblAutoSuggest;
        //private System.Windows.Forms.TextBox txtAutoSuggest;

        //private System.Windows.Forms.Label lblAutoSuggestFormat;
        //private System.Windows.Forms.TextBox txtAutoSuggestFormat;
        //private System.Windows.Forms.Button btnAutoSuggestAdd;

        private System.Windows.Forms.TextBox txtTypeOfSearchString;

        private System.Windows.Forms.Label lblAutoSuggestInptLoc;
        private System.Windows.Forms.TextBox txtAutoSuggestInptLoc;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblAutoSuggestError;
        private System.Windows.Forms.Panel pnlAutoSuggestError;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox SelectedWordsList;

    }
}