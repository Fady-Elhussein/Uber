using System.ComponentModel.DataAnnotations;

namespace Uber.Model
{
    public class Payment
    {
        public int Id { get; set; }

        [Range(20, 5000)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        public int RideId { get; set; }

        // Navigation Property
        public Ride Ride { get; set; } = null!;
    }
}
