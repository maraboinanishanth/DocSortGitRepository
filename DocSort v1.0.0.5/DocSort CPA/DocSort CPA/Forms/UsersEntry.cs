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
using System.Security.Cryptography;

namespace DocSort_CPA.Forms
{
    public partial class UsersEntry : Form
    {
        public UsersEntry()
        {
            InitializeComponent();
        }

        DataTable Dttemp = new DataTable();

        private void UsersEntry_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(15);
            // End

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth - 3) - this.ClientSize.Width) / 2, 139);
            this.ControlBox = false;

            btnUpdate.Visible = false;

            BindRoles();
            cmbStatus.Text = "Active";

            Dttemp.Columns.Clear();

            Dttemp.Columns.Add("User_ID", typeof(int));
            Dttemp.Columns.Add("Name", typeof(String));
            Dttemp.Columns.Add("Address", typeof(String));
            Dttemp.Columns.Add("State", typeof(String));
            Dttemp.Columns.Add("Country", typeof(String));
            Dttemp.Columns.Add("MobileNo", typeof(String));
            Dttemp.Columns.Add("User_Name", typeof(String));
            Dttemp.Columns.Add("Role_Name", typeof(String));

            GetUsersDetails();
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

        public void GetUsersDetails()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

            
            DataGridViewColumn clnDocumentID = new DataGridViewTextBoxColumn();
            clnDocumentID.DataPropertyName = "User_ID";
            clnDocumentID.Name = "User_ID";
            dgvUsers.Columns.Add(clnDocumentID);
            clnDocumentID.Visible = false;

            DataGridViewLinkColumn clnDocumentName = new DataGridViewLinkColumn();
            clnDocumentName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            clnDocumentName.LinkColor = Color.Blue;
            clnDocumentName.DataPropertyName = "Name";
            clnDocumentName.Name = "Name";
            dgvUsers.Columns.Add(clnDocumentName);
            dgvUsers.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            DataGridViewColumn clnDocumentPath = new DataGridViewTextBoxColumn();
            clnDocumentPath.DataPropertyName = "Address";
            clnDocumentPath.Name = "Address";
            dgvUsers.Columns.Add(clnDocumentPath);

            DataGridViewColumn clnKeyword = new DataGridViewTextBoxColumn();
            clnKeyword.DataPropertyName = "State";
            clnKeyword.Name = "State";
            dgvUsers.Columns.Add(clnKeyword);
            
            DataGridViewColumn clnKeywordID = new DataGridViewTextBoxColumn();
            clnKeywordID.DataPropertyName = "Country";
            clnKeywordID.Name = "Country";
            dgvUsers.Columns.Add(clnKeywordID);
            
            
            DataGridViewColumn clnProcesstype = new DataGridViewTextBoxColumn();
            clnProcesstype.DataPropertyName = "MobileNo";
            clnProcesstype.Name = "MobileNo";
            dgvUsers.Columns.Add(clnProcesstype);

            DataGridViewColumn clnUsername = new DataGridViewTextBoxColumn();
            clnUsername.DataPropertyName = "User_Name";
            clnUsername.Name = "UserName";
            dgvUsers.Columns.Add(clnUsername);
            dgvUsers.Columns[6].HeaderCell.SortGlyphDirection = SortOrder.None;

            DataGridViewColumn clnRole = new DataGridViewTextBoxColumn();
            clnRole.DataPropertyName = "Role_Name";
            clnRole.Name = "Role";
            dgvUsers.Columns.Add(clnRole);

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Image = global::DocSort_CPA.Properties.Resources.delete1;
            dgvUsers.Columns.Add(img);
            img.HeaderText = "";
            img.Name = "img";
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            img.Width = 40;

            Dttemp.Clear();

            try
            {

                NewUserManager objShowDocumentsManager = new NewUserManager();
                DocSortResult dsgetScannedDocumentResultsdetails = objShowDocumentsManager.GetUsers();
                UserManager objUserManager = new UserManager();
                DocSortResult dsUserData = objUserManager.GetRoles();
                if (dsgetScannedDocumentResultsdetails.resultDS != null && dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsgetScannedDocumentResultsdetails.resultDS.Tables[0].Rows)
                    {
                        DataRow[] drResult = dsUserData.resultDS.Tables[0].Select("Role_ID =" + dr["Role_ID"].ToString() + "");
                        if (drResult.Count() != 0)
                        {
                            DataRow drtemp = Dttemp.NewRow();
                           
                            drtemp["User_ID"] = dr["User_ID"].ToString();
                            drtemp["Name"] = dr["Name"].ToString();
                            drtemp["Address"] = dr["Address"].ToString();
                            drtemp["State"] = dr["State"].ToString();
                            drtemp["Country"] = dr["Country"].ToString();
                            drtemp["MobileNo"] = dr["MobileNo"].ToString();
                            drtemp["User_Name"] = dr["User_Name"].ToString();
                            drtemp["Role_Name"] = drResult[0].ItemArray[1].ToString();

                            Dttemp.Rows.Add(drtemp);
                        }
                    }
                    dgvUsers.DataSource = Dttemp;
                }
                else
                {
                    dgvUsers.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from GetUsers table");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtFirstName.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "First Name is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Last Name is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtLastName.Focus();
                return;
            }
            if (txtUserName.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "User Name is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Password is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtPassword.Focus();
                return;
            }
            if (txtConfirmPassword.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Please confirm Password";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtConfirmPassword.Focus();
                return;
            }
            if (cmbRoles.Text == "Choose Role" || cmbRoles.Text.Length == 0)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select a Role";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                cmbRoles.Focus();
                return;
            }
            if (cmbStatus.Text == "-Choose a Status-")
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select a Status";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                cmbStatus.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Password and Confirm Password does not match, try again";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
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
                    // Checking duplicate User names with the RoleID

                    NewUserManager objNewUserManager = new NewUserManager();
                    DocSortResult dsUserData = objNewUserManager.CheckDuplicateUser(txtUserName.Text.Trim());
                    if (!dsUserData.HasError && dsUserData.resultDS.Tables[0].Rows.Count > 0)
                    {
                        pnlError.Visible = true;
                        pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                        pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                        lblError.Text = "User name already exists, type a new one";
                        lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                        status = false;
                        txtUserName.Focus();
                        return;
                    }

                    //end

                    //* inserting User details in Users table *//

                    Boolean Status = Convert.ToBoolean(0);
                    if (cmbStatus.Text == "Active")
                    {
                        Status = Convert.ToBoolean(1);
                    }
                    else if (cmbStatus.Text == "InActive")
                    {
                        Status = Convert.ToBoolean(0);
                    }
                    DocSortResult insertUserValues = objNewUserManager.InsertUserValues(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtMiddleName.Text.Trim(), txtAddress.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(),txtCountry.Text.Trim(),txtZip.Text.Trim(), txtMobile.Text.Trim(), txtHomePhone.Text.Trim(), txtUserName.Text.Trim(), this.Encrypt(txtPassword.Text.Trim()), cmbRoles.SelectedValue.ToString(), Status);

                    //* End  *//

                    SaveSuccess objSaveSuccess = new SaveSuccess();
                    objSaveSuccess.FormName = "NewUser";
                    objSaveSuccess.ShowDialog();

                    EmptyControls();

                    GetUsersDetails();

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error while Inserting Data from InsertUserValues SP");
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

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Invalid data, type a valid number";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                txtZip.Focus();
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Invalid data, type a valid number";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                txtMobile.Focus();
                e.Handled = true;
            }
        }

        private void txtHomePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Invalid data, type a valid number";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                txtHomePhone.Focus();
                e.Handled = true;
            }
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
        public bool GetDeletePermissiondetails()
        {
            Boolean canDelete = false;
            UserManager objUserManager = new UserManager();
            DocSortResult dsuserPermission = new DocSortResult();
            dsuserPermission = objUserManager.GetUserPermissions(UserAccessPermissionvalues.RoleID);
            if (dsuserPermission.resultDS != null && dsuserPermission.resultDS.Tables[0].Rows.Count > 0)
            {


                DataRow[] drpermissions = dsuserPermission.resultDS.Tables[0].Select("Form_ID ='" + 18 + "'");//18 is the Form_ID of Delete option in tbl_Useraccesspermission

                if (drpermissions.Length > 0)
                {
                    canDelete = Convert.ToBoolean(drpermissions[0]["IsView"]);

                }

            }
            return canDelete;
        }

        public string UserID;
        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool canLoginUserDeleteAnotherUser = GetDeletePermissiondetails();

            if (canLoginUserDeleteAnotherUser)
            {
                NewUserManager objNewUserManager = new NewUserManager();
                if (dgvUsers.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 8)
                    {
                        int row;
                        row = e.RowIndex;

                        DeleteConfirmation objDeleteConfirmation = new DeleteConfirmation();
                        objDeleteConfirmation.UserName = dgvUsers.Rows[row].Cells[1].Value.ToString();
                        objDeleteConfirmation.ShowDialog();

                        if (objDeleteConfirmation.DeleteConfirmationRequest == "Yes")
                        {
                            if (row >= 0)
                            {
                                UserID = dgvUsers.Rows[row].Cells[0].Value.ToString();
                                try
                                {
                                    DocSortResult result = new DocSortResult();
                                    result = objNewUserManager.DeleteUserDetails(UserID);
                                }
                                catch (Exception x)
                                {
                                    MessageBox.Show(x.Message, "Error while Deleting Data from DeletePayslip SP");
                                }
                                GetUsersDetails();
                            }
                        }
                    }
                    if (e.ColumnIndex == 1)
                    {
                        int row;
                        row = e.RowIndex;
                        if (row >= 0)
                        {
                            UserID = dgvUsers.Rows[row].Cells[0].Value.ToString();
                        }
                        if (UserID != null && UserID != string.Empty)
                        {
                            Boolean Status = false;
                            try
                            {
                                DocSortResult dsUserdetailValues = objNewUserManager.GetUserDetailsUsingUserID(UserID);
                                if (dsUserdetailValues.resultDS != null && dsUserdetailValues.resultDS.Tables[0].Rows.Count > 0)
                                {
                                    DataRow dr = dsUserdetailValues.resultDS.Tables[0].Rows[0];
                                    txtFirstName.Text = dr["FirstName"].ToString();
                                    txtLastName.Text = dr["LastName"].ToString();
                                    txtMiddleName.Text = dr["MiddleName"].ToString();
                                    txtAddress.Text = dr["Address"].ToString();
                                    txtCity.Text = dr["City"].ToString();
                                    txtState.Text = dr["State"].ToString();
                                    txtCountry.Text = dr["Country"].ToString();
                                    txtZip.Text = dr["Zip"].ToString();
                                    txtMobile.Text = dr["MobileNo"].ToString();
                                    txtHomePhone.Text = dr["AlternateMobileNo"].ToString();
                                    txtUserName.Text = dr["User_Name"].ToString();
                                    txtPassword.Text = this.Decrypt(dr["Password"].ToString());
                                    txtConfirmPassword.Text = this.Decrypt(dr["Password"].ToString());
                                    cmbRoles.SelectedValue = dr["Role_ID"].ToString();
                                    Status = Convert.ToBoolean(dr["Status"]);
                                }

                                txtUserName.ReadOnly = true;

                                if (Status == true)
                                {
                                    cmbStatus.Text = "Active";
                                }
                                else
                                {
                                    cmbStatus.Text = "InActive";
                                }

                                btnSave.Visible = false;
                                btnUpdate.Visible = true;
                                btnUpdate.Location = new Point(471, 301);
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show(x.Message, "Error while Retreiving Data from GetUserDetailsUsingUserID SP");
                            }

                            txtFirstName.Focus();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You do not access to Edit. Please check with your admin to get access.");
            }
        }

        private string Decrypt(string encryptedQueryString)
        {
            string EncryptionKey = "";

            string methodName = "decrypt()";
            try
            {
                byte[] buffer = null;

                buffer = Convert.FromBase64String(encryptedQueryString);

                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(System.Configuration.ConfigurationSettings.AppSettings["SecurityKey"]));
                des.IV = IVRegular;
                EncryptionKey = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));

            }
            catch (CryptographicException e)
            {
                return "Invalid License Key";
                // throw e;
                //MessageBox.Show("Invalid LicenseKey", "Invalid LicenseKey");
            }
            catch (FormatException excp)
            {
                return "Invalid License Key";
                //throw excp;
                //MessageBox.Show("Invalid LicenseKey", "Invalid LicenseKey");
            }
            return EncryptionKey;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtFirstName.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "First Name is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Last Name is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtLastName.Focus();
                return;
            }
            if (txtUserName.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "User Name is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Password is required";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtPassword.Focus();
                return;
            }
            if (txtConfirmPassword.Text == string.Empty)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Please confirm Password";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                txtConfirmPassword.Focus();
                return;
            }
            if (cmbRoles.Text == "Choose Role" || cmbRoles.Text.Length == 0)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select a Role";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                cmbRoles.Focus();
                return;
            }
            if (cmbStatus.Text == "-Choose a Status-")
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select a Status";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                cmbStatus.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                pnlError.Visible = true;
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 12);
                lblError.Text = "Password and Confirm Password does not match, try again";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
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
                    //* Updating User details in Users table *//

                    Boolean Status = Convert.ToBoolean(0);
                    if (cmbStatus.Text == "Active")
                    {
                        Status = Convert.ToBoolean(1);
                    }
                    else if (cmbStatus.Text == "InActive")
                    {
                        Status = Convert.ToBoolean(0);
                    }
                    NewUserManager objNewUserManager = new NewUserManager();
                    DocSortResult insertUserValues = objNewUserManager.UpdateUserDetails(UserID,txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtMiddleName.Text.Trim(), txtAddress.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(),txtCountry.Text.Trim(), txtZip.Text.Trim(), txtMobile.Text.Trim(), txtHomePhone.Text.Trim(), txtUserName.Text.Trim(), this.Encrypt(txtPassword.Text.Trim()), cmbRoles.SelectedValue.ToString(), Status);

                    //* End  *//

                    SaveSuccess objSaveSuccess = new SaveSuccess();
                    objSaveSuccess.FormName = "NewUser";
                    objSaveSuccess.ShowDialog();

                    EmptyControls();

                    GetUsersDetails();

                    txtUserName.ReadOnly = false;

                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error while Inserting Data from InsertUserValues SP");
                }

            }
        }

        public void EmptyControls()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            txtZip.Text = "";
            txtMobile.Text = "";
            txtHomePhone.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cmbRoles.SelectedValue = 0;
            cmbStatus.Text = "Active";
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbRoles_MouseClick(object sender, MouseEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbStatus_MouseClick(object sender, MouseEventArgs e)
        {
            pnlError.Visible = false;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void dgvUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgvUsers.Cursor = Cursors.Hand;
            }
            else
                dgvUsers.Cursor = Cursors.Default;

            if (e.ColumnIndex == 8)
            {
                dgvUsers.Cursor = Cursors.Hand;
            }
            else
                dgvUsers.Cursor = Cursors.Default;
        }
    }
}
