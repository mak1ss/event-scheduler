using Microsoft.EntityFrameworkCore;
using Promotions.gRPC.Entities;
using Promotions.gRPC.Seeding;

namespace Promotions.gRPC.Data
{
    public class PromotionContext : DbContext
    {
        public DbSet<Promotion> Promotions { get; set; }

        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var promotions = PromotionSeeder.GeneratePromotions(10);

            modelBuilder.Entity<Promotion>().HasData(promotions);
        }
    }
}
