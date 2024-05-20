using AutoMapper;
using payment_service_provider.Dtos;
using payment_service_provider.Models;

namespace payment_service_provider.Profiles;

public class PayableProfile : Profile
{
    public PayableProfile()
    {
        CreateMap<Payable, ReadPayableDto>();
    }
}
