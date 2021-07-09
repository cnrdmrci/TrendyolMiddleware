using TrendyolMiddleware.Outputs.Logging.Abstract;
using TrendyolMiddleware.Outputs.Logging.Concrete;
using TrendyolMiddleware.Outputs.Logging.LogConfig;

namespace TrendyolMiddleware.Outputs.Logging.LogHelper
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