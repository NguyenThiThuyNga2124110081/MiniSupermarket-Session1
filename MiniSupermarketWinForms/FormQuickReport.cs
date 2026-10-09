using System;
using System.Drawing;
using System.Windows.Forms;
using MiniSupermarket.WinForms;

namespace MiniSupermarketWinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();
        }

        private void FormQuickReport_Load(object? sender, EventArgs e)
        {
            dtpReportDate.Value = DateTime.Today;
            LoadReportData(DateTime.Today);
        }

        private void btnRunReport_Click(object? sender, EventArgs e)
        {
            // Kiểm soát phân quyền cấp Action (Chỉ Admin mới được phép bấm xem báo cáo doanh thu ca)
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            LoadReportData(dtpReportDate.Value);
        }

        private void LoadReportData(DateTime date)
        {
            // Tính toán/mô phỏng số liệu báo cáo ca theo ngày
            int daySeed = date.Day + date.Month * 31;
            int totalOrders = 85 + (daySeed % 50);
            decimal totalRevenue = totalOrders * 125000m + (daySeed % 10) * 15000m;

            string[] bestSellers = new string[]
            {
                "Trà Chanh Giã Tay",
                "Trà Đào Cam Sả Chill",
                "Trà Sữa Trân Châu Đường Đen",
                "Mẹt Ăn Vặt Thập Cẩm",
                "Khô Gà Lá Chanh Hũ 250g"
            };
            string bestSeller = bestSellers[daySeed % bestSellers.Length];

            lblTotalOrders.Text = $"{totalOrders} đơn";
            lblTotalRevenue.Text = $"{totalRevenue:N0} đ";
            lblBestSeller.Text = bestSeller;
        }
    }
}
