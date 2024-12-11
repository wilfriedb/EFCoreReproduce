using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace EFCoreReproduce;

public abstract class RepositoryBase<TPH>  where TPH : class
{
    protected RepositoryBase(DatabaseExtContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = DbContext.Set<TPH>().AsExpandableEFCore().AsNoTracking();
    }

    public DatabaseExtContext DbContext { get; }

    /// <summary>
    /// The property DbSet enables LinqKit
    /// </summary>
    public IQueryable<TPH> DbSet { get; }
}

