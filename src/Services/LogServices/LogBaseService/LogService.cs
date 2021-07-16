using Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter;
using Trendyol.TyMiddleware.Services.LogServices.LogProvider;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy;

namespace Trendyol.TyMiddleware.Services.LogServices.LogBaseService
{
    public class LogService : ILogService
    {
        private readonly ILogProfileService _logProfileService;
        private readonly LogMiddlewareProfile _logProfile;
        private readonly ILogProviderService _logProviderService;

        public LogService(ILogProviderService logProviderService, ILogProfileService logProfileService)
        {
            _logProfileService = logProfileService;
            _logProviderService = logProviderService;
            _logProfile = _logProfileService.GetLogMiddlewareProfile();
        }

        public void Log(BaseMiddlewareModel baseMiddlewareModel)
        {
            if (_logProfileService.IsLoggingIgnore(baseMiddlewareModel)) return;

            dynamic logObject = _logProviderService.CreateLogObject(baseMiddlewareModel);
            
            LogStrategyBase logStrategyBase = LogStrategyFactory.GetLogStrategy(_logProfile);
            logStrategyBase.SaveLog(logObject);
        }
    }
}