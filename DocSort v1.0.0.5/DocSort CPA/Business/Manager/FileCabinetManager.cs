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
    public class FileCabinetManager : NandanaBase
    {
        public NandanaResult InsertFileCabinetDetails(string FileCabinet_Name,string IsDelete)
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FileCabinetname", FileCabinet_Name));
            paramArray.Add(new NandanaDBRequest.Parameter("@Isdelete", IsDelete));
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_InsertFileCabinetDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error While retriving data from InsertFileCabinet sp.", m_oSession, e));
            }
            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from InsertFileCabinet sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetFileCabinets()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetFileCabinets", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetFileCabinets sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetFileCabinets sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult DeleteFileCabinetDetails(string FilecabinetId, string Isdelete)
        {
            NandanaResult result;
            int iVal = -1; 
            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@FilecabinetId", FilecabinetId));
            paramArray.Add(new NandanaDBRequest.Parameter("@Isdelete", Isdelete));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_DeleteFileCabinetDetails", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into DeleteFileCabinetDetails sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from DeleteFileCabinetDetails  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }
    }
}
