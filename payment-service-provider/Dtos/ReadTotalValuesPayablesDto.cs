namespace payment_service_provider.Dtos;

public class ReadTotalValuesPayablesDto
{
    public decimal TotalValuePaid{ get; set; }
    public decimal TotalValueWaitingFunds { get; set; }
}
