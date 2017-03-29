    using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DataAccess
{
    public class NandanaMySqlDBRequest
    {
		private CommandType m_lCommandType;
		private string m_sCommand;
		private ArrayList m_colParameters;
		private MySqlTransaction m_oTransaction;
		
		/// <summary>Default Constructor</summary>
		public NandanaMySqlDBRequest()
		{
		}

		/// <summary>
		/// Overloaded constructor with Command text and Command Type only
		/// </summary>
		/// <param name="sCommand">Command Text</param>
		/// <param name="lCommandType">Command Type</param>
		public NandanaMySqlDBRequest(string sCommand,CommandType lCommandType)
		{
			m_sCommand = sCommand;
			m_lCommandType = lCommandType;
		}
		/// <summary>
		/// Overloaded Constructor with Command,CommandType and parameter list
		/// </summary>
		/// <param name="sCommand">Command Text</param>
		/// <param name="lCommandType">Command Type</param>
		/// <param name="colParamList">Parameter List</param>
		public NandanaMySqlDBRequest(string sCommand,CommandType lCommandType,ArrayList colParamList)
		{
			m_sCommand = sCommand;
			m_lCommandType = lCommandType;
			m_colParameters = colParamList;
		}
		/// <summary>
		/// Overloaded constructor with all the parameters
		/// </summary>
		/// <param name="sCommand">Command Text</param>
		/// <param name="lCommandType">Command Type</param>
		/// <param name="oTransaction">Transaction Object</param>
		/// <param name="colParamList">Array of Parameter List</param>
        public NandanaMySqlDBRequest(string sCommand, CommandType lCommandType, MySqlTransaction oTransaction, ArrayList colParamList)
		{
			SetRequest(sCommand,lCommandType,oTransaction,colParamList);
		}
		
		/// <summary>
		/// Set Request parameters
		/// </summary>
		/// <param name="sCommand">Command Text</param>
		/// <param name="lCommandType">Command Type</param>
		/// <param name="oTransaction">Transaction Object</param>
		/// <param name="colParamList">Array of Parameter List</param>
		public void SetRequest(string sCommand,CommandType lCommandType,MySqlTransaction oTransaction,ArrayList colParamList)
		{
			m_sCommand = sCommand;
			m_lCommandType = lCommandType;
			m_oTransaction = oTransaction;
			m_colParameters = colParamList;
		}
		
		/// <summary> CommandType Property</summary>
		public CommandType CommandType
		{
			get
			{
				return m_lCommandType;
			}
			set 
			{
				m_lCommandType = value;
			}
		}
		
		/// <summary> Command Property</summary>
		public string Command
		{
			get
			{
				return m_sCommand;
			}
			set
			{
				m_sCommand = value;
			}
		}
		/// <summary> Parameters Property</summary>
		public ArrayList Parameters
		{
			get 
			{
				return m_colParameters;
			}
			set 
			{
				m_colParameters = value;
			}
		}
		/// <summary> Exception Property</summary>
		public MySqlTransaction Transaction
		{
			get
			{
				return m_oTransaction;
			}
			set 
			{
				m_oTransaction = value;
			}
		}
		/// <summary>
		/// Helper class for parameter
		/// </summary>
		public class Parameter
		{
			private string m_sParamName;
			private object m_oParamValue;

			/// <summary>
			/// Parameter Name property
			/// </summary>
			public string ParamName
			{
				get
				{
					return m_sParamName;
				}
				set
				{
					m_sParamName = value;
				}
			}

			/// <summary>
			/// Parameter Value Property
			/// </summary>
			public object ParamValue
			{
				get
				{ 
					return m_oParamValue;
				}
				set 
				{
					m_oParamValue = value;
				}
			}

			/// <summary>
			/// Default Constructor
			/// </summary>
			public Parameter()
			{
			}
			/// <summary>
			/// Overloaded Constructor
			/// </summary>
			/// <param name="Name">Parameter Name</param>
			/// <param name="Value">Parameter VAlue</param>
			public Parameter(string Name,object Value)
			{
				m_sParamName = Name;
				m_oParamValue = Value;
			}
		}
	}
}