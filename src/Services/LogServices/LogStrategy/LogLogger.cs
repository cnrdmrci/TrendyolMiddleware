namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy
{
    public class LogLogger : LogStrategyBase
    {
        public override void SaveLog(dynamic logObject)
        {
            var json = FormatObjectToJson(logObject);
            //TODO: inject ILogger
            
            throw new System.NotImplementedException();
        }
    }
}