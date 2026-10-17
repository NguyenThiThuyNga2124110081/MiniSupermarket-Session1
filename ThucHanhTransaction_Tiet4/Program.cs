/*
 * =========================================================================
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Chủ đề: BUỔI 5 - TIẾT 4: CHUẨN ACID & KỸ THUẬT ĐIỀU KHIỂN GIAO DỊCH VỚI SQLTRANSACTION
 * Mô tả: Chương trình kiểm chứng cơ chế Rollback của SqlTransaction
 * =========================================================================
 */
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhTransaction_Tiet4
{
    internal class Program
    {
        // Tự động kiểm tra và ưu tiên chuỗi kết nối phù hợp với máy tính
        private static string GetConnectionString()
        {
            string[] candidates = new string[]
            {
                "Server=(localdb)\\mssqllocaldb;Database=MiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;",
                "Server=localhost;Database=MiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;",
                "Server=.\\SQLEXPRESS;Database=MiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
            };

            foreach (var connStr in candidates)
            {
                try
                {
                    using (var conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        return connStr;
                    }
                }
                catch { }
            }

            return candidates[0];
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string connString = GetConnectionString();

            Console.WriteLine("=========================================================================");
            Console.WriteLine("  BÁO CÁO THỰC HÀNH TIẾT 4: ĐIỀU KHIỂN GIAO DỊCH SQLTRANSACTION (CHUẨN ACID)");
            Console.WriteLine("  Sinh viên: NGUYỄN THỊ THÚY NGA - MSSV: 2124110081 - Lớp: CCQ2411C     ");
            Console.WriteLine("=========================================================================\n");

            Console.WriteLine("=== THỬ NGHIỆM ĐIỀU KHIỂN SQLTRANSACTION ===");

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                // Đọc tồn kho ban đầu của Sản phẩm ID = 1 để đối soát
                int originalStock = 0;
                using (SqlCommand cmdCheck = new SqlCommand("SELECT StockQuantity FROM Products WHERE ProductId = 1", connection))
                {
                    object? res = cmdCheck.ExecuteScalar();
                    originalStock = res != null ? Convert.ToInt32(res) : 0;
                }
                Console.WriteLine($"[TRẠNG THÁI BAN ĐẦU]: Tồn kho của SP 1 hiện tại = {originalStock} đơn vị.");

                // 1. Khởi tạo Transaction từ connection đã mở
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    Console.WriteLine("-> Bắt đầu phiên giao dịch: transaction = connection.BeginTransaction()...");

                    // 2. Thao tác 1: Trừ 5 đơn vị tồn kho của Sản phẩm ID = 1 (Hợp lệ)
                    string sqlStep1 = "UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE ProductId = @Id";
                    using (SqlCommand cmd1 = new SqlCommand(sqlStep1, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@Qty", 5);
                        cmd1.Parameters.AddWithValue("@Id", 1);
                        int r1 = cmd1.ExecuteNonQuery();
                        Console.WriteLine($"-> Bước 1: Đã trừ tồn kho SP 1 (Số dòng tác động: {r1}).");
                    }

                    // 3. Thao tác 2: Cố tình gây lỗi cú pháp SQL hoặc kiểm tra logic không hợp lệ
                    Console.WriteLine("-> Bước 2: Chuẩn bị thực thi thao tác kiểm tra mặt hàng thứ 2...");

                    // Giả lập tình huống kiểm tra logic bị lỗi: Ném ngoại lệ thủ công
                    bool isInventoryShortage = true; // Giả lập mặt hàng thứ 2 bị hết kho thực tế
                    if (isInventoryShortage)
                    {
                        throw new InvalidOperationException("Mặt hàng thứ hai đã hết tồn kho thực tế!");
                    }

                    // 4. Nếu không có lỗi thì mới Commit
                    transaction.Commit();
                    Console.WriteLine("-> GIAO DỊCH COMMIT THÀNH CÔNG!");
                }
                catch (Exception ex)
                {
                    // 5. Khi bắt được lỗi -> Lập tức Rollback
                    Console.WriteLine($"\n[PHÁT SINH LỖI]: {ex.Message}");
                    transaction.Rollback();
                    Console.WriteLine("-> [HỆ THỐNG]: Đã kích hoạt transaction.Rollback()!");
                    Console.WriteLine("-> Toàn bộ thay đổi của Bước 1 đã được hoàn trả, tồn kho SP 1 không bị trừ!");
                }

                // Đối soát lại trên CSDL sau khi Rollback
                int stockAfterRollback = 0;
                using (SqlCommand cmdCheck = new SqlCommand("SELECT StockQuantity FROM Products WHERE ProductId = 1", connection))
                {
                    object? res = cmdCheck.ExecuteScalar();
                    stockAfterRollback = res != null ? Convert.ToInt32(res) : 0;
                }

                Console.WriteLine($"\n[ĐỐI SOÁT CSDL]: Tồn kho SP 1 sau khi Rollback = {stockAfterRollback} đơn vị.");
                if (originalStock == stockAfterRollback)
                {
                    Console.WriteLine("-> [CHỨNG MINH ACID]: Tính nguyên tử (Atomicity) được đảm bảo 100%! Tồn kho không bị trừ lệch.");
                }
            }

            Console.WriteLine("\n=========================================================================");
            Console.WriteLine("-> Hoàn thành Tiết 4. Nhấn phím bất kỳ để kết thúc...");
            Console.WriteLine("=========================================================================");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
