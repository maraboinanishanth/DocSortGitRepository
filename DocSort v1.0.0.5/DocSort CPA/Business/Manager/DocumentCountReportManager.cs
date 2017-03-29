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
    public class DocumentCountReportManager:NandanaBase
    {
        public NandanaResult GetDocumentCountReportUsingDate(string StartDate, string EndDate)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new NandanaDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetDocumentCountReportUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetDocumentCountReportUsingDate sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetDocumentCountReportUsingDate sp.", m_oSession));
            }
            return result;
        }
    }
}
