using System;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.Outputs.Logging.Abstract;
using TrendyolMiddleware.Outputs.Logging.LogConfig;
using TrendyolMiddleware.Outputs.Logging.LogHelper;

namespace TrendyolMiddleware.Outputs.Logging.Concrete
{
    public class ConsoleLogging : LogProvider
    {
        public ConsoleLogging(LogConfiguration logConfiguration) : base(logConfiguration)
        {
        }
        
        public override void Log(BaseMiddlewareModel baseMiddlewareModel)
        {
            var logJsonCreator = new LogJsonCreator(baseMiddlewareModel, LogConfiguration);
            Console.WriteLine(logJsonCreator.GetParsedJson());
        }

        
    }
}