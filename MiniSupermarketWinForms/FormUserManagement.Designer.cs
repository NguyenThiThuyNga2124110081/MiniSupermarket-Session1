namespace MiniSupermarketWinForms
{
    partial class FormUserManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panelPaging;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnToggleLock;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnClearInputs;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.SplitContainer();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panelPaging = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPaging = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnToggleLock = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnClearInputs = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelPaging.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop: Thanh tìm kiếm phía trên cùng
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 52;
            this.panelTop.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);

            this.txtSearch.Location = new System.Drawing.Point(16, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm theo tên đăng nhập / họ tên / vai trò...";
            this.txtSearch.Size = new System.Drawing.Size(320, 29);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.btnSearch.Location = new System.Drawing.Point(348, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 32);
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;

            this.btnLoad.Location = new System.Drawing.Point(468, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 32);
            this.btnLoad.Text = "🔄 Tải lại DS";
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.FlatAppearance.BorderSize = 0;

            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.txtSearch);

            // 
            // split: Phân chia Bảng bên trái và Chi tiết bên phải
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 52);
            this.split.Name = "split";
            this.split.Size = new System.Drawing.Size(1200, 608);
            this.split.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.split.SplitterDistance = 760;
            this.split.TabIndex = 1;

            // 
            // split.Panel1: dgvUsers (Bảng dữ liệu bên trái) + panelPaging
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.RowTemplate.Height = 32;
            this.dgvUsers.ColumnHeadersHeight = 36;

            // 
            // panelPaging: Thanh điều hướng phân trang (Dưới bảng dữ liệu)
            // 
            this.panelPaging.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPaging.Height = 48;
            this.panelPaging.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);

            this.btnPrev.Location = new System.Drawing.Point(16, 8);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(140, 32);
            this.btnPrev.Text = "⏪ Trang trước";
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.Enabled = false;

            this.lblPaging.Location = new System.Drawing.Point(170, 14);
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.AutoSize = true;
            this.lblPaging.Text = "Trang 1 / 1 (Tổng: 0 TK)";
            this.lblPaging.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPaging.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);

            this.btnNext.Location = new System.Drawing.Point(400, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 32);
            this.btnNext.Text = "Trang sau ⏩";
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Enabled = false;

            this.panelPaging.Controls.Add(this.btnPrev);
            this.panelPaging.Controls.Add(this.lblPaging);
            this.panelPaging.Controls.Add(this.btnNext);

            this.split.Panel1.Controls.Add(this.dgvUsers);
            this.split.Panel1.Controls.Add(this.panelPaging);

            // 
            // split.Panel2: panelDetails (Khung chi tiết bên phải rộng 440px)
            // 
            this.panelDetails.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.AutoScroll = false;

            // Tiêu đề
            this.lblDetailsTitle.Text = "THÔNG TIN TÀI KHOẢN NGƯỜI DÙNG";
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.lblDetailsTitle.Location = new System.Drawing.Point(20, 16);
            this.lblDetailsTitle.Size = new System.Drawing.Size(390, 28);

            // 1. Mã người dùng (ID)
            this.lblId.Text = "Mã ID (Tự tăng):";
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblId.Location = new System.Drawing.Point(20, 50);
            this.lblId.Size = new System.Drawing.Size(390, 20);

            this.txtId.Location = new System.Drawing.Point(20, 72);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.BackColor = System.Drawing.Color.FromArgb(235, 238, 242);
            this.txtId.Size = new System.Drawing.Size(390, 27);
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 2. Tên đăng nhập
            this.lblUsername.Text = "Tên đăng nhập (Username) (*):";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblUsername.Location = new System.Drawing.Point(20, 106);
            this.lblUsername.Size = new System.Drawing.Size(390, 20);

            this.txtUsername.Location = new System.Drawing.Point(20, 128);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(390, 27);
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 3. Mật khẩu
            this.lblPassword.Text = "Mật khẩu (*):";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblPassword.Location = new System.Drawing.Point(20, 162);
            this.lblPassword.Size = new System.Drawing.Size(390, 20);

            this.txtPassword.Location = new System.Drawing.Point(20, 184);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(390, 27);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.UseSystemPasswordChar = true;

            // 4. Họ và tên
            this.lblFullName.Text = "Họ và tên nhân viên (*):";
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblFullName.Location = new System.Drawing.Point(20, 218);
            this.lblFullName.Size = new System.Drawing.Size(390, 20);

            this.txtFullName.Location = new System.Drawing.Point(20, 240);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(390, 27);
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 5. Vai trò
            this.lblRole.Text = "Phân quyền vai trò (Role) (*):";
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblRole.Location = new System.Drawing.Point(20, 274);
            this.lblRole.Size = new System.Drawing.Size(390, 20);

            this.cboRole.Location = new System.Drawing.Point(20, 296);
            this.cboRole.Name = "cboRole";
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Items.AddRange(new object[] { "Admin", "Cashier", "Warehouse" });
            this.cboRole.Size = new System.Drawing.Size(390, 28);
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 6. Trạng thái hoạt động
            this.chkIsActive.Location = new System.Drawing.Point(20, 335);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Text = "Tài khoản đang hoạt động (Active)";
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkIsActive.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.chkIsActive.Checked = true;
            this.chkIsActive.AutoSize = true;

            // 
            // 3 Nút Thêm, Sửa, Khóa/Mở (Bố trí ngang)
            // 
            this.btnAddUser.Location = new System.Drawing.Point(20, 380);
            this.btnAddUser.Size = new System.Drawing.Size(122, 42);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Text = "➕ Thêm";
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.FlatAppearance.BorderSize = 0;

            this.btnUpdateUser.Location = new System.Drawing.Point(154, 380);
            this.btnUpdateUser.Size = new System.Drawing.Size(122, 42);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Text = "✏️ Sửa";
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.FlatAppearance.BorderSize = 0;

            this.btnToggleLock.Location = new System.Drawing.Point(288, 380);
            this.btnToggleLock.Size = new System.Drawing.Size(122, 42);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Text = "🔒 Khóa/Mở";
            this.btnToggleLock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleLock.BackColor = System.Drawing.Color.FromArgb(253, 126, 20);
            this.btnToggleLock.ForeColor = System.Drawing.Color.White;
            this.btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLock.FlatAppearance.BorderSize = 0;

            // 2 Nút Đổi mật khẩu & Xóa trắng ô
            this.btnResetPassword.Location = new System.Drawing.Point(20, 432);
            this.btnResetPassword.Size = new System.Drawing.Size(190, 38);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Text = "🔑 Đổi mật khẩu";
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(111, 66, 193);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.FlatAppearance.BorderSize = 0;

            this.btnClearInputs.Location = new System.Drawing.Point(220, 432);
            this.btnClearInputs.Size = new System.Drawing.Size(190, 38);
            this.btnClearInputs.Name = "btnClearInputs";
            this.btnClearInputs.Text = "🔄 Xóa trắng ô";
            this.btnClearInputs.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearInputs.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClearInputs.ForeColor = System.Drawing.Color.White;
            this.btnClearInputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearInputs.FlatAppearance.BorderSize = 0;

            // Add controls to panelDetails
            this.panelDetails.Controls.Add(this.btnClearInputs);
            this.panelDetails.Controls.Add(this.btnResetPassword);
            this.panelDetails.Controls.Add(this.btnToggleLock);
            this.panelDetails.Controls.Add(this.btnUpdateUser);
            this.panelDetails.Controls.Add(this.btnAddUser);
            this.panelDetails.Controls.Add(this.chkIsActive);
            this.panelDetails.Controls.Add(this.cboRole);
            this.panelDetails.Controls.Add(this.lblRole);
            this.panelDetails.Controls.Add(this.txtFullName);
            this.panelDetails.Controls.Add(this.lblFullName);
            this.panelDetails.Controls.Add(this.txtPassword);
            this.panelDetails.Controls.Add(this.lblPassword);
            this.panelDetails.Controls.Add(this.txtUsername);
            this.panelDetails.Controls.Add(this.lblUsername);
            this.panelDetails.Controls.Add(this.txtId);
            this.panelDetails.Controls.Add(this.lblId);
            this.panelDetails.Controls.Add(this.lblDetailsTitle);

            this.split.Panel2.Controls.Add(this.panelDetails);

            // 
            // FormUserManagement
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 660);
            this.Controls.Add(this.split);
            this.Controls.Add(this.panelTop);
            this.Name = "FormUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị Tài khoản & Phân quyền";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelPaging.ResumeLayout(false);
            this.panelPaging.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
