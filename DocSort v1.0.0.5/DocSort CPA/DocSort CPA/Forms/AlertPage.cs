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
    public partial class AlertPage : Form
    {
        public AlertPage()
        {
            InitializeComponent();
        }

        public string ScannedCount;
        private void AlertPage_Load(object sender, EventArgs e)
        {
            //label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblRemainingScannedCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            if (ScannedCount != null)
            {
                lblRemainingScannedCount.Text = "You've " + ScannedCount + " pending documents";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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
