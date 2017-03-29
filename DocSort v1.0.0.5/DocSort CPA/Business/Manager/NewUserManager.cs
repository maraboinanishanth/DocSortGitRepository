using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using DataAccess;
using Common;

namespace Business.Manager
{
     public class NewUserManager:NandanaBase
    {
         public NandanaResult InsertUserValues(string Firstname,string Lastname,string Middlename,string address,string city,string state,string country,string zip,string mobileno,string alternativemobileno,string Username, string password, string RoleId,Boolean status)
         {
             NandanaResult result;
             int iVal = -1;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new NandanaDBRequest.Parameter("@Firstname", Firstname));
             paramArray.Add(new NandanaDBRequest.Parameter("@Lastname", Lastname));
             paramArray.Add(new NandanaDBRequest.Parameter("@Middlename", Middlename));
             paramArray.Add(new NandanaDBRequest.Parameter("@address", address));
             paramArray.Add(new NandanaDBRequest.Parameter("@city", city));
             paramArray.Add(new NandanaDBRequest.Parameter("@state", state));
             paramArray.Add(new NandanaDBRequest.Parameter("@country", country));
             paramArray.Add(new NandanaDBRequest.Parameter("@zip", zip));
             paramArray.Add(new NandanaDBRequest.Parameter("@mobileno", mobileno));
             paramArray.Add(new NandanaDBRequest.Parameter("@alternativemobileno", alternativemobileno));
             paramArray.Add(new NandanaDBRequest.Parameter("@Username", Username));
             paramArray.Add(new NandanaDBRequest.Parameter("@password", password));
             paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));
             paramArray.Add(new NandanaDBRequest.Parameter("@Isstatus", status));

             try
             {
                 NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                 NandanaDBRequest request = new NandanaDBRequest("sp_InsertUserValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 iVal = factory.ExecuteNonQuery(request);
             }
             catch (Exception e)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUserValues sp.", m_oSession, e));
             }

             if (iVal < 0)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUserValues sp.", m_oSession));
             }
             else
             {
                 result = new NandanaResult(null);
             }
             return result;
         }

         public NandanaResult GetUsers()
         { 
             NandanaResult result;
             NandanaDataSet resultDS;
             ArrayList paramArray = new ArrayList();

             try
             {
                 NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                 NandanaDBRequest request = new NandanaDBRequest("sp_GetUsers", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 resultDS = factory.ExecuteDataSet(request);
             }
             catch (Exception e)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUsers sp.", m_oSession, e));
             }
             result = new NandanaResult();
             result.resultDS = resultDS.ReturnedDataSet;
             if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUsers sp.", m_oSession));
             }
             return result;
         }

         public NandanaResult CheckDuplicateUser(string Username)
         { 
             NandanaResult result;
             NandanaDataSet resultDS;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new NandanaDBRequest.Parameter("@Username", Username));

             try
             {
                 NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                 NandanaDBRequest request = new NandanaDBRequest("sp_CheckDuplicateUser", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 resultDS = factory.ExecuteDataSet(request);
             }
             catch (Exception e)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from CheckDuplicateUser sp.", m_oSession, e));
             }
             result = new NandanaResult();
             result.resultDS = resultDS.ReturnedDataSet;
             if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from CheckDuplicateUser sp.", m_oSession));
             }
             return result;
         }

         public NandanaResult GetUserDetailsUsingUserID(string UserId)
         {
             NandanaResult result;
             NandanaDataSet resultDS;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new NandanaDBRequest.Parameter("@UserId", UserId));

             try
             {
                 NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                 NandanaDBRequest request = new NandanaDBRequest("sp_GetUserDetailsUsingUserID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 resultDS = factory.ExecuteDataSet(request);
             }
             catch (Exception e)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserDetailsUsingUserID sp.", m_oSession, e));
             }
             result = new NandanaResult();
             result.resultDS = resultDS.ReturnedDataSet;
             if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserDetailsUsingUserID sp.", m_oSession));
             }
             return result;
         }

         public NandanaResult DeleteUserDetails(string UserId)
         {
             NandanaResult result;
             int iVal = -1;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new NandanaDBRequest.Parameter("@UserId", UserId));
            

             try
             {
                 NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                 NandanaDBRequest request = new NandanaDBRequest("sp_DeleteUserDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 iVal = factory.ExecuteNonQuery(request);
             }
             catch (Exception e)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into DeleteUserDetails sp.", m_oSession, e));
             }

             if (iVal < 0)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into DeleteUserDetails sp.", m_oSession));
             }
             else
             {
                 result = new NandanaResult(null);
             }
             return result;
         }

         public NandanaResult UpdateUserDetails(string UserId,string Firstname, string Lastname, string Middlename, string address, string city, string state,string country, string zip, string mobileno, string alternativemobileno, string Username, string password, string RoleId, Boolean status)
         {
             NandanaResult result;
             int iVal = -1;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new NandanaDBRequest.Parameter("@UserId", UserId));
             paramArray.Add(new NandanaDBRequest.Parameter("@Firstname", Firstname));
             paramArray.Add(new NandanaDBRequest.Parameter("@Lastname", Lastname));
             paramArray.Add(new NandanaDBRequest.Parameter("@Middlename", Middlename));
             paramArray.Add(new NandanaDBRequest.Parameter("@address", address));
             paramArray.Add(new NandanaDBRequest.Parameter("@city", city));
             paramArray.Add(new NandanaDBRequest.Parameter("@state", state));
             paramArray.Add(new NandanaDBRequest.Parameter("@country", country));
             paramArray.Add(new NandanaDBRequest.Parameter("@zip", zip));
             paramArray.Add(new NandanaDBRequest.Parameter("@mobileno", mobileno));
             paramArray.Add(new NandanaDBRequest.Parameter("@alternativemobileno", alternativemobileno));
             paramArray.Add(new NandanaDBRequest.Parameter("@Username", Username));
             paramArray.Add(new NandanaDBRequest.Parameter("@password", password));
             paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));
             paramArray.Add(new NandanaDBRequest.Parameter("@Isstatus", status));

             try
             {
                 NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                 NandanaDBRequest request = new NandanaDBRequest("sp_UpdateUserDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 iVal = factory.ExecuteNonQuery(request);
             }
             catch (Exception e)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into UpdateUserDetails sp.", m_oSession, e));
             }

             if (iVal < 0)
             {
                 return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into UpdateUserDetails sp.", m_oSession));
             }
             else
             {
                 result = new NandanaResult(null);
             }
             return result;
         }
    }
}
