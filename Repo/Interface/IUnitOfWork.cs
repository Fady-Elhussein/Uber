using System.Threading.Tasks;
using Uber.Model;

namespace Uber.Repo.Interface
{
    public interface IUnitOfWork
    {

        IAuthRepository Auth { get; }
        IVehicleRepository Vehicles { get; }
        IUserRepository Users { get; }
        IGenericRepository<Ride> Rides { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Rating> Ratings { get; }

        Task SaveChangesAsync();

    }
}
