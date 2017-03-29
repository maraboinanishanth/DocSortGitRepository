using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DocSort_CPA.Forms
{
    public partial class ShowDocumentPage : Form
    {
        public ShowDocumentPage()
        {
            InitializeComponent();
        }

        public string strFileName
        {
            set;
            get;
        }

        private void ShowDocumentPage_Load(object sender, EventArgs e)
        {
            if (strFileName.Length != 0)
            {
                if (File.Exists(strFileName))
                {
                    pnlError.Visible = false;
                    webBrowser1.Visible = true;
                    webBrowser1.Navigate(strFileName);
                }
                else
                {
                    webBrowser1.Visible = false;
                    pnlError.Visible = true;
                    pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                    pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    lblErrorMsg.Text = "The file you are looking for doesn't exist or moved.";
                    lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);

                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlError_Paint(object sender, PaintEventArgs e)
        {
            if (pnlError.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(System.Drawing.ColorTranslator.FromHtml("#e64c4a"), thickness))
                {
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(halfThickness,
                                                              halfThickness,
                                                              pnlError.ClientSize.Width - thickness,
                                                              pnlError.ClientSize.Height - thickness));
                }
            }
        }
    }
}
