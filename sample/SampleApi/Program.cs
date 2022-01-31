using SampleApi;
using SampleApi.Services;
using Trendyol.TyMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddTyMiddleware(config =>
{
    config.AddMiddlewareProfileType(typeof(LogConfigProfile));
});


var app = builder.Build();

app.UseTyMiddleware();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();