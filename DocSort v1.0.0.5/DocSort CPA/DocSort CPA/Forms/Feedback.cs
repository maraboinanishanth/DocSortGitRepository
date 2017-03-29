using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class Feedback : Form
    {
        
        public Feedback()
        {
            InitializeComponent();
            
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
            //this.TransparencyKey = Color.Transparent;
        }

        private void Feedback_Load(object sender, EventArgs e)
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
                label1.ForeColor = Color.Teal;
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
                label1.ForeColor = Color.Teal;
            }

            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            //this.Location = new Point(0, 0);
            //this.WindowState = FormWindowState.Normal;

           
            //panel1.Location = new Point((this.Width - panel1.ClientSize.Width) / 2, (this.Height - panel1.ClientSize.Height) / 2);

            txtName.Focus();

            panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
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


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string From = string.Empty;
            string FromPWD = string.Empty;
            string ToAddress = string.Empty;
            string BCCAddress = string.Empty;
            string Name = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            string Comments = string.Empty;
            string MessageBody = string.Empty;
            try
            {
                ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
                NandanaResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
                if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                    {
                        switch (Convert.ToString(dr["Config_Name"].ToString()).ToUpper())
                        {
                            case "FROMEMAIL":
                                From = (this.Decrypt(dr["Config_Value"].ToString()));
                                break;
                            case "FROMPASSWORD":
                                FromPWD = (this.Decrypt(dr["Config_Value"].ToString()));
                                break;
                            case "TOADDRESS":
                                ToAddress = dr["Config_Value"].ToString();
                                break;
                            case "BCCADDRESS":
                                BCCAddress = dr["Config_Value"].ToString();
                                break;
                        }
                    }
                }
               
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(From, FromPWD);
                
                MailMessage msg = new MailMessage();
               
                msg.To.Add(ToAddress);
                msg.Bcc.Add(BCCAddress);

                msg.From = new MailAddress(From);
                msg.Subject = "Application Feedback";

                if (txtName.Text != "") Name = txtName.Text.Trim();
                if (txtPhone.Text != "") Phone = txtPhone.Text.Trim();
                if (txtEmail.Text != "") Email = txtEmail.Text.Trim();
                if (txtComments.Text != "") Comments = txtComments.Text.Trim();



                string Message = "Name: " + Name + "\r\n" + "\r\n" + "Phone: " + Phone + "\r\n" + "\r\n" + "Email: " + Email + "\r\n" + "\r\n" + "Content: " + StarContent + "\r\n" + "\r\n" + "Design: " + StarDesign + "\r\n" + "\r\n" + "Usability: " + StarUsability + "\r\n" + "\r\n" + "Overall: " + StarOverall + "\r\n" + "\r\n" + "Comments/Suggestions: " + Comments;

                msg.Body = Message;

                //Attachment data = new Attachment(txtAttachments.Text);
                //msg.Attachments.Add(data);
                client.Send(msg);

                FeedbackSuccess objFeedbackSuccess = new FeedbackSuccess();
                objFeedbackSuccess.ShowDialog();
                //MessageBox.Show("Successfully Sent Message.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtComments.Text = "";

            this.Hide();
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
                return "Invalid credentials";
                // throw e;
                //MessageBox.Show("Invalid LicenseKey", "Invalid LicenseKey");
            }
            catch (FormatException excp)
            {
                return "Invalid credentials";
                //throw excp;
                //MessageBox.Show("Invalid LicenseKey", "Invalid LicenseKey");
            }
            return EncryptionKey;

        }

        int StarContent = 0;
        int StarDesign = 0;
        int StarUsability = 0;
        int StarOverall = 0;

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Please enter numbers only";
                e.Handled = true;
            }
        }

        private void starRatingContent_Click(object sender, EventArgs e)
        {
            StarContent = starRatingContent.SelectedStar;
        }

        private void starRatingDesign_Click(object sender, EventArgs e)
        {
            StarDesign = starRatingDesign.SelectedStar;
        }

        private void starRatingUsability_Click(object sender, EventArgs e)
        {
            StarUsability = starRatingUsability.SelectedStar;
        }

        private void starRatingOverall_Click(object sender, EventArgs e)
        {
            StarOverall = starRatingOverall.SelectedStar;
        }
    }
}
