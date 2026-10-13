namespace Uber.DTOs.RideDto
{
    public class RideDto
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public string DropOffLocation { get; set; } = string.Empty;
        public decimal Fare { get; set; }
        public string Status { get; set; } = string.Empty;
        public int RiderId { get; set; }
        public int? DriverId { get; set; }
    }
}
