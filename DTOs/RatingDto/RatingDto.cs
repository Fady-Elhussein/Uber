namespace Uber.DTOs.RatingDto
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public int RideId { get; set; }
    }
}
