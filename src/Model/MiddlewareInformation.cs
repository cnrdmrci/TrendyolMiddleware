using System;

namespace TrendyolMiddleware.Model
{
    public class MiddlewareInformation 
    {
        public string Id { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public bool HasError { get; set; }
        public string HttpMethod { get; set; }
        public int ProcessingTime { get; set; }
        public DateTime CallDate { get; set; }
        public string Headers { get; set; }
        public string UserAgent { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}