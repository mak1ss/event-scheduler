using Events.DAL.Configs;
using Events.DAL.Entities;
using Events.DAL.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Events.DAL
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

            var categories = Seeder.GenerateCategories(5).ToList();
            var tags = Seeder.GenerateTags(10).ToList();
            var events = Seeder.GenerateEvents(20, categories).ToList();

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Tag>().HasData(tags);
            modelBuilder.Entity<Event>().HasData(events);
        }
    }
}
