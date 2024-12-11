namespace EFCoreReproduce.Entities;

public class CommandAuditLogEntry
{
    public long Id { get; set; }

    public long? PaymentOrderId { get; set; }

    public PaymentOrder? PaymentOrder { get; set; }

}
