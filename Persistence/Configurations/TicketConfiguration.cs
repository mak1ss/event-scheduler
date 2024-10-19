using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(t => t.EventId)
                .IsRequired();

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.HasOne(t => t.Purchase)
                .WithMany(p => p.PurchasedTickets)
                .HasForeignKey(t => t.PurchaseId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
