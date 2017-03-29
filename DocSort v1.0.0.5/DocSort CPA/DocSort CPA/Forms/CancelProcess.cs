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
    public partial class CancelProcess : Form
    {
        public CancelProcess()
        {
            InitializeComponent();
        }

        public string Process
        {
            set;
            get;
        }

        private void CancelProcess_Load(object sender, EventArgs e)
        {
            
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

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

        private void btnNo_Click(object sender, EventArgs e)
        {
            Process = "No";
            this.Hide();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Process = "Yes";
            this.Hide();
        }
    }
}
