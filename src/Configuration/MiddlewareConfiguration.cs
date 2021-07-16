using System;
using System.Collections.Generic;
using System.Linq;
using Trendyol.TyMiddleware.Core.MiddlewareCoreProvider;

namespace Trendyol.TyMiddleware.Configuration
{
    public class MiddlewareConfiguration
    {
        public void AddMiddleware(IBaseMiddleware middleware)
        {
            BaseConfiguration.AddMiddlewareType(middleware.GetType());
        }
        
        public void AddMiddlewareProfileType(Type type)
        {
            BaseConfiguration.AddType(type);
        }

        public void AddMiddlewares(List<IBaseMiddleware> middlewares)
        {
            BaseConfiguration.AddMiddlewares(middlewares.Select(x =>x.GetType()).ToList());
        }
    }
}