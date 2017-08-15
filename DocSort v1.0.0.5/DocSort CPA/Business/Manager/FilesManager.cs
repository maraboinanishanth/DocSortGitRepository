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
    public class FilesManager:DocSortBase
    {
        public DocSortResult InsertFileDetails(int Folder_ID, int FileCabinet_ID, string File_Name, string File_Path, string IsDelete)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@FilecabinetId", FileCabinet_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filename", File_Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filepath", File_Path));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", IsDelete));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertFileDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
                catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertFileDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertFileDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult DeleteFolderAndFiles( int FileCabinet_ID, int Folder_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@FilecabinetId", FileCabinet_ID));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_DeleteFolderAndFiles", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from sp_DeleteFolderAndFiles sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_DeleteFolderAndFiles sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult UpdateFolderCabinet(string CabinetName, Int32 FolderID, string TargetFolderName, int sourceParentFolderID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@CabinetName", CabinetName));
            paramArray.Add(new DocSortDBRequest.Parameter("@FolderID", FolderID));
            paramArray.Add(new DocSortDBRequest.Parameter("@TargetFolderName", TargetFolderName));
            paramArray.Add(new DocSortDBRequest.Parameter("@sourceParentFolderID", sourceParentFolderID));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateFolderCabinet", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While updating data UpdateFolderCabinet", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from UpdateFolderCabinet sp.", m_oSession));
            }
            return result;

        }
        public DocSortResult UpdateFileDetails(int Folder_ID, int FileCabinet_ID, string Cabinet_Name, string File_Name, string File_Path, string IsDelete)
        {
            DocSortResult result;
            DocSortDataSet resultDS;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FolderId", Folder_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@FilecabinetId", FileCabinet_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@CabinetName", Cabinet_Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filename", File_Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filepath", File_Path));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", IsDelete));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateFileDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from UpdateFileDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from UpdateFileDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult UpdateFileDetailsFileID(int FileID, string File_Path)
        {
            DocSortResult result;
            DocSortDataSet resultDS;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileID", FileID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filepath", File_Path));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateFileDetailsFileID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from UpdateFileDetails sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from UpdateFileDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFileDetails()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFileDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFileDetails sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFileDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCabinetsFolderAndFiles()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCabinetsFolderAndFiles", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetCabinetsFolderAndFiles sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetCabinetsFolderAndFiles sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCabinetsAndFolders()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCabinetsAndFolders", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetCabinetsAndFolders sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFileDetails sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCabinetsFolderAndFilesByParentFolderID(string Parent_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@InputParentFolderID", Parent_ID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCabinetsFolderAndFilesByParentFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetCabinetsFolderAndFilesByParentFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetCabinetsFolderAndFilesByParentFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCabinetsFolderAndFilesByFolderID(string InputFolderID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@InputFolderID", InputFolderID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCabinetsFolderAndFilesByFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetCabinetsFolderAndFilesByFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetCabinetsFolderAndFilesByFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCabinetsFolderAndFilesByFileCabinetID(string InputFileCabinetID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@InputFileCabinetID", InputFileCabinetID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCabinetsFolderAndFilesByFileCabinetID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetCabinetsFolderAndFilesByFileCabinetID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetCabinetsFolderAndFilesByFileCabinetID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCabinetFilesByFileCabinetID(string InputFileCabinetID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@InputFileCabinetID", InputFileCabinetID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCabinetFilesByFileCabinetID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetCabinetFilesByFileCabinetID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetCabinetFilesByFileCabinetID sp.", m_oSession));
            }
            return result;
        }


        public DocSortResult GetFilesByFolderID(string InputFolderID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@InputFolderID", InputFolderID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFilesByFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetFilesByFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetFilesByFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetCountOfAllRows()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            //paramArray.Add(new DocSortDBRequest.Parameter("@InputFolderID", InputFolderID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetCountOfAllRows", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetCountOfAllRows sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetCountOfAllRows sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult DynamicSearchResults(string InputSearchText)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@InputSearchText", InputSearchText));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_DynamicSearchResults", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_DynamicSearchResults sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_DynamicSearchResults sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetProcessedDocumentsCount(Int32 fileCabinetId)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@fileCabinetId", fileCabinetId));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetProcessedDocumentsCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from sp_GetProcessedDocumentsCount sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from sp_GetProcessedDocumentsCount sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFilesUsingFileCabinetAndFolderID(string Folder_ID, string FileCabinet_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@Folder_ID", Folder_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@FileCabinet_ID", FileCabinet_ID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFilesUsingFileCabinetAndFolderID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFilesUsingFileCabinetAndFolderID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFilesUsingFileCabinetAndFolderID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetMainFileNamesUsingFileCabinetID(string FileCabinet_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileCabinet_ID", FileCabinet_ID));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetMainFileNamesUsingFileCabinetID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetMainFileNamesUsingFileCabinetID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetMainFileNamesUsingFileCabinetID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFileDetailsUsingFileID(string File_ID)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@File_ID", File_ID));
            
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFileDetailsUsingFileID", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFileDetailsUsingFileID sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFileDetailsUsingFileID sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult DeleteFileDetails(string File_ID, string IsDelete)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileId", File_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", IsDelete));
            
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_DeleteFileDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into DeleteFileDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from DeleteFileDetails  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult UpdateFileNameDetails(string File_ID, string File_Name)
        {
            DocSortResult result;
            int iVal = -1;
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileId", File_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Filename", File_Name));
           
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateFileNameDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateFileNameDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateFileNameDetails  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }
    }
}
