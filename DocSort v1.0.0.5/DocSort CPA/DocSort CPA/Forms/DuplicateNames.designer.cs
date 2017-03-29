namespace DocSort_CPA.Forms
{
    partial class DuplicateNames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateNames));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDuplicateNames = new System.Windows.Forms.TextBox();
            this.lblDuplicateNames = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDuplicateNames);
            this.panel1.Controls.Add(this.lblDuplicateNames);
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 242);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtDuplicateNames
            // 
            this.txtDuplicateNames.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuplicateNames.Location = new System.Drawing.Point(29, 89);
            this.txtDuplicateNames.Multiline = true;
            this.txtDuplicateNames.Name = "txtDuplicateNames";
            this.txtDuplicateNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDuplicateNames.Size = new System.Drawing.Size(365, 92);
            this.txtDuplicateNames.TabIndex = 203;
            // 
            // lblDuplicateNames
            // 
            this.lblDuplicateNames.AutoSize = true;
            this.lblDuplicateNames.BackColor = System.Drawing.Color.Transparent;
            this.lblDuplicateNames.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuplicateNames.ForeColor = System.Drawing.Color.DimGray;
            this.lblDuplicateNames.Location = new System.Drawing.Point(25, 30);
            this.lblDuplicateNames.MaximumSize = new System.Drawing.Size(450, 0);
            this.lblDuplicateNames.Name = "lblDuplicateNames";
            this.lblDuplicateNames.Size = new System.Drawing.Size(13, 20);
            this.lblDuplicateNames.TabIndex = 202;
            this.lblDuplicateNames.Text = ".";
            this.lblDuplicateNames.Visible = false;
            this.lblDuplicateNames.TextChanged += new System.EventHandler(this.lblDuplicateNames_TextChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewBrowse;
            this.btnContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(131, 194);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(114, 32);
            this.btnContinue.TabIndex = 201;
            this.btnContinue.Text = "Verify";
            this.btnContinue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(33, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 20);
            this.label1.TabIndex = 200;
            this.label1.Text = "Please verify and correct the names given below";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(132, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 205;
            this.label2.Text = "Duplicate Found!";
            // 
            // DuplicateNames
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 242);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuplicateNames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DuplicateNames";
            this.Load += new System.EventHandler(this.DuplicateNames_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDuplicateNames;
        private System.Windows.Forms.TextBox txtDuplicateNames;
        private System.Windows.Forms.Label label2;

    }
}