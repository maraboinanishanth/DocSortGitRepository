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
    public partial class DeleteConfirmation : Form
    {
        public DeleteConfirmation()
        {
            InitializeComponent();
        }

        public string DeleteConfirmationRequest
        {
            set;
            get;
        }
        public string UserName
        {
            set;
            get;
        }
        private void DeleteConfirmation_Load(object sender, EventArgs e)
        {
            if (UserName != null)
            {
                label2.Text = "Are you sure you want to delete user " + UserName + "?";
            }
            else
            {
                label2.Text = "Are you sure you want to delete the selected item?";
            }
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label2.Location = new Point((panel1.Width - label2.ClientSize.Width) / 2, 37);

            btnNo.Focus();
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

    }
}
