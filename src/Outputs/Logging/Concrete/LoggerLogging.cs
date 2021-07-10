using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;
using Trendyol.TyMiddleware.Outputs.Logging.LogHelper;

namespace Trendyol.TyMiddleware.Outputs.Logging.Concrete
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