using payment_service_provider.Dtos;
using payment_service_provider.Models;
using payment_service_provider.ValueObjects;

namespace payment_service_provider.tests.MockData;

public class TransactionMockData
{
    public static Response<IEnumerable<ReadTransactionDto>> ListAllTransactionsDtoMockData()
    {
        var list = new List<ReadTransactionDto>
        {
            new ReadTransactionDto {
                Value = 7490.25m,
                Description = "Pagamento Super Bikes",
                PaymentMethod = Enums.PaymentMethod.DebitCard,
                CardLastFourDigits = "0912",
                CardName = "ROSBALDO ATGE",
                CardExpirationDate = DateTime.Parse("11/2027"),
                CardCvv = "001",
                CreatedDate = DateTime.Now
            },
            new ReadTransactionDto {
                Value = 1250.66m,
                Description = "Pagamento Super Bikes",
                PaymentMethod = Enums.PaymentMethod.CreditCard,
                CardLastFourDigits = "8912",
                CardName = "DUARTE LIMA",
                CardExpirationDate = DateTime.Parse("06/2028"),
                CardCvv = "8712",
                CreatedDate = DateTime.Now
            }
        };

        Response<IEnumerable<ReadTransactionDto>> response = new()
        {
            Success = true,
            Message = "List all transactions created.",
            Data = list
        };
        
        return response;
    }

    public static IEnumerable<Transaction> ListAllTransactionsMockData()
    {
        return new List<Transaction>
        {
            new Transaction {
                Id = 1,
                Value = 7490.25m,
                Description = "Pagamento Super Bikes",
                PaymentMethod = Enums.PaymentMethod.DebitCard,
                Card = Card.Create("0912", "ROSBALDO ATGE", DateTime.Parse("11/2027"), "001"),
                CreatedDate = DateTime.Now
            },
            new Transaction {
                Id = 29,
                Value = 1250.66m,
                Description = "Pagamento Super Bikes",
                PaymentMethod = Enums.PaymentMethod.CreditCard,
                Card = Card.Create("8912", "DUARTE LIMA", DateTime.Parse("06/2028"), "8712"),
                CreatedDate = DateTime.Now
            }
        };
    }
}
