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
    public partial class OpenFileCabinet : Form
    {
        public OpenFileCabinet()
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

        private void OpenFileCabinet_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(4);
            // End

            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            cmbFileCabinet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);
            this.ControlBox = false;
            //this.Location = new Point(241, 173);

            BindFileCabinets();
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

        public static DataTable GetComboBoxedDataTable(DataTable oldDataTable, string valueColumn, string textColumn, string topRowValue, string topRowText)
        {
            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add(valueColumn);
            newDataTable.Columns.Add(textColumn);

            foreach (DataRow oldDR in oldDataTable.Rows)
            {
                DataRow newDR = newDataTable.NewRow();
                newDR[0] = oldDR[valueColumn].ToString();
                newDR[1] = oldDR[textColumn].ToString();
                newDataTable.Rows.InsertAt(newDR, newDataTable.Rows.Count);
            }

            DataRow dr = newDataTable.NewRow();
            dr[0] = topRowValue;
            dr[1] = topRowText;
            newDataTable.Rows.InsertAt(dr, 0);

            return newDataTable;
        }
        public void BindFileCabinets()
        {
            try
            {
                string RoleID = UserAccessPermissionvalues.RoleID;
                string UserID = UserAccessPermissionvalues.UserID;
                if (RoleID != null && UserID != null)
                {
                    FileCabinetManager objFileCabinetManager = new FileCabinetManager();
                    DocSortResult result = new DocSortResult();
                    result = objFileCabinetManager.GetFileCabinets();
                   
                    if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
                    {

                        cmbFileCabinet.Items.Clear();
                        cmbFileCabinet.DisplayMember = "FileCabinet_Name";
                        cmbFileCabinet.ValueMember = "FileCabinet_ID";
                        // Changed Stored Procedure sp_GetFileCabinets to SORT. Nishanth. Need to send the SP also.
                        cmbFileCabinet.DataSource = GetComboBoxedDataTable(result.resultDS.Tables[0], "FileCabinet_ID", "FileCabinet_Name", "0", "Choose a Cabinet");
                        //cmbFileCabinet.Sorted = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from Filecabinet table");
            }
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (cmbFileCabinet.Text == "Choose a Cabinet" || cmbFileCabinet.Text.Length == 0)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 64);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblErrorMsg.Text = "Select a Cabinet";
                lblErrorMsg.Location = new Point((pnlError.Width - lblErrorMsg.ClientSize.Width) / 2, (pnlError.Height - lblErrorMsg.ClientSize.Height) / 2);
                status = false;
                cmbFileCabinet.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
                FileCabinetID = cmbFileCabinet.SelectedValue.ToString();
                FileCabinetName = cmbFileCabinet.Text.ToUpper();

                NewMenu objNewMenu = new NewMenu();

                //DashBoardHome obj = new DashBoardHome();
                //obj.strRootNodeID = FileCabinetID;
                //obj.strRootNode = FileCabinetName;

                //this.Hide();
                ////obj.MdiParent = this;
                //obj.Show();

                DashBoardHome obj = new DashBoardHome();
                obj.strRootNodeID = FileCabinetID;
                obj.strRootNode = FileCabinetName;
                obj.MdiParent = (NewMenu)this.MdiParent;
                obj.Show();
                //AdminHomePage obj1 = new AdminHomePage();
                //DashBoardHome obj = new DashBoardHome();
                //obj.strRootNode = Cabinet;
                ////this.Hide();
                //obj.MdiParent = obj1;
                //obj.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewMenu mf = (NewMenu)this.MdiParent;
            // click toolStripButton1
            mf.btnHome.PerformClick();
            //this.Hide();
        }

        private void cmbFileCabinet_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbFileCabinet_MouseClick(object sender, MouseEventArgs e)
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
