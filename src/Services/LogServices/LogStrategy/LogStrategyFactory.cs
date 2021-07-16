namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy
{
    public class LogStrategyFactory
    {
        public static LogStrategyBase GetLogStrategy(LogMiddlewareProfile logProfile)
        {
            if (logProfile.LogType == LogType.Console) return new LogConsole();
            if (logProfile.LogType == LogType.Logger) return new LogLogger();

            return new LogConsole();
        }
    }
}