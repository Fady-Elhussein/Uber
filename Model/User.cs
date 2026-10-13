using System.ComponentModel.DataAnnotations;

namespace Uber.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Role { get; set; }

        // Navigation Properties
        public Vehicle? Vehicle { get; set; }

        public ICollection<Ride> DriverRides { get; set; }
            = new List<Ride>();

        public ICollection<Ride> RiderRides { get; set; }
            = new List<Ride>();
    }
}
