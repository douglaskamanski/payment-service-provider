using Microsoft.EntityFrameworkCore;
using payment_service_provider.Enums;
using payment_service_provider.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace payment_service_provider.Models;

public class Transaction
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Precision(14, 2)]
    [Range(0.01, Double.PositiveInfinity, ErrorMessage = "{0} must be greater than {1}")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1} characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public PaymentMethod PaymentMethod { get; set;}

    [Required(ErrorMessage = "{0} is required")]
    public Card Card { get; set;}

    [Required(ErrorMessage = "{0} is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
