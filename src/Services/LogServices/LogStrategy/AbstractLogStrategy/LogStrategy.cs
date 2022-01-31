using System;
using System.Collections.Generic;
using System.Linq;
using Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy.LogStrategyService;

namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy.AbstractLogStrategy
{
    public class LogStrategy : ILogStrategy
    {
        private readonly ILogProfileService _logProfileService;
        private readonly IEnumerable<ILogStrategyService> _logStrategyServices;
        
        public LogStrategy(IEnumerable<ILogStrategyService> logStrategyServices, ILogProfileService logProfileService)
        {
            _logStrategyServices = logStrategyServices;
            _logProfileService = logProfileService;
        }
        public void SaveLog(dynamic logObject)
        {
            var logType = _logProfileService.GetLogMiddlewareProfile().LogType;
            var logStrategy = _logStrategyServices.FirstOrDefault(x => x.LogType == logType) ?? throw new ArgumentNullException(nameof(logType));
            
            logStrategy.SaveLog(logObject);
        }
    }
}