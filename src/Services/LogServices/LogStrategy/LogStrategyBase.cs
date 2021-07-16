using Newtonsoft.Json;

namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy
{
    public abstract class LogStrategyBase
    {
        public abstract void SaveLog(dynamic logObject);

        public virtual string FormatObjectToJson(dynamic logObject)
        {
            return JsonConvert.SerializeObject(logObject, Formatting.Indented);
        }
    }
}