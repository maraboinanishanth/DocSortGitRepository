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
    public class MoveMyFilesManager:NandanaBase
    {
        public NandanaResult GetKeywordDetails()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
           

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetKeywordDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetKeywordDetails sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetKeywordDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult InsertKeywordDetails(string Keyword, string SubSection, string StartWith, string EndWith)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            
            paramArray.Add(new NandanaDBRequest.Parameter("@keyword", Keyword));
            paramArray.Add(new NandanaDBRequest.Parameter("@subsection", SubSection));
            paramArray.Add(new NandanaDBRequest.Parameter("@startwith", StartWith));
            paramArray.Add(new NandanaDBRequest.Parameter("@endwith", EndWith));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertKeywordDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertKeywordDetails sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertKeywordDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetDocumentsListDetails(string Date, string File_Name)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@Date", Date));
            //paramArray.Add(new NandanaDBRequest.Parameter("@Keyword_ID", Keyword_ID));
            //paramArray.Add(new NandanaDBRequest.Parameter("@Category_ID", Category_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@File_Name", File_Name));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetDocumentsListDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetDocumentsListDetails sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetDocumentsListDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult InsertDocumentlistDetails(string Date, string File_Name, string ProcessType)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@date", Date));
            paramArray.Add(new NandanaDBRequest.Parameter("@Filename", File_Name));
            paramArray.Add(new NandanaDBRequest.Parameter("@Processtype", ProcessType));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertDocumentlistDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertDocumentlistDetails sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertDocumentlistDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetScannedDocumentResultDetails(string Date, string Keyword_ID, string Document_ID)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@Date", Date));
            //paramArray.Add(new NandanaDBRequest.Parameter("@Category_ID", Category_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Keyword_ID", Keyword_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Document_ID", Document_ID));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetScannedDocumentResultDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetScannedDocumentResultDetails sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetScannedDocumentResultDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult InsertScannedDocumentResults(string Date, string Keyword_ID, string Document_ID, string Document_Path, string Match)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@date", Date));
            paramArray.Add(new NandanaDBRequest.Parameter("@KeywordId", Keyword_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@DocumentId", Document_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@DocumentPath", Document_Path));
            paramArray.Add(new NandanaDBRequest.Parameter("@matchstatus", Match));
            
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertScannedDocumentResults", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertScannedDocumentResults sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_INSERTING_RECORD, "Error While inserting data into InsertScannedDocumentResults sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }


        public NandanaResult GetTotalScannedDocumentCountResultsUsingDate(string StartDate, string EndDate)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new NandanaDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetTotalScannedDocumentCountResultsUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetTotalScannedDocumentCountResultsUsingDate sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetTotalScannedDocumentCountResultsUsingDate sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetDocumentCountDetailsUsingDate(string StartDate, string EndDate)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            paramArray.Add(new NandanaDBRequest.Parameter("@StartDate", StartDate));
            paramArray.Add(new NandanaDBRequest.Parameter("@EndDate", EndDate));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetDocumentCountDetailsUsingDate", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from GetDocumentCountDetailsUsingDate sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetDocumentCountDetailsUsingDate sp.", m_oSession));
            }
            return result;
        }
    }
}
