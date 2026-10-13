using System.ComponentModel.DataAnnotations;

namespace Uber.DTOs.PaymentDto
{
    public class CreatePaymentDto
    {
        [Range(20, 5000)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        public int RideId { get; set; }
    }
}
