using System.Reflection;
using EFCoreReproduce.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreReproduce;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PaymentOrder> PaymentOrders { get; set; } = null!;

    public DbSet<CommandAuditLogEntry> CommandLogEntries { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            // Default schema dbo is needed otherwise it is omitted from generated sql scripts,
            // and within DNB the schema will be the user name, not dbo.
            .HasDefaultSchema("dbo")
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
