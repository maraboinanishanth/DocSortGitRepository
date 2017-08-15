using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    /// <summary>
    /// Derived DataReader class from that abstract DocSortDataReader
    /// and customized to manange SQL Server
    /// </summary>
    public class DocSortMySqlDataReader : DocSortDataReader
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
    public class DocSortMySqlDataSet : DocSortDataSet
    {
        /// <summary>
        /// Dataset object which will be returned
        /// </summary>
        DataSet m_oReturnedDataset;

        /// <summary>
        /// Constructor for SqlDataSet class
        /// This initialze the ReturnedDataSet
        /// </summary>		
        public DocSortMySqlDataSet()
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
    public class DocSortMySqlTransaction : DocSortTransaction
    {
        /// <summary>
        /// IDbTransaction object which holds return Transaction
        /// </summary>
        MySqlTransaction m_oReturnedTransaction;

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
                m_oReturnedTransaction = (MySqlTransaction)value;
            }
        }
    }

}
