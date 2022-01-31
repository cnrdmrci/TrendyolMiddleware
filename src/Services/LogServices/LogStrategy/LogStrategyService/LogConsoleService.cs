using System;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy.AbstractLogStrategy;

namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy.LogStrategyService
{
    public class LogConsoleService : LogStrategyBase, ILogStrategyService
    {
        public LogType LogType => LogType.Console;

        public void SaveLog(dynamic logObject)
        {
            Console.WriteLine(FormatObjectToJson(logObject));
        }
    }
}