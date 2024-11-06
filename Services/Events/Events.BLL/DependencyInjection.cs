using Events.BLL.DTO.Category;
using Events.BLL.DTO.Events;
using Events.BLL.DTO.Tag;
using Events.BLL.Interfaces.Services;
using Events.BLL.Services;
using Events.BLL.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBll(this IServiceCollection services, IConfiguration config)
        {
            services.AddGrpc();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ITagService, TagService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CategoryRequest>, CategoryRequestValidator>();
            services.AddScoped<IValidator<EventRequest>, EventRequestValidator>();
            services.AddScoped<IValidator<TagRequest>, TagRequestValidator>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config["ConnectionStrings:Redis"];
                options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
                {
                    AbortOnConnectFail = true,
                    EndPoints = { options.Configuration }
                };
            });

            return services;
        }
    }
}
