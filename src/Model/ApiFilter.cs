namespace Trendyol.TyMiddleware
{
    public class ApiFilter
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public ApiFilterFieldDetail ApiFilterFieldDetail { get; set; }
    }
}