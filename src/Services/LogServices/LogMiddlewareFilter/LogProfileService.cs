using System.Collections.Generic;
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

            foreach (var apiFilter in apiFilters)
            {
                bool isApiFilterSuccess = true;
                
                isApiFilterSuccess = ApiFilterControl(isApiFilterSuccess, apiFilter.Controller,baseMiddlewareModel.Controller);
                isApiFilterSuccess = ApiFilterControl(isApiFilterSuccess, apiFilter.Action,baseMiddlewareModel.Action);
                isApiFilterSuccess = ApiFilterControl(isApiFilterSuccess, apiFilter.HttpMethod,baseMiddlewareModel.HttpMethod);

                if (isApiFilterSuccess)
                    return apiFilter;
            }

            return null;
        }

        private bool ApiFilterControl(bool isApiFilterSuccess, string filterModelField, string middlewareModelField)
        {
            var isApiFilterSuccessLocal = isApiFilterSuccess;
            
            if (isApiFilterSuccessLocal && !string.IsNullOrWhiteSpace(filterModelField))
            {
                if (filterModelField != middlewareModelField)
                {
                    isApiFilterSuccessLocal = false;
                }
            }

            return isApiFilterSuccessLocal;
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