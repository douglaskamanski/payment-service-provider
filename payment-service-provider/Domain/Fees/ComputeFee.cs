namespace payment_service_provider.Domain.Fees;

public class ComputeFee : IComputeFee
{
    public decimal Compute(decimal value, IFee fee)
    {
        return fee.Compute(value);
    }
}
