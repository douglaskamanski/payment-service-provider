using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Dtos;

namespace payment_service_provider.Services;

public class PayableService : IPayableService
{
    private readonly IPayableRepository _payableRepository;
    private readonly IMapper _mapper;

    public PayableService(IPayableRepository payableRepository, IMapper mapper)
    {
        _payableRepository = payableRepository;
        _mapper = mapper;
    }

    public IEnumerable<ReadPayableDto> ListPaidPayables()
    {
        return _mapper.Map<List<ReadPayableDto>>(_payableRepository.ListPaidPayables());
    }

    public IEnumerable<ReadPayableDto> ListWaitingFundsPayables()
    {
        return _mapper.Map<List<ReadPayableDto>>(_payableRepository.ListWaitingFundsPayables());
    }

    public ReadTotalValuesPayablesDto TotalValuesPayables()
    {
        return new()
        {
            TotalValuePaid = _payableRepository.TotalValuePaidPayables(),
            TotalValueWaitingFunds = _payableRepository.TotalValueWaitingFundsPayables()
        };
    }
}
