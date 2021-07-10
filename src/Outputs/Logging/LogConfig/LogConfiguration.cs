using System.Collections.Generic;
using TrendyolMiddleware.Outputs.Logging.Concrete;

namespace TrendyolMiddleware.Outputs.Logging.LogConfig
{
    public class LogConfiguration
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
        public List<FieldDescription> FieldDescriptionListForConstant { get; set; }
        public List<HeaderFieldDesctiption> FieldDescriptionListForHeaderKey { get; set; }
    }

    public class FieldDescription
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }

    public class HeaderFieldDesctiption
    {
        public string FieldName { get; set; }
        public string HeaderKeyForFieldValue { get; set; }
    }
}