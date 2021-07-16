namespace Trendyol.TyMiddleware
{
    public class ApiFilterFieldDetail
    {
        public bool RequestBodyIgnore { get; set; }
        public bool ResponseBodyIgnore { get; set; }
        public bool HeadersIgnore { get; set; }
    }
}