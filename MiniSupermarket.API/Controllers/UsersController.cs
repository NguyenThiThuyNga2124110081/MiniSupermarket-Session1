using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MiniSupermarket.API.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public UsersController(SupermarketDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetUsers()
        {
            // Lấy từ CSDL SQL Server
            var dbList = _context.Users.Select(u => new
            {
                Id = u.Id,
                Username = u.Username,
                FullName = u.FullName,
                Role = u.Role,
                IsActive = u.IsActive
            }).ToList();

            if (dbList.Count > 0)
            {
                return Ok(dbList);
            }

            // Fallback sang in-memory nếu chưa nạp
            var list = UserDataStore.Users.Select(u => new
            {
                Id = u.Id,
                Username = u.Username,
                FullName = u.FullName,
                Role = u.Role,
                IsActive = u.IsActive
            }).ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Thông tin không hợp lệ." });
            }

            var trimmedUsername = request.Username.Trim();
            if (_context.Users.Any(u => u.Username.ToLower() == trimmedUsername.ToLower()) ||
                UserDataStore.Users.Any(u => u.Username.Equals(trimmedUsername, System.StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = "Tên đăng nhập đã tồn tại!" });
            }

            var newDbUser = new MiniSupermarket.API.Models.User
            {
                Username = trimmedUsername,
                Password = request.Password.Trim(),
                FullName = request.FullName?.Trim() ?? string.Empty,
                Role = string.IsNullOrWhiteSpace(request.Role) ? "Cashier" : request.Role.Trim(),
                IsActive = true
            };

            _context.Users.Add(newDbUser);
            _context.SaveChanges();

            // Đồng bộ sang UserDataStore
            UserDataStore.Users.Add(new UserAccount
            {
                Id = newDbUser.Id,
                Username = newDbUser.Username,
                Password = newDbUser.Password,
                FullName = newDbUser.FullName,
                Role = newDbUser.Role,
                IsActive = newDbUser.IsActive
            });

            return Ok(new { message = "Tạo tài khoản thành công!", id = newDbUser.Id });
        }
    }

    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Role { get; set; }
    }
}
