using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

namespace DocSort_CPA.Forms
{
    class ErrorHandling
    {
        private static string m_sErrorFile;

        private const string ERROR_FILENAME = "Error.xml";
        private const string ROOT_NODE = "root";
        private const string DATA_NODE = "data";
        private const string VALUE_NODE = "value";
        private const string NAME_ATTRIBUTE = "name";
        private const string DEFAULT_ERROR = "Error!";
    
        private static XmlElement CreateNode(System.Xml.XmlDocument oRoot, string strName, System.Collections.Specialized.NameValueCollection oAttributes, string sInnerText)
        {
            System.Xml.XmlElement oElement;
            oElement = oRoot.CreateElement(strName);
            oElement.InnerText = sInnerText;
            if (oAttributes != null)
            {
                for (int i = 0; i < oAttributes.Count; i++)
                {
                    oElement.SetAttribute(oAttributes.GetKey(i), null, oAttributes[i]);
                }
            }
            return oElement;
        }
        private static string GetInnerTrace(Exception Exc)
        {
            System.Text.StringBuilder objReturn = new System.Text.StringBuilder();
            Exception objException = Exc;
            while (objException.InnerException != null)
            {
                objReturn.Append(objException.Message + "----------------");
                objException = objException.InnerException;
            }
            return objReturn.ToString();
        }

      
        /// <summary>
        /// write error for the exception
        /// </summary>
        /// <param name="e"></param>
        public static void PostError(Exception e)
        {
            XmlDocument oRoot = OpenLogFile();
            XmlElement oError = CreateRootElement(oRoot, "Application Level Exception", "System Halted.");
            if (e != null)
            {
                oError.AppendChild(CreateExceptionElement(oRoot, e));
            }
            //if(Result.session!=null)
            //	oError.AppendChild(CreateSessionElement(oRoot,System.Web.HttpContext.Current.Session));

            oRoot.DocumentElement.AppendChild(oError);
            // Save the document
            oRoot.Save(m_sErrorFile);

        }
        /// <summary>
        /// Create root element node
        /// </summary>
        /// <param name="oRoot">Root XmlDocument </param>
        /// <param name="ErrorType">Error Type</param>
        /// <param name="ErrorDesc">Error Description</param>
        /// <returns>XmlElement - root error element</returns>
        private static XmlElement CreateRootElement(XmlDocument oRoot, string ErrorType, string ErrorDesc)
        {
            XmlElement oError;
            //Error Node
            oError = CreateNode(oRoot, "Error", null, null);
            //Errordate
            oError.AppendChild(CreateNode(oRoot, "ErrorDate", null, System.DateTime.Now.ToString()));
            // ErrorType
            oError.AppendChild(CreateNode(oRoot, "ErrorType", null, ErrorType));
            //ErrorDescription
            oError.AppendChild(CreateNode(oRoot, "ErrorDesc", null, ErrorDesc));
            return oError;
        }
        /// <summary>
        /// Open Log file and return root element
        /// </summary>
        /// <returns>XmlElement - Root not of the xml log</returns>
        private static XmlDocument OpenLogFile()
        {
            XmlDocument oRoot = new XmlDocument();
            // read / create error filename and store in static variable
            if (m_sErrorFile == null)
            {
                if (System.Configuration.ConfigurationSettings.AppSettings["LogPath"] != null)
                {
                    m_sErrorFile = System.Configuration.ConfigurationSettings.AppSettings["LogPath"];
                    if (!System.IO.Directory.Exists(m_sErrorFile))
                        System.IO.Directory.CreateDirectory(m_sErrorFile);
                    m_sErrorFile += "ErrorLog" + DateTime.Now.ToString("dd-MM-yyyy") + ".xml";
                }
                else
                    m_sErrorFile = "ErrorLog" + DateTime.Now.ToString("dd-MM-yyyy") + ".xml";
            }
            // if file exists then load it to root node
            if (System.IO.File.Exists(m_sErrorFile))
                oRoot.Load(m_sErrorFile);
            else
            {
                byte[] bytContents = System.Text.Encoding.Default.GetBytes("<Errors></Errors>");
                System.IO.FileStream objFile = System.IO.File.Create(m_sErrorFile);
                objFile.Write(bytContents, 0, bytContents.Length);
                objFile.Close();
                objFile = null;
                oRoot.Load(m_sErrorFile);
            }
            return oRoot;
        }

        /// <summary>
        /// private function to create Exception Node
        /// </summary>
        /// <param name="oRoot">Root element</param>
        /// <param name="e">exception</param>
        /// <returns>Exception xml Element</returns>
        private static XmlElement CreateExceptionElement(XmlDocument oRoot, Exception e)
        {
            XmlElement oException;
            oException = CreateNode(oRoot, "Exception", null, null);
            oException.AppendChild(CreateNode(oRoot, "Source", null, e.Source));
            oException.AppendChild(CreateNode(oRoot, "Description", null, e.Message));
            oException.AppendChild(CreateNode(oRoot, "InnerException", null, GetInnerTrace(e)));
            oException.AppendChild(CreateNode(oRoot, "StackTrace", null, e.StackTrace));
            if (e.TargetSite != null)
            {
                oException.AppendChild(CreateNode(oRoot, "Method", null, e.TargetSite.ToString()));
            }
            //	if(e.HelpLink.Length!=0)
            //		oException.AppendChild(CreateNode(oRoot,"HelpLink",null,e.HelpLink));

            return oException;
        }
        /// <summary>
        /// Various error messages prevalent in the system
        /// </summary>
        public enum ErrorType
        {
            #region Site Admin Error/Success Messages

            #region Site Admin Error Messages

            /// <summary> Error: Error writing CSS file</summary>
            ERR_WRITING_CSS_FILE = 9101,
            /// <summary> Error: Error Deleteing the Page</summary>	
            CANNOT_DELETE_PAGE = -9013,

            #endregion


            #region Site Admin Success Messages

            /// <summary> Success: CC Info saved successfully</summary>
            SUC_CSS_SAVED_SUCCESSFULLY = 9201,

            #endregion

            #endregion

            #region Database Related Errors (1000)

            /// <summary> Error: Could not open database. Try later...</summary>
            ERR_DB_OPEN_FAILED = 1000,

            /// <summary> Error: while inserting record to database.</summary>
            ERR_INSERTING_RECORD = 1001,

            /// <summary> Error: while updating record to database.</summary>
            ERR_UPDATING_RECORD = 1002,

            /// <summary> Error: while deleting record to database.</summary>
            ERR_DELETING_RECORD = 1003,

            /// <summary> Error: Error while retrieving data </summary>
            ERR_RETRIEVING_DATA = 1004,

            /// <summary> Error: Invalid arguments while calling a function </summary>
            ERR_INVALID_DATA = 1005,

            /// <summary> Error: No data found </summary>
            ERR_NO_DATA_FOUND = 1006,

            /// <summary> Error: Reference Found </summary>
            ERR_NO_REFERENCE_FOUND = 1007,
            #endregion

            #region Documents Related Errors (2000)

            /// <summary> Error: Creating New Folder </summary>
            ERR_CREATING_FOLDER = 2000,

            /// <summary> Error: Removing Directory </summary>
            ERR_DELETING_FOLDER = 2001,

            /// <summary> Error: Reading File Content	 </summary>
            ERR_READING_FILE = 2002,

            /// <summary> Error: Moving File	</summary>
            ERR_MOVING_FILE = 2003,

            /// <summary> Error: Removing File	</summary>
            ERR_REMOVING_FILE = 2004,

            /// <summary> Error: Renaming Folder	</summary>
            ERR_RENAMING_FOLDER = 2005,

            /// <summary> Error: Renaming File	</summary>
            ERR_RENAMING_FILE = 2006,

            /// <summary> Error: Creating File </summary>
            ERR_CREATING_FILE = 2007,

            /// <summary> Error: Uploading  File </summary>
            ERR_UPLOAD_FILE = 2008,

            /// <summary> Error: Destination directory not found </summary>
            ERR_DIRECTORY_NOT_FOUND = 2036,

            /// <summary> Error: Getting FileSize</summary>
            ERR_FILESIZE = 2009,

            /// <summary> Error: Restoring File</summary>
            ERR_RESTORING_FILE = 2010,

            /// <summary> Error: Restoring File</summary>
            ERR_FOLDER_NAME_EXIST = -2011,

            /// <summary> Error: Restoring File</summary>
            ERR_NOGROUP_EXIST = 2012,

            /// <summary> Error: No Record Exists</summary>
            ERR_RECORDS_EXIST = 2013,

            /// <summary> Error: No Documents Exists in Inbox</summary>
            ERR_NO_DOCUMENTS_EXIST = 2037,


            /// <summary> Error: Folder Name</summary>
            ERR_FOLDER_NAME = 2014,

            /// <summary> Error:Select Folder Name</summary>
            ERR_DEST_FOLDER = 2015,

            /// <summary> Error:Select Folder Name</summary>
            ERR_DELETE_ROOT_FOLDER = 2016,

            /// <summary> Error:Select Folder Name</summary>
            ERR_RENAME_ROOT_FOLDER = 2017,

            /// <summary> Error:Enter Folder Password</summary>
            ERR_FOLDER_PASSWORD = 2018,

            /// <summary> Error:Enter Folder Password</summary>
            ERR_FILETYPE_NOT_SUPPORTED = 2019,

            /// <summary> Error:Enter Folder Password</summary>
            ERR_NO_INVOICE_EXIST = 2020,

            /// <summary> Error: No Record Exists</summary>
            ERR_NO_RECORDS = 2021,

            /// <summary> Error: No User Requests Exists</summary>
            ERR_NO_USER_REQUESTS = 2070,

            /// <summary> Error: No Space Requests Exists</summary>
            ERR_NO_SPACE_REQUESTS = 2071,

            /// <summary> Error: No Backup Requests Exists</summary>
            ERR_NO_BACKUP_REQUESTS = 2073,

            /// <summary> Error: No Record Exists</summary>
            ERR_RECORDS_UPDATED = 2072,

            /// <summary> Error: Caninet alredy exists</summary>
            ERR_CABINET_NAME_EXIST = -2028,

            /// <summary> Error: Not enough space for upload</summary>
            ERR_NO_ENOUGH_SPACE = -2029,

            /// <summary> Error: Restoring File</summary>
            ERR_NOSCHEME_EXIST = -9420,

            /// <summary> Error: No Checkedout files</summary>
            ERR_CHECKEDOUT_FILES = 2023,

            /// <summary> Error: No Checkedout files</summary>
            ERR_INCORRECT_ANSWER = 2024,

            /// <summary> Error: No Checkedout files</summary>
            ERR_NO_DOCUMENT_FOUND = 2025,

            /// <summary> Error: No Checkedout files</summary>
            ERR_BARCODE_IMAGE_NOT_FOUND = 2026,

            /// <summary> Error: No Checkedout files</summary>
            ERR_SENDING_MAIL = 2027,

            /// <summary> Error: No Checkedout files</summary>
            ERR_NO_DOCUMENT_CATEGORY = 2030,

            /// <summary> Error: Group doesnt have right on any folder</summary>
            ERR_NO_FOLDER_UNDER_GROUP = 2031,

            /// <summary> Error: Folder name already exists in the list</summary>
            ERR_FOLDER_ALREADY_IN_LIST = 2032,

            /// <summary> Error: Folder name already exists in the list</summary>
            ERR_CABINET_NOT_EMPTY = -2033,

            /// <summary> Error: Group does not exist</summary>
            ERR_GROUP_DOES_NOT_EXIST = 2034,

            /// <summary> Error: No files in collection</summary>
            ERR_NO_FILES_IN_COLLECTION = 2035,

            /// <summary> Error: Highest Scheme Gain</summary>
            LAST_SCHEME = -1112,

            /// <summary> Create Invoice for Space Request</summary>
            SPACE_INVOICE = 2231,

            /// <summary> Create Invoice for User Request</summary>
            USER_INVOICE = 2234,


            /// <summary> Create Invoice for Space Request</summary>
            SPACE_REQUEST_APPROVED = 2232,

            /// <summary> Create Invoice for User Request</summary>
            USER_REQUEST_APPROVED = 2233,

            /// <summary> Error: Delete Folder/File Message</summary>
            DELETE_FOLDER_FILE_MSG = 8484,

            /// <summary> Error: Move Folder/File Message</summary>
            MOVE_FOLDER_FILE_MSG = 8485,


            /// <summary> Error: Checkout File(s)</summary>
            CHECKOUT_FILE_MSG = 8486,

            /// <summary> Error: Restore File(s)</summary>
            MSG_RESTORE_FILESFOLDERS = 8487,


            /// <summary> Error: Delete file(s) folders</summary>
            MSG_DELETE_FILESFOLDERS = 8488,


            /// <summary> Error: Move file(s) folders</summary>
            MSG_MOVE_FILESFOLDERS = 8489,

            /// <summary> Error: No space slot is defined</summary>
            ERROR_NO_SPACE_SLOT = 8490,


            #endregion

            #region Site Admin Error messages

            /// <summary> Error: No SUCH COMPANY IN CATEGORY</summary>
            ERROR_NO_COMPANY_IN_CATEGORY = 9301,

            /// <summary> Error: No SUCH SPACE REQUESTS IN CATEGORY</summary>
            ERROR_NO_SPACE_REQUESTS_IN_CATEGORY = 9302,

            /// <summary> Error: No SUCH USER REQUESTS IN CATEGORY</summary>
            ERROR_NO_USER_REQUESTS_IN_CATEGORY = 9303,

            /// <summary> Error: No SUCH OTHER CHARGES FOR COMPANY</summary>
            ERROR_NO_OTHER_CHARGES_FOR_COMPANY = 9304,

            /// <summary> Error: No SUCH STORAGE SLOT  FOR SCHEME</summary>
            ERROR_NO_STORAGE_SLOT_FOR_SCHEME = 9305,

            /// <summary> Error: No SUCH USER SLOT  FOR SCHEME</summary>
            ERROR_NO_USER_SLOT_FOR_SCHEME = 9306,

            /// <summary> Error: No SUCH STORAGE SLOT  FOR COMPANY</summary>
            ERROR_NO_STORAGE_SLOT_FOR_COMPANY = 9307,

            /// <summary> Error: No SUCH USER SLOT  FOR COMPANY</summary>
            ERROR_NO_USER_SLOT_FOR_COMPANY = 9308,

            /// <summary> Error: No SUCH COMPANY IN CATEGORY</summary>
            ERROR_NO_BACKUP_REQUEST_IN_CATEGORY = 9309,

            /// <summary> Error: No SUCH SCHEME PRICING FOR COMPANY</summary>
            ERROR_NO_SCHEME_PRICING_FOR_COMPANY = 9310,

            /// <summary> Error: No SUCH SCHEME	UPGRADEREQUSET  FOR REQUEST TYPE</summary>
            ERROR_NO_SCHEMEUPGRADE_REQUEST_FOR_REQUESTTYPE = 9311,

            /// <summary> Error: No SUCH NEW REGISTRATIONS</summary>
            ERROR_NO_NEW_REGISTRATIONS = 9312,

            /// <summary> Error: No SUCH NEW REGISTRATIONS</summary>
            ERR_PAGE_NOT_EXIST = 9313,

            /// <summary> Error: No EMAILIDS EXIST</summary>
            ERR_NO_EMAILIDS_EXIST = 9314,

            /// <summary> Error: No EMAILIDS EXIST</summary>
            ERR_NO_FAXIDS_EXIST = 9316,

            /// <summary> Error: No EMAILTEMPLATES EXIST</summary>
            ERR_NO_EMAILTEMPLATES = 9317,

            /// <summary> Error: No EMAILTEMPLATES EXIST</summary>
            ERR_NO_TEMPLATES = 9318,



            /// <summary> Error: No LINKS EXIST</summary>
            ERR_NO_LINKS_EXIST = 9315,





            #endregion

            #region Success Messages

            /// <summary> Success: CC Info saved successfully</summary>
            ERR_CC_RECORD_SAVED_SUCCESSFULLY = 2022,

            /// <summary> Success: Password changed successfully</summary>
            SUC_PASSWORD_CHANGED_SUCCESFULLY = 4002,

            /// <summary> Success: Password is emailed successfully</summary>
            SUC_PASSWORD_IS_EMAILED = 4003,

            /// <summary> Success: Barcode image found</summary>
            SUC_BARCODE_IMAGE_FOUND = 4004,

            /// <summary> Success: Barcode sent by an email</summary>
            SUC_BARCODE_SENT_BY_MAIL = 4005,

            /// <summary> Success: MEmber details updated successfully</summary>
            SUC_MEMBER_DETAILS_CHANGED = 4006,

            /// <summary> Success: Style Sheet details are updaetd successfully</summary>
            SUC_STYLE_SHEET_DETAILS_UPDATED = 4007,

            /// <summary> Success: Style Sheet details are updaetd successfully</summary>
            SUC_SCHEME_MODULE_DETAILS_UPDATED = 4008,

            /// <summary> Success: Backup Pricing details updaetd successfully</summary>
            SUC_BACKUP_PRICING_DETAILS_UPDATED = 4009,

            /// <summary> Success: Backup Pricing details updaetd successfully</summary>
            SUC_RIGHTS_UPDATED = 4010,

            #endregion

            #region System Errors (3000)

            /// <summary>Error: Page not found </summary>
            ERR_PAGE_NOT_FOUND = 3000,

            /// <summary> Error: Processing request </summary>
            ERR_PROCESSING_REQUEST = 3001,

            /// <summary> Error: Invalid Username or password </summary>
            ERR_INVALID_USENAME_PWD = -3005,

            /// <summary> Error: Invalid Username</summary>
            ERR_INVALID_USENAME = -3006,

            /// <summary> Error: Invalid Password</summary>
            ERR_INVALID_PASSWORD = -3007,

            /// <summary> Error: Invalid Password</summary>
            ERR_PROBLEM_ACCESING_SERVER = -3008,

            /// <summary> Error: Authentication Error</summary>
            ERR_AUTHENTICATION = -3009,

            /// <summary> Error: Authentication Error</summary>
            ERR_MEMBERSHIP_CANCELLED = -3010,
            #endregion

            #region Log Category (9000)

            /// <summary>Log: Delete CC</summary>
            LOG_DELETE_CREDIT_CARD = -9001,

            /// <summary>Log: Add CC </summary>
            LOG_ADD_CREDIT_CARD = -9002,

            /// <summary>Log: Edit CC </summary>
            LOG_EDIT_CREDIT_CARD = -9003,

            /// <summary>Log: Change Password </summary>
            LOG_CHANGED_PASSWORD = -9004,

            /// <summary>Log: File Uploaded by Upload Metthod </summary>
            LOG_FILE_UPLAODED = -9005,

            /// <summary>Log: File detail is modified</summary>
            LOG_FILE_DETAILS_MODIFIED = -9006,

            /// <summary>Log: New Folder created</summary>
            LOG_FOLDER_CREATED = -9007,

            /// <summary>Log: Folder renamed</summary>
            LOG_FOLDER_RENAMED = -9008,

            /// <summary>Log: Folder renamed</summary>
            REGISTRATION_EMAIL_FIALED = -9922,

            /// <summary>Log: Information</summary>
            ERR_NO_LOG_INFORMATION = -9923,




            #endregion


            #region Invoice
            /// <summary> Error: Charge Lable already exists</summary>
            ERR_CHARGE_ALREADY_EXIST = -7001,

            #endregion

            #region Duplicate File Name
            /// <summary> Error: Charge Lable already exists</summary>
            ERR_FILENAME_ALREADY_EXIST = -4001,

            #endregion

            #region SendMail
            /// <summary> Error: Reference Found </summary>
            ERR_MAIL_SEND_FAIL = -8011,
            /// <summary> Error: Reference Found </summary>
            ERR_MAIL_SEND_SUCCESS = -8012,
            /// <summary> Error: Reference Found </summary>
            ERR_MAIL_FILE_ALREADY_REMOVED = -8013,
            /// <summary> Error: Reference Found </summary>
            ERR_BLANK_ATTACHMENT = -8014,
            /// <summary> Error: Reference Found </summary>
            ERR_BLANK_ATTACHMENT_MESSAGE = -8015,
            #endregion

            #region Send Fax
            /// <summary> Error: Reference Found </summary>
            ERR_FAX_SEND_SUCCESS = -8016,
            /// <summary> Error: Reference Found </summary>
            ERR_FAX_SEND_FAIL = -8017,
            /// <summary> Error: Reference Found </summary>
            ERR_FAX_LIMIT_REACHED = -5566,
            /// <summary> Error: Reference Found </summary>
            MSG_FILE_DOWNLOADED_SUCCESSFULLY = -8111,
            #endregion

            #region Renting and Scanning
            /// <summary> Error: Reference Found </summary>
            ERR_RENTING_SCANNING_REQUEST_SENT = -8018,
            #endregion

            #region Manage Recyclebin
            /// <summary> Error: Reference Found </summary>
            ERR_EMPTY_RECYCLEBIN = -8051,

            /// <summary> Error: Reference Found </summary>
            ERR_EMPTY_RECYCLEBIN_RESTORE = -9988,

            #endregion

            #region Index Management
            /// <summary> Error: Reference Found </summary>
            ERR_INDEXMANAGEMENT = -1124,
            #endregion

            #region Fax and Email Configuration
            /// <summary> Error: Reference Found </summary>
            MSG_NEW_EMAIL_ADDED = -8052,

            /// <summary> Error: Invalid CC Info</summary>
            MSG_INVALID_CC_INFO = 4111,


            /// <summary> Error: Reference Found </summary>
            ERR_MSG_EMAIL_ID_EXITS = -8053,

            /// <summary> Error: Reference Found </summary>
            ERR_RECORD_MODIFIED = -8054,


            /// <summary> Error: Reference Found </summary>
            MSG_NEW_FAX_ADDED = -8055,

            /// <summary> Error: Reference Found </summary>
            ERR_MSG_FAX_ID_EXITS = -8056,

            /// <summary> Error: Reference Found </summary>
            ADMIN_PASSWORD_CHANGED = -8057,

            /// <summary> Error: Reference Found </summary>
            ADMIN_HAS_CHANGED_PASSWORD = -8058,

            /// <summary> Error: Reference Found </summary>
            ERR_DUPLICATE_RECORD = -8059,

            /// <summary> Error: Reference Found </summary>
            ERR_DUPLICATE_PAGE = -8060,


            #endregion

            #region Recently Opened Documents
            /// <summary> Error: Reference Found </summary>
            MSG_NO_DOCUMENTS = 7777,

            #endregion
        }
       
        /// <summary>
        /// Returns the error message for the code sent
        /// </summary>
        /// <param name="errorType">The error type Enum</param>
        /// <returns>Error message for that type</returns>
        public static string GetErrorMessage(ErrorType errorType)
        {
            //Determines the path to access .xml file.
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + ERROR_FILENAME;

            //Checks whether .xml file exists for given culture.
            if (File.Exists(filePath))
            {
                XmlDocument xml = new XmlDocument();

                try
                {
                    xml.Load(filePath);
                    //Reads the error-resource data value for given data name/key.
                    XmlNode node = xml.SelectSingleNode(ROOT_NODE + "/" + DATA_NODE + "[@" + NAME_ATTRIBUTE + "=\"" + Convert.ToString((int)errorType) + "\"]/" + VALUE_NODE);

                    if (null != node)
                    {
                        return node.InnerText;
                    }
                }
                catch
                {

                }
            }

            return DEFAULT_ERROR;

        }

    }
}
