 using System;
using System.Collections;
using Security;

namespace Common
{
   	/// <summary>
	/// Summary description for NandanaSession.
	/// </summary>
	public class NandanaSession
	{
		/// <summary>
		/// Stores premission(s) available to user
		/// </summary>
		protected ArrayList _permissions = null;

		/// <summary>
		/// Default Constructor of Session
		/// </summary>
		public NandanaSession()
		{
			_permissions = new ArrayList();
		}

		#region Nandana Session varables

		/// <summary> User ID </summary>
		public int UserID;
		/// <summary>Property for UserName</summary>
		public string UserName;
		/// <summary>Property for First Name</summary>
		public string FirstName;
		/// <summary>Property for Full Name</summary>
		public string FullName;
		/// <summary>Property for CompanyID</summary>
		public int CompanyID;
		/// <summary>Property for CompanyName</summary>
		public string CompanyName;
		/// <summary>Property for MemberType</summary>
		public int MemberType;
		/// <summary>Property for Firm Name</summary>
		public int YearKey;
		/// <summary>Property for AllotedSpace</summary>
		public int AllotedSpaceMB;
		/// <summary>Property for UsedSpace</summary>
		public int UsedSpace;
		/// <summary> Parent ID </summary>
		public int ParentID;
		/// <summary> The unique Session GUID</summary>
		public string SessionID;
		/// <summary> Property for TotalFiles</summary>
		public long TotalFiles;
		/// <summary> Property for TotlaFolders</summary>
		public long TotlaFolders;
		/// <summary> The Path to upload file for particular user</summary>
		public string UploadPath;
		/// <summary>Property for AccountLevel</summary>
		public bool AccountLevel;
		/// <summary>Property for Email ID</summary>
		public string EmailID;
		/// <summary> LicenseScheme ID </summary>
		public int LicenseSchemeID;
		/// <summary>Property for Time Zone</summary>
		public int TimeZone;
		/// <summary> User ID </summary>
		public int AdminID;
		/// <summary>Property for UserName</summary>
		public string AdminFirstName;
		/// <summary>Property for First Name</summary>
		public string AdminLastName;
		/// <summary> The unique Session GUID</summary>
		public string AdminSessionID;
		/// <summary> The unique Session IsYearly</summary>
		public bool IsYearly;
		/// <summary> The unique Session ExpirationDate</summary>
		public string ExpirationDate;
		/// <summary> he Path to upload file for particular user From Inbox</summary>
		public string UploadInboxPath;	
		/// <summary> Denotes if the user has selected secured mode </summary>
		public bool CheckSecured = false;
		/// <summary> Denotes if the user has selected secured mode </summary>
		public bool CanFax = false;
		/// <summary>Account Status Field (N-New, T-Trial...)</summary>	
		public string Status;

		#endregion
	
		#region Module Rights



		#region Properties

		/// <summary>
		/// Gets allowed premission for currently logged in user.
		/// </summary>
		public void AddPermission(ModuleSecurity moduleSecurity)
		{
			_permissions.Add(moduleSecurity);
		}

		#endregion

		#endregion

		#region Methods

		/// <summary>
		/// Checks whether requested permission is available to logged in user or not.
		/// </summary>
		/// <param name="module">The module name</param>
		/// <param name="permission">Permission to check with</param>
		/// <returns></returns>
		public bool HasPermission(SiteModule module, ModulePermission permission)
		{
			return HasPermission(false, module, permission);
		}


		/// <summary>
		/// Checks if all/any of the permissions specified are available in the Session
		/// </summary>
		/// <param name="checkAll">if set to true, will check if all the specified permissions are available</param>
		/// <param name="module">Module Name</param>
		/// <param name="permissions">Permissions to check with</param>
		/// <returns></returns>
		public bool HasPermission(bool checkAll, SiteModule module, params ModulePermission[] permissions)
		{
			ModuleSecurity _moduleSecurity = GetModule(module);

			if(null == _moduleSecurity)
				return false;
			else
			{
				return _moduleSecurity.CheckPermission(checkAll, permissions);
			}	
		}

		private ModuleSecurity GetModule(SiteModule module)
		{
			for (int idx = 0; idx < _permissions.Count; idx++)
			{
				if( (_permissions[idx] as ModuleSecurity).SiteModule == module )
				{
					return (_permissions[idx] as ModuleSecurity);
				}
			}

			return null;
		}

		#endregion
		
	}
}
