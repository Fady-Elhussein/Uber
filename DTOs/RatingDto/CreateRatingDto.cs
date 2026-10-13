using System.ComponentModel.DataAnnotations;

namespace Uber.DTOs.RatingDto
{
    public class CreateRatingDto
    {
        [Range(1, 5)]
        public int Score { get; set; }

        [MaxLength(250)]
        public string? Comment { get; set; }

        [Required]
        public int RideId { get; set; }
    }
}
