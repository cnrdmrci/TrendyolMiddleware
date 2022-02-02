using SampleApi.Services;
using Trendyol.TyMiddleware;

namespace SampleApi;

public class LogConfigProfile : LogMiddlewareProfile
{
    public LogConfigProfile(ITestService testService)
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
                    HttpMethod = "POST",
                    ApiFilterFieldDetail = new ApiFilterFieldDetail()
                    {
                        ResponseBodyIgnore = true
                    }
                },
                new ApiFilter
                {
                    Controller = "WeatherForecast",
                    HttpMethod = "GET",
                    Action = "GetVersion2"
                }
            }
        };

        SecurePasswordLogModel = new SecurePasswordLogModel()
        {
            SecurePasswordLogEnabled = true,
            CaseSensitiveEnabled = false,
            PasswordFieldNames = new List<string>()
            {
                "password"
            }
        };
            
        AddCustomFields("field_1","field_value_1");

        Console.WriteLine(testService.GetTestMessage());
    }

}