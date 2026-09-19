using System;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Thay thế bằng 2 dòng khởi tạo tiêu chuẩn này:
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi chạy màn hình đăng nhập
            Application.Run(new FormLogin());
        }
    }
}