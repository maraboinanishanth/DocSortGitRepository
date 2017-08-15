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
     public class NewUserManager:DocSortBase
    {
         public DocSortResult InsertUserValues(string Firstname,string Lastname,string Middlename,string address,string city,string state,string country,string zip,string mobileno,string alternativemobileno,string Username, string password, string RoleId,Boolean status)
         {
             DocSortResult result;
             int iVal = -1;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new DocSortDBRequest.Parameter("@Firstname", Firstname));
             paramArray.Add(new DocSortDBRequest.Parameter("@Lastname", Lastname));
             paramArray.Add(new DocSortDBRequest.Parameter("@Middlename", Middlename));
             paramArray.Add(new DocSortDBRequest.Parameter("@address", address));
             paramArray.Add(new DocSortDBRequest.Parameter("@city", city));
             paramArray.Add(new DocSortDBRequest.Parameter("@state", state));
             paramArray.Add(new DocSortDBRequest.Parameter("@country", country));
             paramArray.Add(new DocSortDBRequest.Parameter("@zip", zip));
             paramArray.Add(new DocSortDBRequest.Parameter("@mobileno", mobileno));
             paramArray.Add(new DocSortDBRequest.Parameter("@alternativemobileno", alternativemobileno));
             paramArray.Add(new DocSortDBRequest.Parameter("@Username", Username));
             paramArray.Add(new DocSortDBRequest.Parameter("@password", password));
             paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));
             paramArray.Add(new DocSortDBRequest.Parameter("@Isstatus", status));

             try
             {
                 DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                 DocSortDBRequest request = new DocSortDBRequest("sp_InsertUserValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 iVal = factory.ExecuteNonQuery(request);
             }
             catch (Exception e)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUserValues sp.", m_oSession, e));
             }

             if (iVal < 0)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUserValues sp.", m_oSession));
             }
             else
             {
                 result = new DocSortResult(null);
             }
             return result;
         }

         public DocSortResult GetUsers()
         { 
             DocSortResult result;
             DocSortDataSet resultDS;
             ArrayList paramArray = new ArrayList();

             try
             {
                 DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                 DocSortDBRequest request = new DocSortDBRequest("sp_GetUsers", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 resultDS = factory.ExecuteDataSet(request);
             }
             catch (Exception e)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUsers sp.", m_oSession, e));
             }
             result = new DocSortResult();
             result.resultDS = resultDS.ReturnedDataSet;
             if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUsers sp.", m_oSession));
             }
             return result;
         }

         public DocSortResult CheckDuplicateUser(string Username)
         { 
             DocSortResult result;
             DocSortDataSet resultDS;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new DocSortDBRequest.Parameter("@Username", Username));

             try
             {
                 DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                 DocSortDBRequest request = new DocSortDBRequest("sp_CheckDuplicateUser", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 resultDS = factory.ExecuteDataSet(request);
             }
             catch (Exception e)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from CheckDuplicateUser sp.", m_oSession, e));
             }
             result = new DocSortResult();
             result.resultDS = resultDS.ReturnedDataSet;
             if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from CheckDuplicateUser sp.", m_oSession));
             }
             return result;
         }

         public DocSortResult GetUserDetailsUsingUserID(string UserId)
         {
             DocSortResult result;
             DocSortDataSet resultDS;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new DocSortDBRequest.Parameter("@UserId", UserId));

             try
             {
                 DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                 DocSortDBRequest request = new DocSortDBRequest("sp_GetUserDetailsUsingUserID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 resultDS = factory.ExecuteDataSet(request);
             }
             catch (Exception e)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserDetailsUsingUserID sp.", m_oSession, e));
             }
             result = new DocSortResult();
             result.resultDS = resultDS.ReturnedDataSet;
             if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserDetailsUsingUserID sp.", m_oSession));
             }
             return result;
         }

         public DocSortResult DeleteUserDetails(string UserId)
         {
             DocSortResult result;
             int iVal = -1;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new DocSortDBRequest.Parameter("@UserId", UserId));
            

             try
             {
                 DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                 DocSortDBRequest request = new DocSortDBRequest("sp_DeleteUserDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 iVal = factory.ExecuteNonQuery(request);
             }
             catch (Exception e)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into DeleteUserDetails sp.", m_oSession, e));
             }

             if (iVal < 0)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into DeleteUserDetails sp.", m_oSession));
             }
             else
             {
                 result = new DocSortResult(null);
             }
             return result;
         }

         public DocSortResult UpdateUserDetails(string UserId,string Firstname, string Lastname, string Middlename, string address, string city, string state,string country, string zip, string mobileno, string alternativemobileno, string Username, string password, string RoleId, Boolean status)
         {
             DocSortResult result;
             int iVal = -1;
             ArrayList paramArray = new ArrayList();

             paramArray.Add(new DocSortDBRequest.Parameter("@UserId", UserId));
             paramArray.Add(new DocSortDBRequest.Parameter("@Firstname", Firstname));
             paramArray.Add(new DocSortDBRequest.Parameter("@Lastname", Lastname));
             paramArray.Add(new DocSortDBRequest.Parameter("@Middlename", Middlename));
             paramArray.Add(new DocSortDBRequest.Parameter("@address", address));
             paramArray.Add(new DocSortDBRequest.Parameter("@city", city));
             paramArray.Add(new DocSortDBRequest.Parameter("@state", state));
             paramArray.Add(new DocSortDBRequest.Parameter("@country", country));
             paramArray.Add(new DocSortDBRequest.Parameter("@zip", zip));
             paramArray.Add(new DocSortDBRequest.Parameter("@mobileno", mobileno));
             paramArray.Add(new DocSortDBRequest.Parameter("@alternativemobileno", alternativemobileno));
             paramArray.Add(new DocSortDBRequest.Parameter("@Username", Username));
             paramArray.Add(new DocSortDBRequest.Parameter("@password", password));
             paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));
             paramArray.Add(new DocSortDBRequest.Parameter("@Isstatus", status));

             try
             {
                 DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                 DocSortDBRequest request = new DocSortDBRequest("sp_UpdateUserDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                 iVal = factory.ExecuteNonQuery(request);
             }
             catch (Exception e)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into UpdateUserDetails sp.", m_oSession, e));
             }

             if (iVal < 0)
             {
                 return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into UpdateUserDetails sp.", m_oSession));
             }
             else
             {
                 result = new DocSortResult(null);
             }
             return result;
         }
    }
}
