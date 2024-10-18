using Events.BLL.Interfaces.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Events.DAL;
using Events.DAL.Interfaces.Repositories;
using Events.DAL.Interfaces;
using FluentValidation.AspNetCore;
using Events.DAL.Data.Repositories;
using Events.DAL.Data;
using Events.BLL.Services;
using Events.WEBAPI.ExceptionHandling;
using Events.BLL.Validations;
using Events.BLL.DTO.Category;
using Events.BLL.DTO.Events;
using Events.BLL.DTO.Tag;
using Events.WEBAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Events.WEBAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddDbContext<EventContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITagRepository, TagRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ITagService, TagService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CategoryRequest>, CategoryRequestValidator>();
            services.AddScoped<IValidator<EventRequest>, EventRequestValidator>();
            services.AddScoped<IValidator<TagRequest>, TagRequestValidator>();

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
                endpoints.MapControllers();
            });
        }
    }
}
