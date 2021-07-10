using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.Concrete;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;

namespace Trendyol.TyMiddleware.Outputs.Logging.LogHelper
{
    public class LogTypeSelector
    {
        public static LogProvider GetLogMethod(LogConfiguration logConfiguration)
        {
            LogProvider logProvider;
            
            switch (logConfiguration.LogType)
            {
                case LogType.Console:
                    logProvider = new ConsoleLogging(logConfiguration);
                    break;
                case LogType.Logger:
                    logProvider = new LoggerLogging(logConfiguration);
                    break;
                default:
                    logProvider = new ConsoleLogging(logConfiguration);
                    break;
            }

            return logProvider;
        }
    }
}