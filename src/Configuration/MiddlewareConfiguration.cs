using System;
using System.Collections.Generic;
using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Profile;

namespace Trendyol.TyMiddleware.Configuration
{
    public class MiddlewareConfiguration
    {
        public void AddMiddleware(IBaseMiddleware middleware)
        {
            BaseConfiguration.AddMiddleware(middleware);
        }
        
        public void AddMiddlewareProfileType(Type type)
        {
            if (!type.IsSubclassOf(typeof(LogMiddlewareProfile)))
            {
                throw new Exception("You can send only inherited TyMiddlewareProfile abstract class");
            }

            BaseConfiguration.AddType(type);
        }

        public void AddMiddlewares(List<IBaseMiddleware> middlewares)
        {
            BaseConfiguration.AddMiddlewares(middlewares);
        }
    }
}