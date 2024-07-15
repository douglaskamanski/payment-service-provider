using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Dtos;
using payment_service_provider.Models;

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

    public async Task<Response<IEnumerable<ReadPayableDto>>> ListPaidPayables()
    {
        var listPaidPayablesDto = _mapper.Map<List<ReadPayableDto>>(await _payableRepository.ListPaidPayables());

        Response<IEnumerable<ReadPayableDto>> response = new()
        {
            Success = true,
            Message = "List all paid payables.",
            Data = listPaidPayablesDto
        };

        return response;
    }

    public async Task<Response<IEnumerable<ReadPayableDto>>> ListWaitingFundsPayables()
    {
        var listWaitingFundsPayables = _mapper.Map<List<ReadPayableDto>>(await _payableRepository.ListWaitingFundsPayables());

        Response<IEnumerable<ReadPayableDto>> response = new()
        {
            Success = true,
            Message = "List all waiting funds payables.",
            Data = listWaitingFundsPayables
        };

        return response;
    }

    public async Task<Response<ReadTotalValuesPayablesDto>> TotalValuesPayables()
    {
        ReadTotalValuesPayablesDto readTotalValuesPayablesDto = new()
        {
            TotalValuePaid = await _payableRepository.TotalValuePaidPayables(),
            TotalValueWaitingFunds = await _payableRepository.TotalValueWaitingFundsPayables()
        };

        Response<ReadTotalValuesPayablesDto> response = new()
        {
            Success = true,
            Message = "Total values of paid and waiting funds payables.",
            Data = readTotalValuesPayablesDto
        };

        return response;
    }
}
