using Trendyol.TyMiddleware.Enums;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.Concrete;
using Trendyol.TyMiddleware.Profile;

namespace Trendyol.TyMiddleware.Outputs.Logging.LogHelper
{
    public class LogTypeSelector
    {
        public static LogFactory GetLogMethod(LogMiddlewareProfile logProfile)
        {
            LogFactory logFactory;
            
            switch (logProfile.LogType)
            {
                case LogType.Console:
                    logFactory = new ConsoleLogging(logProfile);
                    break;
                case LogType.Logger:
                    logFactory = new LoggerLogging(logProfile);
                    break;
                default:
                    logFactory = new ConsoleLogging(logProfile);
                    break;
            }

            return logFactory;
        }
    }
}