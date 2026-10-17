using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        /*
         * Họ tên sinh viên: Nguyễn Thị Thúy Nga
         * Mã sinh viên: 2124110081
         * Lớp: CCQ2411C
         * Mô tả: Bài tập 6.1 - Phân trang danh sách khách hàng, sắp xếp giảm dần theo điểm thưởng RewardPoints
         */
        // GET: api/customers/paged?keyword=...&sortBy=id&pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedCustomers(
            [FromQuery] string? keyword,
            [FromQuery] string? sortBy = "id",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            // 1. Kiểm tra tham số trang hợp lệ
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 10;

            // 2. Truy vấn LINQ AsNoTracking
            var query = _context.Customers
                .AsNoTracking()
                .AsQueryable();

            // 3. Tìm kiếm theo tên hoặc SĐT
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim().ToLower();
                query = query.Where(c => c.CustomerName.ToLower().Contains(search) 
                                      || c.PhoneNumber.Contains(search));
            }

            // 4. Đếm tổng số khách hàng thỏa mãn
            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // 5. Sắp xếp theo CustomerId tăng dần theo thứ tự chuẩn (hoặc theo RewardPoints nếu có yêu cầu)
            if (string.Equals(sortBy, "points", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(c => c.RewardPoints);
            }
            else
            {
                query = query.OrderBy(c => c.CustomerId);
            }

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CustomerItemDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    RewardPoints = c.RewardPoints,
                    MembershipRank = c.MembershipRank
                })
                .ToListAsync();

            // 6. Đóng gói kết quả trả về
            var response = new PagedResult<CustomerItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };

            return Ok(response);
        }

        // 1. GET: api/customers - Lấy toàn bộ danh sách khách hàng
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // 2. GET: api/customers/5 - Lấy chi tiết theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng!" });
            }
            return customer;
        }

        // 3. GET: api/customers/search?keyword=... - Tìm kiếm theo tên hoặc SĐT
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Customer>>> SearchCustomers([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetCustomers();
            }

            var results = await _context.Customers
                .Where(c => c.CustomerName.Contains(keyword) || c.PhoneNumber.Contains(keyword))
                .ToListAsync();

            return results;
        }

        // 4. POST: api/customers - Thêm mới khách hàng
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        // 5. PUT: api/customers/5 - Cập nhật thông tin khách hàng
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest(new { message = "Mã ID không trùng khớp!" });
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.CustomerId == id))
                {
                    return NotFound(new { message = "Khách hàng không tồn tại!" });
                }
                throw;
            }

            return NoContent();
        }

        // 6. DELETE: api/customers/5 - Xóa khách hàng
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng cần xóa!" });
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}