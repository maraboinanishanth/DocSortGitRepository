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
    public class FolderManager:NandanaBase
    {
        public NandanaResult InsertFolderDetails(string FileCabinet_ID, string Folder_Name, string ParentFolderID, string ISDelete)
        {
            NandanaResult result;
            NandanaDataSet resultDS;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FilecabinetId", FileCabinet_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Foldername", Folder_Name));
            paramArray.Add(new NandanaDBRequest.Parameter("@ParentfolderId", ParentFolderID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Isdelete", ISDelete));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertFolderDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertFolderDetails sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertFolderDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetFolderDetails()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetFolderDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFolderDetails sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFolderDetails sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetMainFolderNamesUsingFileCabinetID(string FileCabinet_ID)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FileCabinet_ID", FileCabinet_ID));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetMainFolderNamesUsingFileCabinetID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetMainFolderNamesUsingFileCabinetID sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMainFolderNamesUsingFileCabinetID sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetFolderDetailsUsingFolderID(string Folder_ID)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@Folder_ID", Folder_ID));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetFolderDetailsUsingFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFolderDetailsUsingFolderID sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFolderDetailsUsingFolderID sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetSubFolderNamesUsingFolderID(string ParentFolderID)
        {
            NandanaResult result; 
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@ParentFolderID", ParentFolderID));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetSubFolderNamesUsingFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetSubFolderNamesUsingFolderID sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetSubFolderNamesUsingFolderID sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetFolderNamesUsingParentFolderID(string FileCabinet_ID,string ParentFolderID)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FileCabinet_ID", FileCabinet_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@ParentFolderID", ParentFolderID));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetFolderNamesUsingParentFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFolderNamesUsingParentFolderID sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFolderNamesUsingParentFolderID sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult UpdateFolderNameDetails(string Folder_ID,string Folder_Name)
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Foldername", Folder_Name));
            
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_UpdateFolderNameDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateFolderNameDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateFolderNameDetails  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult DeleteFolderDetails(string Folder_ID, string IsDelete) 
        {
            NandanaResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Isdelete", IsDelete));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_DeleteFolderDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into DeleteFolderDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from DeleteFolderDetails  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }
    }
}
