using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.Text.RegularExpressions;

namespace DocSort_CPA.Forms
{
    public partial class EnterScanDocCount : Form
    {
        public EnterScanDocCount()
        {
            InitializeComponent();
        }

        private void EnterScanDocCount_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        public void ValidateLicenseKey()
        {
            try
            {

                string ScanCount = this.Decrypt(txtScanDocCount.Text.Trim());
                Regex regex = new Regex("^[0-9]+$");

                if (regex.IsMatch(ScanCount))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("XMLs/Config.xml");
                    XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_Config");

                    foreach (XmlNode node in nodeList)
                    {
                        if (node["Config_Name"].InnerText == "ScanRecordCount")
                        {
                            node["Config_Value"].InnerText = txtScanDocCount.Text.Trim();

                            xmlDoc.Save("XMLs/Config.xml");

                            this.Hide();
                        }
                    }
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Plese enter valid Scan Doc Count";
                    txtScanDocCount.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Plese enter valid Scan Doc Count";
                txtScanDocCount.Focus();
                return;
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

                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(System.Configuration.ConfigurationSettings.AppSettings["SecurityKey"]));
                des.IV = IVRegular;
                EncryptionKey = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));

            }
            catch (CryptographicException e)
            {
                return "Invalid LicenseKey";
                // throw e;
                //MessageBox.Show("Invalid LicenseKey", "Invalid LicenseKey");
            }
            catch (FormatException excp)
            {
                return "Invalid LicenseKey";
                //throw excp;
                //MessageBox.Show("Invalid LicenseKey", "Invalid LicenseKey");
            }
            return EncryptionKey;

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtScanDocCount.Text == String.Empty)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Please Enter Scan Doc Count";
                status = false;
                txtScanDocCount.Focus();
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

        private void txtScanDocCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }
    }
}
