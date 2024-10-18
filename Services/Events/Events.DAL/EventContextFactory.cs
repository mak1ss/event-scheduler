using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Events.DAL
{
    public class EventContextFactory : IDesignTimeDbContextFactory<EventContext>
    {
        public EventContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Event"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EventContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new(optionsBuilder.Options);
        }
    }
}
