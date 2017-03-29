using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocSort_CPA.Forms
{
    public partial class CloseApplication : Form
    {
        public CloseApplication()
        {
            InitializeComponent();
        }

        public string DeleteConfirmationRequest
        {
            set;
            get;
        }

        private void CloseApplication_Load(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            if (UserAccessPermissionvalues.NewMenuWidth == 950)
            {
                this.Width = 950;
                this.Height = 750;
                this.Top = UserAccessPermissionvalues.NewMenuTop;
                this.Left = UserAccessPermissionvalues.NewMenuLeft;
                this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.ClientSize.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.ClientSize.Height) / 2);
                this.WindowState = FormWindowState.Normal;
                panel1.BackColor = Color.White;
                panel1.Location = new Point((this.Width - panel1.ClientSize.Width) / 2, (this.Height - panel1.ClientSize.Height) / 2);
                
            }
            else
            {
                this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                this.Left = 0;
                this.Top = 0;
                this.WindowState = FormWindowState.Normal;
                panel1.BackColor = Color.White;
                panel1.Location = new Point((this.Width - panel1.ClientSize.Width) / 2, (this.Height - panel1.ClientSize.Height) / 2);
                
            }

            btnNo.Focus();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DeleteConfirmationRequest = "Yes";
            this.Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DeleteConfirmationRequest = "No";
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (panel1.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Teal, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              panel1.ClientSize.Width - thickness,
                                                              panel1.ClientSize.Height - thickness));
                }
            }
        }
    }
}
