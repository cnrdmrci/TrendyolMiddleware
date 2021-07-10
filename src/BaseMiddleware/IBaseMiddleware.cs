using System.Threading.Tasks;
using Trendyol.TyMiddleware.Model;

namespace Trendyol.TyMiddleware.BaseMiddleware
{
    public interface IBaseMiddleware
    {
        Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel);
        Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel);
    }
}