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

        public LogJsonCreator(BaseMiddlewareModel baseMiddlewareModel, LogProfile logProfile)
        {
            dynamic baseLogObject = new ExpandoObject();
            FillDefaults(baseMiddlewareModel, logProfile, baseLogObject);

            FillCustomFields(baseLogObject, logProfile);
            FillHeaderFields(baseMiddlewareModel, baseLogObject, logProfile);
            
            _json = JsonConvert.SerializeObject(baseLogObject, Formatting.Indented);
        }

        private void FillDefaults(BaseMiddlewareModel baseMiddlewareModel, LogProfile logProfile, dynamic baseLogObject)
        {
            FillAuditLogId(baseMiddlewareModel, baseLogObject);
            FillAuditLogRequestBody(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogResponseBody(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogHttpMethod(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogController(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogRequestUri(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogAction(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogStatusCode(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogProcessingTime(baseMiddlewareModel, baseLogObject, logProfile);
            FillAuditLogCallDate(baseMiddlewareModel, baseLogObject);
            FillAuditLogFullAction(baseMiddlewareModel, baseLogObject);
        }

        public string GetParsedJson()
        {
            return _json;
        }

        private void FillHeaderFields(BaseMiddlewareModel baseMiddlewareModel, object auditLog,
            LogProfile logProfile)
        {
            if (logProfile.HeaderFields.IsNullOrEmpty()) return;

            foreach (var fieldDescription in logProfile.HeaderFields)
            {
                if (baseMiddlewareModel.Headers.ContainsKey((string) fieldDescription.FieldValue))
                {
                    ((IDictionary<string, object>) auditLog).Add(fieldDescription.FieldName,
                        baseMiddlewareModel.Headers[(string) fieldDescription.FieldValue]);
                }
            }
        }

        private void FillCustomFields(dynamic auditLog, LogProfile logProfile)
        {
            if (logProfile.CustomFields.IsNullOrEmpty()) return;

            foreach (var fieldDescription in logProfile.CustomFields)
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
            LogProfile logProfile)
        {
            if (logProfile.ProcessingTimeLogEnabled)
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
            LogProfile logProfile)
        {
            if (logProfile.RequestBodyLogEnabled)
            {
                auditLog.RequestBody =  baseMiddlewareModel.RequestBody;
            }
        }

        private void FillAuditLogResponseBody(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogProfile logProfile)
        {
            if (logProfile.ResponseBodyLogEnabled)
            {   
                auditLog.ResponseBody = baseMiddlewareModel.ResponseBody;
            }
        }

        private void FillAuditLogController(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogProfile logProfile)
        {
            if (logProfile.ControllerLogEnabled)
            {
                auditLog.Controller = baseMiddlewareModel.Controller;
            }
        }

        private void FillAuditLogRequestUri(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogProfile logProfile)
        {
            if (logProfile.RequestUriLogEnabled)
            {
                auditLog.RequestUri = baseMiddlewareModel.RequestUri;   
            }
        }

        private void FillAuditLogAction(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogProfile logProfile)
        {
            if (logProfile.ActionLogEnabled)
            {
                auditLog.Action = baseMiddlewareModel.Action;
            }
        }

        private void FillAuditLogStatusCode(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogProfile logProfile)
        {
            if (logProfile.StatusCodeLogEnabled)
            {
                auditLog.ResponseStatusCode = baseMiddlewareModel.ResponseStatusCode.ToString();
            }
        }

        private void FillAuditLogHttpMethod(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogProfile logProfile)
        {
            if (logProfile.HttpMethodLogEnabled)
            {
                auditLog.HttpMethod = baseMiddlewareModel.HttpMethod;
            }
        }
    }
}