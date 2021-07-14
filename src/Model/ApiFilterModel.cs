using System.Collections.Generic;

namespace Trendyol.TyMiddleware.Model
{
    public class ApiFilterModel
    {
        public List<ApiFilter> ApiFilters { get; set; }
        public ApiFilterType ApiFilterType { get; set; }
    }
    public class ApiFilter
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public ApiFilterFieldDetail ApiFilterFieldDetail { get; set; }

        public ApiFilter()
        {
            ApiFilterFieldDetail = new ApiFilterFieldDetail();
        }
        
    }

    public class ApiFilterFieldDetail
    {
        public bool RequestBodyIgnore { get; set; }
        public bool ResponseBodyIgnore { get; set; }
        public bool HeadersIgnore { get; set; }
    }

    public enum ApiFilterType
    {
        Include = 1,
        Exclude = 2
    }
}