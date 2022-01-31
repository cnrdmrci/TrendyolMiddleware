using SampleApi.Services;
using Trendyol.TyMiddleware;

namespace SampleApi;

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