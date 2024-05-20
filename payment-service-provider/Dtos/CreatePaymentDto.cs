using Microsoft.EntityFrameworkCore;
using payment_service_provider.Enums;
using System.ComponentModel.DataAnnotations;

namespace payment_service_provider.Dtos;

public class CreatePaymentDto
{
    [Required(ErrorMessage = "{0} is required")]
    [Precision(14, 2)]
    [Range(0.01, Double.PositiveInfinity, ErrorMessage = "{0} must be greater than {1}")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1} characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, 1, ErrorMessage = "{0} is invalid")]
    public PaymentMethod PaymentMethod { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(16, MinimumLength = 16, ErrorMessage = "{0} must be {1} numbers")]
    [Range(0, Int64.MaxValue, ErrorMessage = "{0} must be numbers")]
    public string CardNumbers { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} letters")]
    public string CardName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "MM/yyyy")]
    public DateTime CardExpirationDate { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(4, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} numbers")]
    [Range(0, Int64.MaxValue, ErrorMessage = "{0} must be numbers")]
    public string CardCvv { get; set; }
}
