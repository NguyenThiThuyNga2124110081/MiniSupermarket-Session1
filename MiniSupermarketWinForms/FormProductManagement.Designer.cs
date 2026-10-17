namespace MiniSupermarketWinForms
{
    partial class FormProductManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panelPaging;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
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
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.SplitContainer();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.panelPaging = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPaging = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearInputs = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.panelPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop: Thanh tìm kiếm & lọc
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 52;
            this.panelTop.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);

            this.txtSearchBarcode.Location = new System.Drawing.Point(16, 11);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.PlaceholderText = "Tìm theo mã vạch / tên sản phẩm...";
            this.txtSearchBarcode.Size = new System.Drawing.Size(270, 29);
            this.txtSearchBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Location = new System.Drawing.Point(298, 11);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(230, 29);
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.btnSearch.Location = new System.Drawing.Point(538, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 32);
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;

            this.btnLoad.Location = new System.Drawing.Point(651, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 32);
            this.btnLoad.Text = "🔄 Tải lại DS";
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.FlatAppearance.BorderSize = 0;

            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.cboFilterCategory);
            this.panelTop.Controls.Add(this.txtSearchBarcode);

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
            // split.Panel1: dgvProducts (Bảng dữ liệu bên trái) + panelPaging
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.RowTemplate.Height = 32;
            this.dgvProducts.ColumnHeadersHeight = 36;

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
            this.lblPaging.Text = "Trang 1 / 1 (Tổng: 0 SP)";
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

            this.split.Panel1.Controls.Add(this.dgvProducts);
            this.split.Panel1.Controls.Add(this.panelPaging);

            // 
            // split.Panel2: panelDetails (Khung chi tiết bên phải rộng 440px, bố cục chuẩn)
            // 
            this.panelDetails.BackColor = System.Drawing.Color.FromArgb(249, 250, 252);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.AutoScroll = false;

            // Tiêu đề
            this.lblDetailsTitle.Text = "THÔNG TIN CHI TIẾT SẢN PHẨM";
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(24, 30, 48);
            this.lblDetailsTitle.Location = new System.Drawing.Point(20, 16);
            this.lblDetailsTitle.Size = new System.Drawing.Size(390, 28);

            // 1. Mã sản phẩm (ID)
            this.lblId.Text = "Mã sản phẩm (ID - Tự tăng):";
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

            // 2. Mã vạch
            this.lblBarcode.Text = "Mã vạch (Barcode) (*):";
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBarcode.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblBarcode.Location = new System.Drawing.Point(20, 106);
            this.lblBarcode.Size = new System.Drawing.Size(390, 20);

            this.txtBarcode.Location = new System.Drawing.Point(20, 128);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(390, 27);
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 3. Tên sản phẩm
            this.lblProductName.Text = "Tên sản phẩm (*):";
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblProductName.Location = new System.Drawing.Point(20, 162);
            this.lblProductName.Size = new System.Drawing.Size(390, 20);

            this.txtProductName.Location = new System.Drawing.Point(20, 184);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(390, 27);
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 4. Đơn giá
            this.lblPrice.Text = "Đơn giá (VNĐ):";
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblPrice.Location = new System.Drawing.Point(20, 218);
            this.lblPrice.Size = new System.Drawing.Size(390, 20);

            this.nudPrice.Location = new System.Drawing.Point(20, 240);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudPrice.ThousandsSeparator = true;
            this.nudPrice.Size = new System.Drawing.Size(390, 27);
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 5. Tồn kho
            this.lblStock.Text = "Số lượng tồn kho:";
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblStock.Location = new System.Drawing.Point(20, 274);
            this.lblStock.Size = new System.Drawing.Size(390, 20);

            this.nudStock.Location = new System.Drawing.Point(20, 296);
            this.nudStock.Name = "nudStock";
            this.nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudStock.Size = new System.Drawing.Size(390, 27);
            this.nudStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 6. Nhóm hàng
            this.lblCategory.Text = "Danh mục nhóm hàng:";
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(70, 75, 85);
            this.lblCategory.Location = new System.Drawing.Point(20, 330);
            this.lblCategory.Size = new System.Drawing.Size(390, 20);

            this.cboCategory.Location = new System.Drawing.Point(20, 352);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Size = new System.Drawing.Size(390, 28);
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 
            // 3 Nút Thêm, Sửa, Xóa (Bố trí ngang, kích thước to rõ, không bao giờ bị cắt)
            // 
            // Nút Thêm (x = 20, w = 122)
            this.btnAdd.Location = new System.Drawing.Point(20, 398);
            this.btnAdd.Size = new System.Drawing.Size(122, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;

            // Nút Sửa (x = 154, w = 122)
            this.btnUpdate.Location = new System.Drawing.Point(154, 398);
            this.btnUpdate.Size = new System.Drawing.Size(122, 42);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Text = "✏️ Sửa";
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;

            // Nút Xóa (x = 288, w = 122 -> kết thúc tại x = 410, cách lề phải 30px, an toàn 100%)
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
            this.panelDetails.Controls.Add(this.cboCategory);
            this.panelDetails.Controls.Add(this.lblCategory);
            this.panelDetails.Controls.Add(this.nudStock);
            this.panelDetails.Controls.Add(this.lblStock);
            this.panelDetails.Controls.Add(this.nudPrice);
            this.panelDetails.Controls.Add(this.lblPrice);
            this.panelDetails.Controls.Add(this.txtProductName);
            this.panelDetails.Controls.Add(this.lblProductName);
            this.panelDetails.Controls.Add(this.txtBarcode);
            this.panelDetails.Controls.Add(this.lblBarcode);
            this.panelDetails.Controls.Add(this.txtId);
            this.panelDetails.Controls.Add(this.lblId);
            this.panelDetails.Controls.Add(this.lblDetailsTitle);

            this.split.Panel2.Controls.Add(this.panelDetails);

            // 
            // FormProductManagement
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 660);
            this.Controls.Add(this.split);
            this.Controls.Add(this.panelTop);
            this.Name = "FormProductManagement";
            this.Text = "Quản lý Sản phẩm";

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.panelPaging.ResumeLayout(false);
            this.panelPaging.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Thuộc tính tiện ích tương thích mã nguồn giáo trình Buổi 6
        public System.Windows.Forms.TextBox txtSearch => txtSearchBarcode;
        public System.Windows.Forms.Button btnCreate => btnAdd;
    }
}
