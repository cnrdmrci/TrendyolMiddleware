using TrendyolMiddleware.Model;
using TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public class LoggerLogging  : LogMiddlewareBase
    {
        public LoggerLogging(LogConfiguration logConfiguration) : base(logConfiguration)
        {
        }
        
        public override void LogHandle(MiddlewareInformation middlewareInformation)
        {
            var logJsonCreator = new LogJsonCreator(middlewareInformation, LogConfiguration);
            var json = logJsonCreator.GetParsedJson();
            //TODO: inject ILogger
            
            throw new System.NotImplementedException();
        }
    }
}