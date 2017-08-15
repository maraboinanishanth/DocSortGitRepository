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
    public class ConfirmLicenseManager:DocSortBase
    {
        public DocSortResult UpdateConfigValues(string Config_ID, string Config_Value)
        {
            DocSortResult result;
            
            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@ConfigId", Config_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@ConfigValue", Config_Value));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateConfigValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateConfigValues sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateConfigValues  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult UpdateScannedRecordCount(string Config_ID, string Config_Value)
        {
            DocSortResult result;

            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@Config_ID", Config_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Config_Value", Config_Value));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateScannedRecordCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateScannedRecordCount sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateScannedRecordCount  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult UpdateLockDocCount(string Config_ID, string Config_Value)
        {
            DocSortResult result;

            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@Config_ID", Config_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Config_Value", Config_Value));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateLockDocCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateLockDocCount sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateLockDocCount  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult UpdateLicenseKeys(string Config_ID, string Config_Value)
        {
            DocSortResult result;

            int iVal = -1;

            ArrayList paramArray = new ArrayList();
            paramArray.Add(new DocSortDBRequest.Parameter("@Config_ID", Config_ID));
            paramArray.Add(new DocSortDBRequest.Parameter("@Config_Value", Config_Value));

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_UpdateLicenseKeys", CommandType.StoredProcedure, m_oTransaction, paramArray);
                iVal = factory.ExecuteNonQuery(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "Error While Updating data into UpdateLicenseKeys sp.", m_oSession, e));
            }

            if (iVal < 0)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_UPDATING_RECORD, "No record Updating from UpdateLicenseKeys  sp.", m_oSession));
            }
            else
            {
                result = new DocSortResult(null);
            }
            return result;
        }

        public DocSortResult GetConfigValueOfIsExpired()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetConfigValueOfIsExpired", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfIsExpired sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfIsExpired sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetConfigValueOfSecurityKey()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetConfigValueOfSecurityKey", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfSecurityKey sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfSecurityKey sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetConfigValueOfScannedReadCount()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetConfigValueOfScannedReadCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfScannedReadCount sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfScannedReadCount sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetConfigValueOfLockDocCount()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetConfigValueOfLockDocCount", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfLockDocCount sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfLockDocCount sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetConfigValueOfLicenseKeys()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetConfigValueOfLicenseKeys", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetConfigValueOfLicenseKeys sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetConfigValueOfLicenseKeys sp.", m_oSession));
            }
            return result;
        }

        public DocSortResult GetAllConfigValues()
        {
            DocSortResult result;
            DocSortDataSet resultDS;
            ArrayList paramArray = new ArrayList();

            try
            {
                DocSortAbstractFactory factory = DocSortDBInstance.GetDBFactory();
                DocSortDBRequest request = new DocSortDBRequest("sp_GetAllConfigValues", CommandType.StoredProcedure, m_oTransaction, paramArray);
                resultDS = factory.ExecuteDataSet(request);
            }
            catch (Exception e)
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "Error while Getting data from GetAllConfigValues sp.", m_oSession, e));
            }

            result = new DocSortResult();
            result.resultDS = resultDS.ReturnedDataSet;
            if (!(result.resultDS != null && result.resultDS.Tables.Count > 0 && result.resultDS.Tables[0].Rows.Count > 0))
            {
                return (new DocSortResult(DocSortError.ErrorType.ERR_RETRIEVING_DATA, "No record found from GetAllConfigValues sp.", m_oSession));
            }
            return result;
        }
    }
}
