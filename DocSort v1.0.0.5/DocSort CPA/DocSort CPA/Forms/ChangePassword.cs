using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSort_CPA.Forms;

using Business.Manager;
using Common;
using System.Security.Cryptography;

namespace DocSort_CPA.Forms
{ 
    public partial class ChangePassword : Form
    {
        public ChangePassword() 
        {
            InitializeComponent();
        }

        string username = string.Empty;
        string UserID = string.Empty;

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(11);
            // End

            this.ControlBox = false;

            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            txtOldPwd.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtNewPwd.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtRNewPwd.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //this.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
           
            this.Location = new Point((Devicewidth - this.ClientSize.Width) / 2, 104);
            username = System.Configuration.ConfigurationSettings.AppSettings["UserName"].ToString();
            UserID = UserAccessPermissionvalues.UserID;
        }

        public void GetPermissiondetails(int FormID)
        {
            UserManager objUserManager = new UserManager();
            NandanaResult dsuserPermission = new NandanaResult();
            dsuserPermission = objUserManager.GetUserPermissions(UserAccessPermissionvalues.RoleID);
            if (dsuserPermission.resultDS != null && dsuserPermission.resultDS.Tables[0].Rows.Count > 0)
            {
                Boolean View = false;

                DataRow[] drpermissions = dsuserPermission.resultDS.Tables[0].Select("Form_ID ='" + FormID + "'");

                if (drpermissions.Length > 0)
                {
                    View = Convert.ToBoolean(drpermissions[0]["IsView"]);
                }
                if (View == false)
                {
                    ChangeControlStatus(false);
                }
                else
                {
                    ChangeControlStatus(true);
                }
            }
        }

        public void ChangeControlStatus(bool status)
        {

            foreach (Control c in this.Controls)
            {
                foreach (Control ctrl in c.Controls)
                {
                    EnableControls(ctrl, status);
                }

                EnableControls(c, status);
            }

        }

        public void EnableControls(Control ctrl, bool status)
        {
            if (ctrl is TextBox)

                ((TextBox)ctrl).Enabled = status;

            else if (ctrl is Button)

                ((Button)ctrl).Enabled = status;

            else if (ctrl is RadioButton)

                ((RadioButton)ctrl).Enabled = status;

            else if (ctrl is DataGridView)

                ((DataGridView)ctrl).Enabled = status;

            else if (ctrl is CheckBox)

                ((CheckBox)ctrl).Enabled = status;

            else if (ctrl is ComboBox)

                ((ComboBox)ctrl).Enabled = status;

            else if (ctrl is LinkLabel)

                ((LinkLabel)ctrl).Enabled = status;

            else if (ctrl is Panel)

                ((Panel)ctrl).Enabled = status;

            else if (ctrl is TreeView)

                ((TreeView)ctrl).Enabled = status;

            else if (ctrl is WebBrowser)

                ((WebBrowser)ctrl).Enabled = status;

            else if (ctrl is DateTimePicker)

                ((DateTimePicker)ctrl).Enabled = status;
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool status = true;
            //lblErrorMsg.Visible = false;
            if (txtOldPwd.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblErrorMsg.Text = "Current Password is required";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                txtOldPwd.Focus();
                return;
            }
            if (txtNewPwd.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                lblErrorMsg.Text = "New Password is required";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                txtNewPwd.Focus();
                return;
            }
            if (txtRNewPwd.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                lblErrorMsg.Text = "Please confirm New Password";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                txtRNewPwd.Focus();
                return;
            }

            if (txtNewPwd.Text != txtRNewPwd.Text)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                lblErrorMsg.Text = "New Password and Confirm Password does not match, try again";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                return;
            }
            if (txtNewPwd.Text == txtOldPwd.Text)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                lblErrorMsg.Text = "Your Current Password and New Password cannot be same, try again";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter Required Data");
            }
            else
            {
                try
                {

                    ChangePasswordManager objChangePasswordManager = new ChangePasswordManager();
                    NandanaResult ds = objChangePasswordManager.AdminChangePassword(username,this.Encrypt(txtOldPwd.Text.Trim()));
                    if (!ds.HasError && ds.HasData)
                    {
                        if (ds.resultDS.Tables[0].Rows.Count > 0)
                        {
                            NandanaResult ival = objChangePasswordManager.UpdateAdminPassword(username,this.Encrypt(txtNewPwd.Text.Trim()));

                            pnlError.Visible = true;
                            pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                            pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                            lblErrorMsg.Text = "Password has been changed succesfully!!!";
                            lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);

                            txtOldPwd.Text = "";
                            txtNewPwd.Text = "";
                            txtRNewPwd.Text = "";
                        }
                        else
                        {
                            pnlError.Visible = true;
                            pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                            pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                            lblErrorMsg.Text = "Current Password is Invalid";
                            lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                            txtOldPwd.Focus();
                            return;
                        }
                    }
                    else
                    {
                        pnlError.Visible = true;
                        pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                        pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                        lblErrorMsg.Text = "Current Password is Invalid";
                        lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                        txtOldPwd.Focus();
                        return;
                    }
                }

                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error While retreiving data from AdminChangePassword SP");
                }
            }
        }

        private readonly byte[] IVRegular = new byte[8] { 54, 17, 92, 36, 0, 18, 237, 152 };

        private string Encrypt(string serializedQueryString)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(serializedQueryString);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(System.Configuration.ConfigurationSettings.AppSettings["SecurityKey"]));
            des.IV = IVRegular;
            return Convert.ToBase64String(
               des.CreateEncryptor().TransformFinalBlock(
               buffer,
               0,
               buffer.Length
               )
               );
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPwd.Text = "";
            txtNewPwd.Text = "";
            txtRNewPwd.Text = "";
            pnlError.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // get reference to mdiparent form
            NewMenu mf = (NewMenu)this.MdiParent;
            // click toolStripButton1
            mf.btnHome.PerformClick();
        }

        private void txtOldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void txtNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void txtRNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
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
