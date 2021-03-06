﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.IO;
using MODI;
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using TallComponents.PDF.Rasterizer;
using TallComponents.PDF.Rasterizer.Configuration;
using System.Threading;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.OleDb;
using System.Security.Cryptography;
using DocSort_CPA.Reports;
using System.Diagnostics;
using Business.Manager;
using Common;

namespace DocSort_CPA.Forms
{
    public partial class TagSearch : Form
    {
        public TagSearch()
        {
            InitializeComponent();
        }

        DataTable Dttemp = new DataTable();

        FileCabinetClass FileCabinetClass = new FileCabinetClass();

        int j = 0;
        private static string m_sDocFile;
        private static string m_sDocFolderFile;
        private static string m_sDocCategoryFolderFile;
        private static string m_sDocUnMatchFile;
        private static string m_sConfigFile;
        private static string m_sLogFile;
        private static string m_sDocUnReadFile;
        private static string m_sImages;

        private void TagSearch_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(1);
            // End

            this.ControlBox = false;
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth - 3) - this.ClientSize.Width) / 2, 139);
            //this.Location = new Point(257, 139);
            //this.Location = new Point(297, 139);

            Dttemp.Columns.Clear();
            Dttemp.Columns.Add("Search", typeof(String));
            //Dttemp.Columns.Add("IncludeAdditional", typeof(String));
            //Dttemp.Columns.Add("LableCategory", typeof(String));
            Dttemp.Columns.Add("ValueCategory", typeof(String));
            Dttemp.Columns.Add("FilesFrom", typeof(String));
            Dttemp.Columns.Add("FilesTo", typeof(String));
            Dttemp.Columns.Add("FilePath", typeof(String));
            Dttemp.Columns.Add("FileName", typeof(String));
            Dttemp.Columns.Add("DocumentID", typeof(String));

            //pnlTagBottomControls.Location = new Point(64, 409);
            pnlTagBottomControls.Location = new Point(64, chkBxAssignCabinet.Location.Y + 26);
            //BindFileCabinets();

            //comboBxFolderType.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            //            txtTagSrchParentFldr.GotFocus += new EventHandler(this.SearchTextGotFocus);
            //            txtTagSrchParentFldr.LostFocus += new EventHandler(this.SearchTextLostFocus);

            //            txtTagSrchSubFldr.GotFocus += new EventHandler(this.CategoryTextGotFocus);
            //            txtTagSrchSubFldr.LostFocus += new EventHandler(this.CategoryTextLostFocus);

            //txtTagSrchParentFldr.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            //txtTagSrchSubFldr.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            lblTagSrchParentFldr.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblSelectCabinet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblTagSrchSubFldr.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblTagOtptLoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblTagInptLoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            lblTagNote.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            chkBxAssignCabinet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            chkBxCreateFldrForUnmatchFiles.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            txtTagInptLoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtTagOtptLoc.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            comboBxAssignCabinet.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");

            btnTagSrc.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            btnTagDest.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");

            //BindcomboBxFolderType();


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

        //public void BindcomboBxFolderType()
        //{
        //    try
        //    {
        //        string RoleID = UserAccessPermissionvalues.RoleID;
        //        string UserID = UserAccessPermissionvalues.UserID;
        //        if (RoleID != null && UserID != null)
        //        {
        //            DashBoardManager objFolderTypeManager = new DashBoardManager();
        //            NandanaResult result = new NandanaResult();
        //            result = objFolderTypeManager.GetFolderTypes();

        //            if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
        //            {

        //                comboBxFolderType.Items.Clear();
        //                comboBxFolderType.DisplayMember = "Folder_Type_Value";
        //                comboBxFolderType.ValueMember = "Folder_Type_ID";
        //                comboBxFolderType.DataSource = GetComboBoxedDataTable(result.resultDS.Tables[0], "Folder_Type_ID", "Folder_Type_Value", "0", "Choose a Folder Type");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error While retriving data from FolderType table");
        //    }

        //}

        private void btnTagSrc_Click(object sender, EventArgs e)
        {
            btnTagSrc.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");

            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Select a folder which has files";
            fd.ShowNewFolderButton = true;
            //fd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            //fd.SelectedPath = System.Configuration.ConfigurationSettings.AppSettings["SourceFolder"];
            //fd.SelectedPath = Application.StartupPath;
            string TestSourceFolder = System.Configuration.ConfigurationSettings.AppSettings["RecentFolder"];
            if (TestSourceFolder != "")
            {
                fd.SelectedPath = TestSourceFolder;
            }
            else
            {
                fd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }


            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtTagInptLoc.Text = fd.SelectedPath;
                Environment.SpecialFolder root = fd.RootFolder;
                System.Configuration.ConfigurationSettings.AppSettings["RecentFolder"] = txtTagInptLoc.Text;
            }
        }

        private void btnTagDest_Click(object sender, EventArgs e)
        {
            btnTagDest.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#19abaa");
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Select a folder to move files";
            fd.ShowNewFolderButton = true;
            //fd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            //fd.SelectedPath = System.Configuration.ConfigurationSettings.AppSettings["DestinationFolder"];
            //fd.SelectedPath = Application.StartupPath;
            string TestSourceFolder = System.Configuration.ConfigurationSettings.AppSettings["RecentFolder"];
            if (TestSourceFolder != "")
            {
                fd.SelectedPath = TestSourceFolder;
            }
            else
            {
                fd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }

            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtTagOtptLoc.Text = fd.SelectedPath;
                Environment.SpecialFolder root = fd.RootFolder;
                System.Configuration.ConfigurationSettings.AppSettings["RecentFolder"] = txtTagOtptLoc.Text.Trim();
            }
        }

        public void SearchTextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Type one or more tag keywords separated by commas(,)")
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            }
        }

        public void SearchTextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Type one or more tag keywords separated by commas(,)";
                tb.ForeColor = Color.Gray;

            }
        }

        public void CategoryTextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == "Type one or more tag keywords separated by commas(,)")
            {
                tb.Text = "";
                tb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            }
        }

        public void CategoryTextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == "")
            {
                tb.Text = "Type one or more tag keywords separated by commas(,)";
                tb.ForeColor = Color.Gray;
            }
        }

        BackgroundWorker worker;

        TallComponents.PDF.Rasterizer.Document document = null;
        bool IsUnMatchedChecked = true;
        int FileCount = 0;
        int UnMatchFileCount = 0;
        int UnReadFileCount = 0;
        string SourceFolder;
        string DestinationFolder;
        //string SearchValue;
        string CategoryValue;
        //string CategoryName;
        //string CategoryID;
        //string DocumentErrorFolder = System.Configuration.ConfigurationSettings.AppSettings["DocumentationError"];

        bool cancel = false;
        int ScannedReadCountConfigValue = 0;
        int LockDocCountConfigValue = 0;
        int IsExpiredConfigValue = 0;
        int TotalGivenDocCount = 0;

        string[] SearchValues;
        string[] CategoryValues;

        //private void btnTagAdd_Click(object sender, EventArgs e)
        //{
        //    bool status = true;
        //    if (comboBxFolderType.Text == "Choose a Folder Type" || comboBxFolderType.Text.Length == 0 || string.IsNullOrEmpty(txtTag.Text) /*|| string.IsNullOrEmpty(txtTagFormat.Text)*/)
        //    {
        //        pnlTagError.Visible = true;
        //        pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 14);
        //        pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
        //        if (comboBxFolderType.Text == "Choose a Folder Type" || comboBxFolderType.Text.Length == 0) lblTagError.Text = "Please Select the Folder Type";
        //        else if (string.IsNullOrEmpty(txtTag.Text)) lblTagError.Text = "Please Enter a Search Tag";
        //        else if (string.IsNullOrEmpty(txtTagFormat.Text)) lblTagError.Text = "Please Enter the Search Tag Format";
        //        //lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
        //        status = false;
        //        comboBxFolderType.Focus();
        //        return;
        //    }
        //    if (!status)
        //    {
        //        MessageBox.Show("Please Enter required data");
        //    }
        //    else
        //    {
        //        if (comboBxFolderType.Text == "Parent_Folder")
        //        {
        //            //txtTagSrchParentFldr.Text = string.IsNullOrEmpty(txtTagSrchParentFldr.Text) ? txtTag.Text + ":" + txtTagFormat.Text : txtTagSrchParentFldr.Text + ", " + txtTag.Text + ":" + txtTagFormat.Text;
        //            txtTagSrchParentFldr.Text = string.IsNullOrEmpty(txtTagSrchParentFldr.Text) ? txtTag.Text: txtTagSrchParentFldr.Text + ", " + txtTag.Text;
        //            txtTag.Clear();
        //            txtTagFormat.Clear();
        //        }
        //        else if (comboBxFolderType.Text == "Sub_Folder")
        //        {
        //            //txtTagSrchSubFldr.Text = string.IsNullOrEmpty(txtTagSrchSubFldr.Text) ? txtTag.Text + ":" + txtTagFormat.Text : txtTagSrchSubFldr.Text + ", " + txtTag.Text + ":" + txtTagFormat.Text;
        //            txtTagSrchSubFldr.Text = string.IsNullOrEmpty(txtTagSrchSubFldr.Text) ? txtTag.Text : txtTagSrchSubFldr.Text + ", " + txtTag.Text;
        //            txtTag.Clear();
        //            txtTagFormat.Clear();
        //        }

        //        //FileCabinetID = comboBxFolderType.SelectedValue.ToString();
        //        //FileCabinetName = comboBxFolderType.Text.ToUpper();

        //        //NewMenu objNewMenu = new NewMenu();

        //        //DashBoardHome obj = new DashBoardHome();
        //        //obj.strRootNodeID = FileCabinetID;
        //        //obj.strRootNode = FileCabinetName;
        //        //obj.MdiParent = (NewMenu)this.MdiParent;
        //        //obj.Show();
        //    }
        //}


        private void btnTagStart_Click(object sender, EventArgs e)
        {
            j = 0;
            FileCount = 0;
            UnMatchFileCount = 0;
            UnReadFileCount = 0;

            cancel = false;

            bool status = true;
            m_sDocFile = null;
            m_sDocFolderFile = null;
            m_sDocUnMatchFile = null;
            m_sDocUnReadFile = null;
            m_sImages = null;

            try
            {
                if (txtTagSrchParentFldr.Text == String.Empty || txtTagSrchParentFldr.Text == "Type one or more tag keywords separated by commas(,)")
                {
                    pnlTagError.Visible = true;
                    pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                    lblTagError.Text = "Enter at least one Keyword";
                    lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                    status = false;
                    txtTagSrchParentFldr.Focus();
                    return;
                }
                if (txtTagInptLoc.Text == String.Empty)
                {
                    pnlTagError.Visible = true;
                    pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                    lblTagError.Text = "Input Location is required";
                    lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                    status = false;
                    txtTagInptLoc.Focus();
                    return;
                }
                if (txtTagOtptLoc.Text == String.Empty)
                {
                    pnlTagError.Visible = true;
                    pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                    lblTagError.Text = "Output Location is required";
                    lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                    status = false;
                    txtTagOtptLoc.Focus();
                    return;
                }
                if (chkBxAssignCabinet.Checked)
                {
                    if (comboBxAssignCabinet.Text == "Choose a Cabinet" || comboBxAssignCabinet.Text.Length == 0)
                    {
                        pnlTagError.Visible = true;
                        pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                        pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                        lblTagError.Text = "Select a Cabinet";
                        lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                        status = false;
                        comboBxAssignCabinet.Focus();
                        return;
                    }
                }

                if (!Directory.Exists(txtTagInptLoc.Text.Trim()))
                {
                    pnlTagError.Visible = true;
                    pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                    lblTagError.Text = "Input Location doesn't exist";
                    lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                    status = false;
                    txtTagInptLoc.Focus();
                    return;
                }
                if (!Directory.Exists(txtTagOtptLoc.Text.Trim()))
                {
                    pnlTagError.Visible = true;
                    pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                    lblTagError.Text = "Output Location doesn't exist";
                    lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                    status = false;
                    txtTagOtptLoc.Focus();
                    return;
                }
                if (Directory.GetFiles(txtTagInptLoc.Text.Trim(), "*.*", SearchOption.TopDirectoryOnly).Length == 0)
                {
                    pnlTagError.Visible = true;
                    pnlTagError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                    pnlTagError.Location = new Point((this.Width - pnlTagError.ClientSize.Width) / 2, 12);
                    lblTagError.Text = "No documents found in the Input Location";
                    lblTagError.Location = new Point((pnlTagError.Width - lblTagError.ClientSize.Width) / 2, (pnlTagError.Height - lblTagError.ClientSize.Height) / 2);
                    status = false;
                    txtTagInptLoc.Focus();
                    return;
                }
                if (!status)
                {
                    MessageBox.Show("Please Enter required data");
                }
                else
                {
                    NewMenu mf = (NewMenu)this.MdiParent;
                    mf.EnableAllMenuItem();

                    txtTagSrchParentFldr.ReadOnly = true;
                    txtTagSrchSubFldr.ReadOnly = true;
                    txtTagInptLoc.ReadOnly = true;
                    txtTagOtptLoc.ReadOnly = true;
                    btnTagSrc.Enabled = false;
                    btnTagDest.Enabled = false;
                    chkBxAssignCabinet.Enabled = false;
                    comboBxAssignCabinet.Enabled = false;
                    lnkTagSelectCabinet.Enabled = false;
                    chkBxCreateFldrForUnmatchFiles.Enabled = false;

                    btnTagStart.Visible = false;
                    btnTagClear.Enabled = false;
                    btnTagCancel.Visible = true;
                    btnTagCancel.Location = new Point(254, 96);
                    imgTagProcessing.Visible = true;
                    imgTagProcessing.BringToFront();

                    Dttemp.Clear();
                    progressBarTag.Visible = true;
                    lblTagFileName.Visible = true;
                    lblTagSts.Visible = true;
                    lblTagRemainingTime.Visible = true;
                    lblTagSts.Location = new Point(257, 32);
                    lblTagSts.Text = "";

                    //CategoryName = "ScannedDoc";
                    //CategoryID = "1";

                    SourceFolder = txtTagInptLoc.Text.Trim();
                    DestinationFolder = txtTagOtptLoc.Text.Trim();
                    //SearchValue = txtTagSrchParentFldr.Text;
                    //SearchValue = Regex.Replace(SearchValue, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                    SearchValues = Regex.Replace(txtTagSrchParentFldr.Text, @"[\/:*?<>|'\r\n]+", "").Split(',');



                    if (txtTagSrchSubFldr.Text != "Type one or more tag keywords separated by commas(,)")
                    {
                        CategoryValue = txtTagSrchSubFldr.Text.ToUpper().Trim();

                        string GivenTotalYears = GetSubfolderStrings();

                        CategoryValues = GivenTotalYears.Split(',');
                    }
                    else
                    {
                        CategoryValue = "";
                    }
                    if (chkBxAssignCabinet.Checked)
                    {
                        FileCabinetID = comboBxAssignCabinet.SelectedValue.ToString();
                        FileCabinetName = comboBxAssignCabinet.Text.ToUpper();
                    }
                    else
                    {
                        FileCabinetID = "1";
                    }

                    if (chkBxAssignCabinet.Checked)
                    {
                        FileCabinetClass.SelectedFileCabinetID = FileCabinetID;
                        FileCabinetName = FileCabinetClass.GetRootFileCabinetName();
                    }
                    else
                    {
                        FileCabinetClass.SelectedFileCabinetID = "";
                        FileCabinetName = FileCabinetClass.GetRootFileCabinetName();
                    }

                    if (chkBxCreateFldrForUnmatchFiles.Checked)
                    {
                        IsUnMatchedChecked = true;
                    }
                    else
                    {
                        IsUnMatchedChecked = false;
                    }


                    int filecount = Directory.GetFiles(SourceFolder, "*.*", SearchOption.TopDirectoryOnly).Length;


                    worker = new BackgroundWorker();
                    worker.WorkerSupportsCancellation = true;
                    worker.WorkerReportsProgress = true;
                    worker.ProgressChanged += (se, eventArgs) =>
                    {
                        this.progressBarTag.Maximum = filecount;
                        this.progressBarTag.Minimum = 0;
                        this.progressBarTag.Value = eventArgs.ProgressPercentage;
                        lblTagSts.Text = eventArgs.UserState as String;
                        //lblTagFileName.Text = String.Format("Progress: {0} ", eventArgs.ProgressPercentage);
                    };


                    worker.DoWork += (se, eventArgs) =>
                    {
                        int progress = 0;
                        ((BackgroundWorker)se).ReportProgress(progress, "Initializing the files...");

                        string[] path = Directory.GetFiles(SourceFolder);
                        ScannedReadCountConfigValue = 0;
                        LockDocCountConfigValue = 0;
                        IsExpiredConfigValue = 0;
                        TotalGivenDocCount = 0;
                        GetScannedConfigvalues(out ScannedReadCountConfigValue, out LockDocCountConfigValue, out IsExpiredConfigValue);

                        // Getting total given scan count from config to show alert

                        TotalGivenDocCount = ScannedReadCountConfigValue + LockDocCountConfigValue;

                        if (IsExpiredConfigValue == 1)
                        {
                            ConfirmLicense objConfirmLicense = new ConfirmLicense();
                            objConfirmLicense.IsExpired = IsExpiredConfigValue.ToString();
                            objConfirmLicense.ShowDialog();
                            if (objConfirmLicense.ConfigID != null)
                            {

                                /// verify if already Licensekey used or not
                                objConfirmLicense.Hide();
                                Dttemp.Clear();

                                ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.ScannedReadCountConfigValue).ToString());
                                LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.LockDocCountConfigValue).ToString());
                                IsExpiredConfigValue = 0;
                                UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                            }
                        }
                        if (ScannedReadCountConfigValue <= 0)
                        {

                            //IsExpiredConfigValue = -1;
                            //UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                            CreateFolders();
                            IsExpiredConfigValue = 1;
                            UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                            ConfirmLicense objConfirmLicense = new ConfirmLicense();
                            objConfirmLicense.IsExpired = IsExpiredConfigValue.ToString();
                            objConfirmLicense.ShowDialog();
                            if (objConfirmLicense.ConfigID != null)
                            {
                                //if Licensed Key
                                objConfirmLicense.Hide();
                                Dttemp.Clear();

                                ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.ScannedReadCountConfigValue).ToString());
                                LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.LockDocCountConfigValue).ToString());
                                IsExpiredConfigValue = 0;
                                UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                            }

                            for (int i = j; i < filecount; i++)
                            {
                                if (Dttemp.Rows.Count == 50)
                                {
                                    CreateFolders();
                                    UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                                    Dttemp.Clear();
                                }
                                if (ScannedReadCountConfigValue > 0)
                                {
                                    if (ScannedReadCountConfigValue == ((TotalGivenDocCount * 10) / 100) || ScannedReadCountConfigValue == ((TotalGivenDocCount * 20) / 100) || ScannedReadCountConfigValue == ((TotalGivenDocCount * 30) / 100))
                                    {
                                        AlertPage objAlertpage = new AlertPage();
                                        objAlertpage.ScannedCount = Convert.ToString(ScannedReadCountConfigValue);
                                        objAlertpage.ShowDialog();

                                    }
                                    ScannedReadCountConfigValue = ScannedReadCountConfigValue - 1;
                                    LockDocCountConfigValue = LockDocCountConfigValue + 1;
                                    Stopwatch sw = new Stopwatch();
                                    TimeSpan time = new TimeSpan();
                                    sw.Start(); // To initialize
                                    MoveMyFiles(path[i]);
                                    j = getProgressValue();
                                    int timecount = filecount - j;
                                    // Report progress.
                                    string progressStatus = "Processing " + j + "/" + filecount + "";
                                    sw.Stop();
                                    int secs = sw.Elapsed.Seconds * timecount;
                                    time = TimeSpan.FromSeconds(secs);
                                    //string progressStatus = "Reading Files and File Count is (" + j + ")";
                                    ((BackgroundWorker)se).ReportProgress(j, progressStatus);
                                    UpdateStatus("" + System.IO.Path.GetFileName(path[i]) + "", time);

                                    if (cancel == true)
                                    {
                                        break;
                                    }
                                }
                                else
                                {

                                    CreateFolders();
                                    IsExpiredConfigValue = 1;
                                    UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                                    ConfirmLicense objConfirmLicense1 = new ConfirmLicense();
                                    objConfirmLicense1.IsExpired = IsExpiredConfigValue.ToString();
                                    objConfirmLicense1.ShowDialog();
                                    if (objConfirmLicense1.ConfigID != null)
                                    {
                                        //if Licensed Key
                                        objConfirmLicense1.Hide();
                                        Dttemp.Clear();

                                        ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense1.ScannedReadCountConfigValue).ToString());
                                        LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense1.LockDocCountConfigValue).ToString());
                                        IsExpiredConfigValue = 0;
                                        UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                                        Stopwatch sw = new Stopwatch();
                                        TimeSpan time = new TimeSpan();
                                        sw.Start(); // To initialize
                                        MoveMyFiles(path[i]);
                                        int timecount = filecount - j;
                                        j = getProgressValue();
                                        // Report progress.
                                        string progressStatus = "Processing " + j + "/" + filecount + "";
                                        sw.Stop();
                                        int secs = sw.Elapsed.Seconds * timecount;
                                        time = TimeSpan.FromSeconds(secs);
                                        //string progressStatus = "Reading Files and File Count is (" + j + ")";
                                        ((BackgroundWorker)se).ReportProgress(j, progressStatus);
                                        UpdateStatus("" + System.IO.Path.GetFileName(path[i]) + "", time);

                                        if (cancel == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Process that takes a long time
                            //Formula to calculate Progress Percentage 
                            //This is how I calculated for my program. Divide 100 by number of loops you have
                            for (int i = j; i < filecount; i++)
                            {
                                if (Dttemp.Rows.Count == 50)
                                {
                                    CreateFolders();
                                    UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                                    Dttemp.Clear();
                                }
                                if (ScannedReadCountConfigValue > 0)
                                {
                                    if (ScannedReadCountConfigValue == ((TotalGivenDocCount * 10) / 100) || ScannedReadCountConfigValue == ((TotalGivenDocCount * 20) / 100) || ScannedReadCountConfigValue == ((TotalGivenDocCount * 30) / 100))
                                    {
                                        AlertPage objAlertpage = new AlertPage();
                                        objAlertpage.ScannedCount = Convert.ToString(ScannedReadCountConfigValue);
                                        objAlertpage.ShowDialog();

                                    }
                                    ScannedReadCountConfigValue = ScannedReadCountConfigValue - 1;
                                    LockDocCountConfigValue = LockDocCountConfigValue + 1;
                                    Stopwatch sw = new Stopwatch();
                                    TimeSpan time = new TimeSpan();
                                    sw.Start(); // To initialize
                                    MoveMyFiles(path[i]);
                                    j = getProgressValue();
                                    int timecount = filecount - j;
                                    // Report progress.
                                    string progressStatus = "Processing " + j + "/" + filecount + "";
                                    sw.Stop();
                                    int secs = sw.Elapsed.Seconds * timecount;
                                    time = TimeSpan.FromSeconds(secs);
                                    //string progressStatus = "Reading Files and File Count is (" + j + ")";
                                    ((BackgroundWorker)se).ReportProgress(j, progressStatus);
                                    UpdateStatus("" + System.IO.Path.GetFileName(path[i]) + "", time);

                                    if (cancel == true)
                                    {
                                        break;
                                    }
                                }
                                else
                                {

                                    CreateFolders();
                                    IsExpiredConfigValue = 1;
                                    UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                                    ConfirmLicense objConfirmLicense = new ConfirmLicense();
                                    objConfirmLicense.IsExpired = IsExpiredConfigValue.ToString();
                                    objConfirmLicense.ShowDialog();
                                    if (objConfirmLicense.ConfigID != null)
                                    {
                                        //if Licensed Key
                                        objConfirmLicense.Hide();
                                        Dttemp.Clear();

                                        ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.ScannedReadCountConfigValue).ToString());
                                        LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.LockDocCountConfigValue).ToString());
                                        IsExpiredConfigValue = 0;
                                        UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                                        Stopwatch sw = new Stopwatch();
                                        TimeSpan time = new TimeSpan();
                                        sw.Start(); // To initialize
                                        MoveMyFiles(path[i]);
                                        int timecount = filecount - j;
                                        j = getProgressValue();
                                        // Report progress.
                                        string progressStatus = "Processing " + j + "/" + filecount + "";
                                        sw.Stop();
                                        int secs = sw.Elapsed.Seconds * timecount;
                                        time = TimeSpan.FromSeconds(secs);
                                        //string progressStatus = "Reading Files and File Count is (" + j + ")";
                                        ((BackgroundWorker)se).ReportProgress(j, progressStatus);
                                        UpdateStatus("" + System.IO.Path.GetFileName(path[i]) + "", time);

                                        if (cancel == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }


                        CreateFolders();
                        UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                        AppendStringWithText();
                        GetFileCount();
                        //Report back to the UI

                    };
                    worker.RunWorkerCompleted += (se, eventArgs) =>
                    {
                        //Display smth or update status when progress is completed
                        lblTagSts.Location = new Point(368, 32);
                        lblTagSts.Text = "Your Process has been completed";
                        btnTagStart.Location = new Point(254, 55);
                        lblTagFileName.Visible = false;
                        progressBarTag.Visible = false;
                        lblTagRemainingTime.Visible = false;
                        //btnBack.Enabled = true;
                        //btnFinish.Enabled = true;


                        mf.DisableAllMenuItem();

                        txtTagSrchParentFldr.ReadOnly = false;
                        txtTagSrchSubFldr.ReadOnly = false;
                        txtTagInptLoc.ReadOnly = false;
                        txtTagOtptLoc.ReadOnly = false;
                        btnTagSrc.Enabled = true;
                        btnTagDest.Enabled = true;
                        chkBxAssignCabinet.Enabled = true;
                        comboBxAssignCabinet.Enabled = true;
                        lnkTagSelectCabinet.Enabled = true;
                        chkBxCreateFldrForUnmatchFiles.Enabled = true;
                    };

                    worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetScannedConfigvalues(out  int ScannedReadCountConfigValue, out int LockDocCountConfigValue, out int IsExpiredConfigValue)
        {
            ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
            NandanaResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
            ScannedReadCountConfigValue = 0;
            LockDocCountConfigValue = 0;
            IsExpiredConfigValue = 0;
            if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                {
                    switch (Convert.ToString(dr["Config_Name"].ToString()).ToUpper())
                    {

                        case "SCANRECORDCOUNT":
                            ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(dr["Config_Value"].ToString()));
                            break;
                        case "LOCKDOCCOUNT":
                            LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(dr["Config_Value"].ToString()));
                            break;
                        case "ISEXPIRED":
                            IsExpiredConfigValue = Convert.ToInt32(dr["Config_Value"].ToString());
                            break;

                    }
                }
            }
        }
        private void UpdateScannedConfigValues(int ScannedReadCountConfigValue, int LockDocCountConfigValue, int IsExpiredConfigValue)
        {
            ConfirmLicenseManager objConfirmLicenseManager = new ConfirmLicenseManager();
            NandanaResult getAllConfigValues = objConfirmLicenseManager.GetAllConfigValues();
            if (getAllConfigValues.resultDS != null && getAllConfigValues.resultDS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in getAllConfigValues.resultDS.Tables[0].Rows)
                {
                    switch (Convert.ToString(dr["Config_Name"].ToString()).ToUpper())
                    {

                        case "SCANRECORDCOUNT":
                            NandanaResult updateScannedRecordCount = objConfirmLicenseManager.UpdateConfigValues("3", this.Encrypt(ScannedReadCountConfigValue.ToString()));
                            //node["Config_Value"].InnerText = this.Encrypt(ScannedReadCountConfigValue.ToString());
                            break;

                        case "LOCKDOCCOUNT":
                            NandanaResult updateLocdocCount = objConfirmLicenseManager.UpdateConfigValues("4", this.Encrypt(LockDocCountConfigValue.ToString()));
                            //node["Config_Value"].InnerText = this.Encrypt(LockDocCountConfigValue.ToString());
                            break;

                        case "ISEXPIRED":
                            NandanaResult updateIsexpired = objConfirmLicenseManager.UpdateConfigValues("1", IsExpiredConfigValue.ToString());
                            //node["Config_Value"].InnerText = IsExpiredConfigValue.ToString();
                            break;

                    }
                }
            }
        }

        string FileCabinetName = string.Empty;
        public string FileCabinetID = string.Empty;

        private void UpdateKeyWordsXML(string keyWord, string subSection, string startWith, string endWith)
        {
            // Checking if same kwyword is exists or not
            string AssignKeywordID = string.Empty;
            MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
            NandanaResult GetKeywordDetails = objMoveMyFilesManager.GetKeywordDetails();
            DataTable getKeyword = new DataTable();
            if (GetKeywordDetails.resultDS != null && GetKeywordDetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow[] drResult = GetKeywordDetails.resultDS.Tables[0].Select("Keyword = '" + keyWord + "'" + "and" + " SubSection = '" + subSection + "'");
                if (drResult.Count() != 0)
                {
                    getKeyword = drResult.CopyToDataTable();
                }
            }
            if (getKeyword != null && getKeyword.Rows.Count > 0)
            {
                DataRow dr = getKeyword.Rows[0];
                AssignKeywordID = dr["Keyword_ID"].ToString();
                KeywordID = AssignKeywordID;
            }
            //End

            // If not exists then insert details into keyword table

            if (AssignKeywordID == string.Empty)
            {
                NandanaResult insertintokeywords = objMoveMyFilesManager.InsertKeywordDetails(keyWord, subSection, startWith, endWith);
                if (insertintokeywords.resultDS != null && insertintokeywords.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = insertintokeywords.resultDS.Tables[0].Rows[0];
                    KeywordID = dr["KeywordId"].ToString();
                }
            }

            // End
        }

        private void updateScannedDocXML(string keywordID, string documentID, string documentPath, string Status)
        {
            // insert into tbl_scanneddocumentresults table

            MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
            NandanaResult insertintoscannedresults = objMoveMyFilesManager.InsertScannedDocumentResults(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), keywordID.Trim(), documentID, documentPath, Status);

            // End
        }

        public void CreateFolders()
        {
            DataTable dtFinal = new DataTable();
            if (Dttemp != null && Dttemp.Rows.Count > 0)
            {
                dtFinal = Dttemp;
            }
            if (dtFinal.Rows.Count > 0)
            {
                //MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                int count = dtFinal.Rows.Count;
                //if (chkBxAssignCabinet.Checked)
                //{
                //    FileCabinetClass.SelectedFileCabinetID = FileCabinetID;
                //    FileCabinetName = FileCabinetClass.GetRootFileCabinetName();
                //}
                //else
                //{
                //    FileCabinetClass.SelectedFileCabinetID = "";
                //    FileCabinetName = FileCabinetClass.GetRootFileCabinetName();
                //}
                if (FileCabinetName != "")
                {
                    for (int i = 0; i < count; i++)
                    {
                        string Search = dtFinal.Rows[i]["Search"].ToString();
                        string FilePath = dtFinal.Rows[i]["FilePath"].ToString();
                        string FileName = dtFinal.Rows[i]["FileName"].ToString();

                        if (dtFinal.Rows[i]["Search"].ToString() != "")
                        {
                            DataRow[] drResult = dtFinal.Select("Search like '" + Regex.Replace(dtFinal.Rows[i]["Search"].ToString(), @"[_[]+", "") + "'");

                            if (drResult.Count() > 1)
                            {
                                DataTable dtFinal1 = drResult.CopyToDataTable();

                                UpdateKeyWordsXML(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), "", "");

                                m_sDocFolderFile = null;
                                if (m_sDocFolderFile == null)
                                {
                                    m_sDocFolderFile = DestinationFolder + "\\" + dtFinal.Rows[i]["Search"].ToString();
                                    if (!System.IO.Directory.Exists(m_sDocFolderFile))
                                        System.IO.Directory.CreateDirectory(m_sDocFolderFile);
                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    m_sDocCategoryFolderFile = null;
                                    if (m_sDocCategoryFolderFile == null)
                                    {
                                        m_sDocCategoryFolderFile = m_sDocFolderFile + "\\" + dtFinal.Rows[i]["ValueCategory"].ToString();
                                        if (!System.IO.Directory.Exists(m_sDocCategoryFolderFile))
                                            System.IO.Directory.CreateDirectory(m_sDocCategoryFolderFile);
                                    }

                                    //System.IO.File.Move(path, m_sDocFile + "\\" + FileName);
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                    // Saving in FileCabinet
                                    //FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }
                                else
                                {
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                    // Saving in FileCabinet
                                    //FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }

                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");


                                    //* End  *//

                                    //NandanaResult objinsertscanneddocumentresults = objMoveFilesManager.InsertScannedDocumentResultsDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "True");
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");

                                }
                            }
                            else
                            {
                                UpdateKeyWordsXML(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), "", "");

                                m_sDocFolderFile = null;
                                if (m_sDocFolderFile == null)
                                {
                                    m_sDocFolderFile = DestinationFolder + "\\" + dtFinal.Rows[i]["Search"].ToString().Trim();
                                    if (!System.IO.Directory.Exists(m_sDocFolderFile))
                                        System.IO.Directory.CreateDirectory(m_sDocFolderFile);
                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    m_sDocCategoryFolderFile = null;
                                    if (m_sDocCategoryFolderFile == null)
                                    {
                                        m_sDocCategoryFolderFile = m_sDocFolderFile + "\\" + dtFinal.Rows[i]["ValueCategory"].ToString();
                                        if (!System.IO.Directory.Exists(m_sDocCategoryFolderFile))
                                            System.IO.Directory.CreateDirectory(m_sDocCategoryFolderFile);
                                    }

                                    //System.IO.File.Move(path, m_sDocFile + "\\" + FileName);
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                    // Saving in FileCabinet
                                    //FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }
                                else
                                {
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                    // Saving in FileCabinet
                                    //FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");


                                    //* End  *//

                                    //NandanaResult objinsertscanneddocumentresults = objMoveFilesManager.InsertScannedDocumentResultsDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "True");
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");

                                }

                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        string Search = dtFinal.Rows[i]["Search"].ToString();
                        string FilePath = dtFinal.Rows[i]["FilePath"].ToString();
                        string FileName = dtFinal.Rows[i]["FileName"].ToString();

                        if (dtFinal.Rows[i]["Search"].ToString() != "")
                        {
                            DataRow[] drResult = dtFinal.Select("Search like '" + Regex.Replace(dtFinal.Rows[i]["Search"].ToString(), @"[_[]+", "") + "'");

                            if (drResult.Count() > 1)
                            {
                                DataTable dtFinal1 = drResult.CopyToDataTable();

                                UpdateKeyWordsXML(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), "", "");


                                m_sDocFolderFile = null;
                                if (m_sDocFolderFile == null)
                                {
                                    m_sDocFolderFile = DestinationFolder + "\\" + dtFinal.Rows[i]["Search"].ToString();
                                    if (!System.IO.Directory.Exists(m_sDocFolderFile))
                                        System.IO.Directory.CreateDirectory(m_sDocFolderFile);
                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    m_sDocCategoryFolderFile = null;
                                    if (m_sDocCategoryFolderFile == null)
                                    {
                                        m_sDocCategoryFolderFile = m_sDocFolderFile + "\\" + dtFinal.Rows[i]["ValueCategory"].ToString();
                                        if (!System.IO.Directory.Exists(m_sDocCategoryFolderFile))
                                            System.IO.Directory.CreateDirectory(m_sDocCategoryFolderFile);
                                    }

                                    //System.IO.File.Move(path, m_sDocFile + "\\" + FileName);
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                }
                                else
                                {
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                }

                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");
                                    //Create an xml document
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID, dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");
                                }

                            }
                            else
                            {
                                UpdateKeyWordsXML(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), "", "");

                                m_sDocFolderFile = null;
                                if (m_sDocFolderFile == null)
                                {
                                    m_sDocFolderFile = DestinationFolder + "\\" + dtFinal.Rows[i]["Search"].ToString().Trim();
                                    if (!System.IO.Directory.Exists(m_sDocFolderFile))
                                        System.IO.Directory.CreateDirectory(m_sDocFolderFile);
                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    m_sDocCategoryFolderFile = null;
                                    if (m_sDocCategoryFolderFile == null)
                                    {
                                        m_sDocCategoryFolderFile = m_sDocFolderFile + "\\" + dtFinal.Rows[i]["ValueCategory"].ToString();
                                        if (!System.IO.Directory.Exists(m_sDocCategoryFolderFile))
                                            System.IO.Directory.CreateDirectory(m_sDocCategoryFolderFile);
                                    }

                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                }
                                else
                                {
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");
                                    //Create an xml document
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID, dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "Matched");
                                }
                            }
                        }
                    }
                }
            }
        }

        public void StoreFilesInUnMatchedFolderofFileCabinet(string FilePath, string FileName)
        {
            FileCabinetClass.SelectedFileCabinetID = FileCabinetID;
            FileCabinetClass.UnMatchedDocumentsInFileCabinet(FilePath, FileName);

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

        string KeywordID = string.Empty;
        string DocumentID = string.Empty;

        MODI.Document modiDoc = null;
        MODI.MiDocSearch modiSearch = null;
        MODI.IMiSelectableItem modiTextSel = null;
        MODI.MiSelectRects modiSelectRects = null;
        MODI.MiSelectRect modiSelectRect = null;
        MODI.MiRects modiRects = null;
        int intSelInfoTop;
        int intSelInfoBottom;
        int intSelInfoLeft;
        int intSelInfoRight;

        int Searchcount = 0;
        int compareposition = 0;
        string compareTagSearchvalue = string.Empty;

        private void MoveMyFiles(string path)
        {
            string FileName = System.IO.Path.GetFileName(path);


            #region Insert documents into tbl_documentslist table

            MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
            NandanaResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), FileName.Trim(), "Automated");
            if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                DocumentID = dr["DocumentId"].ToString();
            }

            #endregion


            string value = FileName.Split('.')[1].ToUpper();
            // ... Switch on the string.
            switch (value)
            {
                case "DOC":
                    ReadWordDocument(path, FileName, DocumentID);
                    break;
                case "DOCX":
                    ReadWordDocument(path, FileName, DocumentID);
                    break;
                case "TXT":
                    ReadTextFile(path, FileName, DocumentID);
                    break;
                case "PDF":
                    ReadPDFDocument(path, FileName, DocumentID);
                    break;
                case "JPG":
                    ReadImageFiles(path, FileName, DocumentID);
                    break;
                case "PNG":
                    ReadImageFiles(path, FileName, DocumentID);
                    break;
                case "BMP":
                    ReadImageFiles(path, FileName, DocumentID);
                    break;
                case "GIF":
                    ReadImageFiles(path, FileName, DocumentID);
                    break;
                case "TIF":
                    ReadImageFiles(path, FileName, DocumentID);
                    break;
            }
        }


        public void ReadTextFile(string path, string FileName, string DocumentID)
        {
            string readContents;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd().ToUpper();
            }

            if (readContents != "")
            {
                string SearchText = string.Empty;
                string TypeOfDoc = string.Empty;
                string TagParentFolderValue = string.Empty;

                //string[] SearchValues = SearchValue.Split(',');

                Searchcount = 0;
                compareposition = 0;
                compareTagSearchvalue = string.Empty;

                for (int i = 0; i < SearchValues.Length; i++)
                {
                    if (SearchValues[i].ToString() != "")
                    {
                        if (readContents.Contains(SearchValues[i].ToString().ToUpper()))
                        {
                            TagParentFolderValue = GetLeastPositionedTagValueForTagKeyword(readContents, SearchValues[i].ToString().ToUpper());
                            //string Values = GetLeastPositionedTextWithIndexPosition(readContents, SearchValues[i].ToString().ToUpper(), Searchcount, compareposition, compareTagSearchvalue, i);
                            if (!string.IsNullOrEmpty(TagParentFolderValue))
                            {
                                string Values = GetLeastPositionedTextWithIndexPosition(readContents, TagParentFolderValue.ToUpper(), Searchcount, compareposition, compareTagSearchvalue, i);
                                string[] Valueposition = Values.Split(',');
                                Searchcount = Convert.ToInt32(Valueposition[0]);
                                compareposition = Convert.ToInt32(Valueposition[1]);
                                compareTagSearchvalue = Valueposition[2].ToString();
                                SearchText = TagParentFolderValue;
                            }


                        }
                    }
                }
                if (Searchcount != 0)
                {
                    string[] searchtextvalue = compareTagSearchvalue.Split('-');

                    //SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                    if (SearchText != "")
                    {
                        // Checking any one of the Category Value is present in contened Data or not
                        if (CategoryValue != "")
                        {
                            //string GivenTotalYears = GetSubfolderStrings();

                            //string[] CategoryValues = GivenTotalYears.Split(',');
                            int count = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (readContents.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        string TagSubFolderValue = GetLeastPositionedTagValueForTagKeyword(readContents, CategoryValues[i].ToString().ToUpper());
                                        //string Values = GetLeastPositionedTextWithIndexPosition(readContents, CategoryValues[i].ToString().ToUpper(), count, compareposition, compareTagSearchvalue, i);
                                        if (!string.IsNullOrEmpty(TagSubFolderValue))
                                        {
                                            string Values = GetLeastPositionedTextWithIndexPosition(readContents, TagSubFolderValue.ToUpper(), count, compareposition, compareTagSearchvalue, i);
                                            string[] Valueposition = Values.Split(',');
                                            count = Convert.ToInt32(Valueposition[0]);
                                            compareposition = Convert.ToInt32(Valueposition[1]);
                                            compareTagSearchvalue = Valueposition[2].ToString();
                                            TypeOfDoc = TagSubFolderValue;
                                        }
                                    }
                                }
                            }

                            if (count == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Other";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                //TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                FileCount = FileCount + 1;
                            }

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                    }
                }
                else
                {
                    int UnMatchedSearchcount = 0;
                    int UnMatchedcompareposition = 0;
                    string UnMatchedcompareTagSearchvalue = string.Empty;
                    for (int i = 0; i < SearchValues.Length; i++)
                    {
                        if (SearchValues[i].ToString() != "")
                        {
                            //int size = Math.Max(SearchValues[i].Length < 6 ? SearchValues[i].Length : SearchValues[i].Length / 2 + 1, 5);

                            int size = SearchValues[i].Length < 6 ? SearchValues[i].Length : Math.Max(SearchValues[i].Length / 2 + 1, 5);

                            //for (int j = 0; j < (SearchValues[i].Length - 4) + 1; j++)
                            //{
                            if (readContents.Contains(SearchValues[i].Substring(0, size).ToString().ToUpper()))
                            {
                                UnMatchedSearchcount += 1;

                                int position = readContents.IndexOf(SearchValues[i].Substring(0, size).ToString().ToUpper());

                                int nextposition = position;

                                if (UnMatchedSearchcount == 1)
                                {
                                    UnMatchedcompareposition = position;

                                    UnMatchedcompareTagSearchvalue = UnMatchedcompareposition + "-" + i;

                                    //j = (SearchValues[i].Length - 3);
                                }
                                else
                                {
                                    int result = Math.Min(UnMatchedcompareposition, nextposition);
                                    if (result == UnMatchedcompareposition)
                                    {
                                        UnMatchedcompareposition = result;
                                        UnMatchedcompareTagSearchvalue = UnMatchedcompareTagSearchvalue;
                                    }
                                    else if (result == nextposition)
                                    {
                                        UnMatchedcompareposition = result;
                                        UnMatchedcompareTagSearchvalue = UnMatchedcompareposition + "-" + i;
                                    }

                                    //j = (SearchValues[i].Length - 3);
                                }
                            }
                            //}
                        }
                    }
                    if (UnMatchedSearchcount != 0)
                    {
                        string[] searchtextvalue = UnMatchedcompareTagSearchvalue.Split('-');

                        SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                        SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                        if (CategoryValue != "")
                        {
                            //string GivenTotalYears = GetSubfolderStrings();

                            //string[] CategoryValues = GivenTotalYears.Split(',');
                            int Categorycount = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;
                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (readContents.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        string Values = GetLeastPositionedTextWithIndexPosition(readContents, CategoryValues[i].ToString().ToUpper(), Categorycount, compareposition, compareTagSearchvalue, i);

                                        string[] Valueposition = Values.Split(',');
                                        Categorycount = Convert.ToInt32(Valueposition[0]);
                                        compareposition = Convert.ToInt32(Valueposition[1]);
                                        compareTagSearchvalue = Valueposition[2].ToString();
                                    }
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Other";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');

                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();

                                FileCount = FileCount + 1;


                            }

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End


                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End


                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End

                        }
                    }
                    else
                    {
                        if (chkBxCreateFldrForUnmatchFiles.Checked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "Mismatched";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                            //Inserting unmatched files into Keywords and ScanDocResults tables
                            UpdateKeyWordsXML("Mismatched", "", "", "");

                            updateScannedDocXML(KeywordID.Trim(), DocumentID.Trim(), m_sDocUnMatchFile + "\\" + FileName, "Mismatched");
                            //End

                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                        }
                    }
                }

            }
            else
            {
                UnReadFileCount = UnReadFileCount + 1;

                if (m_sDocUnReadFile == null)
                {
                    m_sDocUnReadFile = DestinationFolder + "\\" + "UnReadFiles";
                    if (!System.IO.Directory.Exists(m_sDocUnReadFile))
                        System.IO.Directory.CreateDirectory(m_sDocUnReadFile);
                }
                //System.IO.File.Move(path, m_sDocUnReadFile + "\\" + FileName);
                System.IO.File.Copy(path, m_sDocUnReadFile + "\\" + FileName, true);
            }
        }

        public void ReadPDFDocument(string path, string FileName, string DocumentID)
        {
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[file.Length];
                file.Read(buffer, 0, buffer.Length);
                document = new TallComponents.PDF.Rasterizer.Document(new BinaryReader(new MemoryStream(buffer)));

                //selectedPage.Items.Clear();
                //for (int i = 1; i <= document.Pages.Count; i++) selectedPage.Items.Add(i);
                //selectedPage.SelectedIndex = 0;
            }

            int UnReadCount = 0;
            int UnMatchCount = 0;
            int count = 0;
            for (int i = 0; i < 1; i++)
            {
                m_sImages = null;
                Page page = document.Pages[i];
                int dpi = getDPI();
                float scale = (float)dpi / (float)72;
                using (Bitmap bitmap = new Bitmap((int)(scale * page.Width), (int)(scale * page.Height)))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.ScaleTransform(scale, scale);
                        graphics.Clear(Color.White);
                        page.Draw(graphics);
                    }
                    if (m_sImages == null)
                    {
                        m_sImages = SourceFolder + "\\" + "PDFIMAGES";
                        if (!System.IO.Directory.Exists(m_sImages))
                            System.IO.Directory.CreateDirectory(m_sImages);
                    }
                    //System.IO.File.Copy(path, m_sImages + "\\" + FileName, true);
                    if (!System.IO.File.Exists(m_sImages + "\\" + FileName.Split('.')[0] + "-" + i + ".jpg"))
                        bitmap.Save(m_sImages + "\\" + FileName.Split('.')[0] + "-" + i + ".jpg", getImageFormat());
                    try
                    {
                        //OCR Operations ... 
                        MODI.Document md = new MODI.Document();
                        md.Create(Convert.ToString(m_sImages + "\\" + FileName.Split('.')[0] + "-" + i + ".jpg"));
                        md.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);
                        MODI.Image image = (MODI.Image)md.Images[0];

                        string imgdata = image.Layout.Text.ToUpper();
                        if (imgdata != "")
                        {
                            string SearchText = string.Empty;
                            string TypeOfDoc = string.Empty;
                            string TagParentFolderValue = string.Empty;

                            //string[] SearchValues = SearchValue.Split(',');

                            Searchcount = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;

                            for (int k = 0; k < SearchValues.Length; k++)
                            {
                                if (SearchValues[k].ToString() != "")
                                {
                                    if (imgdata.Contains(SearchValues[k].ToString().ToUpper()))
                                    {
                                        TagParentFolderValue = GetLeastPositionedTagValueForTagKeyword(imgdata, SearchValues[k].ToString().ToUpper());
                                        //string Values = GetLeastPositionedTextWithIndexPosition(imgdata, SearchValues[k].ToString().ToUpper(), Searchcount, compareposition, compareTagSearchvalue, k);
                                        if (!string.IsNullOrEmpty(TagParentFolderValue))
                                        {
                                            string Values = GetLeastPositionedTextWithIndexPosition(imgdata, TagParentFolderValue.ToUpper(), Searchcount, compareposition, compareTagSearchvalue, k);
                                            string[] Valueposition = Values.Split(',');
                                            Searchcount = Convert.ToInt32(Valueposition[0]);
                                            compareposition = Convert.ToInt32(Valueposition[1]);
                                            compareTagSearchvalue = Valueposition[2].ToString();
                                            SearchText = TagParentFolderValue;
                                        }
                                    }
                                }
                            }
                            if (Searchcount != 0)
                            {
                                string[] searchtextvalue = compareTagSearchvalue.Split('-');

                                //SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                                SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                if (SearchText != "")
                                {
                                    // Checking any one of the Category Value is present in contened Data or not
                                    if (CategoryValue != "")
                                    {
                                        //string GivenTotalYears = GetSubfolderStrings();

                                        //string[] CategoryValues = GivenTotalYears.Split(',');
                                        count = 0;
                                        compareposition = 0;
                                        compareTagSearchvalue = string.Empty;

                                        for (int k = 0; k < CategoryValues.Length; k++)
                                        {
                                            if (CategoryValues[k].ToString() != "")
                                            {
                                                if (imgdata.Contains(CategoryValues[k].ToString().ToUpper()))
                                                {
                                                    string TagSubFolderValue = GetLeastPositionedTagValueForTagKeyword(imgdata, CategoryValues[k].ToString().ToUpper());
                                                    //string Values = GetLeastPositionedTextWithIndexPosition(imgdata, CategoryValues[k].ToString().ToUpper(), count, compareposition, compareTagSearchvalue, k);
                                                    if (!string.IsNullOrEmpty(TagSubFolderValue))
                                                    {
                                                        string Values = GetLeastPositionedTextWithIndexPosition(imgdata, TagSubFolderValue.ToUpper(), count, compareposition, compareTagSearchvalue, k);

                                                        string[] Valueposition = Values.Split(',');
                                                        count = Convert.ToInt32(Valueposition[0]);
                                                        compareposition = Convert.ToInt32(Valueposition[1]);
                                                        compareTagSearchvalue = Valueposition[2].ToString();
                                                        TypeOfDoc = TagSubFolderValue;
                                                    }

                                                }
                                            }
                                        }

                                        //if (i == document.Pages.Count - 1)
                                        //{
                                        if (count == 0)
                                        {
                                            FileCount = FileCount + 1;
                                            TypeOfDoc = "Other";
                                        }
                                        else
                                        {
                                            string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                            //TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                            FileCount = FileCount + 1;
                                        }


                                        // Saving in FileCabinet
                                        FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                                        // End


                                        // Stroring values in Temp table

                                        StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                                        // End

                                        //i = document.Pages.Count - 1;
                                    }
                                    else
                                    {
                                        FileCount = FileCount + 1;

                                        // Saving in FileCabinet
                                        FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                                        // End


                                        // Stroring values in Temp table

                                        StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                                        // End

                                        //i = document.Pages.Count - 1;
                                    }
                                }
                            }
                            else
                            {
                                int UnMatchedSearchcount = 0;
                                int UnMatchedcompareposition = 0;
                                string UnMatchedcompareTagSearchvalue = string.Empty;
                                for (int k = 0; k < SearchValues.Length; k++)
                                {
                                    if (SearchValues[k].ToString() != "")
                                    {
                                        //int size = Math.Max(SearchValues[k].Length < 6 ? SearchValues[k].Length : SearchValues[k].Length / 2 + 1, 5);

                                        int size = SearchValues[k].Length < 6 ? SearchValues[k].Length : Math.Max(SearchValues[k].Length / 2 + 1, 5);

                                        //for (int j = 0; j < (SearchValues[k].Length - 4) + 1; j++)
                                        //{
                                        if (imgdata.Contains(SearchValues[k].Substring(0, size).ToString().ToUpper()))
                                        {
                                            UnMatchedSearchcount += 1;

                                            int position = imgdata.IndexOf(SearchValues[k].Substring(0, size).ToString().ToUpper());

                                            int nextposition = position;

                                            if (UnMatchedSearchcount == 1)
                                            {
                                                UnMatchedcompareposition = position;

                                                UnMatchedcompareTagSearchvalue = UnMatchedcompareposition + "-" + k;

                                                //j = (SearchValues[i].Length - 3);
                                            }
                                            else
                                            {
                                                int result = Math.Min(UnMatchedcompareposition, nextposition);
                                                if (result == UnMatchedcompareposition)
                                                {
                                                    UnMatchedcompareposition = result;
                                                    UnMatchedcompareTagSearchvalue = UnMatchedcompareTagSearchvalue;
                                                }
                                                else if (result == nextposition)
                                                {
                                                    UnMatchedcompareposition = result;
                                                    UnMatchedcompareTagSearchvalue = UnMatchedcompareposition + "-" + k;
                                                }

                                                //j = (SearchValues[k].Length - 3);
                                            }
                                        }
                                        //}
                                    }
                                }
                                if (UnMatchedSearchcount != 0)
                                {
                                    string[] searchtextvalue = UnMatchedcompareTagSearchvalue.Split('-');

                                    SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                    // Checking any one of the Category Value is present in contened Data or not
                                    if (CategoryValue != "")
                                    {
                                        //string GivenTotalYears = GetSubfolderStrings();

                                        //string[] CategoryValues = GivenTotalYears.Split(',');

                                        count = 0;
                                        compareposition = 0;
                                        compareTagSearchvalue = string.Empty;

                                        for (int k = 0; k < CategoryValues.Length; k++)
                                        {
                                            if (CategoryValues[k].ToString() != "")
                                            {
                                                if (imgdata.Contains(CategoryValues[k].ToString().ToUpper()))
                                                {
                                                    string Values = GetLeastPositionedTextWithIndexPosition(imgdata, CategoryValues[k].ToString().ToUpper(), count, compareposition, compareTagSearchvalue, k);

                                                    string[] Valueposition = Values.Split(',');
                                                    count = Convert.ToInt32(Valueposition[0]);
                                                    compareposition = Convert.ToInt32(Valueposition[1]);
                                                    compareTagSearchvalue = Valueposition[2].ToString();
                                                }
                                            }
                                        }

                                        //if (i == document.Pages.Count - 1)
                                        //{
                                        if (count == 0)
                                        {
                                            FileCount = FileCount + 1;
                                            TypeOfDoc = "Other";
                                        }
                                        else
                                        {
                                            FileCount = FileCount + 1;
                                            string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                            TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                        }

                                        // Saving in FileCabinet
                                        FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                                        // End


                                        // Stroring values in Temp table

                                        StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                                        // End

                                        //i = document.Pages.Count - 1;
                                    }
                                    else
                                    {
                                        FileCount = FileCount + 1;

                                        // Saving in FileCabinet
                                        FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                                        // End

                                        // Stroring values in Temp table

                                        StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                                        // End

                                        //i = document.Pages.Count - 1;
                                    }


                                    // End
                                }
                                else
                                {

                                    if (chkBxCreateFldrForUnmatchFiles.Checked == true)
                                    {
                                        UnMatchFileCount = UnMatchFileCount + 1;

                                        if (m_sDocUnMatchFile == null)
                                        {
                                            m_sDocUnMatchFile = DestinationFolder + "\\" + "Mismatched";
                                            if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                                System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                                        }
                                        //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                                        System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                                        //Inserting unmatched files into Keywords and ScanDocResults tables
                                        UpdateKeyWordsXML("Mismatched", "", "", "");

                                        updateScannedDocXML(KeywordID.Trim(), DocumentID.Trim(), m_sDocUnMatchFile + "\\" + FileName, "Mismatched");
                                        //End

                                        StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                                    }

                                }
                            }
                        }
                        else if (i == 0)
                        {
                            if (UnReadCount == 0)
                            {
                                UnReadFileCount = UnReadFileCount + 1;

                                if (m_sDocUnReadFile == null)
                                {
                                    m_sDocUnReadFile = DestinationFolder + "\\" + "UnReadFiles";
                                    if (!System.IO.Directory.Exists(m_sDocUnReadFile))
                                        System.IO.Directory.CreateDirectory(m_sDocUnReadFile);
                                }
                                //System.IO.File.Move(path, m_sDocUnReadFile + "\\" + FileName);
                                System.IO.File.Copy(path, m_sDocUnReadFile + "\\" + FileName, true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                        MessageBox.Show(ex.Message, "Error '" + FileName + "' is in use by another application");
                    }
                }

                if (i == 0)
                {
                    if (!System.IO.File.Exists(m_sDocFile + "\\" + FileName))
                    {
                        if (System.IO.Directory.Exists(m_sImages))
                        {
                            DirectoryInfo dir = new DirectoryInfo(m_sImages);

                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                //fi.IsReadOnly = false;
                                fi.Delete();
                            }
                            dir.Delete(true);
                        }
                    }
                }
            }
        }

        public string GetLeastPositionedTextWithIndexPosition(string extractedText, string TagSearch, int Searchcount, int compareposition, string compareTagSearchvalue, int i)
        {
            Searchcount += 1;

            int position = extractedText.IndexOf(TagSearch);

            int nextposition = position;

            if (Searchcount == 1)
            {
                compareposition = position;

                compareTagSearchvalue = compareposition + "-" + i;
            }
            else
            {
                int result = Math.Min(compareposition, nextposition);
                if (result == compareposition)
                {
                    compareposition = result;
                    compareTagSearchvalue = compareTagSearchvalue;
                }
                else if (result == nextposition)
                {
                    compareposition = result;
                    compareTagSearchvalue = compareposition + "-" + i;
                }
            }

            return Searchcount.ToString() + ',' + compareposition.ToString() + ',' + compareTagSearchvalue;
        }


        public string GetLeastPositionedTagValueForTagKeyword(string extractedText, string TagSearch)
        {
            string tagValue = extractedText.Substring(extractedText.IndexOf(TagSearch) + TagSearch.Length);
            tagValue = tagValue.TrimStart();
            tagValue = Regex.Replace(tagValue, @"[\/:*?<>|'.@#%^&$!~\r\n,\!()]+", "");
            tagValue = tagValue.TrimStart();
            tagValue = tagValue.Substring(0, tagValue.IndexOf(" "));

            return tagValue;
        }

        public string GetLeastPositionedTestWithIMiSelectableItem(IMiSelectableItem modiTextSel, int Searchcount, int compareposition, string compareTagSearchvalue, int j)
        {
            try
            {
                modiSelectRects = modiTextSel.GetSelectRects();
            }
            catch (Exception)
            {
                MessageBox.Show("Me thinks that the OCR didn't work right!");
            }

            //int centerwidth = 0;
            int centerheight = 0;

            foreach (MODI.MiSelectRect mr in modiSelectRects)
            {
                Searchcount++;

                //intSelInfoPN = mr.PageNumber.ToString();
                intSelInfoTop = mr.Top;
                intSelInfoBottom = mr.Bottom;
                //intSelInfoLeft = mr.Left;
                //intSelInfoRight = mr.Right;

                //centerwidth = (intSelInfoRight - intSelInfoLeft) / 2;
                //centerwidth = intSelInfoLeft + centerwidth;
                centerheight = (intSelInfoBottom - intSelInfoTop) / 2;
                centerheight = centerheight + intSelInfoTop;

                int position = centerheight;

                int nextposition = position;

                if (Searchcount == 1)
                {
                    compareposition = position;

                    compareTagSearchvalue = compareposition + "-" + j;
                }
                else
                {
                    int result = Math.Min(compareposition, nextposition);
                    if (result == compareposition)
                    {
                        compareposition = result;
                        compareTagSearchvalue = compareTagSearchvalue;
                    }
                    else if (result == nextposition)
                    {
                        compareposition = result;
                        compareTagSearchvalue = compareposition + "-" + j;
                    }
                }
            }

            return Searchcount.ToString() + ',' + compareposition.ToString() + ',' + compareTagSearchvalue;
        }

        public string GetSubfolderStrings()
        {
            string[] yearCategoryValues = txtTagSrchSubFldr.Text.ToUpper().Trim().Split(',');
            StringBuilder myString = new StringBuilder();
            //string GivenTotalYears = string.Empty;
            for (int k = 0; k < yearCategoryValues.Length; k++)
            {
                if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                {
                    // string Yearcounting = string.Empty;
                    string Presentyear = string.Empty;
                    int i = 0;
                    string[] yearValues = yearCategoryValues[k].Split('-');
                    do
                    {
                        Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                        //Yearcounting = Yearcounting + Presentyear + ",";
                        myString.Append(Presentyear + ",");
                        i++;
                    } while (yearValues[1].ToString() != Presentyear);

                    //GivenTotalYears = GivenTotalYears + Yearcounting;
                    //myString.Append(Yearcounting);
                }
                else
                {
                    //GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                    myString.Append(yearCategoryValues[k].ToString() + ",");
                }
            }

            return myString.ToString();
        }

        public void ReadImageFiles(string path, string FileName, string DocumentID)
        {
            try
            {
                //OCR Operations ... 
                modiDoc = new MODI.Document();
                modiDoc.Create(Convert.ToString(path));
                modiDoc.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);

                modiSearch = new MiDocSearch();
                object num = 0, word = 0, start = 0, back = null;

                string SearchText = string.Empty;
                string TypeOfDoc = string.Empty;

                Searchcount = 0;
                compareposition = 0;
                compareTagSearchvalue = string.Empty;

                for (int k = 0; k < SearchValues.Length; k++)
                {
                    #region Take least positioned Matched string
                    if (SearchValues[k].ToString() != "")
                    {
                        #region Comparing strings with MiDocSearchClass

                        modiSearch.Initialize(modiDoc, SearchValues[k].ToString(), ref num, ref word, ref start, ref back, false, false, false, false);
                        modiSearch.Search(null, ref modiTextSel);

                        if (modiTextSel != null)
                        {
                            if (modiTextSel.Words.Count > 0)
                            {
                                //string TagSubFolderValue = GetLeastPositionedTagValueForTagKeyword(modiTextSel, CategoryValues[k].ToString().ToUpper());
                                string Values = GetLeastPositionedTestWithIMiSelectableItem(modiTextSel, Searchcount, compareposition, compareTagSearchvalue, k);

                                string[] Valueposition = Values.Split(',');
                                Searchcount = Convert.ToInt32(Valueposition[0]);
                                compareposition = Convert.ToInt32(Valueposition[1]);
                                compareTagSearchvalue = Valueposition[2].ToString();
                            }
                        }

                        #endregion
                    }
                    #endregion
                }
                if (Searchcount != 0)
                {
                    string[] searchtextvalue = compareTagSearchvalue.Split('-');

                    SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                    if (SearchText != "")
                    {
                        if (CategoryValue != "")
                        {
                            #region Take Least positioned Category Value

                            int count = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;

                            for (int k = 0; k < CategoryValues.Length; k++)
                            {
                                if (CategoryValues[k].ToString() != "")
                                {
                                    #region Comparing Substrings with MiDocSearchClass

                                    modiSearch.Initialize(modiDoc, CategoryValues[k].ToString(), ref num, ref word, ref start, ref back, false, false, false, false);
                                    modiSearch.Search(null, ref modiTextSel);

                                    if (modiTextSel != null)
                                    {
                                        if (modiTextSel.Words.Count > 0)
                                        {

                                            string Values = GetLeastPositionedTestWithIMiSelectableItem(modiTextSel, count, compareposition, compareTagSearchvalue, k);

                                            string[] Valueposition = Values.Split(',');
                                            count = Convert.ToInt32(Valueposition[0]);
                                            compareposition = Convert.ToInt32(Valueposition[1]);
                                            compareTagSearchvalue = Valueposition[2].ToString();
                                        }
                                    }

                                    #endregion
                                }
                            }
                            if (count == 0) // move the files miscellaneous if category also included 
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Other";

                            }
                            else
                            {
                                FileCount = FileCount + 1;
                                string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();

                            }

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End

                            #endregion
                        }
                        else // move the files to main folder if category is not defined
                        {
                            FileCount = FileCount + 1;

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                    }
                }

                else // Verify with partial  searchkeywords 
                {
                    MODI.Image image = (MODI.Image)modiDoc.Images[0];
                    string imgdata = image.Layout.Text.ToUpper();

                    int UnMatchedSearchcount = 0;
                    compareposition = 0;
                    compareTagSearchvalue = string.Empty;

                    for (int i = 0; i < SearchValues.Length; i++)
                    {
                        if (SearchValues[i].ToString() != "")
                        {
                            //int size = Math.Max(SearchValues[i].Length < 6 ? SearchValues[i].Length : SearchValues[i].Length / 2 + 1, 5);

                            int size = SearchValues[i].Length < 6 ? SearchValues[i].Length : Math.Max(SearchValues[i].Length / 2 + 1, 5);
                            //for (int j = 0; j < (SearchValues[i].Length - 4) + 1; j++)
                            //{
                            if (imgdata.Contains(SearchValues[i].Substring(0, size).ToString().ToUpper()))
                            {
                                UnMatchedSearchcount += 1;

                                int position = imgdata.IndexOf(SearchValues[i].Substring(0, size).ToString().ToUpper());

                                int nextposition = position;

                                if (UnMatchedSearchcount == 1)
                                {
                                    compareposition = position;

                                    compareTagSearchvalue = compareposition + "-" + i;

                                    //j = (SearchValues[i].Length - 3);
                                }
                                else
                                {
                                    int result = Math.Min(compareposition, nextposition);
                                    if (result == compareposition)
                                    {
                                        compareposition = result;
                                        compareTagSearchvalue = compareTagSearchvalue;
                                    }
                                    else if (result == nextposition)
                                    {
                                        compareposition = result;
                                        compareTagSearchvalue = compareposition + "-" + i;
                                    }

                                    //j = (SearchValues[i].Length - 3);
                                }

                            }
                            // }
                        }
                    }

                    if (UnMatchedSearchcount != 0)
                    {
                        string[] searchtextvalue = compareTagSearchvalue.Split('-');

                        SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                        SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                        if (CategoryValue != "")
                        {
                            int Categorycount = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (imgdata.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        string Values = GetLeastPositionedTextWithIndexPosition(imgdata, CategoryValues[i].ToString().ToUpper(), Categorycount, compareposition, compareTagSearchvalue, i);

                                        string[] Valueposition = Values.Split(',');
                                        Categorycount = Convert.ToInt32(Valueposition[0]);
                                        compareposition = Convert.ToInt32(Valueposition[1]);
                                        compareTagSearchvalue = Valueposition[2].ToString();
                                    }

                                    //#region Comparing Substrings with MiDocSearchClass

                                    //modiSearch.Initialize(modiDoc, CategoryValues[i].ToString(), ref num, ref word, ref start, ref back, false, false, false, false);
                                    //modiSearch.Search(null, ref modiTextSel);

                                    //if (modiTextSel != null)
                                    //{
                                    //    if (modiTextSel.Words.Count > 0)
                                    //    {

                                    //        string Values = GetLeastPositionedTestWithIMiSelectableItem(modiTextSel, Categorycount, compareposition, compareTagSearchvalue, i);

                                    //        string[] Valueposition = Values.Split(',');
                                    //        Categorycount = Convert.ToInt32(Valueposition[0]);
                                    //        compareposition = Convert.ToInt32(Valueposition[1]);
                                    //        compareTagSearchvalue = Valueposition[2].ToString();
                                    //    }
                                    //}

                                    //#endregion
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;

                                TypeOfDoc = "Other";
                            }
                            else
                            {
                                FileCount = FileCount + 1;

                                string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                            }

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End

                        }
                    }
                    else
                    {
                        if (chkBxCreateFldrForUnmatchFiles.Checked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "Mismatched";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                            //Inserting unmatched files into Keywords and ScanDocResults tables
                            UpdateKeyWordsXML("Mismatched", "", "", "");

                            updateScannedDocXML(KeywordID.Trim(), DocumentID.Trim(), m_sDocUnMatchFile + "\\" + FileName, "Mismatched");
                            //End

                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                        }
                    }
                }
                // End

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Error '" + FileName + "' is in use by another application");
            }
        }

        public void StroeValuesInTempTable(string SearchText, string TypeOfDoc, string SourceFolder, string DestinationFolder, string path, string FileName, string DocumentID)
        {
            DataRow drtemp = Dttemp.NewRow();
            drtemp["Search"] = SearchText;
            drtemp["ValueCategory"] = TypeOfDoc;
            drtemp["FilesFrom"] = SourceFolder;
            drtemp["FilesTo"] = DestinationFolder;
            drtemp["FilePath"] = path;
            drtemp["FileName"] = FileName;
            drtemp["DocumentID"] = DocumentID;
            Dttemp.Rows.Add(drtemp);
        }

        public void ReadWordDocument(string path, string FileName, string DocumentID)
        {
            Word.Application app = new Word.Application();
            Word.Document doc = new Word.Document();

            object fileName = path;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            doc = app.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            string extractedText = doc.Content.Text.ToUpper();

            doc.Close();

            if (extractedText != "")
            {
                string SearchText = string.Empty;
                string TypeOfDoc = string.Empty;
                string TagParentFolderValue = string.Empty;

                //string[] SearchValues = SearchValue.Split(',');

                Searchcount = 0;
                compareposition = 0;
                compareTagSearchvalue = string.Empty;

                for (int i = 0; i < SearchValues.Length; i++)
                {
                    if (SearchValues[i].ToString() != "")
                    {
                        if (extractedText.Contains(SearchValues[i].ToString().ToUpper()))
                        {
                            TagParentFolderValue = GetLeastPositionedTagValueForTagKeyword(extractedText, SearchValues[i].ToString().ToUpper());
                            //string Values = GetLeastPositionedTextWithIndexPosition(extractedText, SearchValues[i].ToString().ToUpper(), Searchcount, compareposition, compareTagSearchvalue, i);
                            if (!string.IsNullOrEmpty(TagParentFolderValue))
                            {
                                string Values = GetLeastPositionedTextWithIndexPosition(extractedText, TagParentFolderValue.ToUpper(), Searchcount, compareposition, compareTagSearchvalue, i);
                                string[] Valueposition = Values.Split(',');
                                Searchcount = Convert.ToInt32(Valueposition[0]);
                                compareposition = Convert.ToInt32(Valueposition[1]);
                                compareTagSearchvalue = Valueposition[2].ToString();
                                SearchText = TagParentFolderValue;
                            }
                        }
                    }
                }
                if (Searchcount != 0)
                {
                    string[] searchtextvalue = compareTagSearchvalue.Split('-');

                    //SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                    if (SearchText != "")
                    {
                        // Checking any one of the Category Value is present in contened Data or not

                        if (CategoryValue != "")
                        {

                            //string GivenTotalYears=GetSubfolderStrings();

                            //string[] CategoryValues = GivenTotalYears.Split(',');

                            int Categorycount = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (extractedText.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        string TagSubFolderValue = GetLeastPositionedTagValueForTagKeyword(extractedText, CategoryValues[i].ToString().ToUpper());
                                        //string Values = GetLeastPositionedTextWithIndexPosition(extractedText, CategoryValues[i].ToString().ToUpper(), Categorycount, compareposition, compareTagSearchvalue, i);
                                        if (!string.IsNullOrEmpty(TagSubFolderValue))
                                        {
                                            string Values = GetLeastPositionedTextWithIndexPosition(extractedText, TagSubFolderValue.ToUpper(), Categorycount, compareposition, compareTagSearchvalue, i);
                                            string[] Valueposition = Values.Split(',');
                                            Categorycount = Convert.ToInt32(Valueposition[0]);
                                            compareposition = Convert.ToInt32(Valueposition[1]);
                                            compareTagSearchvalue = Valueposition[2].ToString();
                                            TypeOfDoc = TagSubFolderValue;
                                        }
                                    }
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Other";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                //TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                FileCount = FileCount + 1;
                            }


                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                        else
                        {
                            FileCount = FileCount + 1;


                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End

                        }
                    }
                }
                else
                {
                    int UnMatchedSearchcount = 0;
                    int UnMatchedcompareposition = 0;
                    string UnMatchedcompareTagSearchvalue = string.Empty;

                    for (int i = 0; i < SearchValues.Length; i++)
                    {
                        if (SearchValues[i].ToString() != "")
                        {
                            //int size = Math.Max(SearchValues[i].Length < 6 ? SearchValues[i].Length : SearchValues[i].Length / 2 + 1, 5);

                            int size = SearchValues[i].Length < 6 ? SearchValues[i].Length : Math.Max(SearchValues[i].Length / 2 + 1, 5);

                            //for (int j = 0; j < (SearchValues[i].Length - 4) + 1; j++)
                            //{
                            if (extractedText.Contains(SearchValues[i].Substring(0, size).ToString().ToUpper()))
                            {
                                UnMatchedSearchcount += 1;

                                int position = extractedText.IndexOf(SearchValues[i].Substring(0, size).ToString().ToUpper());

                                int nextposition = position;

                                if (UnMatchedSearchcount == 1)
                                {
                                    UnMatchedcompareposition = position;

                                    UnMatchedcompareTagSearchvalue = UnMatchedcompareposition + "-" + i;

                                    //j = (SearchValues[i].Length - 3);
                                }
                                else
                                {
                                    int result = Math.Min(UnMatchedcompareposition, nextposition);
                                    if (result == UnMatchedcompareposition)
                                    {
                                        UnMatchedcompareposition = result;
                                        UnMatchedcompareTagSearchvalue = UnMatchedcompareTagSearchvalue;
                                    }
                                    else if (result == nextposition)
                                    {
                                        UnMatchedcompareposition = result;
                                        UnMatchedcompareTagSearchvalue = UnMatchedcompareposition + "-" + i;
                                    }

                                    //j = (SearchValues[i].Length - 3);
                                }
                            }
                            //}
                        }
                    }
                    if (UnMatchedSearchcount != 0)
                    {
                        string[] searchtextvalue = UnMatchedcompareTagSearchvalue.Split('-');

                        SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                        SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                        if (CategoryValue != "")
                        {
                            //string GivenTotalYears = GetSubfolderStrings();

                            //string[] CategoryValues = GivenTotalYears.Split(',');
                            int Categorycount = 0;
                            compareposition = 0;
                            compareTagSearchvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (extractedText.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        string Values = GetLeastPositionedTextWithIndexPosition(extractedText, CategoryValues[i].ToString().ToUpper(), Categorycount, compareposition, compareTagSearchvalue, i);

                                        string[] Valueposition = Values.Split(',');
                                        Categorycount = Convert.ToInt32(Valueposition[0]);
                                        compareposition = Convert.ToInt32(Valueposition[1]);
                                        compareTagSearchvalue = Valueposition[2].ToString();
                                    }
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Other";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = compareTagSearchvalue.Split('-');
                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                FileCount = FileCount + 1;
                            }

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            // Saving in FileCabinet
                            FileCabinetClass.MatchedDocumentsInFileCabinet(SearchText, TypeOfDoc, FileName, path);
                            // End

                            // Stroring values in Temp table

                            StroeValuesInTempTable(SearchText, TypeOfDoc, SourceFolder, DestinationFolder, path, FileName, DocumentID);

                            // End

                        }
                    }
                    else
                    {
                        if (chkBxCreateFldrForUnmatchFiles.Checked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "Mismatched";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                            //Inserting unmatched files into Keywords and ScanDocResults tables
                            UpdateKeyWordsXML("Mismatched", "", "", "");

                            updateScannedDocXML(KeywordID.Trim(), DocumentID.Trim(), m_sDocUnMatchFile + "\\" + FileName, "Mismatched");
                            //End

                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                        }
                    }
                }
            }
            else
            {
                UnReadFileCount = UnReadFileCount + 1;

                if (m_sDocUnReadFile == null)
                {
                    m_sDocUnReadFile = DestinationFolder + "\\" + "UnReadFiles";
                    if (!System.IO.Directory.Exists(m_sDocUnReadFile))
                        System.IO.Directory.CreateDirectory(m_sDocUnReadFile);
                }
                //System.IO.File.Move(path, m_sDocUnReadFile + "\\" + FileName);
                System.IO.File.Copy(path, m_sDocUnReadFile + "\\" + FileName, true);
            }
        }
        private int getProgressValue()
        {
            Thread.Sleep(100);
            j = j + 1;
            return j;
        }

        int getDPI()
        {
            return 150;
        }

        ImageFormat getImageFormat()
        {
            return ImageFormat.Jpeg;
        }

        private void AppendStringWithText()
        {
            //Creating text document automatically

            if (m_sLogFile == null)
            {
                m_sLogFile = ConfigurationManager.AppSettings["LogFilepath"].ToString();
                if (!System.IO.Directory.Exists(m_sLogFile))
                    System.IO.Directory.CreateDirectory(m_sLogFile);
            }

            StreamWriter sw = null;
            string sDate = DateTime.Now.ToString("yyyyMMdd");
            string sFileName = "PDFREAD_" + sDate + "_log.txt";
            string sFilePath = m_sLogFile + sFileName;

            if (File.Exists(sFilePath))
            {
                sw = File.AppendText(sFilePath); //open existing and append
            }
            else
            {
                sw = File.CreateText(sFilePath);  //create and add 
            }

            sw.WriteLine(" StartTime: " + DateTime.Now.ToString() + " Parent Folders: " + SearchValues + " and Sub-Folders: " + CategoryValue);
            sw.Close();
        }

        private void GetFileCount()
        {
            if (imgTagProcessing.InvokeRequired)
            {
                imgTagProcessing.Invoke(new MethodInvoker(delegate { imgTagProcessing.Visible = false; }));
            }
            else
            {
                imgTagProcessing.Visible = false;
            }
            if (cancel == false)
            {
                MovedFileCount objMovefilecount = new MovedFileCount();
                objMovefilecount.Filecount = FileCount.ToString();
                objMovefilecount.source = SourceFolder;
                objMovefilecount.destination = DestinationFolder;
                objMovefilecount.ShowDialog();
                objMovefilecount.Dispose();
                //MessageBox.Show("Total " + FileCount + " Files copied from " + SourceFolder + " to " + DestinationFolder);
            }
            //this.timer1.Stop();
            //this.progressBarTag.Visible = false;
            //txtSearch.Text = "";
            //txtTagInptLoc.Text = "";
            //txtTagOtptLoc.Text = "";
            //lblResult.Text = "";
            //chkBxCreateFldrForUnmatchFiles.Checked = false; 

            //txtTagSrchParentFldr.Text = "";
            //txtTagSrchSubFldr.Text = "";
            //txtTagInptLoc.Text = "";
            //txtTagOtptLoc.Text = "";
            if (txtTagSrchParentFldr.InvokeRequired)
            {
                txtTagSrchParentFldr.Invoke(new MethodInvoker(delegate { txtTagSrchParentFldr.Text = "Type one or more tag keywords separated by commas(,)"; }));
                txtTagSrchParentFldr.ForeColor = Color.Gray;
            }
            else
            {
                txtTagSrchParentFldr.Text = "";
            }
            if (txtTagSrchSubFldr.InvokeRequired)
            {
                txtTagSrchSubFldr.Invoke(new MethodInvoker(delegate { txtTagSrchSubFldr.Text = "Type one or more tag keywords separated by commas(,)"; }));
                txtTagSrchSubFldr.ForeColor = Color.Gray;
            }
            else
            {
                txtTagSrchSubFldr.Text = "";
            }
            if (txtTagInptLoc.InvokeRequired)
            {
                txtTagInptLoc.Invoke(new MethodInvoker(delegate { txtTagInptLoc.Text = ""; }));
            }
            else
            {
                txtTagInptLoc.Text = "";
            }
            if (txtTagOtptLoc.InvokeRequired)
            {
                txtTagOtptLoc.Invoke(new MethodInvoker(delegate { txtTagOtptLoc.Text = ""; }));
            }
            else
            {
                txtTagOtptLoc.Text = "";
            }
            if (chkBxAssignCabinet.InvokeRequired)
            {
                chkBxAssignCabinet.Invoke(new MethodInvoker(delegate { chkBxAssignCabinet.Checked = false; }));
            }
            else
            {
                chkBxAssignCabinet.Checked = false;
            }
            if (btnTagStart.InvokeRequired)
            {
                btnTagStart.Invoke(new MethodInvoker(delegate { btnTagStart.Visible = true; }));
            }
            else
            {
                btnTagStart.Visible = true;
            }
            if (btnTagClear.InvokeRequired)
            {
                btnTagClear.Invoke(new MethodInvoker(delegate { btnTagClear.Enabled = true; }));
            }
            else
            {
                btnTagClear.Enabled = true;
            }
            if (btnTagCancel.InvokeRequired)
            {
                btnTagCancel.Invoke(new MethodInvoker(delegate { btnTagCancel.Visible = false; }));
            }
            else
            {
                btnTagCancel.Visible = false;
                imgTagProcessing.Visible = false;
            }
            if (lblTagFileName.InvokeRequired)
            {
                lblTagFileName.Invoke(new MethodInvoker(delegate { lblTagFileName.Text = ""; }));
            }
            else
            {
                lblTagFileName.Text = "";
            }
            if (lblTagRemainingTime.InvokeRequired)
            {
                lblTagRemainingTime.Invoke(new MethodInvoker(delegate { lblTagRemainingTime.Text = ""; }));
            }
            else
            {
                lblTagRemainingTime.Text = "";
            }

            //NewMenu mf = (NewMenu)this.MdiParent;
            //mf.DisableAllMenuItem();

            txtTagSrchParentFldr.GotFocus += new EventHandler(this.SearchTextGotFocus);
            txtTagSrchParentFldr.LostFocus += new EventHandler(this.SearchTextLostFocus);

            //txtTagSrchSubFldr.GotFocus += new EventHandler(this.CategoryTextGotFocus);
            //txtTagSrchSubFldr.LostFocus += new EventHandler(this.CategoryTextLostFocus);
        }

        private void backgroundWorkerTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBarTag.Maximum = FileCount;
            this.progressBarTag.Minimum = 0;
            this.progressBarTag.Value = e.ProgressPercentage;
            lblTagSts.Text = e.UserState as String;
            //lblTagFileName.Text = String.Format("Progress: {0} ", e.ProgressPercentage);
        }

        private void backgroundWorkerTag_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Display smth or update status when progress is completed
            lblTagSts.Location = new Point(368, 32);
            lblTagSts.Text = "Your Process has been completed.";
            lblTagFileName.Visible = false;
            progressBarTag.Visible = false;
            // btnBack.Enabled = true;
            //btnFinish.Enabled = true;
            btnTagStart.Enabled = false;

            NewMenu mf = (NewMenu)this.MdiParent;
            mf.DisableAllMenuItem();

            txtTagSrchParentFldr.ReadOnly = false;
            txtTagSrchSubFldr.ReadOnly = false;
            txtTagInptLoc.ReadOnly = false;
            txtTagOtptLoc.ReadOnly = false;
            btnTagSrc.Enabled = true;
            btnTagDest.Enabled = true;
            chkBxAssignCabinet.Enabled = true;
            comboBxAssignCabinet.Enabled = true;
            lnkTagSelectCabinet.Enabled = true;
            chkBxCreateFldrForUnmatchFiles.Enabled = true;
        }
        private delegate void UpdateStatusDelegate(string status, TimeSpan ts);
        private void UpdateStatus(string status, TimeSpan ts)
        {
            if (this.lblTagFileName.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatus), new object[] { status, ts });
                return;
            }
            if (status.Length > 25)
            {
                this.lblTagFileName.Text = status.Substring(0, 25).ToString() + "...";
            }
            else
            {
                this.lblTagFileName.Text = status;
            }
            int totsecs = ts.Seconds;
            int totminutes = ts.Minutes;
            int tothours = ts.Hours;
            if (tothours > 0)
            {
                lblTagRemainingTime.Location = new Point(298, 72);
                lblTagRemainingTime.Text = "Time remaining : " + "About" + " " + tothours + " " + "Hours" + " " + totminutes + " Minutes" + " and " + totsecs + " Seconds";
            }
            else if (totminutes > 0)
            {
                lblTagRemainingTime.Location = new Point(323, 72);
                lblTagRemainingTime.Text = "Time remaining : " + "About" + " " + totminutes + " Minutes" + " and " + totsecs + " Seconds";
            }
            else
            {
                lblTagRemainingTime.Location = new Point(370, 72);
                lblTagRemainingTime.Text = "Time remaining : " + "About" + " " + totsecs + " Seconds";
            }
        }

        private void btnTagClear_Click(object sender, EventArgs e)
        {
            Dttemp.Clear();
            this.progressBarTag.Visible = false;
            lblTagSts.Visible = false;
            lblTagFileName.Visible = false;
            txtTagSrchParentFldr.Text = "";
            txtTagSrchSubFldr.Text = "";
            txtTagInptLoc.Text = "";
            txtTagOtptLoc.Text = "";
            chkBxCreateFldrForUnmatchFiles.Checked = false;
        }


        public string removeduplicates(string colname)
        {
            Hashtable ht = new Hashtable();
            string DuplicateNames = string.Empty;
            string[] Names = colname.Split(',');
            for (int i = 0; i < Names.Length; i++)
            {
                if (!ht.Contains(Names[i].ToUpper()))
                {
                    ht.Add(Names[i].ToUpper(), 0);
                }

                int count = (int)ht[Names[i].ToUpper()] + 1;
                ht[Names[i].ToUpper()] = count;
                if (count == 2)
                {
                    // Duplicate items are identified here.
                    DuplicateNames = DuplicateNames + Names[i] + ",";
                }
            }
            if (DuplicateNames.Length > 0)
            {
                DuplicateNames = DuplicateNames.Substring(0, DuplicateNames.Length - 1);
            }
            if (DuplicateNames != string.Empty || DuplicateNames != "")
            {
                DuplicateNames objDuplicateNames = new DuplicateNames();
                objDuplicateNames.DuplicateName = DuplicateNames;
                objDuplicateNames.ShowDialog();
                //return;
                //MessageBox.Show(DuplicateNames + " are given as duplicate");
            }
            return DuplicateNames;
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
                FileCabinetManager objFileCabinetManager = new FileCabinetManager();
                NandanaResult result = new NandanaResult();
                result = objFileCabinetManager.GetFileCabinets();

                if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
                {

                    //comboBxAssignCabinet.Items.Clear();
                    comboBxAssignCabinet.DisplayMember = "FileCabinet_Name";
                    comboBxAssignCabinet.ValueMember = "FileCabinet_ID";
                    comboBxAssignCabinet.DataSource = GetComboBoxedDataTable(result.resultDS.Tables[0], "FileCabinet_ID", "FileCabinet_Name", "0", "Choose a Cabinet");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error while Updating Data from GetFileCabinets SP");
            }
        }

        private void chkBxAssignCabinet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxAssignCabinet.Checked)
            {
                pnlTagAssignCabinet.Visible = true;
                pnlTagBottomControls.Location = new Point(64, 448);

                BindFileCabinets();
            }
            else
            {
                pnlTagAssignCabinet.Visible = false;
                pnlTagBottomControls.Location = new Point(64, 409);
            }
        }

        private void btnTagCancel_Click(object sender, EventArgs e)
        {
            CancelProcess objCancelProcess = new CancelProcess();
            objCancelProcess.ShowDialog();

            if (objCancelProcess.Process == "Yes")
            {
                //if (MessageBox.Show("Do you really wanted to stop the process?", "Stop Process", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                //{
                m_sImages = SourceFolder + "\\" + "PDFIMAGES";

                if (System.IO.Directory.Exists(m_sImages))
                {
                    DirectoryInfo dir = new DirectoryInfo(m_sImages);

                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        //fi.IsReadOnly = false;
                        fi.Delete();
                    }
                    dir.Delete(true);
                }

                CreateFolders();
                UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
                Dttemp.Clear();
                worker.CancelAsync();
                cancel = true;

                //NewMenu mf = (NewMenu)this.MdiParent;
                //mf.DisableAllMenuItem();
            }
        }

        private void txtTag_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void txtTagFormat_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void txtTagSrchParentFldr_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void txtTagSrchSubFldr_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void txtTagInptLoc_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void txtTagOtptLoc_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void lnkTagSelectCabinet_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            NewFileCabinet1 objNewFileCabinet = new NewFileCabinet1();
            objNewFileCabinet.ShowDialog();
            BindFileCabinets();
        }

        private void txtTagInptLoc_TextChanged(object sender, EventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void txtTagOtptLoc_TextChanged(object sender, EventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void pnlTagError_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (pnlTagError.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(System.Drawing.ColorTranslator.FromHtml("#e64c4a"), thickness))
                {
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(halfThickness,
                                                              halfThickness,
                                                              pnlTagError.ClientSize.Width - thickness,
                                                              pnlTagError.ClientSize.Height - thickness));
                }
            }
        }

        private void comboBxAssignCabinet_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlTagError.Visible = false;
        }

        private void comboBxAssignCabinet_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pnlTagError.Visible = false;
        }
    }
}
