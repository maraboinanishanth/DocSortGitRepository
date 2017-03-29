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
    public class ConfirmLicenseManager:NandanaBase
    {
        public NandanaResult UpdateConfigValues(string Config_ID, string Config_Value)
        {
            NandanaResult result;
            
            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@ConfigId", Config_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@ConfigValue", Config_Value));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_UpdateConfigValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateConfigValues sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateConfigValues  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult UpdateScannedRecordCount(string Config_ID, string Config_Value)
        {
            NandanaResult result;

            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@Config_ID", Config_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Config_Value", Config_Value));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_UpdateScannedRecordCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateScannedRecordCount sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateScannedRecordCount  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult UpdateLockDocCount(string Config_ID, string Config_Value)
        {
            NandanaResult result;

            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@Config_ID", Config_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Config_Value", Config_Value));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_UpdateLockDocCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateLockDocCount sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateLockDocCount  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult UpdateLicenseKeys(string Config_ID, string Config_Value)
        {
            NandanaResult result;

            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new NandanaDBRequest.Parameter("@Config_ID", Config_ID));
            paramArray.Add(new NandanaDBRequest.Parameter("@Config_Value", Config_Value));

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_UpdateLicenseKeys", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateLicenseKeys sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateLicenseKeys  sp.", m_oSession));
            }
            else
            {
                result = new NandanaResult(null);
            }
            return result;
        }

        public NandanaResult GetConfigValueOfIsExpired()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetConfigValueOfIsExpired", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfIsExpired sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfIsExpired sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetConfigValueOfSecurityKey()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetConfigValueOfSecurityKey", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfSecurityKey sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfSecurityKey sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetConfigValueOfScannedReadCount()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetConfigValueOfScannedReadCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfScannedReadCount sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfScannedReadCount sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetConfigValueOfLockDocCount()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetConfigValueOfLockDocCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfLockDocCount sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfLockDocCount sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetConfigValueOfLicenseKeys()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetConfigValueOfLicenseKeys", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfLicenseKeys sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfLicenseKeys sp.", m_oSession));
            }
            return result;
        }

        public NandanaResult GetAllConfigValues()
        {
            NandanaResult result;
            NandanaDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                NandanaAbstractFactory factory = NandanaDBInstance.GetDBFactory();
                NandanaDBRequest request = new NandanaDBRequest("sp_GetAllConfigValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetAllConfigValues sp.", m_oSession, e));
            }

            result = new NandanaResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new NandanaResult(NandanaError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllConfigValues sp.", m_oSession));
            }
            return result;
        }
    }
}
