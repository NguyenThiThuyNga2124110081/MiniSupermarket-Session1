namespace MiniSupermarketWinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblBestSeller;
        private System.Windows.Forms.Panel panelCardOrders;
        private System.Windows.Forms.Panel panelCardRevenue;
        private System.Windows.Forms.Panel panelCardBestSeller;
        private System.Windows.Forms.Panel panelTopFilter;
        private System.Windows.Forms.DataGridView dgvCashierReport;
        private System.Windows.Forms.Panel panelGridContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTopFilter = new System.Windows.Forms.Panel();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.panelCardOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.panelCardRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.panelCardBestSeller = new System.Windows.Forms.Panel();
            this.lblBestSeller = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // panelTopFilter
            // 
            this.panelTopFilter.BackColor = System.Drawing.Color.White;
            this.panelTopFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopFilter.Height = 75;
            this.panelTopFilter.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);

            var lblDatePrompt = new System.Windows.Forms.Label();
            lblDatePrompt.Text = "Chọn ngày xem báo cáo:";
            lblDatePrompt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblDatePrompt.Location = new System.Drawing.Point(20, 24);
            lblDatePrompt.AutoSize = true;

            this.dtpReportDate.Location = new System.Drawing.Point(220, 22);
            this.dtpReportDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportDate.Width = 150;

            this.btnRunReport.Text = "📊 Xem Báo Cáo Ca";
            this.btnRunReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.FlatAppearance.BorderSize = 0;
            this.btnRunReport.Location = new System.Drawing.Point(390, 18);
            this.btnRunReport.Size = new System.Drawing.Size(180, 38);
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);

            this.panelTopFilter.Controls.Add(lblDatePrompt);
            this.panelTopFilter.Controls.Add(this.dtpReportDate);
            this.panelTopFilter.Controls.Add(this.btnRunReport);

            // Container for 3 cards
            var panelCards = new System.Windows.Forms.TableLayoutPanel();
            panelCards.Dock = System.Windows.Forms.DockStyle.Top;
            panelCards.Height = 200;
            panelCards.ColumnCount = 3;
            panelCards.RowCount = 1;
            panelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            panelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            panelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            panelCards.Padding = new System.Windows.Forms.Padding(16, 20, 16, 20);

            // Card 1: Tổng số hóa đơn
            this.panelCardOrders.BackColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.panelCardOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardOrders.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardOrders.Padding = new System.Windows.Forms.Padding(16);

            var lblTitleOrders = new System.Windows.Forms.Label();
            lblTitleOrders.Text = "TỔNG SỐ HÓA ĐƠN";
            lblTitleOrders.ForeColor = System.Drawing.Color.WhiteSmoke;
            lblTitleOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitleOrders.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitleOrders.Height = 30;

            this.lblTotalOrders.Text = "128 đơn";
            this.lblTotalOrders.ForeColor = System.Drawing.Color.White;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelCardOrders.Controls.Add(this.lblTotalOrders);
            this.panelCardOrders.Controls.Add(lblTitleOrders);

            // Card 2: Tổng doanh thu
            this.panelCardRevenue.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.panelCardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardRevenue.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardRevenue.Padding = new System.Windows.Forms.Padding(16);

            var lblTitleRevenue = new System.Windows.Forms.Label();
            lblTitleRevenue.Text = "TỔNG DOANH THU";
            lblTitleRevenue.ForeColor = System.Drawing.Color.WhiteSmoke;
            lblTitleRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitleRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitleRevenue.Height = 30;

            this.lblTotalRevenue.Text = "15.420.000 đ";
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelCardRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelCardRevenue.Controls.Add(lblTitleRevenue);

            // Card 3: Mặt hàng bán chạy nhất
            this.panelCardBestSeller.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.panelCardBestSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardBestSeller.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardBestSeller.Padding = new System.Windows.Forms.Padding(16);

            var lblTitleBestSeller = new System.Windows.Forms.Label();
            lblTitleBestSeller.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            lblTitleBestSeller.ForeColor = System.Drawing.Color.WhiteSmoke;
            lblTitleBestSeller.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitleBestSeller.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitleBestSeller.Height = 30;

            this.lblBestSeller.Text = "Trà Sữa Trân Châu";
            this.lblBestSeller.ForeColor = System.Drawing.Color.White;
            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBestSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBestSeller.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelCardBestSeller.Controls.Add(this.lblBestSeller);
            this.panelCardBestSeller.Controls.Add(lblTitleBestSeller);

            panelCards.Controls.Add(this.panelCardOrders, 0, 0);
            panelCards.Controls.Add(this.panelCardRevenue, 1, 0);
            panelCards.Controls.Add(this.panelCardBestSeller, 2, 0);

            //
            // panelGridContainer & dgvCashierReport
            //
            this.panelGridContainer = new System.Windows.Forms.Panel();
            this.panelGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridContainer.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);

            var lblGridTitle = new System.Windows.Forms.Label();
            lblGridTitle.Text = "CHI TIẾT DOANH THU THEO TỪNG THU NGÂN (STORED PROCEDURE: sp_GetRevenueByCashier)";
            lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblGridTitle.Height = 35;

            this.dgvCashierReport = new System.Windows.Forms.DataGridView();
            this.dgvCashierReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashierReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvCashierReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCashierReport.ReadOnly = true;
            this.dgvCashierReport.AllowUserToAddRows = false;
            this.dgvCashierReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashierReport.RowHeadersVisible = false;
            this.dgvCashierReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashierReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCashierReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.panelGridContainer.Controls.Add(this.dgvCashierReport);
            this.panelGridContainer.Controls.Add(lblGridTitle);

            // 
            // FormQuickReport
            // 
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.Controls.Add(this.panelGridContainer);
            this.Controls.Add(panelCards);
            this.Controls.Add(this.panelTopFilter);
            this.Text = "BÁO CÁO DOANH THU & HIỆU SUẤT";
            this.Load += new System.EventHandler(this.FormQuickReport_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
