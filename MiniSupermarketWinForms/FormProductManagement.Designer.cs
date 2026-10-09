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
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

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
            this.panelDetails = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            this.txtSearchBarcode.Location = new System.Drawing.Point(12, 12);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.PlaceholderText = "Tìm theo mã vạch / tên sản phẩm...";
            this.txtSearchBarcode.Size = new System.Drawing.Size(260, 27);
            this.txtSearchBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Location = new System.Drawing.Point(285, 12);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(220, 28);
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.btnSearch.Location = new System.Drawing.Point(515, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(41, 100, 180);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;

            this.btnLoad.Location = new System.Drawing.Point(625, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 32);
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
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 50);
            this.split.Name = "split";
            this.split.SplitterDistance = 680;
            this.split.TabIndex = 1;

            // 
            // split.Panel1: dgvProducts
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
            this.split.Panel1.Controls.Add(this.dgvProducts);

            // 
            // split.Panel2: panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.AutoScroll = true;
            this.panelDetails.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);

            var lblDetailsTitle = new System.Windows.Forms.Label();
            lblDetailsTitle.Text = "THÔNG TIN CHI TIẾT SẢN PHẨM";
            lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(41, 100, 180);
            lblDetailsTitle.Location = new System.Drawing.Point(16, 12);
            lblDetailsTitle.Size = new System.Drawing.Size(320, 28);

            // 1. Mã sản phẩm (ID)
            var lblId = new System.Windows.Forms.Label();
            lblId.Text = "Mã sản phẩm (ID):";
            lblId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblId.Location = new System.Drawing.Point(16, 45);
            lblId.Size = new System.Drawing.Size(300, 20);

            this.txtId.Location = new System.Drawing.Point(16, 68);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.txtId.Size = new System.Drawing.Size(310, 27);
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 2. Mã vạch
            var lblBarcode = new System.Windows.Forms.Label();
            lblBarcode.Text = "Mã vạch (Barcode) (*):";
            lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblBarcode.Location = new System.Drawing.Point(16, 102);
            lblBarcode.Size = new System.Drawing.Size(300, 20);

            this.txtBarcode.Location = new System.Drawing.Point(16, 125);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(310, 27);
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 3. Tên sản phẩm
            var lblProductName = new System.Windows.Forms.Label();
            lblProductName.Text = "Tên sản phẩm (*):";
            lblProductName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblProductName.Location = new System.Drawing.Point(16, 159);
            lblProductName.Size = new System.Drawing.Size(300, 20);

            this.txtProductName.Location = new System.Drawing.Point(16, 182);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(310, 27);
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 4. Đơn giá
            var lblPrice = new System.Windows.Forms.Label();
            lblPrice.Text = "Đơn giá (VNĐ):";
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPrice.Location = new System.Drawing.Point(16, 216);
            lblPrice.Size = new System.Drawing.Size(300, 20);

            this.nudPrice.Location = new System.Drawing.Point(16, 239);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudPrice.ThousandsSeparator = true;
            this.nudPrice.Size = new System.Drawing.Size(310, 27);
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 5. Tồn kho
            var lblStock = new System.Windows.Forms.Label();
            lblStock.Text = "Số lượng tồn kho:";
            lblStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStock.Location = new System.Drawing.Point(16, 273);
            lblStock.Size = new System.Drawing.Size(300, 20);

            this.nudStock.Location = new System.Drawing.Point(16, 296);
            this.nudStock.Name = "nudStock";
            this.nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudStock.Size = new System.Drawing.Size(310, 27);
            this.nudStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // 6. Nhóm hàng
            var lblCategory = new System.Windows.Forms.Label();
            lblCategory.Text = "Danh mục nhóm hàng:";
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCategory.Location = new System.Drawing.Point(16, 330);
            lblCategory.Size = new System.Drawing.Size(300, 20);

            this.cboCategory.Location = new System.Drawing.Point(16, 353);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Size = new System.Drawing.Size(310, 28);
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // Buttons: Thêm, Sửa, Xóa
            this.btnAdd.Location = new System.Drawing.Point(16, 395);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 38);
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;

            this.btnUpdate.Location = new System.Drawing.Point(122, 395);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 38);
            this.btnUpdate.Text = "✏️ Sửa";
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;

            this.btnDelete.Location = new System.Drawing.Point(228, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 38);
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;

            this.panelDetails.Controls.Add(this.btnDelete);
            this.panelDetails.Controls.Add(this.btnUpdate);
            this.panelDetails.Controls.Add(this.btnAdd);
            this.panelDetails.Controls.Add(this.cboCategory);
            this.panelDetails.Controls.Add(lblCategory);
            this.panelDetails.Controls.Add(this.nudStock);
            this.panelDetails.Controls.Add(lblStock);
            this.panelDetails.Controls.Add(this.nudPrice);
            this.panelDetails.Controls.Add(lblPrice);
            this.panelDetails.Controls.Add(this.txtProductName);
            this.panelDetails.Controls.Add(lblProductName);
            this.panelDetails.Controls.Add(this.txtBarcode);
            this.panelDetails.Controls.Add(lblBarcode);
            this.panelDetails.Controls.Add(this.txtId);
            this.panelDetails.Controls.Add(lblId);
            this.panelDetails.Controls.Add(lblDetailsTitle);

            this.split.Panel2.Controls.Add(this.panelDetails);

            // 
            // FormProductManagement
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 660);
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
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
