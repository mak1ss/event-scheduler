using Microsoft.EntityFrameworkCore;
using Promotions.gRPC.Entities;

namespace Promotions.gRPC.Data
{
    public class PromotionContext : DbContext
    {
        public DbSet<Promotion> Promotions { get; set; }

        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options) { }

    }
}
