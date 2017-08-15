using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class Useraccesspermissions : Form
    {
        public Useraccesspermissions()
        {
            InitializeComponent();
        }

        private void Useraccesspermissions_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(10);
            // End

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth - 3) - this.ClientSize.Width) / 2, 139);
            this.ControlBox = false;

            BindRoles();

            btnSave.Visible = false;
            btnCancel.Visible = false;
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


        private void BindRoles()
        {
            try
            {
                UserManager objUserManager = new UserManager();

                DocSortResult dsUserData = objUserManager.GetRoles();
                if (!dsUserData.HasError && dsUserData.resultDS.Tables[0].Rows.Count > 0)
                {
                    //cmbRoles.Items.Clear();
                    cmbRoles.DisplayMember = "Role_Name";
                    cmbRoles.ValueMember = "Role_ID";
                    cmbRoles.DataSource = GetComboBoxedDataTable(dsUserData.resultDS.Tables[0], "Role_ID", "Role_Name", "0", "Choose Role");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error While retriving data from GetRoles");
            }

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

            // Add your 'Select an item' option at the top
            DataRow dr = newDataTable.NewRow();
            dr[0] = topRowValue;
            dr[1] = topRowText;
            newDataTable.Rows.InsertAt(dr, 0);

            return newDataTable;
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue.ToString() != "0")
            {
                BindPermissions();
            }            
        }

        private void BindPermissions()
        {
            if (cmbRoles.SelectedValue != null)
            {
                DocSortResult dsResult = new DocSortResult();
                DocSortResult dsuserPermission = new DocSortResult();
                UserManager objUserManager = new UserManager();
                dsResult = objUserManager.GetAllForms();
                DataTable dtUserAccess = new DataTable();
                dtUserAccess.Columns.Add("ID", typeof(string));
                dtUserAccess.Columns.Add("FormName", typeof(string));
                dtUserAccess.Columns.Add("View", typeof(Boolean));
                
                string RoleId = cmbRoles.SelectedValue.ToString();
                
                dgvUserAccessPermissions.Columns.Clear();
                dgvUserAccessPermissions.AutoGenerateColumns = false;
                dgvUserAccessPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUserAccessPermissions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvUserAccessPermissions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

                DataGridViewColumn clnFormID = new DataGridViewTextBoxColumn();
                clnFormID.DataPropertyName = "ID";
                clnFormID.Name = "ID";
                dgvUserAccessPermissions.Columns.Add(clnFormID);
                clnFormID.Visible = false;

                DataGridViewColumn clnFormName = new DataGridViewTextBoxColumn();
                clnFormName.DataPropertyName = "FormName";
                clnFormName.Name = "Screen Name";
                dgvUserAccessPermissions.Columns.Add(clnFormName);
                clnFormName.Width = 320;

                DataGridViewCheckBoxColumn clnView = new DataGridViewCheckBoxColumn();
                clnView.DataPropertyName = "View";
                clnView.Name = "View";
                dgvUserAccessPermissions.Columns.Add(clnView);
                clnView.Width = 120;
                this.dgvUserAccessPermissions.Columns["View"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                dsuserPermission = objUserManager.GetUserPermissions(cmbRoles.SelectedValue.ToString());
                if (!dsResult.HasError && dsResult.resultDS.Tables[0].Rows.Count > 0)
                {
                    string MenuIds = string.Empty;

                    //DataRow[] drMainMenus = dsResult.Tables[0].Select("MainMenuId is NULL ");  //
                    //DataTable dtMainMenus = drMainMenus.CopyToDataTable();

                    foreach (DataRow dr in dsResult.resultDS.Tables[0].Rows)
                    {
                        Boolean View = false;
                        string FormName=string.Empty;

                        if (dsuserPermission.resultDS != null && dsuserPermission.resultDS.Tables[0].Rows.Count > 0)
                        {

                            DataRow[] drpermissions = dsuserPermission.resultDS.Tables[0].Select("Form_ID ='" + Convert.ToString(dr["Form_ID"]) + "'");
                            FormName = GetMenuName(Convert.ToString(dr["Form_ID"]));
                            if (drpermissions.Length > 0)
                            {
                                View = Convert.ToBoolean(drpermissions[0]["IsView"]);

                            }
                        }
                        else
                        {
                            FormName = GetMenuName(Convert.ToString(dr["Form_ID"]));
                            View = false;
                        }
                        dtUserAccess.Rows.Add(Convert.ToString(dr["Form_ID"]), FormName, View);
                    }
                    dgvUserAccessPermissions.DataSource = dtUserAccess;
                    dgvUserAccessPermissions.Visible = true;

                    btnSave.Visible = true;
                    btnCancel.Visible = true;
                }
                else
                {
                    dgvUserAccessPermissions.Visible = false;

                    btnSave.Visible = false;
                    btnCancel.Visible = false;

                }
            }
            else
            {
                dgvUserAccessPermissions.Visible = false;

                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }

        private string GetMenuName(string ID)
        {
            String MenuName = string.Empty;
            UserManager objUserManager = new UserManager();
            DocSortResult dsResult = new DocSortResult();
            dsResult = objUserManager.GetMenuNamesByFormID(ID);
            if (!dsResult.HasError && dsResult.resultDS.Tables[0].Rows.Count > 0)
            {
                MenuName = Convert.ToString(dsResult.resultDS.Tables[0].Rows[0][0]);
            }
            return MenuName;
        }
        private string FormMenuwithMainMenu(string MenuId)
        {
            string strMenuName = string.Empty;
            DocSortResult dsResult = new DocSortResult();

            UserManager objUserManager = new UserManager();
            dsResult = objUserManager.GetMenuDetilsByMainMenuId(MenuId);
            return strMenuName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (cmbRoles.Text == "Choose Role" || cmbRoles.Text.Length==0)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 26);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select a Role";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                cmbRoles.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
                if (dgvUserAccessPermissions.Rows.Count > 0)
                {
                    foreach (DataGridViewRow gvrow in dgvUserAccessPermissions.Rows)
                    {
                        bool View = Convert.ToBoolean(gvrow.Cells[2].Value);

                        DocSortResult dsResult = new DocSortResult();
                        try
                        {
                            UserManager objUserManager = new UserManager();
                            dsResult = objUserManager.InsertUpdateUserAccessPermissions(cmbRoles.SelectedValue.ToString(), Convert.ToString(gvrow.Cells[0].Value), Convert.ToBoolean(gvrow.Cells[2].Value));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error while Inserting Data from UserAccessPermissions table");
                        }
                    }

                    SaveSuccess objSaveSuccess = new SaveSuccess();
                    objSaveSuccess.ShowDialog();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewMenu mf = (NewMenu)this.MdiParent;
            mf.btnHome.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewRole objNewRole = new NewRole();
            objNewRole.ShowDialog();
            BindRoles();
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
