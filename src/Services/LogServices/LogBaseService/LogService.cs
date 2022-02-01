using Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter;
using Trendyol.TyMiddleware.Services.LogServices.LogProvider;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy.AbstractLogStrategy;

namespace Trendyol.TyMiddleware.Services.LogServices.LogBaseService
{
    public class LogService : ILogService
    {
        private readonly ILogProfileService _logProfileService;
        private readonly ILogProviderService _logProviderService;
        private readonly ILogStrategy _logStrategy;

        public LogService(ILogProviderService logProviderService, ILogProfileService logProfileService, ILogStrategy logStrategy)
        {
            _logProfileService = logProfileService;
            _logStrategy = logStrategy;
            _logProviderService = logProviderService;
        }

        public void Log(BaseMiddlewareModel baseMiddlewareModel)
        {
            if (_logProfileService.IsLoggingIgnore(baseMiddlewareModel)) return;

            dynamic logObject = _logProviderService.CreateLogObject(baseMiddlewareModel);
            
            _logStrategy.SaveLog(logObject);
        }

        public bool IgnoreLog(BaseMiddlewareModel baseMiddlewareModel)
        {
            return baseMiddlewareModel.FullAction?.ToLower()?.Contains("swagger") ?? false;
        }
    }
}