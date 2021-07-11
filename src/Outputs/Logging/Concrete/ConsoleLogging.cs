using System;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;
using Trendyol.TyMiddleware.Outputs.Logging.LogHelper;

namespace Trendyol.TyMiddleware.Outputs.Logging.Concrete
{
    public class ConsoleLogging : LogFactory
    {
        public ConsoleLogging(LogProfile logProfile) : base(logProfile)
        {
        }
        
        public override void Log(BaseMiddlewareModel baseMiddlewareModel)
        {
            var logJsonCreator = new LogJsonCreator(baseMiddlewareModel, LogProfile);
            Console.WriteLine(logJsonCreator.GetParsedJson());
        }

        
    }
}