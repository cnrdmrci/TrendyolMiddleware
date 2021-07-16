using System;

namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy
{
    public class LogConsole : LogStrategyBase
    {
        public override void SaveLog(dynamic logObject)
        {
            Console.WriteLine(FormatObjectToJson(logObject));
        }
    }
}