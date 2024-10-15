using EF_ServcieManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EF_ServcieManagement.DAL.Seeding;


namespace EF_ServcieManagement.DAL.Configs
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(s => s.Id)
                    .UseIdentityColumn()
                    .IsRequired();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            builder.Property(s => s.Price)
                   .IsRequired()
                   .HasColumnType("decimal(10, 2)");

            builder.Property(s => s.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(s => s.UpdatedAt);

            builder.HasOne(s => s.Category)
                   .WithMany(c => c.Event)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Tags)
               .WithMany(t => t.Event)
               .UsingEntity(j => j.ToTable("eventTag"));

            new ServiceSeeder().Seed(builder);
        }
    }
}
