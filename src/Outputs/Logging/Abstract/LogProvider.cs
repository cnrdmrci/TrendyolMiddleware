using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;

namespace Trendyol.TyMiddleware.Outputs.Logging.Abstract
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