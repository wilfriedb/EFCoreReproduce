namespace EFCoreReproduce.Entities;

public class PaymentOrder
{
    public long Id { get; set; }

    public DateOnly ValueDate { get; set; }

    /// <summary>
    /// Amount to transfer in this payment order
    /// <para>Always a positive number</para>
    /// </summary>
    public decimal Amount { get; set; }
}
