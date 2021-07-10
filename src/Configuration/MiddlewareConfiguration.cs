using System.Collections.Generic;
using Trendyol.TyMiddleware.BaseMiddleware;

namespace Trendyol.TyMiddleware.Configuration
{
    public class MiddlewareConfiguration
    {
        public void AddMiddleware(IBaseMiddleware middleware)
        {
            BaseConfiguration.AddMiddleware(middleware);
        }

        public void AddMiddlewares(List<IBaseMiddleware> middlewares)
        {
            BaseConfiguration.AddMiddlewares(middlewares);
        }
    }
}