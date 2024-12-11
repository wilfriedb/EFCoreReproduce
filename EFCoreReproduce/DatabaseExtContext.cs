using EFCoreReproduce.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace EFCoreReproduce;

public class DatabaseExtContext : DatabaseContext
{
    public new IQueryable<PaymentOrder> PaymentOrders => Set<PaymentOrder>();
    public new IQueryable<CommandAuditLogEntry> CommandLogEntries => Set<CommandAuditLogEntry>();

    public readonly List<BaseQueryFilter> siloFilters = [];

    public DatabaseExtContext(DbContextOptions<DatabaseExtContext> options) : base(options)
    {
    }

    public new IQueryable<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>()
            .AsNoTracking()
            .AsSplitQuery()
            .AsExpandable(); //Enable LinqKit support
    }

    public DbSet<TEntity> WriteSet<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }
}
