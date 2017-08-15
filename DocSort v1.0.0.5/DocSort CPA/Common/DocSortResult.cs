  using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Xml;


namespace Common
{

	/// <summary>
	/// Summary description for DocSortSession.
	/// </summary>
	public class DocSortResult
	{
		/// <summary> Status of result</summary>
		public StatusType status;
		/// <summary> Error Code </summary>
		public DocSortError.ErrorType errorCode;
		/// <summary> Error Descripiton </summary>
		public string errorDescr; 
		/// <summary> Error Descripiton </summary>
		public Exception errorException;
		/// <summary> Data Set for returning the values to the Caller method </summary>
		public DataSet resultDS;
		/// <summary> Generic variable, where in any other datatype can be fitted, 
		/// if required to be retured back 
		/// </summary>
		public Object resultObj;
		/// <summary>OFISession object containing valid User data for Error returning purpose</summary>
		public DocSortSession session;

        public IDataReader resultDR;

		#region "Enums"
		/// <summary>
		/// Status Type System defined datatype for maintaining standards
		/// </summary>
		public enum StatusType
		{
			/// <summary> Operation successful </summary>
			SUCCESS = 0,

			/// <summary> Operation has some Error, Check Error details for further information. </summary>
			ERROR = 1
		}

		#endregion

		/// <summary>
		/// Default Constructor without any arguments
		/// </summary>
		public DocSortResult()
		{
			// default set the Result to SUCCESS
			status = StatusType.SUCCESS;
			errorException = null;
			resultDS = null;
			resultObj = null;
			session = null;
		}
		/// <summary>
		///	Overloaded Constructor with session object as argument
		/// </summary>
		/// <param name="sess">OFISession Object</param>
		public DocSortResult(DocSortSession sess)
		{
			// default set the Result to SUCCESS
			status = StatusType.SUCCESS;
			errorException = null;
			resultDS = null;
			resultObj = null;
			session = sess;
		}

		/// <summary>
		///	Overloaded Constructor with two arguments for setting up the result dataset and Sesion 
		/// </summary>
		/// <param name="ds">DataSet Object</param>
		/// <param name="sess">OFISession Object</param>
		public DocSortResult(DataSet ds,DocSortSession sess)
		{
			// default set the Result to SUCCESS
			status = StatusType.SUCCESS;
			// Also set the dataset
			resultDS = ds;
			resultObj = null;
			session = sess;
		}

		/// <summary>
		///	Overloaded Constructor with two arguments for setting up Error code and session
		/// </summary>
		/// <param name="errCode">ErrorCode</param>
		/// <param name="sess">OFISession Object</param>
		public DocSortResult(DocSortError.ErrorType errCode, DocSortSession sess)
		{
			status = StatusType.ERROR;
			errorCode = errCode;
			resultDS = null;
			resultObj = null;
			session = sess; 
			DocSortError.PostError(this);
		}
		/// <summary>
		///	Overloaded Constructor with three arguments for setting up Error code, Error Desc and session
		/// </summary>
		/// <param name="errCode">ErrorCode</param>
		/// <param name="errDesc">Error Description Object</param>
		/// <param name="sess">OFISession Object</param>
		public DocSortResult(DocSortError.ErrorType errCode, string errDesc, DocSortSession sess)
		{
			status = StatusType.ERROR;
			errorCode = errCode;
			resultDS = null;
			resultObj = null;
			session = sess; 
			// append the description to the existing one
			errorDescr += (null != errorDescr && 0 < errorDescr.Length && null != errDesc && 0 < errDesc.Length ? " : ":"") + errDesc;
			DocSortError.PostError(this);
		}
		/// <summary>
		///	Overloaded Constructor with four arguments for setting up Error code, Error Desc, session and exception
		/// </summary>
		/// <param name="errCode">ErrorCode</param>
		/// <param name="errDesc">Error Description Object</param>
		/// <param name="sess">OFISession Object</param>
		/// <param name="exp">Exception Object</param>
		public DocSortResult(DocSortError.ErrorType errCode, string errDesc, DocSortSession sess, Exception exp)
		{
			status = StatusType.ERROR;
			errorCode = errCode;
			errorException = exp;
			resultDS = null;
			resultObj = null;
			session = sess;
			// append the description to the existing one, set by IBCError object
			errorDescr += (null != errorDescr && 0 < errorDescr.Length && null != errDesc && 0 < errDesc.Length ? " : ":"") + errDesc;
			if(null != exp)
			{
#if (DEBUG)
				errorDescr += (null != errorDescr && 0 < errorDescr.Length ? " : ":"") + exp.ToString();
#else
				errorDescr += (null != errorDescr && 0 < errorDescr.Length ? " : ":"") + exp.Message;
#endif
			}
			DocSortError.PostError(this);
		}

		/// <summary>
		///	Check Condition function to validate a condition and fire the error.
		/// </summary>
		public static DocSortResult CheckCondition(bool condition, DocSortError.ErrorType errCode, string errDesc, DocSortSession sess)
		{
			if (!condition )
			{
				if ( (null == errDesc) || (0 == errDesc.Length) )
					return (new DocSortResult(errCode,sess));
				else
					return (new DocSortResult(errCode, errDesc,sess, null));
			}
			else
				return (new DocSortResult());
		}

		/// <summary>
		///		Generates the Error Description based on OFI Error object
		/// </summary>
		/// <returns>Error Message string</returns>
		public string GetErrorMessage()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Error Code: " + errorCode.ToString() + "\n");
			sb.Append("Description: " + errorDescr + "\n");
			string errSource = "", expText = "";
			if (null != errorException)
			{
				errSource +=  "Class: " 
					+ new StackTrace().GetFrame(2).GetMethod().ReflectedType.FullName
					+ " Method: " 
					+ new StackTrace().GetFrame(2).GetMethod().ToString();
			}
			sb.Append("Source: " + errSource + "\n");
			sb.Append("Exception Text: " + expText + "\n");
			return sb.ToString();
		}

		/// <summary>
		///	Validates if the Result has Error or not
		/// </summary>
		/// <returns>true, if Result has Error, false otherwise.</returns>
		public bool HasError
		{
			// Return the status validator
			get
			{
				return (StatusType.ERROR == status); 
			}
			
		}

		/// <summary>
		/// Returns true if there is data available
		/// </summary>
		/// <remarks>True if data returned else false</remarks>
		public bool HasData
		{
			get
			{
				if(HasError)
					return false;
				else if ( (null != resultDS) && (null != resultDS.Tables[0]) && (0 < resultDS.Tables[0].Rows.Count))
					return true;

				return false;
			}
		}

		/// <summary>
		/// The Table [0] available in the data set returned
		/// </summary>
		public DataTable ResultTable
		{
			get
			{
				if ( (null != resultDS) && (null != resultDS.Tables[0]) && (0 < resultDS.Tables[0].Rows.Count))
					return resultDS.Tables[0];
				return null;
			}
		}

		/// <summary>
		/// The First DataRow Of First Table
		/// </summary>
		public DataRow ResultRow
		{
			get
			{
				if(null != ResultTable)
					return ResultTable.Rows[0];
				return null;
			}
		}
	}
}
