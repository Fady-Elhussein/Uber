using System.ComponentModel.DataAnnotations;

namespace Uber.Model
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

        [MaxLength(250)]
        public string? Comment { get; set; }

        [Required]
        public int RideId { get; set; }

        // Navigation Property
        public Ride Ride { get; set; } = null!;
    }
}
