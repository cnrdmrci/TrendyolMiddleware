using TrendyolMiddleware.Model;
using TrendyolMiddleware.Outputs.Logging.Abstract;
using TrendyolMiddleware.Outputs.Logging.LogConfig;
using TrendyolMiddleware.Outputs.Logging.LogHelper;

namespace TrendyolMiddleware.Outputs.Logging.Concrete
{
    public class LoggerLogging  : LogProvider
    {
        public LoggerLogging(LogConfiguration logConfiguration) : base(logConfiguration)
        {
        }
        
        public override void Log(BaseMiddlewareModel baseMiddlewareModel)
        {
            var logJsonCreator = new LogJsonCreator(baseMiddlewareModel, LogConfiguration);
            var json = logJsonCreator.GetParsedJson();
            //TODO: inject ILogger
            
            throw new System.NotImplementedException();
        }
    }
}