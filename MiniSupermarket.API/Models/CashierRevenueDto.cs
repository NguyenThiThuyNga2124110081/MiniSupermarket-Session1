/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Ngày tạo: 15/09/2026
 * Mô tả: BUỔI 5 - TIẾT 3: DTO hứng dữ liệu kết quả thống kê từ Stored Procedure
 */

namespace MiniSupermarket.API.Models
{
    // DTO hứng kết quả từ sp_GetRevenueByCashier
    public class CashierRevenueDto
    {
        public string CashierUsername { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalPointsAwarded { get; set; }
    }

    // DTO hứng kết quả từ sp_GetTop5SellingProducts (Bài tập 3.2)
    public class TopSellingProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int TotalQuantitySold { get; set; }
        public decimal TotalSalesRevenue { get; set; }
    }
}
