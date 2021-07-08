using System.Collections.Generic;
using TrendyolMiddleware.BaseMiddleware;

namespace TrendyolMiddleware.Configuration
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