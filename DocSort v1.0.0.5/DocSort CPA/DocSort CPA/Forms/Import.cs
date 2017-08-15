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
using System.Configuration;

namespace DocSort_CPA.Forms
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }

        FolderManager objFolderManager = new FolderManager();
        DataTable DtFolders = new DataTable();

        private void Import_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(9);
            // End

            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            this.Location = new Point(((Devicewidth - 3) - this.ClientSize.Width) / 2, 139);
            this.ControlBox = false;

            BindFileCabinets();
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
                string RoleID = UserAccessPermissionvalues.RoleID;
                string UserID = UserAccessPermissionvalues.UserID;
                if (RoleID != null && UserID != null)
                {
                    FileCabinetManager objFileCabinetManager = new FileCabinetManager();
                    DocSortResult result = new DocSortResult();
                    result = objFileCabinetManager.GetFileCabinets();

                    if (!result.HasError && result.resultDS.Tables[0].Rows.Count > 0)
                    {

                        cmbFileCabinet.Items.Clear();
                        cmbFileCabinet.DisplayMember = "FileCabinet_Name";
                        cmbFileCabinet.ValueMember = "FileCabinet_ID";
                        cmbFileCabinet.DataSource = GetComboBoxedDataTable(result.resultDS.Tables[0], "FileCabinet_ID", "FileCabinet_Name", "0", "Choose a Cabinet");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from Filecabinet table");
            }

        }

        public void GetFolders()
        {
            // Taking all all records of Folders into DtFolders table

            DocSortResult objgetFolderdetails = objFolderManager.GetFolderDetails();
            if (objgetFolderdetails.resultDS != null && objgetFolderdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DtFolders = objgetFolderdetails.resultDS.Tables[0];
            }
            else
            {
                DtFolders = null;
            }

            // End
        }

        private void GetMainFoldersBasedonCabinet(string FileCabinetID, string ParentFolderID)
        {
            try
            {
                DataTable DtMainFolders = new DataTable();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + FileCabinetID + "'" + "and" + " ParentFolderID = '" + ParentFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            DtMainFolders = drResult.CopyToDataTable();
                        }

                        if (DtMainFolders.HasErrors != null && DtMainFolders.Rows.Count > 0)
                        {
                            TreeNode parentNode = new TreeNode();

                            foreach (DataRow dr in DtMainFolders.Rows)
                            {
                                //cmbParentFolder.Items.Clear();
                                cmbParentFolder.DisplayMember = "Folder_Name";
                                cmbParentFolder.ValueMember = "Folder_ID";
                                cmbParentFolder.DataSource = GetComboBoxedDataTable(DtMainFolders, "Folder_ID", "Folder_Name", "0", "Choose a Parent Folder");
                            }
                        }
                        else
                        {
                            cmbParentFolder.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbFileCabinet_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            if (cmbFileCabinet.SelectedValue.ToString() != "0")
            {
                GetFolders();
                GetMainFoldersBasedonCabinet(cmbFileCabinet.SelectedValue.ToString(), "0");
            }
            else
            {
                cmbParentFolder.DataSource = null;
            }
        }

        private void cmbParentFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            if (cmbFileCabinet.SelectedValue.ToString() != "0" && cmbParentFolder.SelectedValue.ToString() != "0")
            {
                GetFolders();
                GetSubFoldersBasedonParentFolder(cmbParentFolder.SelectedValue.ToString());
            }
            else
            {
                cmbSubFolder.DataSource = null;
            }
        }

        private void GetSubFoldersBasedonParentFolder(string parentId)
        {
            try
            {
                DataTable DtSubFolders = new DataTable();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("ParentFolderID = '" + parentId.ToString() + "'" + "and" + " ParentFolderID <> '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            DtSubFolders = drResult.CopyToDataTable();
                        }

                        if (DtSubFolders.HasErrors != null && DtSubFolders.Rows.Count > 0)
                        {
                            foreach (DataRow dr in DtSubFolders.Rows)
                            {
                                //cmbSubFolder.Items.Clear();
                                cmbSubFolder.DisplayMember = "Folder_Name";
                                cmbSubFolder.ValueMember = "Folder_ID";
                                cmbSubFolder.DataSource = GetComboBoxedDataTable(DtSubFolders, "Folder_ID", "Folder_Name", "0", "Choose a Sub-Folder");
                            }
                        }
                        else
                        {
                            cmbSubFolder.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string FileArray = string.Empty;
        string FilePathArray = string.Empty;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            FileArray = string.Empty;
            FilePathArray = string.Empty;

            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fd.FilterIndex = 2;
            fd.RestoreDirectory = true;
            fd.Multiselect = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fd.FileNames.Length; i++)
                {
                    FilePathArray = FilePathArray + (fd.FileNames[i]) + "|";
                    FileArray = FileArray + (fd.SafeFileNames[i]) + "|";
                }

                if (FilePathArray.Length > 0)
                {
                    FilePathArray = FilePathArray.Substring(0, FilePathArray.Length - 1);
                }
                if (FileArray.Length > 0)
                {
                    FileArray = FileArray.Substring(0, FileArray.Length - 1);
                }
            }
        }

        string DocumentID = string.Empty;

        private string m_sConfigFile;
        private string m_sFileCabinetDocFile;
        private string m_sMainFolderDocFile;
        private string m_sSubFolderDocFile;
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool status = true;
            if (cmbFileCabinet.Text == "Choose a Cabinet" || cmbFileCabinet.Text.Length == 0)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 54);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select a Cabinet";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                cmbFileCabinet.Focus();
                return;
            }
            if (FileArray.Length == 0)
            {
                pnlError.Visible = true;
                pnlError.Location = new Point((this.Width - pnlError.ClientSize.Width) / 2, 54);
                pnlError.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5b7b7");
                lblError.Text = "Select one or more Documents to Import";
                lblError.Location = new Point((pnlError.Width - lblError.ClientSize.Width) / 2, (pnlError.Height - lblError.ClientSize.Height) / 2);
                status = false;
                btnBrowse.Focus();
                return;
            }
            if (!status)
            {
                MessageBox.Show("Please Enter required data");
            }
            else
            {
                FilesManager objFilesManager = new FilesManager();

                string[] splitFileName = FileArray.Split('|');
                string[] splitFilePathName = FilePathArray.Split('|');

                m_sConfigFile = null;
                m_sFileCabinetDocFile = null;
                m_sMainFolderDocFile = null;
                m_sSubFolderDocFile = null;

                for (int i = 0; i < splitFileName.Length; i++)
                {
                    if (m_sConfigFile == null)
                    {
                        m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                        if (!System.IO.Directory.Exists(m_sConfigFile))
                            System.IO.Directory.CreateDirectory(m_sConfigFile);
                    }

                    if (m_sFileCabinetDocFile == null)
                    {
                        m_sFileCabinetDocFile = m_sConfigFile + "\\" + cmbFileCabinet.Text;
                        if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                            System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
                    }

                    if (cmbFileCabinet.Text != "Choose a Cabinet" && (cmbParentFolder.Text == "Choose a Parent Folder" || cmbParentFolder.Text.Length == 0 || cmbParentFolder.Text == null))
                    {
                        System.IO.File.Copy(splitFilePathName[i], m_sFileCabinetDocFile + "\\" + splitFileName[i], true);

                        // inserting files into documentslist table //

                        MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                        DocSortResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), splitFileName[i], "Manual");
                        if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                            DocumentID = dr["DocumentId"].ToString();
                        }

                        // End

                        DocSortResult insertfiledetails = objFilesManager.InsertFileDetails(0,Convert.ToInt32(cmbFileCabinet.SelectedValue.ToString()), splitFileName[i], m_sFileCabinetDocFile + "\\" + splitFileName[i], "True");
                    }
                    else if (cmbFileCabinet.Text != "Choose a Cabinet" && cmbParentFolder.Text != "Choose a Parent Folder" && (cmbSubFolder.Text == "Choose a Sub-Folder" || cmbSubFolder.Text.Length == 0 || cmbSubFolder.Text == null))
                    {
                        if (m_sMainFolderDocFile == null)
                        {
                            m_sMainFolderDocFile = m_sFileCabinetDocFile + "\\" + cmbParentFolder.Text;
                            if (!System.IO.Directory.Exists(m_sMainFolderDocFile))
                                System.IO.Directory.CreateDirectory(m_sMainFolderDocFile);
                        }

                        System.IO.File.Copy(splitFilePathName[i], m_sMainFolderDocFile + "\\" + splitFileName[i], true);

                        // inserting files into documentslist table //

                        MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                        DocSortResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), splitFileName[i], "Manual");
                        if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                            DocumentID = dr["DocumentId"].ToString();
                        }

                        // End

                        DocSortResult insertfiledetails = objFilesManager.InsertFileDetails(Convert.ToInt32(cmbParentFolder.SelectedValue.ToString()),Convert.ToInt32(cmbFileCabinet.SelectedValue.ToString()), splitFileName[i], m_sMainFolderDocFile + "\\" + splitFileName[i], "True");
                    }
                    else if (cmbFileCabinet.Text != "Choose a Cabinet" && cmbParentFolder.Text != "Choose a Parent Folder" && cmbSubFolder.Text != "Choose a Sub-Folder")
                    {
                        if (m_sMainFolderDocFile == null)
                        {
                            m_sMainFolderDocFile = m_sFileCabinetDocFile + "\\" + cmbParentFolder.Text;
                            if (!System.IO.Directory.Exists(m_sMainFolderDocFile))
                                System.IO.Directory.CreateDirectory(m_sMainFolderDocFile);
                        }
                        if (m_sSubFolderDocFile == null)
                        {
                            m_sSubFolderDocFile = m_sMainFolderDocFile + "\\" + cmbSubFolder.Text;
                            if (!System.IO.Directory.Exists(m_sSubFolderDocFile))
                                System.IO.Directory.CreateDirectory(m_sSubFolderDocFile);
                        }

                        System.IO.File.Copy(splitFilePathName[i], m_sSubFolderDocFile + "\\" + splitFileName[i], true);

                        // inserting files into documentslist table //

                        MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                        DocSortResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), splitFileName[i], "Manual");
                        if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                            DocumentID = dr["DocumentId"].ToString();
                        }

                        // End

                        DocSortResult insertfiledetails = objFilesManager.InsertFileDetails(Convert.ToInt32(cmbSubFolder.SelectedValue.ToString()),Convert.ToInt32(cmbFileCabinet.SelectedValue.ToString()), splitFileName[i], m_sSubFolderDocFile + "\\" + splitFileName[i], "True");
                    }
                }
                //MessageBox.Show("Files are Imported into Selected Filecabinet Successfully");

                SaveSuccess objsavesuccess = new SaveSuccess();
                objsavesuccess.ShowDialog();

                FileArray = string.Empty;
                FilePathArray = string.Empty;

                cmbFileCabinet.SelectedValue = 0;
                cmbParentFolder.DataSource = null;
                cmbSubFolder.DataSource = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewMenu mf = (NewMenu)this.MdiParent;
            // click toolStripButton1
            mf.btnHome.PerformClick();
            //this.Hide();
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
