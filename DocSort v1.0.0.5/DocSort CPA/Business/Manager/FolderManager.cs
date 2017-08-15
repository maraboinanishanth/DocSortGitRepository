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
    public class FolderManager:DocSortBase
    {
        public DocSortResult InsertFolderDetails(string FileCabinet_ID, string Folder_Name, string ParentFolderID, string ISDelete)
        {
            DocSortResult result;
            DocSortDataSet resultDS;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FilecabinetId", FileCabinet_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Foldername", Folder_Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@ParentfolderId", ParentFolderID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", ISDelete));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertFolderDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertFolderDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertFolderDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFolderDetails()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFolderDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFolderDetails sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFolderDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetMainFolderNamesUsingFileCabinetID(string FileCabinet_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileCabinet_ID", FileCabinet_ID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetMainFolderNamesUsingFileCabinetID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetMainFolderNamesUsingFileCabinetID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMainFolderNamesUsingFileCabinetID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFolderDetailsUsingFolderID(string Folder_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@Folder_ID", Folder_ID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFolderDetailsUsingFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFolderDetailsUsingFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFolderDetailsUsingFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetSubFolderNamesUsingFolderID(string ParentFolderID)
        {
            DocSortResult result; 
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@ParentFolderID", ParentFolderID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetSubFolderNamesUsingFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetSubFolderNamesUsingFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetSubFolderNamesUsingFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFolderNamesUsingParentFolderID(string FileCabinet_ID,string ParentFolderID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileCabinet_ID", FileCabinet_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@ParentFolderID", ParentFolderID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFolderNamesUsingParentFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFolderNamesUsingParentFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFolderNamesUsingParentFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult UpdateFolderNameDetails(string Folder_ID,string Folder_Name)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Foldername", Folder_Name));
            
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateFolderNameDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateFolderNameDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateFolderNameDetails  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult DeleteFolderDetails(string Folder_ID, string IsDelete) 
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", IsDelete));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_DeleteFolderDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into DeleteFolderDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from DeleteFolderDetails  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }
    }
}
