using TrendyolMiddleware.Model;
using TrendyolMiddleware.Outputs.Logging.LogConfig;

namespace TrendyolMiddleware.Outputs.Logging.Abstract
{
    public abstract class LogProvider
    {
        protected readonly LogConfiguration LogConfiguration;

        protected LogProvider(LogConfiguration logConfiguration)
        {
            this.LogConfiguration = logConfiguration;
        }

        public abstract void Log(BaseMiddlewareModel baseMiddlewareModel);
    }
}