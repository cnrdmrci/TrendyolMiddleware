using System.Collections.Generic;
using Trendyol.TyMiddleware.Enums;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;

namespace Trendyol.TyMiddleware.Profile
{
    public abstract class LogMiddlewareProfile : IBaseProfile
    {
        public bool RequestBodyLogEnabled { get; set; } = true;
        public bool ResponseBodyLogEnabled { get; set; } = true;
        public bool HttpMethodLogEnabled { get; set; } = true;
        public bool ControllerLogEnabled { get; set; } = true;
        public bool RequestUriLogEnabled { get; set; } = true;
        public bool ActionLogEnabled { get; set; } = true;
        public bool StatusCodeLogEnabled { get; set; } = true;
        public bool ProcessingTimeLogEnabled { get; set; } = true;
        public LogType LogType { get; set; }
        public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public List<HeaderField> HeaderFields { get; set; } = new List<HeaderField>();
        
        public void AddCustomFields(string fieldName, object fieldValue)
        {
            if (CustomFields == null)
            {
                CustomFields = new List<CustomField>();
            }

            if (!string.IsNullOrEmpty(fieldName.Trim()) && fieldValue != null)
            {
                CustomFields.Add(new CustomField(fieldName, fieldValue));
            }
        }

        public void AddHeaderFields(string fieldName, object fieldValue)
        {
            if (HeaderFields == null)
            {
                HeaderFields = new List<HeaderField>();
            }

            if (!string.IsNullOrEmpty(fieldName.Trim()) && fieldValue != null)
            {
                HeaderFields.Add(new HeaderField(fieldName, fieldValue));
            }
        }
    }
}