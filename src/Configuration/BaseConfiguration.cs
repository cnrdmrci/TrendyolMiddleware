using System.Collections.Generic;
using Trendyol.TyMiddleware.BaseMiddleware;

namespace Trendyol.TyMiddleware.Configuration
{
    public static class BaseConfiguration
    {
        private static readonly List<IBaseMiddleware> BaseMiddlewares;

        static BaseConfiguration()
        {
            BaseMiddlewares = new List<IBaseMiddleware>();
        }

        public static void AddMiddleware(IBaseMiddleware baseMiddleware)
        {
            BaseMiddlewares.Add(baseMiddleware);
        }
        
        public static void AddMiddlewares(List<IBaseMiddleware> baseMiddlewares)
        {
            BaseMiddlewares.AddRange(baseMiddlewares);
        }

        public static List<IBaseMiddleware> GetMiddlewares()
        {
            return BaseMiddlewares;
        }
    }
}