/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Bài tập thực hành 2: Cập nhật tồn kho sản phẩm bằng ExecuteNonQuery() và SqlParameter
 */
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    public class Bai2
    {
        public static void ThucHien(string connString)
        {
            Console.WriteLine("=== BÀI TẬP 2: CẬP NHẬT TỒN KHO AN TOÀN VỚI SQLPARAMETER ===");

            // Giả lập thông tin do nhân viên nhập từ bàn phím
            int maSanPhamCanSua = 1;       // Mã sản phẩm Trà chanh giã tay
            int soLuongTonKhoMoi = 150;    // Số lượng kiểm kê mới nhập kho

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 1. Viết câu lệnh UPDATE có chứa 2 tham số @Stock và @Id (Tuyệt đối không cộng chuỗi)
                    string updateSql = @"UPDATE Products 
                                         SET StockQuantity = @Stock 
                                         WHERE ProductId = @Id";

                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        // 2. Gán giá trị an toàn vào tham số thông qua AddWithValue để triệt tiêu SQL Injection
                        command.Parameters.AddWithValue("@Stock", soLuongTonKhoMoi);
                        command.Parameters.AddWithValue("@Id", maSanPhamCanSua);

                        // 3. Mở kết nối
                        connection.Open();

                        // 4. Thực thi ExecuteNonQuery() để nhận về số dòng bị thay đổi trong CSDL
                        int rowsAffected = command.ExecuteNonQuery();

                        // 5. Kiểm tra kết quả thực thi
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"-> THÀNH CÔNG: Đã cập nhật tồn kho cho Sản phẩm ID = {maSanPhamCanSua} thành {soLuongTonKhoMoi} đơn vị.");
                            Console.WriteLine($"-> Số dòng dữ liệu bị ảnh hưởng: {rowsAffected} dòng.");
                        }
                        else
                        {
                            Console.WriteLine($"-> CẢNH BÁO: Không tìm thấy sản phẩm có ID = {maSanPhamCanSua} để cập nhật.");
                        }
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
