using System;
using System.Collections.Specialized;
using System.Configuration;


namespace DataAccess
{
   	/// <summary>
	/// Helper class to get ConnectionString from the Configuration file.
	/// </summary>
	public class DocSortConnStrings
	{
		// based on GoF singleton definition
		private static DocSortConnStrings m_Instance = null;
		private static System.Threading.Mutex m_Mutex = InitializeMutex();
		private static NameValueCollection m_colConnetionStrings =(NameValueCollection) ConfigurationSettings.GetConfig("appSettings");
		
		private static System.Threading.Mutex InitializeMutex()
		{
			return (new System.Threading.Mutex());
		}

		/// <summary>
		/// Function to get instance of this class
		/// </summary>
		/// <returns>Instance of the ConnectionStrings class</returns>
		public static DocSortConnStrings GetInstance()
		{
			// To be thread safe, we use Mutex to synchronize threads
			m_Mutex.WaitOne(); // WaitOne() requests a thread
			if (m_Instance == null)
				m_Instance = new DocSortConnStrings();
			m_Mutex.ReleaseMutex();
			return m_Instance;
		}
		/// <summary>
		/// Function to Get the Connection String from DB type in the Config settings
		/// </summary>
		/// <returns>Connection String</returns>
		public string GetConnectionStringByDBType()
		{
			string sDBType ="";
			sDBType = m_colConnetionStrings.Get("DBType");
			return m_colConnetionStrings.Get(sDBType.ToString()+"_ConnString");
		}	
	}
}
