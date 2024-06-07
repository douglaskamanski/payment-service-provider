using payment_service_provider.Dtos;
using payment_service_provider.Models;

namespace payment_service_provider.tests.MockData;

public class PayableMockData
{
    public static IEnumerable<ReadPayableDto> ListPaidPayablesDtoMockData()
    {
        return new List<ReadPayableDto> {
            new ReadPayableDto {
                Value = 660.50m,
                Status = Enums.PaymentStatus.Paid,
                PaymentDate = DateTime.Now
            },
            new ReadPayableDto {
                Value = 100m,
                Status = Enums.PaymentStatus.Paid,
                PaymentDate = DateTime.Parse("11/11/2023")
            },
            new ReadPayableDto {
                Value = 225.33m,
                Status = Enums.PaymentStatus.Paid,
                PaymentDate = DateTime.Parse("25/02/2023")
            }
        };
    }

    public static IEnumerable<ReadPayableDto> ListWaitingFundsPayablesDtoMockData()
    {
        return new List<ReadPayableDto> {
            new ReadPayableDto {
                Value = 770.70m,
                Status = Enums.PaymentStatus.WaitingFunds,
                PaymentDate = DateTime.Now
            },
            new ReadPayableDto {
                Value = 325m,
                Status = Enums.PaymentStatus.WaitingFunds,
                PaymentDate = DateTime.Parse("15/05/2023")
            },
            new ReadPayableDto {
                Value = 99.90m,
                Status = Enums.PaymentStatus.WaitingFunds,
                PaymentDate = DateTime.Parse("19/06/2023")
            }
        };
    }

    public static ReadTotalValuesPayablesDto TotalValuesPayablesDtoMockData()
    {
        return new ReadTotalValuesPayablesDto
        {
            TotalValuePaid = 999.10m,
            TotalValueWaitingFunds = 1560.85m
        };
    }

    public static IEnumerable<Payable> ListPaidPayablesMockData()
    {
        return new List<Payable> {
            new Payable {
                Id = 1,
                Value = 660.50m,
                Status = Enums.PaymentStatus.Paid,
                PaymentDate = DateTime.Parse("11/11/2023")
            },
            new Payable {
                Id = 2,
                Value = 100m,
                Status = Enums.PaymentStatus.Paid,
                PaymentDate = DateTime.Parse("01/03/2024")
            },
            new Payable {
                Id = 3,
                Value = 225.33m,
                Status = Enums.PaymentStatus.Paid,
                PaymentDate = DateTime.Parse("12/02/2024")
            }
        };
    }

    public static IEnumerable<Payable> ListWaitingFundsPayablesMockData()
    {
        return new List<Payable> {
            new Payable {
                Id = 10,
                Value = 660.50m,
                Status = Enums.PaymentStatus.WaitingFunds,
                PaymentDate = DateTime.Parse("06/08/2023")
            },
            new Payable {
                Id = 20,
                Value = 100m,
                Status = Enums.PaymentStatus.WaitingFunds,
                PaymentDate = DateTime.Parse("20/09/2023")
            },
            new Payable {
                Id = 30,
                Value = 225.33m,
                Status = Enums.PaymentStatus.WaitingFunds,
                PaymentDate = DateTime.Parse("30/10/2023")
            }
        };
    }

    public static decimal TotalValuePaidPayablesMockData()
    {
        return 9670.95m;
    }

    public static decimal TotalValueWaitingFundsPayablesMockData()
    {
        return 17933.88m;
    }
}
