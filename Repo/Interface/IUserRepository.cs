using Uber.Model;

namespace Uber.Repo.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetDrivers();
        Task<List<User>> SearchRiders(string name);
    }
}
