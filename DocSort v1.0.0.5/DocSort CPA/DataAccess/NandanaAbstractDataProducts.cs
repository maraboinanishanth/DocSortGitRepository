using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
    /// <summary>
    /// Abstract Base Class for Data reader
    /// </summary>
    public abstract class NandanaDataReader
    {
        /// <summary>
        /// Abstract property for Return DataReader 
        /// </summary>
        public abstract IDataReader ReturnedDataReader
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Abstract base class for DataSet
    /// </summary>
    public abstract class NandanaDataSet
    {
        /// <summary>
        /// abstract Property for Returned Dataset 
        /// </summary>
        public abstract DataSet ReturnedDataSet
        {
            get;

            set;
        }
    }

    /// <summary>
    /// Abstract class for Transaction
    /// </summary>
    public abstract class NandanaTransaction
    {
        /// <summary>
        /// Returned Transaction
        /// </summary>
        public abstract IDbTransaction ReturnedTransaction
        {
            get;
            set;
        }
    }
}
