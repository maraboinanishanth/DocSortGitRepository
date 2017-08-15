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
    public class UserManager : DocSortBase 
    {
        public DocSortResult InserRoleValues(string Rolename, string Roledesc, Boolean Isactive)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@Rolename", Rolename));
            paramArray.Add(new DocSortDBRequest.Parameter("@Roledesc", Roledesc));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isactive", Isactive));
            

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertRoleValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertRoleValues sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertRoleValues sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult InsertUserValues(string Username, string password, string RoleId)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@Username", Username));
            paramArray.Add(new DocSortDBRequest.Parameter("@password", password));
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));


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

        public DocSortResult GetFormDetailsByMenuID(string MenuId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@MenuId", MenuId));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetFormDetailsByMenuID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetFormDetailsByMenuID sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFormDetailsByMenuID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetSubMenusByMenuID(string MenuId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@MenuId", MenuId));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetSubMenusByMenuID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetSubMenusByMenuID sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetSubMenusByMenuID sp.", m_oSession));
            }
            return result;

        }

        public DocSortResult GetMenuDetails(int RoleId, int UserId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleID", RoleId));
            paramArray.Add(new DocSortDBRequest.Parameter("@UserId", UserId));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetMenuItemsBasedonRoleanduser", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetMenuItemsBasedonRoleanduser sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMenuItemsBasedonRoleanduser sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFormClassNamebyformName(string FormName)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@FormName", FormName));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetFormClassNamebyformName", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetFormClassNamebyformName sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFormClassNamebyformName sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetRoles()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetRoles", CommandType.StoredProcedure, m_oTransaction, paramArray);//Issue fixed by Nishanth//Getting error onclick of last tab.Fixed.
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetRoles sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetRoles sp.", m_oSession));
            }
            return result;

        }

        public DocSortResult BindUsers()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_BindUsers", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from BindUsers sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from BindUsers sp.", m_oSession));
            }
            return result;

        }

        public DocSortResult GetUserDetailsByRoleID(string RoleId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetUsersBasedonRole", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUsersBasedonRole sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUsersBasedonRole sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetAllConfigParams()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetAllConfigParams", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetAllConfigParams sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllConfigParams sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetConfigParamUserPermissions(string RoleId, string UserId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));
            paramArray.Add(new DocSortDBRequest.Parameter("@UserId", UserId));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetUserConfigParamPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserConfigParamPermissions sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserConfigParamPermissions sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult InsertUpdateConfigParamUserAccessPermissions(string RoleID, string UserID, string ID, Boolean HasAccess)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleID", RoleID));
            paramArray.Add(new DocSortDBRequest.Parameter("@UserID", UserID));
            paramArray.Add(new DocSortDBRequest.Parameter("@ID", ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@HasAccess", HasAccess));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("InsertUpdateConfigParamUserAccessPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertUpdateConfigParamUserAccessPermissions sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertUpdateConfigParamUserAccessPermissions sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetAllForms()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetAllForms", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetAllForms sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllForms sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetUserPermissions(string RoleId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetUserPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserPermissions sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserPermissions sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetMainMenus()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetMainMenus", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetMainMenus sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllForms sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetMenuNamesByFormID(string FormID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FormId", FormID));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetMenuNamesByFormID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetMenuNamesByFormID sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMenuNamesByFormID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetMenuDetilsByMainMenuId(string MenuId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@MenuId", MenuId));


            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetMenuDetailsByMainMenuId", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetMenuDetilsByMainMenuId sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMenuDetilsByMainMenuId sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult InsertUpdateUserAccessPermissions(string RoleID, string ID, Boolean View)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleID));
            paramArray.Add(new DocSortDBRequest.Parameter("@FormId", ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isview", View));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertUpdateUserAccessPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUpdateUserAccessPermissions sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUpdateUserAccessPermissions sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
           
        }

        public DocSortResult GetUserDetailsByCredentials(string Name, string Password)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@UserName", Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@Pwd", Password));
            

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_Users", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserDetailsByCredentials sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserDetailsByCredentials  sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFormLevelControlPermissions(string RoleId, string UserId, string FormName)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@RoleId", RoleId));
            paramArray.Add(new DocSortDBRequest.Parameter("@UserId", UserId));
            paramArray.Add(new DocSortDBRequest.Parameter("@FormName", FormName));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("GetUserAccessControls", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserAccessControls sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserAccessControls sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult BindMonth()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_BindMonth", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from BindMonth sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from BindMonth sp.", m_oSession));
            }
            return result;
        }
    }
}
