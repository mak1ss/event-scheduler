using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public class TicketDbContext : DbContext
    {

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) 
        {
        }
    }
}
