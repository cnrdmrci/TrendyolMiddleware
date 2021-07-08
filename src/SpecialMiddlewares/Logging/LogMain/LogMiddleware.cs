using System.Threading.Tasks;
using TrendyolMiddleware.BaseMiddleware;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public class LogMiddleware : IBaseMiddleware
    {
        private readonly LogConfiguration _logConfiguration;

        public LogMiddleware(LogConfiguration logConfiguration)
        {
            _logConfiguration = logConfiguration;
        }

        public Task BeforeDelegateHandle(MiddlewareInformation middlewareInformation)
        {
            return Task.CompletedTask;
        }

        public Task AfterDelegateHandle(MiddlewareInformation middlewareInformation)
        {
            LogMiddlewareBase logMiddlewareBase = LogMethodSelector.GetLogMethod(_logConfiguration);
            logMiddlewareBase.LogHandle(middlewareInformation);
            return Task.CompletedTask;
        }
    }
}