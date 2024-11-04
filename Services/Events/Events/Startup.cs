using Events.DAL;
using Events.WEBAPI.ExceptionHandling;
using Events.WEBAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Events.BLL;
using Events.BLL.Services.Grpc;

namespace Events.WEBAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddBll();
            services.AddDal(Configuration);

            services.Configure<ApiBehaviorOptions>(options
                        => options.SuppressModelStateInvalidFilter = true);
            services.AddScoped<ValidationFilter>();

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Event.API",
                    Version = "v1"
                });
            });

            services.AddProblemDetails();

            services.AddExceptionHandler<BadRequestExceptionHandler>();
            services.AddExceptionHandler<EntityNotFoundExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
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
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Event.API");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseExceptionHandler();
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GrpcEventService>();
                endpoints.MapControllers();
            });

            app.UseCors("AllowAll");
        }
    }
}
