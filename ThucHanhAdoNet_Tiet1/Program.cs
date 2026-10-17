/*
 * =========================================================================
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Chủ đề: BUỔI 5 - TIẾT 1: KIẾN TRÚC ADO.NET CĂN BẢN VÀ CÁC THÀNH PHẦN CỐT LÕI
 * =========================================================================
 */
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
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
            Console.WriteLine("   BÁO CÁO THỰC HÀNH TIẾT 1: KIẾN TRÚC ADO.NET VÀ CÁC THÀNH PHẦN CỐT LÕI ");
            Console.WriteLine("   Sinh viên: NGUYỄN THỊ THÚY NGA - MSSV: 2124110081 - Lớp: CCQ2411C    ");
            Console.WriteLine("=========================================================================\n");

            // Chạy lần lượt cả 3 bài tập thực hành của Tiết 1
            Console.WriteLine(">>> 1. CHẠY BÀI TẬP 1:");
            Bai1.ThucHien(connString);
            Console.WriteLine();

            Console.WriteLine(">>> 2. CHẠY BÀI TẬP 2:");
            Bai2.ThucHien(connString);
            Console.WriteLine();

            Console.WriteLine(">>> 3. CHẠY BÀI TẬP 3:");
            Bai3.ThucHien(connString);
            Console.WriteLine();

            Console.WriteLine("=========================================================================");
            Console.WriteLine("-> Hoàn thành toàn bộ Tiết 1! Nhấn phím bất kỳ để kết thúc...");
            Console.WriteLine("=========================================================================");
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
