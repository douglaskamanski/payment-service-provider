namespace payment_service_provider.Domain.Fees;

public class DebitCardFee : IFee
{
    private const decimal _fee = 0.03m;

    public decimal Compute(decimal value)
    {
        return value * _fee;
    }
}
