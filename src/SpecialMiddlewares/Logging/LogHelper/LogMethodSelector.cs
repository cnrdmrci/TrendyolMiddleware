using TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public class LogMethodSelector
    {
        public static LogMiddlewareBase GetLogMethod(LogConfiguration logConfiguration)
        {
            LogMiddlewareBase logMiddlewareBase;
            
            switch (logConfiguration.LogType)
            {
                case LogType.Console:
                    logMiddlewareBase = new ConsoleLogging(logConfiguration);
                    break;
                case LogType.Logger:
                    logMiddlewareBase = new LoggerLogging(logConfiguration);
                    break;
                
                default:
                    logMiddlewareBase = new ConsoleLogging(logConfiguration);
                    break;
            }

            return logMiddlewareBase;
        }
    }
}