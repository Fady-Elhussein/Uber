using Uber.Model;

namespace Uber.Repo.Interface
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<Vehicle?> GetById(int id);

        Task<bool> DriverExists(int driverId);

        Task<bool> VehicleExistsForDriver(int driverId);

    }
}
