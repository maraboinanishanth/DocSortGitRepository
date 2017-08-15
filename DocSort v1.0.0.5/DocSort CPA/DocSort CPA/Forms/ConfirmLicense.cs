using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class ConfirmLicense : Form
    {
        public ConfirmLicense()
        {
            InitializeComponent();
        }

        public string ConfigID
        {
            set;
            get;
        }
        public string ScannedReadCountConfigValue
        {
            set;
            get;
        }
        public string LockDocCountConfigValue
        {
            set;
            get;
        }
        public string Days
        {
            set;
            get;
        }
        public string LicenseExpired
        {
            set;
            get;
        }
        public string IsExpired
        {
            set;
            get;
        }
        private void ConfirmLicense_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            if (IsExpired != null)
            {
                label2.Visible = true;
                lblHeading.Visible = true;

                this.Size = new System.Drawing.Size(450, 300);
                panel1.Size = new System.Drawing.Size(450, 300);
                lblHeading.Location = new Point(135, 14);
                label1.Location = new Point(101, lblHeading.Location.Y + 30);
                label2.Location = new Point(45, label1.Location.Y + 30);
                lblErrorMsg.Location = new Point(lblErrorMsg.Location.X, label2.Location.Y + 52);
                label6.Location = new Point(label6.Location.X, lblErrorMsg.Location.Y + 35);
                txtLicenseKey.Location = new Point(txtLicenseKey.Location.X, label6.Location.Y + 30);
                btnContinue.Location = new Point(btnContinue.Location.X, txtLicenseKey.Location.Y + txtLicenseKey.Height + 20);
                btnQuit.Location = new Point(btnContinue.Location.X + btnContinue.Width, txtLicenseKey.Location.Y + txtLicenseKey.Height + 20);
            }
            else
            {
                if (Days != null)
                {
                    label2.Visible = true;
                    lblHeading.Visible = true;

                    this.Size = new System.Drawing.Size(450, 300);
                    panel1.Size = new System.Drawing.Size(450, 300);
                    lblHeading.Location = new Point(135, 14);
                    label1.Location = new Point(101, lblHeading.Location.Y + 30);
                    label2.Location = new Point(45, label1.Location.Y + 30);
                    lblErrorMsg.Location = new Point(lblErrorMsg.Location.X, label2.Location.Y + 52);
                    label6.Location = new Point(label6.Location.X, lblErrorMsg.Location.Y + 35);
                    txtLicenseKey.Location = new Point(txtLicenseKey.Location.X, label6.Location.Y + 30);
                    btnContinue.Location = new Point(btnContinue.Location.X, txtLicenseKey.Location.Y + txtLicenseKey.Height + 20);
                    btnQuit.Location = new Point(btnContinue.Location.X + btnContinue.Width, txtLicenseKey.Location.Y + txtLicenseKey.Height + 20);
                }
                else
                {
                    label2.Visible = false;
                    lblHeading.Visible = false;

                    this.Size = new System.Drawing.Size(450, 242);
                    panel1.Size = new System.Drawing.Size(450, 242);
                    label1.Location = new Point(101, 25);
                    lblErrorMsg.Location = new Point(lblErrorMsg.Location.X, label1.Location.Y + 35);
                    label6.Location = new Point(label6.Location.X, lblErrorMsg.Location.Y + 35);
                    txtLicenseKey.Location = new Point(txtLicenseKey.Location.X, label6.Location.Y + 30);
                    btnContinue.Location = new Point(btnContinue.Location.X, txtLicenseKey.Location.Y + txtLicenseKey.Height + 20);
                    btnQuit.Location = new Point(btnContinue.Location.X + btnContinue.Width, txtLicenseKey.Location.Y + txtLicenseKey.Height + 20);
                }
            }
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtLicenseKey.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public int LenghtOfHours;

        public void ValidateLicenseKey()
        {
            string ConfigValue = string.Empty;
            string Licensekeys = string.Empty;

            ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
            DocSortResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
            if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                {
                    switch (Convert.ToString(dr["Config_Name"].ToString()))
                    {
                        case "SecurityKey":
                            ConfigValue = dr["Config_Value"].ToString();
                            break;
                        case "LicenseKeys":
                            Licensekeys = dr["Config_Value"].ToString();
                            break;
                    }
                }
            }

            try
            {
                string CompareConfigValue = this.Decrypt(txtLicenseKey.Text.Trim());
                string[] SplitLicensekey = CompareConfigValue.Split('~');
                CompareConfigValue = SplitLicensekey[0];
                if (Licensekeys != "")
                {
                    string[] SplitLicensekeys = Licensekeys.Split(',');
                    int Searchcount = 0;
                    for (int i = 0; i < SplitLicensekeys.Length; i++)
                    {
                        if (SplitLicensekey[1] == SplitLicensekeys[i])
                        {
                            Searchcount += 1;

                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "This License Key is invalid.";
                            txtLicenseKey.Focus();
                            return;
                        }
                    }
                    if (Searchcount == 0)
                    {
                        String myString = string.Empty;
                        if (SplitLicensekey[1].Length == 14)
                            myString = (SplitLicensekey[1].Substring(0, 2).ToString() + '-' + SplitLicensekey[1].Substring(2, 2).ToString() + '-' + SplitLicensekey[1].Substring(4, 2).ToString() + ' ' + SplitLicensekey[1].Substring(6, 2).ToString() + ':' + SplitLicensekey[1].Substring(8, 2).ToString() + ':' + SplitLicensekey[1].Substring(10, 2).ToString() + ' ' + SplitLicensekey[1].Substring(12, 2).ToString());
                        else
                            myString = (SplitLicensekey[1].Substring(0, 2).ToString() + '-' + SplitLicensekey[1].Substring(2, 2).ToString() + '-' + SplitLicensekey[1].Substring(4, 2).ToString() + ' ' + SplitLicensekey[1].Substring(6, 1).ToString() + ':' + SplitLicensekey[1].Substring(7, 2).ToString() + ':' + SplitLicensekey[1].Substring(9, 2).ToString() + ' ' + SplitLicensekey[1].Substring(11, 2).ToString());
                        DateTime date1 = DateTime.ParseExact(myString, "dd-MM-yy h:mm:ss tt", null);
                        DateTime date2 = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yy h:mm:ss tt"), "dd-MM-yy h:mm:ss tt", null);
                        TimeSpan ts = (date2 - date1);

                        LenghtOfHours = (int)Math.Ceiling(ts.TotalHours);
                        int comparehours = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Hours"]);
                        if (LenghtOfHours <= comparehours)
                        {
                            foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                            {
                                if (dr["Config_ID"].ToString() == "5")
                                {
                                    DocSortResult updateLicensekeys = objConfirmLicenseManager.UpdateConfigValues("5", Licensekeys + "," + SplitLicensekey[1].ToString());

                                }
                            }
                        }
                        else
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "This License Key is invalid.";
                            txtLicenseKey.Focus();
                            return;
                        }

                    }
                }
                else
                {
                    String myString = string.Empty;
                    if (SplitLicensekey[1].Length == 14)
                        myString = (SplitLicensekey[1].Substring(0, 2).ToString() + '-' + SplitLicensekey[1].Substring(2, 2).ToString() + '-' + SplitLicensekey[1].Substring(4, 2).ToString() + ' ' + SplitLicensekey[1].Substring(6, 2).ToString() + ':' + SplitLicensekey[1].Substring(8, 2).ToString() + ':' + SplitLicensekey[1].Substring(10, 2).ToString() + ' ' + SplitLicensekey[1].Substring(12, 2).ToString());
                    else
                        myString = (SplitLicensekey[1].Substring(0, 2).ToString() + '-' + SplitLicensekey[1].Substring(2, 2).ToString() + '-' + SplitLicensekey[1].Substring(4, 2).ToString() + ' ' + SplitLicensekey[1].Substring(6, 1).ToString() + ':' + SplitLicensekey[1].Substring(7, 2).ToString() + ':' + SplitLicensekey[1].Substring(9, 2).ToString() + ' ' + SplitLicensekey[1].Substring(11, 2).ToString());
                    DateTime date1 = DateTime.ParseExact(myString, "dd-MM-yy h:mm:ss tt", null);
                    DateTime date2 = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yy h:mm:ss tt"), "dd-MM-yy h:mm:ss tt", null);
                    TimeSpan ts = (date2 - date1);

                    LenghtOfHours = (int)Math.Ceiling(ts.TotalHours);
                    int comparehours = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Hours"]);
                    if (LenghtOfHours <= comparehours)
                    {
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            if (dr["Config_ID"].ToString() == "5")
                            {
                                DocSortResult updateLicensekeys = objConfirmLicenseManager.UpdateConfigValues("5", SplitLicensekey[1].ToString());

                            }
                        }
                    }
                    else
                    {
                        lblErrorMsg.Visible = true;
                        lblErrorMsg.Text = "This License Key is invalid.";
                        txtLicenseKey.Focus();
                        return;
                    }
                }
                string[] SplitLicenseNoOfDays = CompareConfigValue.Split('-');

                if (SplitLicenseNoOfDays[0].ToString().Contains(ConfigValue))
                {
                    CompareConfigValue = SplitLicenseNoOfDays[0].ToString().Replace(ConfigValue, "");

                    ConfigID = "2";

                    foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                    {
                        if (dr["Config_ID"].ToString() == "1")
                        {
                            DocSortResult updateIsExpired = objConfirmLicenseManager.UpdateConfigValues("1", "0");
                            
                        }
                    }

                    if (CompareConfigValue != "")
                    {
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            switch (dr["Config_Name"].ToString())
                            {
                                case "LockDocCount":
                                    LockDocCountConfigValue = dr["Config_Value"].ToString();
                                    break;
                                case "ScanRecordCount":
                                    if(dr["Config_Value"].ToString()!="")
                                        ScannedReadCountConfigValue = (dr["Config_Value"].ToString());
                                    break;
                            }
                        }

                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            if (dr["Config_ID"].ToString() == "3")
                            {
                                DocSortResult updateScanRecordCount;
                                if(ScannedReadCountConfigValue!=null)
                                    updateScanRecordCount = objConfirmLicenseManager.UpdateConfigValues("3", this.Encrypt((Convert.ToInt32(CompareConfigValue) +Convert.ToInt32(this.Decrypt(ScannedReadCountConfigValue))).ToString()));
                                else
                                    updateScanRecordCount = objConfirmLicenseManager.UpdateConfigValues("3", this.Encrypt((Convert.ToInt32(CompareConfigValue)).ToString()));
                            }
                        }

                        DocSortResult getupdatedConfigValues = objConfirmLicenseManager.GetAllConfigValues();
                        foreach (DataRow dr in getupdatedConfigValues.resultDS.Tables[0].Rows)
                        {
                            switch (dr["Config_Name"].ToString())
                            {
                                case "LockDocCount":
                                    LockDocCountConfigValue = dr["Config_Value"].ToString();
                                    break;
                                case "ScanRecordCount":
                                    if (dr["Config_Value"].ToString() != "")
                                        ScannedReadCountConfigValue = (dr["Config_Value"].ToString());
                                    break;
                            }
                        }
                    }
                    else
                    {
                        CompareConfigValue = "0";
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            switch (dr["Config_Name"].ToString())
                            {
                                case "LockDocCount":
                                    LockDocCountConfigValue = dr["Config_Value"].ToString();
                                    break;
                                case "ScanRecordCount":
                                    if (dr["Config_Value"].ToString() != "")
                                        ScannedReadCountConfigValue = (dr["Config_Value"].ToString());
                                    break;
                            }
                        }
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            if (dr["Config_ID"].ToString() == "3")
                            {
                                DocSortResult updateScanRecordCount;
                                if (ScannedReadCountConfigValue != null)
                                    updateScanRecordCount = objConfirmLicenseManager.UpdateConfigValues("3", this.Encrypt((Convert.ToInt32(CompareConfigValue) +Convert.ToInt32(this.Decrypt(ScannedReadCountConfigValue))).ToString()));
                                    
                                else
                                    updateScanRecordCount = objConfirmLicenseManager.UpdateConfigValues("3", this.Encrypt((Convert.ToInt32(CompareConfigValue)).ToString()));   
                            }
                        }
                    }
                   
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "This License Key is invalid.";
                    txtLicenseKey.Focus();
                    return;
                }
                if (SplitLicenseNoOfDays[1].ToString().Contains(ConfigValue))
                {
                    string PresentDays = string.Empty;
                    string NoOfDays = SplitLicenseNoOfDays[1].ToString().Replace(ConfigValue, "");

                    //ConfigID = "8";
                    if (NoOfDays != "")
                    {
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            switch (dr["Config_Name"].ToString())
                            {
                                case "AllowedDays":
                                    if (dr["Config_Value"].ToString() != "")
                                    {
                                        PresentDays = this.Decrypt(dr["Config_Value"].ToString());
                                    }
                                    else
                                    {
                                        PresentDays = "0";
                                    }
                                    break;
                            }
                        }

                        if (LicenseExpired != null)
                        {
                            foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                            {
                                if (dr["Config_ID"].ToString() == "8")
                                {
                                    
                                    DocSortResult updateDate = objConfirmLicenseManager.UpdateConfigValues("8", this.Encrypt(DateTime.Parse(DateTime.Today.ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString()));
                                   
                                }
                                if (dr["Config_ID"].ToString() == "9")
                                {
                                    DocSortResult updateDays = objConfirmLicenseManager.UpdateConfigValues("9", this.Encrypt((Convert.ToInt32(NoOfDays)).ToString()));

                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                            {
                                if (dr["Config_ID"].ToString() == "8")
                                {
                                    
                                    if (dr["Config_Value"].ToString() == "")
                                    {
                                        DocSortResult updateDate = objConfirmLicenseManager.UpdateConfigValues("8", this.Encrypt(DateTime.Parse(DateTime.Today.ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString()));
                                        
                                    }
                                }
                                if (dr["Config_ID"].ToString() == "9")
                                {
                                    DocSortResult updateDays = objConfirmLicenseManager.UpdateConfigValues("9", this.Encrypt((Convert.ToInt32(PresentDays) + (Convert.ToInt32(NoOfDays))).ToString()));
                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        NoOfDays = "0";
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            switch (dr["Config_Name"].ToString())
                            {
                                case "AllowedDays":
                                    if (dr["Config_Value"].ToString() != "")
                                    {
                                        PresentDays = this.Decrypt(dr["Config_Value"].ToString());
                                    }
                                    else
                                    {
                                        PresentDays = "0";
                                    }
                                    break;
                            }
                        }
                        foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                        {
                            if (dr["Config_ID"].ToString() == "9")
                            {
                                DocSortResult updateDays = objConfirmLicenseManager.UpdateConfigValues("9", this.Encrypt((Convert.ToInt32(PresentDays) + (Convert.ToInt32(NoOfDays))).ToString()));
                            }
                        }
                    }

                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "This License Key is invalid.";
                txtLicenseKey.Focus();
                return;
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
             bool status = true;
             if (txtLicenseKey.Text == String.Empty)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "This License Key is invalid.";
                status = false;
                txtLicenseKey.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
                ValidateLicenseKey();
            }
        }

        private void txtLicenseKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
