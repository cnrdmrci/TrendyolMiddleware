using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Trendyol.TyMiddleware.Extensions;
using Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter;

namespace Trendyol.TyMiddleware.Services.LogServices.LogProvider
{
    public class LogProviderService : ILogProviderService
    {
        private readonly LogMiddlewareProfile _logProfile;
        private readonly ILogProfileService _logProfileService;
        private BaseMiddlewareModel _baseMiddlewareModel;
        private ApiFilter _apiFilter;
        

        public LogProviderService(ILogProfileService logProfileService)
        {
            _logProfileService = logProfileService;
            _logProfile = logProfileService.GetLogMiddlewareProfile();
        }

        public dynamic CreateLogObject(BaseMiddlewareModel baseMiddlewareModel)
        {
            InitializeMembers(baseMiddlewareModel);
            
            dynamic logObject = new ExpandoObject();
            FillDefaults(logObject);
            FillCustomFields(logObject);
            FillHeaderFields(logObject);
            return logObject;
        }

        private void InitializeMembers(BaseMiddlewareModel baseMiddlewareModel)
        {
            _baseMiddlewareModel = baseMiddlewareModel;
            _apiFilter = _logProfileService.GetApiFilter(baseMiddlewareModel);
        }
        
        private void FillDefaults(dynamic logObject)
        {
            FillAuditLogId(logObject);
            FillAuditLogRequestBody(logObject);
            FillAuditLogResponseBody(logObject);
            FillAuditLogHttpMethod(logObject);
            FillAuditLogController(logObject);
            FillAuditLogRequestUri(logObject);
            FillAuditLogAction(logObject);
            FillAuditLogStatusCode(logObject);
            FillAuditLogProcessingTime(logObject);
            FillAuditLogCallDate(logObject);
            FillAuditLogFullAction(logObject);
        }
        
        private void FillHeaderFields(dynamic logObject)
        {
            if (_logProfile.GetHeaderFields().IsNullOrEmpty()) return;
            if (_apiFilter?.ApiFilterFieldDetail?.HeadersIgnore ?? false) return;
            
            _logProfile.GetHeaderFields().ForEach(headerField =>
            {
                AddHeaderToField(logObject, headerField);
            });
        }

        private void AddHeaderToField(dynamic logObject, HeaderField headerField)
        {
            if (_baseMiddlewareModel.Headers.ContainsKey((string) headerField.FieldValue))
            {
                string fieldValue = _baseMiddlewareModel.Headers[(string) headerField.FieldValue];
                ((IDictionary<string, object>) logObject).Add(headerField.FieldName,fieldValue);
            }
        }

        private void FillCustomFields(dynamic logObject)
        {
            if (_logProfile.GetCustomFields().IsNullOrEmpty()) return;
            
            _logProfile.GetCustomFields().ForEach(customField =>
            {
                ((IDictionary<string, object>) logObject).Add(customField.FieldName, customField.FieldValue);
            });
        }


        private void FillAuditLogId(dynamic logObject)
        {
            logObject.Id = _baseMiddlewareModel.Id;
        }
        
        private void FillAuditLogProcessingTime(dynamic logObject)
        {
            if (_logProfile.ProcessingTimeLogEnabled)
            {
                logObject.ProcessingTime =  _baseMiddlewareModel.ProcessingTime;
            }
        }
        
        private void FillAuditLogCallDate(dynamic logObject)
        {
            logObject.CallDate =  _baseMiddlewareModel.CallDate;
        }
        
        private void FillAuditLogFullAction(dynamic logObject)
        {
            logObject.FullAction =  _baseMiddlewareModel.FullAction;
        }

        private void FillAuditLogRequestBody(dynamic logObject)
        {
            if (_apiFilter?.ApiFilterFieldDetail?.RequestBodyIgnore ?? false) return;

            var requestBody = _baseMiddlewareModel.RequestBody;

            if (_logProfile.RequestBodyLogEnabled)
            {
                if (_logProfile.SecurePasswordLogModel.SecurePasswordLogEnabled)
                {
                    dynamic dynamicRequestObjects = JsonConvert.DeserializeObject(_baseMiddlewareModel.RequestBody);
                    if (dynamicRequestObjects != null)
                    {
                        foreach (var dynamicRequestObject in dynamicRequestObjects)
                        {
                            var property = dynamicRequestObject.Path;
                        
                            if (!_logProfile.SecurePasswordLogModel.CaseSensitiveEnabled)
                                property = property.ToLower();
                        
                            if (_logProfile.SecurePasswordLogModel.PasswordFieldNames.Contains(property))
                            {
                                dynamicRequestObject.Value = "***";
                            }
                        }

                        requestBody = JsonConvert.SerializeObject(dynamicRequestObjects);
                    }
                }

                logObject.RequestBody = requestBody;
            }
        }

        private void FillAuditLogResponseBody(dynamic logObject)
        {
            if (_apiFilter?.ApiFilterFieldDetail?.ResponseBodyIgnore ?? false) return;
            
            if (_logProfile.ResponseBodyLogEnabled)
            {   
                logObject.ResponseBody = _baseMiddlewareModel.ResponseBody;
            }
        }

        private void FillAuditLogController(dynamic logObject)
        {
            if (_logProfile.ControllerLogEnabled)
            {
                logObject.Controller = _baseMiddlewareModel.Controller;
            }
        }

        private void FillAuditLogRequestUri(dynamic logObject)
        {
            if (_logProfile.RequestUriLogEnabled)
            {
                logObject.RequestUri = _baseMiddlewareModel.RequestUri;   
            }
        }

        private void FillAuditLogAction(dynamic logObject)
        {
            if (_logProfile.ActionLogEnabled)
            {
                logObject.Action = _baseMiddlewareModel.Action;
            }
        }

        private void FillAuditLogStatusCode(dynamic logObject)
        {
            if (_logProfile.StatusCodeLogEnabled)
            {
                logObject.ResponseStatusCode = _baseMiddlewareModel.ResponseStatusCode.ToString();
            }
        }

        private void FillAuditLogHttpMethod(dynamic logObject)
        {
            if (_logProfile.HttpMethodLogEnabled)
            {
                logObject.HttpMethod = _baseMiddlewareModel.HttpMethod;
            }
        }
    }
}