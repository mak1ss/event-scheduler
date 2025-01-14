﻿using ADO_Dapper_ServiceManagment.DAL.infrastructure;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.repositories;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;
using ADO_Dapper_ServiceManagment.DAL.mappers;
using ADO_Dapper_ServiceManagment.DAL.repositories.sql;
using ADO_Dapper_ServiceManagment.DAL.services;
using ADO_Dapper_ServiceManagment.DAL.unitOfWork;

namespace ADO_Dapper_ServiceManagment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<ILikeRepository, LikeRepotisory>();

            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<ILikeService,  LikeService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IConnectionFactory, ConnectionFactory>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddAutoMapper(typeof(DtoMappingProfile));

            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Feedback.API",
                    Version = "v1"
                });
            });
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
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Feedback.API");
                        options.RoutePrefix = string.Empty;
                    });
                }
            }

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
