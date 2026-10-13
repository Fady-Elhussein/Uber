using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uber.DTOs.LoginDto;
using Uber.DTOs.RegisterDto;
using Uber.DTOs.UserDto;
using Uber.Model;
using Uber.Repo.Interface;

namespace Uber.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _authRepository;
        private readonly IConfiguration _config;

        public AuthController(
            IUnitOfWork authRepository ,
            IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (dto.Role != "Rider" && dto.Role != "Driver")
                return BadRequest("Invalid Role");

            if (await _authRepository.Auth.EmailExists(dto.Email))
                return BadRequest("Email already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = dto.Role,
                Password = dto.Password
            };

            await _authRepository.Auth.Add(user);

            var result = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role
            };

            return StatusCode(201, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _authRepository.Auth.Login(dto.Email, dto.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256));

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler()
                    .WriteToken(token)
            });
        }
    
}
}