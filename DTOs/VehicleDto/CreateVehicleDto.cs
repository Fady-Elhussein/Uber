using System.ComponentModel.DataAnnotations;

namespace Uber.DTOs.VehicleDto
{
    public class CreateVehicleDto
    {
        [Required]
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; } = string.Empty;
        public int DriverId { get; set; }

    }
}
