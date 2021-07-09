using System.Threading.Tasks;
using TrendyolMiddleware.Model;

namespace TrendyolMiddleware.BaseMiddleware
{
    public interface IBaseMiddleware
    {
        Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel);
        Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel);
    }
}