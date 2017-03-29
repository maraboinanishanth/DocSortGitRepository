using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSort_CPA.Reports;
using System.IO;
using System.Xml;
using System.Reflection;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class NewMenu : Form
    {
        public NewMenu()
        {
            InitializeComponent();
        }

        bool onFullScreen;
        bool maximized;
        bool on_MinimumSize;
        short minimumWidth = 350;
        short minimumHeight = 26;
        short borderSpace = 20;
        short borderDiameter = 3;

        bool onBorderRight;
        bool onBorderLeft;
        bool onBorderTop;
        bool onBorderBottom;
        bool onCornerTopRight;
        bool onCornerTopLeft;
        bool onCornerBottomRight;
        bool onCornerBottomLeft;

        bool movingRight;
        bool movingLeft;
        bool movingTop;
        bool movingBottom;
        bool movingCornerTopRight;
        bool movingCornerTopLeft;
        bool movingCornerBottomRight;
        bool movingCornerBottomLeft;

        private void startResizer()
        {
            if (movingRight)
            {
                this.Width = Cursor.Position.X - this.Location.X;
            }

            else if (movingLeft)
            {
                this.Width = ((this.Width + this.Location.X) - Cursor.Position.X);
                this.Location = new Point(Cursor.Position.X, this.Location.Y);
            }

            else if (movingTop)
            {
                this.Height = ((this.Height + this.Location.Y) - Cursor.Position.Y);
                this.Location = new Point(this.Location.X, Cursor.Position.Y);
            }

            else if (movingBottom)
            {
                this.Height = (Cursor.Position.Y - this.Location.Y);
            }

            else if (movingCornerTopRight)
            {
                this.Width = (Cursor.Position.X - this.Location.X);
                this.Height = ((this.Location.Y - Cursor.Position.Y) + this.Height);
                this.Location = new Point(this.Location.X, Cursor.Position.Y);
            }

            else if (movingCornerTopLeft)
            {
                this.Width = ((this.Width + this.Location.X) - Cursor.Position.X);
                this.Location = new Point(Cursor.Position.X, this.Location.Y);
                this.Height = ((this.Height + this.Location.Y) - Cursor.Position.Y);
                this.Location = new Point(this.Location.X, Cursor.Position.Y);
            }

            else if (movingCornerBottomRight)
            {
                this.Size = new Size(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
            }

            else if (movingCornerBottomLeft)
            {
                this.Width = ((this.Width + this.Location.X) - Cursor.Position.X);
                this.Height = (Cursor.Position.Y - this.Location.Y);
                this.Location = new Point(Cursor.Position.X, this.Location.Y);
            }
        }

        private void stopResizer()
        {
            movingRight = false;
            movingLeft = false;
            movingTop = false;
            movingBottom = false;
            movingCornerTopRight = false;
            movingCornerTopLeft = false;
            movingCornerBottomRight = false;
            movingCornerBottomLeft = false;
            this.Cursor = Cursors.Default;
            System.Threading.Thread.Sleep(300);
            on_MinimumSize = false;
        }
        private void NewMenu_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(13);
            GetPermissiondetails(14);
            // End

            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            UserAccessPermissionvalues.NewMenuWidth = this.Width;
            UserAccessPermissionvalues.NewMenuHeight = this.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = FormWindowState.Normal;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;
            //panel2.BackColor = Color.FromArgb(232, 75, 76);
            //panel3.BackColor = Color.FromArgb(232, 75, 76);
            panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#E94B4C");
            panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#E94B4C");

            panel4.BackColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            panel7.BackColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            panel8.BackColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");

            btnMinimise.FlatAppearance.BorderColor = Color.FromArgb(232, 75, 76);
            btnMaximise.FlatAppearance.BorderColor = Color.FromArgb(232, 75, 76);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(232, 75, 76);

            //lblUserName.Text = System.Configuration.ConfigurationManager.AppSettings["UserName"];
            lblUserName.Text = "Account";
            lblUserName.Text = lblUserName.Text.First().ToString().ToUpper() + lblUserName.Text.Substring(1);
            UserAccessPermissionvalues.DeviceHeight = this.Height;
            UserAccessPermissionvalues.DeviceWidth = this.Width;

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlMainMenu.Location = new Point((Devicewidth - 554) / 2, 18);

            lblVersion.Text = "V " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //pnlMainMenu.Location = new Point(253, 18);
            //pnlMainMenu.Location = new Point(273, 18);

            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    //client.BackColor = Color.Gray;
                    client.BackColor = Color.FromArgb(234, 234, 234);
                    // 4#
                    break;
                }
            }

            #region Nishanth Task#2
            //btnHome_Click(sender, e);
            //lblSearchDocs_Click(sender, e);
           
            FileCabinetManager objFileCabinetManager = new FileCabinetManager();
            NandanaResult result = objFileCabinetManager.GetFileCabinets();
            if (result.resultDS != null && result.resultDS.Tables[0].Rows.Count > 0)
            {
                btnDashBoard_Click(sender, e);
            }
            else
            {
                btnHome_Click(sender, e);
                lblSearchDocs_Click(sender, e);
            }
            #endregion


            lblLogHistory.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblChangePassword.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //CheckScanDocCountValue();

            Control theMdiClient = this.Controls[this.Controls.Count - 1];

            theMdiClient.Click += theMdiClient_Click;
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
                    if (FormID == 13)
                    {
                        btnHelp.Enabled = false;
                    }
                    else if (FormID == 14)
                    {
                        btnFeeback.Enabled = false;
                    }

                    //ChangeControlStatus(false);
                }
                else
                {
                    if (FormID == 13)
                    {
                        btnHelp.Enabled = true;
                    }
                    else if (FormID == 14)
                    {
                        btnFeeback.Enabled = true;
                    }

                    //ChangeControlStatus(true);
                }
            }
        }

        private void theMdiClient_Click(object sender, EventArgs e)
        {
            // for testing only
            //MessageBox.Show("clicked on the MDI Parent");

            // whatever you want to do on a click on the MdiParent Form

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            FormCollection fc = Application.OpenForms;

            if (fc.Count == 2)
            {
                //iterate through
                pnlHome.Visible = false;
                pnlDashboard.Visible = false;
                pnlImport.Visible = false;
                pnlPermissions.Visible = false;
                pnlReports.Visible = false;

                btnHome.Height = 75;
                btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
                btnDashBoard.Height = 75;
                btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
                btnReports.Height = 75;
                btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
                btnImport.Height = 75;
                btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
                btnPermissions.Height = 75;
                btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;


            }
        }

        public void CheckScanDocCountValue()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("XMLs/Config.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_Config");

            foreach (XmlNode node in nodeList)
            {
                if (node["Config_Name"].InnerText == "ScanRecordCount")
                {
                    if (node["Config_Value"].InnerText == "")
                    {
                        ConfirmLicense obj = new ConfirmLicense();
                        //EnterScanDocCount obj = new EnterScanDocCount();
                        obj.ShowDialog();
                    }
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.Color.FromArgb(68, 68, 68);
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 74;
            btnHome.Width = 110;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome_edit;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;
            
            //pnlHome.Location = new Point((Width - this.ClientSize.Width) / 2, 173);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlHome.Location = new Point((Devicewidth - 1004) / 2, panel1.Height+1);
            //pnlHome.Location = new Point(260, 96);
            //pnlHome.Location = new Point(300, 96);
            
            
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;
            pnlHome.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            lblSearchDocs_Click(sender, e);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 74;
            btnDashBoard.Width = 100;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard_Click;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlDashboard.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlDashboard.Location = new Point((Devicewidth - 1004) / 2, panel1.Height + 1);
            
            pnlHome.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;
            pnlDashboard.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            lblDashboard_Click(sender, e);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 74;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports_Click;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlReports.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlReports.Location = new Point((Devicewidth - 1004) / 2, panel1.Height + 1);
            
            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = true;

            //ChangeLableColorsInAllPanels();

            lblShowDocuments.Location = new Point(18,8);
            lblDocumentCount.Location = new Point(lblShowDocuments.Location.X + lblShowDocuments.Width + 15, 8);
            lblStatusCount.Location = new Point(lblDocumentCount.Location.X + lblDocumentCount.Width + 15, 8);
            lblDocumentReport.Location = new Point(lblStatusCount.Location.X + lblStatusCount.Width + 15, 8);
            

            CloseChangePasswordAndLogHistory();

            lblShowDocuments_Click(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 74;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport_Click;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

           
            //pnlImport.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlImport.Location = new Point((Devicewidth - 1004) / 2, panel1.Height + 1);
            
            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;
            pnlImport.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            lblImport_Click(sender, e);
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 74;
            btnPermissions.Width = 92;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions_Click;
            
            //pnlPermissions.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlPermissions.Location = new Point((Devicewidth - 1004) / 2, panel1.Height + 1);
            
            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlReports.Visible = false;
            pnlPermissions.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            lblNewUser_Click(sender, e);
            //lblUserAccessPermissions_Click(sender, e);
        }

        public void EnableAllMenuItem()
        {
            btnDashBoard.Enabled = false;
            btnReports.Enabled = false;
            btnImport.Enabled = false;
            btnPermissions.Enabled = false;
            lblUserName.Enabled = false;
            btnLogout.Enabled = false;
            btnHelp.Enabled = false;
            btnFeeback.Enabled = false;
            btnHome.Enabled = false;
        }

        public void DisableAllMenuItem()
        {
            btnDashBoard.Enabled = true;
            btnReports.Enabled = true;
            btnImport.Enabled = true;
            btnPermissions.Enabled = true;
            lblUserName.Enabled = true;
            btnLogout.Enabled = true;
            btnHelp.Enabled = true;
            btnFeeback.Enabled = true;
            btnHome.Enabled = true;
        }

        private void lblSearchDocs_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllMDIForms();

            //CloseAllOpenedForms();

            //lblSearchDocs.ForeColor = Color.Teal;
            //lblSearchDocs.Font = new Font(Font, FontStyle.Underline);
            //lblSearchDocs.Font = new System.Drawing.Font(lblSearchDocs.Font.Name, lblSearchDocs.Font.SizeInPoints,FontStyle.Underline);
            //lblSearchDocs.Font.Style = FontStyle.Underline;
            pnlBottom.Visible = true;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Location = new Point(lblSearchDocs.Location.X, lblSearchDocs.Location.Y + 20);
            pnlBottom.Width = lblSearchDocs.Width;
            pnlBottom.BringToFront();
            //pnlBottom.Location = new Point(18, 28);

            SearchString objSearchString = new SearchString();
            objSearchString.MdiParent = this;
            objSearchString.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");  
            ////lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void lblTagSearchDocs_Click(object sender, EventArgs e)
        {
            //to do
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllMDIForms();


            pnlBottom.Visible = true;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Location = new Point(lblTagSearchDocs.Location.X, lblTagSearchDocs.Location.Y + 20);
            pnlBottom.Width = lblTagSearchDocs.Width;
            pnlBottom.BringToFront();

            TagSearch objTagSearch = new TagSearch();
            objTagSearch.MdiParent = this;
            objTagSearch.Show();

        }

        private void lblAutoSuggest_Click(object sender, EventArgs e)
        {
            //to do
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllMDIForms();


            pnlBottom.Visible = true;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Location = new Point(lblAutoSuggest.Location.X, lblAutoSuggest.Location.Y + 20);
            pnlBottom.Width = lblAutoSuggest.Width;
            pnlBottom.BringToFront();

            //Nishanth has renamed AutoSuggest screen and related fiels to AutoSuggest_Original.
            //He copied the SearchString and related files (MY Workspsace) to AutoSuggest.
            //Now I have to get the AutoSuggest Functionality added to the AUtoSuggest Screen which now has only My Workspace code and forms UI.

            //AutoSuggest_Original objAutoSuggest = new AutoSuggest_Original();
            //objAutoSuggest.MdiParent = this;
            //objAutoSuggest.Show();

            AutoSuggest objAutoSuggest = new AutoSuggest();
            objAutoSuggest.MdiParent = this;
            objAutoSuggest.Show();


        }


        private void CloseAllMDIForms()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            //closeWithoutMDIForms();
        }

        private void closeWithoutMDIForms()
        {
            List<Form> fc = new List<Form>();
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name != "Form1" && fm.IsMdiChild != true && fm.IsMdiContainer != true)
                {
                    fc.Add(fm);
                }
            }
            foreach (Form fm in fc)
            {
                fm.Close();
            }
        }

        private void CloseAllActiveForm()
        {
            List<Form> fc = new List<Form>();
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name != "Form1")
                {
                    fc.Add(fm);
                }
            }
            foreach (Form fm in fc)
            {
                fm.Close();
            }
        }

        private void CloseAllOpenedForms()
        {
            List<Form> fc = new List<Form>();
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name != "NewMenu")
                {
                    fc.Add(fm);
                }
            }
            foreach (Form fm in fc)
            {
                fm.Close();
            }
        }

        private void CloseChangePasswordAndLogHistory()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name == "ChangePassword" || form.Name == "Log_History")
                {
                    form.Close();
                }
            }
        }

        public void ChangeLableColorsInAllPanels()
        {
            //if(lblSearchDocs.ForeColor!=Color.Teal)
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblSearchDocs.ForeColor = System.Drawing.Color.FromArgb(68, 68, 68);
            //lblSearch.ForeColor = Color.Gray;
            //lblSearchString.ForeColor = Color.Gray;
            ////lblSearchDocs.ForeColor = Color.Gray;

            //lblDashboard.ForeColor = Color.Gray;
            //lblNew.ForeColor = Color.Gray;
            //lblOpen.ForeColor = Color.Gray;
            //lblUserPermissions.ForeColor = Color.Gray;

            //lblShowDocuments.ForeColor = Color.Gray;
            //lblDocumentCount.ForeColor = Color.Gray;
            //lblDocumentReport.ForeColor = Color.Gray;
            //lblStatusCount.ForeColor = Color.Gray;
            //lblTotalDocument.ForeColor = Color.Gray;

            //lblImport.ForeColor = Color.Gray;

            //lblUserAccessPermissions.ForeColor = Color.Gray;
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblDashboard.ForeColor = Color.Teal;

            pnlDused.Visible = true;
            pnlDused.BackColor = Color.White;
            //pnlDused.BackColor = Color.FromArgb(25, 171, 170);
            pnlDused.Location = new Point(lblDashboard.Location.X, lblDashboard.Location.Y + 20);
            pnlDused.Width = lblDashboard.Width;
            pnlDused.BringToFront();

            CloseAllMDIForms();

            //string FileCabinetName = string.Empty;

            //string dfRoles = "XMLs/FileCabinet.xml";
            //DataSet dsroles = new DataSet();
            //dsroles.ReadXml(dfRoles);

            //DataTable getFolderNames = new DataTable();

            //if (dsroles.Tables[0].Rows.Count > 0)
            //{
            //    DataRow[] drResult = dsroles.Tables[0].Select("FileCabinet_ID = '" + "1" + "'");
            //    if (drResult.Count() != 0)
            //    {
            //        getFolderNames = drResult.CopyToDataTable();
            //    }
            //}

            //foreach (DataRow dr in getFolderNames.Rows)
            //{
            //    FileCabinetName = dr["FileCabinet_Name"].ToString();
            //}

            DashBoardHome objDashboardhome = new DashBoardHome();
            objDashboardhome.MdiParent = this;
            objDashboardhome.Show();

            //SampleWebBrowser obj = new SampleWebBrowser();
            //obj.MdiParent = this;
            //obj.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            ////lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void lblStatusCount_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblStatusCount.ForeColor = Color.Teal;
            //lblShowDocuments.ForeColor = Color.Gray;
            //lblDocumentCount.ForeColor = Color.Gray;
            //lblDocumentReport.ForeColor = Color.Gray;
            //lblTotalDocument.ForeColor = Color.Gray;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblStatusCount.Location.X, lblStatusCount.Location.Y + 20);
            pnlShowUsed.Width = lblStatusCount.Width;
            pnlShowUsed.BringToFront();

            CloseAllMDIForms();

            DocumentStatusReport objDocumentStatusReport = new DocumentStatusReport();
            objDocumentStatusReport.MdiParent = this;
            objDocumentStatusReport.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void lblDocumentReport_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

           // lblDocumentReport.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblDocumentReport.Location.X, lblDocumentReport.Location.Y + 20);
            pnlShowUsed.Width = lblDocumentReport.Width;
            pnlShowUsed.BringToFront();

            CloseAllMDIForms();

            DocumentsReport objDocumentsReport = new DocumentsReport();
            objDocumentsReport.MdiParent = this;
            objDocumentsReport.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            System.Diagnostics.Process.Start(Application.StartupPath + @"\\UserGuidev1.2Final.pdf"); 
        }

        private void lblOpen_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblOpen.ForeColor = Color.Teal;

            pnlDused.Visible = true;
            pnlDused.BackColor = Color.White;
            pnlDused.Location = new Point(lblOpen.Location.X, lblOpen.Location.Y + 20);
            pnlDused.Width = lblOpen.Width;
            pnlDused.BringToFront();

            CloseAllMDIForms();

            OpenFileCabinet objOpenFileCabinet = new OpenFileCabinet();
            objOpenFileCabinet.MdiParent = this;
            //objOpenFileCabinet.ShowDialog();
            objOpenFileCabinet.Show();

            //if (objOpenFileCabinet.FileCabinetID != null)
            //{
            //    lblDashboard.ForeColor = Color.Teal;
            //    lblNew.ForeColor = Color.Gray;
            //    lblOpen.ForeColor = Color.Gray;

            //    DashBoardHome obj = new DashBoardHome();
            //    obj.strRootNodeID = objOpenFileCabinet.FileCabinetID;
            //    obj.strRootNode = objOpenFileCabinet.FileCabinetName;
            //    //this.Hide();
            //    obj.MdiParent = this;
            //    obj.Show();
            //}
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = true;
            pnlLog.Visible = true;
            pnlLog.BringToFront();
            pnlLogout.BringToFront();
            pnlLogout.Location = new Point(pnlLogout.Location.X,83);
            pnlLog.Location = new Point(pnlLog.Location.X, 113);
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllActiveForm();

            Form1 objForm = new Form1();
            objForm.Show();
            this.Hide();
            objForm.lblError.Visible = true;
            objForm.lblError.Text = "You have successfully logged out";
            objForm.lblError.Location = new Point(objForm.ClientSize.Width / 2 - objForm.lblError.Size.Width / 2, 84);

            //Application.Exit();
        }

        private void lblLogHistory_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllMDIForms();

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;               
            pnlImport.Visible = false;
            pnlReports.Visible = false;
            pnlPermissions.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;


            pnlReports.Visible = false;
            Log_History objLogHistory = new Log_History();
            objLogHistory.MdiParent = this;
            objLogHistory.Show();
        }

        private void lblChangePassword_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllMDIForms();

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;


            ChangePassword objChangepassword = new ChangePassword();
            objChangepassword.MdiParent = this;
            objChangepassword.Show();
        }

        private void NewMenu_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;
        }

        private void NewMenu_MouseClick(object sender, MouseEventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;
        }

        private void lblNew_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblNew.ForeColor = Color.Teal;

            pnlDused.Visible = true;
            pnlDused.BackColor = Color.White;
            pnlDused.Location = new Point(lblNew.Location.X, lblNew.Location.Y + 20);
            pnlDused.Width = lblNew.Width;
            pnlDused.BringToFront();

            CloseAllMDIForms();

            NewFileCabinet objNewFileCabinet = new NewFileCabinet();
            objNewFileCabinet.MdiParent = this;
            objNewFileCabinet.Show();

            //if (objNewFileCabinet.FileCabinetID != null)
            //{
            //    lblDashboard.ForeColor = Color.Teal;
            //    lblNew.ForeColor = Color.Gray;
            //    lblOpen.ForeColor = Color.Gray;

            //    DashBoardHome obj = new DashBoardHome();
            //    obj.strRootNodeID = objNewFileCabinet.FileCabinetID;
            //    obj.strRootNode = objNewFileCabinet.FileCabinetName;
            //    //this.Hide();
            //    obj.MdiParent = this;
            //    obj.Show();
            //}

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void lblShowDocuments_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;
            
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblShowDocuments.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblShowDocuments.Location.X, lblShowDocuments.Location.Y + 20);
            pnlShowUsed.Width = lblShowDocuments.Width;
            pnlShowUsed.BringToFront();

            CloseAllMDIForms();

            Documents objDocuments = new Documents();
            objDocuments.MdiParent = this;
            objDocuments.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            ////lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void lblDocumentCount_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblDocumentCount.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblDocumentCount.Location.X, lblDocumentCount.Location.Y + 20);
            pnlShowUsed.Width = lblDocumentCount.Width;
            pnlShowUsed.BringToFront();

            CloseAllMDIForms();

            DocumentsCountReport objDocumentsCountReport = new DocumentsCountReport();
            objDocumentsCountReport.MdiParent = this;
            objDocumentsCountReport.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void lblTotalDocument_Click(object sender, EventArgs e)
        {
            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblTotalDocument.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblTotalDocument.Location.X, lblTotalDocument.Location.Y + 20);
            pnlShowUsed.Width = lblTotalDocument.Width;
            pnlShowUsed.BringToFront();

            CloseAllMDIForms();

            TotalDocumentsReport objTotalDocumentsReport = new TotalDocumentsReport();
            objTotalDocumentsReport.MdiParent = this;
            objTotalDocumentsReport.Show();

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        private void PagerectangleShape_MouseClick(object sender, MouseEventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            FormCollection fc = Application.OpenForms;

            if (fc.Count == 2)
            {
                //iterate through
                pnlHome.Visible = false;
                pnlDashboard.Visible = false;
                pnlImport.Visible = false;
                pnlPermissions.Visible = false;
                pnlReports.Visible = false;

                btnHome.Height = 75;
                btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
                btnDashBoard.Height = 75;
                btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
                btnReports.Height = 75;
                btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
                btnImport.Height = 75;
                btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
                btnPermissions.Height = 75;
                btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;


            }
        }

        private void pnlLog_Paint(object sender, PaintEventArgs e)
        {
            if (pnlLog.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Gray, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              pnlLog.ClientSize.Width - thickness,
                                                              pnlLog.ClientSize.Height - thickness));
                }
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblImport_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = false;
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlImport.Visible = true;
            pnlUserperbottom.Visible = false;
            
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseAllMDIForms();

            //CloseAllOpenedForms();

            //lblImport.ForeColor = Color.Teal;
            //lblSearchDocs.Font = new Font(lblSearchDocs.Font.Name, lblSearchDocs.Font.SizeInPoints, FontStyle.Underline);
            pnlimportbottom.Visible = true;
            pnlimportbottom.BackColor = Color.White;
            pnlimportbottom.Location = new Point(lblImport.Location.X, lblImport.Location.Y + 20);
            pnlimportbottom.Width = lblImport.Width;
            pnlimportbottom.BringToFront();
            //pnlimportbottom.Location = new Point(18, 28);
            //pnlimportbottom.Location = new Point(455, 28);
            
            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            Import objImport = new Import();
            objImport.MdiParent = this;
            objImport.Show();

            //ComingSoon objComingSoon = new ComingSoon();
            //if (this.ActiveMdiChild.Text == "Change Password")
            //{

            //    //ChangePassword obj = new ChangePassword();
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 139);
            //}
            //else if (this.ActiveMdiChild.Text == "Log History")
            //{

            //    //ChangePassword obj = new ChangePassword();
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 139);
            //}
            
            //objComingSoon.ShowDialog();

            

            //if (this.ActiveMdiChild.Text == "SearchString")
            //{
            //    GetSearchDocsMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DashBoardHome")
            //{
            //    GetDashboardHomeMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "NewFileCabinet")
            //{
            //    GetNewCabinetMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "OpenFileCabinet")
            //{
            //    GetOpenCabinetMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "Show Documents")
            //{
            //    GetShowDocumentsMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DocumentsCountReport")
            //{
            //    GetDocumentsCountMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DocumentsReport")
            //{
            //    GetDocumentsReportMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DocumentStatusReport")
            //{
            //    GetDocumentsStatusMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "TotalDocumentsReport")
            //{
            //    GetTotalDocumentsMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "Change Password")
            //{
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);

            //    btnHome.Height = 75;
            //    btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            //    btnDashBoard.Height = 75;
            //    btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            //    btnReports.Height = 75;
            //    btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            //    btnImport.Height = 75;
            //    btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            //    btnPermissions.Height = 75;
            //    btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;
            //}
            //else if (this.ActiveMdiChild.Text == "Log History")
            //{

            //    //ChangePassword obj = new ChangePassword();
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);

            //    btnHome.Height = 75;
            //    btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            //    btnDashBoard.Height = 75;
            //    btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            //    btnReports.Height = 75;
            //    btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            //    btnImport.Height = 75;
            //    btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            //    btnPermissions.Height = 75;
            //    btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;
            //}

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //pnlimportbottom.Visible = false;
        }

        public void GetTotalDocumentsMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 74;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports_Click;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlReports.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlReports.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblTotalDocument.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblTotalDocument.Location.X, lblTotalDocument.Location.Y + 20);
            pnlShowUsed.Width = lblTotalDocument.Width;
            pnlShowUsed.BringToFront();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetDocumentsStatusMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 74;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports_Click;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlReports.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlReports.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblStatusCount.Location.X, lblStatusCount.Location.Y + 20);
            pnlShowUsed.Width = lblStatusCount.Width;
            pnlShowUsed.BringToFront();

            //lblStatusCount.ForeColor = Color.Teal;

            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetDocumentsReportMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 74;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports_Click;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlReports.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlReports.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblDocumentReport.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblDocumentReport.Location.X, lblDocumentReport.Location.Y + 20);
            pnlShowUsed.Width = lblDocumentReport.Width;
            pnlShowUsed.BringToFront();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetDocumentsCountMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 74;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports_Click;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlReports.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlReports.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblDocumentCount.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblDocumentCount.Location.X, lblDocumentCount.Location.Y + 20);
            pnlShowUsed.Width = lblDocumentCount.Width;
            pnlShowUsed.BringToFront();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetShowDocumentsMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 74;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports_Click;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlReports.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlReports.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlDused.Visible = false;
            pnlBottom.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblShowDocuments.ForeColor = Color.Teal;

            pnlShowUsed.Visible = true;
            pnlShowUsed.BackColor = Color.White;
            pnlShowUsed.Location = new Point(lblShowDocuments.Location.X, lblShowDocuments.Location.Y + 20);
            pnlShowUsed.Width = lblShowDocuments.Width;
            pnlShowUsed.BringToFront();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            ////lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetOpenCabinetMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 74;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard_Click;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlDashboard.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlDashboard.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;
            pnlDashboard.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblOpen.ForeColor = Color.Teal;

            pnlDused.Visible = true;
            pnlDused.BackColor = Color.White;
            pnlDused.Location = new Point(lblOpen.Location.X, lblOpen.Location.Y + 20);
            pnlDused.Width = lblOpen.Width;
            pnlDused.BringToFront();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetNewCabinetMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 74;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard_Click;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlDashboard.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlDashboard.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;
            pnlDashboard.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblNew.ForeColor = Color.Teal;

            pnlDused.Visible = true;
            pnlDused.BackColor = Color.White;
            pnlDused.Location = new Point(lblNew.Location.X, lblNew.Location.Y + 20);
            pnlDused.Width = lblNew.Width;
            pnlDused.BringToFront();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetDashboardHomeMDIChild()
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 75;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            btnDashBoard.Height = 74;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard_Click;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlDashboard.Location = new Point(191, 120);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlDashboard.Location = new Point((Devicewidth - 1004) / 2, 94);

            pnlHome.Visible = false;
            pnlDashboard.Visible = true;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            pnlBottom.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            //lblDashboard.ForeColor = Color.Teal;

            pnlDused.Visible = true;
            pnlDused.BackColor = Color.White;
            pnlDused.Location = new Point(lblDashboard.Location.X, lblDashboard.Location.Y + 20);
            pnlDused.Width = lblDashboard.Width;
            pnlDused.BringToFront();

            ////CloseAllMDIForms();
            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }

        public void GetSearchDocsMDIChild()
        {
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlUserperbottom.Visible = false;
            pnlimportbottom.Visible = false;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            btnHome.Height = 74;
            btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome_edit;
            btnDashBoard.Height = 75;
            btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            btnReports.Height = 75;
            btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            btnImport.Height = 75;
            btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            btnPermissions.Height = 75;
            btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;

            //pnlHome.Location = new Point((Width - this.ClientSize.Width) / 2, 173);
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlHome.Location = new Point((Devicewidth - 1004) / 2, 94);
            //pnlHome.Location = new Point(260, 96);
            //pnlHome.Location = new Point(300, 96);

            
            pnlDashboard.Visible = false;
            pnlImport.Visible = false;
            pnlPermissions.Visible = false;
            pnlReports.Visible = false;
            pnlHome.Visible = true;

            //ChangeLableColorsInAllPanels();

            CloseChangePasswordAndLogHistory();

            //lblSearchDocs.ForeColor = Color.Teal;
            //lblSearchDocs.Font = new Font(lblSearchDocs.Font.Name, lblSearchDocs.Font.SizeInPoints, FontStyle.Underline);
            pnlBottom.Visible = true;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Location = new Point(lblSearchDocs.Location.X, lblSearchDocs.Location.Y + 20);
            pnlBottom.Width = lblSearchDocs.Width;
            pnlBottom.BringToFront();


            //lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblSearchString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            ////lblSearchDocs.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblDashboard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblNew.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblOpen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblUserPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblShowDocuments.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblDocumentReport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblStatusCount.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //lblTotalDocument.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
        }
        private void lblUserAccessPermissions_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = false;
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlimportbottom.Visible = false;
            pnlPermissions.Visible = true;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

           

            //CloseAllOpenedForms();

            //lblUserAccessPermissions.ForeColor = Color.Teal;
            //lblSearchDocs.Font = new Font(lblSearchDocs.Font.Name, lblSearchDocs.Font.SizeInPoints, FontStyle.Underline);
            pnlUserperbottom.Visible = true;
            pnlUserperbottom.BackColor = Color.White;
            pnlUserperbottom.Location = new Point(lblUserAccessPermissions.Location.X, lblUserAccessPermissions.Location.Y + 20);
            pnlUserperbottom.Width = lblUserAccessPermissions.Width;
            pnlUserperbottom.BringToFront();
            //pnlUserperbottom.Location = new Point(18, 28);
            //pnlUserperbottom.Location = new Point(533, 28);

            CloseAllMDIForms();

            Useraccesspermissions objUseraccesspermissions = new Useraccesspermissions();
            objUseraccesspermissions.MdiParent = this;
            objUseraccesspermissions.Show();
            //if (this.ActiveMdiChild.Text == "Change Password")
            //{
                
            //    //ChangePassword obj = new ChangePassword();
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 139);
            //}
            //else if (this.ActiveMdiChild.Text == "Log History")
            //{

            //    //ChangePassword obj = new ChangePassword();
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 139);
            //}
            //objUseraccesspermissions.ShowDialog();

            //lblUserAccessPermissions.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            
            
            //if (this.ActiveMdiChild.Text == "SearchString")
            //{
            //    GetSearchDocsMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DashBoardHome")
            //{
            //    GetDashboardHomeMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "NewFileCabinet")
            //{
            //    GetNewCabinetMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "OpenFileCabinet")
            //{
            //    GetOpenCabinetMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "Show Documents")
            //{
            //    GetShowDocumentsMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DocumentsCountReport")
            //{
            //    GetDocumentsCountMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DocumentsReport")
            //{
            //    GetDocumentsReportMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "DocumentStatusReport")
            //{
            //    GetDocumentsStatusMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "TotalDocumentsReport")
            //{
            //    GetTotalDocumentsMDIChild();
            //}
            //else if (this.ActiveMdiChild.Text == "Change Password")
            //{
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);

            //    btnHome.Height = 75;
            //    btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            //    btnDashBoard.Height = 75;
            //    btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            //    btnReports.Height = 75;
            //    btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            //    btnImport.Height = 75;
            //    btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            //    btnPermissions.Height = 75;
            //    btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;
            //}
            //else if (this.ActiveMdiChild.Text == "Log History")
            //{

            //    //ChangePassword obj = new ChangePassword();
            //    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            //    this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);

            //    btnHome.Height = 75;
            //    btnHome.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewHome;
            //    btnDashBoard.Height = 75;
            //    btnDashBoard.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewDashboard;
            //    btnReports.Height = 75;
            //    btnReports.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewReports;
            //    btnImport.Height = 75;
            //    btnImport.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewImport;
            //    btnPermissions.Height = 75;
            //    btnPermissions.BackgroundImage = global::DocSort_CPA.Properties.Resources.NewPermissions;
            //}
            
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximise_Click(object sender, EventArgs e)
        {
            btnMaximise.Visible = false;
            btnMaximize.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(950, 750);
            UserAccessPermissionvalues.NewMenuWidth = 950;
            UserAccessPermissionvalues.NewMenuHeight = 750;
            //this.Size = new Size(1020, 750);
            //this.Left = 100;
            //this.Top = 100;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.ClientSize.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.ClientSize.Height) / 2);
            panel3.Location = new Point(0, this.Height - 39);
            this.HorizontalScroll.Visible = true;
            this.HorizontalScroll.Visible = true;

            pnlMainMenu.Location = new Point(243, 18);
            //this.VerticalScroll.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseApplication objCloseConfirmation = new CloseApplication();
            objCloseConfirmation.ShowDialog();

            if (objCloseConfirmation.DeleteConfirmationRequest == "Yes")
            {
                Application.Exit();
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            btnMaximise.Visible = true;
            btnMaximize.Visible = false;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            UserAccessPermissionvalues.NewMenuWidth = this.Width;
            UserAccessPermissionvalues.NewMenuHeight = this.Height;
            this.Left = 0;
            this.Top = 0;
            this.WindowState = FormWindowState.Normal;
            this.HorizontalScroll.Visible = false;
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            pnlMainMenu.Location = new Point((Devicewidth - 554) / 2, 18);
            if (this.ActiveMdiChild.Text == "Change Password")
            {
                this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);
            }
            else if (this.ActiveMdiChild.Text == "Log History")
            {
                this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);
            }
            else
            {
                this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 139);
            }
            panel3.Location = new Point(0, this.Height-20);
        }

        private void btnFeeback_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            Feedback objFeedback = new Feedback();
            objFeedback.ShowDialog();
        }

       
        #region 'Resize'

        private void NewMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (onBorderRight) { movingRight = true; } else { movingRight = false; }
                if (onBorderLeft) { movingLeft = true; } else { movingLeft = false; }
                if (onBorderTop) { movingTop = true; } else { movingTop = false; }
                if (onBorderBottom) { movingBottom = true; } else { movingBottom = false; }
                if (onCornerTopRight) { movingCornerTopRight = true; } else { movingCornerTopRight = false; }
                if (onCornerTopLeft) { movingCornerTopLeft = true; } else { movingCornerTopLeft = false; }
                if (onCornerBottomRight) { movingCornerBottomRight = true; } else { movingCornerBottomRight = false; }
                if (onCornerBottomLeft) { movingCornerBottomLeft = true; } else { movingCornerBottomLeft = false; }
            }
        }


        private void NewMenu_MouseUp(object sender, MouseEventArgs e)
        {
            stopResizer();
        }

        private void NewMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (onFullScreen | maximized) { return; }

            if (this.Width <= minimumWidth) { this.Width = (minimumWidth + 5); on_MinimumSize = true; }
            if (this.Height <= minimumHeight) { this.Height = (minimumHeight + 5); on_MinimumSize = true; }
            if (on_MinimumSize) { stopResizer(); } else { startResizer(); }


            if ((Cursor.Position.X > ((this.Location.X + this.Width) - borderDiameter))
                & (Cursor.Position.Y > (this.Location.Y + borderSpace))
                & (Cursor.Position.Y < ((this.Location.Y + this.Height) - borderSpace)))
            { this.Cursor = Cursors.SizeWE; onBorderRight = true; }

            else if ((Cursor.Position.X < (this.Location.X + borderDiameter))
                & (Cursor.Position.Y > (this.Location.Y + borderSpace))
                & (Cursor.Position.Y < ((this.Location.Y + this.Height) - borderSpace)))
            { this.Cursor = Cursors.SizeWE; onBorderLeft = true; }

            else if ((Cursor.Position.Y < (this.Location.Y + borderDiameter))
                & (Cursor.Position.X > (this.Location.X + borderSpace))
                & (Cursor.Position.X < ((this.Location.X + this.Width) - borderSpace)))
            { this.Cursor = Cursors.SizeNS; onBorderTop = true; }

            else if ((Cursor.Position.Y > ((this.Location.Y + this.Height) - borderDiameter))
                & (Cursor.Position.X > (this.Location.X + borderSpace))
                & (Cursor.Position.X < ((this.Location.X + this.Width) - borderSpace)))
            { this.Cursor = Cursors.SizeNS; onBorderBottom = true; }

            else if ((Cursor.Position.X == ((this.Location.X + this.Width) - 1))
                & (Cursor.Position.Y == this.Location.Y))
            { this.Cursor = Cursors.SizeNESW; onCornerTopRight = true; }
            else if ((Cursor.Position.X == this.Location.X)
                & (Cursor.Position.Y == this.Location.Y))
            { this.Cursor = Cursors.SizeNWSE; onCornerTopLeft = true; }

            else if ((Cursor.Position.X == ((this.Location.X + this.Width) - 1))
                & (Cursor.Position.Y == ((this.Location.Y + this.Height) - 1)))
            { this.Cursor = Cursors.SizeNWSE; onCornerBottomRight = true; }

            else if ((Cursor.Position.X == this.Location.X)
                & (Cursor.Position.Y == ((this.Location.Y + this.Height) - 1)))
            { this.Cursor = Cursors.SizeNESW; onCornerBottomLeft = true; }

            else
            {
                onBorderRight = false;
                onBorderLeft = false;
                onBorderTop = false;
                onBorderBottom = false;
                onCornerTopRight = false;
                onCornerTopLeft = false;
                onCornerBottomRight = false;
                onCornerBottomLeft = false;
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region 'Drag'

        int posX;
        int posY;
        bool drag;

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Size == new Size(950, 750))
                {
                    btnMaximise.Visible = true;
                    btnMaximize.Visible = false;
                    this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                    this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                    UserAccessPermissionvalues.NewMenuWidth = this.Width;
                    UserAccessPermissionvalues.NewMenuHeight = this.Height;
                    this.Left = 0;
                    this.Top = 0;
                    UserAccessPermissionvalues.NewMenuTop = this.Top;
                    UserAccessPermissionvalues.NewMenuLeft = this.Left;
                    this.WindowState = FormWindowState.Normal;
                    this.HorizontalScroll.Visible = false;
                    int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
                    pnlMainMenu.Location = new Point((Devicewidth - 554) / 2, 18);
                    if (this.ActiveMdiChild.Text == "Change Password")
                    {
                        this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);
                    }
                    else if (this.ActiveMdiChild.Text == "Log History")
                    {
                        this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 104);
                    }
                    else
                    {
                        this.ActiveMdiChild.Location = new Point(((Devicewidth - 3) - this.ActiveMdiChild.ClientSize.Width) / 2, 139);
                    }
                    panel3.Location = new Point(0, this.Height - 20);
                }
                else
                {
                    btnMaximise.Visible = false;
                    btnMaximize.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    this.Size = new Size(950, 750);
                    UserAccessPermissionvalues.NewMenuWidth = 950;
                    UserAccessPermissionvalues.NewMenuHeight = 750;
                    //this.Size = new Size(1020, 750);
                    //this.Left = 100;
                    //this.Top = 100;
                    this.StartPosition = FormStartPosition.CenterScreen;
                    this.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.ClientSize.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.ClientSize.Height) / 2);
                    UserAccessPermissionvalues.NewMenuTop = this.Top;
                    UserAccessPermissionvalues.NewMenuLeft = this.Left;
                    panel3.Location = new Point(0, this.Height - 39);
                    this.HorizontalScroll.Visible = true;

                    pnlMainMenu.Location = new Point(263, 18);
                    //this.VerticalScroll.Visible = true;
                }
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                posX = Cursor.Position.X - this.Left;
                posY = Cursor.Position.Y - this.Top;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = System.Windows.Forms.Cursor.Position.Y - posY;
                this.Left = System.Windows.Forms.Cursor.Position.X - posX;
                UserAccessPermissionvalues.NewMenuTop = this.Top;
                UserAccessPermissionvalues.NewMenuLeft = this.Left;
            }
            this.Cursor = Cursors.Default;
        }

       
        #endregion

        private void lblUserName_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = true;
            pnlLog.Visible = true;
            pnlLog.BringToFront();
            pnlLogout.BringToFront();
            pnlLogout.Location = new Point(pnlLogout.Location.X, 83);
            pnlLog.Location = new Point(pnlLog.Location.X, 113);
        }

        private void btnsignout_Click(object sender, EventArgs e)
        {
            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            CloseApplication objCloseConfirmation = new CloseApplication();
            objCloseConfirmation.ShowDialog();

            if (objCloseConfirmation.DeleteConfirmationRequest == "Yes")
            {
                CloseAllActiveForm();

                Form1 objForm = new Form1();
                objForm.Show();
                this.Hide();
                objForm.lblError.Visible = true;
                objForm.lblError.Text = "You have successfully logged out";
                objForm.lblError.Location = new Point(objForm.ClientSize.Width / 2 - objForm.lblError.Size.Width / 2, 84);
            }
        }

        private void pnlMainMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlLogout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNewUser_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = false;
            pnlDused.Visible = false;
            pnlShowUsed.Visible = false;
            pnlimportbottom.Visible = false;
            pnlPermissions.Visible = true;

            pnlLogout.Visible = false;
            pnlLog.Visible = false;

            pnlUserperbottom.Visible = true;
            pnlUserperbottom.BackColor = Color.White;
            pnlUserperbottom.Location = new Point(lblNewUser.Location.X, lblNewUser.Location.Y + 20);
            pnlUserperbottom.Width = lblNewUser.Width;
            pnlUserperbottom.BringToFront();
            
            CloseAllMDIForms();

            UsersEntry objUsersEntry = new UsersEntry();
            objUsersEntry.MdiParent = this;
            objUsersEntry.Show();
        }
    }
}
