using System.Threading.Tasks;
using TrendyolMiddleware.BaseMiddleware;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.Outputs.Logging.Abstract;
using TrendyolMiddleware.Outputs.Logging.LogConfig;
using TrendyolMiddleware.Outputs.Logging.LogHelper;

namespace TrendyolMiddleware.Middlewares
{
    public class LogMiddleware : IBaseMiddleware
    {
        private readonly LogConfiguration _logConfiguration;

        public LogMiddleware(LogConfiguration logConfiguration)
        {
            _logConfiguration = logConfiguration;
        }

        public Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            return Task.CompletedTask;
        }

        public Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            LogProvider logProvider = LogTypeSelector.GetLogMethod(_logConfiguration);
            logProvider.Log(baseMiddlewareModel);
            
            return Task.CompletedTask;
        }
    }
}