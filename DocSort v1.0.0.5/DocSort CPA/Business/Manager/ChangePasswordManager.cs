using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess;
using System.Data;
using Common;
using System.Collections; 

namespace Business.Manager
{
    public class ChangePasswordManager : NandanaBase 
    { 
        public NandanaResult UpdateAdminPassword(string UserName, string Password)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@UserName", UserName));
            paramArray.Add(new NandanaDBRequest.Parameter("@Pwd", Password));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_UpdateAdminPassword", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data from UpdateAdminPassword sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateAdminPassword  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult AdminChangePassword(string UserName, string Password)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@UserName", UserName));
            paramArray.Add(new NandanaDBRequest.Parameter("@Pwd", Password));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_AdminChangePassword", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from AdminChangePassword sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from AdminChangePassword sp.", m_oSession));
            }
            return result;
        }
    }
}
