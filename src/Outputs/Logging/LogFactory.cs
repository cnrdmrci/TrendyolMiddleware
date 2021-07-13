using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Profile;

namespace Trendyol.TyMiddleware.Outputs.Logging.Abstract
{
    public abstract class LogFactory
    {
        protected readonly LogMiddlewareProfile LogProfile;

        protected LogFactory(LogMiddlewareProfile logProfile)
        {
            this.LogProfile = logProfile;
        }

        public abstract void Log(BaseMiddlewareModel baseMiddlewareModel);
    }
}