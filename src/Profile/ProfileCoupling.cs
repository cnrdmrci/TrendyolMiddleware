using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Middlewares;

namespace Trendyol.TyMiddleware.Profile
{
    public static class ProfileCoupling
    {
        public static IBaseMiddleware GetBaseMiddleware(IBaseProfile baseProfile)
        {
            if (baseProfile is LogMiddlewareProfile)
            {
                return new LogMiddleware();
            }

            return null;
        }
    }
}