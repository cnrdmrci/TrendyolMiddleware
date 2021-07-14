using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Configuration;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Outputs.Logging.Abstract;
using Trendyol.TyMiddleware.Outputs.Logging.LogHelper;
using Trendyol.TyMiddleware.Profile;
using TrendyolMiddleware.Utils;

namespace Trendyol.TyMiddleware.Middlewares
{
    public class LogMiddleware : IBaseMiddleware
    {
        private readonly LogMiddlewareProfile _logProfile;

        public LogMiddleware()
        {
            _logProfile = BaseConfiguration.GetBaseProfiles().OfType<LogMiddlewareProfile>().FirstOrDefault();
        }

        public Task RequestHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            return Task.CompletedTask;
        }

        public Task ResponseHandler(BaseMiddlewareModel baseMiddlewareModel)
        {
            ApiFilter apiFilter = GetApiFilter(baseMiddlewareModel);
            if (apiFilter != null)
            {
                LogFactory logFactory = LogTypeSelector.GetLogMethod(_logProfile);
                logFactory.Log(baseMiddlewareModel,apiFilter);
            }
            
            return Task.CompletedTask;
        }

        private ApiFilter GetApiFilter(BaseMiddlewareModel baseMiddlewareModel)
        {
            ApiFilterModel apiFilterModel = _logProfile.ApiFilterModel;
            List<ApiFilter> apiFilters = apiFilterModel.ApiFilters;
            
            if (!apiFilters.IsNullOrEmpty() && !string.IsNullOrWhiteSpace(baseMiddlewareModel.Controller))
            {
                apiFilters = apiFilters.Where(x => x.Controller == baseMiddlewareModel.Controller).ToList();
            }
            if(!apiFilters.IsNullOrEmpty() && !string.IsNullOrWhiteSpace(baseMiddlewareModel.Action))
            {
                apiFilters = apiFilters.Where(x => x.Action == baseMiddlewareModel.Action).ToList();
            }
            if(!apiFilters.IsNullOrEmpty() && !string.IsNullOrWhiteSpace(baseMiddlewareModel.HttpMethod))
            {
                apiFilters = apiFilters.Where(x => x.Method == baseMiddlewareModel.HttpMethod).ToList();
            }
            
            if (apiFilterModel.ApiFilterType == ApiFilterType.Exclude && apiFilters.Any())
            {
                return null;
            }
            
            if (apiFilterModel.ApiFilterType == ApiFilterType.Include)
            {
                return apiFilters.FirstOrDefault();
            }

            return new ApiFilter();
        }
    }
}