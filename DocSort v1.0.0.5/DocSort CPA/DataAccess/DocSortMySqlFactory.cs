using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Diagnostics;
namespace DataAccess
{
    class DocSortMySqlFactory: DocSortAbstractFactory
    {
        /// <summary>
        /// DocSortMySqlFactory Constructor
        /// </summary>
        public DocSortMySqlFactory()
        {
        }

        /// <summary>
        /// Destructor to close connection
        /// </summary>
        ~DocSortMySqlFactory()
        {
        }

        /// <summary>
        /// Get or create instances of the MySqlConnection and returns it
        /// </summary>
        /// <returns>MySqlConnection object</returns>
        public override IDbConnection GetConnection()
        {
            MySqlConnection conMySql = null;
            try
            {
                conMySql = new MySqlConnection();
                conMySql.ConnectionString = GetConnectionString();
                conMySql.Open();
            }
            catch (MySqlException)
            {
                if (conMySql.State == ConnectionState.Open)
                    conMySql.Close();
                throw;
            }
            return conMySql;
        }

        /// <summary>
        /// Get or create instances of the Transaction 
        /// </summary>
        /// <returns>MySqlTransaction object</returns>
        public override MySqlTransaction GetTransaction()
        {
            MySqlTransaction transMySql;

            MySqlConnection conMySql = null;
            try
            {
                conMySql = (MySqlConnection)this.GetConnection();
                transMySql = conMySql.BeginTransaction();
            }
            catch (MySqlException exMySql)
            {
                Debug.WriteLine(exMySql.Message);
                if ((conMySql != null) && (conMySql.State == ConnectionState.Open))
                    conMySql.Close();
                throw;
            }
            return transMySql;
        }


        /// <summary>
        /// Execute DataReader
        /// </summary>
        /// <param name="Request">DocSortDBRequest with connection details</param>
        /// <returns>DataReader Object</returns>
        public override DocSortDataReader ExecuteDataReader(DocSortDBRequest Request)
        {
            // implementation code here....
            MySqlConnection conMySql = new MySqlConnection();
            MySqlCommand cmdMySql = new MySqlCommand();
            MySqlDataReader drMySql;
            MySqlTransaction tranMySql = null;

            DocSortMySqlDataReader oDataReaderMySql = new DocSortMySqlDataReader();
            try
            {
                conMySql.ConnectionString = GetConnectionString();
                if (Request.Transaction != null)
                    tranMySql = Request.Transaction;

                PrepareCommand(cmdMySql, conMySql, tranMySql, Request);

                drMySql = cmdMySql.ExecuteReader();
                oDataReaderMySql.ReturnedDataReader = drMySql;
            }
            catch (MySqlException exMySql)
            {
                if (conMySql.State == ConnectionState.Open)
                    conMySql.Close();
                throw (exMySql);
            }

            finally
            {
                cmdMySql.Parameters.Clear();
            }
            return oDataReaderMySql;
        }

        /// <summary>
        /// Implementation of ExecuteNonQuery for MySql specific
        /// </summary>
        /// <param name="Request">DocSortDBRequest object</param>
        /// <returns>int value</returns>
        public override int ExecuteNonQuery(DocSortDBRequest Request)
        {
            MySqlConnection conMySql = new MySqlConnection();
            MySqlCommand cmdMySql = new MySqlCommand();
            MySqlParameter prmMySql = new MySqlParameter();
            MySqlTransaction tranMySql = null;
            int iVal = 0;
            try
            {
                if (Request.Transaction != null)
                    tranMySql = Request.Transaction;

                PrepareCommand(cmdMySql, conMySql, tranMySql, Request);
                //if (cmdMySql.CommandType == CommandType.StoredProcedure)
                //{
                //    prmMySql.ParameterName = "@Return";
                //    prmMySql.DbType = DbType.Int32;
                //    prmMySql.Direction = ParameterDirection.ReturnValue;
                //    cmdMySql.Parameters.Add(prmMySql);
                //}
                iVal = cmdMySql.ExecuteNonQuery();
                //if (cmdMySql.CommandType == CommandType.StoredProcedure)
                //{
                //    iVal = Convert.ToInt32(cmdMySql.Parameters["@Return"].Value.ToString());
                //}
            }
            catch (MySqlException)
            {
                if (conMySql.State == ConnectionState.Open)
                    conMySql.Close();
                throw;
            }
            finally
            {
                if (cmdMySql != null)
                {
                    cmdMySql.Parameters.Clear();
                }
                if ((Request.Transaction == null) && (conMySql.State == ConnectionState.Open))
                    conMySql.Close();
            }
            return iVal;
        }

        /// <summary>
        /// Execute DataSet
        /// </summary>
        /// <param name="Request">DocSortDBRequest with connection details</param>
        /// <returns>DataSet Object</returns>
        public override DocSortDataSet ExecuteDataSet(DocSortDBRequest Request)
        {
            // implementation code here...
            MySqlConnection conMySql = new MySqlConnection();
            MySqlCommand cmdMySql = new MySqlCommand();
            MySqlDataAdapter daMySql;
            DocSortMySqlDataSet oDataSetMySql = new DocSortMySqlDataSet();
            MySqlTransaction tranMySql = null;

            try
            {
                if (Request.Transaction != null)
                    tranMySql = Request.Transaction;

                PrepareCommand(cmdMySql, conMySql, tranMySql, Request);
                daMySql = new MySqlDataAdapter(cmdMySql);
                daMySql.Fill(oDataSetMySql.ReturnedDataSet);
            }
            catch (MySqlException ex)
            {
                if (conMySql.State == ConnectionState.Open)
                    conMySql.Close();
                throw (ex);
            }
            finally
            {
                if (cmdMySql != null)
                {
                    cmdMySql.Parameters.Clear();
                }
                if ((Request.Transaction == null) && (conMySql.State == ConnectionState.Open))
                    conMySql.Close();
            }

            return oDataSetMySql;
        }
        /// <summary>
        /// Execute Scalar
        /// </summary>
        /// <param name="Request">DocSortDBRequest with connection details</param>
        /// <returns>return 1X1 Object returned by ExecuteScalar</returns>
        public override Object ExecuteScalar(DocSortDBRequest Request)
        {
            // implementation code here...
            MySqlConnection conMySql = new MySqlConnection();
            MySqlCommand cmdMySql = new MySqlCommand();
            MySqlTransaction tranMySql = null;
            object oReturn;
            try
            {
                if (Request.Transaction != null)
                    tranMySql = Request.Transaction;

                PrepareCommand(cmdMySql, conMySql, tranMySql, Request);
                oReturn = cmdMySql.ExecuteScalar();
            }
            catch (MySqlException)
            {
                if (conMySql.State == ConnectionState.Open)
                    conMySql.Close();
                throw;
            }
            finally
            {
                if (cmdMySql != null)
                {
                    cmdMySql.Parameters.Clear();
                }
                if ((Request.Transaction == null) && (conMySql.State == ConnectionState.Open))
                    conMySql.Close();
            }

            return oReturn;
        }

        /// <summary>
        /// Private function to retrive connection string from the Configuration settings
        /// </summary>
        /// <returns>String containing connection String</returns>
        private string GetConnectionString()
        {
            DocSortConnStrings oConnString = DocSortConnStrings.GetInstance();
            return oConnString.GetConnectionStringByDBType();
        }

        /// <summary>
        /// Prepare Command to be executed
        /// </summary>
        /// <param name="cmdMySql">MySqlCommand instance</param>
        /// <param name="conMySql">MySqlConnection instance. Transaction is handle internally</param>
        /// <param name="tranMySql">Transaction instance. </param>
        /// <param name="Request">DocSortDBRequest containing Requests</param>
        private void PrepareCommand(MySqlCommand cmdMySql, MySqlConnection conMySql, MySqlTransaction tranMySql, DocSortDBRequest Request)
        {

            if (tranMySql != null)
            {
                conMySql = tranMySql.Connection;
                cmdMySql.Transaction = tranMySql;
            }
            else
            {
                conMySql.ConnectionString = GetConnectionString();
                conMySql.Open();
            }
            cmdMySql.Connection = conMySql;
            cmdMySql.CommandText = Request.Command;
            cmdMySql.CommandType = Request.CommandType;

            // add parameters if they exists.
            if ((Request.Parameters != null) && (Request.Parameters.Count > 0))
            {
                foreach (DocSortDBRequest.Parameter oParam in Request.Parameters)
                {
                    //if((oParam.ParamValue.GetType() == typeof(System.String))&& oParam.ParamValue.ToString().Length==0)
                    //	oParam.ParamValue  = DBNull.Value;
                    if (oParam.ParamValue == System.DBNull.Value)
                        oParam.ParamValue = DBNull.Value;
                    cmdMySql.Parameters.Add(oParam.ParamName, oParam.ParamValue);
                }
            }
        }
        /// <summary>
        /// Execute DataSet with query directly passed as parameter
        /// </summary>
        /// <param name="sSelectMySql">Select Query</param>
        /// <param name="colParameterList">Array of DocSortDBRequest.Parameter containing Name and value pair</param>
        /// <returns>DataSet Object</returns>
        public override DocSortDataSet ExecuteDataSet(string sSelectMySql, ArrayList colParameterList)
        {
            // implementation code here...
            MySqlConnection conMySql = new MySqlConnection();
            MySqlCommand cmdMySql = new MySqlCommand();
            MySqlDataAdapter daMySql;
            DocSortMySqlDataSet oDataSetMySql = new DocSortMySqlDataSet();
            DocSortDBRequest oRequest = new DocSortDBRequest(sSelectMySql, CommandType.Text, null, colParameterList);
            try
            {
                PrepareCommand(cmdMySql, conMySql, null, oRequest);
                daMySql = new MySqlDataAdapter(cmdMySql);
                daMySql.Fill(oDataSetMySql.ReturnedDataSet);
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (cmdMySql != null)
                {
                    cmdMySql.Parameters.Clear();
                }
                if (conMySql.State == ConnectionState.Open)
                    conMySql.Close();
            }

            return oDataSetMySql;
        }
    }
}

