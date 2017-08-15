using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class NewFileCabinet : Form
    {
        public NewFileCabinet()
        {
            InitializeComponent();
        }


        public string FileCabinetID
        {
            set;
            get;
        }
        public string FileCabinetName
        {
            set;
            get;
        }
        private void NewFileCabinet_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(3);
            // End

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);
            this.ControlBox = false;
            //this.Location = new Point(241, 173);
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtFileCabinet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetPermissiondetails(int FormID)
        {
            UserManager objUserManager = new UserManager();
            DocSortResult dsuserPermission = new DocSortResult();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtFileCabinet.Text == String.Empty)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblErrorMsg.Text = "Cabinet name is required";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                txtFileCabinet.Focus();
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
                    // Checking duplicate cabinet names

                    FileCabinetManager objFileCabinetManager = new FileCabinetManager();
                    DocSortResult result = new DocSortResult();
                    result = objFileCabinetManager.GetFileCabinets();

                    if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in result.resultDS.Tables[0].Rows)
                        {
                            string CabinetName = dr["FileCabinet_Name"].ToString();

                            if (CabinetName.ToUpper() == txtFileCabinet.Text.ToUpper())
                            {
                                pnlError.Visible = true;
                                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                                lblErrorMsg.Text = "Cabinet already exists, type a new name";
                                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                                status = false;
                                txtFileCabinet.Focus();
                                return;
                            }

                        }
                    }

                    //end

                    //* inserting File Cabinet details in FileCabinet table *//

                    DocSortResult insertFileCabinet = objFileCabinetManager.InsertFileCabinetDetails(txtFileCabinet.Text.Trim(),"True");
                    if (insertFileCabinet.resultDS != null && insertFileCabinet.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = insertFileCabinet.resultDS.Tables[0].Rows[0];
                        FileCabinetID = dr["CabinetID"].ToString();
                        FileCabinetName = txtFileCabinet.Text;
                    }

                    //* End  *//

                    DashBoardHome obj = new DashBoardHome();
                    obj.strRootNodeID = FileCabinetID;
                    obj.strRootNode = FileCabinetName;
                    obj.MdiParent = (NewMenu)this.MdiParent;
                    obj.Show();
                    
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
            NewMenu mf = (NewMenu)this.MdiParent;
            // click toolStripButton1
            mf.btnHome.PerformClick();
            //this.Hide();
        }

        private void txtFileCabinet_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFileCabinet_TextChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }
    }
}
