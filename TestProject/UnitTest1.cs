using EFCoreReproduce;
using EFCoreReproduce.Entities;

namespace TestProject;

public class UnitTest1
{
    /// <summary>
    /// This unit test will succeed with dotnet 8 / ef core 8, but fail with dotnet 9 / .ef core 9
    /// This code will succeed with dotnet 9 / ef core 9 with a small modification in the MapperProfile class
    /// as noted there
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCommands_ReturnsAllCommands()
    {
        // arrange
        using var dbContext = await new InMemoryDbBuilder().Add(GenerateCommandAuditLogEntries(5)).Build();

        var commandRepository = new CommandRepository(dbContext);

        // act
        var commands = commandRepository.GetAllExecutedCommands(DateOnly.FromDateTime(DateTime.UtcNow));

        // Assert
        Assert.Equal(5, commands.Count());
    }

    private static List<CommandAuditLogEntry> GenerateCommandAuditLogEntries(int count)
    {
        var entries = new List<CommandAuditLogEntry>();

        // Generate test data for PaymentOrder
        var paymentOrders = GeneratePaymentOrders(count);

        for (var i = 0; i < count; i++)
        {
            entries.Add(new CommandAuditLogEntry
            {
                PaymentOrder = paymentOrders[i]
            });
        }

        return entries;
    }

    private static List<PaymentOrder> GeneratePaymentOrders(int count)
    {
        var paymentOrders = new List<PaymentOrder>();
        for (var i = 0; i < count; i++)
        {
            paymentOrders.Add(new PaymentOrder
            {
                ValueDate = DateOnly.FromDateTime(DateTime.UtcNow)
            });
        }
        return paymentOrders;
    }
}
