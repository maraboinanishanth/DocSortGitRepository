using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DocSort_CPA.Forms
{
    public partial class ComingSoon : Form
    {
        public ComingSoon()
        {
           
            InitializeComponent();

            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //panel1.BackColor = Color.White;
            //panel1.BackColor = Color.FromArgb(25, Color.Black);
            //this.BackColor = Color.FromArgb(255, 255, 255, 5);
            //this.TransparencyKey = Color.FromArgb(255, 255, 255, 5);
        }
        
        private void ComingSoon_Load(object sender, EventArgs e)
        {
            //NewMenu mf = new NewMenu();
            //NewMenu mf = (NewMenu)this.MdiParent;
            //mf.EnableAllMenuItem();
            if (UserAccessPermissionvalues.NewMenuWidth == 950)
            {
                this.Width = 950;
                this.Height = 750;
                this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.ClientSize.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.ClientSize.Height) / 2);
                this.Top = UserAccessPermissionvalues.NewMenuTop;
                this.Left = UserAccessPermissionvalues.NewMenuLeft;
                this.WindowState = FormWindowState.Normal;
                panel1.BackColor = Color.White;
                panel1.Location = new Point((this.Width - panel1.ClientSize.Width) / 2, (this.Height - panel1.ClientSize.Height) / 2);
                label1.ForeColor = Color.Teal;
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
                label1.ForeColor = Color.Teal;
            }
            //panel1.BackColor = Color.White;

            
            //panel1.Location = new Point((this.Width - panel1.ClientSize.Width) / 2, (this.Height - panel1.ClientSize.Height) / 2);
            //panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2,this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //panel1.Anchor = AnchorStyles.None;

            //label1.ForeColor = Color.Teal;
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    //e.Graphics.FillRectangle(new SolidBrush(panel1.BackColor), panel1.ClientRectangle);
           

        //    Pen outlinePen = new Pen(Brushes.White);
        //    e.Graphics.DrawRectangle(outlinePen, (this.Width - panel1.ClientSize.Width) / 2, (this.Height - panel1.ClientSize.Height) / 2, panel1.Width, panel1.Height);
        //}
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

            //TextRenderer.DrawText(e.Graphics,overallpercent.ToString("#0") + "%",this.Font,new Point(10, 10),Color.Red);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
