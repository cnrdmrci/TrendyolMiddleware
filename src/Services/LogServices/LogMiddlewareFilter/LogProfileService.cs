using System.Collections.Generic;
using System.Linq;
using Trendyol.TyMiddleware.Configuration;
using Trendyol.TyMiddleware.Extensions;

namespace Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter
{
    public class LogProfileService : ILogProfileService
    {
        private readonly LogMiddlewareProfile _logProfile;
        public LogProfileService()
        {
            _logProfile = BaseConfiguration.GetProfile<LogMiddlewareProfile>();
        }
        public LogMiddlewareProfile GetLogMiddlewareProfile()
        {
            return _logProfile;
        }

        public ApiFilter GetApiFilter(BaseMiddlewareModel baseMiddlewareModel)
        {
            List<ApiFilter> apiFilters = _logProfile?.ApiFilterModel?.ApiFilters;
            if (apiFilters.IsNullOrEmpty()) return null;

            FilterController(apiFilters, baseMiddlewareModel);
            FilterAction(apiFilters, baseMiddlewareModel);
            FilterHttpMethod(apiFilters, baseMiddlewareModel);
            
            return apiFilters?.FirstOrDefault();
        }

        private void FilterController(List<ApiFilter> apiFilters,BaseMiddlewareModel baseMiddlewareModel)
        {
            if (apiFilters.AnyNullSafe() && !string.IsNullOrWhiteSpace(baseMiddlewareModel.Controller))
            {
                apiFilters = apiFilters?.Where(x => x.Controller == baseMiddlewareModel.Controller).ToList();
            }
        }
        
        private void FilterAction(List<ApiFilter> apiFilters,BaseMiddlewareModel baseMiddlewareModel)
        {
            if (apiFilters.AnyNullSafe() && !string.IsNullOrWhiteSpace(baseMiddlewareModel.Action))
            {
                apiFilters = apiFilters?.Where(x => x.Action == baseMiddlewareModel.Action).ToList();
            }
        }
        
        private void FilterHttpMethod(List<ApiFilter> apiFilters,BaseMiddlewareModel baseMiddlewareModel)
        {
            if (apiFilters.AnyNullSafe() && !string.IsNullOrWhiteSpace(baseMiddlewareModel.HttpMethod))
            {
                apiFilters = apiFilters?.Where(x => x.Method == baseMiddlewareModel.HttpMethod).ToList();
            }
        }

        public bool IsLoggingIgnore(BaseMiddlewareModel baseMiddlewareModel)
        {
            if (IsFilterTypeExclude() && !IsApiFilterEmpty(baseMiddlewareModel)) return true;
            
            if (IsFilterTypeInclude() && IsApiFilterEmpty(baseMiddlewareModel)) return true;

            return false;
        }

        private bool IsApiFilterEmpty(BaseMiddlewareModel baseMiddlewareModel)
        {
            return GetApiFilter(baseMiddlewareModel) == null;
        }
        
        private bool IsFilterTypeExclude()
        {
            return _logProfile?.ApiFilterModel?.ApiFilterType == ApiFilterType.Exclude;
        }

        private bool IsFilterTypeInclude()
        {
            return _logProfile?.ApiFilterModel?.ApiFilterType == ApiFilterType.Include;
        }
    }
}