using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace MiniSupermarketWinForms
{
    public partial class FormCustomerManagement : Form
    {
        private readonly HttpClient _httpClient;
        // Kiểm tra đúng Port API của bạn (thay 7181 bằng Port API đang chạy)
        private const string ApiBaseUrl = "https://localhost:7099/api/Customers";

        public FormCustomerManagement()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            // Đăng ký các sự kiện
            this.Load += FormCustomerManagement_Load;
            btnLoad.Click += btnLoad_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnSearch.Click += btnSearch_Click;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        // Tải danh sách khách hàng từ Web API
        private async System.Threading.Tasks.Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _httpClient.GetFromJsonAsync<List<CustomerDto>>(ApiBaseUrl);
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi chọn một dòng trên bảng DataGridView
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerId.Text = row.Cells["CustomerId"]?.Value?.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"]?.Value?.ToString();
                txtPhoneNumber.Text = row.Cells["PhoneNumber"]?.Value?.ToString();
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString();
                txtRewardPoints.Text = row.Cells["RewardPoints"]?.Value?.ToString();
                txtMembershipRank.Text = row.Cells["MembershipRank"]?.Value?.ToString();
            }
        }

        // Nút Tải lại (Làm mới)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            await LoadCustomersAsync();
        }

        // Nút Thêm mới
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newCustomer = new CustomerDto
            {
                CustomerName = txtCustomerName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RewardPoints = int.TryParse(txtRewardPoints.Text, out int points) ? points : 0,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text) ? "Chuẩn" : txtMembershipRank.Text
            };

            var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, newCustomer);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
                await LoadCustomersAsync();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Cập nhật
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updatedCustomer = new CustomerDto
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RewardPoints = int.TryParse(txtRewardPoints.Text, out int points) ? points : 0,
                MembershipRank = txtMembershipRank.Text
            };

            var response = await _httpClient.PutAsJsonAsync($"{ApiBaseUrl}/{id}", updatedCustomer);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
                await LoadCustomersAsync();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Tìm kiếm
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadCustomersAsync();
                return;
            }

            try
            {
                var customers = await _httpClient.GetFromJsonAsync<List<CustomerDto>>($"{ApiBaseUrl}/search?keyword={keyword}");
                dgvCustomers.DataSource = customers;
            }
            catch
            {
                await LoadCustomersAsync();
            }
        }

        // Hàm xóa trắng ô nhập liệu
        private void ClearInputFields()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtRewardPoints.Clear();
            txtMembershipRank.Clear();
            txtSearch.Clear();
        }
    }

    // Class DTO khớp chính xác với tên các cột trong CSDL (dbo.Customers)
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}