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
    public class MoveMyFilesManager:DocSortBase
    {
        public DocSortResult GetKeywordDetails()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
           

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetKeywordDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetKeywordDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetKeywordDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult InsertKeywordDetails(string Keyword, string SubSection, string StartWith, string EndWith)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            
            paramArray.Add(new DocSortDBRequest.Parameter("@keyword", Keyword));
            paramArray.Add(new DocSortDBRequest.Parameter("@subsection", SubSection));
            paramArray.Add(new DocSortDBRequest.Parameter("@startwith", StartWith));
            paramArray.Add(new DocSortDBRequest.Parameter("@endwith", EndWith));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertKeywordDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertKeywordDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertKeywordDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetDocumentsListDetails(string Date, string File_Name)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@Date", Date));
            //paramArray.Add(new DocSortDBRequest.Parameter("@Keyword_ID", Keyword_ID));
            //paramArray.Add(new DocSortDBRequest.Parameter("@Category_ID", Category_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@File_Name", File_Name));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetDocumentsListDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetDocumentsListDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetDocumentsListDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult InsertDocumentlistDetails(string Date, string File_Name, string ProcessType)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@date", Date));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filename", File_Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@Processtype", ProcessType));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertDocumentlistDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertDocumentlistDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertDocumentlistDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetScannedDocumentResultDetails(string Date, string Keyword_ID, string Document_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@Date", Date));
            //paramArray.Add(new DocSortDBRequest.Parameter("@Category_ID", Category_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Keyword_ID", Keyword_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Document_ID", Document_ID));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetScannedDocumentResultDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetScannedDocumentResultDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetScannedDocumentResultDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult InsertScannedDocumentResults(string Date, string Keyword_ID, string Document_ID, string Document_Path, string Match)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@date", Date));
            paramArray.Add(new DocSortDBRequest.Parameter("@KeywordId", Keyword_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@DocumentId", Document_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@DocumentPath", Document_Path));
            paramArray.Add(new DocSortDBRequest.Parameter("@matchstatus", Match));
            
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertScannedDocumentResults", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertScannedDocumentResults sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertScannedDocumentResults sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }


        public DocSortResult GetTotalScannedDocumentCountResultsUsingDate(string StartDate, string EndDate)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new DocSortDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetTotalScannedDocumentCountResultsUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetTotalScannedDocumentCountResultsUsingDate sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetTotalScannedDocumentCountResultsUsingDate sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetDocumentCountDetailsUsingDate(string StartDate, string EndDate)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new DocSortDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new DocSortDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetDocumentCountDetailsUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetDocumentCountDetailsUsingDate sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetDocumentCountDetailsUsingDate sp.", m_oSession));
            }
            return result;
        }
    }
}
