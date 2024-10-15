using EF_ServcieManagement.DAL.Configs;
using EF_ServcieManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_ServcieManagement.DAL
{
    public class EventContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
