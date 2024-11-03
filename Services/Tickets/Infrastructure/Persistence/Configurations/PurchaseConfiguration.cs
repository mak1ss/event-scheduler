
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable(nameof(Purchase));

            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.PaymentMethod)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PurchasedTime)
                .IsRequired();

            builder.Property(p => p.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasMany(p => p.PurchasedTickets)
                .WithOne(t => t.Purchase)
                .HasForeignKey(t => t.PurchaseId);

            builder.Property(p => p.IsPromoCodeUsed)
                .IsRequired();
        }
    }
}
