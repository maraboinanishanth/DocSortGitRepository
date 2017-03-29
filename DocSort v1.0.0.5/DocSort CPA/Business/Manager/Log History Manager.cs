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
    public class Log_History_Manager:NandanaBase 
    {
        public NandanaResult InsertLogHistoryDetails(string LogDateTime, string LoggedInUser, string Description, string Type, string LogDate)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@logdatetme", LogDateTime));
            paramArray.Add(new NandanaDBRequest.Parameter("@loggeduser", LoggedInUser));
            paramArray.Add(new NandanaDBRequest.Parameter("@description", Description));
            paramArray.Add(new NandanaDBRequest.Parameter("@logintype", Type));
            paramArray.Add(new NandanaDBRequest.Parameter("@LogDate", LogDate));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertLogHistoryDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertLogHistoryDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertLogHistoryDetails sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }
      

        public NandanaResult GetLogHistoryDetails()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetLogHistoryDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetLogHistoryDetails sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetLogHistoryDetails sp.", m_oSession));
            }
            return result;
        }


        public NandanaResult GetLogHistoryDetailsGO(string LogDate)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@LogDate", LogDate));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetLogHistoryDetailsGO", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetLogHistoryDetailsGO sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetLogHistoryDetailsGO sp.", m_oSession));
            }
            return result;
        }
        
    }
}
