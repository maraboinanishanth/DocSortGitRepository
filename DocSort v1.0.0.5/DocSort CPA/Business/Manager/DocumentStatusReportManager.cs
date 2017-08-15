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
    public class DocumentStatusReportManager:DocSortBase
    {
        public DocSortResult GetDocumentStatusReportUsingDate(string StartDate, string EndDate)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new DocSortDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetDocumentStatusReportUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetDocumentStatusReportUsingDate sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetDocumentStatusReportUsingDate sp.", m_oSession));
            }
            return result;
        }
    }
}
