    using System;
namespace Common
{
 	/// <summary>
	/// Summary description for Enum.
	/// </summary>
	public class Enumuration
	{
		/// <summary>
		/// Enumuration
		/// </summary>
		public Enumuration()
		{
			//
			// TODO: Add constructor logic here
			//
		}		
	}

    public enum ModuleName
    { 
        ADMIN,
        TEACHER,
        PARENT,
        STUDENT
    }

    public enum PageName
    { 
        StudentList

    }

	/// <summary>
	/// enums for Fuse Mode to decide the mode of the form.
	/// </summary>
	public enum FuseMode
	{
		/// <summary>fuse mode for add</summary>
		ADD,
		/// <summary>fuse mode for edit</summary>
		EDIT,
		/// <summary>Fuse mode for list</summary>
		LIST,
		/// <summary>Fuse mode for view</summary>
		VIEW,		
		/// <summary>fuse mode for delete</summary>
		DELETE,
		/// <summary>fuse mode for no mode</summary>
		NONE
	}	

	/// <summary>
	/// Enum for Log Category which will be passed at the time of saving Logs
	/// </summary>
	public enum LogCategory
	{	
		/// <summary>Log Category for Login Successful </summary>
		LoginSuccessful	= 1,
		/// <summary>Log Category for Change Password</summary>
		ChangePassword,
		/// <summary>Log Category for UploadFilebyUpload </summary>
		UploadFilebyUpload,
		/// <summary>Log Category for CreateFolder</summary>
		CreateFolder,
		/// <summary>Log Category for DeleteFolder</summary>
		DeleteFolder,
		/// <summary>Log Category for RenameFolder</summary>
		RenameFolder,
		/// <summary>Log Category for AddNewMember</summary>
		AddNewMember,
		/// <summary>Log Category for DeleteMember</summary>
		DeleteMember,
		/// <summary>Log Category for EditMember</summary>
		EditMember,
		/// <summary>Log Category for AddNewGroup</summary>
		AddNewGroup,
		/// <summary>Log Category for EditDocumentDetail</summary>
		EditDocumentDetail,
		/// <summary>Log Category for Save FolderPassword</summary>
		SaveFolderPassword,
		/// <summary>Log Category for Advanced Search</summary>
		PerformAdvanceSearch,
		/// <summary>Log Category for Account Hacking</summary>
		AccountHacking,
		/// <summary>Log Category for Admin Login Successful </summary>
		AdminLoginSuccessful,
		/// <summary>Log Category for Member Profile Updated</summary>
		MemberProfileUpdated,
		/// <summary>Log Category for Company Profile Updated</summary>
		CompanyProfileUpdated,
		/// <summary>Log Category for Invoice For Users request</summary>
		CreateInvoiceForUsers,
		/// <summary>Log Category for Invoice For Scheme Upgrade request</summary>
		CreateInvoiceForScheme,
		/// <summary>Log Category for Invoice For Registartion Approved request</summary>
		CreateInvoiceForRegApp,
		/// <summary>Log Category for Invoice For Registartion Reject request</summary>
		CreateInvoiceForRegRej,

		/// <summary>Log Category for Invoice For Registartion Approved request</summary>
		RegApproved,
		/// <summary>Log Category for Invoice For Registartion Reject request</summary>
		RegRejected,
		/// <summary>Log Category for Invoice For Space Approved request</summary>
		SpaceApproved,
		/// <summary>Log Category for Invoice For Space Reject request</summary>
		SpaceRejected,
		/// <summary>Log Category for Invoice For Users Approved request</summary>
		UsersApproved,
		/// <summary>Log Category for Invoice For Users Reject request</summary>
		UsersRejected,
		/// <summary>Log Category for Invoice For Scheme Approved request</summary>
		SchemeApproved,
		/// <summary>Log Category for Invoice For Scheme Reject request</summary>
		SchemeRejected,
		/// <summary>Log Category for Delete Files and Folders Operation</summary>
		DeleteFilesFolders,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		CreateInvoiceForSpace,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		MoveFilesFolders,

		/// <summary>Log Category for Create Invoice For Space request</summary>
		SentEmail,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		SentFax,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		DownLoadFile,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		DeleteFilesFoldersFromRecyclebin,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		RestoreFilesFolders,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		MoveFilesFoldersFromRecyclebin,
		/// <summary>Log Category for Create Invoice For Space request</summary>
		AdminPasswordChanged,
		
		/// <summary>Log Category for Credit Cards Deleted</summary>
		DeleteCreditCard,
		/// <summary>Log Category for Credit Cards Added </summary>
		AddCreditCard,
		/// <summary>Log Category for Credit Cards edited</summary>
		EditCreditCard,

		/// <summary>Log Category for Create Cabinet</summary>
		CreateCabinet,
		/// <summary>Log Category for Cabinet Deleted</summary>
		DeleteCabinet,
		/// <summary>Log Category for Cabinet details edited</summary>
		EditCabinet,
		/// <summary>Log Category for Cabinet details edited</summary>
		RegistrationEmailFail,
		/// <summary>Checked Out the file</summary>
		CheckedoutFile

	}
	/// <summary>
	/// Enum for Upload File Module which indictes method thru which file was uploaded
	/// </summary>
	public enum UploadModule
	{	
		/// <summary>Category for file Uploaded by Upload file method</summary>
		UploadFile	= 1,
		/// <summary>Category for file Uploaded by WebScan</summary>
		WebScan,
		/// <summary>Category for file Uploaded by Email</summary>
		Inbox
		
	}
	
	/// <summary>
	/// Enum for defining search type (basic/advance search)
	/// </summary>
	public enum SearchCategory
	{	
		/// <summary>Category for Basic Search</summary>
		B,
		/// <summary>Category for Advance Search</summary>
		A
	}

	/// <summary>
	/// Enum for defining Right type
	/// </summary>
	public enum RightsCategory
	{	
		/// <summary>Category for View right</summary>
		FolderVIEW,
		/// <summary>Category for Edit right</summary>
		FolderEDIT,
		/// <summary>Category for Delete Right</summary>
		FolderDELETE,
		/// <summary>Category for Manage Right</summary>
		FolderMANAGE		
	}

	/// <summary>
	/// Enum for defining File Right type
	/// </summary>
	public enum FileRightsCategory
	{	
		/// <summary>Category for View right</summary>
		FileVIEW,
		/// <summary>Category for Edit right</summary>
		FileEDIT,
		/// <summary>Category for Delete Right</summary>
		FileDELETE,
		/// <summary>Category for Manage Right</summary>
		FileMANAGE		
	}

	/// <summary>
	/// Enum for different Radio buttons given in Advance search
	/// </summary>
	public enum AdvanceSearchRadioButtonTypes
	{	
		/// <summary>Category for Find All</summary>
		FindAll = 1,
		/// <summary>Category for None</summary>
		None,
		/// <summary>Category for ExactPhrase</summary>
		ExactPhrase,
		/// <summary>Category for WordLike</summary>
		WordLike		
	}

	/// <summary>
	/// Enum for defining for whom rights to be set (group/user)
	/// </summary>
	public enum RightsGroupUser
	{	
		/// <summary>Category for Group</summary>
		Group,
		/// <summary>Category for User</summary>
		User
	}
	
	/// <summary>
	/// Enum for defining for Status of Request
	/// </summary>
	public enum RequestStatus
	{	
		/// <summary>Category for New</summary>
		N,
		/// <summary>Category for Approved</summary>
		A,
		/// <summary>Category for Rejected</summary>
		R,
		/// <summary>Category for Pending</summary>
		P,
		/// <summary>Category for Expired</summary>
		E,
		/// <summary>Category for Trial</summary>
		T,
		/// <summary>Category for Monthly</summary>
		M,
		/// <summary>Category for Yearly</summary>
		Y,
		/// <summary>Category for Space</summary>
		S,
		/// <summary>Category for User</summary>
		U,
		/// <summary>Category for Scheme</summary>
		C,
		/// <summary>Category for Backup</summary>
		B	

	}

	/// <summary>
	/// Enum for defining Backup Type (CD/DVD/FTP)
	/// </summary>
	public enum BackupType
	{	
		/// <summary>Category for CD</summary>
		C,
		/// <summary>Category for DVD</summary>
		D,
		/// <summary>Category for FTP</summary>
		F
	}

	/// <summary>
	/// Enum for defining for Status of Credit Card
	/// </summary>
	public enum CreditCardStatus
	{	
		/// <summary>Category for Active</summary>
		A,
		/// <summary>Category for Inactive</summary>
		I
	}


	/// <summary>
	/// Enum for defining MemberType (Company Admin / Normal USer)
	/// </summary>
	public enum MemberType
	{	
		/// <summary>Category for Company Admin</summary>
		CompanyAdmin = 1,
		/// <summary>Category for Normal User</summary>
		NormalUser,
		/// <summary>Category for SiteAdmin</summary>
		SiteAdmin,
		/// <summary>Category for Surveillance user</summary>
		Surveillance

	}

	/// <summary>
	/// The Site Module
	/// </summary>
	public enum SiteModule
	{
		/// <summary>No Module Specified</summary>
		NONE = 0,

		// Document Menu
		/// <summary>View doc Module</summary>
		VIEWDOC,
		/// <summary>Search Documents Module</summary>
		SSRCDOC,
		/// <summary>Advance Search Module</summary>
		ASRCDOC,	
		/// <summary>Manage RecycleBin Module</summary>
		MNGRECBN,
		/// <summary>Inbox Module</summary>
		INBOX,
		/// <summary>Checkedout Documents Module</summary>
		CHKOTDOC,
		/// <summary>Folder Management Module</summary>
		FLDRMGMT,		
		/// <summary>INDEX Management Module</summary>
		INDXMGMT,	
		/// <summary>Cabinet Management Module</summary>
		CABMGMT,		
		/// <summary>Category Management Module</summary>
		CATMGMT,	
		
		//Security
		/// <summary>Group Folderwise Permissions Module</summary>
		GFORIGHT,
		/// <summary>Group Filewise Permissions Module</summary>
		GFIRIGHT,
		/// <summary>User Folderwise Permissions Module</summary>
		UFORIGHT,
		/// <summary>User Filewise Permissions Module</summary>
		UFIRIGHT,
		/// <summary>Screen Groupwise Rights Module</summary>
		GSCRIGHT,
		/// <summary>Screen Userwise Rights Module</summary>
		USCRIGHT,		
		/// <summary>Folder Group Rights Module</summary>
		FOGRPRIGHT,	
		/// <summary>Folder User Rights Module</summary>
		FOUSRRIGHT,	
		/// <summary>File Group Rights Module</summary>
		FIGRPRIGHT,	
		/// <summary>File User Rights Module</summary>
		FIUSRRIGHT,	

		//Administrator
		/// <summary>Administrative Tools Module</summary>
		ADMNTOOLS,
		/// <summary>Group Management Module</summary>
		GRPMGMT,
		/// <summary>Member Management Module</summary>
		MEMMGMT,
		/// <summary>Invoices Module</summary>
		INVOICE,

		// Administrative Tools (not in menu)
		/// <summary>Company Profile Module</summary>
		COMPPRFL,
		/// <summary>Cancel Membership Module</summary>
		CNCLMSHP,
		/// <summary>Upgrade Module</summary>
		UPGRADE,
		/// <summary>CC Management Module</summary>
		CCMGMT,
		/// <summary>Team Reports Module</summary>
		TMRPTS,

		// Member Profile
		/// <summary>Member Profile Module</summary>
		MEMPRFL,
		/// <summary>Change Password Module</summary>
		CHNGPWD,
		/// <summary>Request barcode Module</summary>
		REQBRCD,	
		
		// Log Management
		/// <summary>Log Management Module</summary>
		LOGMGMT,
		/// <summary>Purge Log Module</summary>
		PURGMGMT,

		// User Request
		/// <summary>Request History Module</summary>
		REQHSTRY,
		/// <summary>Request Extra Users Module</summary>
		REQEXUS,
		/// <summary>Request Extra Space Module</summary>
		REQEXSP,
		/// <summary>Request Backup Module</summary>
		REQBCKP,
		/// <summary>Scheme Upgrade Request Management</summary>
		REQSCHMUP,	


		//Configuration
		/// <summary>Email Configuration Module</summary>
		EMCONFIG,
		/// <summary>Fax Configuration Module</summary>
		FXCONFIG,

		//Renting-Scanning
		/// <summary>Renting Scanner Module</summary>
		RENTSCN,
		/// <summary>DocumentScanning Module</summary>
		DOCSCN,
		
//		/// <summary>Member Home Module</summary>
//		MEMHOME,
		
		
//		//Tasks
//		/// <summary>Delete Log Task</summary>
//		//DELLOG,		
		/// <summary>Send Email Task</summary>
		SENDMAIL,
		/// <summary>Send Fax Task</summary>
		SENDFAX,
		/// <summary>Upload Documents Task</summary>
		UPLDDOC,
		/// <summary>Download Documents Task</summary>
		DWNLDDOC,
		/// <summary>Checkout Documents Task</summary>
		CHKOUTDOC
	}

	/// <summary>
	/// Enum For Help Code, on passing help code to the function, appropriate 
	/// </summary>
	public enum HelpCode
	{
		/// <summary>Code for NONE</summary>
		NONE,
		/// <summary>Code for MemberHome Help</summary>
		MEMBERHOME,
		/// <summary>Code for MemberHomeImage Help</summary>
		MemberHomeImage,
		/// <summary>Code for UserFolderRights Help</summary>
		UserFolderRights,
		
		/// <summary>Code for UserFileRights Help</summary>
		UserFileRights,
		/// <summary>Code for GroupFolderRights Help</summary>
		GroupFolderRights,
		/// <summary>Code for GroupFileRights Help</summary>
		GroupFileRights,
		/// <summary>Code for ModuleGroupRights Help</summary>
		ModuleGroupRights,
		/// <summary>Code for ModuleGroupRights Help</summary>
		ModuleUserRights,
		/// <summary>Code for CheckedOutDocuments Help</summary>
		CheckedOutDocuments,
		/// <summary>Code for CategoryList Help</summary>
		CategoryList,
		/// <summary>Code for AdinistrativeTools Help</summary>
		AdinistrativeTools,
		/// <summary>Code for GroupManagement Help</summary>
		GroupManagement,
		/// <summary>Code for MemberManagement Help</summary>
		MemberManagement,
		/// <summary>Code for ViewInvoices Help</summary>
		ViewInvoices,
		/// <summary>Code for TemplateManagement Help</summary>
		TemplateManagement,
		/// <summary>Code for MemberProfile Help</summary>
		MemberProfile,
		/// <summary>Code for ChangePasssword Help</summary>
		ChangePasssword,
		/// <summary>Code for viewLogManagement Help</summary>
		viewLogManagement,
		/// <summary>Code for PurgeLogManagement Help</summary>
		PurgeLogManagement,
		/// <summary>Code for RequestHistory Help</summary>
		RequestHistory,
		/// <summary>Code for RequestUser Help</summary>
		RequestUser,
		/// <summary>Code for RequestSpace Help</summary>
		RequestSpace,
		/// <summary>Code for RequestBackup Help</summary>
		RequestBackup,
		/// <summary>Code for RequestBackup Help</summary>
		RequestSchemeHistroy,
		/// <summary>Code for EmailConfiguration Help</summary>
		EmailConfiguration,
		/// <summary>Code for FaxConfiguration Help</summary>
		FaxConfiguration,
		/// <summary>Code for RentingScanner Help</summary>
		RentingScanner,
		/// <summary>Code for DocumentScanning Help</summary>
		DocumentScanning,
		/// <summary>Code for Addcreditcard Help</summary>
		Addcreditcard,
		/// <summary>Code for CreditcardInformation Help</summary>
		CreditcardInformation,
		/// <summary>Code for TeamReports Help</summary>
		TeamReports,
		/// <summary>Code for CompanyProfile Help</summary>
		CompanyProfile,
		/// <summary>Code for AddnewGroup Help</summary>
		AddnewGroup,
		/// <summary>Code for AddnewMember Help</summary>
		AddnewMember,
		/// <summary>Code for AddTemplate Help</summary>
		AddTemplate,
		/// <summary>Code for AddCabinet Help</summary>
		AddCabinet,
		/// <summary>Code for AddCategory Help</summary>
		AddCategory,
		/// <summary>Code for Documents Help</summary>
		Documents,
		/// <summary>Code for SearchResults</summary>
		SearchResults,
		
		
		

		
		
		
		

		
		

		
		
		

		
		/// <summary>Code for BasicSearch Help</summary>
		BasicSearch,	
		

		//Extra Codes used for static text displayed on some pages
		/// <summary>Code for static display text in BasicSearch page for Basic as well as advance search</summary>
		TxtBasicAdvanceSearch,	
		/// <summary>Code for static display text in BasicSearch page for only Basic search(advance search is disabled for particular user)</summary>
		TxtBasicSearch
	}

	/// <summary>
	/// The permissions available to Modules / Tasks
	/// </summary>
	public enum ModulePermission
	{
		/// <summary>View Right</summary>
		View = 'V',
		/// <summary>Add Right</summary>
		Add  = 'A',
		/// <summary>Edit Right</summary>
		Edit = 'E',
		/// <summary>Delete Right</summary>
		Delete = 'D',
	}

	/// <summary>
	/// Inbox Type
	/// </summary>
	public enum InboxType
	{
		/// <summary>Email</summary>
		E,
		/// <summary>FAx</summary>
		F,
	}

	/// <summary>
	/// Invoice Type
	/// </summary>
	public enum InvoiceType
	{
		/// <summary>New</summary>
		New = 0,
		/// <summary>Paid</summary>
		Paid,
		/// <summary>Review</summary>
		Review,
		/// <summary>Paid</summary>
		OverDue,
		/// <summary>All</summary>
		All,
	}

	/// <summary>
	/// Style sheet groups
	/// </summary>
	public enum StyleSheetGroup
	{
		/// <summary>Font</summary>
		Font = 0,
		/// <summary>Text</summary>
		Text,
		/// <summary>Color</summary>
		Color,
		/// <summary>Border</summary>
		Border		
	}

	/// <summary>
	/// Style sheet Class Element Types
	/// </summary>
	public enum StyleSheetClassElementType
	{
		/// <summary>font-family</summary>
		F = 0,
		/// <summary>font-weight</summary>
		W,
		/// <summary>font-size</summary>
		S,
		/// <summary>text-decoration</summary>
		D,
		/// <summary>Border</summary>
		B,
		/// <summary>Border-Top</summary>
		BT,
		/// <summary>Border-Right</summary>
		BR,
		/// <summary>Border-Bottom</summary>
		BB,
		/// <summary>Border-Left</summary>
		BL,
		/// <summary>Color</summary>
		C,
		/// <summary>background-color</summary>
		BC
	}

	/// <summary>
	/// Site Link Types [Header / Footer]
	/// </summary>
	public enum LinkType
	{
		/// <summary>Header</summary>
		H = 0,
		/// <summary>Footer</summary>
		F		
	}

	/// <summary>
	/// enums for Toolbar button (one used in View documnet) ItemID.
	/// </summary>
	public enum ToolbarButtonItemID
	{
		/// <summary>GoBack ItemID</summary>
		GoBack,
		/// <summary>NewFolder ItemID</summary>
		NewFolder,
		/// <summary>RenameFolder ItemID</summary>
		RenameFolder,
		/// <summary>Upload ItemID</summary>
		Upload,
		/// <summary>Download ItemID</summary>
		Download,
		/// <summary>SendFax ItemID</summary>
		SendFax,
		/// <summary>SendEmail ItemID</summary>
		SendEmail,
		/// <summary>CheckOut ItemID</summary>
		CheckOut,
		/// <summary>Move ItemID</summary>
		Move,
		/// <summary>Delete ItemID</summary>
		Delete,
		/// <summary>Change Password ItemID</summary>
		ChangePassword,
		/// <summary>RequestBarcode ItemID</summary>
		RequestBarcode,
		/// <summary>UserRight ItemID</summary>
		UserRight,
		/// <summary>GroupRight ItemID</summary>
		GroupRight,
		/// <summary>Restore ItemID</summary>
		Restore,
		/// <summary>ViewLog ItemID</summary>
		ViewLog,
		/// <summary>Reset ItemID</summary>
		Reset
	}
}
