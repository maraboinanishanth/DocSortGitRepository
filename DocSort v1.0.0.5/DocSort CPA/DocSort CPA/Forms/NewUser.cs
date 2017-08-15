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
using System.Security.Cryptography;

namespace DocSort_CPA.Forms
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            BindRoles();
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
                    cmbRole.Items.Clear();
                    cmbRole.DisplayMember = "Role_Name";
                    cmbRole.ValueMember = "Role_ID";
                    cmbRole.DataSource = GetComboBoxedDataTable(dsUserData.resultDS.Tables[0], "Role_ID", "Role_Name", "0", "Choose Role");
                }
                else
                {
                    cmbRole.Items.Clear();
                    DataTable dtRoles = new DataTable();
                    cmbRole.DisplayMember = "Role_Name";
                    cmbRole.ValueMember = "Role_ID";
                    cmbRole.DataSource = GetComboBoxedDataTable(dtRoles, "Role_ID", "Role_Name", "0", "Choose Role");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error While retriving data from GetRoles");
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
            if (txtUserName.Text == String.Empty)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "User name is required";
                status = false;
                txtUserName.Focus();
                return;
            }
            if (cmbRole.Text == "Choose Role" || cmbRole.Text.Length == 0)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Select a Role";
                status = false;
                txtUserName.Focus();
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
                    // Checking duplicate User names with the RoleID

                    UserManager objUserManager = new UserManager();


                    DocSortResult dsUserData = objUserManager.GetUserDetailsByCredentials(txtUserName.Text.Trim(), this.Encrypt(txtUserName.Text.Trim()));
                        if (!dsUserData.HasError && dsUserData.resultDS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in dsUserData.resultDS.Tables[0].Rows)
                            {
                                string UserName = dr["User_Name"].ToString();
                                string RoleID = dr["Role_ID"].ToString();

                                if (UserName.ToUpper() == txtUserName.Text.ToUpper() && RoleID == cmbRole.SelectedValue.ToString())
                                {
                                    lblErrorMsg.Visible = true;
                                    lblErrorMsg.Text = "User already exists, type a new name";
                                    status = false;
                                    txtUserName.Focus();
                                    return;
                                }

                            }
                        }

                    //end

                    //* inserting User details in Users table *//

                    DocSortResult insertUserValues = objUserManager.InsertUserValues(txtUserName.Text.Trim(), this.Encrypt(txtUserName.Text.Trim()), cmbRole.SelectedValue.ToString());


                    //* End  *//

                    this.Hide();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }

        private void cmbRole_MouseClick(object sender, MouseEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }
    }
}
