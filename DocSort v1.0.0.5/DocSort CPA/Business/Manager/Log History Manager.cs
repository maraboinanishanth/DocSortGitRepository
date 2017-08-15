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
    public class Log_History_Manager:DocSortBase 
    {
        public DocSortResult InsertLogHistoryDetails(string LogDateTime, string LoggedInUser, string Description, string Type, string LogDate)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@logdatetme", LogDateTime));
            paramArray.Add(new DocSortDBRequest.Parameter("@loggeduser", LoggedInUser));
            paramArray.Add(new DocSortDBRequest.Parameter("@description", Description));
            paramArray.Add(new DocSortDBRequest.Parameter("@logintype", Type));
            paramArray.Add(new DocSortDBRequest.Parameter("@LogDate", LogDate));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertLogHistoryDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertLogHistoryDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertLogHistoryDetails sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }
      

        public DocSortResult GetLogHistoryDetails()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetLogHistoryDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetLogHistoryDetails sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetLogHistoryDetails sp.", m_oSession));
            }
            return result;
        }


        public DocSortResult GetLogHistoryDetailsGO(string LogDate)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@LogDate", LogDate));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetLogHistoryDetailsGO", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetLogHistoryDetailsGO sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetLogHistoryDetailsGO sp.", m_oSession));
            }
            return result;
        }
        
    }
}
