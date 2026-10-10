namespace MiniSupermarketWinForms
{
    partial class FormCategoryManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnCustomerManagement = new Button();
            btnProductManagement = new Button();
            btnLoad = new Button();
            btnSearch = new Button();
            txtKeyword = new TextBox();
            groupBox2 = new GroupBox();
            dgvCategories = new DataGridView();
            groupBox3 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtDescription = new TextBox();
            label3 = new Label();
            txtCategoryName = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnCustomerManagement);
            groupBox1.Controls.Add(btnProductManagement);
            groupBox1.Controls.Add(btnLoad);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyword);
            groupBox1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(14, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1012, 65);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm & Điều hướng";
            // 
            // btnCustomerManagement
            // 
            btnCustomerManagement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCustomerManagement.BackColor = Color.FromArgb(70, 130, 180);
            btnCustomerManagement.FlatStyle = FlatStyle.Flat;
            btnCustomerManagement.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCustomerManagement.ForeColor = Color.White;
            btnCustomerManagement.Location = new Point(695, 23);
            btnCustomerManagement.Name = "btnCustomerManagement";
            btnCustomerManagement.Size = new Size(150, 32);
            btnCustomerManagement.TabIndex = 3;
            btnCustomerManagement.Text = "👥 Quản lý Khách hàng";
            btnCustomerManagement.UseVisualStyleBackColor = false;
            // 
            // btnProductManagement
            // 
            btnProductManagement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProductManagement.BackColor = Color.FromArgb(46, 139, 87);
            btnProductManagement.FlatStyle = FlatStyle.Flat;
            btnProductManagement.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnProductManagement.ForeColor = Color.White;
            btnProductManagement.Location = new Point(853, 23);
            btnProductManagement.Name = "btnProductManagement";
            btnProductManagement.Size = new Size(150, 32);
            btnProductManagement.TabIndex = 4;
            btnProductManagement.Text = "📦 Quản lý Sản phẩm";
            btnProductManagement.UseVisualStyleBackColor = false;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(240, 240, 240);
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoad.Location = new Point(390, 24);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(90, 30);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "🔄 Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(240, 240, 240);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(292, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtKeyword
            // 
            txtKeyword.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtKeyword.Location = new Point(14, 26);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập tên nhóm hàng cần tìm...";
            txtKeyword.Size = new Size(270, 24);
            txtKeyword.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dgvCategories);
            groupBox2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(14, 85);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(8);
            groupBox2.Size = new Size(650, 520);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhóm hàng (15 danh mục)";
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.BorderStyle = BorderStyle.Fixed3D;
            dgvCategories.ColumnHeadersHeight = 35;
            dgvCategories.Dock = DockStyle.Fill;
            dgvCategories.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCategories.Location = new Point(8, 25);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersWidth = 30;
            dgvCategories.RowTemplate.Height = 32;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(634, 487);
            dgvCategories.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Controls.Add(txtDescription);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtCategoryName);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtId);
            groupBox3.Controls.Add(label1);
            groupBox3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(674, 85);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(352, 520);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin chi tiết nhóm hàng";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(211, 47, 47);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(236, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 38);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑 Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(30, 136, 229);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(128, 300);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 38);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 125, 50);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 300);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 38);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(20, 185);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(312, 90);
            txtDescription.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 165);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 4;
            label3.Text = "Mô tả nhóm hàng";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCategoryName.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoryName.Location = new Point(20, 120);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "Ví dụ: Trà Chanh, Ăn Vặt...";
            txtCategoryName.Size = new Size(312, 24);
            txtCategoryName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(20, 100);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "Tên nhóm hàng";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtId.BackColor = Color.FromArgb(240, 240, 240);
            txtId.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(20, 58);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(312, 24);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 38);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã ID (Tự tăng)";
            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            ClientSize = new Size(1040, 620);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new Size(800, 500);
            Name = "FormCategoryManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Danh mục Nhóm hàng";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtKeyword;
        private Button btnLoad;
        private Button btnCustomerManagement;
        private Button btnProductManagement;
        private GroupBox groupBox2;
        private DataGridView dgvCategories;
        private GroupBox groupBox3;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtDescription;
        private Label label3;
        private TextBox txtCategoryName;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button btnDelete;
    }
}