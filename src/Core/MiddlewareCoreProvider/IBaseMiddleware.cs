using System.Threading.Tasks;

namespace Trendyol.TyMiddleware.Core.MiddlewareCoreProvider
{
    public interface IBaseMiddleware
    {
        Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel);
        Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel);
    }
}