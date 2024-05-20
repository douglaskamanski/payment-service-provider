namespace payment_service_provider.Domain.Fees;

public class CreditCardFee : IFee
{
    private const decimal _fee = 0.05m;

    public decimal Compute(decimal value)
    {
        return value * _fee;
    }
}
