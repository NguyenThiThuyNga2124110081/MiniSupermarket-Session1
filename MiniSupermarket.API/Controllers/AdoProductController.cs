/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Ngày tạo: 15/09/2026
 * Mô tả: BUỔI 5 - TIẾT 2: Controller ADO.NET thuần - Tra cứu mã vạch siêu tốc và mô hình ngắt kết nối với DataTable
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    // DTO tra cứu sản phẩm cho quầy POS
    public class ProductLookupDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    // DTO đếm sản phẩm theo danh mục (Bài tập 2.2)
    public class CategoryProductCountDto
    {
        public int CategoryId { get; set; }
        public int TotalProducts { get; set; }
    }

    [Route("api/ado-products")]
    [ApiController]
    public class AdoProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Constructor tiêm IConfiguration để đọc chuỗi kết nối từ appsettings.json
        public AdoProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // THAO TÁC 1: TRA CỨU THEO MÃ VẠCH (CONNECTED MODE - SQLDATAREADER)
        // =========================================================================
        // GET: api/ado-products/barcode/8931111001011
        [HttpGet("barcode/{barcode}")]
        public IActionResult GetProductByBarcode(string barcode)
        {
            // 1. Kiểm tra tính hợp lệ của tham số đầu vào
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            // 2. Lấy chuỗi kết nối tới SQL Server
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 3. Sử dụng khối using để đảm bảo SqlConnection luôn được đóng và giải phóng
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 4. Câu lệnh SELECT có tham số hóa @Barcode chống SQL Injection
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM Products 
                                 WHERE Barcode = @Barcode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // 5. Gán giá trị an toàn qua SqlParameter
                    command.Parameters.AddWithValue("@Barcode", barcode.Trim());

                    try
                    {
                        // 6. Mở kết nối vật lý tới SQL Server
                        connection.Open();

                        // 7. Khởi tạo luồng đọc nhanh Forward-Only SqlDataReader (<100ms)
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 8. Đọc bản ghi: reader.Read() trả về true nếu tìm thấy dòng dữ liệu
                            if (reader.Read())
                            {
                                var productDto = new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"]?.ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                };

                                // Trả về mã 200 OK kèm dữ liệu sản phẩm
                                return Ok(productDto);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Bắt lỗi nếu kết nối CSDL gặp sự cố
                        return StatusCode(500, new { message = "Lỗi truy vấn SQL: " + ex.Message });
                    }
                }
            } // Kết thúc using, connection.Close() tự động được thực thi tại đây

            // 9. Nếu không tìm thấy sản phẩm nào khớp mã vạch -> Trả về 404 Not Found
            return NotFound(new { message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}" });
        }

        // =========================================================================
        // THAO TÁC 2: TẢI DANH SÁCH LƯU ĐỆM (DISCONNECTED MODE - DATATABLE & ADAPTER)
        // =========================================================================
        // GET: api/ado-products/disconnected-cache
        [HttpGet("disconnected-cache")]
        public IActionResult GetProductsDisconnected()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Khởi tạo bảng ảo DataTable trên RAM
            DataTable productTable = new DataTable("CachedProducts");

            // 2. Mở kết nối và sử dụng SqlDataAdapter để nạp dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM Products 
                                 ORDER BY ProductId ASC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // 3. SqlDataAdapter làm cầu nối giữa Command và DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // 4. Phương thức Fill(): Tự động Open connection -> Đọc dữ liệu đổ vào DataTable -> Tự động Close connection
                        adapter.Fill(productTable);
                    }
                }
            } // Tại đây, kết nối CSDL ĐÃ ĐƯỢC ĐÓNG HOÀN TOÀN!

            // 5. Thao tác độc lập trên bộ nhớ RAM (Không cần kết nối tới SQL Server nữa)
            var resultList = new List<ProductLookupDto>();

            // Duyệt qua từng dòng (DataRow) trong tập hợp Rows của DataTable
            foreach (DataRow row in productTable.Rows)
            {
                resultList.Add(new ProductLookupDto
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Barcode = row["Barcode"]?.ToString() ?? string.Empty,
                    ProductName = row["ProductName"]?.ToString() ?? string.Empty,
                    Price = Convert.ToDecimal(row["Price"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"])
                });
            }

            // Trả về danh sách sản phẩm đã được lưu đệm trên RAM
            return Ok(new
            {
                totalLoaded = productTable.Rows.Count,
                cachedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                data = resultList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.1: BỔ SUNG ENDPOINT TRA CỨU THEO KHOẢNG GIÁ TỒN KHO
        // =========================================================================
        // GET: api/ado-products/filter-stock?minStock=50
        [HttpGet("filter-stock")]
        public IActionResult FilterByStock([FromQuery] int minStock = 50)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            var resultList = new List<ProductLookupDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM Products 
                                 WHERE StockQuantity <= @MinStock 
                                 ORDER BY StockQuantity ASC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MinStock", minStock);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                resultList.Add(new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"]?.ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new { message = "Lỗi SQL: " + ex.Message });
                    }
                }
            }

            return Ok(new
            {
                filter = $"Tồn kho <= {minStock}",
                totalFound = resultList.Count,
                data = resultList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.2: ĐẾM SỐ LƯỢNG SẢN PHẨM THEO TỪNG NHÓM DANH MỤC BẰNG DATATABLE
        // =========================================================================
        // GET: api/ado-products/category-count
        [HttpGet("category-count")]
        public IActionResult GetProductCountByCategory()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            DataTable catCountTable = new DataTable("CategoryProductCount");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT CategoryId, COUNT(*) AS TotalProducts 
                                 FROM Products 
                                 GROUP BY CategoryId 
                                 ORDER BY CategoryId ASC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(catCountTable);
                    }
                }
            } // Kết nối đã ngắt, thao tác hoàn toàn ngắt kết nối trên RAM

            var resultList = new List<CategoryProductCountDto>();
            foreach (DataRow row in catCountTable.Rows)
            {
                resultList.Add(new CategoryProductCountDto
                {
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    TotalProducts = Convert.ToInt32(row["TotalProducts"])
                });
            }

            return Ok(new
            {
                totalCategoriesWithProducts = catCountTable.Rows.Count,
                data = resultList
            });
        }
    }
}
