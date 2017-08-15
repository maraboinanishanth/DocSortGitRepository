using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSort_CPA;
using DocSort_CPA.Forms;
using System.Security.Cryptography;
using System.IO;
using Business.Manager;
using Common;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace DocSort_CPA 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtusername.Focus();

            //cmbUserType.Text = "-Select UserType-";
            //btnLogin.BackColor = Color.FromArgb(233, 75, 76);
            btnLogin.BackColor = System.Drawing.ColorTranslator.FromHtml("#E94B4C");

            lblTag.Text = "©Copyright " + DateTime.Today.Year;

            txtusername.GotFocus+= new EventHandler(this.UserTextGotFocus);
            txtusername.LostFocus += new EventHandler(this.UserTextLostFocus);

            txtpassword.GotFocus += new EventHandler(this.PasswordTextGotFocus);
            txtpassword.LostFocus += new EventHandler(this.PasswordTextLostFocus);

            PnlLogo.Location = new Point(this.ClientSize.Width / 2 - PnlLogo.Size.Width / 2, 5);

            //lblError.Location = new Point(this.ClientSize.Width / 2 - lblError.Size.Width / 2, 84);
            //txtusername.Location = new Point(this.ClientSize.Width / 2 - txtusername.Size.Width / 2+6, 115);
            //txtpassword.Location = new Point(this.ClientSize.Width / 2 - txtpassword.Size.Width / 2+6, 171);
            //cmbUserType.Location = new Point((this.ClientSize.Width / 2 - cmbUserType.Size.Width / 2)+4, 223);
            //btnLogin.Location = new Point(this.ClientSize.Width / 2 - btnLogin.Size.Width / 2, 279);

            lblCannotAccess.Location = new Point(this.ClientSize.Width / 2 - lblCannotAccess.Size.Width / 2, 349);
            lblTag.Location = new Point(this.ClientSize.Width / 2 - lblTag.Size.Width / 2, 361);

            //txtusername.Controls.Add(pictureBox1);
           

            //lblError.Focus();
            
        }

        public void UserTextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Username")
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            }
        }

        public void UserTextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Username";
                tb.ForeColor = Color.Gray;
                
            }
        }

        public void PasswordTextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            
            if (tb.Text == "Password")
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                tb.PasswordChar = '*';
            }
        }

        public void PasswordTextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            
            if (tb.Text == "")
            {
                tb.Text = "Password";
                tb.ForeColor = Color.Gray;
                tb.PasswordChar = '\0';
                
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool status = true;
            lblError.Visible = false;
            if (txtusername.Text == string.Empty || txtusername.Text == "Username")
            {
                //MessageBox.Show("Please Enter User Name");
                lblError.Visible = true;
                lblError.Text = "Username is required";
                status = false;
                txtusername.Focus();
                return;
            }
            if (txtpassword.Text == string.Empty || txtpassword.Text == "Password")
            {
                //MessageBox.Show("Please Enter Password");
                lblError.Visible = true;
                lblError.Text = "Password is required";
                status = false;
                txtpassword.Focus();
                return;
            }
            //if (cmbUserType.Text == string.Empty || cmbUserType.Text == " UserType ")
            //{
            //    MessageBox.Show("Please Select User Type");
            //    status = false;
            //    cmbUserType.Focus();
            //    return;
            //}
            if (!status)
            {
                MessageBox.Show("Please enter required data");
            }
            else
            {
                cmbUserType.Text = "admin";
                //bool matchFound = false;
                System.Configuration.ConfigurationSettings.AppSettings["UserName"] = txtusername.Text;
                
                    try
                    {
                        String strRoleId = string.Empty;
                        String strUserId = string.Empty;


                        //MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationSettings.AppSettings["MYSQL_ConnString"]);
                        //con.Open();
                        //MySqlCommand cmd = new MySqlCommand("sp_Users", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new MySqlParameter("User_Name", txtusername.Text.Trim()));
                        //cmd.Parameters.Add(new MySqlParameter("Password", txtpassword.Text.Trim()));
                        //cmd.Parameters.Add(new MySqlParameter("Role_Name", cmbUserType.Text));

                        //MySqlDataReader dr = cmd.ExecuteReader();
                        //if (dr.Read())
                        //{
                        //    //strUserId = Convert.ToString(((((MySql.Data.MySqlClient.MySqlDataReader)(dr))).ResultSet.Values[0]).Value);
                        //    //strRoleId = Convert.ToString(((((MySql.Data.MySqlClient.MySqlDataReader)(dr))).ResultSet.Values[3]).Value);
                            
                        //    System.Configuration.ConfigurationSettings.AppSettings["RoleID"] = strRoleId;

                        //    AssignConfigParamValues(strRoleId, strUserId);

                        //    //CheckScanDocCountValue();
                        //    //CheckLicenseExpired();

                        //    NewMenu objAdminHomePage = new NewMenu();
                        //    objAdminHomePage.Show();
                        //    this.Hide();
                        //}
                        //con.Close();

                        UserManager objUserManager = new UserManager();
                        DocSortResult dsUserData = objUserManager.GetUserDetailsByCredentials(txtusername.Text.Trim(), this.Encrypt(txtpassword.Text.Trim()));
                        if (!dsUserData.HasError && dsUserData.resultDS.Tables[0].Rows.Count > 0)
                        {
                            strRoleId = Convert.ToString(dsUserData.resultDS.Tables[0].Rows[0]["Role_ID"]);
                            strUserId = Convert.ToString(dsUserData.resultDS.Tables[0].Rows[0]["User_ID"]);
                            System.Configuration.ConfigurationSettings.AppSettings["RoleID"] = strRoleId;
                            System.Configuration.ConfigurationSettings.AppSettings["UserID"] = strUserId;

                            //* inserting log details in log table *//
                            string currentSystemName = Environment.MachineName;
                            string Description = "User logged in the applicaton from " + currentSystemName +".";
                            string PresentDateTime = DateTime.Now.ToString("dd-MM-yyyy h:mm:ss tt");
                            string presentdate = DateTime.Now.ToString("dd-MM-yyyy");
                            string Type = "Login";
                            Log_History_Manager objLogHistoryManager = new Log_History_Manager();
                            DocSortResult ival = objLogHistoryManager.InsertLogHistoryDetails((DateTime.Now.ToString("dd-MM-yyyy h:mm:ss tt")), txtusername.Text.Trim(), Description.Trim(), Type.Trim(),(DateTime.Now.ToString("dd-MM-yyyy")));
                            //* End  *//

                            AssignConfigParamValues(strRoleId, strUserId);

                            CheckScanDocCountValue();
                            GetConfigValuesOfIsExpired();
                            CheckLicenseExpired();

                            NewMenu objAdminHomePage = new NewMenu();
                            objAdminHomePage.Show();
                            this.Hide();
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Invalid Username or Password";
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        //return (new (ErrorHandling.ErrorType.ERR_RETRIEVING_DATA, "Error While retrieving data from users xml.", ex));
                        MessageBox.Show(ex.Message, "Error While retriving data from Users");
                    }
                    
            }
        }

        public void CheckScanDocCountValue()
        {
            ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
            DocSortResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
            if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                {
                    if (dr["Config_Name"].ToString() == "ScanRecordCount")
                    {
                        if (dr["Config_Value"].ToString() == "")
                        {
                            ConfirmLicense obj = new ConfirmLicense();
                            //EnterScanDocCount obj = new EnterScanDocCount();
                            obj.ShowDialog();
                        }
                    }
                }
            }
        }

        public void GetConfigValuesOfIsExpired()
        {
            ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
            DocSortResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
            if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                {
                    if (dr["Config_Name"].ToString() == "IsExpired")
                    {
                        if (dr["Config_Value"].ToString() == "1")
                        {
                            ConfirmLicense obj = new ConfirmLicense();
                            obj.IsExpired = dr["Config_Value"].ToString();
                            obj.ShowDialog();
                        }
                    }
                }
            }
        }

        public void CheckLicenseExpired()
        {
            bool matchFound = false;

            string IntialDate = string.Empty;
            string NumOfDays = string.Empty;
            //DateTime Givendate=DateTime.Now;

            ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
            DocSortResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
            if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                {
                    switch (Convert.ToString(dr["Config_Name"].ToString()))
                    {
                        case "SetupDate":
                            if (dr["Config_Value"].ToString() != "")
                            {
                                IntialDate = (this.Decrypt(dr["Config_Value"].ToString()));
                            }
                            else
                                IntialDate = "";
                            break;
                        case "AllowedDays":
                            if (dr["Config_Value"].ToString() != "")
                                NumOfDays = (this.Decrypt(dr["Config_Value"].ToString()));
                            else
                                NumOfDays = "0";
                            break;
                    }
                }
            }

            if (Convert.ToInt32(NumOfDays) == 0)
            {
                ConfirmLicense obj = new ConfirmLicense();
                obj.Days = NumOfDays;
                obj.ShowDialog();
            }

            //DateTime expirydate = DateTime.ParseExact(IntialDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if ((DateTime.Today - DateTime.Parse(IntialDate, System.Globalization.CultureInfo.InvariantCulture)).Days <= Convert.ToInt16(NumOfDays))
            {
                matchFound = true;
            }
            if (!matchFound)
            {
                ConfirmLicense obj = new ConfirmLicense();
                obj.Days = NumOfDays;
                obj.LicenseExpired = "True";
                obj.ShowDialog();
            }
        }

        private readonly byte[] IVRegular = new byte[8] { 54, 17, 92, 36, 0, 18, 237, 152 };

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

                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(System.Configuration.ConfigurationManager.AppSettings["SecurityKey"]));
                des.IV = IVRegular;
                EncryptionKey = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));

            }
            catch (CryptographicException e)
            {
                return "Invalid LicenseKey";
            }
            catch (FormatException excp)
            {
                return "Invalid LicenseKey";
            }
            return EncryptionKey;
        }

        private string Encrypt(string serializedQueryString)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(serializedQueryString);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(System.Configuration.ConfigurationManager.AppSettings["SecurityKey"]));
            des.IV = IVRegular;
            return Convert.ToBase64String(
               des.CreateEncryptor().TransformFinalBlock(
               buffer,
               0,
               buffer.Length
               )
               );
        }

        private void AssignConfigParamValues(string RoleId, string UserId)
        {
            UserAccessPermissionvalues.RoleID = RoleId;
            UserAccessPermissionvalues.UserID = UserId;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
