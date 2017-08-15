using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Common;

namespace DataAccess
{
    /// <summary>
	/// Abstract Factory Class for Database activities. 
	/// </summary>
	public abstract class DocSortAbstractFactory
	{
		/// <summary>
		/// Abstract function definition for ExecuteDataReader 
		/// </summary>
		/// <param name="Request">DocSortDBRequest Object containing all the DB details</param>
		/// <returns>DocSortDataReader object</returns>
		public abstract DocSortDataReader ExecuteDataReader(DocSortDBRequest Request);

		/// <summary>
		/// Abstract function definition for ExecuteDataSet
		/// </summary>
		/// <param name="Request">DocSortDBRequest Object containing all the DB details</param>
		/// <returns>DocSortDataSet object</returns>
		public abstract DocSortDataSet ExecuteDataSet(DocSortDBRequest Request);

		/// <summary>
		/// Abstract function definition for ExecuteDataSet with select query directly passed in
		/// </summary>
		/// <param name="sSelectSQL">Select Query</param>
		/// <param name="colParameterList">ArrayList of parameter</param>
		/// <returns>DocSortDataSet object</returns>
		public abstract DocSortDataSet ExecuteDataSet(string sSelectSQL, ArrayList colParameterList);

		/// <summary>
		/// Abstract function definition for ExecuteNonQuery
		/// </summary>
		/// <param name="Request">DocSortDBRequest Object containing all the DB details</param>
		/// <returns>Integer value whether query was successful or not</returns>
		public abstract int ExecuteNonQuery(DocSortDBRequest Request);
		/// <summary>
		/// Abstract function definition for ExecuteScalar
		/// </summary>
		/// <param name="Request">DocSortDBRequest Object containing all the DB details</param>
		/// <returns>1X1 object </returns>
		public abstract object ExecuteScalar(DocSortDBRequest Request);

		/// <summary>
		/// GetConnection to be override in the derived class
		/// </summary>
		/// <returns>Connection Object</returns>
		public abstract IDbConnection GetConnection();
		/// <summary>
		/// GetTransaction to be override in the derived class
		/// </summary>
		/// <returns>Transaction Object</returns>
		public abstract MySqlTransaction GetTransaction();
       
	}
}
