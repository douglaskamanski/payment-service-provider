namespace payment_service_provider.Domain.Fees;

public interface IComputeFee
{
    decimal Compute(decimal value, IFee fee);
}
