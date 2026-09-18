using System.Net.Http.Json;

namespace MiniSupermarketWinForms
{
    public partial class FormCategoryManagement : Form
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7099/api/")
        };

        public FormCategoryManagement()
        {
            InitializeComponent();

            // Gắn sự kiện cho các nút
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;
            btnLoad.Click += btnLoad_Click;

            // Khi click vào dòng trong bảng
            dgvCategories.CellClick += dgvCategories_CellClick;

            // Khi Form mở
            this.Load += FormCategoryManagement_Load;
        }

        // Khi mở Form
        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Tải danh sách nhóm hàng
        private async Task LoadDataAsync()
        {
            try
            {
                var categories =
                    await _client.GetFromJsonAsync<List<CategoryDto>>("categories");

                dgvCategories.DataSource = categories;
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
            await LoadDataAsync();
        }

        // Click vào dòng trong bảng
        private void dgvCategories_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];

                txtId.Text =
                    row.Cells["CategoryId"].Value?.ToString() ?? "";

                txtCategoryName.Text =
                    row.Cells["CategoryName"].Value?.ToString() ?? "";

                txtDescription.Text =
                    row.Cells["Description"].Value?.ToString() ?? "";
            }
        }

        // THÊM
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newCat = new
            {
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            var response =
                await _client.PostAsJsonAsync("categories", newCat);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm mới thành công!");

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
                MessageBox.Show("Vui lòng chọn nhóm hàng cần sửa!");
                return;
            }

            int id = int.Parse(txtId.Text);

            var updateCat = new
            {
                CategoryId = id,
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            var response =
                await _client.PutAsJsonAsync(
                    $"categories/{id}",
                    updateCat);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật thành công!");

                await LoadDataAsync();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        // XÓA
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!");
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
                var response =
                    await _client.DeleteAsync($"categories/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa thành công!");

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // TÌM KIẾM
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                var result =
                    await _client.GetFromJsonAsync<List<CategoryDto>>(
                        $"categories/search?keyword={keyword}");

                dgvCategories.DataSource = result;
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!");
            }
        }

        // Xóa ô nhập
        private void ClearInputs()
        {
            txtId.Text = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
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