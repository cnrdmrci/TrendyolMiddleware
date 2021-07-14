using System.Collections.Generic;
using Trendyol.TyMiddleware.Enums;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;

namespace Trendyol.TyMiddleware.Profile
{
    public abstract class LogMiddlewareProfile : IBaseProfile
    {
        public bool RequestBodyLogEnabled { get; set; }
        public bool ResponseBodyLogEnabled { get; set; }
        public bool HttpMethodLogEnabled { get; set; }
        public bool ControllerLogEnabled { get; set; }
        public bool RequestUriLogEnabled { get; set; }
        public bool ActionLogEnabled { get; set; }
        public bool StatusCodeLogEnabled { get; set; }
        public bool ProcessingTimeLogEnabled { get; set; }
        public ApiFilterModel ApiFilterModel { get; set; }
        public LogType LogType { get; set; }
        private readonly List<CustomField> _customFields;
        private readonly List<HeaderField> _headerFields;
        protected LogMiddlewareProfile()
        {
            RequestBodyLogEnabled = true;
            ResponseBodyLogEnabled = true;
            HttpMethodLogEnabled = true;
            ControllerLogEnabled = true;
            RequestBodyLogEnabled = true;
            RequestUriLogEnabled = true;
            ActionLogEnabled = true;
            StatusCodeLogEnabled = true;
            ProcessingTimeLogEnabled = true;
            ApiFilterModel = new ApiFilterModel();
            _customFields = new List<CustomField>();
            _headerFields = new List<HeaderField>();
        }

        public void AddCustomFields(string fieldName, object fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldName.Trim()) && fieldValue != null)
            {
                _customFields.Add(new CustomField(fieldName, fieldValue));
            }
        }

        public List<CustomField> GetCustomFields()
        {
            return _customFields;
        }

        public void AddHeaderFields(string fieldName, object fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldName.Trim()) && fieldValue != null)
            {
                _headerFields.Add(new HeaderField(fieldName, fieldValue));
            }
        }

        public List<HeaderField> GetHeaderFields()
        {
            return _headerFields;
        }
    }
}