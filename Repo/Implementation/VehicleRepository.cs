using Microsoft.EntityFrameworkCore;
using Uber.DBContext;
using Uber.Model;
using Uber.Repo.Interface;

namespace Uber.Repo.Implementation
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {


        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetById(int id)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> DriverExists(int driverId)
        {
            return await _context.Users.AnyAsync(
                u => u.Id == driverId && u.Role == "Driver");
        }

        public async Task<bool> VehicleExistsForDriver(int driverId)
        {
            return await _context.Vehicles.AnyAsync(
                v => v.DriverId == driverId);
        }
    }
}

