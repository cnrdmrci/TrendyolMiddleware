using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.LogHelper;
using Trendyol.TyMiddleware.Profile;

namespace Trendyol.TyMiddleware.Outputs.Logging.Concrete
{
    public class LoggerLogging  : LogFactory
    {
        public LoggerLogging(LogMiddlewareProfile logProfile) : base(logProfile)
        {
        }
        
        public override void Log(BaseMiddlewareModel baseMiddlewareModel)
        {
            var logJsonCreator = new LogJsonCreator(baseMiddlewareModel, LogProfile);
            var json = logJsonCreator.GetParsedJson();
            //TODO: inject ILogger
            
            throw new System.NotImplementedException();
        }
    }
}