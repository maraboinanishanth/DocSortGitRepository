namespace DocSort_CPA.Forms
{
    partial class EnterScanDocCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterScanDocCount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtScanDocCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Controls.Add(this.lblErrorMsg);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtScanDocCount);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.Transparent;
            this.btnQuit.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse;
            resources.ApplyResources(this.btnQuit, "btnQuit");
            this.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse;
            resources.ApplyResources(this.btnContinue, "btnContinue");
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblErrorMsg
            // 
            resources.ApplyResources(this.lblErrorMsg, "lblErrorMsg");
            this.lblErrorMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Name = "lblErrorMsg";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Name = "label6";
            // 
            // txtScanDocCount
            // 
            resources.ApplyResources(this.txtScanDocCount, "txtScanDocCount");
            this.txtScanDocCount.Name = "txtScanDocCount";
            this.txtScanDocCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScanDocCount_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Name = "label1";
            // 
            // EnterScanDocCount
            // 
            this.AcceptButton = this.btnContinue;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnterScanDocCount";
            this.Load += new System.EventHandler(this.EnterScanDocCount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnContinue;
        public System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtScanDocCount;
        private System.Windows.Forms.Label label1;
    }
}