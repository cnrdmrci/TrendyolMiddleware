using System.Collections.Generic;

namespace TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig
{
    public class LogConfiguration
    {
        public bool IsIdLogActive { get; set; } = true;
        public bool IsRequestBodyLogActive { get; set; } = true;
        public bool IsResponseBodyLogActive { get; set; } = true;
        public bool IsHttpMethodLogActive { get; set; } = true;
        public bool IsControllerLogActive { get; set; } = true;
        public bool IsRequestUriLogActive { get; set; } = true;
        public bool IsActionLogActive { get; set; } = true;
        public bool IsStatusCodeLogActive { get; set; } = true;
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