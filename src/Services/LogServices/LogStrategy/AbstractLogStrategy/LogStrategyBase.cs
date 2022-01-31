using Newtonsoft.Json;

namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy.AbstractLogStrategy
{
    public abstract class LogStrategyBase
    {
        protected string FormatObjectToJson(dynamic logObject)
        {
            return JsonConvert.SerializeObject(logObject, Formatting.Indented);
        }
    }
}