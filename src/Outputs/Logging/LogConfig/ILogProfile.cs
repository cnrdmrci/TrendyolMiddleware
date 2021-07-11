using System.Collections.Generic;
using Trendyol.TyMiddleware.Enums;

namespace Trendyol.TyMiddleware.Outputs.Logging.LogConfig
{
    public interface ILogProfile
    {
        bool RequestBodyLogEnabled { get; }
        bool ResponseBodyLogEnabled { get; }
        bool HttpMethodLogEnabled { get; }
        bool ControllerLogEnabled { get; }
        bool RequestUriLogEnabled { get; }
        bool ActionLogEnabled { get; }
        bool StatusCodeLogEnabled { get; }
        bool ProcessingTimeLogEnabled { get; }
        LogType LogType { get; }
        List<CustomField> CustomFields { get; }
        List<HeaderField> HeaderFields { get; }
        string ProfileName { get; }

        void AddHeaderFields(string fieldName, object fieldValue);
        void AddCustomFields(string fieldName, object fieldValue);
    }
}