using System;
using System.Collections.Generic;

namespace TrendyolMiddleware.Model
{
    public class BaseMiddlewareModel
    {
        public string Id { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public bool HasError { get; set; }
        public string HttpMethod { get; set; }
        public int ProcessingTime { get; set; }
        public DateTime CallDate { get; set; }
        public Dictionary<string,string> Headers { get; set; }
        public string RequestUri { get; set; }
        public int ResponseStatusCode { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string FullAction { get; set; }
    }
}