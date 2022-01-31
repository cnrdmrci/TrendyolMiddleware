using Microsoft.Extensions.Logging;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy.AbstractLogStrategy;

namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy.LogStrategyService
{
    public class LogLoggerService : LogStrategyBase, ILogStrategyService
    {
        private readonly ILogger<LogLoggerService> _logger;

        public LogLoggerService(ILogger<LogLoggerService> logger)
        {
            _logger = logger;
        }

        public LogType LogType => LogType.Logger;
        
        public void SaveLog(dynamic logObject)
        {
            string jsonString = FormatObjectToJson(logObject);
            
            _logger.LogInformation(jsonString);
        }
    }
}