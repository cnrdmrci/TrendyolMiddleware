using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.LogConfig;

namespace Trendyol.TyMiddleware.Outputs.Logging.Abstract
{
    public abstract class LogFactory
    {
        protected readonly LogProfile LogProfile;

        protected LogFactory(LogProfile logProfile)
        {
            this.LogProfile = logProfile;
        }

        public abstract void Log(BaseMiddlewareModel baseMiddlewareModel);
    }
}