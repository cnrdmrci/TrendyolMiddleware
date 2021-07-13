using System.Linq;
using System.Threading.Tasks;
using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Configuration;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.LogHelper;
using Trendyol.TyMiddleware.Profile;

namespace Trendyol.TyMiddleware.Middlewares
{
    public class LogMiddleware : IBaseMiddleware
    {
        private readonly LogMiddlewareProfile _logProfile;

        public LogMiddleware()
        {
            _logProfile = BaseConfiguration.GetBaseProfiles().OfType<LogMiddlewareProfile>().FirstOrDefault();
        }

        public Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            return Task.CompletedTask;
        }

        public Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            LogFactory logFactory = LogTypeSelector.GetLogMethod(_logProfile);
            logFactory.Log(baseMiddlewareModel);
            
            return Task.CompletedTask;
        }
    }
}