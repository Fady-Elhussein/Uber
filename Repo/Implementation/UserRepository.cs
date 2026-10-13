using Microsoft.EntityFrameworkCore;
using Uber.DBContext;
using Uber.Model;
using Uber.Repo.Interface;

namespace Uber.Repo.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all drivers
        public async Task<List<User>> GetDrivers()
        {
            return await _context.Users
                .Where(u => u.Role == "Driver")
                .ToListAsync();
        }

        // Search riders by name
        public async Task<List<User>> SearchRiders(string name)
        {
            return await _context.Users
                .Where(u => u.Role == "Rider"
                    && u.FullName.Contains(name))
                .ToListAsync();
        }
    
}
}
