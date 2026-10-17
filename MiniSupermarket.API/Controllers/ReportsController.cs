/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Ngày tạo: 15/09/2026
 * Mô tả: BUỔI 5 - TIẾT 3: Controller ADO.NET thực thi Stored Procedure xuất báo cáo ca bán lẻ
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Models;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Dependency Injection lấy chuỗi kết nối từ appsettings.json
        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // GET: api/reports/revenue-by-cashier
        // Chức năng: Gọi Stored Procedure sp_GetRevenueByCashier qua SqlDataReader
        // =========================================================================
        [HttpGet("revenue-by-cashier")]
        public IActionResult GetRevenueByCashier()
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Khởi tạo SqlConnection trong khối using đảm bảo tự động đóng kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 2. Gán CommandText là CHÍNH XÁC tên Stored Procedure trên SQL Server
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByCashier", connection))
                {
                    // 3. ĐIỂM KHOA HỌC QUAN TRỌNG: Thiết lập CommandType là StoredProcedure
                    // Nếu thiếu dòng này, SQL Server sẽ hiểu nhầm đây là chuỗi SQL thường và báo lỗi cú pháp!
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        // 4. Mở kết nối vật lý tới SQL Server
                        connection.Open();

                        // 5. Thực thi bằng ExecuteReader(): Nhận về luồng dữ liệu forward-only
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 6. Vòng lặp đọc từng dòng kết quả của Stored Procedure
                            while (reader.Read())
                            {
                                // Ánh xạ từng cột dữ liệu từ reader vào đối tượng DTO
                                var item = new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"]?.ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"])
                                        : 0
                                };

                                reportList.Add(item);
                            }
                        } // reader tự động Close() tại đây
                    }
                    catch (SqlException ex)
                    {
                        // Bắt lỗi nếu quên tạo Stored Procedure trên CSDL hoặc sai chuỗi kết nối
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message
                        });
                    }
                }
            } // connection tự động Close() và Dispose() tại đây

            // 7. Trả về mã 200 OK kèm danh sách báo cáo đã tổng hợp
            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.1: STORED PROCEDURE BÁO CÁO DOANH THU THEO KHOẢNG NGÀY (CÓ THAM SỐ)
        // GET: api/reports/revenue-by-date-range?fromDate=2026-09-01&toDate=2026-09-30
        // =========================================================================
        [HttpGet("revenue-by-date-range")]
        public IActionResult GetRevenueByDateRange([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var fDate = fromDate ?? DateTime.Today.AddDays(-30);
            var tDate = toDate ?? DateTime.Today.AddDays(1);

            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", fDate);
                    command.Parameters.AddWithValue("@ToDate", tDate);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"]?.ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"])
                                        : 0
                                };
                                reportList.Add(item);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi sp_GetRevenueByDateRange: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                fromDate = fDate.ToString("yyyy-MM-dd HH:mm:ss"),
                toDate = tDate.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.2: STORED PROCEDURE TOP 5 SẢN PHẨM BÁN CHẠY NHẤT
        // GET: api/reports/top-selling
        // =========================================================================
        [HttpGet("top-selling")]
        public IActionResult GetTop5SellingProducts()
        {
            var topList = new List<TopSellingProductDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetTop5SellingProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new TopSellingProductDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                                    Barcode = reader["Barcode"]?.ToString() ?? string.Empty,
                                    TotalQuantitySold = Convert.ToInt32(reader["TotalQuantitySold"]),
                                    TotalSalesRevenue = Convert.ToDecimal(reader["TotalSalesRevenue"])
                                };
                                topList.Add(item);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi sp_GetTop5SellingProducts: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalProducts = topList.Count,
                data = topList
            });
        }
    }
}
