/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Form Quản lý Danh mục Nhóm hàng - Hỗ trợ phân trang LINQ, tìm kiếm và CRUD đồng bộ SQL Server
 */
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
        private int _currentPage = 1;
        private readonly int _pageSize = 5;
        private int _totalPages = 1;

        public FormCategoryManagement()
        {
            InitializeComponent();

            // Gắn sự kiện cho các nút CRUD
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;
            btnLoad.Click += btnLoad_Click;

            // Gắn sự kiện phân trang
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;

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
                ApiClientService.Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        // Khi mở Form: Kiểm tra Role để phân quyền giao diện UI
        private async void FormCategoryManagement_Load(object? sender, EventArgs e)
        {
            // Cấp quyền theo RBAC Buổi 4:
            // Admin và Warehouse có toàn quyền quản lý Danh mục nhóm hàng
            // Cashier chỉ được xem (khóa các chức năng Thêm, Sửa, Xóa)
            bool isCashier = string.Equals(SessionManager.CurrentRole, "Cashier", StringComparison.OrdinalIgnoreCase);

            btnAdd.Enabled = !isCashier;
            btnUpdate.Enabled = !isCashier;
            btnDelete.Enabled = !isCashier;

            txtCategoryName.ReadOnly = isCashier;
            txtDescription.ReadOnly = isCashier;

            await LoadDataAsync();
        }

        // Tải danh sách nhóm hàng phân trang từ Backend API
        private async Task LoadDataAsync()
        {
            try
            {
                AttachBearerToken();
                string search = txtKeyword.Text.Trim();
                if (search == "Nhập từ khóa..." || search == "Nhập tên nhóm hàng cần tìm...") search = "";

                string url = $"categories/paged?keyword={Uri.EscapeDataString(search)}&pageNumber={_currentPage}&pageSize={_pageSize}";

                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<CategoryDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    dgvCategories.DataSource = null;
                    dgvCategories.DataSource = result.Items;

                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} DM)";
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    groupBox2.Text = $"Danh sách nhóm hàng ({result.TotalItems} danh mục)";

                    // Tùy chỉnh tiêu đề và kích thước các cột hiển thị
                    if (dgvCategories.Columns["CategoryId"] != null)
                    {
                        dgvCategories.Columns["CategoryId"].HeaderText = "Mã ID";
                        dgvCategories.Columns["CategoryId"].Width = 80;
                    }

                    if (dgvCategories.Columns["CategoryName"] != null)
                    {
                        dgvCategories.Columns["CategoryName"].HeaderText = "Tên Nhóm hàng";
                        dgvCategories.Columns["CategoryName"].FillWeight = 45;
                    }

                    if (dgvCategories.Columns["Description"] != null)
                    {
                        dgvCategories.Columns["Description"].HeaderText = "Mô tả nhóm hàng";
                        dgvCategories.Columns["Description"].FillWeight = 55;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Backend API: " + ex.Message +
                    "\n\n👉 Hướng dẫn khắc phục:\n1. Hãy đảm bảo dự án Backend MiniSupermarket.API đang chạy trên cổng https://localhost:7099.\n2. Trong Visual Studio, cài đặt Multiple Startup Projects để chạy cả API và WinForms.",
                    "Lỗi kết nối Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Sự kiện chuyển trang
        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadDataAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadDataAsync();
            }
        }

        // Nút Tải lại danh sách
        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtKeyword.Clear();
            _currentPage = 1;
            ClearInputs();
            await LoadDataAsync();
        }

        // Click vào dòng trong bảng để đổ dữ liệu lên các ô nhập
        private void dgvCategories_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategories.Rows[e.RowIndex].DataBoundItem is CategoryDto cat)
            {
                txtId.Text = cat.CategoryId.ToString();
                txtCategoryName.Text = cat.CategoryName;
                txtDescription.Text = cat.Description ?? string.Empty;
            }
            else if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"]?.Value?.ToString() ?? "";
                txtCategoryName.Text = row.Cells["CategoryName"]?.Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? "";
            }
        }

        // ================= THÊM MỚI NHÓM HÀNG =================
        private async void btnAdd_Click(object? sender, EventArgs e)
        {
            string catName = txtCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(catName))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            var newCat = new
            {
                CategoryName = catName,
                Description = txtDescription.Text?.Trim()
            };

            try
            {
                AttachBearerToken();
                var response = await ApiClientService.Client.PostAsJsonAsync("categories", newCat);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới nhóm hàng thành công và đã lưu bền vững vào CSDL SQL Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        $"Thêm mới thất bại từ Server (Mã lỗi HTTP {(int)response.StatusCode})!\n\nChi tiết:\n{error}",
                        "Lỗi từ Server",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối khi gửi yêu cầu thêm mới: " + ex.Message +
                    "\n\n👉 Vui lòng kiểm tra xem Backend MiniSupermarket.API có đang chạy không!",
                    "Lỗi kết nối Backend",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= CẬP NHẬT NHÓM HÀNG =================
        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn một nhóm hàng từ bảng danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string catName = txtCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(catName))
            {
                MessageBox.Show("Tên nhóm hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            var updateCat = new
            {
                CategoryId = id,
                CategoryName = catName,
                Description = txtDescription.Text?.Trim()
            };

            try
            {
                AttachBearerToken();
                var response = await ApiClientService.Client.PutAsJsonAsync($"categories/{id}", updateCat);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật nhóm hàng vào CSDL SQL Server thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        $"Cập nhật thất bại từ Server (Mã lỗi HTTP {(int)response.StatusCode})!\n\nChi tiết:\n{error}",
                        "Lỗi từ Server",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối khi gửi yêu cầu cập nhật: " + ex.Message +
                    "\n\n👉 Vui lòng kiểm tra xem Backend MiniSupermarket.API có đang chạy không!",
                    "Lỗi kết nối Backend",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= XÓA NHÓM HÀNG =================
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn một nhóm hàng từ bảng danh sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhóm hàng '{txtCategoryName.Text}' (Mã ID = {id}) khỏi CSDL SQL Server không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    AttachBearerToken();
                    var response = await ApiClientService.Client.DeleteAsync($"categories/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa nhóm hàng thành công khỏi CSDL SQL Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(
                            $"Xóa thất bại từ Server (Mã lỗi HTTP {(int)response.StatusCode})!\n\nChi tiết:\n{error}",
                            "Lỗi từ Server",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi kết nối khi gửi yêu cầu xóa: " + ex.Message +
                        "\n\n👉 Vui lòng kiểm tra xem Backend MiniSupermarket.API có đang chạy không!",
                        "Lỗi kết nối Backend",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // ================= TÌM KIẾM NHÓM HÀNG =================
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadDataAsync();
        }

        // Chuyển sang Form Quản lý Khách hàng
        private void btnCustomerManagement_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using FormCustomerManagement customerForm = new FormCustomerManagement();
            customerForm.ShowDialog();
            this.Show();
        }

        // Chuyển sang Form Quản lý Sản phẩm
        private void btnProductManagement_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using FormProductManagement prodForm = new FormProductManagement();
            prodForm.ShowDialog();
            this.Show();
        }

        // Xóa các ô nhập liệu
        private void ClearInputs()
        {
            txtId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
        }
    }

    // DTO nhóm hàng
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}