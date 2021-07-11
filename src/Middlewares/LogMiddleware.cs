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
        private readonly LogProfile _logProfile;

        public LogMiddleware(LogProfile logProfile)
        {
            _logProfile = logProfile;
        }

        public Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            return Task.CompletedTask;
        }

        public Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            LogFactory logFactory = LogTypeSelector.GetLogMethod(_logProfile);
            logFactory.Log(baseMiddlewareModel);
            
            return Task.CompletedTask;
        }
    }
}