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
    public class DocumentReportManager:DocSortBase
    {
        public DocSortResult GetNumberOfDocumentCountDetailsUsingDate(string StartDate, string EndDate)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            DocSortDataReader resultDR;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new DocSortDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetNumberOfDocumentCountDetailsUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
                resultDR = factory.ExecuteDataReader(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetNumberOfDocumentCountDetailsUsingDate sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            result.resultDR = resultDR.ReturnedDataReader;
            if (!(result.resultDR != null && result.resultDR.FieldCount > 0 && result.resultDR.FieldCount > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetNumberOfDocumentCountDetailsUsingDate sp.", m_oSession));
            }
            

            return result;
        }

        public DocSortResult GetNumberOfMatchedDocumentCountUsingDate(string StartDate, string EndDate)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new DocSortDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetNumberOfMatchedDocumentCountUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetNumberOfMatchedDocumentCountUsingDate sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetNumberOfMatchedDocumentCountUsingDate sp.", m_oSession));
            }
            return result;
        }
    }
}
