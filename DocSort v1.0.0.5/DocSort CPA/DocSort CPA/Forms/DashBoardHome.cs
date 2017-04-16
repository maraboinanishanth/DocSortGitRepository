using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Word = Microsoft.Office.Interop.Word;
using Business.Manager;
using Common;
using System.Diagnostics;

namespace DocSort_CPA.Forms
{
    public partial class DashBoardHome : Form
    {
        public DashBoardHome()
        {
            InitializeComponent();
        }

        //DataTable dttemp = new DataTable();
        public string strRootNodeID
        {
            set;
            get;
        }
        public string strRootNode
        {
            set;
            get;
        }

        
        OpenFileCabinet openfilecabinet = new OpenFileCabinet();
        NewFileCabinet newfilecabinet = new NewFileCabinet();

        DataTable DtCabinets = new DataTable();
        DataTable DtFolders = new DataTable();
        DataTable DtFiles = new DataTable();

        FileCabinetManager objFileCabinetManager = new FileCabinetManager();
        FolderManager objFolderManager = new FolderManager();
        FilesManager objFilesManager = new FilesManager();

        object backupTreeViewObject;

        private void DashBoardHome_Load(object sender, EventArgs e)
        {
            // Checking Useraccesspermissions based on Role
            GetPermissiondetails(2);


            // End

            //txtSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            treeView1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
            int Devicewidth = UserAccessPermissionvalues.DeviceWidth;
            int Deviceheight = UserAccessPermissionvalues.DeviceHeight;
            this.Location = new Point(((Devicewidth-3) - this.ClientSize.Width) / 2, 139);

            this.ControlBox = false;
            //this.Location = new Point(5, 173);
            //this.WindowState = FormWindowState.Maximized;

            txtSearch.GotFocus += new EventHandler(this.UserTextGotFocus);
            txtSearch.LostFocus += new EventHandler(this.UserTextLostFocus);

            this.Height = 562;
            this.Width = 1004;
            this.Location = new Point(((Devicewidth - 3) - this.ClientSize.Width) / 2, 139);

            DataTable dtfilecabinets = new DataTable();

            GetFileCabinets();

            GetFolders();

            GetFiles();

            if (strRootNode != null)
            {
                //strRootNode = newfilecabinet.FileCabinetName;
                //strRootNodeID = newfilecabinet.FileCabinetID;

                LoadTreeview(strRootNodeID, strRootNode.ToUpper());
            }
            else
            {
                LoadTreeview("1", "ROOT");

                // sorting table by removing ROOT default cabinet outside

                DataRow[] drResult = DtCabinets.Select("FileCabinet_ID <> '" + 1 + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    dtfilecabinets = drResult.CopyToDataTable();

                    DataView dv = dtfilecabinets.DefaultView;
                    dv.Sort = "FileCabinet_Name asc";
                    DataTable sortedDT = dv.ToTable();

                    //END

                    foreach (DataRow dr in sortedDT.Rows)
                    {
                        //strRootNodeID = dr["FileCabinet_ID"].ToString();
                        //strRootNode = dr["FileCabinet_Name"].ToString();

                        LoadTreeview(dr["FileCabinet_ID"].ToString(), dr["FileCabinet_Name"].ToString().ToUpper());
                    }
                }
                //treeView1.Sort();
            }
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

            else if (ctrl is DateTimePicker)

                ((DateTimePicker)ctrl).Enabled = status;
        }

        public DataTable GetFileCabinets()
        {
            // Taking all all records of FileCabinets into DtCabinets table

            NandanaResult getfilecabinets = objFileCabinetManager.GetFileCabinets();
            if (getfilecabinets.resultDS != null && getfilecabinets.resultDS.Tables[0].Rows.Count > 0)
            {
                DtCabinets = getfilecabinets.resultDS.Tables[0];
            }
            else
            {
                DtCabinets = null;
            }

            return DtCabinets;
            // End
        }

        public DataTable GetFolders()
        {
            // Taking all all records of Folders into DtFolders table

            NandanaResult objgetFolderdetails = objFolderManager.GetFolderDetails();
            if (objgetFolderdetails.resultDS != null && objgetFolderdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DtFolders = objgetFolderdetails.resultDS.Tables[0];
            }
            else
            {
                DtFolders = null;
            }

            return DtFolders;
            // End
        }

        public void GetFiles()
        {
            // Taking all all records of Files into DtFiles table

            NandanaResult objgetFilesdetails = objFilesManager.GetFileDetails();
            if (objgetFilesdetails.resultDS != null && objgetFilesdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DtFiles = objgetFilesdetails.resultDS.Tables[0];
            }
            else
            {
                DtFiles = null;
            }

            // End
        }

        TreeNode RootNode = new TreeNode();
        public void LoadTreeview(string strRootNodeID, string strRootNode)
        {
            if (strRootNode.Length != 0 || strRootNodeID != null)
            {

                PanelWebBrowser.Visible = false;

                TreeNode RootNode = new TreeNode(strRootNode.ToUpper());
                treeView1.ImageList = imageList1;
                //TreeView1.SelectedNode.ImageIndex = 0;
                //TreeView1.SelectedNode.SelectedImageIndex = 1;

                RootNode.Name = strRootNodeID;
                RootNode.ContextMenuStrip = RootNodeContextMenu;
                RootNode.ImageKey = "LockerIcon.png";
                RootNode.SelectedImageKey = "LockerIcon.png";


                // Searching for Mainfolders
                GetMainFoldersBasedonCabinet(strRootNodeID, "0", RootNode);
                //End


                // Searching for files which present in Mainfolders
                GetFilesBasedonCabinetAndFolders(Convert.ToInt32(strRootNodeID), 0, RootNode);
                //End
               
                if (strRootNode == "ROOT")
                {
                    treeView1.Nodes.Add(RootNode);

                    treeView1.SelectedNode = RootNode;
                }
                else
                {
                    treeView1.Nodes.Add(RootNode);
                }
            }
        }

        private int GetMainFolderCabinetID(string FolderName)
        {
            DataTable DtMainFolders = new DataTable();
            int FolderID = 0;
            try
            {
                DtMainFolders = new DataTable();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("Folder_Name = '" + FolderName  + "'");
                        if (drResult.Count() != 0)
                        {
                            DtMainFolders = drResult.CopyToDataTable();
                        }

                        foreach (DataRow dr in DtMainFolders.Rows)
                        {
                            if (DtMainFolders.HasErrors != null && DtMainFolders.Rows.Count > 0)
                            {
                                FolderID = Convert.ToInt32(dr["Folder_ID"].ToString());
                            }
                        }
                    }
                }               

            }
            catch (Exception ex)
            {
            }

            return FolderID;
        }

        private void GetMainFoldersBasedonCabinet(string strRootNodeID, string ParentFolderID, TreeNode RootNode)
        {
            try
            {
                DataTable DtMainFolders = new DataTable();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + strRootNodeID + "'" + "and" + " ParentFolderID = '" + ParentFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            DtMainFolders = drResult.CopyToDataTable();
                        }

                        if (DtMainFolders.HasErrors != null && DtMainFolders.Rows.Count > 0)
                        {
                            TreeNode parentNode = new TreeNode();

                            foreach (DataRow dr in DtMainFolders.Rows)
                            {
                                parentNode = RootNode.Nodes.Add(dr["Folder_Name"].ToString().ToUpper());
                                parentNode.Name = dr["Folder_ID"].ToString();
                                parentNode.ContextMenuStrip = FolderContextMenu;
                                parentNode.ImageKey = "FolderIcon.png";
                                parentNode.SelectedImageKey = "FolderIcon.png";
                                
                                PopulateFolderTreeView(Convert.ToInt32(dr["Folder_ID"].ToString()), parentNode, Convert.ToInt32(strRootNodeID));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetSubFoldersBasedonParentFolder(int parentId, TreeNode parentNode, int CabinetID)
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
                            TreeNode childNode;
                            foreach (DataRow dr in DtSubFolders.Rows)
                            {
                                if (parentNode == null)
                                {
                                    if (!RootNode.Nodes.ContainsKey(dr["Folder_ID"].ToString()))
                                    {
                                        childNode = RootNode.Nodes.Add(dr["Folder_Name"].ToString().ToUpper());
                                        childNode.Name = dr["Folder_ID"].ToString();
                                        childNode.ContextMenuStrip = FolderContextMenu;
                                        childNode.ImageKey = "FolderIcon.png";
                                        childNode.SelectedImageKey = "FolderIcon.png";

                                        PopulateFolderTreeView(Convert.ToInt32(dr["Folder_ID"].ToString()), childNode, CabinetID);
                                    }
                                }
                                else
                                {
                                    if (!parentNode.Nodes.ContainsKey(dr["Folder_ID"].ToString()))
                                    {
                                        childNode = parentNode.Nodes.Add(dr["Folder_Name"].ToString().ToUpper());
                                        childNode.Name = dr["Folder_ID"].ToString();
                                        childNode.ContextMenuStrip = FolderContextMenu;
                                        childNode.ImageKey = "FolderIcon.png";
                                        childNode.SelectedImageKey = "FolderIcon.png";

                                        PopulateFolderTreeView(Convert.ToInt32(dr["Folder_ID"].ToString()), childNode, CabinetID);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetFilesBasedonCabinetAndFolders(int strRootNodeID, int ParentFolderID, TreeNode RootNode)
        {
            try
            {
                DataTable DtMainFolderFiles = new DataTable();

                if (DtFiles != null)
                {
                    if (DtFiles.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFiles.Select("FileCabinet_ID = '" + strRootNodeID + "'" + "and" + " Folder_ID = '" + ParentFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            DtMainFolderFiles = drResult.CopyToDataTable();
                        }

                        if (DtMainFolderFiles.HasErrors != null && DtMainFolderFiles.Rows.Count > 0)
                        {
                            TreeNode fileNode = new TreeNode();

                            foreach (DataRow dr in DtMainFolderFiles.Rows)
                            {
                                fileNode = RootNode.Nodes.Add(dr["File_Name"].ToString());
                                string FileName = (dr["File_Name"].ToString());
                                fileNode.Name = dr["File_ID"].ToString();
                                fileNode.ContextMenuStrip = FileContextMenu;
                                string[] FileType = FileName.Split('.');

                                string value = FileType[1].ToString().ToUpper();
                                // ... Switch on the string.
                                switch (value)
                                {
                                    case "PDF":
                                        fileNode.ImageKey = "PDFIcon.png";
                                        fileNode.SelectedImageKey = "PDFIcon.png";
                                        break;
                                    case "JPG":
                                        fileNode.ImageKey = "JPGIcon.png";
                                        fileNode.SelectedImageKey = "JPGIcon.png";
                                        break;
                                    case "PNG":
                                        fileNode.ImageKey = "JPGIcon.png";
                                        fileNode.SelectedImageKey = "JPGIcon.png";
                                        break;
                                    case "BMP":
                                        fileNode.ImageKey = "JPGIcon.png";
                                        fileNode.SelectedImageKey = "JPGIcon.png";
                                        break;
                                    case "GIF":
                                        fileNode.ImageKey = "JPGIcon.png";
                                        fileNode.SelectedImageKey = "JPGIcon.png";
                                        break;
                                    case "TIF":
                                        fileNode.ImageKey = "JPGIcon.png";
                                        fileNode.SelectedImageKey = "JPGIcon.png";
                                        break;
                                    case "TIFF":
                                        fileNode.ImageKey = "JPGIcon.png";
                                        fileNode.SelectedImageKey = "JPGIcon.png";
                                        break;
                                    default:
                                        fileNode.ImageKey = "TXTIcon.png";
                                        fileNode.SelectedImageKey = "TXTIcon.png";
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UserTextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Search")
            {
                this.txtSearch.TextChanged -= new System.EventHandler(this.txtSearch_TextChanged);
                tb.Text = "";
                tb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            }
        }

        public void UserTextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                this.txtSearch.TextChanged -= new System.EventHandler(this.txtSearch_TextChanged);
                tb.Text = "Search";
                tb.ForeColor = Color.Gray;
                this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            }
        }

        private void PopulateFolderTreeView(int parentId, TreeNode parentNode, int CabinetID)
        {
            try
            {
                // Searching for Subfolders
                GetSubFoldersBasedonParentFolder(parentId, parentNode, CabinetID);
                //End

                // Searching for files which present in Subfolders
                GetFilesBasedonCabinetAndFolders(CabinetID, parentId, parentNode);
                //End

                //DataTable dtchildc = new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from Folders");
            }
        }

        private void PopulateFileTreeView(int parentfolderId, int FilecabinetId, TreeNode parentNode)
        {
            // Searching for files which present in Subfolders
            GetFilesBasedonCabinetAndFolders(FilecabinetId, parentfolderId, parentNode);
            //End
        }

        // adding Directories to Selected Node //


        public string FolderID;
        public string FileID;
        private string m_sConfigFile;
        private string m_sFileCabinetDocFile;
        private string m_sImportedFolderDocFile;
        private string m_sImportedSubFolderDocFile;
        private void ListDirectory(TreeView treeView, string path)
        {
            m_sConfigFile = null;
            m_sFileCabinetDocFile = null;
            m_sImportedFolderDocFile = null;

            if (m_sConfigFile == null)
            {
                m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                if (!System.IO.Directory.Exists(m_sConfigFile))
                    System.IO.Directory.CreateDirectory(m_sConfigFile);
            }

            if (m_sFileCabinetDocFile == null)
            {
                m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();
                if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                    System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
            }

            //FolderManager objFolderManager = new FolderManager();
            //FilesManager objFilesManager = new FilesManager();

            var rootDirectoryInfo = new DirectoryInfo(path);

            var directoryNode = new TreeNode(rootDirectoryInfo.Name);

            if (m_sImportedFolderDocFile == null)
            {
                m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + rootDirectoryInfo.Name.ToUpper();
                if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                    System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
            }

            //* inserting Folder details in Folder table *//

            NandanaResult objinsertintofolder = objFolderManager.InsertFolderDetails(strRootNodeID, rootDirectoryInfo.Name.ToUpper(), "0", "True");
            if (objinsertintofolder.resultDS != null && objinsertintofolder.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = objinsertintofolder.resultDS.Tables[0].Rows[0];
                FolderID = dr["FolderId"].ToString();
            }
            
            //* End  *//

            foreach (var file in rootDirectoryInfo.GetFiles())
            {
                System.IO.File.Copy(path + "\\" + file.Name, m_sImportedFolderDocFile + "\\" + file.Name, true);

                //* inserting files details in Files table *//

                NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(FolderID),Convert.ToInt32(strRootNodeID), file.Name, m_sImportedFolderDocFile + "\\" + file.Name, "True");

                //* End  *//

                directoryNode.Nodes.Add(new TreeNode(file.Name));
            }

            foreach (TreeNode ChildNode in directoryNode.Nodes)
            {
                ChildNode.ContextMenuStrip = FileContextMenu;
                //ChildNode.ImageKey = "File.png";
                //ChildNode.SelectedImageKey = "File.png";

            }

            treeView.SelectedNode.Nodes.Add(directoryNode);
            directoryNode.ContextMenuStrip = FolderContextMenu;
            directoryNode.ImageKey = "FolderIcon.png";
            directoryNode.SelectedImageKey = "FolderIcon.png";

            treeView.SelectedNode.Expand();
        }

        string DocumentID = string.Empty;

        // adding Files to Selected Node //
        private void  ListFiles(TreeView treeView, string path)
        {
            m_sConfigFile = null;
            m_sFileCabinetDocFile = null;
            m_sImportedFolderDocFile = null;

            if (m_sConfigFile == null)
            {
                m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                if (!System.IO.Directory.Exists(m_sConfigFile))
                    System.IO.Directory.CreateDirectory(m_sConfigFile);
            }

            if (m_sFileCabinetDocFile == null)
            {
                m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();  
                if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                    System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
            }

            //FilesManager objFilesManager = new FilesManager();
            var rootFileInfo = new FileInfo(path);

            TreeNode newNode = new TreeNode();
            newNode.Text = rootFileInfo.Name;


            //treeView.SelectedNode.Nodes.Add((rootFileInfo.Name));

            System.IO.File.Copy(path, m_sFileCabinetDocFile + "\\" + rootFileInfo.Name, true);


            // inserting files into documentslist table //

            MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
            NandanaResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), rootFileInfo.Name, "Manual");
            if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                DocumentID = dr["DocumentId"].ToString();
            }

            // End

            //* inserting files details in Files table *//

            NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(0,Convert.ToInt32(treeView1.SelectedNode.Name), rootFileInfo.Name, m_sFileCabinetDocFile + "\\" + rootFileInfo.Name, "True");
            if (objinsertfilesdetails.resultDS != null && objinsertfilesdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = objinsertfilesdetails.resultDS.Tables[0].Rows[0];
                FileID = dr["FileId"].ToString();
            }
            
            //* End  *//

           
            newNode.Name = FileID;
            newNode.ContextMenuStrip = FileContextMenu;
            string[] FileType = rootFileInfo.Name.ToString().Split('.');

            string value = FileType[1].ToString().ToUpper();
            // ... Switch on the string.
            switch (value)
            {
                case "PDF":
                    newNode.ImageKey = "PDFIcon.png";
                    newNode.SelectedImageKey = "PDFIcon.png";
                    break;
                case "JPG":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "PNG":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "BMP":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "GIF":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "TIF":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "TIFF":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                default:
                    newNode.ImageKey = "TXTIcon.png";
                    newNode.SelectedImageKey = "TXTIcon.png";
                    break;
            }


            treeView.SelectedNode.Nodes.Add(newNode);

            treeView.SelectedNode.Expand();
        }

        private void ListSubFiles(TreeView treeView, string path)
        {
            m_sConfigFile = null;
            m_sFileCabinetDocFile = null;
            m_sImportedFolderDocFile = null;

            if (m_sConfigFile == null)
            {
                m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                if (!System.IO.Directory.Exists(m_sConfigFile))
                    System.IO.Directory.CreateDirectory(m_sConfigFile);
            }

            if (m_sFileCabinetDocFile == null)
            {
                if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                {
                    m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Parent.Text.ToUpper();
                }
                else
                {
                    m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Parent.Parent.Text.ToUpper();
                }
                if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                    System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
            }

            var rootFileInfo = new FileInfo(path);

            ArrayFolderIDs = string.Empty;
            ImportFilesInFolder(treeView1.SelectedNode.Name, m_sFileCabinetDocFile, path, rootFileInfo.Name);


            treeView.SelectedNode.Expand();
        }

        public void ImportFilesInFolder(string FolderID, string m_sFileCabinetDocFile, string path, string rootFileInfo)
        {
            GetFolders();

            //NandanaResult objgetfolderdetails = objFolderManager.GetFolderDetails();

            DataTable getMainFolderNames = new DataTable();

            DataRow[] drResult = DtFolders.Select("Folder_ID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
            if (drResult.Count() != 0)
            {
                getMainFolderNames = drResult.CopyToDataTable();
            }

            if (getMainFolderNames.HasErrors != null && getMainFolderNames.Rows.Count > 0)
            {
                DataRow dr = getMainFolderNames.Rows[0];
                string ParentFolderID = dr["ParentFolderID"].ToString();
                ArrayFolderIDs = ArrayFolderIDs + ParentFolderID + ',';
                ImportFilesInFolder(ParentFolderID, m_sFileCabinetDocFile, path, rootFileInfo);
            }
            else
            {
                if (ArrayFolderIDs.Length > 0)
                {
                    ArrayFolderIDs = ArrayFolderIDs.Substring(0, ArrayFolderIDs.Length - 1);
                }
                CheckImportFilesInFolder(FolderID, m_sFileCabinetDocFile, path, rootFileInfo, ArrayFolderIDs);
            }
        }

        int FileCount = 0;
        public void CheckImportFilesInFolder(string FolderID, string m_sFileCabinetDocFile, string path, string rootFileInfo, string ArraysFolderID)
        {
            FileCount = 0;

            DataTable getSubFolderNames = new DataTable();

            if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
            {
                DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getSubFolderNames = drResult.CopyToDataTable();
                }
            }
            else
            {
                DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getSubFolderNames = drResult.CopyToDataTable();
                }
            }

            if (getSubFolderNames.HasErrors != null && getSubFolderNames.Rows.Count > 0)
            {
                if (getSubFolderNames.Rows.Count > 1)
                {
                    foreach (DataRow dr in getSubFolderNames.Rows)
                    {
                        string[] rows = ArraysFolderID.Split(',');
                        //DataRow dr = getSubFolderNames.resultDS.Tables[0].Rows[0];
                        string FolderId = dr["Folder_ID"].ToString();
                        string FolderName = dr["Folder_Name"].ToString().ToUpper();

                        for (int i = 0; i < rows.Length; i++)
                        {
                            if (FolderId == rows[i])
                            {
                                m_sImportedFolderDocFile = null;

                                if (m_sImportedFolderDocFile == null)
                                {
                                    m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + FolderName;
                                    if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                                        System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                                }
                                m_sFileCabinetDocFile = m_sImportedFolderDocFile;

                                CheckImportFilesInFolder(FolderId, m_sFileCabinetDocFile, path, rootFileInfo, ArraysFolderID);
                            }

                            if (FolderId == treeView1.SelectedNode.Name)
                            {
                                FileCount += 1;
                                if (FileCount == 1)
                                {
                                    m_sImportedFolderDocFile = null;

                                    if (m_sImportedFolderDocFile == null)
                                    {
                                        m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + treeView1.SelectedNode.Text;
                                        if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                                            System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                                    }
                                    m_sFileCabinetDocFile = m_sImportedFolderDocFile;
                                    System.IO.File.Copy(path, m_sFileCabinetDocFile + "\\" + rootFileInfo, true);

                                    // inserting files into documentslist table //

                                    MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                                    NandanaResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), rootFileInfo, "Manual");
                                    if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
                                    {
                                        DataRow drdoc = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                                        DocumentID = drdoc["DocumentId"].ToString();
                                    }

                                    // End

                                    //* inserting files details in Files table *//

                                    if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                                    {
                                        NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(treeView1.SelectedNode.Name),Convert.ToInt32(treeView1.SelectedNode.Parent.Name), rootFileInfo, m_sFileCabinetDocFile + "\\" + rootFileInfo, "True");
                                        if (objinsertfilesdetails.resultDS != null && objinsertfilesdetails.resultDS.Tables[0].Rows.Count > 0)
                                        {
                                            DataRow drfile = objinsertfilesdetails.resultDS.Tables[0].Rows[0];
                                            FileID = drfile["FileId"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(treeView1.SelectedNode.Name),Convert.ToInt32(treeView1.SelectedNode.Parent.Parent.Name), rootFileInfo, m_sFileCabinetDocFile + "\\" + rootFileInfo, "True");
                                        if (objinsertfilesdetails.resultDS != null && objinsertfilesdetails.resultDS.Tables[0].Rows.Count > 0)
                                        {
                                            DataRow drfile = objinsertfilesdetails.resultDS.Tables[0].Rows[0];
                                            FileID = drfile["FileId"].ToString();
                                        }
                                    }
                                    
                                    //* End  *//



                                    TreeNode newNode = new TreeNode();
                                    newNode.Text = rootFileInfo;
                                    newNode.Name = FileID;
                                    newNode.ContextMenuStrip = FileContextMenu;
                                    string[] FileType = rootFileInfo.ToString().Split('.');
                                    string value = FileType[1].ToString().ToUpper();
                                    // ... Switch on the string.
                                    switch (value)
                                    {
                                        case "PDF":
                                            newNode.ImageKey = "PDFIcon.png";
                                            newNode.SelectedImageKey = "PDFIcon.png";
                                            break;
                                        case "JPG":
                                            newNode.ImageKey = "JPGIcon.png";
                                            newNode.SelectedImageKey = "JPGIcon.png";
                                            break;
                                        case "PNG":
                                            newNode.ImageKey = "JPGIcon.png";
                                            newNode.SelectedImageKey = "JPGIcon.png";
                                            break;
                                        case "BMP":
                                            newNode.ImageKey = "JPGIcon.png";
                                            newNode.SelectedImageKey = "JPGIcon.png";
                                            break;
                                        case "GIF":
                                            newNode.ImageKey = "JPGIcon.png";
                                            newNode.SelectedImageKey = "JPGIcon.png";
                                            break;
                                        case "TIF":
                                            newNode.ImageKey = "JPGIcon.png";
                                            newNode.SelectedImageKey = "JPGIcon.png";
                                            break;
                                        case "TIFF":
                                            newNode.ImageKey = "JPGIcon.png";
                                            newNode.SelectedImageKey = "JPGIcon.png";
                                            break;
                                        default:
                                            newNode.ImageKey = "TXTIcon.png";
                                            newNode.SelectedImageKey = "TXTIcon.png";
                                            break;
                                    }
                                    treeView1.SelectedNode.Nodes.Add(newNode);
                                }
                            }
                        }

                    }

                }
                else
                {
                    DataRow dr = getSubFolderNames.Rows[0];

                    string FolderId = dr["Folder_ID"].ToString();
                    string FolderName = dr["Folder_Name"].ToString().ToUpper();

                    m_sImportedFolderDocFile = null;

                    if (m_sImportedFolderDocFile == null)
                    {
                        m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + FolderName;
                        if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                            System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                    }
                    m_sFileCabinetDocFile = m_sImportedFolderDocFile;
                    if (FolderId == treeView1.SelectedNode.Name)
                    {
                       
                        System.IO.File.Copy(path, m_sFileCabinetDocFile + "\\" + rootFileInfo, true);
                        //CheckCreateFolder(FolderId, m_sFileCabinetDocFile);


                        // inserting files into documentslist table //

                        MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
                        NandanaResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), rootFileInfo, "Manual");
                        if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
                        {
                            DataRow drdoc = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                            DocumentID = drdoc["DocumentId"].ToString();
                        }

                        // End

                        //* inserting files details in Files table *//

                        if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                        {
                            NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(treeView1.SelectedNode.Name),Convert.ToInt32(treeView1.SelectedNode.Parent.Name), rootFileInfo, m_sFileCabinetDocFile + "\\" + rootFileInfo, "True");
                            if (objinsertfilesdetails.resultDS != null && objinsertfilesdetails.resultDS.Tables[0].Rows.Count > 0)
                            {
                                DataRow drfile = objinsertfilesdetails.resultDS.Tables[0].Rows[0];
                                FileID = drfile["FileId"].ToString();
                            }
                        }
                        else
                        {
                            NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(treeView1.SelectedNode.Name),Convert.ToInt32(treeView1.SelectedNode.Parent.Parent.Name), rootFileInfo, m_sFileCabinetDocFile + "\\" + rootFileInfo, "True");
                            if (objinsertfilesdetails.resultDS != null && objinsertfilesdetails.resultDS.Tables[0].Rows.Count > 0)
                            {
                                DataRow drfile = objinsertfilesdetails.resultDS.Tables[0].Rows[0];
                                FileID = drfile["FileId"].ToString();
                            }
                        }

                        //* End  *//


                        TreeNode newNode = new TreeNode();
                        newNode.Text = rootFileInfo;
                        newNode.Name = FileID;
                        newNode.ContextMenuStrip = FileContextMenu;
                        string[] FileType = rootFileInfo.ToString().Split('.');
                        string value = FileType[1].ToString().ToUpper();
                        // ... Switch on the string.
                        switch (value)
                        {
                            case "PDF":
                                newNode.ImageKey = "PDFIcon.png";
                                newNode.SelectedImageKey = "PDFIcon.png";
                                break;
                            case "JPG":
                                newNode.ImageKey = "JPGIcon.png";
                                newNode.SelectedImageKey = "JPGIcon.png";
                                break;
                            case "PNG":
                                newNode.ImageKey = "JPGIcon.png";
                                newNode.SelectedImageKey = "JPGIcon.png";
                                break;
                            case "BMP":
                                newNode.ImageKey = "JPGIcon.png";
                                newNode.SelectedImageKey = "JPGIcon.png";
                                break;
                            case "GIF":
                                newNode.ImageKey = "JPGIcon.png";
                                newNode.SelectedImageKey = "JPGIcon.png";
                                break;
                            case "TIF":
                                newNode.ImageKey = "JPGIcon.png";
                                newNode.SelectedImageKey = "JPGIcon.png";
                                break;
                            case "TIFF":
                                newNode.ImageKey = "JPGIcon.png";
                                newNode.SelectedImageKey = "JPGIcon.png";
                                break;
                            default:
                                newNode.ImageKey = "TXTIcon.png";
                                newNode.SelectedImageKey = "TXTIcon.png";
                                break;
                        }
                        treeView1.SelectedNode.Nodes.Add(newNode);
                    }
                    else
                    {
                        CheckImportFilesInFolder(FolderId, m_sFileCabinetDocFile, path, rootFileInfo, ArraysFolderID);
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            treeView1.SelectedNode.Remove();
        }

        private void ImportFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = string.Empty;
            treeView1.HideSelection = false;
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Select a folder which has files";
            fd.ShowNewFolderButton = true;
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Path = fd.SelectedPath;

                ListDirectory(treeView1, Path);
            }
            else
            {
                Path = "";
            }
        }

        string FileArray = string.Empty;
        string FilePathArray = string.Empty;
        private void ImportFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fdFileName = string.Empty;
            treeView1.HideSelection = false;
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
                    ListFiles(treeView1, fd.FileNames[i]);
                }

                DeclareFolderDatagridviewColumns();
            }
        }

        private void ExpandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Expand();
        }

        private void CollaspeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Collapse();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Refresh();
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.HighlightText, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TempNodeText = string.Empty;
            EnterText frm = new EnterText();
            //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.HideSelection = false; 
            
            frm.CurrentFolderName = treeView1.SelectedNode.Text.ToUpper();
            frm.FileCabinetID = treeView1.SelectedNode.Name;
            frm.ShowDialog();
            if (frm.FolderName != null)
            {
                TempNodeText = frm.FolderName.ToUpper();
            }
            else
            {
                TempNodeText = frm.FolderName;
            }
            frm.Dispose();
            if ((TempNodeText != null))
            {

                m_sConfigFile = null;
                m_sFileCabinetDocFile = null;
                m_sImportedFolderDocFile = null;

                if (m_sConfigFile == null)
                {
                    m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                    if (!System.IO.Directory.Exists(m_sConfigFile))
                        System.IO.Directory.CreateDirectory(m_sConfigFile);
                }

                if (m_sFileCabinetDocFile == null)
                {
                    m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();
                    if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                        System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
                }

                if (m_sImportedFolderDocFile == null)
                {
                    m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + TempNodeText.ToUpper();
                    if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                        System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                }

                //FolderManager objFolderManager = new FolderManager();

                TreeNode newNode = new TreeNode();
                newNode.Text = TempNodeText;

                //* inserting Folder details in Folder table *//

                NandanaResult objInsertFolderdetails = objFolderManager.InsertFolderDetails(treeView1.SelectedNode.Name, TempNodeText.ToUpper(), "0", "True");
                if (objInsertFolderdetails.resultDS != null && objInsertFolderdetails.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = objInsertFolderdetails.resultDS.Tables[0].Rows[0];
                    FolderID = dr["FolderId"].ToString();
                }

                //* End  *//

                newNode.Name = FolderID;

                newNode.ContextMenuStrip = FolderContextMenu;
                newNode.ImageKey = "FolderIcon.png";
                newNode.SelectedImageKey = "FolderIcon.png";

                //newNode.ImageKey = "Folder.jpg";
                //newNode.SelectedImageKey = "Folder.jpg";
                treeView1.SelectedNode.Nodes.Add(newNode);
                treeView1.SelectedNode.Expand();

                DeclareFolderDatagridviewColumns();
            }
        }

        private void SaveImportingFolder(string folderName, string Path) // THis is implemented by nishanth for folder import
        {
            string TempNodeText = string.Empty;
            //EnterText frm = new EnterText();
            //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.HideSelection = false;

            //frm.CurrentFolderName = treeView1.SelectedNode.Text.ToUpper();
            //frm.FileCabinetID = treeView1.SelectedNode.Name;
            //frm.ShowDialog();
            TempNodeText = folderName;
            //if (folderName != null)
            //{
            //    TempNodeText = frm.FolderName.ToUpper();
            //}
            //else
            //{
            //    TempNodeText = frm.FolderName;
            //}
            //frm.Dispose();
            if ((TempNodeText != null))
            {

                m_sConfigFile = null;
                m_sFileCabinetDocFile = null;
                m_sImportedFolderDocFile = null;

                if (m_sConfigFile == null)
                {
                    m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                    if (!System.IO.Directory.Exists(m_sConfigFile))
                        System.IO.Directory.CreateDirectory(m_sConfigFile);
                }

                if (m_sFileCabinetDocFile == null)
                {
                    m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();
                    if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                        System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
                }

                if (m_sImportedFolderDocFile == null)
                {
                    m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + TempNodeText.ToUpper();
                    if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                        System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                }

                //FolderManager objFolderManager = new FolderManager();

                TreeNode newNode = new TreeNode();
                newNode.Text = TempNodeText;

                //We need to properly get filecabinetid
                string fileCabinetID = treeView1.SelectedNode.Parent.Name == string.Empty ? treeView1.SelectedNode.Name : treeView1.SelectedNode.Parent.Name;

                //* inserting Folder details in Folder table *//

                NandanaResult objInsertFolderdetails = objFolderManager.InsertFolderDetails(fileCabinetID, TempNodeText.ToUpper(), treeView1.SelectedNode.Name, "True");
                if (objInsertFolderdetails.resultDS != null && objInsertFolderdetails.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = objInsertFolderdetails.resultDS.Tables[0].Rows[0];
                    FolderID = dr["FolderId"].ToString();
                }

                //* End  *//
                if (string.IsNullOrEmpty(FolderID))
                { 
                 MessageBox.Show("FolderID is Empty !!");
                }
                newNode.Name = FolderID;

                newNode.ContextMenuStrip = FolderContextMenu;
                newNode.ImageKey = "FolderIcon.png";
                newNode.SelectedImageKey = "FolderIcon.png";

                //newNode.ImageKey = "Folder.jpg";
                //newNode.SelectedImageKey = "Folder.jpg";

                


                SaveImportingFolderFiles(treeView1, Path, FolderID, treeView1.SelectedNode.Parent.Name, newNode);

                
                var rootDirectoryInfo = new DirectoryInfo(Path);
                foreach (var file in rootDirectoryInfo.GetFiles())
                {
                    ListFiles1(treeView1, file.FullName, newNode, FolderID, fileCabinetID);
                }
                if (newNode.Name != string.Empty)
                {
                    treeView1.SelectedNode.Nodes.Add(newNode);
                }

                
            }
        }

        private void SaveImportingFolderFiles(TreeView treeView, string path, string FolderID, string fileCabinetId, TreeNode newNode)
        {
            m_sConfigFile = null;
            m_sFileCabinetDocFile = null;
            m_sImportedFolderDocFile = null;

            if (m_sConfigFile == null)
            {
                m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                if (!System.IO.Directory.Exists(m_sConfigFile))
                    System.IO.Directory.CreateDirectory(m_sConfigFile);
            }

            if (m_sFileCabinetDocFile == null)
            {
                m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();
                if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                    System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
            }

            //FolderManager objFolderManager = new FolderManager();
            //FilesManager objFilesManager = new FilesManager();

            var rootDirectoryInfo = new DirectoryInfo(path);

            var directoryNode = new TreeNode(rootDirectoryInfo.Name);
            directoryNode.Name = FolderID;

            newNode.Name = FolderID;

            if (m_sImportedFolderDocFile == null)
            {
                m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + rootDirectoryInfo.Name.ToUpper();
                if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                    System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
            }

            //* inserting Folder details in Folder table *//

            //NandanaResult objinsertintofolder = objFolderManager.InsertFolderDetails(strRootNodeID, rootDirectoryInfo.Name.ToUpper(), "0", "True");
            //if (objinsertintofolder.resultDS != null && objinsertintofolder.resultDS.Tables[0].Rows.Count > 0)
            //{
            //    DataRow dr = objinsertintofolder.resultDS.Tables[0].Rows[0];
            //    FolderID = dr["FolderId"].ToString();
            //}

            //* End  *//

            foreach (var file in rootDirectoryInfo.GetFiles())
            {
                System.IO.File.Copy(path + "\\" + file.Name, m_sImportedFolderDocFile + "\\" + file.Name, true);

                //* inserting files details in Files table *//

                NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(FolderID), Convert.ToInt32(fileCabinetId), file.Name, m_sImportedFolderDocFile + "\\" + file.Name, "True");

                //* End  *//

                //directoryNode.Nodes.Add(new TreeNode(file.Name));
                
                
                //newNode.Nodes.Add(new TreeNode(file.Name));
            }

            foreach (TreeNode ChildNode in directoryNode.Nodes)
            {
                //ChildNode.ContextMenuStrip = FileContextMenu;
                
                
                
                
                //ChildNode.ImageKey = "File.png";
                //ChildNode.SelectedImageKey = "File.png";

            }

           // treeView.SelectedNode.Nodes.Add(directoryNode);
           // directoryNode.ContextMenuStrip = FolderContextMenu;
            //directoryNode.ImageKey = "FolderIcon.png";
            //directoryNode.SelectedImageKey = "FolderIcon.png";

            //treeView.SelectedNode.Expand();
        }

        private void ListFiles1(TreeView treeView, string path, TreeNode newNode1, string FolderID, string fileCabinetID)
        {
            m_sConfigFile = null;
            m_sFileCabinetDocFile = null;
            m_sImportedFolderDocFile = null;

            if (m_sConfigFile == null)
            {
                m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                if (!System.IO.Directory.Exists(m_sConfigFile))
                    System.IO.Directory.CreateDirectory(m_sConfigFile);
            }

            if (m_sFileCabinetDocFile == null)
            {
                m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();
                if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                    System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
            }

            //FilesManager objFilesManager = new FilesManager();
            var rootFileInfo = new FileInfo(path);

            TreeNode newNode = new TreeNode();
            newNode.Text = rootFileInfo.Name;


            //treeView.SelectedNode.Nodes.Add((rootFileInfo.Name));

            System.IO.File.Copy(path, m_sFileCabinetDocFile + "\\" + rootFileInfo.Name, true);


            // inserting files into documentslist table //

            MoveMyFilesManager objMoveMyFilesManager = new MoveMyFilesManager();
            NandanaResult insertdocumentdetails = objMoveMyFilesManager.InsertDocumentlistDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), rootFileInfo.Name, "Manual");
            if (insertdocumentdetails.resultDS != null && insertdocumentdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = insertdocumentdetails.resultDS.Tables[0].Rows[0];
                DocumentID = dr["DocumentId"].ToString();
            }

            // End

            //* inserting files details in Files table *//

            NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(FolderID), Convert.ToInt32(fileCabinetID), rootFileInfo.Name, m_sFileCabinetDocFile + "\\" + rootFileInfo.Name, "True");
            if (objinsertfilesdetails.resultDS != null && objinsertfilesdetails.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = objinsertfilesdetails.resultDS.Tables[0].Rows[0];
                FileID = dr["FileId"].ToString();
            }

            //* End  *//


            newNode.Name = FileID;
            newNode.ContextMenuStrip = FileContextMenu;
            string[] FileType = rootFileInfo.Name.ToString().Split('.');

            string value = FileType[1].ToString().ToUpper();
            // ... Switch on the string.
            switch (value)
            {
                case "PDF":
                    newNode.ImageKey = "PDFIcon.png";
                    newNode.SelectedImageKey = "PDFIcon.png";
                    break;
                case "JPG":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "PNG":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "BMP":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "GIF":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "TIF":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                case "TIFF":
                    newNode.ImageKey = "JPGIcon.png";
                    newNode.SelectedImageKey = "JPGIcon.png";
                    break;
                default:
                    newNode.ImageKey = "TXTIcon.png";
                    newNode.SelectedImageKey = "TXTIcon.png";
                    break;
            }

            ///treeView.SelectedNode.Nodes.Remove 
            newNode1.Nodes.Add(newNode);

           // treeView.SelectedNode.Expand();
        }

        private void NewFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string TempNodeText = string.Empty;
            EnterText frm = new EnterText();
            treeView1.HideSelection = false;
            frm.CurrentFolderName = treeView1.SelectedNode.Text;
            if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
            {
                frm.FileCabinetID = treeView1.SelectedNode.Parent.Name;
            }
            //else
            //{
            //    frm.FileCabinetID = treeView1.SelectedNode.Parent.Parent.Name;
            //}
            frm.FolderID = treeView1.SelectedNode.Name;
            frm.ShowDialog();
            if (frm.FolderName != null)
            {
                TempNodeText = frm.FolderName.ToUpper();
            }
            else
            {
                TempNodeText = frm.FolderName;
            }
            
            frm.Dispose();

            if ((TempNodeText != null))
            {
                m_sConfigFile = null;
                m_sFileCabinetDocFile = null;
                //m_sImportedFolderDocFile = null;
                //m_sImportedSubFolderDocFile = null;

                if (m_sConfigFile == null)
                {
                    m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                    if (!System.IO.Directory.Exists(m_sConfigFile))
                        System.IO.Directory.CreateDirectory(m_sConfigFile);
                }

                if (m_sFileCabinetDocFile == null)
                {
                    if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                    {
                        m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Parent.Text;
                    }
                    else
                    {
                        m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Parent.Parent.Text;
                    }
                    if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                        System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);
                }


                ArrayFolderIDs = string.Empty;
                CreateFolder(treeView1.SelectedNode.Name, m_sFileCabinetDocFile, TempNodeText);


                //FolderManager objFolderManager = new FolderManager();


                TreeNode newNode = new TreeNode();
                newNode.Text = TempNodeText;

                //* inserting Folder details in Folder table *//

                if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                {
                    NandanaResult objInsertFolderdetails = objFolderManager.InsertFolderDetails(treeView1.SelectedNode.Parent.Name, TempNodeText.ToUpper(), treeView1.SelectedNode.Name, "True");
                    if (objInsertFolderdetails.resultDS != null && objInsertFolderdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = objInsertFolderdetails.resultDS.Tables[0].Rows[0];
                        FolderID = dr["FolderId"].ToString();
                    }
                }
                else
                {
                    NandanaResult objInsertFolderdetails = objFolderManager.InsertFolderDetails(treeView1.SelectedNode.Parent.Parent.Name, TempNodeText.ToUpper(), treeView1.SelectedNode.Name, "True");
                    if (objInsertFolderdetails.resultDS != null && objInsertFolderdetails.resultDS.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = objInsertFolderdetails.resultDS.Tables[0].Rows[0];
                        FolderID = dr["FolderId"].ToString();
                    }
                }

                //* End  *//

                newNode.Name = FolderID;

                newNode.ContextMenuStrip = FolderContextMenu;
                newNode.ImageKey = "FolderIcon.png";
                newNode.SelectedImageKey = "FolderIcon.png";

                //newNode.ImageKey = "Folder.jpg";
                //newNode.SelectedImageKey = "Folder.jpg";
                treeView1.SelectedNode.Nodes.Add(newNode);
                treeView1.SelectedNode.Expand();

                if (strRootNode != null)
                {
                    GetFolderAndFileDetails();
                }
                else
                {
                    GetAllFolderAndFileDetailsOfFileCabinets();
                }

                //this.treeView1.AfterSelect += new TreeViewEventHandler(this.treeView1_AfterSelect);
            }
        }

        string ArrayFolderIDs = string.Empty;
        public void CreateFolder(string FolderID, string m_sFileCabinetDocFile, string TempNodeText)
        {
            NandanaResult objgetfolderdetails = objFolderManager.GetFolderDetails();

            DataTable getMainFolderNames = new DataTable();
            if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
            {

                DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("Folder_ID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getMainFolderNames = drResult.CopyToDataTable();
                }

            }

            
            if (getMainFolderNames.HasErrors != null && getMainFolderNames.Rows.Count > 0)
            {
                DataRow dr = getMainFolderNames.Rows[0];
                string ParentFolderID = dr["ParentFolderID"].ToString();
                ArrayFolderIDs = ArrayFolderIDs + ParentFolderID + ',';
                CreateFolder(ParentFolderID, m_sFileCabinetDocFile, TempNodeText);
            }
            else
            {
                if (ArrayFolderIDs.Length > 0)
                {
                    ArrayFolderIDs = ArrayFolderIDs.Substring(0, ArrayFolderIDs.Length - 1);
                }
                CheckCreateFolder(FolderID, m_sFileCabinetDocFile, TempNodeText, ArrayFolderIDs);
            }
        }

        int Count = 0;
        public void CheckCreateFolder(string FolderID, string m_sFileCabinetDocFile, string TempNodeText, string ArraysFolderID)
        {
            DataTable getSubFolderNames = new DataTable();

            if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
            {
                DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getSubFolderNames = drResult.CopyToDataTable();
                }
            }
            else
            {
                DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getSubFolderNames = drResult.CopyToDataTable();
                }
            }

            if (getSubFolderNames.HasErrors != null && getSubFolderNames.Rows.Count > 0)
            {

                if (getSubFolderNames.Rows.Count > 1)
                {
                    foreach (DataRow dr in getSubFolderNames.Rows)
                    {
                        string[] rows = ArraysFolderID.Split(',');
                        //DataRow dr = getSubFolderNames.resultDS.Tables[0].Rows[0];
                        string FolderId = dr["Folder_ID"].ToString();
                        string FolderName = dr["Folder_Name"].ToString();

                        for (int i = 0; i < rows.Length; i++)
                        {
                            if (FolderId == rows[i])
                            {
                                m_sImportedFolderDocFile = null;

                                if (m_sImportedFolderDocFile == null)
                                {
                                    m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + FolderName;
                                    if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                                        System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                                }
                                m_sFileCabinetDocFile = m_sImportedFolderDocFile;

                                CheckCreateFolder(FolderId, m_sFileCabinetDocFile, TempNodeText, ArraysFolderID);
                            }

                            if (FolderId == treeView1.SelectedNode.Name)
                            {
                                Count += 1;
                                if (Count == 1)
                                {
                                    m_sImportedFolderDocFile = null;

                                    if (m_sImportedFolderDocFile == null)
                                    {
                                        m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + treeView1.SelectedNode.Text;
                                        if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                                            System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                                    }

                                    m_sImportedSubFolderDocFile = null;

                                    if (m_sImportedSubFolderDocFile == null)
                                    {
                                        m_sImportedSubFolderDocFile = m_sImportedFolderDocFile + "\\" + TempNodeText;
                                        if (!System.IO.Directory.Exists(m_sImportedSubFolderDocFile))
                                            System.IO.Directory.CreateDirectory(m_sImportedSubFolderDocFile);
                                    }
                                }
                            }
                        }

                    }

                }
                else
                {
                    DataRow dr = getSubFolderNames.Rows[0];

                    string FolderId = dr["Folder_ID"].ToString();
                    string FolderName = dr["Folder_Name"].ToString();

                    m_sImportedFolderDocFile = null;

                    if (m_sImportedFolderDocFile == null)
                    {
                        m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + FolderName;
                        if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                            System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                    }
                    m_sFileCabinetDocFile = m_sImportedFolderDocFile;
                    if (FolderId == treeView1.SelectedNode.Name)
                    {
                        m_sImportedFolderDocFile = null;

                        if (m_sImportedFolderDocFile == null)
                        {
                            m_sImportedFolderDocFile = m_sFileCabinetDocFile + "\\" + TempNodeText;
                            if (!System.IO.Directory.Exists(m_sImportedFolderDocFile))
                                System.IO.Directory.CreateDirectory(m_sImportedFolderDocFile);
                        }
                    }
                    else
                    {
                        CheckCreateFolder(FolderId, m_sFileCabinetDocFile, TempNodeText, ArraysFolderID);
                    }
                }
            }
        }

        private void ExpandToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Expand();
        }

        string DeleteFolderIDs = string.Empty;
        string DeleteFilesIDs = string.Empty;
        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteConfirmation objDeleteConfirmation = new DeleteConfirmation();
            objDeleteConfirmation.ShowDialog();

            if (objDeleteConfirmation.DeleteConfirmationRequest == "Yes")
            {
                NandanaResult deletefolders = objFolderManager.DeleteFolderDetails(treeView1.SelectedNode.Name, "False");

                treeView1.SelectedNode.Remove();
            }
        }

        public void DeleteSelectedFolderAlongWithFiles(string FolderID)
        {
            DataTable objgetsubfolders = new DataTable();
            DataTable objgetFiles = new DataTable();


            if (DtFolders.Rows.Count > 0)
            {
                if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                {
                    DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");

                    if (drResult.Count() != 0)
                    {
                        objgetsubfolders = drResult.CopyToDataTable();
                    }
                }
                else
                {
                    DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " ParentFolderID = '" + FolderID + "'" + "and" + " IsDelete = '" + "True" + "'");

                    if (drResult.Count() != 0)
                    {
                        objgetsubfolders = drResult.CopyToDataTable();
                    }
                }
            }


            if (DtFiles.Rows.Count > 0)
            {
                if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                {
                    DataRow[] drResult = DtFiles.Select("Folder_ID = '" + FolderID + "'" + "and" + " FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                    if (drResult.Count() != 0)
                    {
                        objgetFiles = drResult.CopyToDataTable();
                    }
                }
                else
                {
                    DataRow[] drResult = DtFiles.Select("Folder_ID = '" + FolderID + "'" + "and" + " FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                    if (drResult.Count() != 0)
                    {
                        objgetFiles = drResult.CopyToDataTable();
                    }
                }
            }
            
            if (objgetFiles.HasErrors != null && objgetFiles.Rows.Count > 0)
            {
                foreach (DataRow dr in objgetFiles.Rows)
                {
                    string FileId = dr["File_ID"].ToString();
                    DeleteFilesIDs = DeleteFilesIDs + FileId + ',';

                    NandanaResult deletefiles = objFilesManager.DeleteFileDetails(FileId, "False");
                }
            }
            DataTable dtchildc = new DataTable();
            if (objgetsubfolders.HasErrors != null && objgetsubfolders.Rows.Count > 0)
            {
                dtchildc = objgetsubfolders;
                //TreeNode childNode;
                foreach (DataRow dr in dtchildc.Rows)
                {
                    string FolderId = dr["Folder_ID"].ToString();

                    DeleteFolderIDs = DeleteFolderIDs + FolderId + ',';

                    NandanaResult deletefolders = objFolderManager.DeleteFolderDetails(FolderId, "False");

                    DeleteSelectedFolderAlongWithFiles((dr["Folder_ID"].ToString()));
                }
            }
        }

        private void RenameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string TempNodeText = string.Empty;
            EnterText frm = new EnterText();
            treeView1.HideSelection = false;
            frm.CurrentFolderName = treeView1.SelectedNode.Text;
            if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
            {
                frm.FileCabinetID = treeView1.SelectedNode.Parent.Name;
            }
            else
            {
                frm.FileCabinetID = treeView1.SelectedNode.Parent.Parent.Name;
            }
            frm.FolderID = treeView1.SelectedNode.Name;
            frm.ShowDialog();
            if (frm.FolderName != null)
            {
                TempNodeText = frm.FolderName.ToUpper();
            }
            else
            {
                TempNodeText = frm.FolderName;
            }
            frm.Dispose();
            string originalName = string.Empty;
            originalName = treeView1.SelectedNode.Text;
            TreeNode SelectedNode = treeView1.SelectedNode;
            if ((TempNodeText != null))
            {
                SelectedNode.Text = TempNodeText;

                NandanaResult updateFolderName = objFolderManager.UpdateFolderNameDetails(treeView1.SelectedNode.Name,TempNodeText.ToUpper());
            }
            string folderID = string.Empty;
            string fileCabinetID = string.Empty;
            string fileCabinetName = string.Empty;
            string filePath = string.Empty;
            string fileName = string.Empty;
            string fileID = string.Empty;
            if (DtFiles != null)
            {
                if (DtFiles.Rows.Count > 0)
                {
                    if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")//Nishanth Needs to understand if this IF condition is for folders rename and the below ELSE is for FILE RENAME
                    {
                        DataRow[] drResult = DtFiles.Select("Folder_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                        DirectoryInfo dinfo = Directory.GetParent(Path.GetDirectoryName(drResult[0]["File_Path"].ToString()));
                        Directory.SetCurrentDirectory(dinfo.FullName);
                        if (drResult.Count() != 0 && Directory.Exists(originalName))//Nishanth Folder Name Change
                        {
                            Directory.Move(originalName, TempNodeText);
                            foreach (DataRow dataRow in drResult)
                            {
                                filePath = dataRow["File_Path"].ToString();
                                fileName = dataRow["File_Name"].ToString();
                                fileID = dataRow["File_ID"].ToString();
                                folderID = treeView1.SelectedNode.Name;
                                fileCabinetID = treeView1.SelectedNode.Parent.Name;
                                fileCabinetName = treeView1.SelectedNode.Parent.Text;
                                
                                filePath = Directory.GetCurrentDirectory() + "\\" + TempNodeText + "\\" + fileName;
                                objFilesManager.UpdateFileDetailsFileID(Convert.ToInt32(fileID), filePath);
                            }
                        }
                    }
                    else
                    {
                        DataRow[] drResult = DtFiles.Select("Folder_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            filePath = drResult[0]["File_Path"].ToString();
                            fileName = drResult[0]["File_Name"].ToString();
                            fileID = drResult[0]["File_ID"].ToString();
                        }
                        folderID = treeView1.SelectedNode.Name;
                        fileCabinetID = treeView1.SelectedNode.Parent.Parent.Name;
                        fileCabinetName = treeView1.SelectedNode.Parent.Parent.Text;
                    }
                }

                
            }

            
            //Directory.Move();


            //RenameToolStripTextBox.Text = treeView1.SelectedNode.Text;
            //treeView1.SelectedNode.Text = "abc";--
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //
            // Get the selected node.
            //
            TreeNode node = treeView1.SelectedNode;
            //
            // Render message box.
            treeView1.HideSelection = false;
            //
            MessageBox.Show(string.Format("You selected: {0}", node.Text));
        }

        private void ImportFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string fdFileName = string.Empty;

            OpenFileDialog fd = new OpenFileDialog();
            treeView1.HideSelection = false;
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fd.FilterIndex = 2;
            fd.RestoreDirectory = true;
            fd.Multiselect = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fd.FileNames.Length; i++)
                {
                    ListSubFiles(treeView1, fd.FileNames[i]);
                    //fdFileName = (fd.FileName);

                    //ListSubFiles(treeView1, fdFileName);


                }

                if (strRootNode != null)
                {
                    GetFolderAndFileDetails();
                }
                else
                {
                    GetAllFolderAndFileDetailsOfFileCabinets();
                }
            }
        }
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        private void ImportFoldersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string Path = string.Empty;
            string FolderID;
            treeView1.HideSelection = false;
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Select a folder which has files";
            fd.ShowNewFolderButton = true;
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Path = fd.SelectedPath;
               

                object sender1 = new object();//Nishanth Import Folder task changes start
                EventArgs e1 = new EventArgs();
                //NewFolderToolStripMenuItem_Click(sender, e);//Nishanth Import Folder task changes end

                string folderName = Path.Split('\\')[Path.Split('\\').Count() - 1];

                var rootDirectoryInfo = new DirectoryInfo(Path);
                WalkDirectoryTree(rootDirectoryInfo, treeView1.SelectedNode.Parent.Name, treeView1.SelectedNode.Name);// FOr folder import this is working just awesome. Need to proceed with this. Please note that below mentioned approach is commented.

                //LoadTreeview(treeView1.SelectedNode.Name, treeView1.SelectedNode.Text);
                //SaveImportingFolder(folderName, Path);// After Building WalkTreeDirectory. This method is obsolete. Need to remove Nishanth.

                treeView1.Nodes.Clear();
                DashBoardHome_Load(sender, e);//Loading entire tree view is very bad. Need to figure out smart way . to just refresh added nodes. NISHANTH.
            }
            else
            {
                Path = "";
            }
        }

        private void WalkDirectoryTree(System.IO.DirectoryInfo root,string fileCabinetID, string parentFolderID)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            string FolderID = string.Empty;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
                //string fileCabinetID = treeView1.SelectedNode.Parent.Name;
                string folderName = root.Name;
                //string FolderID;
                //string parentFolderID = treeView1.SelectedNode.Name; //Selected folder will be the parent of the folder which we are importing.

                NandanaResult objinsertintofolder = objFolderManager.InsertFolderDetails(fileCabinetID, folderName, parentFolderID, "True");
                if (objinsertintofolder.resultDS != null && objinsertintofolder.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = objinsertintofolder.resultDS.Tables[0].Rows[0];
                    FolderID = dr["FolderId"].ToString();
                    foreach (FileInfo f in files)
                    {
                        NandanaResult objinsertfilesdetails = objFilesManager.InsertFileDetails(Convert.ToInt32(FolderID), Convert.ToInt32(fileCabinetID), f.Name,f.FullName, "True");
                    }
                }
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    //Console.WriteLine(fi.FullName);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo, fileCabinetID, FolderID);
                }
            }
        }

        private void DeleteFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteConfirmation objDeleteConfirmation = new DeleteConfirmation();
            objDeleteConfirmation.ShowDialog();

            if (objDeleteConfirmation.DeleteConfirmationRequest == "Yes")
            {
                
                NandanaResult DeleteFiles = objFilesManager.DeleteFileDetails(treeView1.SelectedNode.Name, "False");

                treeView1.SelectedNode.Remove();
            }
        }

        private void MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Folder level Move
            
            TreeNode node = treeView1.SelectedNode;
            treeView1.HideSelection = false;
            //
            //foreach (TreeNode n in treeView1.SelectedNodes)
            //{
            //    MessageBox.Show(string.Format("You selected: {0}", n.Text));                
            //} 

            MoveFiles MF = new MoveFiles();

            
            DialogResult DlgResult = MF.ShowDialog();

            string Cabinet = MF.GetCabinet;
            string Folder = MF.GetFolder;

            //MessageBox.Show(string.Format("You selected: {0}", Cabinet));
            //MessageBox.Show(string.Format("You selected: {0}", Folder));    

            int SelectedCabinetID = 0;

            if (DlgResult == DialogResult.OK)
            {
                //MessageBox.Show("Ok");
                foreach (TreeNode n in treeView1.SelectedNodes)
                {
                    //MessageBox.Show(string.Format("You selected: {0}", n.Text));
                    // Get folder cabinet number
                    try
                    {
                        DataTable DtMainFolders = new DataTable();

                        if (DtFolders != null)
                        {
                            if (DtFolders.Rows.Count > 0)
                            {
                                DataRow[] drResult = DtFolders.Select("Folder_Name = '" + n.Text + "'");
                                if (drResult.Count() != 0)
                                {
                                    DtMainFolders = drResult.CopyToDataTable();
                                }

                                if (DtMainFolders.HasErrors != null && DtMainFolders.Rows.Count > 0)
                                {
                                    TreeNode parentNode = new TreeNode();

                                    foreach (DataRow dr in DtMainFolders.Rows)
                                    {

                                        // Cabinet => move to
                                        // n.Name => move from
                                        NandanaResult objinsertfilesdetails = objFilesManager.UpdateFolderCabinet(Cabinet, n.Text);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    int FolderID = 0;
                    foreach (TreeNode SubNode in n.Nodes)
                    {
                 
                        m_sConfigFile = null;
                        m_sFileCabinetDocFile = null;
                        m_sImportedFolderDocFile = null;

                        Folder = n.Text;

                        if (m_sConfigFile == null)
                        {
                            m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                            if (!System.IO.Directory.Exists(m_sConfigFile))
                                System.IO.Directory.CreateDirectory(m_sConfigFile);
                        }

                        if ((m_sFileCabinetDocFile == null) && (Cabinet != null))
                        {
                            if (Folder != null)
                            {
                                m_sFileCabinetDocFile = m_sConfigFile + "\\" + Cabinet + "\\" + Folder;
                                FolderID = GetMainFolderCabinetID(Folder);
                            }
                            else
                            {
                                FolderID = 0;
                                m_sFileCabinetDocFile = m_sConfigFile + "\\" + Cabinet; // +"\\" + treeView1.SelectedNode.Text.ToUpper();
                            }

                            if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                                System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);

                            TreeNode newNode = new TreeNode();
                            newNode.Text = n.Text.ToUpper();

                            //string PrevNode = n.FullPath;

                            string ParentNode =  m_sConfigFile + "\\" + n.Parent.Text  +"\\" + newNode.Text;
                            //string ParentNode = m_sConfigFile + "\\" + n.FullPath;
                            string NodeFile = m_sFileCabinetDocFile + "\\";
                            if (File.Exists(ParentNode))
                            {
                                if (!File.Exists(NodeFile))
                                    System.IO.File.Copy(ParentNode, NodeFile, true);
                            }
                            //* inserting files details in Files table *//

                            NandanaResult objinsertfilesdetails = objFilesManager.UpdateFileDetails(FolderID, Convert.ToInt32(n.Name), Cabinet, n.Text.ToUpper(), m_sFileCabinetDocFile + "\\" + n.Text.ToUpper(), "True");
                            //* End  *//
                        }
                        else break;
                    }
                 
                }

                treeView1.Nodes.Clear();
                DashBoardHome_Load(sender, e);
                MF.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel"); 
                MF.Dispose();
            }
        }

        private void MoveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // File level Move
            string Path = string.Empty;
            treeView1.HideSelection = false;

            //foreach (TreeNode n in treeView1.SelectedNodes)
            //{
            //    MessageBox.Show(string.Format("You selected: {0}", n.Text));
            //}

            //MessageBox.Show(string.Format("You selected: {0}", Cabinet));
            //MessageBox.Show(string.Format("You selected: {0}", Folder));    
  
            MoveFiles MF = new MoveFiles();
            DialogResult DlgResult = MF.ShowDialog();

            string Cabinet = MF.GetCabinet;
            string Folder = MF.GetFolder;

            int FolderID = 0;
            if (DlgResult == DialogResult.OK)
            {
                //MessageBox.Show("Ok");

                foreach (TreeNode n in treeView1.SelectedNodes)
                {
                    //ListDirectory(treeView1, Path); 
                    //ListFiles(treeView1, n.Text);

                    m_sConfigFile = null;
                    m_sFileCabinetDocFile = null;
                    m_sImportedFolderDocFile = null;

                    if (m_sConfigFile == null)
                    {
                        m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                        if (!System.IO.Directory.Exists(m_sConfigFile))
                            System.IO.Directory.CreateDirectory(m_sConfigFile);
                    }

                    if ((m_sFileCabinetDocFile == null) && (Cabinet != null))
                    {
                        if (Folder != null)
                        {
                            m_sFileCabinetDocFile = m_sConfigFile + "\\" + Cabinet + "\\" + Folder;
                            FolderID = GetMainFolderCabinetID(Folder);
                        }
                        else
                        {
                            FolderID = 0;
                            m_sFileCabinetDocFile = m_sConfigFile + "\\" + Cabinet; // +"\\" + treeView1.SelectedNode.Text.ToUpper();
                        }

                        if (!System.IO.Directory.Exists(m_sFileCabinetDocFile))
                            System.IO.Directory.CreateDirectory(m_sFileCabinetDocFile);

                        TreeNode newNode = new TreeNode();
                        newNode.Text = n.Text.ToUpper();

                        //string PrevNode = n.FullPath;

                        //string ParentNode =  m_sConfigFile + "\\" + n.Parent.Text  +"\\" + newNode.Text;
                        string ParentNode = m_sConfigFile + "\\" + n.FullPath;
                        string NodeFile = m_sFileCabinetDocFile + "\\" + newNode.Text;
                        if (File.Exists(ParentNode))
                        {
                            if (!File.Exists(NodeFile))
                                System.IO.File.Copy(ParentNode, NodeFile , true);
                        }
                        //* inserting files details in Files table *//

                        NandanaResult objinsertfilesdetails = objFilesManager.UpdateFileDetails(FolderID, Convert.ToInt32(n.Name), Cabinet, n.Text.ToUpper(), m_sFileCabinetDocFile + "\\" + n.Text.ToUpper(), "True");
                        //* End  *//
                    }
                    else break;
                }
                 
                treeView1.Nodes.Clear();
                DashBoardHome_Load(sender, e);
                
                MF.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel"); 
                MF.Dispose();
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TempNodeText = string.Empty;
            string FileName = treeView1.SelectedNode.Text;
            string[] splitfilenames = FileName.Split('.');
            treeView1.HideSelection = false;
            EnterText frm = new EnterText();
            frm.FormName = "File";
            if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
            {
                frm.CurrentFolderName = "0";
                frm.FileCabinetID = treeView1.SelectedNode.Parent.Name;
            }
            else
            {
                if (treeView1.SelectedNode.Parent.Parent.Level == 0)
                {
                    frm.CurrentFolderName = treeView1.SelectedNode.Parent.Text;
                    frm.FileCabinetID = treeView1.SelectedNode.Parent.Parent.Name;
                }
                else
                {
                    frm.CurrentFolderName = treeView1.SelectedNode.Parent.Text;
                    frm.FileCabinetID = treeView1.SelectedNode.Parent.Parent.Parent.Name;
                }
            }
            frm.FileID = treeView1.SelectedNode.Name;
            frm.ShowDialog();
            if (frm.FolderName != null)
            {
                TempNodeText = frm.FolderName.ToUpper();
            }
            else
            {
                TempNodeText = frm.FolderName;
            }
            //string TempNodeText = frm.FolderName.ToUpper();
            frm.Dispose();
            TreeNode SelectedNode = treeView1.SelectedNode;
            if ((TempNodeText != null))
            {
                SelectedNode.Text = TempNodeText + "." + splitfilenames[1].ToString();

                
                NandanaResult updateFolderName = objFilesManager.UpdateFileNameDetails(treeView1.SelectedNode.Name, TempNodeText + "." + splitfilenames[1].ToString());
            }
        }

        public void DeclareFolderDatagridviewColumns()
        {
            try
            {
                dgvDocuments.Columns.Clear();
                dgvDocuments.AutoGenerateColumns = false;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDocuments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvDocuments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvDocuments.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgvDocuments.BorderStyle = BorderStyle.None;
                dgvDocuments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvDocuments.RowHeadersDefaultCellStyle.BackColor = Color.Gray;
                dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

                DataGridViewColumn clnName = new DataGridViewTextBoxColumn();
                clnName.DataPropertyName = "Name";
                clnName.Name = "Name";
                dgvDocuments.Columns.Add(clnName);
                //clnName.SortMode = DataGridViewColumnSortMode.Automatic;
                clnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnName.Width = 175;
                dgvDocuments.Sort(dgvDocuments.Columns[0], ListSortDirection.Ascending);


                DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
                clnDate.DataPropertyName = "Date";
                clnDate.Name = "Date";
                dgvDocuments.Columns.Add(clnDate);
                //clnName.SortMode = DataGridViewColumnSortMode.Automatic;
                clnDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnDate.Width = 175;
                //dgvDocuments.Sort(dgvDocuments.Columns[0], ListSortDirection.Ascending);



                DataGridViewColumn clnType = new DataGridViewTextBoxColumn();
                clnType.DataPropertyName = "Type";
                clnType.Name = "Type";
                dgvDocuments.Columns.Add(clnType);
                clnType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnType.Width = 100;

                DataGridViewColumn clnSize = new DataGridViewTextBoxColumn();
                clnSize.DataPropertyName = "Size";
                clnSize.Name = "Size";
                dgvDocuments.Columns.Add(clnSize);
                clnSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnSize.Width = 100;

                DataGridViewColumn clnPageCount = new DataGridViewTextBoxColumn();
                clnPageCount.DataPropertyName = "PageCount";
                clnPageCount.Name = "Total Pages";
                dgvDocuments.Columns.Add(clnPageCount);
                clnPageCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnPageCount.Width = 100;

                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("Date", typeof(String));
                dttemp.Columns.Add("Name", typeof(String));
                dttemp.Columns.Add("Type", typeof(String));
                dttemp.Columns.Add("Size", typeof(String));
                dttemp.Columns.Add("PageCount", typeof(String));


                dttemp.Clear();

                DataTable getFolderNames = new DataTable();
                DataTable getfileNames = new DataTable();

                GetFolders();
                GetFiles();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " ParentFolderID = '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getFolderNames = drResult.CopyToDataTable();
                        }
                    }
                }

                if (DtFiles != null)
                {
                    if (DtFiles.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFiles.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " Folder_ID = '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getfileNames = drResult.CopyToDataTable();
                        }
                    }
                }
                

                if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
                {
                    //img.Image = global::MoveMyFiles.Properties.Resources.Folder16x16;

                    foreach (DataRow dr in getFolderNames.Rows)
                    {
                        DataRow drtemp = dttemp.NewRow();

                        string path = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString() + "\\" + treeView1.SelectedNode.Text + "\\" + dr["Folder_Name"].ToString();
                        //drtemp["img"] = global::MoveMyFiles.Properties.Resources.FolderIcon;
                        drtemp["Date"] = Directory.GetCreationTime(path);
                        drtemp["Name"] = dr["Folder_Name"].ToString();
                        drtemp["Type"] = "Folder";
                        drtemp["Size"] = "";
                        drtemp["PageCount"] = "";

                        dttemp.Rows.Add(drtemp);
                    }
                }
                if (getfileNames.HasErrors != null && getfileNames.Rows.Count > 0)
                {
                    //img.Image = global::MoveMyFiles.Properties.Resources.File16x16;

                    foreach (DataRow dr in getfileNames.Rows)
                    {
                        DataRow drtemp = dttemp.NewRow();


                        string FileName = dr["File_Name"].ToString();
                        string[] splitFileName = FileName.Split('.');
                        drtemp["Name"] = splitFileName[0];
                        drtemp["Type"] = splitFileName[1];
                        long length = new System.IO.FileInfo(dr["File_Path"].ToString()).Length;

                        string Size = BytesToString(length);

                        drtemp["Size"] = Size;
                        drtemp["Date"] = File.GetCreationTime(dr["File_Path"].ToString());
                        if (splitFileName[1].ToUpper() == "JPG" || splitFileName[1].ToUpper() == "PNG" || splitFileName[1].ToUpper() == "BMP" || splitFileName[1].ToUpper() == "GIF" || splitFileName[1].ToUpper() == "TIF" || splitFileName[1].ToUpper()== "TIFF") // or // ImageFormat.Jpeg.ToString()
                        {
                            //drtemp["img"] = global::MoveMyFiles.Properties.Resources.JPGIcon;
                            drtemp["PageCount"] = Convert.ToString(1);
                        }
                        else if (splitFileName[1].ToUpper() == "PDF")
                        {
                            //drtemp["img"] = global::MoveMyFiles.Properties.Resources.PDFFileIcon;
                            using (FileStream file = new FileStream(dr["File_Path"].ToString(), FileMode.Open, FileAccess.Read))
                            {
                                byte[] buffer = new byte[file.Length];
                                file.Read(buffer, 0, buffer.Length);
                                document = new TallComponents.PDF.Rasterizer.Document(new BinaryReader(new MemoryStream(buffer)));
                            }

                            drtemp["PageCount"] = Convert.ToString(document.Pages.Count);
                        }
                        else
                        {
                            if (splitFileName[1].ToUpper() == "DOC" || splitFileName[1].ToUpper() == "DOCX")
                            {
                                drtemp["PageCount"] = GetNoOfPagesDOC(dr["File_Path"].ToString()).ToString();
                            }
                            else
                            {
                                drtemp["PageCount"] = "1";
                            }
                        }

                        dttemp.Rows.Add(drtemp);
                    }
                }

                dgvDocuments.DataSource = dttemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from GetMainFolderNamesUsingFileCabinetID sp");
            }
        }

        TallComponents.PDF.Rasterizer.Document document = null;

        public void GetAllFolderAndFileDetailsOfFileCabinets()
        {
            try
            {
                dgvDocuments.Columns.Clear();
                dgvDocuments.AutoGenerateColumns = false;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDocuments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvDocuments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvDocuments.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);

                dgvDocuments.BorderStyle = BorderStyle.None;
                dgvDocuments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                //dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
                dgvDocuments.RowHeadersDefaultCellStyle.BackColor = Color.Gray;

             
                DataGridViewColumn clnName = new DataGridViewTextBoxColumn();
                clnName.DataPropertyName = "Name";
                clnName.Name = "Name";
                dgvDocuments.Columns.Add(clnName);
                //clnName.SortMode = DataGridViewColumnSortMode.Automatic;
                clnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnName.Width = 175;
                dgvDocuments.Sort(dgvDocuments.Columns[0], ListSortDirection.Ascending);


                DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
                clnDate.DataPropertyName = "Date";
                clnDate.Name = "Date";
                dgvDocuments.Columns.Add(clnDate);
                //clnName.SortMode = DataGridViewColumnSortMode.Automatic;
                clnDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnDate.Width = 175;



                DataGridViewColumn clnType = new DataGridViewTextBoxColumn();
                clnType.DataPropertyName = "Type";
                clnType.Name = "Type";
                dgvDocuments.Columns.Add(clnType);
                clnType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnType.Width = 100;

                DataGridViewColumn clnSize = new DataGridViewTextBoxColumn();
                clnSize.DataPropertyName = "Size";
                clnSize.Name = "Size";
                dgvDocuments.Columns.Add(clnSize);
                clnSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnSize.Width = 100;

                DataGridViewColumn clnPageCount = new DataGridViewTextBoxColumn();
                clnPageCount.DataPropertyName = "PageCount";
                clnPageCount.Name = "Total Pages";
                dgvDocuments.Columns.Add(clnPageCount);
                clnPageCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnPageCount.Width = 100;


                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("Date", typeof(String));
                dttemp.Columns.Add("Name", typeof(String));
                dttemp.Columns.Add("Type", typeof(String));
                dttemp.Columns.Add("Size", typeof(String));
                dttemp.Columns.Add("PageCount", typeof(String));

                dttemp.Clear();

                DataTable getFolderNames = new DataTable();
                DataTable getfileNames = new DataTable();

                GetFolders();
                GetFiles();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                        {
                            DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " ParentFolderID = '" + treeView1.SelectedNode.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                            if (drResult.Count() != 0)
                            {
                                getFolderNames = drResult.CopyToDataTable();
                            }
                        }
                        else
                        {
                            DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " ParentFolderID = '" + treeView1.SelectedNode.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                            if (drResult.Count() != 0)
                            {
                                getFolderNames = drResult.CopyToDataTable();
                            }
                        }
                    }
                }

                if (DtFiles != null)
                {
                    if (DtFiles.Rows.Count > 0)
                    {
                        if (treeView1.SelectedNode.Parent.ImageKey == "LockerIcon.png")
                        {
                            DataRow[] drResult = DtFiles.Select("Folder_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                            if (drResult.Count() != 0)
                            {
                                getfileNames = drResult.CopyToDataTable();
                            }
                        }
                        else
                        {
                            DataRow[] drResult = DtFiles.Select("Folder_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " FileCabinet_ID = '" + treeView1.SelectedNode.Parent.Parent.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                            if (drResult.Count() != 0)
                            {
                                getfileNames = drResult.CopyToDataTable();
                            }
                        }
                    }
                }
                
                if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
                {
                    foreach (DataRow dr in getFolderNames.Rows)
                    {
                        DataRow drtemp = dttemp.NewRow();

                        string path = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString() + "\\" + treeView1.SelectedNode.Parent.Text + "\\" + treeView1.SelectedNode.Text + "\\" + dr["Folder_Name"].ToString();
                        //drtemp["img"] = global::MoveMyFiles.Properties.Resources.FolderIcon;
                        drtemp["Date"] = Directory.GetCreationTime(path);
                        drtemp["Name"] = dr["Folder_Name"].ToString();
                        drtemp["Type"] = "Folder";
                        drtemp["Size"] = "";
                        drtemp["PageCount"] = "";

                        dttemp.Rows.Add(drtemp);
                    }
                }
                if (getfileNames.HasErrors != null && getfileNames.Rows.Count > 0)
                {
                    foreach (DataRow dr in getfileNames.Rows)
                    {
                        DataRow drtemp = dttemp.NewRow();


                        string FileName = dr["File_Name"].ToString();
                        string[] splitFileName = FileName.Split('.');
                        drtemp["Name"] = splitFileName[0];
                        drtemp["Type"] = splitFileName[1];
                        long length = new System.IO.FileInfo(dr["File_Path"].ToString()).Length;

                        string Size = BytesToString(length);

                        drtemp["Size"] = Size;
                        drtemp["Date"] = File.GetCreationTime(dr["File_Path"].ToString());

                        if (splitFileName[1].ToUpper() == "JPG" || splitFileName[1].ToUpper() == "PNG" || splitFileName[1].ToUpper() == "BMP" || splitFileName[1].ToUpper() == "GIF" || splitFileName[1].ToUpper() == "TIF" || splitFileName[1].ToUpper() == "TIFF") // or // ImageFormat.Jpeg.ToString()
                        {
                            //drtemp["img"] = global::MoveMyFiles.Properties.Resources.JPGIcon;
                            drtemp["PageCount"] = Convert.ToString(1);
                        }
                        else if (splitFileName[1].ToUpper() == "PDF")
                        {
                            //drtemp["img"] = global::MoveMyFiles.Properties.Resources.PDFFileIcon;
                            using (FileStream file = new FileStream(dr["File_Path"].ToString(), FileMode.Open, FileAccess.Read))
                            {
                                byte[] buffer = new byte[file.Length];
                                file.Read(buffer, 0, buffer.Length);
                                document = new TallComponents.PDF.Rasterizer.Document(new BinaryReader(new MemoryStream(buffer)));
                            }

                            drtemp["PageCount"] = Convert.ToString(document.Pages.Count);
                        }
                        else
                        {
                            if (splitFileName[1].ToUpper() == "DOC" || splitFileName[1].ToUpper() == "DOCX")
                            {
                                drtemp["PageCount"] = GetNoOfPagesDOC(dr["File_Path"].ToString()).ToString();
                            }
                            else
                            {
                                drtemp["PageCount"] = "1";
                            }
                        }

                        dttemp.Rows.Add(drtemp);
                    }
                }

                dgvDocuments.DataSource = dttemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from GetFolderNamesUsingParentFolderID sp");
            }
        }

        public void GetFolderAndFileDetails()
        {
            try
            {
                dgvDocuments.Columns.Clear();
                dgvDocuments.AutoGenerateColumns = false;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDocuments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvDocuments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvDocuments.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#444444");
                this.dgvDocuments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.00F);
                
                dgvDocuments.BorderStyle = BorderStyle.None;
                dgvDocuments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                //dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
                dgvDocuments.RowHeadersDefaultCellStyle.BackColor = Color.Gray;

                DataGridViewColumn clnName = new DataGridViewTextBoxColumn();
                clnName.DataPropertyName = "Name";
                clnName.Name = "Name";
                dgvDocuments.Columns.Add(clnName);
                //clnName.SortMode = DataGridViewColumnSortMode.Automatic;
                clnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnName.Width = 175;
                dgvDocuments.Sort(dgvDocuments.Columns[0], ListSortDirection.Ascending);


                DataGridViewColumn clnDate = new DataGridViewTextBoxColumn();
                clnDate.DataPropertyName = "Date";
                clnDate.Name = "Date";
                dgvDocuments.Columns.Add(clnDate);
                //clnName.SortMode = DataGridViewColumnSortMode.Automatic;
                clnDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnDate.Width = 175;



                DataGridViewColumn clnType = new DataGridViewTextBoxColumn();
                clnType.DataPropertyName = "Type";
                clnType.Name = "Type";
                dgvDocuments.Columns.Add(clnType);
                clnType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnType.Width = 100;

                DataGridViewColumn clnSize = new DataGridViewTextBoxColumn();
                clnSize.DataPropertyName = "Size";
                clnSize.Name = "Size";
                dgvDocuments.Columns.Add(clnSize);
                clnSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnSize.Width = 100;

                DataGridViewColumn clnPageCount = new DataGridViewTextBoxColumn();
                clnPageCount.DataPropertyName = "PageCount";
                clnPageCount.Name = "Total Pages";
                dgvDocuments.Columns.Add(clnPageCount);
                clnPageCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                clnPageCount.Width = 100;


                DataTable dttemp = new DataTable();
                dttemp.Columns.Add("Date", typeof(String));
                dttemp.Columns.Add("Name", typeof(String));
                dttemp.Columns.Add("Type", typeof(String));
                dttemp.Columns.Add("Size", typeof(String));
                dttemp.Columns.Add("PageCount", typeof(String));

                dttemp.Clear();

                DataTable getFolderNames = new DataTable();
                DataTable getfileNames = new DataTable();

                GetFolders();
                GetFiles();

                if (DtFolders != null)
                {
                    if (DtFolders.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + Convert.ToInt32(strRootNodeID) + "'" + "and" + " ParentFolderID = '" + treeView1.SelectedNode.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getFolderNames = drResult.CopyToDataTable();
                        }
                    }
                }

                if (DtFiles != null)
                {
                    if (DtFiles.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFiles.Select("Folder_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " FileCabinet_ID = '" + Convert.ToInt32(strRootNodeID) + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getfileNames = drResult.CopyToDataTable();
                        }
                    }
                }
                
                if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
                {
                    foreach (DataRow dr in getFolderNames.Rows)
                    {
                        DataRow drtemp = dttemp.NewRow();

                        string path = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString() + "\\" + strRootNode + "\\" + treeView1.SelectedNode.Text + "\\" + dr["Folder_Name"].ToString();
                        //drtemp["img"] = global::MoveMyFiles.Properties.Resources.FolderIcon;
                        drtemp["Date"] = Directory.GetCreationTime(path);
                        drtemp["Name"] = dr["Folder_Name"].ToString();
                        drtemp["Type"] = "Folder";
                        drtemp["Size"] = "";
                        drtemp["PageCount"] = "";

                        dttemp.Rows.Add(drtemp);
                    }
                }
                if (getfileNames.HasErrors != null && getfileNames.Rows.Count > 0)
                {
                    foreach (DataRow dr in getfileNames.Rows)
                    {
                        DataRow drtemp = dttemp.NewRow();


                        string FileName = dr["File_Name"].ToString();
                        string[] splitFileName = FileName.Split('.');
                        drtemp["Name"] = splitFileName[0];
                        drtemp["Type"] = splitFileName[1];
                        long length = new System.IO.FileInfo(dr["File_Path"].ToString()).Length;

                        string Size = BytesToString(length);

                        drtemp["Size"] = Size;
                        drtemp["Date"] = File.GetCreationTime(dr["File_Path"].ToString());

                        if (splitFileName[1].ToUpper() == "JPG" || splitFileName[1].ToUpper() == "PNG" || splitFileName[1].ToUpper() == "BMP" || splitFileName[1].ToUpper() == "GIF" || splitFileName[1].ToUpper() == "TIF" || splitFileName[1].ToUpper() == "TIFF") // or // ImageFormat.Jpeg.ToString()
                        {
                            //drtemp["img"] = global::MoveMyFiles.Properties.Resources.JPGIcon;
                            drtemp["PageCount"] = "1";
                        }
                        else if (splitFileName[1].ToUpper() == "PDF")
                        {
                            //drtemp["img"] = global::MoveMyFiles.Properties.Resources.PDFFileIcon;
                            using (FileStream file = new FileStream(dr["File_Path"].ToString(), FileMode.Open, FileAccess.Read))
                            {
                                byte[] buffer = new byte[file.Length];
                                file.Read(buffer, 0, buffer.Length);
                                document = new TallComponents.PDF.Rasterizer.Document(new BinaryReader(new MemoryStream(buffer)));
                            }

                            drtemp["PageCount"] = Convert.ToString(document.Pages.Count);
                        }
                        else
                        {
                            if (splitFileName[1].ToUpper() == "DOC" || splitFileName[1].ToUpper() == "DOCX")
                            {
                                drtemp["PageCount"] = GetNoOfPagesDOC(dr["File_Path"].ToString()).ToString();
                            }
                            else
                            {
                                drtemp["PageCount"] = "1";
                            }
                        }

                        dttemp.Rows.Add(drtemp);
                    }
                }

                dgvDocuments.DataSource = dttemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from GetFolderNamesUsingParentFolderID sp");
            }
        }

        public int GetNoOfPagesDOC(string FileName)
        {
            int num = 0;
            object fileName = FileName;
            object readOnly = false;
            object isVisible = true;
            object objDNS = Word.WdSaveOptions.wdDoNotSaveChanges;
            try
            {
                Word.Application WordApp = new Word.Application();

                // give any file name of your choice.


                //  the way to handle parameters you don't care about in .NET
                object missing = System.Reflection.Missing.Value;

                //   Make word visible, so you can see what's happening
                //WordApp.Visible = true;
                //   Open the document that was chosen by the dialog

                Word.Document aDoc = WordApp.Documents.Open(ref fileName,
                                        ref missing, ref readOnly, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                         ref missing, ref isVisible,
                                         ref missing, ref missing, ref missing, ref missing);
                Word.WdStatistic stat = Word.WdStatistic.wdStatisticPages;
                num = aDoc.ComputeStatistics(stat, ref missing);
                WordApp.Quit(ref objDNS, ref missing, ref missing);
                aDoc = null;
                WordApp = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return num;

        }

        void treeView1_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            //TreevViewNodeMouseClick();
        }

        private void TreevViewNodeMouseClick()
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                // if (!node.BackColor.IsEmpty &&  node.BackColor == Color.LightGray)
                node.BackColor = Color.White;
                if (node.Parent != null)
                {
                    node.Parent.BackColor = Color.White;
                }

                UnSelectParentsOfSubNodes(node);


                UnSelectParents(node);
            }

            SelectParents(treeView1.SelectedNode);
        }

        private void UnSelectParentsOfSubNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0)
                return;
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    UnSelectParents(childNode);
                    UnSelectParentsOfSubNodes(childNode);
                }
            }
        }

        

        void treeView1_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            //UnSelectParents(treeView1.SelectedNode);
            //foreach (TreeNode node in treeView1.Nodes)
            //{
            //    if (node.BackColor == Color.LightGray)
            //        node.BackColor = Color.White;
            //}
        }

        private void SelectParents(TreeNode node)
        {
            if (node == null) return;
            var parent = node.Parent;

            if (parent == null)
                return;

            //if (!isSelected && HasSelectedNode(parent))
            //    parent.BackColor = Color.White;
            //    return;

            parent.BackColor = Color.LightGray;
            node.BackColor = Color.LightGray;
            SelectParents(parent);
        }

        private void UnSelectParents(TreeNode node)
        {
            if (node == null) return;
            var parent = node.Parent;

            if (parent == null)
                return;


            parent.BackColor = Color.White;
            node.BackColor = Color.White;
            UnSelectParents(parent);
        }

        private bool HasSelectedNode(TreeNode node)
        {
            return node.Nodes.Cast<TreeNode>().Any(n => n.IsSelected);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.ImageKey == "LockerIcon.png" || treeView1.SelectedNode.ImageKey == "FolderIcon.png")
            {
                PanelWebBrowser.Visible = false;
                PanelGridview.Visible = true;

                //this.PanelGridview.Width = this.Width - 265;
                //this.PanelGridview.Height = this.Height - 8;

                this.PanelGridview.Size = new System.Drawing.Size(745, 570); 
                //this.PanelGridview.Width = Screen.PrimaryScreen.WorkingArea.Width - 260;
                //this.PanelGridview.Height = Screen.PrimaryScreen.WorkingArea.Height - 170;
                //dgvDocuments.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width - 240, Screen.PrimaryScreen.WorkingArea.Height - 150);
                dgvDocuments.Size = new Size(690, 550);

                if (treeView1.SelectedNode.ImageKey == "LockerIcon.png")
                {
                    //DeclareFolderDatagridviewColumns();
                }
                else if (strRootNode != null)
                {
                    GetFolderAndFileDetails();
                }
                else
                {
                    //GetAllFolderAndFileDetailsOfFileCabinets();
                }
            }

            if (treeView1.SelectedNode.ImageKey == "PDFIcon.png" || treeView1.SelectedNode.ImageKey == "JPGIcon.png" || treeView1.SelectedNode.ImageKey == "TXTIcon.png")
            {
                PanelGridview.Visible = false;
                PanelWebBrowser.Visible = true;

                PanelWebBrowser.Location = new Point(262, 45);//PanelWebBrowser.Location = new Point(262, 5); Nishanth
                this.PanelWebBrowser.Width = this.Width - 265;
                this.PanelWebBrowser.Height = this.Height - 48;// this.PanelWebBrowser.Height = this.Height - 8; Nishanth
                //this.PanelWebBrowser.Width = this.Width - 500;
                //this.PanelWebBrowser.Height = Screen.PrimaryScreen.WorkingArea.Height - 175;

                DataTable getfiledetails = new DataTable();

                GetFolders();
                GetFiles();

                if (DtFiles != null)
                {
                    if (DtFiles.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFiles.Select("File_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getfiledetails = drResult.CopyToDataTable();
                        }
                    }
                }

                if (getfiledetails.HasErrors != null && getfiledetails.Rows.Count > 0)
                {
                    DataRow dr = getfiledetails.Rows[0];
                    string strfilepath = dr["File_Path"].ToString();

                    webBrowser1.Navigate(strfilepath);

                }
            }
            TreevViewNodeMouseClick();
        }

        static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        private void ExportFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string Path = string.Empty;

            SaveFileDialog objsavefiledialogue = new SaveFileDialog();
            //objsavefiledialogue.InitialDirectory = Application.StartupPath;
            objsavefiledialogue.RestoreDirectory = true;
            objsavefiledialogue.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            objsavefiledialogue.FileName = treeView1.SelectedNode.Text;
            if (objsavefiledialogue.FileName != "")
            {
                if (objsavefiledialogue.ShowDialog() == DialogResult.OK)
                {
                    string fileName = objsavefiledialogue.FileName;

                    DataTable getfilesdetails = new DataTable();

                    if (DtFiles.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFiles.Select("File_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getfilesdetails = drResult.CopyToDataTable();
                        }
                    }


                    if (getfilesdetails.HasErrors != null && getfilesdetails.Rows.Count > 0)
                    {
                        DataRow dr = getfilesdetails.Rows[0];
                        string Filepath = dr["File_Path"].ToString();

                        System.IO.File.Copy(Filepath, fileName, true);
                    }
                }
            }
        }

        private void dgvDocuments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.Handled = true;
                using (Brush b = new SolidBrush(dgvDocuments.DefaultCellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
                using (Pen p = new Pen(Brushes.LightGray))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right, e.CellBounds.Bottom - 1));
                }
                e.PaintContent(e.ClipBounds);
            }
        }

        private void PanelWebBrowser_Paint(object sender, PaintEventArgs e)
        {
            if (PanelWebBrowser.BorderStyle == BorderStyle.None)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Gray, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              PanelWebBrowser.ClientSize.Width - thickness,
                                                              PanelWebBrowser.ClientSize.Height - thickness));
                }
            }
        }

        private void PrintRecursive(TreeNode treeNode, int i)
        {
            if (txtSearch.Text != "" && txtSearch.Text != "Search")
            {
                if (treeNode.Text.ToLower().Contains(txtSearch.Text.Substring(0, i).ToString().ToLower()))
                {
                    TreeNode[] foundNodes = treeNode.Nodes.Find(treeNode.Text, true);
                    if (foundNodes.Length > 0)
                    {
                        TreeNode foundNode = foundNodes[0];
                        HideNodes(treeNode.Nodes, foundNode);
                    }
                    if (treeNode.Level == 0)
                    {
                        treeNode.BackColor = Color.Teal;
                        treeNode.ForeColor = Color.White;
                    }
                    else if (treeNode.Parent.Level == 0)
                    {
                        TreeNode treeNode1 = treeNode.Parent;
                        if (treeNode1 != null)
                        {
                            treeNode1.Expand();

                        }
                        treeNode.BackColor = Color.Teal;
                        treeNode.ForeColor = Color.White;
                    }
                    else if (treeNode.Parent.Parent.Level == 0)
                    {
                        TreeNode treeNode1 = treeNode.Parent;
                        if (treeNode1 != null)
                        {
                            treeNode.Parent.Parent.Expand();
                            treeNode.Parent.Expand();
                        }
                        treeNode.BackColor = Color.Teal;
                        treeNode.ForeColor = Color.White;
                    }
                }
                else
                {
                    treeNode.BackColor = Color.White;
                    treeNode.ForeColor = Color.Gray;
                }
            }
            else
            {

                if (treeNode.Parent != null)
                {
                    TreeNode treeNode1 = treeNode.Parent;
                    if (treeView1.Nodes[0] != treeNode1.Nodes[0] && treeNode1 != null)
                    {
                        treeNode1.Collapse();
                    }
                }
                else if (treeNode.Parent.Parent != null)
                {
                    TreeNode treeNode1 = treeNode.Parent.Parent;
                    if (treeView1.Nodes[0] != treeNode1.Nodes[0] && treeNode1 != null)
                    {
                        treeNode.Parent.Parent.Collapse();
                        treeNode1.Collapse();
                    }
                }

                treeNode.BackColor = Color.White;
                treeNode.ForeColor = Color.Gray;
            }
            // Print each node recursively.
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn, i);
            }
        }


        // Call the procedure using the TreeView.

        private void CallRecursive(TreeView treeView, int i)
        {

            // Print each node recursively.

            TreeNodeCollection nodes = treeView.Nodes;

            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n, i);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length < 2)
            {
                return; //Nishanth. There is no need to do anything for less than two charachters
            }
            if (txtSearch.Text != "" && txtSearch.Text != "Search" && txtSearch.Text.Length > 2)
            {
            //if (txtSearch.Text != "" && txtSearch.Text != "Search")
            //{
                try
                {
                    DataTable getFolderNames = new DataTable();

                    //DtFolders.Table

                    string searchCriteria = "Folder_Name like '%" + txtSearch.Text.ToUpper() + "%'" + "and" + " ParentFolderID = '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'";

                    if (DtFolders != null)
                    {
                        if (DtFolders.Rows.Count > 0)
                        {
                            DataRow[] drResult = DtFolders.Select(searchCriteria);
                            if (drResult.Count() != 0)
                            {
                                getFolderNames = drResult.CopyToDataTable();
                            }
                        }
                    }

                    treeView1.Nodes.Clear();
                    if (!getFolderNames.HasErrors  && getFolderNames.Rows.Count > 0)
                    {
                        DataView view = new DataView(getFolderNames);
                        DataTable distinctCabinets = new DataTable();
                        distinctCabinets = view.ToTable(true, "FileCabinet_ID");

                        foreach (DataRow dr in distinctCabinets.Rows)
                        {
                            TreeNode Root = new TreeNode();

                            DataTable dtfilecabinets = new DataTable();

                            NandanaResult objgetfilecabinets = objFileCabinetManager.GetFileCabinets();


                            if (objgetfilecabinets.resultDS!=null && objgetfilecabinets.resultDS.Tables[0].Rows.Count > 0)
                            {
                                DataRow[] drResult = objgetfilecabinets.resultDS.Tables[0].Select("FileCabinet_ID = '" + dr["FileCabinet_ID"].ToString() + "'");
                                if (drResult.Count() != 0)
                                {
                                    dtfilecabinets = drResult.CopyToDataTable();
                                }
                            }
                            if (!dtfilecabinets.HasErrors && dtfilecabinets.Rows.Count > 0)
                            {
                                DataRow drCabinet = dtfilecabinets.Rows[0];

                                Root = new TreeNode(drCabinet["FileCabinet_Name"].ToString().ToUpper());

                                Root.Name = dr["FileCabinet_ID"].ToString();
                                Root.ContextMenuStrip = RootNodeContextMenu;
                                Root.ImageKey = "LockerIcon.png";
                                Root.SelectedImageKey = "LockerIcon.png";

                                DataTable dtFindNodes = new DataTable();
                                DataRow[] drSameCabinetIDRows = getFolderNames.Select("FileCabinet_ID = '" + dr["FileCabinet_ID"].ToString() + "'");
                                if (drSameCabinetIDRows.Count() != 0)
                                {

                                    dtFindNodes = drSameCabinetIDRows.CopyToDataTable();
                                    if(!dtFindNodes.HasErrors && dtFindNodes.Rows.Count > 0)
                                    {
                                        foreach (DataRow drFinalNodes in dtFindNodes.Rows)
                                        {
                                            GetFilecabinetAndMainFolderNames(Root, drFinalNodes["FileCabinet_ID"].ToString(), drFinalNodes["Folder_ID"].ToString(), drFinalNodes["Folder_Name"].ToString(), drFinalNodes["ParentFolderID"].ToString());
                                        }
                                    }
                                }
                            }
                            treeView1.Nodes.Add(Root);
                            Root.Expand();
                        }
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Please try again !! If the problem is persisting, please contact the DocSort Support.");
                }
            }
            else
            {
                treeView1.Nodes.Clear();

                // DashBoardHome_Load(sender, e);//Nishanth  Search Optimi commented .Need to double confirm why he commented.

                //The below if and else code is added by Nishanth for search optim
                if (strRootNode != null)
                {
                    LoadTreeview(strRootNodeID, strRootNode.ToUpper());
                }
                else
                {
                    LoadTreeview("1", "ROOT");

                    // sorting table by removing ROOT default cabinet outside

                    DataRow[] drResult = DtCabinets.Select("FileCabinet_ID <> '" + 1 + "'" + "and" + " IsDelete = '" + "True" + "'");
                    if (drResult.Count() != 0)
                    {
                        DataTable dtfilecabinets = drResult.CopyToDataTable();

                        DataView dv = dtfilecabinets.DefaultView;
                        dv.Sort = "FileCabinet_Name asc";
                        DataTable sortedDT = dv.ToTable();

                        foreach (DataRow dr in sortedDT.Rows)
                        {
                            LoadTreeview(dr["FileCabinet_ID"].ToString(), dr["FileCabinet_Name"].ToString().ToUpper());
                        }
                    }
                }
            }
        }

        public void GetFilecabinetAndMainFolderNames(TreeNode Root, string CabinetID, string FolderID, string FolderName, string ParentFolderID)
        {
            TreeNode ParentFolder = new TreeNode();

            if (ParentFolderID == "0")
            {
                ParentFolder = Root.Nodes.Add(FolderName.ToUpper());
                ParentFolder.Name = FolderID;
                ParentFolder.ContextMenuStrip = FolderContextMenu;
                ParentFolder.ImageKey = "FolderIcon.png";
                ParentFolder.SelectedImageKey = "FolderIcon.png";

                ParentFolder.BackColor = Color.Teal;
                ParentFolder.ForeColor = Color.White;

                GetFolderTreeView(Convert.ToInt32(FolderID), ParentFolder, Convert.ToInt32(CabinetID));

                ParentFolder.Collapse();
            }
        }

        private void GetFolderTreeView(int parentId, TreeNode parentNode, int CabinetID)
        {
            try
            {
                GetSubFoldersBasedonParentFolder(parentId, parentNode, CabinetID);

                GetFilesBasedonCabinetAndFolders(CabinetID, parentId, parentNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error While retriving data from Folders");
            }
        }

        private void FindInTreeView(TreeNodeCollection tncoll, string strNode)
        {
            foreach (TreeNode tnode in tncoll)
            {
                //if (tnode.Text.Contains(strNode.ToLower()))
                if (tnode.Text.ToUpper() == strNode.ToUpper())
                {
                    tnode.BackColor = Color.Teal;
                    tnode.ForeColor = Color.White;
                    tnode.TreeView.SelectedNode = tnode;
                }
                else
                {
                    tnode.ForeColor = SystemColors.GrayText;
                    tnode.BackColor = tnode.TreeView.BackColor;
                    //tnode.TreeView.CollapseAll();
                }
                FindInTreeView(tnode.Nodes, strNode);
            }
        }

        private void collapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Collapse();
        }

        private List<RemovedTreeNode> _removedNodes = new List<RemovedTreeNode>();

        private void HideNodes(TreeNodeCollection nodes, TreeNode visibleNode)
        {
            List<TreeNode> nodesToRemove = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (!AreNodesRelated(node, visibleNode))
                {
                    _removedNodes.Add(new RemovedTreeNode() { RemovedNode = node, ParentNode = node.Parent, RemovedNodeIndex = node.Index });
                    nodesToRemove.Add(node);
                }
                else
                {
                    HideNodes(node.Nodes, visibleNode);
                }
            }

            foreach (TreeNode node in nodesToRemove)
                node.Remove();
        }

        private bool AreNodesRelated(TreeNode firstNode, TreeNode secondNode)
        {
            if (!IsNodeAncestor(firstNode, secondNode) && !IsNodeAncestor(secondNode, firstNode) && firstNode != secondNode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsNodeAncestor(TreeNode nodeToCheck, TreeNode descendantNode)
        {
            TreeNode parentNode = descendantNode.Parent;
            while (parentNode != null)
            {
                if (parentNode == nodeToCheck)
                {
                    return true;
                }
                else
                {
                    parentNode = parentNode.Parent;
                }
            }

            return false;
        }

        private void restoreNodes_Click(object sender, EventArgs e)
        {
            RestoreNodes();
        }

        private void RestoreNodes()
        {
            _removedNodes.Reverse();
            foreach (RemovedTreeNode removedNode in _removedNodes)
            {
                if (removedNode.ParentNode == null)
                    treeView1.Nodes.Add(removedNode.RemovedNode);
                else
                    removedNode.ParentNode.Nodes.Insert(removedNode.RemovedNodeIndex, removedNode.RemovedNode);
            }

            _removedNodes.Clear();
        }


        public class RemovedTreeNode
        {
            public TreeNode RemovedNode { get; set; }
            public int RemovedNodeIndex { get; set; }
            public TreeNode ParentNode { get; set; }
        }

        private void DeleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DeleteConfirmation objDeleteConfirmation = new DeleteConfirmation();
            objDeleteConfirmation.ShowDialog();

            if (objDeleteConfirmation.DeleteConfirmationRequest == "Yes")
            {
                DeleteFoldersexistingFileCabinetID(treeView1.SelectedNode.Name);
                DeleteFilesexistingFileCabinetID(treeView1.SelectedNode.Name);

                
                NandanaResult deletefilecabinet = objFileCabinetManager.DeleteFileCabinetDetails(treeView1.SelectedNode.Name, "False");

                treeView1.SelectedNode.Remove();
            }
        }

        public void DeleteFoldersexistingFileCabinetID(string FileCabinetID)
        {
            DataTable objgetsubfolders = new DataTable();

            if (DtFolders.Rows.Count > 0)
            {
                DataRow[] drResult = DtFolders.Select("FileCabinet_ID = '" + FileCabinetID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    objgetsubfolders = drResult.CopyToDataTable();
                }

            }
            

            if (objgetsubfolders.HasErrors != null && objgetsubfolders.Rows.Count > 0)
            {
                foreach (DataRow dr in objgetsubfolders.Rows)
                {
                    string FolderId = dr["Folder_ID"].ToString();
                    //DeleteFolderids = DeleteFolderids + FolderId + ',';

                    NandanaResult objdeletefolderdetails = objFolderManager.DeleteFolderDetails(FolderId, "False");
                }
            }
        }

        public void DeleteFilesexistingFileCabinetID(string FileCabinetID)
        {
            DataTable objgetFiles = new DataTable();

            if (DtFiles.Rows.Count > 0)
            {
                DataRow[] drResult = DtFiles.Select("FileCabinet_ID = '" + FileCabinetID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    objgetFiles = drResult.CopyToDataTable();
                }
            }

            if (objgetFiles.HasErrors != null && objgetFiles.Rows.Count > 0)
            {
                foreach (DataRow dr in objgetFiles.Rows)
                {
                    string FileId = dr["File_ID"].ToString();
                    //DeleteFilesIDs = DeleteFilesIDs + FileId + ',';

                    NandanaResult deletefiledetails = objFilesManager.DeleteFileDetails(FileId, "False");
                }
            }
        }

        private void RootNodeContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode.Name == "1")
            {
                NewFolderToolStripMenuItem.Visible = true;
                ExpandToolStripMenuItem.Visible = true;
                CollaspeAllToolStripMenuItem.Visible = true;
                DeleteToolStripMenuItem.Visible = false;
                importToolStripMenuItem.Visible = true;
            }
            else
            {
                NewFolderToolStripMenuItem.Visible = true;
                ExpandToolStripMenuItem.Visible = true;
                CollaspeAllToolStripMenuItem.Visible = true;
                importToolStripMenuItem.Visible = true;
                DeleteToolStripMenuItem.Visible = true;
            }
        }

        private void dgvDocuments_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgvDocuments.Cursor = Cursors.Hand;
            }
            else
                dgvDocuments.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string test = treeView1.SelectedNode.Text.ToUpper();

            m_sConfigFile = null;
            m_sFileCabinetDocFile = null;
            m_sImportedFolderDocFile = null;
            string strfilepath = string.Empty; ;
            if (m_sConfigFile == null)
            {
                m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
                DataTable getfiledetails = new DataTable();

                GetFolders();
                GetFiles();

                if (DtFiles != null)
                {
                    if (DtFiles.Rows.Count > 0)
                    {
                        DataRow[] drResult = DtFiles.Select("File_ID = '" + treeView1.SelectedNode.Name + "'" + "and" + " IsDelete = '" + "True" + "'");
                        if (drResult.Count() != 0)
                        {
                            getfiledetails = drResult.CopyToDataTable();
                        }
                    }
                }

                if (getfiledetails.HasErrors != null && getfiledetails.Rows.Count > 0)
                {
                    DataRow dr = getfiledetails.Rows[0];
                    strfilepath = dr["File_Path"].ToString();
                }
            }

            if (m_sFileCabinetDocFile == null)
            {
                m_sFileCabinetDocFile = m_sConfigFile + "\\" + treeView1.SelectedNode.Text.ToUpper();
            }



            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;
            object fileName = m_sFileCabinetDocFile;

            try
            {
                if (strfilepath != string.Empty)
                {
                    Process.Start(strfilepath);
                }
            }
            catch
            {                
                //please select proper file
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
