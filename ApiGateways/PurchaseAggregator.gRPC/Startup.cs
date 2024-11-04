using API.Filters;
using Application.Protos;
using Events.WEBAPI.Protos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PurchaseAggregator.gRPC.ExceptionHandling;
using PurchaseAggregator.gRPC.Service;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PurchaseAggregator.gRPC
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
            services.AddGrpcClient<EventProtoService.EventProtoServiceClient>(grpcClient =>
            {
                grpcClient.Address = new Uri(Configuration["GrpcSettings:EventsUrl"]);
            });
            services.AddGrpcClient<PurchaseProtoService.PurchaseProtoServiceClient>(grpcClient =>
            {
                grpcClient.Address = new Uri(Configuration["GrpcSettings:TicketsUrl"]);
            });

            services.AddSingleton<EventPurchaseService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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
            services.AddExceptionHandler<PromoCodeNotValidExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "EventPurchaseAggregator.API",
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
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EventPurchaseAggregator.API");
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
