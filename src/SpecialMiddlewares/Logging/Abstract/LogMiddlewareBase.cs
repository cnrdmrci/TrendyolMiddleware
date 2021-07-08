using TrendyolMiddleware.Model;
using TrendyolMiddleware.SpecialMiddlewares.Logging.LogConfig;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public abstract class LogMiddlewareBase
    {
        protected LogConfiguration LogConfiguration;

        public LogMiddlewareBase(LogConfiguration logConfiguration)
        {
            this.LogConfiguration = logConfiguration;
        }

        public abstract void LogHandle(MiddlewareInformation middlewareInformation);
    }
}