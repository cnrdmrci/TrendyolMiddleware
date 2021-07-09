using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.Outputs.Logging.LogConfig;
using TrendyolMiddleware.Utils;

namespace TrendyolMiddleware.Outputs.Logging.LogHelper
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

        private void FillAuditLogRequestBody(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.RequestBody = logConfiguration.RequestBodyLogEnabled ? baseMiddlewareModel.RequestBody : null;
        }

        private void FillAuditLogResponseBody(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.ResponseBody = logConfiguration.ResponseBodyLogEnabled ? baseMiddlewareModel.ResponseBody : null;
        }

        private void FillAuditLogController(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.Controller = logConfiguration.ControllerLogEnabled ? baseMiddlewareModel.Controller : null;
        }

        private void FillAuditLogRequestUri(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.RequestUri = logConfiguration.RequestUriLogEnabled ? baseMiddlewareModel.RequestUri : null;
        }

        private void FillAuditLogAction(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.Action = logConfiguration.ActionLogEnabled ? baseMiddlewareModel.Action : null;
        }

        private void FillAuditLogStatusCode(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.ResponseStatusCode =
                logConfiguration.StatusCodeLogEnabled ? baseMiddlewareModel.ResponseStatusCode : null;
        }

        private void FillAuditLogHttpMethod(BaseMiddlewareModel baseMiddlewareModel, dynamic auditLog,
            LogConfiguration logConfiguration)
        {
            auditLog.HttpMethod = logConfiguration.HttpMethodLogEnabled ? baseMiddlewareModel.HttpMethod : null;
        }
    }
}