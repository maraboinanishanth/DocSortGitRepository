   using System;


namespace Common
{
   	/// <summary>
	/// Summary description for GPSConstant.
	/// </summary>
	public class NandanaConstants
	{
		#region Constants for System Params

		/// <summary>
		/// Enum for System Parameter Values
		/// </summary>
		public enum SysParams
		{
			/// <summary>
			/// System's Connection String
			/// </summary>
			ConnectionString,
			/// <summary>
			/// Administrator Email
			/// </summary>
			AdminEmail,
			/// <summary>
			/// Server Path
			/// </summary>
			DefaultUploadPath,
			/// <summary>
			/// SMTP Server Name
			/// </summary>
			SMTPServer,
			/// <summary>
			/// YearKey
			/// </summary>
			SMTPServerUser,
			/// <summary>
			/// YearKey
			/// </summary>
			SMTPServerPassword,
			/// <summary>
			/// YearKey
			/// </summary>
			YearKey,
			/// <summary>
			/// DefaultIndexSize
			/// </summary>
			DefaultIndexSize,

			/// <summary>
			/// StrCatalogPath
			/// </summary>
			StrCatalogPath,

			/// <summary>
			/// ACCOUNT CONSTANT	
			/// </summary>
			ACC,

			/// <summary>
			/// Impersonate user's domain name
			/// </summary>
			StrDomain,

			/// <summary>
			/// Impersonate user login
			/// </summary>
			StrLogin,

			/// <summary>
			/// Impersonate user password
			/// </summary>
			StrPwd,

			/// <summary>
			/// Trial Account
			/// </summary>
			Trial,

			/// <summary>
			/// FaxServer
			/// </summary>
			FaxServer,

			/// <summary>
			/// FaxServer
			/// </summary>
			FaxFrom,

			
			/// <summary>
			/// FaxPassword
			/// </summary>
			FaxPassword,


		}

		#endregion

		#region Constants for Help
		
		/// <summary>Constant for name of Help XML file.</summary>
		public const string HELP_FILENAME = "Help.xml";
		/// <summary>Constant for Default help constant</summary>
		public const string DEFAULT_HELP = "No Help";
		/// <summary>Constant for Root Node</summary>
		public const string ROOT_NODE = "root";
		/// <summary>Constant for Data Node</summary>
		public const string DATA_NODE = "data";
		/// <summary>Constant for Value Node</summary>
		public const string VALUE_NODE = "value";
		/// <summary>Constant for Name Attribute</summary>
		public const string NAME_ATTRIBUTE = "name";
		/// <summary>Constant for Name Attribute</summary>
		public const string PAGE_TYPE_ASPX = ".aspx";

	
		#endregion

		#region Constants for Session object

	

		/// <summary>Constant for length of keycode.</summary>
		public const string SESSION_OBJECT_NAME = "NandanaSession";

		/// <summary>Constant for length of keycode.</summary>
		public const string ADMIN_SESSION_OBJECT_NAME = "NandanaAdminSession";

		

		/// <summary>Constant for Default page Path </summary>
		public const string DEFAULT_PATH = "~/default.aspx";
		/// <summary>Constant for Temp Folder in Images</summary>
		public const string PHYSICALTEMP_PATH = "Images\\Temp\\";

		/// <summary>Constant for CSS Folder </summary>
		public const string PHYSICAL_CSS_PATH = "CSS\\";

		/// <summary>Constant for CSS file name </summary>
		public const string CSS_FILE_NAME = "style.css";

		/// <summary>Constant for CSS file name </summary>
		public const string CSS_DEFAULT_FILE_NAME = "style_default.css";

		/// <summary>Constant for Temp Folder in Images</summary>
		public const string PHYSICAL_LAYOUT_PATH = "Images\\Layouts\\";
		/// <summary>Constant for Temp Folder in Images (Relative path)</summary>
		public const string RELATIVETEMP_PATH = "Temp/";	

		/// <summary>Constant for Layout Path </summary>
		public const string LAYOUT_PATH = "Layouts/";

		/// <summary>Constant for Icon Path (web\images\icons) </summary>
		public const string ICON_PATH = "Icons/";

		
		
		#endregion

		#region Registration Process Constant
        /// <summary> File Extension </summary>
		public const string EXTENSION = ".ascx";						
		/// <summary> Registration Step Control 1 </summary>
		public const string  Step1_Title = "Nandana SM :: Licenses";
		/// <summary> Registration Step Control 2 </summary>
		public const string  Step2_Title = "Nandana SM :: Company Contact Infromation";
		/// <summary> Registration Step Control 3 </summary>
		public const string  Step3_Title = "Nandana SM :: Terms and Conditions";
		/// <summary> Registration Step Control 4 </summary>
		public const string  Step4_Title = "Nandana SM :: Credit Card Information";
		/// <summary> Registration Step Control 5 </summary>
		public const string  Step5_Title = "Nandana SM :: Administrator Account";

		#endregion

		#region Grid Constant

		/// <summary>
		/// String type
		/// </summary>
		public const string STRING_TYPE = "System.String";
		/// <summary>
		/// Double type
		/// </summary>
		public const string DOUBLE_TYPE = "System.Double";
		
		/// <summary>
		/// Sort String
		/// </summary>
		public const string SORT_STRING_COLUMN = "SortString";
		/// <summary>
		/// Filter Clause used
		/// </summary>
		public const string FILTER_CLAUSE_STRING = "FilterClause";
		/// <summary>
		/// Sort Ascending
		/// </summary>
		public const string SORT_STRING_ASC = "asc";
		/// <summary>
		/// Sort Descending
		/// </summary>
		public const string SORT_STRING_DESC = " desc";
		/// <summary>
		/// Primary Key
		/// </summary>
		public const string PRIMARY_KEY = "PK";
		/// <summary>
		/// Tool
		/// </summary>
		public const string TOOL = "Tool";
		/// <summary>
		/// Select statement
		/// </summary>
		public const string SELECT_CLAUSE = "select";
		/// <summary>
		/// Starts with
		/// </summary>
		public const string STARTWITH_CLAUSE = "startwith";
		/// <summary>
		/// Start Field
		/// </summary>
		public const string START_FIELD = "StartField";
		/// <summary>
		/// Sort Field
		/// </summary>
		public const string SORT_FIELD = "sortfield";
		/// <summary>
		/// Return
		/// </summary>
		public const string RETURN_STRING = "Return";
		/// <summary>
		/// For 0 Deleted folder 
		/// </summary>
		public const int IS_RECYCLE = 0;
		/// <summary>
		/// Constants for the Folder image
		/// </summary>
		public const string FOLDER_IMAGE = "folder.gif";
		/// <summary>
		/// Constants for the Locked Folder image
		/// </summary>
		public const string LOCKED_FOLDER_IMAGE = "lock_folder.gif";
		/// <summary>
		/// Constants for the Folder image
		/// </summary>
		public const string CABINATE_IMAGE = "cabinet_icon.jpg";
		/// <summary>
		/// Constants for the Locked Cabinet image
		/// </summary>
		public const string LOCKED_CABINET_IMAGE = "cabinet_lock.gif";
		#endregion

		#region Constant for Business
		/// <summary>A byte Constant for true or yes flag</summary>
		public const byte TRUE_BYTE = 1;
		/// <summary>A byte Constant for false or no flag</summary>
		public const byte FALSE_BYTE = 0;

		/// <summary>Set index of the dropdownlist</summary>
		public const int INDEX_MINUS = -1;

		/// <summary>Constant for @Transaction parameter. </summary>
		public const string TRANSACTION_PARAM = "@Transaction"; 
		/// <summary>Constant for @NameID parameter. </summary>
		public const String TRANSTYPE_PARAM = "@TransType";
		/// <summary>
		/// Constant for Save String
		/// </summary>
		public const string SAVE_VALUE = "Save";
		/// <summary>
		/// Constant for Rename String
		/// </summary>
		public const string RENAME_VALUE = "Rename";
		/// <summary>
		/// String Constants for View rights only
		/// </summary>
		public const string STR_DISABLED = "*****";

		#endregion

		#region Enum for Email Types

		/// <summary>
		/// The Enumerator used for the type of
		/// Emails that will go from the system
		/// </summary>
		/// <remarks>This names are same as mapped </remarks>
		public enum EmailTemplate
		{
			/// <summary>
			/// New Account
			/// </summary>
			NewAccount,
			/// <summary>
			/// Forgot password
			/// </summary>
			ForgotPassword,
			/// <summary>
			/// Change password
			/// </summary>
			ChangePassword,
			/// <summary>
			/// Request Barcode
			/// </summary>
			RequestBarcode,
			/// <summary>
			/// For the Invoice
			/// </summary>
			Invoice,
			/// <summary>
			/// For the Pending Invoice
			/// </summary>
			PendingInvoice,
			/// <summary>
			/// For the Account
			/// </summary>
			Confirmation,

			/// <summary>
			/// For the AccountInactive
			/// </summary>
			Inactive,
			/// <summary>
			/// Cancel MemberShip
			/// </summary>
			CancelMembership,

			/// <summary>
			/// Reject Space
			/// </summary>
			RejectSpace,
			/// <summary>
			/// Approve Space
			/// </summary>
			ApproveSpace,

			/// <summary>
			/// Reject Users
			/// </summary>
			RejectUsers,
			/// <summary>
			/// Approve Users
			/// </summary>
			ApproveUsers,

			/// <summary>
			/// For the Document Scanning
			/// </summary>
			DocumentScanning,

			/// <summary>
			/// For the Renting Scanner
			/// </summary>
			RentingScanner,
			
			/// <summary>
			/// Reject Scheme
			/// </summary>
			RejectScheme,

			/// <summary>
			/// Approve Scheme
			/// </summary>
			ApprovScheme,

			/// <summary>
			/// Reject Account
			/// </summary>
			RejectAccount,

			/// <summary>
			/// Information Request
			/// </summary>
			InformationRequest,

			/// <summary>
			/// Approve CancelMembership Request
			/// </summary>
			ApproveCancelMembership,

			/// <summary>
			/// Reject CancelMembership Request
			/// </summary>
			RejectCancelMembership

		}
		#endregion

		#region Enum for Operation Type
		/// <summary>
		/// The Enumerator used for the type of
		/// Mode that will be used for taking decision for type of operation
		/// </summary>
		/// <remarks>This names are same as mapped </remarks>
		public enum OperationMode
		{
			/// <summary>
			/// View Mode
			/// </summary>			
			View = 'V',
			/// <summary>
			/// Edit Mode
			/// </summary>
			Edit = 'E',
			/// <summary>
			/// Delete Mode
			/// </summary>
			Delete = 'D',
			/// <summary>
			/// Add Mode
			/// </summary>
			Add = 'A'

		}
		#endregion

		#region Enum for Send Document Mode
		/// <summary>
		/// The Enumerator used for the type of
		/// Mode that will be used for sending the file
		/// </summary>
		/// <remarks>This names are same as mapped </remarks>
		public enum SendDocumentMode
		{
			/// <summary>
			/// Fax Mode
			/// </summary>			
			FaxMode = 'F',
			/// <summary>
			/// Email Mode
			/// </summary>
			EmailMode = 'M'
		}
		#endregion

		#region Enum Common
		/// <summary>
		/// The Enumerator used for the type of
		/// Mode that will be used for taking decision for type of operation
		/// </summary>
		/// <remarks>This names are same as mapped </remarks>
		public enum CommonEnum
		{
			/// <summary>
			/// Mode
			/// </summary>			
			Mode			
		}
		#endregion

		#region Constant for WebPage
		/// <summary>Constant for  delfield Field </summary>
		public const string DELETE_FIELD = "delfield";
		/// <summary>
		/// ROOT VALUE
		/// </summary>
		public const string ROOT = "Root"; 
		/// <summary>
		/// Default Root Value
		/// </summary>
		public const int DEFAULT_ROOT_VALUE = 1; 
		/// <summary>
		/// First row of combo box
		/// </summary>
		public const string CMB_FIRST_ROW = "";
		/// <summary>
		/// Combo's first row text
		/// </summary>
		public const string CMB_FIRST_ROW_TEXT = "---------All---------";
		/// <summary>
		/// Any selection of Combo box
		/// </summary>
		public const string CMB_FIRST_ROW_ANY = "Any";
		/// <summary>
		/// First row Id of a combo box
		/// </summary>
		public const string CMB_FIRST_ROWID = "0";
		/// <summary>
		/// Boolean for insert
		/// </summary>
		public const bool BLN_INSERT_ATEND = false;
		/// <summary>
		/// Duration of year months
		/// </summary>
		public const int DURATION_MONTHS_YEARLY = 12;
		/// <summary>
		/// Month duration default
		/// </summary>
		public const int DURATION_MONTHS = 1;
		/// <summary>
		/// Year duration default
		/// </summary>
		public const int DURATION_YEARLY = 1;
		/// <summary>
		/// Duration month yearly
		/// </summary>
		public const int DURATION_MONTHS_ISYEARLY = 0;
		/// <summary>
		/// Blank state ID
		/// </summary>
		public const int STATE_ID_NONE = 0;
		/// <summary>
		/// Bronze Scheme
		/// </summary>
		public const string SCHEME_BRONZE = "Bronze" ;
		/// <summary>
		/// Bronze scheme ID
		/// </summary>
		public const int SCHEME_BRONZE_ID = 1 ;
		/// <summary>
		/// Silver Scheme
		/// </summary>
		public const string SCHEME_SLIVER = "Sliver" ;
		/// <summary>
		/// Gold scheme
		/// </summary>
		public const string SCHEME_GOLD = "Gold" ;
		/// <summary>
		/// Platinum scheme
		/// </summary>
		public const string SCHEME_PLATINUM = "Platinum" ;
		/// <summary>
		/// Company Account Status
		/// </summary>
		public const string COPMPANY_ACCOUNT_STATUS = "N" ;
		/// <summary>
		/// Company Status Approved
		/// </summary>
		public const string COPMPANY_ACCOUNT_STATUS_APPROVED = "A" ;
		/// <summary>
		/// Company Status Trial
		/// </summary>
		public const string COPMPANY_ACCOUNT_STATUS_TRIAL = "T" ;
		/// <summary>
		/// Active parameter
		/// </summary>
		public const string PARAM_ACTIVE = "A";
		/// <summary>
		/// Slected Panel 1
		/// </summary>
		public const string SELECT_PANEL_1 = "1";
		/// <summary>
		/// Selected Panel 2
		/// </summary>
		public const string SELECT_PANEL_2 = "2";

		/// <summary>
		/// The Company Account Record in Session
		/// </summary>
		public const string COMP_ACC_REC = "Session:CompAccRecord";
		/// <summary>
		/// The Company Record in Session
		/// </summary>
		public const string COMP_COMP_REC = "Session:CompRecord";
		/// <summary>
		/// The company record 2
		/// </summary>
		public const string COMP_COMP2_REC = "Session:CompRecord2";
		/// <summary>
		/// The Company member record
		/// </summary>
		public const string COMP_MEM_REC = "Session:CompanyMember";
		/// <summary>
		/// The Company Payment Object
		/// </summary>
		public const string COMP_PAYMENT_OBJECT= "Session:PaymentObject";
		/// <summary>
		/// The Company Account Total Amount
		/// </summary>
		public const string COMP_TOTAL_AMOUNT= "Session:TotalAmount";
		/// <summary>
		/// The Card Information
		/// </summary>
		public const string COMP_CARD_REC = "Session:CardInfo";
		/// <summary>
		/// Sign up page
		/// </summary>
		public const string PAGE_SIGNUP = "SignUp.aspx";


		/// <summary>
		/// Sign up page
		/// </summary>
		public const string PAGE_UPAGRADE = "Upgrade.aspx";

		/// <summary>
		/// Trial page
		/// </summary>
		public const string PAGE_TRIAL   = "Trial.aspx";
		/// <summary>
		/// Upgrade page
		/// </summary>
		public const string PAGE_UPGRADE = "Upgrade.aspx";
		/// <summary>
		/// Registration Step 1
		/// </summary>
		public const string REG_STEP_1   = "RegStep1";
		/// <summary>
		/// Registration Step 2
		/// </summary>
		public const string REG_STEP_2   = "RegStep2";
		/// <summary>
		/// Registration Step 3
		/// </summary>
		public const string REG_STEP_3   = "RegStep3";
		/// <summary>
		/// Registration Step 4
		/// </summary>
		public const string REG_STEP_4   = "RegStep4";
		/// <summary>
		/// Registration Step 5
		/// </summary>
		public const string REG_STEP_5   = "RegStep5";
		/// <summary>
		/// Registration Step 6
		/// </summary>
		public const string REG_STEP_6   = "RegStep6";
		/// <summary>
		/// Registration Step 7
		/// </summary>
		public const string REG_STEP_7   = "RegStep7";

		/// <summary>
		/// Registration Step 7
		/// </summary>
		public const string UREG_STEP_1   = "URegStep1";
 
		/// <summary>
		/// Registration Step 7
		/// </summary>
		public const string UREG_STEP_4   = "URegStep4";


		
		/// <summary>
		/// Company Account Edit Part Changes
		/// </summary>
		public const string CTRL_CONTACT_INFO   = "EditContactInfo";

		/// <summary>
		/// Company Account Edit Billing Info Changes
		/// </summary>
		public const string CTRL_BILLING_INFO   = "EditBillingInfo";

		/// <summary>
		/// Company Account Edit Shipping Info Changes
		/// </summary>
		public const string CTRL_SHIPPING_INFO  = "EditShippingInfo";


		/// <summary>
		/// Company Account Edit Company Account Info Changes
		/// </summary>
		public const string CTRL_ACCOUNTCONFIGURATION_INFO  = "EditAccountConfiguration";


		/// <summary>
		/// Advance Registration
		/// </summary>
		public const string ADVANCE_SEARCH   = "AdvancedSearch";
		/// <summary>
		/// Path to controls
		/// </summary>
		public const string ctrlPath = "~/Controls/";
		/// <summary>
		/// US Currency
		/// </summary>
		public const string MONEY_USA = "$";
		/// <summary>
		/// USA Country Id
		/// </summary>
		public const string COUNTRY_USA = "1";
		/// <summary>
		/// Space Unit
		/// </summary>
		public const string SPACE_IN = "MB";
		/// <summary>
		/// Company Admin Id
		/// </summary>
		public const int COMPANY_ADMIN_ID = 0;
		/// <summary>
		/// Length of months
		/// </summary>
		public const int LENGTH_MONTH = 2;

		


		
		#region Constants for Upgrade Account Request 
		/// <summary>
		/// Upgrade Account Request Contants For Request Type Space
		/// </summary>
		public const string REQUEST_TYPE_SPACE = "S";

		/// <summary>
		/// Upgrade Account Request Contants For Request Type User
		/// </summary>
		public const string REQUEST_TYPE_USER = "U";
		
		/// <summary>
		/// //Upgrade Account Request Contants For Request Status
		/// </summary>
		public const string REQUEST_STATUS_PENDING = "P";

		/// <summary>
		/// //Upgrade Account Request Contants For Request Status
		/// </summary>
		public const string REQUEST_STATUS_APPROVED = "A";

		#endregion


		/// <summary>
		/// DB Provider
		/// </summary>
		public const string strOledbIndexSearch = "Provider=\"MSIDXS\";";

//		private const bool BLN_INSERT_ATEND= false;
//		private const string CMB_FIRST_ROW = " ------ Select ------ ";
//		private const string CMB_FIRST_ROWID = "0";

		#endregion

		#region Constants for Logs
		/// <summary>
		/// New Folder
		/// </summary>
		public const string NEW_FOLDER = "has Create New Folder Name : ";
		/// <summary>
		/// Delete Folder
		/// </summary>
		public const string DELETE_FOLDER = "Folder has been Deleted by : " ;
		/// <summary>
		/// Rename Folder
		/// </summary>
		public const string RENAME_FOLDER = "Folder has been Renamed by : ";
		#endregion

		#region Constants for Company
		
		/// <summary>Constant for ADMIN group name</summary>
		public const string ADMIN_GROUP = "Admin";

		#endregion
		
		#region Constants for Company File 

		/// <summary>Constant for CategoryID</summary>
		public const string NO_CATEGORY_SELECTED = "0";
		/// <summary>Constant for FilePages.</summary>
		public const int FILEPAGES = 1;
		/// <summary>Constant for FilePassword</summary>
		public const string FILE_PASSWORD = "password";
		/// <summary>Constant for DownloadedBy</summary>
		public const int DOWNLOADED_BY = 1;
		/// <summary>Constant for DeletedBy</summary>
		public const int DELETED_BY = 1;
		
		/// <summary>Constant for Documents</summary>
		public const string DOCUMENTS = "\\Documents";
		/// <summary>Constant for Inbox</summary>
		public const string INBOX = "\\Inbox";
		/// <summary>Constant for Outbox</summary>
		public const string OUTBOX = "\\Outbox";
	
		
		#endregion

		#region Constants for Misc category
		/// <summary> Constants for { character </summary>
		public const string DOUBLE_BACK_SLASH = "\\";
		/// <summary>Constant for Comma</summary>
		public const string COMMA_CHAR = ",";
		/// <summary>Constant for Pipe</summary>
		public const string PIPE_CHAR = "|";
		/// <summary>Constant for Colon</summary>
		public const string COLON_CHAR = ":";
		/// <summary>Constant for Colon</summary>
		public const string SEMI_COLON_CHAR = ";";
		/// <summary>Constant for star</summary>
		public const string STAR_CHAR = "*";
		/// <summary>Constant for HASH</summary>
		public const string HASH_CHAR = "#";
		/// <summary>Constant for space</summary>
		public const string SPCAE_CHAR = " ";
		/// <summary> Constants for New Line character </summary>
		public const string NEWLINE_CHAR = "\r\n";
		/// <summary> Constants for BR in html character </summary>
		public const string BREAK_CHAR = "<br>";
		/// <summary> Constants for { character </summary>
		public const string LEFT_CURRELY_CHAR = "{";
		/// <summary> Constants for } character </summary>
		public const string RIGHT_CURRELY_CHAR = "}";
		/// <summary>Constant for Dot(.)</summary>
		public const string DOT_CHAR = ".";
		/// <summary>Constant for Question mark</summary>
		public const string QUESTIONMARK_CHAR = "?";
		/// <summary>Constant for Underscore</summary>
		public const string UNDERSCORE_CHAR = "_";
		/// <summary>Constant for Equal</summary>
		public const string EQUAL_CHAR = "=";
		/// <summary>Constant for ampersand</summary>
		public const string AMPERSAND_CHAR = "&";
		/// <summary>Constant for GIF extension</summary>
		public const string GIF_EXTENSION = ".gif";
		/// <summary>Constant for GIF extension</summary>
		public const string JPG_EXTENSION = ".jpg";
		/// <summary>Constant for tife extension</summary>
		public const string TIFE_EXTENSION = ".tif";
		/// <summary>Constant for GIF extension</summary>
		public const string BMP_EXTENSION = ".bmp";
		/// <summary>Constant for Number of bytes in 1 KB</summary>
		public const int NO_OF_BYTES = 1024;
		/// <summary>Constant for 0</summary>
		public const string ZERO_CHAR = "0";
		/// <summary>Constant for 1</summary>
		public const string ONE_CHAR = "1";

		/// <summary>Constant for 1</summary>
		public const string USERCODE_FIRSTCHAR = "F";

		/// <summary>Constant for 0</summary>
		public const string TWO_CHAR = "2";
		/// <summary>Constant for 1</summary>
		public const string THREE_CHAR = "3";
		/// <summary>Constant for 1</summary>
		public const string MINUS_ONE_CHAR = "-1";

		/// <summary>
		/// Constant for Number RIGHTS_BIT
		/// </summary>
		public const bool RIGHTS_BIT = true;
		/// <summary>	Constants for Save </summary>
		public const string SAVE_STRING = "Save";


		/// <summary>Constant for Number of bytes in 1 KB</summary>
		public const string EDIT_MEMBER_INFORMATIOM = "Edit Member Information";

		/// <summary>Constant for Number of bytes in 1 KB</summary>
		public const string EDIT_OTHER_CHARGE = "Edit Information";

		/// <summary>Constant for Number of bytes in 1 KB</summary>
		public const string ADD_OTHER_CHARGE = "Add Other Charges";
		#endregion
	
		#region Constants File Folder Types
		/// <summary>
		/// If 0 then it is File type and if 1 then it is folder type		
		/// </summary>
		/// <remarks>This Values are Mapped </remarks>
		public enum FileFolderType
		{
			/// <summary>
			/// File Type
			/// </summary>			
			File = '0',

			/// <summary>
			/// Folder Type
			/// </summary>
			Folder = '1',

			/// <summary>
			/// Split Char
			/// </summary>
			Split_Char = '_',

			/// <summary>
			/// Slash Char
			/// </summary>
			Date_Char = '/'
		}
		#endregion

		#region Numric Constants
		/// <summary>
		/// If 0 then it is File type and if 1 then it is folder type		
		/// </summary>
		/// <remarks>This Values are Mapped </remarks>
		public enum NumericValue
		{		
			/// <summary> Value = 0</summary>
			Zero = 0,
			/// <summary> Value = 1</summary>
			One = 1,
			/// <summary> Value = 2</summary>
			Two = 2,			
			/// <summary> Value = 3</summary>
			Three= 3,
			/// <summary> Value = 12</summary>
			Twelve = 12
		}
		#endregion

		#region Operation Mode Enum

		/// <summary>
		/// The Enumerator used for the type of Operation
		/// </summary>
		/// <remarks>This names are same as mapped </remarks>
		public enum OPERATION
		{
			/// <summary>
			/// Delete Operation
			/// </summary>
			Delete,
			/// <summary>
			/// View Operation
			/// </summary>
			View,
			/// <summary>
			/// Edit Operation
			/// </summary>
			Edit
		}
		#endregion

	}
}
