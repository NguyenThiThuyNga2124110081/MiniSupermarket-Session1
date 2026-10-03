using MiniSupermarket.WinForms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormCategoryManagement : Form
    {
        // Hãy kiểm tra đúng Port API của bạn (thay 7099 hoặc 7181 theo đúng Backend)
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7099/api/")
        };

        public FormCategoryManagement()
        {
            InitializeComponent();

            // Gắn sự kiện cho các nút CRUD
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;
            btnLoad.Click += btnLoad_Click;

            // Gắn sự kiện điều hướng chuyển Form
            if (btnCustomerManagement != null)
                btnCustomerManagement.Click += btnCustomerManagement_Click;

            if (btnProductManagement != null)
                btnProductManagement.Click += btnProductManagement_Click;

            // Sự kiện bảng & Form
            dgvCategories.CellClick += dgvCategories_CellClick;
            this.Load += FormCategoryManagement_Load;
        }

        // Cập nhật Header đính kèm Bearer Token từ SessionManager
        private void AttachBearerToken()
        {
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        // Khi mở Form: Kiểm tra Role để phân quyền giao diện UI
        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            // Nếu không phải Admin (ví dụ: Cashier) thì ẩn/khóa các chức năng CUD
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                txtCategoryName.ReadOnly = true;
                txtDescription.ReadOnly = true;
            }

            await LoadDataAsync();
        }

        // Tải danh sách nhóm hàng
        private async Task LoadDataAsync()
        {
            try
            {
                AttachBearerToken();

                var categories =
                    await _client.GetFromJsonAsync<List<CategoryDto>>("categories");

                dgvCategories.DataSource = categories;

                // Đổi tên tiêu đề các cột hiển thị cho đẹp
                if (dgvCategories.Columns["CategoryId"] != null)
                    dgvCategories.Columns["CategoryId"].HeaderText = "Mã ID";

                if (dgvCategories.Columns["CategoryName"] != null)
                    dgvCategories.Columns["CategoryName"].HeaderText = "Tên Nhóm hàng";

                if (dgvCategories.Columns["Description"] != null)
                    dgvCategories.Columns["Description"].HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Server: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tải lại
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            ClearInputs();
            await LoadDataAsync();
        }

        // Click vào dòng trong bảng
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

                txtId.Text = row.Cells["CategoryId"]?.Value?.ToString() ?? "";
                txtCategoryName.Text = row.Cells["CategoryName"]?.Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? "";
            }
        }

        // THÊM
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCat = new
            {
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            AttachBearerToken();
            var response = await _client.PostAsJsonAsync("categories", newCat);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show(
                    "Thêm mới thất bại!\n\nMã lỗi: " + response.StatusCode +
                    "\n\nChi tiết:\n" + error,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CẬP NHẬT
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            var updateCat = new
            {
                CategoryId = id,
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            AttachBearerToken();
            var response = await _client.PutAsJsonAsync($"categories/{id}", updateCat);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show(
                    "Cập nhật thất bại!\n\nMã lỗi: " + response.StatusCode +
                    "\n\nChi tiết:\n" + error,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // XÓA
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhóm hàng ID = {id}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                AttachBearerToken();
                var response = await _client.DeleteAsync($"categories/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        "Xóa thất bại!\n\nMã lỗi: " + response.StatusCode +
                        "\n\nChi tiết:\n" + error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // TÌM KIẾM
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập từ khóa...")
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                AttachBearerToken();
                var result = await _client.GetFromJsonAsync<List<CategoryDto>>($"categories/search?keyword={keyword}");
                dgvCategories.DataSource = result;
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Chuyển sang Form Quản lý Khách hàng
        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCustomerManagement customerForm = new FormCustomerManagement();
            customerForm.ShowDialog();
            this.Show();
        }

        // Chuyển sang Form Quản lý Sản phẩm
        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang mở giao diện Quản lý Sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa ô nhập
        private void ClearInputs()
        {
            txtId.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
            txtKeyword.Text = "";
        }
    }

    // DTO
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}