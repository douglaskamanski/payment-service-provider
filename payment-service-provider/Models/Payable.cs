using Microsoft.EntityFrameworkCore;
using payment_service_provider.Enums;
using System.ComponentModel.DataAnnotations;

namespace payment_service_provider.Models;

public class Payable
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Precision(14, 2)]
    [Range(0.01, Double.PositiveInfinity, ErrorMessage = "{0} must be greater than {1}")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public PaymentStatus Status { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
    public DateTime PaymentDate { get; set; }
}
