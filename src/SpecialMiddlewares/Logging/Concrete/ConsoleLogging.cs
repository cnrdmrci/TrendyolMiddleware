using System;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public class ConsoleLogging : LogMiddlewareBase
    {
        public ConsoleLogging(LogConfiguration logConfiguration) : base(logConfiguration)
        {
        }
        
        public override void LogHandle(MiddlewareInformation middlewareInformation)
        {
            var logJsonCreator = new LogJsonCreator(middlewareInformation, LogConfiguration);
            Console.WriteLine(logJsonCreator.GetParsedJson());
        }

        
    }
}