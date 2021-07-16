using System;
using System.Collections.Generic;
using Trendyol.TyMiddleware.Core.MiddlewareCoreProvider;

namespace Trendyol.TyMiddleware.Extensions
{
    public static class ServiceExtension
    {
        public static List<IBaseMiddleware> CreateServices(this List<Type> middlewares, IServiceProvider serviceProvider)
        {
            var baseMiddlewares = new List<IBaseMiddleware>();
            
            if (middlewares.AnyNullSafe())
            {
                middlewares.ForEach(x =>
                {
                    var baseMiddleware = (IBaseMiddleware) serviceProvider.GetService(x);
                    baseMiddlewares.Add(baseMiddleware);
                });
            }

            return baseMiddlewares;
        }
    }
}