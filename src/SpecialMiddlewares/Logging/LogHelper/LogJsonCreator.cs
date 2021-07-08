using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public class LogJsonCreator
    {
        private readonly string _json;
        public LogJsonCreator(MiddlewareInformation middlewareInformation, LogConfiguration logConfiguration)
        {
            dynamic auditLog = new ExpandoObject();
            FillAuditLogId(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogRequestBody(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogResponseBody(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogHttpMethod(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogController(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogRequestUri(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogAction(middlewareInformation, auditLog, logConfiguration);
            FillAuditLogStatusCode(middlewareInformation, auditLog, logConfiguration);

            FillConstantField(auditLog, logConfiguration);

            FillConstantFieldWithHeaderValue(middlewareInformation, auditLog, logConfiguration);
            _json = JsonConvert.SerializeObject(auditLog, Formatting.Indented);
        }

        public string GetParsedJson()
        {
            return _json;
        }
        
        private void FillConstantFieldWithHeaderValue(MiddlewareInformation middlewareInformation, object auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.FieldDescriptionListForHeaderKey != null &&
                logConfiguration.FieldDescriptionListForHeaderKey.Any())
            {
                foreach (var fieldDescription in logConfiguration.FieldDescriptionListForHeaderKey)
                {
                    if (middlewareInformation.Headers.ContainsKey(fieldDescription.HeaderKeyForFieldValue))
                    {
                        ((IDictionary<String, Object>)auditLog).Add(fieldDescription.FieldName, middlewareInformation.Headers[fieldDescription.HeaderKeyForFieldValue]);    
                    }
                }
            }
        }

        private void FillConstantField(dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.FieldDescriptionListForConstant != null &&
                logConfiguration.FieldDescriptionListForConstant.Any())
            {
                foreach (var fieldDescription in logConfiguration.FieldDescriptionListForConstant)
                {
                    ((IDictionary<String, Object>)auditLog).Add(fieldDescription.FieldName, fieldDescription.FieldValue);
                }
            }
        }


        private void FillAuditLogId(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsIdLogActive)
            {
                auditLog.Id = middlewareInformation.Id;
            }
        }
        
        private void FillAuditLogRequestBody(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsRequestBodyLogActive)
            {
                auditLog.RequestBody = middlewareInformation.RequestBody;
            }
        }
        
        private void FillAuditLogResponseBody(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsResponseBodyLogActive)
            {
                auditLog.ResponseBody = middlewareInformation.ResponseBody;
            }
        }
        
        private void FillAuditLogController(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsControllerLogActive)
            {
                auditLog.Controller = middlewareInformation.Controller;
            }
        }
        
        private void FillAuditLogRequestUri(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsRequestUriLogActive)
            {
                auditLog.RequestUri = middlewareInformation.RequestUri;
            }
        }
        
        private void FillAuditLogAction(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsActionLogActive)
            {
                auditLog.Action = middlewareInformation.Action;
            }
        }
        
        private void FillAuditLogStatusCode(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsStatusCodeLogActive)
            {
                auditLog.ResponseStatusCode = middlewareInformation.ResponseStatusCode;
            }
        }
        
        private void FillAuditLogHttpMethod(MiddlewareInformation middlewareInformation, dynamic auditLog, LogConfiguration logConfiguration)
        {
            if (logConfiguration.IsHttpMethodLogActive)
            {
                auditLog.HttpMethod = middlewareInformation.HttpMethod;
            }
        }
    }
}