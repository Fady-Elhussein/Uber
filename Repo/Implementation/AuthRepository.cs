using Microsoft.EntityFrameworkCore;
using Uber.DBContext;
using Uber.Model;
using Uber.Repo.Interface;

namespace Uber.Repo.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<User?> Login(
           string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == email &&
                    u.Password == password);
        }


    }
}
