using System.Collections.Generic;
using TrendyolMiddleware.MiddlewareManagement.BaseMiddleware;

namespace TrendyolMiddleware.MiddlewareManagement.Configuration
{
    public interface IConfigurationManagementService
    {
        void ConfigureMiddleware();
        List<IBaseMiddleware> GetMiddlewareDelegateHandlers();
    }
}