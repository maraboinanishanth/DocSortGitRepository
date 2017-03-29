using System;
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
using System.Xml;
using System.Security.Cryptography;
using System.Diagnostics;

namespace DocSort_CPA.Forms
{
    public partial class SearchProcessing : Form
    {
        public SearchProcessing()
        {
            InitializeComponent();
        }

        DataTable Dttemp = new DataTable();

        FileCabinetClass FileCabinetClass = new FileCabinetClass();

        //SearchString Searchstring = new SearchString();

        private void SearchProcessing_Load(object sender, EventArgs e)
        {
            picProcess.Visible = true;

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

            CheckingValuesInConfigToRunProcess();
        }
        BackgroundWorker worker;
        int j = 0;
        private static string m_sDocFile;
        private static string m_sDocFolderFile;
        private static string m_sDocCategoryFolderFile;
        private static string m_sDocUnMatchFile;
        private static string m_sConfigFile;
        private static string m_sLogFile;
        private static string m_sDocUnReadFile;
        private static string m_sImages;

        TallComponents.PDF.Rasterizer.Document document = null;
        public bool IsUnMatchedChecked = false;
        public int FileCount = 0;
        public int UnMatchFileCount = 0;
        public int UnReadFileCount = 0;
        public string SourceFolder;
        public string DestinationFolder;
        public string SearchValue;
        public string CategoryValue;
        public string CategoryName;
        public string CategoryID;
        public string DocumentErrorFolder = System.Configuration.ConfigurationSettings.AppSettings["DocumentationError"];

        int ScannedReadCountConfigValue = 0;
        int LockDocCountConfigValue = 0;
        int IsExpiredConfigValue = 0;
        int TotalGivenDocCount = 0;

        bool cancel = false;
        public void CheckingValuesInConfigToRunProcess()
        {
            try
            {
                Dttemp.Clear();

                progressBar1.Visible = true;
                //lblRunningFile.Visible = true;
                lblRemainingTime.Visible = true;
                lblFileName.Visible = true;
                lblFileName.Text = "";
                lblStatus.Visible = true;
                //lblStatus.Location = new Point(250, 97);
                lblStatus.Text = "";



                string DocumentErrorFolder = System.Configuration.ConfigurationSettings.AppSettings["DocumentationError"];


                string SearchText = string.Empty;

                int filecount = Directory.GetFiles(SourceFolder, "*", SearchOption.AllDirectories).Length;

                worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = true;
                worker.WorkerReportsProgress = true;
                worker.ProgressChanged += (se, eventArgs) =>
                {
                    this.progressBar1.Maximum = filecount;
                    this.progressBar1.Minimum = 0;
                    this.progressBar1.Value = eventArgs.ProgressPercentage;
                    lblStatus.Text = eventArgs.UserState as String;
                    // lblPercentage.Text = String.Format("Progress: {0} ", eventArgs.ProgressPercentage);
                    //lblFileName.Text = eventArgs.UserState as String;
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

                    TotalGivenDocCount = ScannedReadCountConfigValue + LockDocCountConfigValue;

                    if (IsExpiredConfigValue == -1)
                    {
                        ConfirmLicense objConfirmLicense = new ConfirmLicense();
                        objConfirmLicense.ShowDialog();
                        if (objConfirmLicense.ConfigID != null)
                        {

                            /// verify if already Licensekey used or not
                            objConfirmLicense.Hide();
                            Dttemp.Clear();

                            ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.ScannedReadCountConfigValue).ToString());
                            LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(objConfirmLicense.LockDocCountConfigValue).ToString());
                            IsExpiredConfigValue = 1;
                            UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                        }
                    }
                    if (ScannedReadCountConfigValue > 0)
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
                                IsExpiredConfigValue = -1;
                                UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);

                                ConfirmLicense objConfirmLicense = new ConfirmLicense();
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
                    else
                    {
                        IsExpiredConfigValue = -1;
                        UpdateScannedConfigValues(ScannedReadCountConfigValue, LockDocCountConfigValue, IsExpiredConfigValue);
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
                    lblStatus.Location = new Point(118, 40);
                    lblStatus.Text = "Your Process has been completed";
                    lblFileName.Visible = false;
                    progressBar1.Visible = false;
                    lblRemainingTime.Visible = false;
                    //btnBack.Enabled = true;
                    //btnFinish.Enabled = true;

                    btnCancel.Text = "Close";
                    picProcess.Visible = false;
                };

                worker.RunWorkerAsync();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetScannedConfigvalues(out  int ScannedReadCountConfigValue, out int LockDocCountConfigValue, out int IsExpiredConfigValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("XMLs/Config.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_Config");
            ScannedReadCountConfigValue = 0;
            LockDocCountConfigValue = 0;
            IsExpiredConfigValue = 0;
            foreach (XmlNode node in nodeList)
            {
                switch (Convert.ToString(node["Config_Name"].InnerText).ToUpper())
                {

                    case "SCANRECORDCOUNT":
                        ScannedReadCountConfigValue = Convert.ToInt32(this.Decrypt(node["Config_Value"].InnerText));
                        break;
                    case "LOCKDOCCOUNT":
                        LockDocCountConfigValue = Convert.ToInt32(this.Decrypt(node["Config_Value"].InnerText));
                        break;
                    case "ISEXPIRED":
                        IsExpiredConfigValue = Convert.ToInt32(node["Config_Value"].InnerText);
                        break;

                }
            }
        }
        private void UpdateScannedConfigValues(int ScannedReadCountConfigValue, int LockDocCountConfigValue, int IsExpiredConfigValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("XMLs/Config.xml");
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_Config");
            foreach (XmlNode node in nodeList)
            {
                switch (Convert.ToString(node["Config_Name"].InnerText).ToUpper())
                {

                    case "SCANRECORDCOUNT":
                        node["Config_Value"].InnerText = this.Encrypt(ScannedReadCountConfigValue.ToString());
                        break;

                    case "LOCKDOCCOUNT":
                        node["Config_Value"].InnerText = this.Encrypt(LockDocCountConfigValue.ToString());
                        break;

                    case "ISEXPIRED":
                        node["Config_Value"].InnerText = IsExpiredConfigValue.ToString();
                        break;

                }
            }
            xmlDoc.Save("XMLs/Config.xml");
        }

        public string FileCabinetName = string.Empty;
        public string FileCabinetID = string.Empty;

        private XmlDocument docDocuments;
        private const string PATHDocuments = "XMLs/DocumentsList.xml";

        private XmlDocument docKeywords;
        private const string PATHKeywords = "XMLs/Keywords.xml";

        private XmlDocument docScanned;
        private const string PATHScanned = "XMLs/ScannedDocumentResults.xml";

        private void UpdateKeyWordsXML(string keyWord, string subSection, string startWith, string endWith)
        {
            //Create an xml document
            docKeywords = new XmlDocument();
            //If there is no current file, then create a new one
            if (!System.IO.File.Exists(PATHKeywords))
            {
                //Create neccessary nodes

                XmlElement Mainroot = docKeywords.CreateElement("Table");
                XmlElement table = docKeywords.CreateElement("tbl_Keywords");
                XmlElement Id = docKeywords.CreateElement("ID");
                //XmlElement Date = docKeywords.CreateElement("Date");
                XmlElement Keyword = docKeywords.CreateElement("Keyword");
                XmlElement SubSection = docKeywords.CreateElement("SubSection");
                XmlElement StartWith = docKeywords.CreateElement("StartWith");
                XmlElement EndWith = docKeywords.CreateElement("EndWith");

                //Add the values for each nodes

                KeywordID = "1";
                Id.InnerText = KeywordID;
                //Date.InnerText = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"); ;
                Keyword.InnerText = keyWord;
                SubSection.InnerText = subSection;
                StartWith.InnerText = startWith;
                EndWith.InnerText = endWith;

                //Construct the document
                docKeywords.AppendChild(Mainroot);

                Mainroot.AppendChild(table);
                table.AppendChild(Id);
                //table.AppendChild(Date);
                table.AppendChild(Keyword);
                table.AppendChild(SubSection);
                table.AppendChild(StartWith);
                table.AppendChild(EndWith);

                docKeywords.Save(PATHKeywords);
            }
            else //If there is already a file
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("XMLs/Keywords.xml");
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_Keywords");

                //Load the XML File
                docKeywords.Load(PATHKeywords);

                string AssignKeywordID = string.Empty;
                //int LatestID = 0;

                DataTable getFolderNames = new DataTable();
                string dfFolder = "XMLs/Keywords.xml";
                DataSet dsFolder = new DataSet();
                dsFolder.ReadXml(dfFolder);
                if (dsFolder.Tables.Count != 0)
                {
                    if (dsFolder.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drResult = dsFolder.Tables[0].Select("Keyword = '" + keyWord + "'" + "and" + " SubSection = '" + subSection + "'");
                        if (drResult.Count() != 0)
                        {
                            getFolderNames = drResult.CopyToDataTable();
                        }
                    }
                    if (getFolderNames.HasErrors != null && getFolderNames.Rows.Count > 0)
                    {
                        DataRow dr = getFolderNames.Rows[0];
                        AssignKeywordID = dr["ID"].ToString();
                        KeywordID = AssignKeywordID;
                    }
                }

                //foreach (XmlNode detailNode in nodeList)
                //{
                //    string MatchedKeyWord = detailNode.SelectSingleNode("Keyword").InnerText;
                //    string MatchedSubsction = detailNode.SelectSingleNode("SubSection").InnerText;
                //    LatestID = Convert.ToInt32(detailNode.SelectSingleNode("ID").InnerText);

                //    if (keyWord == MatchedKeyWord && subSection == MatchedSubsction)
                //    {
                //        AssignKeywordID = detailNode.SelectSingleNode("ID").InnerText;
                //        KeywordID = AssignKeywordID;
                //    }
                //}

                if (AssignKeywordID == string.Empty)
                {
                    //Get the root element
                    XmlElement root = docKeywords.DocumentElement;

                    XmlElement table = docKeywords.CreateElement("tbl_Keywords");
                    XmlElement Id = docKeywords.CreateElement("ID");
                    //XmlElement Date = docKeywords.CreateElement("Date");
                    XmlElement Keyword = docKeywords.CreateElement("Keyword");
                    XmlElement SubSection = docKeywords.CreateElement("SubSection");
                    XmlElement StartWith = docKeywords.CreateElement("StartWith");
                    XmlElement EndWith = docKeywords.CreateElement("EndWith");

                    //Add the values for each nodes

                    Id.InnerText = (nodeList.Count + 1).ToString();
                    KeywordID = (nodeList.Count + 1).ToString();
                    //Date.InnerText = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                    Keyword.InnerText = keyWord;
                    SubSection.InnerText = subSection;
                    StartWith.InnerText = startWith;
                    EndWith.InnerText = endWith;

                    //Construct the Person element
                    table.AppendChild(Id);
                    //table.AppendChild(Date);
                    table.AppendChild(Keyword);
                    table.AppendChild(SubSection);
                    table.AppendChild(StartWith);
                    table.AppendChild(EndWith);

                    //Add the New person element to the end of the root element
                    root.AppendChild(table);

                    //Save the document
                    docKeywords.Save(PATHKeywords);
                }
            }

        }

        private void updateScannedDocXML(string keywordID, string documentID, string documentPath)
        {
            //Create an xml document
            docScanned = new XmlDocument();

            //If there is no current file, then create a new one
            if (!System.IO.File.Exists(PATHScanned))
            {
                //Create neccessary nodes

                XmlElement Mainroot = docScanned.CreateElement("Table");
                XmlElement table = docScanned.CreateElement("tbl_ScannedDocumentResults");
                XmlElement Id = docScanned.CreateElement("ID");
                XmlElement Date = docScanned.CreateElement("Date");
                XmlElement Keyword_ID = docScanned.CreateElement("Keyword_ID");
                XmlElement Document_ID = docScanned.CreateElement("Document_ID");
                XmlElement Document_Path = docScanned.CreateElement("Document_Path");
                XmlElement Match = docScanned.CreateElement("Match");

                //Add the values for each nodes

                Id.InnerText = "1";
                Date.InnerText = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                Keyword_ID.InnerText = keywordID.Trim();
                Document_ID.InnerText = documentID;
                Document_Path.InnerText = documentPath;
                Match.InnerText = "True";

                //Construct the document
                docScanned.AppendChild(Mainroot);

                Mainroot.AppendChild(table);
                table.AppendChild(Id);
                table.AppendChild(Date);
                table.AppendChild(Keyword_ID);
                table.AppendChild(Document_ID);
                table.AppendChild(Document_Path);
                table.AppendChild(Match);

                docScanned.Save(PATHScanned);
            }
            else //If there is already a file
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("XMLs/ScannedDocumentResults.xml");
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_ScannedDocumentResults");

                //Load the XML File
                docScanned.Load(PATHScanned);

                //Get the root element
                XmlElement root = docScanned.DocumentElement;

                XmlElement table = docScanned.CreateElement("tbl_ScannedDocumentResults");
                XmlElement Id = docScanned.CreateElement("ID");
                XmlElement Date = docScanned.CreateElement("Date");
                XmlElement Keyword_ID = docScanned.CreateElement("Keyword_ID");
                XmlElement Document_ID = docScanned.CreateElement("Document_ID");
                XmlElement Document_Path = docScanned.CreateElement("Document_Path");
                XmlElement Match = docScanned.CreateElement("Match");

                //Add the values for each nodes

                Id.InnerText = (nodeList.Count + 1).ToString();
                Date.InnerText = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                Keyword_ID.InnerText = keywordID;
                Document_ID.InnerText = documentID;
                Document_Path.InnerText = documentPath;
                Match.InnerText = "True";

                //Construct the Person element
                table.AppendChild(Id);
                table.AppendChild(Date);
                table.AppendChild(Keyword_ID);
                table.AppendChild(Document_ID);
                table.AppendChild(Document_Path);
                table.AppendChild(Match);

                //Add the New person element to the end of the root element
                root.AppendChild(table);

                //Save the document
                docScanned.Save(PATHScanned);
            }


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

                FileCabinetClass.SelectedFileCabinetID = FileCabinetID;
                FileCabinetName = FileCabinetClass.GetRootFileCabinetName();

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
                                    FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }
                                else
                                {
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                    // Saving in FileCabinet
                                    FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }

                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());


                                    //* End  *//

                                    //NandanaResult objinsertscanneddocumentresults = objMoveFilesManager.InsertScannedDocumentResultsDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "True");
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());

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
                                    FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }
                                else
                                {
                                    System.IO.File.Copy(dtFinal.Rows[i]["FilePath"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), true);

                                    // Saving in FileCabinet
                                    FileCabinetClass.MatchedDocumentsInFileCabinet(dtFinal.Rows[i]["Search"].ToString(), dtFinal.Rows[i]["ValueCategory"].ToString(), dtFinal.Rows[i]["FileName"].ToString(), dtFinal.Rows[i]["FilePath"].ToString());
                                    // End
                                }
                                if (dtFinal.Rows[i]["ValueCategory"].ToString() != "")
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());


                                    //* End  *//

                                    //NandanaResult objinsertscanneddocumentresults = objMoveFilesManager.InsertScannedDocumentResultsDetails(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString(), "True");
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());

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
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());
                                    //Create an xml document
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID, dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());
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
                                    updateScannedDocXML(KeywordID.Trim(), dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocCategoryFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());
                                    //Create an xml document
                                }
                                else
                                {
                                    updateScannedDocXML(KeywordID, dtFinal.Rows[i]["DocumentID"].ToString(), m_sDocFolderFile + "\\" + dtFinal.Rows[i]["FileName"].ToString());
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

        private void MoveMyFiles(string path)
        {
            string FileName = System.IO.Path.GetFileName(path);

            //Create an xml document
            docDocuments = new XmlDocument();

            //If there is no current file, then create a new one 
            /// log the all scanned documents
            /// 
            #region Log All Scanned documents to tbl_DocumentsList.xml
            if (!System.IO.File.Exists(PATHDocuments))
            {
                //Create neccessary nodes
                /// Create DocumentsList Xml if not exists
                XmlElement Mainroot = docDocuments.CreateElement("Table");
                XmlElement table = docDocuments.CreateElement("tbl_DocumentsList");
                XmlElement Id = docDocuments.CreateElement("ID");
                XmlElement Date = docDocuments.CreateElement("Date");
                XmlElement File_Name = docDocuments.CreateElement("File_Name");


                //Add the values for each nodes               

                Id.InnerText = "1";
                DocumentID = "1";
                Date.InnerText = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                File_Name.InnerText = FileName.Trim();


                //Construct the document
                docDocuments.AppendChild(Mainroot);

                Mainroot.AppendChild(table);
                table.AppendChild(Id);
                table.AppendChild(Date);
                table.AppendChild(File_Name);


                docDocuments.Save(PATHDocuments);
            }
            else //If there is already a file
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("XMLs/DocumentsList.xml");
                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Table/tbl_DocumentsList");

                //Load the XML File
                docDocuments.Load(PATHDocuments);

                //Get the root element
                XmlElement root = docDocuments.DocumentElement;

                XmlElement table = docDocuments.CreateElement("tbl_DocumentsList");
                XmlElement Id = docDocuments.CreateElement("ID");
                XmlElement Date = docDocuments.CreateElement("Date");
                XmlElement File_Name = docDocuments.CreateElement("File_Name");

                //Add the values for each nodes


                Id.InnerText = (nodeList.Count + 1).ToString();
                DocumentID = (nodeList.Count + 1).ToString();
                Date.InnerText = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                File_Name.InnerText = FileName.Trim();

                //Construct the Person element
                table.AppendChild(Id);
                table.AppendChild(Date);
                table.AppendChild(File_Name);


                //Add the New person element to the end of the root element
                root.AppendChild(table);

                //Save the document
                docDocuments.Save(PATHDocuments);
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
                case "XLS":
                    ReadExcelDocuments(path, FileName, DocumentID);
                    break;
                case "XLSX":
                    ReadExcelDocuments(path, FileName, DocumentID);
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

        public void ReadExcelDocuments(string path, string FileName, string DocumentID)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

            OleDbConnection connExcel = new OleDbConnection(excelConnectionString);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            System.Data.DataTable dt = new System.Data.DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            //connExcel.Open();
            //cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            //oda.SelectCommand = cmdExcel;
            //OleDbDataReader ExcelReader = cmdExcel.ExecuteReader();

            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            string ExcelData = string.Empty;

            //ExcelData = convertDataTableToString(dt);

            //if (ExcelData != null)
            //{

            //}
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object o = dt.Rows[i].ItemArray[j];
                    //if you want to get the string
                    ExcelData = ExcelData + o.ToString() + " ";
                }

            //string Text = string.Empty;
            //using (ExcelReader dr = cmdExcel.ExecuteReader(CommandBehavior.SequentialAccess))
            //while (ExcelReader.Read())
            //{
            //    object item = ExcelReader.GetValue(0);
            //    //textBox1.AppendText(item.ToString() + Environment.NewLine);
            //    Text = Text +  item.ToString() + Environment.NewLine;
            //    //((ExcelReader.GetValue(0)).ToString());
            //}
            //connExcel.Close();
            try
            {
                //string text = File.ReadAllText(ExcelReader.Read(path));
            }
            catch (IOException)
            {
            }

            //if (dt != "")
            //{
            //    if (readContents.Contains(Start.ToUpper()))
            //    {

            //    }
            //}
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

                string[] SearchValues = SearchValue.Split(',');
                int Searchcount = 0;
                int compareposition = 0;
                string comparesearchstringvalue = string.Empty;

                for (int i = 0; i < SearchValues.Length; i++)
                {
                    if (SearchValues[i].ToString() != "")
                    {
                        if (readContents.Contains(SearchValues[i].ToString().ToUpper()))
                        {
                            Searchcount += 1;

                            int position = readContents.IndexOf(SearchValues[i].ToString().ToUpper());

                            int nextposition = position;

                            if (Searchcount == 1)
                            {
                                compareposition = position;

                                comparesearchstringvalue = compareposition + "-" + i;
                            }
                            else
                            {
                                int result = Math.Min(compareposition, nextposition);
                                if (result == compareposition)
                                {
                                    compareposition = result;
                                    comparesearchstringvalue = comparesearchstringvalue;
                                }
                                else if (result == nextposition)
                                {
                                    compareposition = result;
                                    comparesearchstringvalue = compareposition + "-" + i;
                                }
                            }

                            //SearchText = SearchValues[i].ToString();
                            //SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                            //i = SearchValues.Length - 1;
                        }
                    }
                }
                if (Searchcount != 0)
                {
                    string[] searchtextvalue = comparesearchstringvalue.Split('-');

                    SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                    if (SearchText != "")
                    {
                        // Checking any one of the Category Value is present in contened Data or not
                        if (CategoryValue != "")
                        {
                            string[] yearCategoryValues = CategoryValue.Split(',');
                            string GivenTotalYears = string.Empty;
                            for (int k = 0; k < yearCategoryValues.Length; k++)
                            {
                                if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                {
                                    string Yearcounting = string.Empty;
                                    string Presentyear = string.Empty;
                                    int i = 0;
                                    string[] yearValues = yearCategoryValues[k].Split('-');
                                    do
                                    {
                                        Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                                        Yearcounting = Yearcounting + Presentyear + ",";
                                        i++;
                                    } while (yearValues[1].ToString() != Presentyear);

                                    GivenTotalYears = GivenTotalYears + Yearcounting;
                                }
                                else
                                {
                                    GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                }
                            }

                            string[] CategoryValues = GivenTotalYears.Split(',');
                            int count = 0;
                            int Yearcompareposition = 0;
                            string Yearcomparesearchstringvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (readContents.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        count += 1;

                                        int position = readContents.IndexOf(CategoryValues[i].ToString().ToUpper());

                                        int nextposition = position;

                                        if (count == 1)
                                        {
                                            Yearcompareposition = position;

                                            Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                        }
                                        else
                                        {
                                            int result = Math.Min(Yearcompareposition, nextposition);
                                            if (result == Yearcompareposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                            }
                                            else if (result == nextposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                            }
                                        }

                                    }
                                }
                            }

                            if (count == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Miscellaneous";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');
                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                FileCount = FileCount + 1;
                            }

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);
                        }
                    }
                    else
                    {
                        if (IsUnMatchedChecked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                        }
                    }
                    // End

                }
                else
                {
                    int UnMatchedSearchcount = 0;
                    int UnMatchedcompareposition = 0;
                    string UnMatchedcomparesearchstringvalue = string.Empty;
                    for (int i = 0; i < SearchValues.Length; i++)
                    {
                        if (SearchValues[i].ToString() != "")
                        {
                            for (int j = 0; j < (SearchValues[i].Length - 4) + 1; j++)
                            {
                                if (readContents.Contains(SearchValues[i].Substring(j, 4).ToString().ToUpper()))
                                {
                                    UnMatchedSearchcount += 1;

                                    int position = readContents.IndexOf(SearchValues[i].Substring(j, 4).ToString().ToUpper());

                                    int nextposition = position;

                                    if (UnMatchedSearchcount == 1)
                                    {
                                        UnMatchedcompareposition = position;

                                        UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + i;

                                        j = (SearchValues[i].Length - 3);
                                    }
                                    else
                                    {
                                        int result = Math.Min(UnMatchedcompareposition, nextposition);
                                        if (result == UnMatchedcompareposition)
                                        {
                                            UnMatchedcompareposition = result;
                                            UnMatchedcomparesearchstringvalue = UnMatchedcomparesearchstringvalue;
                                        }
                                        else if (result == nextposition)
                                        {
                                            UnMatchedcompareposition = result;
                                            UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + i;
                                        }

                                        j = (SearchValues[i].Length - 3);
                                    }

                                    //SearchText = SearchValues[i].ToString();
                                    //SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                    //j = (SearchValues[i].Length - 3);

                                    //i = SearchValues.Length - 1;
                                }
                            }
                        }
                    }
                    if (UnMatchedSearchcount != 0)
                    {
                        string[] searchtextvalue = UnMatchedcomparesearchstringvalue.Split('-');

                        SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                        SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                        if (CategoryValue != "")
                        {
                            string[] yearCategoryValues = CategoryValue.Split(',');
                            string GivenTotalYears = string.Empty;
                            for (int k = 0; k < yearCategoryValues.Length; k++)
                            {
                                if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                {
                                    string Yearcounting = string.Empty;
                                    string Presentyear = string.Empty;
                                    int i = 0;
                                    string[] yearValues = yearCategoryValues[k].Split('-');
                                    do
                                    {
                                        Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                                        Yearcounting = Yearcounting + Presentyear + ",";
                                        i++;
                                    } while (yearValues[1].ToString() != Presentyear);

                                    GivenTotalYears = GivenTotalYears + Yearcounting;
                                }
                                else
                                {
                                    GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                }
                            }
                            string[] CategoryValues = GivenTotalYears.Split(',');
                            int Categorycount = 0;
                            int Yearcompareposition = 0;
                            string Yearcomparesearchstringvalue = string.Empty;
                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (readContents.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        Categorycount += 1;


                                        int position = readContents.IndexOf(CategoryValues[i].ToString().ToUpper());

                                        int nextposition = position;

                                        if (Categorycount == 1)
                                        {
                                            Yearcompareposition = position;

                                            Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                        }
                                        else
                                        {
                                            int result = Math.Min(Yearcompareposition, nextposition);
                                            if (result == Yearcompareposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                            }
                                            else if (result == nextposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                            }
                                        }
                                    }
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Miscellaneous";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');

                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();

                                FileCount = FileCount + 1;


                            }

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);

                        }
                    }
                    else
                    {
                        if (IsUnMatchedChecked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

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
            for (int i = 0; i < document.Pages.Count; i++)
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

                            string[] SearchValues = SearchValue.Split(',');
                            int Searchcount = 0;
                            int compareposition = 0;
                            string comparesearchstringvalue = string.Empty;

                            for (int k = 0; k < SearchValues.Length; k++)
                            {
                                if (SearchValues[k].ToString() != "")
                                {
                                    if (imgdata.Contains(SearchValues[k].ToString().ToUpper()))
                                    {
                                        Searchcount += 1;

                                        int position = imgdata.IndexOf(SearchValues[k].ToString().ToUpper());

                                        int nextposition = position;

                                        if (Searchcount == 1)
                                        {
                                            compareposition = position;

                                            comparesearchstringvalue = compareposition + "-" + k;
                                        }
                                        else
                                        {
                                            int result = Math.Min(compareposition, nextposition);
                                            if (result == compareposition)
                                            {
                                                compareposition = result;
                                                comparesearchstringvalue = comparesearchstringvalue;
                                            }
                                            else if (result == nextposition)
                                            {
                                                compareposition = result;
                                                comparesearchstringvalue = compareposition + "-" + k;
                                            }
                                        }

                                        //SearchText = SearchValues[k].ToString();
                                        //SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                        //k = SearchValues.Length - 1;
                                    }
                                }
                            }
                            if (Searchcount != 0)
                            {
                                string[] searchtextvalue = comparesearchstringvalue.Split('-');

                                SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                                SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                if (SearchText != "")
                                {
                                    // Checking any one of the Category Value is present in contened Data or not
                                    if (CategoryValue != "")
                                    {
                                        string[] yearCategoryValues = CategoryValue.Split(',');
                                        string GivenTotalYears = string.Empty;
                                        for (int k = 0; k < yearCategoryValues.Length; k++)
                                        {
                                            if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                            {
                                                string Yearcounting = string.Empty;
                                                string Presentyear = string.Empty;
                                                int increment = 0;
                                                string[] yearValues = yearCategoryValues[k].Split('-');
                                                do
                                                {
                                                    Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + increment).ToString();
                                                    Yearcounting = Yearcounting + Presentyear + ",";
                                                    increment++;
                                                } while (yearValues[1].ToString() != Presentyear);

                                                GivenTotalYears = GivenTotalYears + Yearcounting;
                                            }
                                            else
                                            {
                                                GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                            }
                                        }
                                        string[] CategoryValues = GivenTotalYears.Split(',');
                                        int Yearcompareposition = 0;
                                        string Yearcomparesearchstringvalue = string.Empty;

                                        for (int k = 0; k < CategoryValues.Length; k++)
                                        {
                                            if (CategoryValues[k].ToString() != "")
                                            {
                                                if (imgdata.Contains(CategoryValues[k].ToString().ToUpper()))
                                                {
                                                    count += 1;

                                                    int position = imgdata.IndexOf(CategoryValues[k].ToString().ToUpper());

                                                    int nextposition = position;

                                                    if (count == 1)
                                                    {
                                                        Yearcompareposition = position;

                                                        Yearcomparesearchstringvalue = Yearcompareposition + "-" + k;
                                                    }
                                                    else
                                                    {
                                                        int result = Math.Min(Yearcompareposition, nextposition);
                                                        if (result == Yearcompareposition)
                                                        {
                                                            Yearcompareposition = result;
                                                            Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                                        }
                                                        else if (result == nextposition)
                                                        {
                                                            Yearcompareposition = result;
                                                            Yearcomparesearchstringvalue = Yearcompareposition + "-" + k;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //if (i == document.Pages.Count - 1)
                                        //{
                                        if (count == 0)
                                        {
                                            FileCount = FileCount + 1;
                                            TypeOfDoc = "Miscellaneous";
                                        }
                                        else
                                        {
                                            string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');
                                            TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                            FileCount = FileCount + 1;
                                        }
                                        DataRow drtemp = Dttemp.NewRow();
                                        drtemp["Search"] = SearchText;
                                        //drtemp["IncludeAdditional"] = SecondParam;
                                        drtemp["ValueCategory"] = TypeOfDoc;
                                        drtemp["FilesFrom"] = SourceFolder;
                                        drtemp["FilesTo"] = DestinationFolder;
                                        drtemp["FilePath"] = path;
                                        drtemp["FileName"] = FileName;
                                        drtemp["DocumentID"] = DocumentID;
                                        Dttemp.Rows.Add(drtemp);

                                        i = document.Pages.Count - 1;
                                    }
                                    else
                                    {
                                        FileCount = FileCount + 1;

                                        DataRow drtemp = Dttemp.NewRow();
                                        drtemp["Search"] = SearchText;
                                        //drtemp["IncludeAdditional"] = SecondParam;
                                        drtemp["ValueCategory"] = TypeOfDoc;
                                        drtemp["FilesFrom"] = SourceFolder;
                                        drtemp["FilesTo"] = DestinationFolder;
                                        drtemp["FilePath"] = path;
                                        drtemp["FileName"] = FileName;
                                        drtemp["DocumentID"] = DocumentID;
                                        Dttemp.Rows.Add(drtemp);

                                        i = document.Pages.Count - 1;
                                    }
                                }
                                else if (i == document.Pages.Count - 1)
                                {
                                    if (UnMatchCount == 0)
                                    {
                                        if (IsUnMatchedChecked == true)
                                        {
                                            UnMatchFileCount = UnMatchFileCount + 1;

                                            if (m_sDocUnMatchFile == null)
                                            {
                                                m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                                            }
                                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                                        }
                                    }
                                }

                                // End
                            }
                            else
                            {
                                int UnMatchedSearchcount = 0;
                                int UnMatchedcompareposition = 0;
                                string UnMatchedcomparesearchstringvalue = string.Empty;
                                for (int k = 0; k < SearchValues.Length; k++)
                                {
                                    if (SearchValues[k].ToString() != "")
                                    {
                                        for (int j = 0; j < (SearchValues[k].Length - 4) + 1; j++)
                                        {
                                            if (imgdata.Contains(SearchValues[k].Substring(j, 4).ToString().ToUpper()))
                                            {
                                                UnMatchedSearchcount += 1;

                                                int position = imgdata.IndexOf(SearchValues[k].Substring(j, 4).ToString().ToUpper());

                                                int nextposition = position;

                                                if (UnMatchedSearchcount == 1)
                                                {
                                                    UnMatchedcompareposition = position;

                                                    UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + k;

                                                    j = (SearchValues[i].Length - 3);
                                                }
                                                else
                                                {
                                                    int result = Math.Min(UnMatchedcompareposition, nextposition);
                                                    if (result == UnMatchedcompareposition)
                                                    {
                                                        UnMatchedcompareposition = result;
                                                        UnMatchedcomparesearchstringvalue = UnMatchedcomparesearchstringvalue;
                                                    }
                                                    else if (result == nextposition)
                                                    {
                                                        UnMatchedcompareposition = result;
                                                        UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + k;
                                                    }

                                                    j = (SearchValues[k].Length - 3);
                                                }
                                                //SearchText = SearchValues[i].ToString();
                                                //SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                                //j = (SearchValues[k].Length - 3);

                                                //k = SearchValues.Length - 1;
                                            }
                                        }
                                    }
                                }
                                if (UnMatchedSearchcount != 0)
                                {
                                    string[] searchtextvalue = UnMatchedcomparesearchstringvalue.Split('-');

                                    SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                    // Checking any one of the Category Value is present in contened Data or not
                                    if (CategoryValue != "")
                                    {
                                        string[] yearCategoryValues = CategoryValue.Split(',');
                                        string GivenTotalYears = string.Empty;
                                        for (int k = 0; k < yearCategoryValues.Length; k++)
                                        {
                                            if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                            {
                                                string Yearcounting = string.Empty;
                                                string Presentyear = string.Empty;
                                                int increment = 0;
                                                string[] yearValues = yearCategoryValues[k].Split('-');
                                                do
                                                {
                                                    Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + increment).ToString();
                                                    Yearcounting = Yearcounting + Presentyear + ",";
                                                    increment++;
                                                } while (yearValues[1].ToString() != Presentyear);

                                                GivenTotalYears = GivenTotalYears + Yearcounting;
                                            }
                                            else
                                            {
                                                GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                            }
                                        }
                                        string[] CategoryValues = GivenTotalYears.Split(',');

                                        int Yearcompareposition = 0;
                                        string Yearcomparesearchstringvalue = string.Empty;

                                        for (int k = 0; k < CategoryValues.Length; k++)
                                        {
                                            if (CategoryValues[k].ToString() != "")
                                            {
                                                if (imgdata.Contains(CategoryValues[k].ToString().ToUpper()))
                                                {
                                                    count += 1;
                                                    int position = imgdata.IndexOf(CategoryValues[k].ToString().ToUpper());

                                                    int nextposition = position;

                                                    if (count == 1)
                                                    {
                                                        Yearcompareposition = position;

                                                        Yearcomparesearchstringvalue = Yearcompareposition + "-" + k;
                                                    }
                                                    else
                                                    {
                                                        int result = Math.Min(Yearcompareposition, nextposition);
                                                        if (result == Yearcompareposition)
                                                        {
                                                            Yearcompareposition = result;
                                                            Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                                        }
                                                        else if (result == nextposition)
                                                        {
                                                            Yearcompareposition = result;
                                                            Yearcomparesearchstringvalue = Yearcompareposition + "-" + k;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //if (i == document.Pages.Count - 1)
                                        //{
                                        if (count == 0)
                                        {
                                            FileCount = FileCount + 1;
                                            TypeOfDoc = "Miscellaneous";
                                        }
                                        else
                                        {
                                            FileCount = FileCount + 1;
                                            string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');
                                            TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                        }


                                        DataRow drtemp = Dttemp.NewRow();
                                        drtemp["Search"] = SearchText;
                                        //drtemp["IncludeAdditional"] = SecondParam;
                                        drtemp["ValueCategory"] = TypeOfDoc;
                                        drtemp["FilesFrom"] = SourceFolder;
                                        drtemp["FilesTo"] = DestinationFolder;
                                        drtemp["FilePath"] = path;
                                        drtemp["FileName"] = FileName;
                                        drtemp["DocumentID"] = DocumentID;
                                        Dttemp.Rows.Add(drtemp);

                                        i = document.Pages.Count - 1;
                                    }
                                    else
                                    {
                                        FileCount = FileCount + 1;

                                        DataRow drtemp = Dttemp.NewRow();
                                        drtemp["Search"] = SearchText;
                                        //drtemp["IncludeAdditional"] = SecondParam;
                                        drtemp["ValueCategory"] = TypeOfDoc;
                                        drtemp["FilesFrom"] = SourceFolder;
                                        drtemp["FilesTo"] = DestinationFolder;
                                        drtemp["FilePath"] = path;
                                        drtemp["FileName"] = FileName;
                                        drtemp["DocumentID"] = DocumentID;
                                        Dttemp.Rows.Add(drtemp);

                                        i = document.Pages.Count - 1;
                                    }


                                    // End
                                }
                                else if (i == document.Pages.Count - 1)
                                {
                                    if (UnMatchCount == 0)
                                    {
                                        if (IsUnMatchedChecked == true)
                                        {
                                            UnMatchFileCount = UnMatchFileCount + 1;

                                            if (m_sDocUnMatchFile == null)
                                            {
                                                m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                                            }
                                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                                        }
                                    }
                                }
                            }
                        }
                        else if (i == document.Pages.Count - 1)
                        {
                            if (UnReadCount == 0)
                            {
                                UnReadFileCount = UnReadFileCount + 1;
                                //if (m_sDocFile == null)
                                //{
                                //    m_sDocFile = DestinationFolder + "\\" + CategoryName;
                                //    if (!System.IO.Directory.Exists(m_sDocFile))
                                //        System.IO.Directory.CreateDirectory(m_sDocFile);
                                //}
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

                if (i == document.Pages.Count - 1)
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
        public void ReadImageFiles(string path, string FileName, string DocumentID)
        {
            try
            {
                //OCR Operations ... 
                MODI.Document md = new MODI.Document();
                md.Create(Convert.ToString(path));
                md.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);
                MODI.Image image = (MODI.Image)md.Images[0];

                string imgdata = image.Layout.Text.ToUpper();
                if (imgdata != "")
                {
                    string SearchText = string.Empty;
                    string TypeOfDoc = string.Empty;
                    string[] SearchValues = SearchValue.Split(',');
                    int Searchcount = 0;
                    int compareposition = 0;
                    string comparesearchstringvalue = string.Empty;
                    for (int k = 0; k < SearchValues.Length; k++)
                    {
                        #region Take least positioned Matched string
                        if (SearchValues[k].ToString() != "")
                        {
                            if (imgdata.Contains(SearchValues[k].ToString().ToUpper()))
                            {
                                Searchcount += 1;
                                int position = imgdata.IndexOf(SearchValues[k].ToString().ToUpper());
                                int nextposition = position;
                                if (Searchcount == 1)
                                {
                                    compareposition = position;
                                    comparesearchstringvalue = compareposition + "-" + k; // position_ SearchString
                                }
                                else
                                {

                                    int result = Math.Min(compareposition, nextposition);
                                    if (result == compareposition)
                                    {
                                        compareposition = result;
                                        comparesearchstringvalue = comparesearchstringvalue;
                                    }
                                    else if (result == nextposition)
                                    {
                                        compareposition = result;
                                        comparesearchstringvalue = compareposition + "-" + k;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    if (Searchcount != 0)
                    {
                        string[] searchtextvalue = comparesearchstringvalue.Split('-');
                        SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                        SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                        if (SearchText != "")
                        {
                            if (CategoryValue != "")
                            {
                                #region Take Least positioned Category Value
                                string[] yearCategoryValues = CategoryValue.Split(',');
                                string GivenTotalYears = string.Empty;
                                for (int k = 0; k < yearCategoryValues.Length; k++)
                                {
                                    if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                    {
                                        string Yearcounting = string.Empty;
                                        string Presentyear = string.Empty;
                                        int i = 0;
                                        string[] yearValues = yearCategoryValues[k].Split('-');
                                        do
                                        {
                                            Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                                            Yearcounting = Yearcounting + Presentyear + ",";
                                            i++;
                                        } while (yearValues[1].ToString() != Presentyear);

                                        GivenTotalYears = GivenTotalYears + Yearcounting;
                                    }
                                    else
                                    {
                                        GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                    }
                                }
                                string[] CategoryValues = GivenTotalYears.Split(',');
                                int count = 0;
                                int Yearcompareposition = 0;
                                string Yearcomparesearchstringvalue = string.Empty;
                                for (int k = 0; k < CategoryValues.Length; k++)
                                {
                                    if (CategoryValues[k].ToString() != "")
                                    {
                                        if (imgdata.Contains(CategoryValues[k].ToString().ToUpper()))
                                        {
                                            count += 1;

                                            int position = imgdata.IndexOf(CategoryValues[k].ToString().ToUpper());

                                            int nextposition = position;
                                            if (count == 1)
                                            {
                                                Yearcompareposition = position;

                                                Yearcomparesearchstringvalue = Yearcompareposition + "-" + k;
                                            }
                                            else
                                            {
                                                int result = Math.Min(Yearcompareposition, nextposition);
                                                if (result == Yearcompareposition)
                                                {
                                                    Yearcompareposition = result;
                                                    Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                                }
                                                else if (result == nextposition)
                                                {
                                                    Yearcompareposition = result;
                                                    Yearcomparesearchstringvalue = Yearcompareposition + "-" + k; // Position _ Type od Categeory in String with commaseperated
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion


                                if (count == 0) // move the files miscellaneous if category also included 
                                {
                                    FileCount = FileCount + 1;
                                    TypeOfDoc = "Miscellaneous";

                                }
                                else
                                {
                                    string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');
                                    TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                    FileCount = FileCount + 1;

                                }
                                DataRow drtemp = Dttemp.NewRow();
                                drtemp["Search"] = SearchText;
                                //drtemp["IncludeAdditional"] = SecondParam;
                                drtemp["ValueCategory"] = TypeOfDoc;
                                drtemp["FilesFrom"] = SourceFolder;
                                drtemp["FilesTo"] = DestinationFolder;
                                drtemp["FilePath"] = path;
                                drtemp["FileName"] = FileName;
                                drtemp["DocumentID"] = DocumentID;
                                Dttemp.Rows.Add(drtemp);


                            }
                            else // move the files to main folder if category is not defined
                            {
                                FileCount = FileCount + 1;

                                DataRow drtemp = Dttemp.NewRow();
                                drtemp["Search"] = SearchText;
                                //drtemp["IncludeAdditional"] = SecondParam;
                                drtemp["ValueCategory"] = TypeOfDoc;
                                drtemp["FilesFrom"] = SourceFolder;
                                drtemp["FilesTo"] = DestinationFolder;
                                drtemp["FilePath"] = path;
                                drtemp["FileName"] = FileName;
                                drtemp["DocumentID"] = DocumentID;
                                Dttemp.Rows.Add(drtemp);

                            }
                        }

                    }
                    else // Verify with partial  searchkeywords 
                    {
                        int UnMatchedSearchcount = 0;
                        //int MatchedSearchcount = 0;
                        int UnMatchedcompareposition = 0;
                        string UnMatchedcomparesearchstringvalue = string.Empty;

                        for (int i = 0; i < SearchValues.Length; i++)
                        {
                            if (SearchValues[i].ToString() != "")
                            {
                                for (int j = 0; j < (SearchValues[i].Length - 4) + 1; j++)
                                {
                                    if (imgdata.Contains(SearchValues[i].Substring(j, 4).ToString().ToUpper()))
                                    {
                                        UnMatchedSearchcount += 1;

                                        int position = imgdata.IndexOf(SearchValues[i].Substring(j, 4).ToString().ToUpper());

                                        int nextposition = position;

                                        if (UnMatchedSearchcount == 1)
                                        {
                                            UnMatchedcompareposition = position;

                                            UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + i;

                                            j = (SearchValues[i].Length - 3);
                                        }
                                        else
                                        {
                                            int result = Math.Min(UnMatchedcompareposition, nextposition);
                                            if (result == UnMatchedcompareposition)
                                            {
                                                UnMatchedcompareposition = result;
                                                UnMatchedcomparesearchstringvalue = UnMatchedcomparesearchstringvalue;
                                            }
                                            else if (result == nextposition)
                                            {
                                                UnMatchedcompareposition = result;
                                                UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + i;
                                            }

                                            j = (SearchValues[i].Length - 3);
                                        }


                                    }
                                }
                            }
                        }
                        if (UnMatchedSearchcount != 0)
                        {
                            string[] searchtextvalue = UnMatchedcomparesearchstringvalue.Split('-');

                            SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                            SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                            if (CategoryValue != "")
                            {
                                string[] yearCategoryValues = CategoryValue.Split(',');
                                string GivenTotalYears = string.Empty;
                                for (int k = 0; k < yearCategoryValues.Length; k++)
                                {
                                    if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                    {
                                        string Yearcounting = string.Empty;
                                        string Presentyear = string.Empty;
                                        int i = 0;
                                        string[] yearValues = yearCategoryValues[k].Split('-');
                                        do
                                        {
                                            Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                                            Yearcounting = Yearcounting + Presentyear + ",";
                                            i++;
                                        } while (yearValues[1].ToString() != Presentyear);

                                        GivenTotalYears = GivenTotalYears + Yearcounting;
                                    }
                                    else
                                    {
                                        GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                    }
                                }
                                string[] CategoryValues = GivenTotalYears.Split(',');
                                int Categorycount = 0;
                                int Yearcompareposition = 0;
                                string Yearcomparesearchstringvalue = string.Empty;
                                for (int i = 0; i < CategoryValues.Length; i++)
                                {
                                    if (CategoryValues[i].ToString() != "")
                                    {
                                        if (imgdata.Contains(CategoryValues[i].ToString().ToUpper()))
                                        {
                                            Categorycount += 1;

                                            int position = imgdata.IndexOf(CategoryValues[i].ToString().ToUpper());

                                            int nextposition = position;

                                            if (Categorycount == 1)
                                            {
                                                Yearcompareposition = position;

                                                Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                            }
                                            else
                                            {
                                                int result = Math.Min(Yearcompareposition, nextposition);
                                                if (result == Yearcompareposition)
                                                {
                                                    Yearcompareposition = result;
                                                    Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                                }
                                                else if (result == nextposition)
                                                {
                                                    Yearcompareposition = result;
                                                    Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (Categorycount == 0)
                                {
                                    FileCount = FileCount + 1;

                                    TypeOfDoc = "Miscellaneous";
                                }
                                else
                                {
                                    string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');

                                    TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();

                                    FileCount = FileCount + 1;


                                }

                                DataRow drtemp = Dttemp.NewRow();
                                drtemp["Search"] = SearchText;
                                //drtemp["IncludeAdditional"] = SecondParam;
                                drtemp["ValueCategory"] = TypeOfDoc;
                                drtemp["FilesFrom"] = SourceFolder;
                                drtemp["FilesTo"] = DestinationFolder;
                                drtemp["FilePath"] = path;
                                drtemp["FileName"] = FileName;
                                drtemp["DocumentID"] = DocumentID;
                                Dttemp.Rows.Add(drtemp);
                            }
                            else
                            {
                                FileCount = FileCount + 1;

                                DataRow drtemp = Dttemp.NewRow();
                                drtemp["Search"] = SearchText;
                                //drtemp["IncludeAdditional"] = SecondParam;
                                drtemp["ValueCategory"] = TypeOfDoc;
                                drtemp["FilesFrom"] = SourceFolder;
                                drtemp["FilesTo"] = DestinationFolder;
                                drtemp["FilePath"] = path;
                                drtemp["FileName"] = FileName;
                                drtemp["DocumentID"] = DocumentID;
                                Dttemp.Rows.Add(drtemp);

                            }
                        }
                        else
                        {
                            if (IsUnMatchedChecked == true)
                            {
                                UnMatchFileCount = UnMatchFileCount + 1;

                                if (m_sDocUnMatchFile == null)
                                {
                                    m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                    if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                        System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                                }
                                //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                                System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                                StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                            }
                        }
                    }
                    // End
                }
                else
                {

                    #region Move the files UnreadFiles Folder
                    UnReadFileCount = UnReadFileCount + 1;

                    if (m_sDocUnReadFile == null)
                    {
                        m_sDocUnReadFile = DestinationFolder + "\\" + "UnReadFiles";
                        if (!System.IO.Directory.Exists(m_sDocUnReadFile))
                            System.IO.Directory.CreateDirectory(m_sDocUnReadFile);
                    }
                    //System.IO.File.Move(path, m_sDocUnReadFile + "\\" + FileName);
                    System.IO.File.Copy(path, m_sDocUnReadFile + "\\" + FileName, true);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Error '" + FileName + "' is in use by another application");
            }
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

                string[] SearchValues = SearchValue.Split(',');
                int Searchcount = 0;
                int compareposition = 0;
                string comparesearchstringvalue = string.Empty;

                for (int i = 0; i < SearchValues.Length; i++)
                {
                    if (SearchValues[i].ToString() != "")
                    {
                        if (extractedText.Contains(SearchValues[i].ToString().ToUpper()))
                        {
                            Searchcount += 1;

                            int position = extractedText.IndexOf(SearchValues[i].ToString().ToUpper());

                            int nextposition = position;

                            if (Searchcount == 1)
                            {
                                compareposition = position;

                                comparesearchstringvalue = compareposition + "-" + i;
                            }
                            else
                            {
                                int result = Math.Min(compareposition, nextposition);
                                if (result == compareposition)
                                {
                                    compareposition = result;
                                    comparesearchstringvalue = comparesearchstringvalue;
                                }
                                else if (result == nextposition)
                                {
                                    compareposition = result;
                                    comparesearchstringvalue = compareposition + "-" + i;
                                }
                            }

                            //SearchText = SearchValues[i].ToString();
                            //SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                            //i = SearchValues.Length - 1;
                        }
                    }
                }
                if (Searchcount != 0)
                {
                    string[] searchtextvalue = comparesearchstringvalue.Split('-');

                    SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                    SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                    if (SearchText != "")
                    {
                        // Checking any one of the Category Value is present in contened Data or not

                        if (CategoryValue != "")
                        {
                            string[] yearCategoryValues = CategoryValue.Split(',');
                            string GivenTotalYears = string.Empty;
                            for (int k = 0; k < yearCategoryValues.Length; k++)
                            {
                                if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                {
                                    string Yearcounting = string.Empty;
                                    string Presentyear = string.Empty;
                                    int i = 0;
                                    string[] yearValues = yearCategoryValues[k].Split('-');
                                    do
                                    {
                                        Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                                        Yearcounting = Yearcounting + Presentyear + ",";
                                        i++;
                                    } while (yearValues[1].ToString() != Presentyear);

                                    GivenTotalYears = GivenTotalYears + Yearcounting;
                                }
                                else
                                {
                                    GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                }
                            }
                            string[] CategoryValues = GivenTotalYears.Split(',');
                            int Categorycount = 0;
                            int Yearcompareposition = 0;
                            string Yearcomparesearchstringvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (extractedText.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        Categorycount += 1;

                                        int position = extractedText.IndexOf(CategoryValues[i].ToString().ToUpper());

                                        int nextposition = position;

                                        if (Categorycount == 1)
                                        {
                                            Yearcompareposition = position;

                                            Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                        }
                                        else
                                        {
                                            int result = Math.Min(Yearcompareposition, nextposition);
                                            if (result == Yearcompareposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                            }
                                            else if (result == nextposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                            }
                                        }
                                    }
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Miscellaneous";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');
                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                FileCount = FileCount + 1;
                            }

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);

                        }
                    }
                    else
                    {
                        if (IsUnMatchedChecked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

                            StoreFilesInUnMatchedFolderofFileCabinet(path, FileName);
                        }
                    }

                    //// End
                }
                else
                {
                    int UnMatchedSearchcount = 0;
                    int UnMatchedcompareposition = 0;
                    string UnMatchedcomparesearchstringvalue = string.Empty;

                    for (int i = 0; i < SearchValues.Length; i++)
                    {
                        if (SearchValues[i].ToString() != "")
                        {
                            for (int j = 0; j < (SearchValues[i].Length - 4) + 1; j++)
                            {
                                if (extractedText.Contains(SearchValues[i].Substring(j, 4).ToString().ToUpper()))
                                {
                                    UnMatchedSearchcount += 1;

                                    int position = extractedText.IndexOf(SearchValues[i].Substring(j, 4).ToString().ToUpper());

                                    int nextposition = position;

                                    if (UnMatchedSearchcount == 1)
                                    {
                                        UnMatchedcompareposition = position;

                                        UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + i;

                                        j = (SearchValues[i].Length - 3);
                                    }
                                    else
                                    {
                                        int result = Math.Min(UnMatchedcompareposition, nextposition);
                                        if (result == UnMatchedcompareposition)
                                        {
                                            UnMatchedcompareposition = result;
                                            UnMatchedcomparesearchstringvalue = UnMatchedcomparesearchstringvalue;
                                        }
                                        else if (result == nextposition)
                                        {
                                            UnMatchedcompareposition = result;
                                            UnMatchedcomparesearchstringvalue = UnMatchedcompareposition + "-" + i;
                                        }

                                        j = (SearchValues[i].Length - 3);
                                    }

                                    //int MatchedSearchcount = 0;
                                    //for (int k = 1; k < SearchValues[i].Length; k++)
                                    //{
                                    //    do
                                    //    {
                                    //        if (extractedText.Contains(SearchValues[i].Substring(j, 3 + k).ToString().ToUpper()))
                                    //        {
                                    //            MatchedSearchcount += 1;

                                    //SearchText = SearchValues[i].ToString();
                                    //SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                                    //j = (SearchValues[i].Length - 3);

                                    //i = SearchValues.Length - 1;

                                    //        k = SearchValues.Length - 1;
                                    //    }
                                    //} while (MatchedSearchcount >= 1);
                                    //}
                                }
                            }
                        }
                    }
                    if (UnMatchedSearchcount != 0)
                    {
                        string[] searchtextvalue = UnMatchedcomparesearchstringvalue.Split('-');

                        SearchText = SearchValues[Convert.ToInt32(searchtextvalue[1])].ToString();
                        SearchText = Regex.Replace(SearchText, @"[\/:*?<>|'.@#%^&$!~\r\n]+", "");

                        if (CategoryValue != "")
                        {
                            string[] yearCategoryValues = CategoryValue.Split(',');
                            string GivenTotalYears = string.Empty;
                            for (int k = 0; k < yearCategoryValues.Length; k++)
                            {
                                if (Regex.IsMatch(yearCategoryValues[k], @"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"))
                                {
                                    string Yearcounting = string.Empty;
                                    string Presentyear = string.Empty;
                                    int i = 0;
                                    string[] yearValues = yearCategoryValues[k].Split('-');
                                    do
                                    {
                                        Presentyear = (Convert.ToInt32(yearValues[0].ToString()) + i).ToString();
                                        Yearcounting = Yearcounting + Presentyear + ",";
                                        i++;
                                    } while (yearValues[1].ToString() != Presentyear);

                                    GivenTotalYears = GivenTotalYears + Yearcounting;
                                }
                                else
                                {
                                    GivenTotalYears = GivenTotalYears + yearCategoryValues[k].ToString() + ",";
                                }
                            }
                            string[] CategoryValues = GivenTotalYears.Split(',');
                            int Categorycount = 0;
                            int Yearcompareposition = 0;
                            string Yearcomparesearchstringvalue = string.Empty;

                            for (int i = 0; i < CategoryValues.Length; i++)
                            {
                                if (CategoryValues[i].ToString() != "")
                                {
                                    if (extractedText.Contains(CategoryValues[i].ToString().ToUpper()))
                                    {
                                        Categorycount += 1;

                                        int position = extractedText.IndexOf(CategoryValues[i].ToString().ToUpper());

                                        int nextposition = position;

                                        if (Categorycount == 1)
                                        {
                                            Yearcompareposition = position;

                                            Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                        }
                                        else
                                        {
                                            int result = Math.Min(Yearcompareposition, nextposition);
                                            if (result == Yearcompareposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcomparesearchstringvalue;
                                            }
                                            else if (result == nextposition)
                                            {
                                                Yearcompareposition = result;
                                                Yearcomparesearchstringvalue = Yearcompareposition + "-" + i;
                                            }
                                        }
                                    }
                                }
                            }

                            if (Categorycount == 0)
                            {
                                FileCount = FileCount + 1;
                                TypeOfDoc = "Miscellaneous";
                            }
                            else
                            {
                                string[] Yearsearchtextvalue = Yearcomparesearchstringvalue.Split('-');
                                TypeOfDoc = CategoryValues[Convert.ToInt32(Yearsearchtextvalue[1])].ToString();
                                FileCount = FileCount + 1;
                            }

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);
                        }
                        else
                        {
                            FileCount = FileCount + 1;

                            DataRow drtemp = Dttemp.NewRow();
                            drtemp["Search"] = SearchText;
                            //drtemp["IncludeAdditional"] = SecondParam;
                            drtemp["ValueCategory"] = TypeOfDoc;
                            drtemp["FilesFrom"] = SourceFolder;
                            drtemp["FilesTo"] = DestinationFolder;
                            drtemp["FilePath"] = path;
                            drtemp["FileName"] = FileName;
                            drtemp["DocumentID"] = DocumentID;
                            Dttemp.Rows.Add(drtemp);

                        }
                    }
                    else
                    {
                        if (IsUnMatchedChecked == true)
                        {
                            UnMatchFileCount = UnMatchFileCount + 1;

                            if (m_sDocUnMatchFile == null)
                            {
                                m_sDocUnMatchFile = DestinationFolder + "\\" + "UnMatchFiles";
                                if (!System.IO.Directory.Exists(m_sDocUnMatchFile))
                                    System.IO.Directory.CreateDirectory(m_sDocUnMatchFile);
                            }
                            //System.IO.File.Move(path, m_sDocUnMatchFile + "\\" + FileName);
                            System.IO.File.Copy(path, m_sDocUnMatchFile + "\\" + FileName, true);

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

            sw.WriteLine(" StartTime: " + DateTime.Now.ToString() + " Type O Searchstring: " + SearchValue + " and Type Of Docs: " + CategoryValue);
            sw.Close();
        }

        private void GetFileCount()
        {
            if (picProcess.InvokeRequired)
            {
                picProcess.Invoke(new MethodInvoker(delegate { picProcess.Visible = false; }));
            }
            else
            {
                picProcess.Visible = false;
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

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //string[] path = Directory.GetFiles(SourceFolder);

            this.progressBar1.Maximum = FileCount;
            this.progressBar1.Minimum = 0;
            
            this.progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = e.UserState as String;
            //lblPercentage.Text = String.Format("Progress: {0} ", e.ProgressPercentage);
            //lblFileName.Text = System.IO.Path.GetFileName(path[j]);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Display smth or update status when progress is completed
            //lblStatus.Location = new Point(174, 451);
            lblStatus.Text = "Your Process has been completed.";
            lblStatus.ForeColor = Color.Teal;
            lblStatus.Font = new System.Drawing.Font(lblStatus.Font.FontFamily, 11);
            lblStatus.Location = new Point(this.ClientSize.Width / 2 - lblStatus.Size.Width / 2, 84);
            //lblRunningFile.Visible = false;
            lblFileName.Visible = false;
            //lblPercentage.Visible = false;
            progressBar1.Visible = false;
            // btnBack.Enabled = true;
            //btnFinish.Enabled = true;
            //btnMove.Enabled = false;

            btnCancel.Text = "Close";
            picProcess.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Close")
            {
                this.Hide();
            }
            else
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
                }
            }
        }

        public void KillMe()
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.Dispose();
                backgroundWorker1 = null;
                GC.Collect();
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (panel1.BorderStyle == BorderStyle.None)
            {
                int thickness = 2;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Teal, thickness))
                {
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(halfThickness,
                                                              halfThickness,
                                                              panel1.ClientSize.Width - thickness,
                                                              panel1.ClientSize.Height - thickness));
                }
            }
        }

        private delegate void UpdateStatusDelegate(string status, TimeSpan ts);
        private void UpdateStatus(string status, TimeSpan ts)
        {
            if (this.lblFileName.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(this.UpdateStatus), new object[] { status, ts });
                return;
            }
            if (status.Length > 25)
            {
                this.lblFileName.Text = status.Substring(0, 25).ToString() + "...";
            }
            else
            {
                this.lblFileName.Text = status;
            }
            int totsecs = ts.Seconds;
            int totminutes = ts.Minutes;
            int tothours = ts.Hours;
            if (tothours > 0)
            {
                lblRemainingTime.Location = new Point(23, 91);
                lblRemainingTime.Text = "Time remaining : " + "About" + " " + tothours + " " + "Hours" + " " + totminutes + " Minutes" + " and " + totsecs + " Seconds";
            }
            else if (totminutes > 0)
            {
                lblRemainingTime.Location = new Point(58, 91);
                lblRemainingTime.Text = "Time remaining : " + "About" + " " + totminutes + " Minutes" + " and " + totsecs + " Seconds";
            }
            else
            {
                lblRemainingTime.Location = new Point(128, 91);
                lblRemainingTime.Text = "Time remaining : " + "About" + " " + totsecs + " Seconds";
            }
        }
    }
}
