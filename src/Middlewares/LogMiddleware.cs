using System.Threading.Tasks;
using Trendyol.TyMiddleware.Core.MiddlewareCoreProvider;
using Trendyol.TyMiddleware.Services.LogServices.LogBaseService;

namespace Trendyol.TyMiddleware.Middlewares
{
    public class LogMiddleware : IBaseMiddleware
    {
        private readonly ILogService _logService;

        public LogMiddleware(ILogService logService)
        {
            _logService = logService;
        }

        public Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            return Task.CompletedTask;
        }

        public Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            if (_logService.IgnoreLog(baseMiddlewareModel)) 
                return Task.CompletedTask;
            
            _logService.Log(baseMiddlewareModel);

            return Task.CompletedTask;
        }
    }
}