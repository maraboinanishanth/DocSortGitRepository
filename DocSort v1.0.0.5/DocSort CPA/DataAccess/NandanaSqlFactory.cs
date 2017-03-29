using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;

namespace DataAccess
{
    /// <summary>
    /// SqlFactory class for SQL Database derived from AbstractFactory class.
    /// </summary>
    public class NandanaSqlFactory : NandanaAbstractFactory
    {
        /// <summary>
        /// NandanaSqlFactory Constructor
        /// </summary>
        public NandanaSqlFactory()
        {
        }

        /// <summary>
        /// Destructor to close connection
        /// </summary>
        ~NandanaSqlFactory()
        {
        }

        /// <summary>
        /// Get or create instances of the SqlConnection and returns it
        /// </summary>
        /// <returns>SqlConnection object</returns>
        public override IDbConnection GetConnection()
        {
            SqlConnection conSQL = null;
            try
            {
                conSQL = new SqlConnection();
                conSQL.ConnectionString = GetConnectionString();
                conSQL.Open();
            }
            catch (SqlException)
            {
                if (conSQL.State == ConnectionState.Open)
                    conSQL.Close();
                throw;
            }
            return conSQL;
        }

        /// <summary>
        /// Get or create instances of the Transaction 
        /// </summary>
        /// <returns>SqlTransaction object</returns>
        public override SqlTransaction GetTransaction() 
        {
            SqlTransaction transSQL;

            SqlConnection conSQL = null;
            try
            {
                conSQL = (SqlConnection)this.GetConnection();
                transSQL = conSQL.BeginTransaction();
            }
            catch (SqlException exSQL)
            {
                Debug.WriteLine(exSQL.Message);
                if ((conSQL != null) && (conSQL.State == ConnectionState.Open))
                    conSQL.Close();
                throw;
            }
            return transSQL;
        }


        /// <summary>
        /// Execute DataReader
        /// </summary>
        /// <param name="Request">NandanaDBRequest with connection details</param>
        /// <returns>DataReader Object</returns>
        public override NandanaDataReader ExecuteDataReader(NandanaDBRequest Request)
        {
            // implementation code here....
            SqlConnection conSQL = new SqlConnection();
            SqlCommand cmdSQL = new SqlCommand();
            SqlDataReader drSQL;
            SqlTransaction tranSQL = null;

            NandanaSqlDataReader oDataReaderSQL = new NandanaSqlDataReader();
            try
            {
                conSQL.ConnectionString = GetConnectionString();
                if (Request.Transaction != null)
                    tranSQL = Request.Transaction;

                PrepareCommand(cmdSQL, conSQL, tranSQL, Request);

                drSQL = cmdSQL.ExecuteReader();
                oDataReaderSQL.ReturnedDataReader = drSQL;
            }
            catch (SqlException exSQL)
            {
                if (conSQL.State == ConnectionState.Open)
                    conSQL.Close();
                throw (exSQL);
            }

            finally
            {
                cmdSQL.Parameters.Clear();
            }
            return oDataReaderSQL;
        }

        /// <summary>
        /// Implementation of ExecuteNonQuery for SQL specific
        /// </summary>
        /// <param name="Request">NandanaDBRequest object</param>
        /// <returns>int value</returns>
        public override int ExecuteNonQuery(NandanaDBRequest Request)
        {
            SqlConnection conSQL = new SqlConnection();
            SqlCommand cmdSQL = new SqlCommand();
            SqlParameter prmSQL = new SqlParameter();
            SqlTransaction tranSQL = null;
            int iVal = 0;
            try
            {
                if (Request.Transaction != null)
                    tranSQL = Request.Transaction;

                PrepareCommand(cmdSQL, conSQL, tranSQL, Request);
                if (cmdSQL.CommandType == CommandType.StoredProcedure)
                {
                    prmSQL.ParameterName = "@Return";
                    prmSQL.DbType = DbType.Int32;
                    prmSQL.Direction = ParameterDirection.ReturnValue;
                    cmdSQL.Parameters.Add(prmSQL);
                }
                iVal = cmdSQL.ExecuteNonQuery();
                if (cmdSQL.CommandType == CommandType.StoredProcedure)
                {
                    iVal = Convert.ToInt32(cmdSQL.Parameters["@Return"].Value.ToString());
                }
            }
            catch (SqlException)
            {
                if (conSQL.State == ConnectionState.Open)
                    conSQL.Close();
                throw;
            }
            finally
            {
                if (cmdSQL != null)
                {
                    cmdSQL.Parameters.Clear();
                }
                if ((Request.Transaction == null) && (conSQL.State == ConnectionState.Open))
                    conSQL.Close();
            }
            return iVal;
        }

        /// <summary>
        /// Execute DataSet
        /// </summary>
        /// <param name="Request">NandanaDBRequest with connection details</param>
        /// <returns>DataSet Object</returns>
        public override NandanaDataSet ExecuteDataSet(NandanaDBRequest Request)
        {
            // implementation code here...
            SqlConnection conSQL = new SqlConnection();
            SqlCommand cmdSQL = new SqlCommand();
            SqlDataAdapter daSQL;
            NandanaSqlDataSet oDataSetSQL = new NandanaSqlDataSet();
            SqlTransaction tranSQL = null;

            try
            {
                if (Request.Transaction != null)
                    tranSQL = Request.Transaction;

                PrepareCommand(cmdSQL, conSQL, tranSQL, Request);
                daSQL = new SqlDataAdapter(cmdSQL);
                daSQL.Fill(oDataSetSQL.ReturnedDataSet);
            }
            catch (SqlException ex)
            {
                if (conSQL.State == ConnectionState.Open)
                    conSQL.Close();
                throw (ex);
            }
            finally
            {
                if (cmdSQL != null)
                {
                    cmdSQL.Parameters.Clear();
                }
                if ((Request.Transaction == null) && (conSQL.State == ConnectionState.Open))
                    conSQL.Close();
            }

            return oDataSetSQL;
        }
        /// <summary>
        /// Execute Scalar
        /// </summary>
        /// <param name="Request">NandanaDBRequest with connection details</param>
        /// <returns>return 1X1 Object returned by ExecuteScalar</returns>
        public override Object ExecuteScalar(NandanaDBRequest Request)
        {
            // implementation code here...
            SqlConnection conSQL = new SqlConnection();
            SqlCommand cmdSQL = new SqlCommand();
            SqlTransaction tranSQL = null;
            object oReturn;
            try
            {
                if (Request.Transaction != null)
                    tranSQL = Request.Transaction;

                PrepareCommand(cmdSQL, conSQL, tranSQL, Request);
                oReturn = cmdSQL.ExecuteScalar();
            }
            catch (SqlException)
            {
                if (conSQL.State == ConnectionState.Open)
                    conSQL.Close();
                throw;
            }
            finally
            {
                if (cmdSQL != null)
                {
                    cmdSQL.Parameters.Clear();
                }
                if ((Request.Transaction == null) && (conSQL.State == ConnectionState.Open))
                    conSQL.Close();
            }

            return oReturn;
        }

        /// <summary>
        /// Private function to retrive connection string from the Configuration settings
        /// </summary>
        /// <returns>String containing connection String</returns>
        private string GetConnectionString()
        {
            NandanaConnStrings oConnString = NandanaConnStrings.GetInstance();
            return oConnString.GetConnectionStringByDBType();
        }

        /// <summary>
        /// Prepare Command to be executed
        /// </summary>
        /// <param name="cmdSQL">SqlCommand instance</param>
        /// <param name="conSQL">SqlConnection instance. Transaction is handle internally</param>
        /// <param name="tranSQL">Transaction instance. </param>
        /// <param name="Request">NandanaDBRequest containing Requests</param>
        private void PrepareCommand(SqlCommand cmdSQL, SqlConnection conSQL, SqlTransaction tranSQL, NandanaDBRequest Request)
        {

            if (tranSQL != null)
            {
                conSQL = tranSQL.Connection;
                cmdSQL.Transaction = tranSQL;
            }
            else
            {
                conSQL.ConnectionString = GetConnectionString();
                conSQL.Open();
            }
            cmdSQL.Connection = conSQL;
            cmdSQL.CommandText = Request.Command;
            cmdSQL.CommandType = Request.CommandType;

            // add parameters if they exists.
            if ((Request.Parameters != null) && (Request.Parameters.Count > 0))
            {
                foreach (NandanaDBRequest.Parameter oParam in Request.Parameters)
                {
                    //if((oParam.ParamValue.GetType() == typeof(System.String))&& oParam.ParamValue.ToString().Length==0)
                    //	oParam.ParamValue  = DBNull.Value;
                    if (oParam.ParamValue == System.DBNull.Value)
                        oParam.ParamValue = DBNull.Value;
                    cmdSQL.Parameters.Add(oParam.ParamName, oParam.ParamValue);
                }
            }
        }
        /// <summary>
        /// Execute DataSet with query directly passed as parameter
        /// </summary>
        /// <param name="sSelectSQL">Select Query</param>
        /// <param name="colParameterList">Array of NandanaDBRequest.Parameter containing Name and value pair</param>
        /// <returns>DataSet Object</returns>
        public override NandanaDataSet ExecuteDataSet(string sSelectSQL, ArrayList colParameterList)
        {
            // implementation code here...
            SqlConnection conSQL = new SqlConnection();
            SqlCommand cmdSQL = new SqlCommand();
            SqlDataAdapter daSQL;
            NandanaSqlDataSet oDataSetSQL = new NandanaSqlDataSet();
            NandanaDBRequest oRequest = new NandanaDBRequest(sSelectSQL, CommandType.Text, null, colParameterList);
            try
            {
                PrepareCommand(cmdSQL, conSQL, null, oRequest);
                daSQL = new SqlDataAdapter(cmdSQL);
                daSQL.Fill(oDataSetSQL.ReturnedDataSet);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (cmdSQL != null)
                {
                    cmdSQL.Parameters.Clear();
                }
                if (conSQL.State == ConnectionState.Open)
                    conSQL.Close();
            }

            return oDataSetSQL;
        }
    }
}
