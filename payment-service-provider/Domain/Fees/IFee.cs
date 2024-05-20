namespace payment_service_provider.Domain.Fees;

public interface IFee
{
    decimal Compute(decimal value);
}
