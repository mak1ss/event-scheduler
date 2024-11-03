using Events.DAL.Data;
using Events.DAL.Data.Repositories;
using Events.DAL.Interfaces;
using Events.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.DAL
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EventContext>(options =>
            {
                string connectionString = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITagRepository, TagRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
