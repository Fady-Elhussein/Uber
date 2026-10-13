using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber.DTOs.UserDto;
using Uber.Repo.Interface;

namespace Uber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users/drivers
        [HttpGet("drivers")]
        public async Task<IActionResult> GetDrivers()
        {
            var users = await _userRepository.GetDrivers();

            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                Role = u.Role
            }).ToList();

            return Ok(result);
        }

        // GET: api/users/riders/search?name=Ali
        [HttpGet("riders/search")]
        public async Task<IActionResult> SearchRiders(
            [FromQuery] string name)
        {
            var users = await _userRepository.SearchRiders(name);

            var result = users.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                Role = u.Role
            }).ToList();

            return Ok(result);
        }
    }
}

