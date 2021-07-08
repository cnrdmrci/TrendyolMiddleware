using System.Threading.Tasks;
using TrendyolMiddleware.MiddlewareManagement.BaseMiddleware;
using TrendyolMiddleware.Model;

namespace TrendyolMiddleware.SpecialMiddlewares
{
    public class LogMiddleware : IBaseMiddleware
    {
        public LogMiddleware()
        {
            
        }
        public Task BeforeDelegateHandle(MiddlewareInformation middlewareInformation)
        {
            throw new System.NotImplementedException();
        }

        public Task AfterDelegateHandle(MiddlewareInformation middlewareInformation)
        {
            throw new System.NotImplementedException();
        }
    }
}