using EFCoreReproduce;
using Microsoft.EntityFrameworkCore;

namespace TestProject;

public class InMemoryDbBuilder : Dictionary<Type, IList<object>>
{
    public InMemoryDbBuilder Add<T>(IEnumerable<T> testData) where T : class
    {
        var key = typeof(T);
        if (!ContainsKey(key))
            Add(key, []);

        foreach (var item in testData)
        {
            this[key].Add(item);
        }

        return this;
    }

    public async Task<DatabaseExtContext> Build()
    {
        var options = new DbContextOptionsBuilder<DatabaseExtContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var dbContext = new DatabaseExtContext(options);

        foreach (var (entityType, testData) in this)
        {
            (GetType()?.GetMethod("AddTestData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
                                      .MakeGenericMethod(entityType))?.Invoke(this, new object[] { dbContext, testData });

            await dbContext.SaveChangesAsync();
        }

        return dbContext;
    }

    private void AddTestData<TEntity>(DatabaseExtContext dbContext, IList<object> testData) where TEntity : class
    {
        dbContext.WriteSet<TEntity>().AddRange(testData.Cast<TEntity>());
    }

}
