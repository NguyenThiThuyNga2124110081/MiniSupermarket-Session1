/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Bài tập thực hành 1: Đếm tổng số mặt hàng bằng ExecuteScalar()
 */
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    public class Bai1
    {
        public static void ThucHien(string connString)
        {
            Console.WriteLine("=== BÀI TẬP 1: ĐẾM TỔNG SỐ LƯỢNG MẶT HÀNG (ExecuteScalar) ===");

            // 1. Khởi tạo đối tượng SqlConnection trong khối using để tự động giải phóng
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 2. Câu lệnh SQL đếm toàn bộ số dòng trong bảng Products
                    string query = "SELECT COUNT(*) FROM Products";

                    // 3. Khởi tạo đối tượng SqlCommand gắn câu lệnh với kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 4. Bắt buộc phải mở kết nối trước khi thực thi
                        connection.Open();
                        Console.WriteLine("-> Đã kết nối thành công tới SQL Server!");

                        // 5. ExecuteScalar() trả về một đối tượng kiểu object (ô đầu tiên dòng 1)
                        // Cần ép kiểu tường minh sang kiểu int
                        object? result = command.ExecuteScalar();
                        int totalCount = Convert.ToInt32(result);

                        // 6. Hiển thị kết quả ra màn hình
                        Console.WriteLine($"-> Tổng số mặt hàng hiện có trong kho siêu thị: {totalCount} sản phẩm.");
                        Console.WriteLine("-> ExecuteScalar() thực thi tối ưu nhất vì chỉ lấy duy nhất 1 ô dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi nếu sai chuỗi kết nối hoặc sai tên bảng CSDL
                    Console.WriteLine($"[LỖI SQL]: Không thể truy vấn CSDL. Chi tiết: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi ngoại lệ chung
                    Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
                }
            } // Kết thúc using, connection.Close() và connection.Dispose() tự động được gọi
        }
    }
}
