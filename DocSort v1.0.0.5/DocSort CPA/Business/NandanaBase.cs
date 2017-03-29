 using System;
using Common;
using DataAccess;
using MySql.Data.MySqlClient;

namespace Business
{
   
	/// <summary>
	/// This is the base class for all Nandana classes.
	/// It manages the session that can be use through out the system
	/// The session object contains the active user information.
	/// </summary>
	public class NandanaBase
	{
		/// <summary>
		/// The session object that is used as a common resource 
		/// containing active user information.
		/// </summary>
		public NandanaSession m_oSession;

		/// <summary>
		///  NandanaTransaction object to maintain transaction between multiple sql statements
		/// </summary>
		public MySqlTransaction m_oTransaction;

		/// <summary>Abstract Factory Class for Database Connection</summary>
		protected NandanaAbstractFactory m_oDBFactory;
		/// <summary>
		/// Default constuctor with no arguments.
		/// </summary>
		public NandanaBase()
		{
			m_oSession = null;
			m_oTransaction = null;
			m_oDBFactory = NandanaDBInstance.GetDBFactory();

		}

		/// <summary>
		/// Constuctor with NandanaSession as argument.
		/// </summary>
		public NandanaBase(NandanaSession sess)
		{
			m_oSession = sess;
			m_oTransaction = null;
			m_oDBFactory = NandanaDBInstance.GetDBFactory();
		}
		
		/// <summary>
		/// Constuctor with NandanaSession and NandanaTransaction as argument.
		/// </summary>
		public NandanaBase(NandanaSession sess,MySqlTransaction Trans)
		{
			m_oSession = sess;
			m_oDBFactory = NandanaDBInstance.GetDBFactory();
			m_oTransaction = Trans;
		}
		/// <summary>
		///	Validates a value to be not null and returns the status 
		/// </summary>
		/// <param name="val">Value to be checked</param>
		/// <param name="errType">Error type to be used for result object initialization</param>
		/// <param name="errMessage">Error message to be embedded</param>
		/// <returns>Result object with status</returns>
		protected NandanaResult CheckNotNull(string val, NandanaError.ErrorType errType, string errMessage)
		{
			return (NandanaResult.CheckCondition( (null != val) && (0 != val.Length),			
				errType, errMessage, m_oSession));
			
		}

		/// <summary>
		/// If transaction is not yet started, then start transaction and return 
		/// </summary>
		/// <returns>Opened Transaction</returns>
		public MySqlTransaction BeginTransaction()
		{
			if(m_oTransaction==null)
			{
				if(m_oDBFactory==null)
					m_oDBFactory = NandanaDBInstance.GetDBFactory();
                m_oTransaction = m_oDBFactory.GetTransaction();
			}
			return m_oTransaction;
		}

		/// <summary>
		/// Rollback current Transaction
		/// </summary>
		public void RollbackTransaction()
		{
			if(m_oTransaction !=null)
			{
				
				m_oTransaction.Rollback();
				m_oTransaction = null;

				
			}
		}
		/// <summary>
		/// Commit current Transaction
		/// </summary>
		public void CommitTransaction()
		{
			if(m_oTransaction !=null)
			{
				m_oTransaction.Commit();
				m_oTransaction = null;
			}
		}
		/// <summary>
		/// GetTransType
		/// </summary>
		/// <param name="opMode"></param>
		/// <returns></returns>
		public byte GetTransType(FuseMode opMode)
		{
			byte transType;

			if(opMode == FuseMode.ADD)
				transType = 0;
			else
				transType = 1;

			return transType;
		}

	}
}
