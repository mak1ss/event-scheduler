using API.ExceptionHandling;
using API.Filters;
using Application;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Text.Json.Serialization;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.Configure<ApiBehaviorOptions>(options
                        => options.SuppressModelStateInvalidFilter = true);
            services.AddScoped<ValidationFilter>();

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
            services.AddControllers()
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        });

            services.AddExceptionHandler<BadRequestExceptionHandler>();
            services.AddExceptionHandler<EntityNotFoundExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddProblemDetails();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Ticket.API",
                    Version = "v1"
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket.API");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
