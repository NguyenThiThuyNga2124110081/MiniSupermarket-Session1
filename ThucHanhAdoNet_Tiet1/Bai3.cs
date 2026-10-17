/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Bài tập thực hành 3: Đọc danh sách sản phẩm bằng SqlDataReader
 */
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    public class Bai3
    {
        public static void ThucHien(string connString)
        {
            Console.WriteLine("=== BÀI TẬP 3: DUYỆT DANH SÁCH BẰNG SQLDATAREADER (Forward-Only) ===");

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 1. Câu truy vấn lấy danh sách mặt hàng
                    string query = @"SELECT TOP 15 ProductId, Barcode, ProductName, Price, StockQuantity 
                                     FROM Products 
                                     ORDER BY ProductId ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // 2. Kích hoạt luồng đọc trực tiếp bằng ExecuteReader()
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            Console.WriteLine(string.Format("{0,-6} | {1,-14} | {2,-35} | {3,12} | {4,8}", 
                                "MÃ SP", "MÃ VẠCH", "TÊN SẢN PHẨM", "ĐƠN GIÁ", "TỒN KHO"));
                            Console.WriteLine("-----------------------------------------------------------------------------------------");

                            // 3. Vòng lặp while(reader.Read()): Dịch chuyển con trỏ xuống từng dòng dữ liệu tiếp theo
                            // Khi nào hết dữ liệu, hàm Read() sẽ tự động trả về giá trị false
                            int stt = 0;
                            while (reader.Read())
                            {
                                stt++;

                                // Đọc giá trị từng cột theo tên cột
                                int id = Convert.ToInt32(reader["ProductId"]);
                                string barcode = reader["Barcode"]?.ToString() ?? "";
                                string name = reader["ProductName"]?.ToString() ?? "";
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int stock = Convert.ToInt32(reader["StockQuantity"]);

                                // In dòng dữ liệu căn lề đẹp mắt
                                Console.WriteLine(string.Format("{0,-6} | {1,-14} | {2,-35} | {3,12:N0} đ | {4,8}", 
                                    id, barcode, name, price, stock));
                            }

                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            Console.WriteLine($"-> Tổng cộng đã đọc thành công: {stt} mặt hàng từ SQL Server.");
                        } // Kết thúc using, reader tự động đóng lại
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"[LỖI SQL]: {ex.Message}");
                }
            }
        }
    }
}
