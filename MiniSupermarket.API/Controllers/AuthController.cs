using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MiniSupermarket.API.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Endpoint Đăng nhập: POST /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { success = false, message = "Vui lòng nhập tài khoản và mật khẩu!" });
            }

            var user = UserDataStore.Users.FirstOrDefault(u =>
                u.Username.Equals(request.Username.Trim(), System.StringComparison.OrdinalIgnoreCase) &&
                u.Password == request.Password.Trim());

            if (user != null)
            {
                if (!user.IsActive)
                {
                    return Unauthorized(new { success = false, message = "Tài khoản đang bị khóa!" });
                }

                var token = GenerateJwtToken(user.Username, user.Role);
                return Ok(new
                {
                    success = true,
                    token = token,
                    role = user.Role,
                    fullName = user.FullName,
                    username = user.Username
                });
            }

            return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
        }

        private string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Lấy khóa bí mật từ appsettings.json
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Thời hạn token là 2 tiếng
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
