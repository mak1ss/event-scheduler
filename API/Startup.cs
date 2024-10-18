using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Reflection;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TicketDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
