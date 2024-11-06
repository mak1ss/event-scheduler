using EventAggregator.ExceptionHandling;
using EventAggregator.Services.Implementations;
using EventAggregator.Services.Interfaces;

namespace EventAggregator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IFeedbackService, FeedbackService>(c =>
            {
                c.BaseAddress = new Uri(Configuration["APIUrls:FeedbackAPI"]);
                c.Timeout = TimeSpan.FromSeconds(30);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                return handler;
            });
                    
            services.AddHttpClient<IEventService, EventService>(c => {
                c.BaseAddress = new Uri(Configuration["APIUrls:EventAPI"]);
                c.Timeout = TimeSpan.FromSeconds(30);
            
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                return handler;
            });

            services.AddControllers();

            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "EventAggregator.API",
                    Version = "v1"
                });
            });

            services.AddProblemDetails();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "EventAggregator.API");
                        options.RoutePrefix = string.Empty;
                    });
                }
            }

            app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
