namespace EFCoreReproduce;

public class PaymentModel : BaseCreatedEntity<long>
{
    public required string ValueDate { get; init; }

    public required decimal Amount { get; init; }
}
