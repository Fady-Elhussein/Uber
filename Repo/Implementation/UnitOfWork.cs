using Uber.DBContext;
using Uber.Model;
using Uber.Repo.Interface;

namespace Uber.Repo.Implementation
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IAuthRepository Auth { get; }
        public IGenericRepository<User> Users { get; }
        public IVehicleRepository Vehicles { get; }
        public IGenericRepository<Ride> Rides { get; }
        public IGenericRepository<Payment> Payments { get; }
        public IGenericRepository<Rating> Ratings { get; }

        public UnitOfWork(AppDbContext context, IAuthRepository auth, IVehicleRepository vehicles, IGenericRepository<Ride> rides, IGenericRepository<Payment> payments, IGenericRepository<Rating> ratings, IGenericRepository<User> users)
        {
            _context = context;

            Auth =  auth;
            Users = users;
            Vehicles = vehicles;
            Rides = rides;
            Payments = payments;
            Ratings = ratings;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
