using EFCoreReproduce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreReproduce.Configuration
{
    internal class CommandAuditLogEntryConfiguration : IEntityTypeConfiguration<CommandAuditLogEntry>
    {
        public void Configure(EntityTypeBuilder<CommandAuditLogEntry> builder)
        {
            builder
                .ToTable("CommandAuditLog")
                .HasKey(self => self.Id);

            builder
                .Property(self => self.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(self => self.PaymentOrderId);

            builder
                .HasOne(self => self.PaymentOrder)
                .WithMany();

        }
    }
}
