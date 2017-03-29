using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public abstract class NandanaMySqlAbstractFactory
    {
        /// <summary>
        /// Abstract function definition for ExecuteDataReader 
        /// </summary>
        /// <param name="Request">NandanaDBRequest Object containing all the DB details</param>
        /// <returns>NandanaDataReader object</returns>
        public abstract NandanaDataReader ExecuteDataReader(NandanaMySqlDBRequest Request);

        /// <summary>
        /// Abstract function definition for ExecuteDataSet
        /// </summary>
        /// <param name="Request">NandanaDBRequest Object containing all the DB details</param>
        /// <returns>NandanaDataSet object</returns>
        public abstract NandanaDataSet ExecuteDataSet(NandanaMySqlDBRequest Request);

        /// <summary>
        /// Abstract function definition for ExecuteDataSet with select query directly passed in
        /// </summary>
        /// <param name="sSelectSQL">Select Query</param>
        /// <param name="colParameterList">ArrayList of parameter</param>
        /// <returns>NandanaDataSet object</returns>
        public abstract NandanaDataSet ExecuteDataSet(string sSelectSQL, ArrayList colParameterList);

        /// <summary>
        /// Abstract function definition for ExecuteNonQuery
        /// </summary>
        /// <param name="Request">NandanaDBRequest Object containing all the DB details</param>
        /// <returns>Integer value whether query was successful or not</returns>
        public abstract int ExecuteNonQuery(NandanaMySqlDBRequest Request);
        /// <summary>
        /// Abstract function definition for ExecuteScalar
        /// </summary>
        /// <param name="Request">NandanaDBRequest Object containing all the DB details</param>
        /// <returns>1X1 object </returns>
        public abstract object ExecuteScalar(NandanaMySqlDBRequest Request);

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