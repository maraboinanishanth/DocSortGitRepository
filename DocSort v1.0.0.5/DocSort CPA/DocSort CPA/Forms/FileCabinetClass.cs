using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using DocSort_CPA.Forms;
using Business.Manager;
using Common;

class FileCabinetClass
{
    private static string m_sConfigFile;
    private static string m_sRootFile;
    private static string m_sMainFolderFile;
    private static string m_sSubFolderFile;

    string FileCabinetName = string.Empty;
    public string SelectedFileCabinetID;
    string MainFolderID = string.Empty;
    string SubFolderID = string.Empty;
    string FileID = string.Empty;

    //public SearchString objSearchString;

    FileCabinetManager objFileCabinetManager = new FileCabinetManager();
    FolderManager objFolderManager = new FolderManager();
    FilesManager objFilesManager = new FilesManager();

    public string GetRootFileCabinetName()
    {
        // Retrieving FileCabinetName using FileCabinetID
        m_sConfigFile = null;
        if (m_sConfigFile == null)
        {
            m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
            if (!System.IO.Directory.Exists(m_sConfigFile))
                System.IO.Directory.CreateDirectory(m_sConfigFile);
        }
        //SearchString objSearchString = new SearchString();
        if (SelectedFileCabinetID == "")
        {
            SelectedFileCabinetID = "1";
        }

        NandanaResult getfilecabinets = objFileCabinetManager.GetFileCabinets();
        if (!getfilecabinets.HasError && getfilecabinets.resultDS.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in getfilecabinets.resultDS.Tables[0].Rows)
            {
                if (dr["FileCabinet_ID"].ToString() == SelectedFileCabinetID)
                {
                    FileCabinetName = dr["FileCabinet_Name"].ToString().ToUpper();

                    m_sRootFile = null;
                    if (m_sRootFile == null)
                    {
                        m_sRootFile = m_sConfigFile + "\\" + FileCabinetName.ToUpper();
                        if (!System.IO.Directory.Exists(m_sRootFile))
                            System.IO.Directory.CreateDirectory(m_sRootFile);
                    }
                }
            }
        }

        if (FileCabinetName == string.Empty)
        {
            FileCabinetName = "";
        }

        return FileCabinetName;
        //
    }

    public void MatchedDocumentsInFileCabinet(string MainFolder, string SubFolder, string FileName, string FilePath)
    {
        // Checking Main Folder is present in FileCabinet, if present retrieving MainFolderID if not Inserting MainFolderName

        if (SelectedFileCabinetID == "")
        {
            SelectedFileCabinetID = "1";
        }
        int Mainfoldercount = 0;

        NandanaResult getfolderdetails = objFolderManager.GetFolderDetails();
        DataTable getFolderNames = new DataTable();
        if (getfolderdetails.resultDS != null && getfolderdetails.resultDS.Tables[0].Rows.Count > 0)
        {

            DataRow[] drResult = getfolderdetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + SelectedFileCabinetID + "'" + "and" + " ParentFolderID = '" + "0" + "'" + "and" + " IsDelete = '" + "True" + "'");
            if (drResult.Count() != 0)
            {
                getFolderNames = drResult.CopyToDataTable();
            }


            if (getFolderNames != null && getFolderNames.Rows.Count > 0)
            {
                foreach (DataRow dr in getFolderNames.Rows)
                {
                    if (dr["Folder_Name"].ToString().ToUpper() == MainFolder.ToUpper())
                    {
                        Mainfoldercount += 1;
                        MainFolderID = dr["Folder_ID"].ToString();
                    }
                }
            }
        }
        if (Mainfoldercount == 0)
        {
            NandanaResult objinsertintofolder = objFolderManager.InsertFolderDetails(SelectedFileCabinetID, MainFolder.ToUpper(), "0", "True");
            if (objinsertintofolder.resultDS != null && objinsertintofolder.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = objinsertintofolder.resultDS.Tables[0].Rows[0];
                MainFolderID = dr["FolderId"].ToString();
            }
        }

        m_sMainFolderFile = null;
        if (m_sMainFolderFile == null)
        {
            m_sMainFolderFile = m_sRootFile + "\\" + MainFolder.ToUpper();
            if (!System.IO.Directory.Exists(m_sMainFolderFile))
                System.IO.Directory.CreateDirectory(m_sMainFolderFile);
        }

        //End

        if (SubFolder != "")
        {
            // Checking Sub Folder is present in Main Folder of FileCabinet, if present retrieving SubFolderID if not Inserting SubFolderName into MainFolder

            int Subfoldercount = 0;


            NandanaResult objgetfolderdetails = objFolderManager.GetFolderDetails();

            DataTable getSubFolderNames = new DataTable();
            if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
            {

                DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("ParentFolderID = '" + MainFolderID + "'" + "and" + " ParentFolderID <> '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    getSubFolderNames = drResult.CopyToDataTable();
                }


                if (getSubFolderNames != null && getSubFolderNames.Rows.Count > 0)
                {
                    foreach (DataRow dr in getSubFolderNames.Rows)
                    {
                        if (dr["Folder_Name"].ToString().ToUpper() == SubFolder.ToUpper())
                        {
                            Subfoldercount += 1;
                            SubFolderID = dr["Folder_ID"].ToString();
                        }
                    }
                }
            }

            if (Subfoldercount == 0)
            {
                NandanaResult objinsertintofolder = objFolderManager.InsertFolderDetails(SelectedFileCabinetID, SubFolder.ToUpper(), MainFolderID, "True");
                if (objinsertintofolder.resultDS != null && objinsertintofolder.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = objinsertintofolder.resultDS.Tables[0].Rows[0];
                    SubFolderID = dr["FolderId"].ToString();
                }
            }

            // creating sub folders in FileCabinets path and moving that file into it
            m_sSubFolderFile = null;
            if (m_sSubFolderFile == null)
            {
                m_sSubFolderFile = m_sMainFolderFile + "\\" + SubFolder.ToUpper();
                if (!System.IO.Directory.Exists(m_sSubFolderFile))
                    System.IO.Directory.CreateDirectory(m_sSubFolderFile);
            }

            System.IO.File.Copy(FilePath, m_sSubFolderFile + "\\" + FileName, true);
            // End

            // Checking Files is present in Sub Folder of FileCabinet,if not Inserting Files into SubFolder

            int filecount = 0;


            NandanaResult objGetFiledetails = objFilesManager.GetFileDetails();

            DataTable objgetFiles = new DataTable();
            if (objGetFiledetails.resultDS != null && objGetFiledetails.resultDS.Tables[0].Rows.Count > 0)
            {

                DataRow[] drResult = objGetFiledetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + SelectedFileCabinetID + "'" + "and" + " Folder_ID = '" + SubFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    objgetFiles = drResult.CopyToDataTable();
                }

                if (objgetFiles != null && objgetFiles.Rows.Count > 0)
                {
                    foreach (DataRow dr in objgetFiles.Rows)
                    {
                        if (dr["File_Name"].ToString() == FileName)
                        {
                            filecount += 1;
                            //MainFolderID = node["Folder_ID"].InnerText;
                        }
                    }
                }
            }

            if (filecount == 0)
            {
                NandanaResult insertintofiles = objFilesManager.InsertFileDetails(Convert.ToInt32(SubFolderID), Convert.ToInt32(SelectedFileCabinetID), FileName, m_sSubFolderFile + "\\" + FileName, "True");
                if (insertintofiles.resultDS != null && insertintofiles.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = insertintofiles.resultDS.Tables[0].Rows[0];
                    FileID = dr["FileId"].ToString();
                }
            }
        }
        else
        {
            // Checking Files is present in Sub Folder of FileCabinet,if not Inserting Files into SubFolder

            System.IO.File.Copy(FilePath, m_sMainFolderFile + "\\" + FileName, true);

            int filecount = 0;

            NandanaResult objgetfiledetails = objFilesManager.GetFileDetails();

            DataTable objgetFiles = new DataTable();
            if (objgetfiledetails.resultDS != null && objgetfiledetails.resultDS.Tables[0].Rows.Count != 0)
            {

                DataRow[] drResult = objgetfiledetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + SelectedFileCabinetID + "'" + "and" + " Folder_ID = '" + MainFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
                if (drResult.Count() != 0)
                {
                    objgetFiles = drResult.CopyToDataTable();
                }

                if (objgetFiles != null && objgetFiles.Rows.Count > 0)
                {
                    foreach (DataRow dr in objgetFiles.Rows)
                    {
                        if (dr["File_Name"].ToString() == FileName)
                        {
                            filecount += 1;
                            //MainFolderID = node["Folder_ID"].InnerText;
                        }
                    }
                }
            }


            if (filecount == 0)
            {
                // Insert into tbl_files table

                NandanaResult insertintofiles = objFilesManager.InsertFileDetails(Convert.ToInt32(MainFolderID), Convert.ToInt32(SelectedFileCabinetID), FileName, m_sMainFolderFile + "\\" + FileName, "True");
                if (insertintofiles.resultDS != null && insertintofiles.resultDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = insertintofiles.resultDS.Tables[0].Rows[0];
                    FileID = dr["FileId"].ToString();
                }

                // end
            }
        }
    }

    public void UnMatchedDocumentsInFileCabinet(string FilePath, string FileName)
    {
        m_sConfigFile = null;
        m_sRootFile = null;
        m_sMainFolderFile = null;
        m_sSubFolderFile = null;

        m_sConfigFile = null;
        if (m_sConfigFile == null)
        {
            m_sConfigFile = ConfigurationManager.AppSettings["TreeviewFilepath"].ToString();
            if (!System.IO.Directory.Exists(m_sConfigFile))
                System.IO.Directory.CreateDirectory(m_sConfigFile);
        }

        if (SelectedFileCabinetID == null)
        {
            SelectedFileCabinetID = "1";
        }


        NandanaResult objgetfilecabinets = objFileCabinetManager.GetFileCabinets();
        if (objgetfilecabinets.resultDS != null && objgetfilecabinets.resultDS.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in objgetfilecabinets.resultDS.Tables[0].Rows)
            {
                if (dr["FileCabinet_ID"].ToString() == SelectedFileCabinetID)
                {
                    FileCabinetName = dr["FileCabinet_Name"].ToString().ToUpper();

                    m_sRootFile = null;
                    if (m_sRootFile == null)
                    {
                        m_sRootFile = m_sConfigFile + "\\" + FileCabinetName.ToUpper();
                        if (!System.IO.Directory.Exists(m_sRootFile))
                            System.IO.Directory.CreateDirectory(m_sRootFile);
                    }
                }
            }
            if (FileCabinetName == string.Empty)
            {
                FileCabinetName = "";
            }

        }

        int Mainfoldercount = 0;


        NandanaResult objgetfolderdetails = objFolderManager.GetFolderDetails();
        DataTable getFolderNames = new DataTable();
        if (objgetfolderdetails.resultDS != null && objgetfolderdetails.resultDS.Tables[0].Rows.Count > 0)
        {
            DataRow[] drResult = objgetfolderdetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + SelectedFileCabinetID + "'" + "and" + " ParentFolderID = '" + 0 + "'" + "and" + " IsDelete = '" + "True" + "'");
            if (drResult.Count() != 0)
            {
                getFolderNames = drResult.CopyToDataTable();
            }


            if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
            {
                foreach (DataRow dr in getFolderNames.Rows)
                {
                    if (dr["Folder_Name"].ToString().ToUpper() == "Mismatched".ToUpper())
                    {
                        Mainfoldercount += 1;
                        MainFolderID = dr["Folder_ID"].ToString();
                    }
                }
            }
        }
        if (Mainfoldercount == 0)
        {
            // insert into tbl_folder table

            NandanaResult objinsertintofolder = objFolderManager.InsertFolderDetails(SelectedFileCabinetID, "Mismatched".ToUpper(), "0", "True");
            if (objinsertintofolder.resultDS != null && objinsertintofolder.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = objinsertintofolder.resultDS.Tables[0].Rows[0];
                MainFolderID = dr["FolderId"].ToString();
            }

            // end
        }

        m_sMainFolderFile = null;
        if (m_sMainFolderFile == null)
        {
            m_sMainFolderFile = m_sRootFile + "\\" + "Mismatched".ToUpper();
            if (!System.IO.Directory.Exists(m_sMainFolderFile))
                System.IO.Directory.CreateDirectory(m_sMainFolderFile);
        }



        System.IO.File.Copy(FilePath, m_sMainFolderFile + "\\" + FileName, true);

        int filecount = 0;

        NandanaResult objgetfiledetails = objFilesManager.GetFileDetails();

        DataTable objgetFiles = new DataTable();
        if (objgetfiledetails.resultDS != null && objgetfiledetails.resultDS.Tables[0].Rows.Count != 0)
        {

            DataRow[] drResult = objgetfiledetails.resultDS.Tables[0].Select("FileCabinet_ID = '" + SelectedFileCabinetID + "'" + "and" + " Folder_ID = '" + MainFolderID + "'" + "and" + " IsDelete = '" + "True" + "'");
            if (drResult.Count() != 0)
            {
                objgetFiles = drResult.CopyToDataTable();
            }

            if (objgetFiles.HasErrors != null && objgetFiles.Rows.Count > 0)
            {
                foreach (DataRow dr in objgetFiles.Rows)
                {
                    if (dr["File_Name"].ToString() == FileName)
                    {
                        filecount += 1;
                    }
                }
            }
        }

        if (filecount == 0)
        {
            // Insert into tbl_files table

            NandanaResult insertintofiles = objFilesManager.InsertFileDetails(Convert.ToInt32(MainFolderID), Convert.ToInt32(SelectedFileCabinetID), FileName, m_sMainFolderFile + "\\" + FileName, "True");
            if (insertintofiles.resultDS != null && insertintofiles.resultDS.Tables[0].Rows.Count > 0)
            {
                DataRow dr = insertintofiles.resultDS.Tables[0].Rows[0];
                FileID = dr["FileId"].ToString();
            }

            // end
        }
    }
}

