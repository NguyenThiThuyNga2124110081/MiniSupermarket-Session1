/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Controller Quản trị Tài khoản Người dùng & Phân quyền (RBAC) - Hỗ trợ phân trang LINQ, cập nhật, đổi mật khẩu và khóa/mở tài khoản
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

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

        // GET: api/users/paged?keyword=...&pageNumber=1&pageSize=10
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedUsers(
            [FromQuery] string? keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 10;

            var query = _context.Users.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim().ToLower();
                query = query.Where(u => u.Username.ToLower().Contains(search) 
                                      || u.FullName.ToLower().Contains(search)
                                      || u.Role.ToLower().Contains(search));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var items = await query
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UserItemDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FullName = u.FullName,
                    Role = u.Role,
                    IsActive = u.IsActive
                })
                .ToListAsync();

            var response = new PagedResult<UserItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> GetUsers()
        {
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
                UserDataStore.Users.Any(u => u.Username.Equals(trimmedUsername, StringComparison.OrdinalIgnoreCase)))
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

        // PUT: api/users/5 (Cập nhật thông tin FullName, Role, IsActive)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy người dùng!" });
            }

            if (!string.IsNullOrWhiteSpace(request.FullName))
            {
                user.FullName = request.FullName.Trim();
            }

            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                user.Role = request.Role.Trim();
            }

            if (request.IsActive.HasValue)
            {
                user.IsActive = request.IsActive.Value;
            }

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                user.Password = request.Password.Trim();
            }

            await _context.SaveChangesAsync();

            // Đồng bộ bộ nhớ tạm
            var mem = UserDataStore.Users.FirstOrDefault(u => u.Id == id || u.Username == user.Username);
            if (mem != null)
            {
                mem.FullName = user.FullName;
                mem.Role = user.Role;
                mem.IsActive = user.IsActive;
                if (!string.IsNullOrWhiteSpace(request.Password)) mem.Password = user.Password;
            }

            return Ok(new { message = "Cập nhật tài khoản thành công!" });
        }

        // PUT: api/users/5/toggle-lock (Khóa hoặc Mở khóa tài khoản)
        [HttpPut("{id}/toggle-lock")]
        public async Task<IActionResult> ToggleLock(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy người dùng!" });
            }

            // Đảo trạng thái hoạt động
            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();

            var mem = UserDataStore.Users.FirstOrDefault(u => u.Id == id || u.Username == user.Username);
            if (mem != null)
            {
                mem.IsActive = user.IsActive;
            }

            string status = user.IsActive ? "Đã mở khóa tài khoản thành công!" : "Đã khóa tài khoản thành công!";
            return Ok(new { message = status, isActive = user.IsActive });
        }

        // PUT: api/users/5/reset-password (Đổi mật khẩu tài khoản)
        [HttpPut("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetPasswordRequest req)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy người dùng!" });
            }

            string newPass = string.IsNullOrWhiteSpace(req?.NewPassword) ? "123456" : req.NewPassword.Trim();
            user.Password = newPass;
            await _context.SaveChangesAsync();

            var mem = UserDataStore.Users.FirstOrDefault(u => u.Id == id || u.Username == user.Username);
            if (mem != null)
            {
                mem.Password = user.Password;
            }

            return Ok(new { message = "Đặt lại mật khẩu thành công!", password = newPass });
        }
    }

    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Role { get; set; }
    }

    public class UpdateUserRequest
    {
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string? NewPassword { get; set; }
    }
}
