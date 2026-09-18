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
            groupBox1.Controls.Add(btnLoad);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyword);
            groupBox1.Location = new Point(13, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(775, 65);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(377, 28);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(296, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(6, 29);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(248, 23);
            txtKeyword.TabIndex = 0;
            txtKeyword.Text = "Nhập từ khóa...";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCategories);
            groupBox2.Location = new Point(7, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(458, 300);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhóm hàng";
            // 
            // dgvCategories
            // 
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(6, 22);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.Size = new Size(431, 272);
            dgvCategories.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Controls.Add(txtDescription);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtCategoryName);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtId);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(475, 123);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(304, 291);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin nhóm hàng";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(198, 169);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(102, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(21, 165);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(19, 132);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(279, 23);
            txtDescription.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 114);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Mô tả";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(17, 85);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(281, 23);
            txtCategoryName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 69);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "Tên nhóm hàng";
            // 
            // txtId
            // 
            txtId.Location = new Point(16, 38);
            txtId.Name = "txtId";
            txtId.Size = new Size(288, 23);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã ID";
            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormCategoryManagement";
            Text = "FormCategoryManagement";
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