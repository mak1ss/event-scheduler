using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Seeding;


namespace Persistence
{
    public class TicketDbContext : DbContext
    {

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            var purchases = PurchaseSeeder.GeneratePurchases(10);
            var tickets = PurchaseSeeder.GenerateTickets(30, purchases);

            modelBuilder.Entity<Purchase>().HasData(purchases); 
            modelBuilder.Entity<Ticket>().HasData(tickets);
            
        }
    }
}
