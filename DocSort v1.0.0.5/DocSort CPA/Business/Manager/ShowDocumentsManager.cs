using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Common;
using System.Collections;
using System.Data;

namespace Business.Manager
{
    public class ShowDocumentsManager:DocSortBase
    {
        public DocSortResult ShowScannedDocuments()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_ShowScannedDocuments", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from ShowScannedDocuments sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from ShowScannedDocuments sp.", m_oSession));
            }
            return result;
        }
    }
}
