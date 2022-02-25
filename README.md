[![.NET](https://github.com/cnrdmrci/TrendyolMiddleware/actions/workflows/deploy.yml/badge.svg?branch=master)](https://github.com/cnrdmrci/TrendyolMiddleware/actions/workflows/deploy.yml)

# TyMiddleware


## Installation

```bash
dotnet add package Trendyol.TyMiddleware
```

## Usage


### Create profile
```cs
public class LogConfigProfile : LogMiddlewareProfile
{
    public LogConfigProfile(ILogger<LogConfigProfile> logger)
    {
        LogType = LogType.Console;
    }
}
```

### Add to project
```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddTyMiddleware(config =>
    {
        config.AddMiddlewareProfileType(typeof(LogConfigProfile));
    });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseTyMiddleware();
}
```


## License

This project is licensed under the MIT License
