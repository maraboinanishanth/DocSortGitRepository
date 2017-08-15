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
    public partial class EnterText : Form
    {
        public EnterText()
        {
            InitializeComponent();
        }
        //public DashBoardHome DashboardHome;

        public string CurrentFolderName
        {
            set;
            get;
        }

        public string FolderName
        {
            set;
            get;
        }
        public string FileCabinetID
        {
            set;
            get;
        }
        public string FolderID
        {
            set;
            get;
        }
        public string FileID
        {
            set;
            get;
        }
        public string FileName
        {
            set;
            get;
        }
        public string FormName
        {
            set;
            get;
        }

        FolderManager objFolderManager = new FolderManager();
        FilesManager objFilesManager = new FilesManager();

        private void EnterText_Load(object sender, EventArgs e)
        {
            if (FormName == "File")
            {
                label6.Text = "File Name";
            }
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            txtFolderName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            
            //FileCabinetID = ((DashBoardHome)DashboardHome).strRootNodeID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (txtFolderName.Text == String.Empty)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Folder Name is required";
                status = false;
                txtFolderName.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
               
                DashBoardHome obj = new DashBoardHome();
                
                if (FileCabinetID != null && FolderID != null)
                {

                    DataTable getFolderNames = new DataTable();

                    DocSortResult objgetfolderdetails = objFolderManager.GetFolderDetails();

                    if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + FileCabinetID + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getFolderNames = drResult.CopyToDataTable();
                        }
                    }
                    
                    if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
                    {
                        DataTable dtAllFolders = getFolderNames;
                        DataRow[] drMainFolders = dtAllFolders.Select("Folder_Name = '" + txtFolderName.Text + "'");
                        //DataTable dtMainFolders = drMainFolders.CopyToDataTable();
                        if (drMainFolders.Length != 0)
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Folder already exists, type a new name";
                            txtFolderName.Focus();
                            return;
                        }
                        else if (CurrentFolderName == txtFolderName.Text)
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Folder already exists, type a new name";
                            txtFolderName.Focus();
                            return;
                        }
                        else
                        {
                            FolderName = txtFolderName.Text;
                            this.Hide();
                        }
                    }
                    else
                    {
                        FolderName = txtFolderName.Text;
                        this.Hide();
                    }
                }
                else if (FileCabinetID != null)
                {
                    DataTable getFolderNames = new DataTable();

                    DocSortResult objgetfolderdetails = objFolderManager.GetFolderDetails();

                    if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + FileCabinetID + "'" + "and" + " ParentFolderID = '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getFolderNames = drResult.CopyToDataTable();
                        }
                    }
                   

                    if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
                    {
                        DataTable dtAllFolders = getFolderNames;
                        DataRow[] drMainFolders = dtAllFolders.Select("Folder_Name = '" + txtFolderName.Text + "'");
                        //DataTable dtMainFolders = drMainFolders.CopyToDataTable();
                        if (drMainFolders.Length != 0)
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Folder already exists, type a new name";
                            txtFolderName.Focus();
                            return;
                        }
                        else if (CurrentFolderName == txtFolderName.Text)
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Folder already exists, type a new name";
                            txtFolderName.Focus();
                            return;
                        }
                        else
                        {
                            FolderName = txtFolderName.Text;
                            this.Hide();
                        }
                    }
                    else
                    {
                        FolderName = txtFolderName.Text;
                        this.Hide();
                    }
                }
                else if (FolderID != null)
                {
                    DataTable getMainFolderNames = new DataTable();

                    DocSortResult objgetfolderdetails = objFolderManager.GetFolderDetails();

                    DataTable getSubFolderNames = new DataTable();


                    if (objgetfolderdetails.resultDS!=null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("ParentFolderID = '" + FolderID + "'" + "and" + " ParentFolderID <> '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getSubFolderNames = drResult.CopyToDataTable();
                        }
                    }

                   
                    if (getSubFolderNames.HasErrors != null && getSubFolderNames.Rows.Count > 0)
                    { 
                        DataTable dtAllSubFolders = getSubFolderNames;
                        DataRow[] drSubFolders = dtAllSubFolders.Select("Folder_Name = '" + txtFolderName.Text + "'");
                        //DataTable dtMainFolders = drMainFolders.CopyToDataTable();
                        if (drSubFolders.Length != 0)
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Folder already exists, type a new name";
                            txtFolderName.Focus();
                            return;
                        }
                        else if (CurrentFolderName == txtFolderName.Text)
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Folder already exists, type a new name";
                            txtFolderName.Focus();
                            return;
                        }
                        else
                        {
                            FolderName = txtFolderName.Text;
                            this.Hide();
                        }
                    }
                    else
                    {
                        FolderName = txtFolderName.Text;
                        this.Hide();
                    }
                }
                else if (FileID != null)
                {
                    DataTable getfiles = new DataTable();

                    DocSortResult objgetfiledetails = objFilesManager.GetFileDetails();

                    if (objgetfiledetails.resultDS != null && objgetfiledetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drResult = objgetfiledetails.resultDS.Tables[0].Select("File_ID = '" + FileID + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getfiles = drResult.CopyToDataTable();
                        }
                    }
                     

                    if (getfiles.HasErrors != null && getfiles.Rows.Count > 0)
                    {
                        DataRow dr = getfiles.Rows[0];

                        string Folderid = dr["Folder_ID"].ToString();

                        DataTable getfiledetailsussingfolderid = new DataTable();
                        DocSortResult objgetfolderdetails = objFolderManager.GetFolderDetails();

                        if (objgetfolderdetails.resultDS!=null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
                        {
                            DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("Folder_ID = '" + Folderid + "'" + "and" + " FileCabinet_ID = '" + FileCabinetID + "'" + "and" + " IsDelete = '" + "True" + "'");
                            if (drResult.Count() != 0)
                            {
                                getfiledetailsussingfolderid = drResult.CopyToDataTable();
                            }
                        }
                       
                        if (getfiledetailsussingfolderid.HasErrors != null && getfiledetailsussingfolderid.Rows.Count > 0)
                        {
                            foreach (DataRow drfiles in getfiledetailsussingfolderid.Rows)
                            {
                                string FileName = drfiles["File_Name"].ToString();
                                string[] splitfilenames = FileName.Split('.');
                                if (splitfilenames[0] == txtFolderName.Text.Trim())
                                {
                                    lblErrorMsg.Visible = true;
                                    lblErrorMsg.Text = "File already exists, type a new name";
                                    txtFolderName.Focus();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private DataTable GetMainFolderNames(string CabinetID)
        {
            DataTable getFolderNames = new DataTable();

            DocSortResult objgetfolderdetails = objFolderManager.GetFolderDetails();

            if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + CabinetID + "'" + "and" + " ParentFolderID = '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getFolderNames = drResult.CopyToDataTable();
                }
            }
            return getFolderNames;
        }

        private DataTable GetSubFolderNames(string FolderID)
        {
            DataTable getSubFolderNames = new DataTable();

            DocSortResult objgetfolderdetails = objFolderManager.GetFolderDetails();

            if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("ParentFolderID = '" + FolderID + "'" + "and" + " ParentFolderID <> '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getSubFolderNames = drResult.CopyToDataTable();
                }
            }
            return getSubFolderNames;
        }

        private void txtFolderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblErrorMsg.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
            //e.Graphics.DrawRectangle(Pens.Tomato,
            //e.ClipRectangle.Left,
            //e.ClipRectangle.Top,
            //e.ClipRectangle.Width - 1,
            //e.ClipRectangle.Height - 1);
            //base.OnPaint(e);
        }
    }
}
