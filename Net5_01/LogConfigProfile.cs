using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Net5_01.NewTest;
using Trendyol.TyMiddleware.Enums;
using Trendyol.TyMiddleware.Model;
using Trendyol.TyMiddleware.Profile;

namespace Net5_01
{
    public class LogConfigProfile : LogMiddlewareProfile
    {
        public LogConfigProfile(ILogger<LogConfigProfile> logger, ITestService testService)
        {
            LogType = LogType.Console;
            
            ApiFilterModel = new ApiFilterModel()
            {
                ApiFilterType = ApiFilterType.Include,
                ApiFilters = new List<ApiFilter>()
                {
                    new ApiFilter
                    {
                        Controller = "WeatherForecast",
                        Method = "GET"
                    }
                }
            };
            
            AddCustomFields("field_1","field_value_1");

            Console.WriteLine(testService.GetTestMessage());
        }

    }
}