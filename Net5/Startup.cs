using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TrendyolMiddleware.Extensions;
using TrendyolMiddleware.Middlewares;
using TrendyolMiddleware.Outputs.Logging.Concrete;
using TrendyolMiddleware.Outputs.Logging.LogConfig;

namespace Net5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Net5", Version = "v1"}); });
            services.AddTrendyolMiddleware();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5 v1"));
            }
                    
            app.UseTrendyolMiddleware(config =>
            {
                config.AddMiddleware(new LogMiddleware(new LogConfiguration()
                {
                    LogType = LogType.Console,
                    FieldDescriptionListForConstant = new List<FieldDescription>()
                    {
                        new FieldDescription()
                        {
                            FieldName = "test_field1",
                            FieldValue = "test_field_value1"
                        },
                        new FieldDescription()
                        {
                            FieldName = "test_field2",
                            FieldValue = "test_field_value2"
                        }
                    },
                    FieldDescriptionListForHeaderKey = new List<HeaderFieldDesctiption>()
                    {
                        new HeaderFieldDesctiption()
                        {
                            FieldName = "test_header_field1",
                            HeaderKeyForFieldValue = "test_header_field_value1"
                        },
                        new HeaderFieldDesctiption()
                        {
                            FieldName = "test_header_field2",
                            HeaderKeyForFieldValue = "test_header_field_value2"
                        }
                    }
                }));
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}