/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Lớp DTO tổng quát (Generic) chứa dữ liệu phân trang trả về cho Client
 */
namespace MiniSupermarket.API.Models
{
    // DTO chi tiết từng sản phẩm trả về kèm tên nhóm hàng
    public class ProductItemDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty; // Lấy từ bảng Categories qua Eager Loading
    }

    // DTO chi tiết khách hàng cho bài tập 6.1
    public class CustomerItemDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = string.Empty;
    }

    // DTO chi tiết danh mục nhóm hàng phân trang
    public class CategoryItemDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    // DTO chi tiết người dùng phân trang
    public class UserItemDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    // DTO bao bọc kết quả phân trang
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }       // Trang hiện tại (1, 2, 3...)
        public int PageSize { get; set; }          // Số phần tử trên mỗi trang (ví dụ: 5 dòng)
        public int TotalItems { get; set; }         // Tổng số phần tử thỏa mãn điều kiện
        public int TotalPages { get; set; }         // Tổng số trang = Ceiling(TotalItems / PageSize)
        public List<T> Items { get; set; } = new(); // Danh sách dữ liệu của trang hiện hành
    }
}
