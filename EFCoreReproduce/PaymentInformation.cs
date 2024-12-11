namespace EFCoreReproduce;

public record PaymentInformation
{
    public required string ValueDate { get; set; }
    public required decimal Amount { get; set; }
}
