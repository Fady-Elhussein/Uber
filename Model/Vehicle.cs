using System.ComponentModel.DataAnnotations;

namespace Uber.Model
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int DriverId { get; set; }

        // Navigation Property
        public User Driver { get; set; }
    }
}
