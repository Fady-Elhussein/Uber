namespace Uber.DTOs.VehicleDto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int DriverId { get; set; }
    }
}
