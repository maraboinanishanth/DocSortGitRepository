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
    public partial class MovedFileCount : Form
    {
        public MovedFileCount()
        {
            InitializeComponent();
        }
        private bool mGrowing;
        public string Filecount
        {
            set;
            get;
        }
        public string source
        {
            set;
            get;
        }
        public string destination
        {
            set;
            get;
        }

        private void MovedFileCount_Load(object sender, EventArgs e)
        {
            lblCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSource.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDestination.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            if (Filecount != "" && source != "" && destination != "")
            {
                lblCount.Text = Filecount + " documents have been processed successfully!";
                lblCount.Location = new Point(this.ClientSize.Width / 2 - lblCount.Size.Width / 2, 53);
                //lblSource.Text = source;
                //lblDestination.Text = destination;
            }
        }

        private void resizeLabel()
        {
            if (mGrowing) return;
            try
            {
                mGrowing = true;
                Size sz = new Size(this.lblCount.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(this.lblCount.Text, this.lblCount.Font, sz, TextFormatFlags.WordBreak);
                this.lblCount.Height = sz.Height;
            }
            finally
            {
                mGrowing = false;
            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblCount_TextChanged(object sender, EventArgs e)
        {
            resizeLabel();
        }
    }
}
