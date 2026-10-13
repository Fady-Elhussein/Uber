using Uber.Model;

namespace Uber.Repo.Interface
{

        public interface IAuthRepository
        {
            Task<bool> EmailExists(string email);

            Task<User?> GetByEmail(string email);

            Task Add(User user);
      
        Task<User?> Login(string email, string password);

    }
    
}
