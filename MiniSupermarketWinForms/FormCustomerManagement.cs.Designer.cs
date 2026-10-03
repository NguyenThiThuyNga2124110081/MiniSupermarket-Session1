namespace MiniSupermarketWinForms
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer components = null;

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
            pnlSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();

            pnlMain = new Panel();
            grpList = new GroupBox();
            dgvCustomers = new DataGridView();

            grpInput = new GroupBox();
            lblCustomerId = new Label();
            txtCustomerId = new TextBox();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblRewardPoints = new Label();
            txtRewardPoints = new TextBox();
            lblMembershipRank = new Label();
            txtMembershipRank = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            pnlSearch.SuspendLayout();
            pnlMain.SuspendLayout();
            grpList.SuspendLayout();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();

            // 
            // pnlSearch (Thanh tìm kiếm phía trên cùng)
            // 
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Height = 50;
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnLoad);

            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 16);
            lblSearch.Text = "Tìm kiếm";

            txtSearch.Location = new System.Drawing.Point(85, 13);
            txtSearch.Size = new System.Drawing.Size(320, 23);

            btnSearch.Text = "Tìm kiếm";
            btnSearch.Location = new System.Drawing.Point(420, 12);
            btnSearch.Size = new System.Drawing.Size(75, 25);

            btnLoad.Text = "Tải lại";
            btnLoad.Location = new System.Drawing.Point(505, 12);
            btnLoad.Size = new System.Drawing.Size(75, 25);

            // 
            // pnlMain (Khung chứa bên dưới)
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Padding = new Padding(10, 0, 10, 10);
            pnlMain.Controls.Add(grpList);
            pnlMain.Controls.Add(grpInput);

            // 
            // grpList (Danh sách khách hàng bên trái)
            // 
            grpList.Text = "Danh sách khách hàng";
            grpList.Dock = DockStyle.Fill;
            grpList.Controls.Add(dgvCustomers);

            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 
            // grpInput (Thông tin Khách hàng bên phải)
            // 
            grpInput.Text = "Thông tin Khách hàng";
            grpInput.Dock = DockStyle.Right;
            grpInput.Width = 350;
            grpInput.Controls.Add(lblCustomerId);
            grpInput.Controls.Add(txtCustomerId);
            grpInput.Controls.Add(lblCustomerName);
            grpInput.Controls.Add(txtCustomerName);
            grpInput.Controls.Add(lblPhoneNumber);
            grpInput.Controls.Add(txtPhoneNumber);
            grpInput.Controls.Add(lblAddress);
            grpInput.Controls.Add(txtAddress);
            grpInput.Controls.Add(lblRewardPoints);
            grpInput.Controls.Add(txtRewardPoints);
            grpInput.Controls.Add(lblMembershipRank);
            grpInput.Controls.Add(txtMembershipRank);
            grpInput.Controls.Add(btnAdd);
            grpInput.Controls.Add(btnUpdate);
            grpInput.Controls.Add(btnDelete);

            // Các ô nhập liệu xếp dọc
            lblCustomerId.Text = "Mã KH";
            lblCustomerId.Location = new System.Drawing.Point(20, 30);
            lblCustomerId.AutoSize = true;

            txtCustomerId.Location = new System.Drawing.Point(120, 27);
            txtCustomerId.Size = new System.Drawing.Size(200, 23);
            txtCustomerId.ReadOnly = true;

            lblCustomerName.Text = "Tên khách hàng";
            lblCustomerName.Location = new System.Drawing.Point(20, 70);
            lblCustomerName.AutoSize = true;

            txtCustomerName.Location = new System.Drawing.Point(120, 67);
            txtCustomerName.Size = new System.Drawing.Size(200, 23);

            lblPhoneNumber.Text = "Số điện thoại";
            lblPhoneNumber.Location = new System.Drawing.Point(20, 110);
            lblPhoneNumber.AutoSize = true;

            txtPhoneNumber.Location = new System.Drawing.Point(120, 107);
            txtPhoneNumber.Size = new System.Drawing.Size(200, 23);

            lblAddress.Text = "Địa chỉ";
            lblAddress.Location = new System.Drawing.Point(20, 150);
            lblAddress.AutoSize = true;

            txtAddress.Location = new System.Drawing.Point(120, 147);
            txtAddress.Size = new System.Drawing.Size(200, 23);

            lblRewardPoints.Text = "Điểm tích lũy";
            lblRewardPoints.Location = new System.Drawing.Point(20, 190);
            lblRewardPoints.AutoSize = true;

            txtRewardPoints.Location = new System.Drawing.Point(120, 187);
            txtRewardPoints.Size = new System.Drawing.Size(200, 23);

            lblMembershipRank.Text = "Hạng thành viên";
            lblMembershipRank.Location = new System.Drawing.Point(20, 230);
            lblMembershipRank.AutoSize = true;

            txtMembershipRank.Location = new System.Drawing.Point(120, 227);
            txtMembershipRank.Size = new System.Drawing.Size(200, 23);

            // Các nút Thao tác bên dưới phần nhập
            btnAdd.Text = "Thêm mới";
            btnAdd.Location = new System.Drawing.Point(20, 280);
            btnAdd.Size = new System.Drawing.Size(90, 30);

            btnUpdate.Text = "Cập nhật";
            btnUpdate.Location = new System.Drawing.Point(130, 280);
            btnUpdate.Size = new System.Drawing.Size(90, 30);

            btnDelete.Text = "Xóa";
            btnDelete.Location = new System.Drawing.Point(240, 280);
            btnDelete.Size = new System.Drawing.Size(80, 30);

            // 
            // FormCustomerManagement
            // 
            ClientSize = new System.Drawing.Size(950, 550);
            Controls.Add(pnlMain);
            Controls.Add(pnlSearch);
            Name = "FormCustomerManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khách hàng";

            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlMain.ResumeLayout(false);
            grpList.ResumeLayout(false);
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnLoad;
        private Panel pnlMain;
        private GroupBox grpList;
        private DataGridView dgvCustomers;
        private GroupBox grpInput;
        private Label lblCustomerId;
        private TextBox txtCustomerId;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblRewardPoints;
        private TextBox txtRewardPoints;
        private Label lblMembershipRank;
        private TextBox txtMembershipRank;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}