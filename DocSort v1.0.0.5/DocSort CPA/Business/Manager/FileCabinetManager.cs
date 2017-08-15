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
    public class FileCabinetManager : DocSortBase
    {
        public DocSortResult InsertFileCabinetDetails(string FileCabinet_Name,string IsDelete)
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FileCabinetname", FileCabinet_Name));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", IsDelete));
            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_InsertFileCabinetDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertFileCabinet sp.", m_oSession, e));
            }
            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertFileCabinet sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetFileCabinets()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetFileCabinets", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFileCabinets sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFileCabinets sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult DeleteFileCabinetDetails(string FilecabinetId, string Isdelete)
        {
            DocSortResult result;
            int iVal = -1; 
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@FilecabinetId", FilecabinetId));
            paramArray.Add(new DocSortDBRequest.Parameter("@Isdelete", Isdelete));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_DeleteFileCabinetDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into DeleteFileCabinetDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from DeleteFileCabinetDetails  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }
    }
}
