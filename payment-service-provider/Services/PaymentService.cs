using payment_service_provider.Data.Repositories;
using payment_service_provider.Domain.Fees;
using payment_service_provider.Dtos;
using payment_service_provider.Enums;
using payment_service_provider.Models;
using payment_service_provider.ValueObjects;

namespace payment_service_provider.Services;

public class PaymentService : IPaymentService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPayableRepository _payableRepository;
    private readonly IComputeFee _computeFee;

    public PaymentService(ITransactionRepository transactionRepository, IPayableRepository payableRepository, IComputeFee computeFee)
    {
        _transactionRepository = transactionRepository;
        _payableRepository = payableRepository;
        _computeFee = computeFee;
    }

    public void CreatePayment(CreatePaymentDto createPaymentDto)
    {
        Transaction transaction = new()
        {
            Value = createPaymentDto.Value,
            Description = createPaymentDto.Description,
            PaymentMethod = createPaymentDto.PaymentMethod,
            Card = Card.Create(createPaymentDto.CardNumbers.Substring(createPaymentDto.CardNumbers.Length - 4), createPaymentDto.CardName, createPaymentDto.CardExpirationDate, createPaymentDto.CardCvv)
        };

        _transactionRepository.Create(transaction);

        Payable payable = new();

        if (createPaymentDto.PaymentMethod == PaymentMethod.DebitCard)
        {
            payable.Value = createPaymentDto.Value - _computeFee.Compute(createPaymentDto.Value, new DebitCardFee());
            payable.Status = PaymentStatus.Paid;
            payable.PaymentDate = DateTime.Now;
        }
        else if (createPaymentDto.PaymentMethod == PaymentMethod.CreditCard)
        {
            payable.Value = createPaymentDto.Value - _computeFee.Compute(createPaymentDto.Value, new CreditCardFee());
            payable.Status = PaymentStatus.WaitingFunds;
            payable.PaymentDate = DateTime.Now.AddDays(30);
        }

        _payableRepository.Create(payable);
    }
}
