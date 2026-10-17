namespace MiniSupermarketWinForms
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelPaging;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.NumericUpDown nudRewardPoints;
        private System.Windows.Forms.Label lblMembershipRank;
        private System.Windows.Forms.ComboBox cboMembershipRank;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelPaging = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPaging = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblRewardPoints = new System.Windows.Forms.Label();
            this.nudRewardPoints = new System.Windows.Forms.NumericUpDown();
            this.lblMembershipRank = new System.Windows.Forms.Label();
            this.cboMembershipRank = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearInputs = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.panelPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRewardPoints)).BeginInit();
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
            this.txtSearch.PlaceholderText = "Tìm theo tên khách hàng / số điện thoại...";
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
            // split.Panel1: dgvCustomers (Bảng dữ liệu bên trái) + panelPaging
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.RowTemplate.Height = 32;
            this.dgvCustomers.ColumnHeadersHeight = 36;

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
            this.lblPaging.Text = "Trang 1 / 1 (Tổng: 0 KH)";
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

            this.split.Panel1.Controls.Add(this.dgvCustomers);
            this.split.Panel1.Controls.Add(this.panelPaging);

            // 
            // split.Panel2: panelDetails (Khung chi tiết bên phải rộng 440px)
            // 
            this.panelDetails.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.AutoScroll = false;

            // Tiêu đề
            this.lblDetailsTitle.Text = "THÔNG TIN CHI TIẾT KHÁCH HÀNG";
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.lblDetailsTitle.Location = new System.Drawing.Point(20, 16);
            this.lblDetailsTitle.Size = new System.Drawing.Size(390, 28);

            // 1. Mã khách hàng (ID)
            this.lblCustomerId.Text = "Mã khách hàng (ID - Tự tăng):";
            this.lblCustomerId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerId.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblCustomerId.Location = new System.Drawing.Point(20, 50);
            this.lblCustomerId.Size = new System.Drawing.Size(390, 20);

            this.txtCustomerId.Location = new System.Drawing.Point(20, 72);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.BackColor = System.Drawing.Color.FromArgb(235, 238, 242);
            this.txtCustomerId.Size = new System.Drawing.Size(390, 27);
            this.txtCustomerId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 2. Tên khách hàng
            this.lblCustomerName.Text = "Tên khách hàng (*):";
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblCustomerName.Location = new System.Drawing.Point(20, 106);
            this.lblCustomerName.Size = new System.Drawing.Size(390, 20);

            this.txtCustomerName.Location = new System.Drawing.Point(20, 128);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(390, 27);
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 3. Số điện thoại
            this.lblPhoneNumber.Text = "Số điện thoại (*):";
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblPhoneNumber.Location = new System.Drawing.Point(20, 162);
            this.lblPhoneNumber.Size = new System.Drawing.Size(390, 20);

            this.txtPhoneNumber.Location = new System.Drawing.Point(20, 184);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(390, 27);
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 4. Địa chỉ
            this.lblAddress.Text = "Địa chỉ liên hệ:";
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblAddress.Location = new System.Drawing.Point(20, 218);
            this.lblAddress.Size = new System.Drawing.Size(390, 20);

            this.txtAddress.Location = new System.Drawing.Point(20, 240);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(390, 27);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 5. Điểm tích lũy
            this.lblRewardPoints.Text = "Điểm thưởng tích lũy (Reward Points):";
            this.lblRewardPoints.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRewardPoints.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblRewardPoints.Location = new System.Drawing.Point(20, 274);
            this.lblRewardPoints.Size = new System.Drawing.Size(390, 20);

            this.nudRewardPoints.Location = new System.Drawing.Point(20, 296);
            this.nudRewardPoints.Name = "nudRewardPoints";
            this.nudRewardPoints.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.nudRewardPoints.ThousandsSeparator = true;
            this.nudRewardPoints.Size = new System.Drawing.Size(390, 27);
            this.nudRewardPoints.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 6. Hạng thành viên
            this.lblMembershipRank.Text = "Hạng thành viên:";
            this.lblMembershipRank.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMembershipRank.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblMembershipRank.Location = new System.Drawing.Point(20, 330);
            this.lblMembershipRank.Size = new System.Drawing.Size(390, 20);

            this.cboMembershipRank.Location = new System.Drawing.Point(20, 352);
            this.cboMembershipRank.Name = "cboMembershipRank";
            this.cboMembershipRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMembershipRank.Items.AddRange(new object[] { "Chuẩn", "Bạc", "Vàng", "Bạch Kim" });
            this.cboMembershipRank.Size = new System.Drawing.Size(390, 28);
            this.cboMembershipRank.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 
            // 3 Nút Thêm, Sửa, Xóa (Bố trí ngang)
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 398);
            this.btnAdd.Size = new System.Drawing.Size(122, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;

            this.btnUpdate.Location = new System.Drawing.Point(154, 398);
            this.btnUpdate.Size = new System.Drawing.Size(122, 42);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Text = "✏️ Sửa";
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;

            this.btnDelete.Location = new System.Drawing.Point(288, 398);
            this.btnDelete.Size = new System.Drawing.Size(122, 42);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;

            // Nút Nhập mới / Xóa trắng ô
            this.btnClearInputs.Location = new System.Drawing.Point(20, 448);
            this.btnClearInputs.Size = new System.Drawing.Size(390, 38);
            this.btnClearInputs.Name = "btnClearInputs";
            this.btnClearInputs.Text = "🔄 Nhập mới / Xóa trắng ô";
            this.btnClearInputs.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearInputs.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClearInputs.ForeColor = System.Drawing.Color.White;
            this.btnClearInputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearInputs.FlatAppearance.BorderSize = 0;

            // Add controls to panelDetails
            this.panelDetails.Controls.Add(this.btnClearInputs);
            this.panelDetails.Controls.Add(this.btnDelete);
            this.panelDetails.Controls.Add(this.btnUpdate);
            this.panelDetails.Controls.Add(this.btnAdd);
            this.panelDetails.Controls.Add(this.cboMembershipRank);
            this.panelDetails.Controls.Add(this.lblMembershipRank);
            this.panelDetails.Controls.Add(this.nudRewardPoints);
            this.panelDetails.Controls.Add(this.lblRewardPoints);
            this.panelDetails.Controls.Add(this.txtAddress);
            this.panelDetails.Controls.Add(this.lblAddress);
            this.panelDetails.Controls.Add(this.txtPhoneNumber);
            this.panelDetails.Controls.Add(this.lblPhoneNumber);
            this.panelDetails.Controls.Add(this.txtCustomerName);
            this.panelDetails.Controls.Add(this.lblCustomerName);
            this.panelDetails.Controls.Add(this.txtCustomerId);
            this.panelDetails.Controls.Add(this.lblCustomerId);
            this.panelDetails.Controls.Add(this.lblDetailsTitle);

            this.split.Panel2.Controls.Add(this.panelDetails);

            // 
            // FormCustomerManagement
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 660);
            this.Controls.Add(this.split);
            this.Controls.Add(this.panelTop);
            this.Name = "FormCustomerManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Khách hàng & Tích điểm";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelPaging.ResumeLayout(false);
            this.panelPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRewardPoints)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}