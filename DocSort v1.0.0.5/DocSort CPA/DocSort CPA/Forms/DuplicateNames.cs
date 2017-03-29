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
    public partial class DuplicateNames : Form
    {
        public DuplicateNames()
        {
            InitializeComponent();
        }
        private bool mGrowing;
         
        public string DuplicateName;
        private void DuplicateNames_Load(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDuplicateNames.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtDuplicateNames.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            if (DuplicateName != null)
            {
                lblDuplicateNames.Text = DuplicateName;
                txtDuplicateNames.Text = DuplicateName;
            }
        }

        private void resizeLabel()
        {
            if (mGrowing) return;
            try
            {
                mGrowing = true;
                Size sz = new Size(this.lblDuplicateNames.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(this.lblDuplicateNames.Text, this.lblDuplicateNames.Font, sz, TextFormatFlags.WordBreak);
                this.lblDuplicateNames.Height = sz.Height;
            }
            finally
            {
                mGrowing = false;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
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

        private void lblDuplicateNames_TextChanged(object sender, EventArgs e)
        {
            resizeLabel();
        }
    }
}
