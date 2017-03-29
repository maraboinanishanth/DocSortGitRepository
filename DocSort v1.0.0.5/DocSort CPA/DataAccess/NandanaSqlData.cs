using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    /// <summary>
    /// Derived DataReader class from that abstract NandanaDataReader
    /// and customized to manange SQL Server
    /// </summary>
    public class NandanaSqlDataReader : NandanaDataReader
    {
        /// <summary>
        /// IDataReader object which holds return DataReader
        /// </summary>
        IDataReader m_oReturnedDataReader;

        /// <summary>
        /// ReturnedDataReader property overridden.
        /// </summary>		
        public override IDataReader ReturnedDataReader
        {
            get
            {
                return m_oReturnedDataReader;
            }
            set
            {
                m_oReturnedDataReader = value;
            }
        }
    }

    /// <summary>
    /// Derived SQL class for Dataset
    /// </summary>
    public class NandanaSqlDataSet : NandanaDataSet
    {
        /// <summary>
        /// Dataset object which will be returned
        /// </summary>
        DataSet m_oReturnedDataset;

        /// <summary>
        /// Constructor for SqlDataSet class
        /// This initialze the ReturnedDataSet
        /// </summary>		
        public NandanaSqlDataSet()
        {
            m_oReturnedDataset = new DataSet();
        }

        /// <summary>
        /// Override DataSet return property
        /// </summary>
        public override DataSet ReturnedDataSet
        {
            get
            {
                return m_oReturnedDataset;
            }
            set
            {
                m_oReturnedDataset = value;
            }
        }
    }
    /// <summary>
    /// Derived SQL class for Transaction
    /// </summary>
    public class NandanaSqlTransaction : NandanaTransaction
    {
        /// <summary>
        /// IDbTransaction object which holds return Transaction
        /// </summary>
        SqlTransaction m_oReturnedTransaction;

        /// <summary>
        /// ReturnedTransaction 
        /// </summary>
        public override IDbTransaction ReturnedTransaction
        {
            get
            {
                return m_oReturnedTransaction;
            }

            set
            {
                m_oReturnedTransaction = (SqlTransaction)value;
            }
        }
    }

}
