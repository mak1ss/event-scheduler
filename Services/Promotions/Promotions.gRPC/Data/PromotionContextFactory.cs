using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Promotions.gRPC.Data
{
    public class PromotionContextFactory : IDesignTimeDbContextFactory<PromotionContext>
    {
        public PromotionContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Promotions.gRPC"))
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PromotionContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new(optionsBuilder.Options);
        }
    }
}
