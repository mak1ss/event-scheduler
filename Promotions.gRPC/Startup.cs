using Microsoft.EntityFrameworkCore;
using Promotions.gRPC.Data;
using Promotions.gRPC.Data.Repositories;
using Promotions.gRPC.Interfaces.Repositories;
using Promotions.gRPC.Services;

namespace Promotions.gRPC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PromotionContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddGrpc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<PromotionService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}

