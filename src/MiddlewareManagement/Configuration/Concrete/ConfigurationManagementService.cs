using System.Collections.Generic;
using TrendyolMiddleware.MiddlewareManagement.BaseMiddleware;
using TrendyolMiddleware.SpecialMiddlewares;

namespace TrendyolMiddleware.MiddlewareManagement.Configuration.Concrete
{
    public class ConfigurationManagementService : IConfigurationManagementService
    {
        private List<IBaseMiddleware> _baseMiddlewares;
        
        public void ConfigureMiddleware()
        {
            _baseMiddlewares = new List<IBaseMiddleware>()
            {
                new LogMiddleware()
            };
        }

        public List<IBaseMiddleware> GetMiddlewareDelegateHandlers()
        {
            return new List<IBaseMiddleware>()
            {
                new LogMiddleware()
            };
        }
    }
}