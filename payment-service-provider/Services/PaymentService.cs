using Microsoft.EntityFrameworkCore;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Domain.Fees;
using payment_service_provider.Dtos;
using payment_service_provider.Enums;
using payment_service_provider.Models;
using payment_service_provider.ValueObjects;
using System.ComponentModel.DataAnnotations;

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

    public async Task<Response<CreatePaymentDto>> CreatePayment(CreatePaymentDto createPaymentDto)
    {
        Response<CreatePaymentDto> response = new();

        try
        {
            Validator.ValidateObject(createPaymentDto, new ValidationContext(createPaymentDto), true);
        }
        catch (ValidationException ex)
        {
            response.Success = false;
            response.Message = $"Parameter validation exception: {ex.Message}";
            response.Data = createPaymentDto;

            return response;
        }

        Transaction transaction = new()
        {
            Value = createPaymentDto.Value,
            Description = createPaymentDto.Description,
            PaymentMethod = createPaymentDto.PaymentMethod,
        };

        try
        {
            transaction.Card = Card.Create(createPaymentDto.CardNumbers.Substring(createPaymentDto.CardNumbers.Length - 4), createPaymentDto.CardName, createPaymentDto.CardExpirationDate, createPaymentDto.CardCvv);
        } catch (ArgumentException ex) 
        {
            response.Success = false;
            response.Message = $"Card validation exception: {ex.Message}";
            response.Data = createPaymentDto;

            return response;
        }

        try
        {
            await _transactionRepository.Create(transaction);
        }
        catch (DbUpdateException ex)
        {
            response.Success = false;
            response.Message = $"Create transaction failed: {ex.Message}";
            response.Data = createPaymentDto;

            return response;
        }

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

        try
        {
            await _payableRepository.Create(payable);
        }
        catch (DbUpdateException ex)
        {
            response.Success = false;
            response.Message = $"Create payable failed: {ex.Message}";
            response.Data = createPaymentDto;

            return response;
        }

        response.Success = true;
        response.Message = "Create payment successfully.";
        response.Data = null;

        return response;
    }
}
