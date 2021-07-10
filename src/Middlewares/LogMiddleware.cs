using System.Threading.Tasks;
using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;
using Trendyol.TyMiddleware.Outputs.Logging.LogHelper;

namespace Trendyol.TyMiddleware.Middlewares
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