namespace MiniSupermarketWinForms
{
    partial class FormMainShell
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelUserFooter;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnLogout;

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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelUserFooter = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // 
            // panelSidebar (Thanh điều hướng bên trái)
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(230, 720);
            this.panelSidebar.TabIndex = 0;

            // Logo MiniMart
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblLogo.Text = "🛒 MiniMart POS";
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Height = 60;
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Buttons
            this.btnUserManage = CreateSidebarButton("🛡 Quản trị Tài khoản");
            this.btnUserManage.Click += new System.EventHandler(this.btnUserManage_Click);

            this.btnReports = CreateSidebarButton("📊 Báo cáo Doanh thu");
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            this.btnCustomer = CreateSidebarButton("👥 Quản lý Khách hàng");
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);

            this.btnProduct = CreateSidebarButton("📦 Quản lý Sản phẩm");
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);

            this.btnCategory = CreateSidebarButton("📁 Quản lý Danh mục");
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);

            this.btnPOS = CreateSidebarButton("🛒 Bán hàng (POS)");
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);

            // panelUserFooter chứa nút btnLogout
            this.panelUserFooter = new System.Windows.Forms.Panel();
            this.panelUserFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUserFooter.Height = 60;

            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.panelUserFooter.Controls.Add(this.btnLogout);

            // Add controls in reverse order so lblLogo is topmost, followed by btnPOS, btnCategory, ...
            this.panelSidebar.Controls.Add(this.panelUserFooter);
            this.panelSidebar.Controls.Add(this.btnUserManage);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnCustomer);
            this.panelSidebar.Controls.Add(this.btnProduct);
            this.panelSidebar.Controls.Add(this.btnCategory);
            this.panelSidebar.Controls.Add(this.btnPOS);
            this.panelSidebar.Controls.Add(this.lblLogo);

            // 
            // panelTopHeader (Thanh tiêu đề trên)
            // 
            this.panelTopHeader.BackColor = System.Drawing.Color.White;
            this.panelTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHeader.Location = new System.Drawing.Point(230, 0);
            this.panelTopHeader.Name = "panelTopHeader";
            this.panelTopHeader.Size = new System.Drawing.Size(1050, 60);
            this.panelTopHeader.TabIndex = 1;

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";

            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblUserInfo.AutoSize = false;
            this.lblUserInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserInfo.Width = 420;
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserInfo.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblUserInfo.Text = "Xin chào: ...";

            this.panelTopHeader.Controls.Add(this.lblTitle);
            this.panelTopHeader.Controls.Add(this.lblUserInfo);

            // 
            // panelMainContent (Vùng chứa trung tâm)
            // 
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(230, 60);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1050, 660);
            this.panelMainContent.TabIndex = 2;

            // 
            // FormMainShell
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTopHeader);
            this.Controls.Add(this.panelSidebar);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini";
            this.Load += new System.EventHandler(this.FormMainShell_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button CreateSidebarButton(string text)
        {
            var btn = new System.Windows.Forms.Button();
            btn.Text = text;
            btn.Height = 45;
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            return btn;
        }

        #endregion
    }
}
