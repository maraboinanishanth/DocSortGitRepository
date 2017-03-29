 using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;

namespace DataAccess
{
    
	/// <summary>
	/// Class to instantiate Factory Object instance based on the parameter in the config and also has some 
	/// helper functions to generate SQL queries.
	/// </summary>
	public class NandanaDBInstance
	{
		// based on GoF singleton definition
		private static System.Threading.Mutex m_Mutex = new System.Threading.Mutex();
		private static NandanaAbstractFactory m_oDBFactory;
		private static NameValueCollection m_colAppSettings;
		/// <summary>
		/// static constructor 
		/// </summary>
		public NandanaDBInstance()
		{
		}

		/// <summary>
		/// Get DBFactory object based on the DBType specified in the applicaton settings
		/// </summary>
		/// <returns>Single instance of the NandanaAbstractDBFactory. If DBType = SQL then it returns NandanaSqlFactory object</returns>
		public static NandanaAbstractFactory GetDBFactory()
		{
			string sDBType ="";
			if (null == m_oDBFactory)
			{
				m_colAppSettings= (NameValueCollection) ConfigurationSettings.GetConfig("appSettings");


				sDBType = m_colAppSettings.Get("DBType");
				
				// To be thread safe, we use Mutex to synchronize threads
				m_Mutex.WaitOne(); // WaitOne() requests a thread
				if(sDBType == "SQL")
					m_oDBFactory = new NandanaMySqlFactory();
                else if (sDBType == "MYSQL")
                    m_oDBFactory = new NandanaMySqlFactory();
				m_Mutex.ReleaseMutex();
			}
			return m_oDBFactory;
		}

		/// <summary>
		/// Helper class to get the dynamic Insert Sql statement created from the column list passed as parameter
		/// </summary>
		/// <param name="InsertSQL">Dynamic Insert SQL statement</param>
		/// <param name="hstColumns">Hashtable of the column name to be inserted</param>
		/// <returns>Modified Insert Sql statement</returns>
		public static string GetInsertQuery(string InsertSQL, Hashtable hstColumns)
		{
			string sColumnList= "";
			string sParamList= "";

			if(null != hstColumns)
			{
				foreach ( DictionaryEntry dItem in hstColumns ) 
				{
					if (sColumnList.Length>0)
						sColumnList+=",";
					if (sParamList.Length>0)
						sParamList+=",";
					sColumnList += dItem.Key;
					sParamList += dItem.Value;
				}
				InsertSQL = String.Format(InsertSQL,sColumnList,sParamList);
			}
			return InsertSQL;
		}
		
		/// <summary>
		/// Helper class to get the dynamic Update Sql statement created from the column list and where clause passed as parameter
		/// </summary>
		/// <param name="sUpdateSQL">Update SQL Statement</param>
		/// <param name="hstColumns">Hashtable for columns</param>
		/// <param name="hstWhereClause">Hashtable for Where clause</param>
		/// <returns>Modified Update query</returns>
		public static string GetUpdateQuery(string sUpdateSQL ,Hashtable  hstColumns, Hashtable hstWhereClause)
		{
			string sValues= "";
			string sWhereClause= "";

			if(null != hstColumns)
			{
				foreach ( DictionaryEntry dItem in hstColumns) 
				{
					if (sValues.Length>0)
						sValues+= ",";
					sValues  += dItem.Key + "=" + dItem.Value ;
				}
			}
			if(null != hstWhereClause)
			{
				foreach ( DictionaryEntry dItem in hstWhereClause) 
				{
					if (sWhereClause.Length>0)
						sWhereClause+= " and ";
					sWhereClause += dItem.Key + "=" + dItem.Value;
				}
			}
			sUpdateSQL = String.Format(sUpdateSQL,sValues,sWhereClause);
			return sUpdateSQL;

		}
		/// <summary>
		/// Helper class to get the dynamic Sql statement created from the where clause passed as parameter
		/// </summary>
		/// <param name="sSQL">SQL Statement</param>
		/// <param name="hstWhereClause">Hashtable for Where clause</param>
		/// <returns>Modified SQL statement which can be directly used</returns>
		public static string GetQuery(string sSQL, Hashtable hstWhereClause)
		{
			string sWhereClause= "";

			if(null != hstWhereClause)
			{
				foreach ( DictionaryEntry dItem in hstWhereClause) 
				{
					if (sWhereClause.Length>0)
						sWhereClause+= " and ";
					sWhereClause += dItem.Key + "=" + dItem.Value;
				}
				sSQL = String.Format(sSQL,sWhereClause);
			}
			return sSQL;
		}
		/// <summary>
		/// Helper class to get the dynamic Select Sql statement created from the column list and where clause passed as parameter
		/// </summary>
		/// <param name="sSelectSQL">Update SQL Statement</param>
		/// <param name="ColumnList">ArrayList for columns</param>
		/// <param name="hstWhereClause">Hashtable for Where clause</param>
		/// <returns>Modified Select query which can be directly used</returns>
		public static string GetSelectQuery(string sSelectSQL ,ArrayList ColumnList, Hashtable hstWhereClause)
		{
			string sValues= "";
			string sWhereClause= "";

			if(null != ColumnList)
			{
				foreach ( string column in ColumnList) 
				{
					if (sValues.Length>0)
						sValues+= ",";
					sValues += column ;
				}
			}
			if(null != hstWhereClause)
			{
				foreach ( DictionaryEntry dItem in hstWhereClause) 
				{
					if (sWhereClause.Length>0)
						sWhereClause+= " and ";
					sWhereClause += dItem.Key + "=" + dItem.Value;
				}
				
			}
			sSelectSQL = String.Format(sSelectSQL,sValues,sWhereClause);
			return sSelectSQL;

		}
	}
}

