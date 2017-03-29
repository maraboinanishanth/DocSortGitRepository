using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Common; 
using System.Collections;

namespace Business.Manager 
{
    public class DashBoardManager: NandanaBase
    {
        public NandanaResult GetServicingAlerts()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();
          
            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetServicingAlerts", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetServicingAlerts sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetServicingAlerts sp.", m_oSession));
            }
            return result;
        }
    }
}
