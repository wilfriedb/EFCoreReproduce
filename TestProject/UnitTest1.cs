using EFCoreReproduce;
using EFCoreReproduce.Entities;

namespace TestProject;

public class UnitTest1
{
    [Fact]
    public async Task GetCommands_WithAllInSilo_ReturnsAllCommands()
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
