using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Common;
using Business.Manager;


namespace DocSort_CPA.Forms
{
    public partial class NewRole : Form
    {
        public NewRole()
        {
            InitializeComponent();
        }

        private void NewRole_Load(object sender, EventArgs e)
        {
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
            bool status = true;
            if (txtRoleName.Text == String.Empty)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Role name is required";
                status = false;
                txtRoleName.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
                try
                {
                    // Checking duplicate Role names

                    UserManager objUserManager = new UserManager();
                    NandanaResult result = new NandanaResult();
                    result = objUserManager.GetRoles();

                    if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in result.resultDS.Tables[0].Rows)
                        {
                            string RoleName = dr["Role_Name"].ToString();

                            if (RoleName.ToUpper() == txtRoleName.Text.ToUpper())
                            {
                                lblErrorMsg.Visible = true;
                                lblErrorMsg.Text = "Role already exists, type a new name";
                                status = false;
                                txtRoleName.Focus();
                                return;
                            }

                        }
                    }

                    //end

                    //* inserting Role details in Roles table *//

                    NandanaResult insertFileCabinet = objUserManager.InserRoleValues(txtRoleName.Text.Trim(),txtRoleName.Text+" Desc",Convert.ToBoolean(1));
                    

                    //* End  *//

                    this.Hide();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error while Inserting Data from InsertFileCabinet SP");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtRoleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }
    }
}
