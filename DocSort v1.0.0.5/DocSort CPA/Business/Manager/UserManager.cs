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
    public class UserManager : NandanaBase 
    {
        public NandanaResult InserRoleValues(string Rolename, string Roledesc, Boolean Isactive)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@Rolename", Rolename));
            paramArray.Add(new NandanaDBRequest.Parameter("@Roledesc", Roledesc));
            paramArray.Add(new NandanaDBRequest.Parameter("@Isactive", Isactive));
            

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertRoleValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertRoleValues sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertRoleValues sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult InsertUserValues(string Username, string password, string RoleId)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@Username", Username));
            paramArray.Add(new NandanaDBRequest.Parameter("@password", password));
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));


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

        public NandanaResult GetFormDetailsByMenuID(string MenuId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@MenuId", MenuId));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetFormDetailsByMenuID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetFormDetailsByMenuID sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFormDetailsByMenuID sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetSubMenusByMenuID(string MenuId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@MenuId", MenuId));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetSubMenusByMenuID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetSubMenusByMenuID sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetSubMenusByMenuID sp.", m_oSession));
            }
            return result;

        }

        public NandanaResult GetMenuDetails(int RoleId, int UserId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleID", RoleId));
            paramArray.Add(new NandanaDBRequest.Parameter("@UserId", UserId));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetMenuItemsBasedonRoleanduser", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetMenuItemsBasedonRoleanduser sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMenuItemsBasedonRoleanduser sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetFormClassNamebyformName(string FormName)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@FormName", FormName));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetFormClassNamebyformName", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetFormClassNamebyformName sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFormClassNamebyformName sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetRoles()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetRoles", CommandType.Text, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetRoles sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetRoles sp.", m_oSession));
            }
            return result;

        }

        public NandanaResult BindUsers()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_BindUsers", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from BindUsers sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from BindUsers sp.", m_oSession));
            }
            return result;

        }

        public NandanaResult GetUserDetailsByRoleID(string RoleId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetUsersBasedonRole", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUsersBasedonRole sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUsersBasedonRole sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetAllConfigParams()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetAllConfigParams", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetAllConfigParams sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllConfigParams sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetConfigParamUserPermissions(string RoleId, string UserId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));
            paramArray.Add(new NandanaDBRequest.Parameter("@UserId", UserId));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetUserConfigParamPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserConfigParamPermissions sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserConfigParamPermissions sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult InsertUpdateConfigParamUserAccessPermissions(string RoleID, string UserID, string ID, Boolean HasAccess)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleID", RoleID));
            paramArray.Add(new NandanaDBRequest.Parameter("@UserID", UserID));
            paramArray.Add(new NandanaDBRequest.Parameter("@ID", ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@HasAccess", HasAccess));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("InsertUpdateConfigParamUserAccessPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertUpdateConfigParamUserAccessPermissions sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertUpdateConfigParamUserAccessPermissions sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetAllForms()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetAllForms", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetAllForms sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllForms sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetUserPermissions(string RoleId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetUserPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserPermissions sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserPermissions sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetMainMenus()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetMainMenus", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetMainMenus sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllForms sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetMenuNamesByFormID(string FormID)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FormId", FormID));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetMenuNamesByFormID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetMenuNamesByFormID sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMenuNamesByFormID sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetMenuDetilsByMainMenuId(string MenuId)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@MenuId", MenuId));


            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetMenuDetailsByMainMenuId", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetMenuDetilsByMainMenuId sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMenuDetilsByMainMenuId sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult InsertUpdateUserAccessPermissions(string RoleID, string ID, Boolean View)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleID));
            paramArray.Add(new NandanaDBRequest.Parameter("@FormId", ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Isview", View));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertUpdateUserAccessPermissions", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUpdateUserAccessPermissions sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertUpdateUserAccessPermissions sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
           
        }

        public NandanaResult GetUserDetailsByCredentials(string Name, string Password)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@UserName", Name));
            paramArray.Add(new NandanaDBRequest.Parameter("@Pwd", Password));
            

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_Users", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserDetailsByCredentials sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserDetailsByCredentials  sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetFormLevelControlPermissions(string RoleId, string UserId, string FormName)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@RoleId", RoleId));
            paramArray.Add(new NandanaDBRequest.Parameter("@UserId", UserId));
            paramArray.Add(new NandanaDBRequest.Parameter("@FormName", FormName));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("GetUserAccessControls", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetUserAccessControls sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetUserAccessControls sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult BindMonth()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_BindMonth", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from BindMonth sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from BindMonth sp.", m_oSession));
            }
            return result;
        }
    }
}
