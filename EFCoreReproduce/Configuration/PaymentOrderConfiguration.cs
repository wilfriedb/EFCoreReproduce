using EFCoreReproduce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreReproduce.Configuration;

internal class PaymentOrderConfiguration : IEntityTypeConfiguration<PaymentOrder>
{
    public void Configure(EntityTypeBuilder<PaymentOrder> builder)
    {
        builder
            .ToTable("PaymentOrders")
            .HasKey(self => self.Id);

        builder
            .Property(self => self.Id)
                .ValueGeneratedOnAdd();

        builder
            .Property(self => self.ValueDate)
                .HasColumnType(SqlDataType.ValueDate);

        builder
            .Property(self => self.Amount)
                .HasColumnType(SqlDataType.Amount);
    }
}
