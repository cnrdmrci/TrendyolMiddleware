using System.Threading.Tasks;
using TrendyolMiddleware.Model;

namespace TrendyolMiddleware.BaseMiddleware
{
    public interface IBaseMiddleware
    {
        Task BeforeDelegateHandle(MiddlewareInformation middlewareInformation);
        Task AfterDelegateHandle(MiddlewareInformation middlewareInformation);
    }
}