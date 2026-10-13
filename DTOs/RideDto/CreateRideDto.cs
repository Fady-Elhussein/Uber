using System.ComponentModel.DataAnnotations;

namespace Uber.DTOs.RideDto
{
    public class CreateRideDto
    {
        [Required]
        [MaxLength(150)]
        public string PickupLocation { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string DropOffLocation { get; set; } = string.Empty;

        [Range(20, 5000)]
        public decimal Fare { get; set; }
    }
}
