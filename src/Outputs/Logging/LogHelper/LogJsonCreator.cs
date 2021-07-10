using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;
using TrendyolMiddleware.Utils;

namespace Trendyol.TyMiddleware.Outputs.Logging.LogHelper
{
    public class LogJsonCreator
    {
        private readonly string _json;

        public LogJsonCreator(BaseMiddlewareModel baseMiddlewareModel, LogConfiguration logConfiguration)
        {
            dynamic auditLog = new ExpandoObject();
            FillAuditLogId(baseMiddlewareModel, auditLog);
            FillAuditLogRequestBody(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogResponseBody(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogHttpMethod(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogController(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogRequestUri(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogAction(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogStatusCode(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogProcessingTime(baseMiddlewareModel, auditLog, logConfiguration);
            FillAuditLogCallDate(baseMiddlewareModel, auditLog);
            FillAuditLogFullAction(baseMiddlewareModel, auditLog);

            FillConstantField(auditLog, logConfiguration);

            FillConstantFieldWithHeaderValue(baseMiddlewareModel, auditLog, logConfiguration);
            _json = JsonConvert.SerializeObject(auditLog, Formatting.Indented);
        }

        public string GetParsedJson()
        {
            return _json;
        }

        private void FillConstantFieldWithHeaderValue(BaseMiddlewareModel baseMiddlewareModel, object auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.FieldDescriptionListForHeaderKey.IsNullOrEmpty()) return;

            foreach (var fieldDescription in logConfiguration.FieldDescriptionListForHeaderKey)
            {
                if (baseMiddlewareModel.Headers.ContainsKey(fieldDescription.HeaderKeyForFieldValue))
                {
                    ((IDictionary<string, object>) auditLog).Add(fieldDescription.FieldName,
                        baseMiddlewareModel.Headers[fieldDescription.HeaderKeyForFieldValue]);
                }
            }
        }

        private void FillConstantField(dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.FieldDescriptionListForConstant.IsNullOrEmpty()) return;

            foreach (var fieldDescription in logConfiguration.FieldDescriptionListForConstant)
            {
                ((IDictionary<string, object>) auditLog).Add(fieldDescription.FieldName,
                    fieldDescription.FieldValue);
            }
        }


        private void FillAuditLogId(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog)
        {
            auditLog.Id = baseMiddlewareModel.Id;
        }
        
        private void FillAuditLogProcessingTime(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.ProcessingTimeLogEnabled)
            {
                auditLog.ProcessingTime =  baseMiddlewareModel.ProcessingTime;
            }
        }
        
        private void FillAuditLogCallDate(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog)
        {
                auditLog.CallDate =  baseMiddlewareModel.CallDate;
        }
        
        private void FillAuditLogFullAction(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog)
        {
                auditLog.FullAction =  baseMiddlewareModel.FullAction;
        }

        private void FillAuditLogRequestBody(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.RequestBodyLogEnabled)
            {
                auditLog.RequestBody =  baseMiddlewareModel.RequestBody;
            }
        }

        private void FillAuditLogResponseBody(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.ResponseBodyLogEnabled)
            {   
                auditLog.ResponseBody = baseMiddlewareModel.ResponseBody;
            }
        }

        private void FillAuditLogController(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.ControllerLogEnabled)
            {
                auditLog.Controller = baseMiddlewareModel.Controller;
            }
        }

        private void FillAuditLogRequestUri(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.RequestUriLogEnabled)
            {
                auditLog.RequestUri = baseMiddlewareModel.RequestUri;   
            }
        }

        private void FillAuditLogAction(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.ActionLogEnabled)
            {
                auditLog.Action = baseMiddlewareModel.Action;
            }
        }

        private void FillAuditLogStatusCode(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.StatusCodeLogEnabled)
            {
                auditLog.ResponseStatusCode = baseMiddlewareModel.ResponseStatusCode.ToString();
            }
        }

        private void FillAuditLogHttpMethod(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            if (logConfiguration.HttpMethodLogEnabled)
            {
                auditLog.HttpMethod = baseMiddlewareModel.HttpMethod;
            }
        }
    }
}