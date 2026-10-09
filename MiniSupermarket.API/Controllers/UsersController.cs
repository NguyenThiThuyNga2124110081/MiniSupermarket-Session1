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
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetUsers()
        {
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

            if (UserDataStore.Users.Any(u => u.Username.Equals(request.Username.Trim(), System.StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { message = "Tên đăng nhập đã tồn tại!" });
            }

            int newId = UserDataStore.Users.Count > 0 ? UserDataStore.Users.Max(u => u.Id) + 1 : 1;
            var newUser = new UserAccount
            {
                Id = newId,
                Username = request.Username.Trim(),
                Password = request.Password.Trim(),
                FullName = request.FullName?.Trim() ?? string.Empty,
                Role = string.IsNullOrWhiteSpace(request.Role) ? "Cashier" : request.Role.Trim(),
                IsActive = true
            };

            UserDataStore.Users.Add(newUser);
            return Ok(new { message = "Tạo tài khoản thành công!", id = newId });
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
