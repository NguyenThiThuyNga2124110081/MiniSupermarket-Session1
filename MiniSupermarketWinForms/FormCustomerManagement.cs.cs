/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Code-behind Quản lý Khách hàng & Tích điểm - Hỗ trợ phân trang LINQ, tìm kiếm và CRUD đồng bộ SQL Server
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms;
using MiniSupermarket.WinForms.Services;

namespace MiniSupermarketWinForms
{
    public class CustomerItemViewDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = "Chuẩn";
    }

    public partial class FormCustomerManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 10;
        private int _totalPages = 1;

        public FormCustomerManagement()
        {
            InitializeComponent();

            this.Load += FormCustomerManagement_Load;
            this.Resize += (s, e) => AdjustSplitter();

            // Tìm kiếm và Phân trang
            this.btnSearch.Click += btnSearch_Click;
            this.btnLoad.Click += btnLoad_Click;
            this.btnPrev.Click += btnPrev_Click;
            this.btnNext.Click += btnNext_Click;

            // Thao tác CRUD
            this.btnAdd.Click += btnAdd_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnClearInputs.Click += (s, e) => ClearInputFields();

            // Chọn khách hàng trên lưới
            this.dgvCustomers.CellClick += dgvCustomers_CellClick;
        }

        private async void FormCustomerManagement_Load(object? sender, EventArgs e)
        {
            AdjustSplitter();
            SetupGridColumns();
            if (cboMembershipRank.Items.Count > 0)
            {
                cboMembershipRank.SelectedIndex = 0;
            }
            await LoadCustomersPagedAsync();
        }

        private void AdjustSplitter()
        {
            try
            {
                int desiredPanel2Width = 440;
                int minPanel1 = 300;
                if (split.Width > desiredPanel2Width + minPanel1)
                {
                    int target = split.Width - desiredPanel2Width;
                    if (target > 50 && target < split.Width - 100)
                    {
                        split.SplitterDistance = target;
                    }
                }
            }
            catch { }
        }

        private void SetupGridColumns()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            dgvCustomers.RowTemplate.Height = 32;
            dgvCustomers.ColumnHeadersHeight = 36;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 248);
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerId",
                HeaderText = "Mã KH",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Tên Khách Hàng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Số Điện Thoại",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Địa Chỉ Liên Hệ",
                Width = 220
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RewardPoints",
                HeaderText = "Điểm Tích Lũy",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MembershipRank",
                HeaderText = "Hạng Thành Viên",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        // Tải danh sách khách hàng phân trang từ Web API (Bài tập 6.1)
        private async Task LoadCustomersPagedAsync()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string url = $"customers/paged?keyword={Uri.EscapeDataString(search)}&pageNumber={_currentPage}&pageSize={_pageSize}";

                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<CustomerItemViewDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    dgvCustomers.DataSource = result.Items;
                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} KH)";

                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách khách hàng: {ex.Message}", "Lỗi kết nối API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Điều hướng chuyển trang
        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadCustomersPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadCustomersPagedAsync();
            }
        }

        // Tìm kiếm
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadCustomersPagedAsync();
        }

        // Tải lại dữ liệu
        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            _currentPage = 1;
            await LoadCustomersPagedAsync();
            ClearInputFields();
        }

        // Xử lý khi chọn một dòng trên bảng DataGridView
        private void dgvCustomers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].DataBoundItem is CustomerItemViewDto cust)
            {
                txtCustomerId.Text = cust.CustomerId.ToString();
                txtCustomerName.Text = cust.CustomerName;
                txtPhoneNumber.Text = cust.PhoneNumber;
                txtAddress.Text = cust.Address ?? string.Empty;

                if (cust.RewardPoints > nudRewardPoints.Maximum) nudRewardPoints.Maximum = cust.RewardPoints;
                nudRewardPoints.Value = cust.RewardPoints;

                if (!string.IsNullOrEmpty(cust.MembershipRank) && cboMembershipRank.Items.Contains(cust.MembershipRank))
                {
                    cboMembershipRank.SelectedItem = cust.MembershipRank;
                }
                else
                {
                    cboMembershipRank.SelectedIndex = 0;
                }
            }
        }

        // Nút Thêm mới khách hàng
        private async void btnAdd_Click(object? sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }

            var newCustomer = new
            {
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = (int)nudRewardPoints.Value,
                MembershipRank = cboMembershipRank.SelectedItem?.ToString() ?? "Chuẩn"
            };

            try
            {
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var response = await ApiClientService.Client.PostAsJsonAsync("customers", newCustomer);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới khách hàng thành công và đã lưu vào CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    await LoadCustomersPagedAsync();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Thêm thất bại: " + err, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Cập nhật thông tin khách hàng
        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId.Text) || !int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Tên khách hàng và số điện thoại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updatedCustomer = new
            {
                CustomerId = id,
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = (int)nudRewardPoints.Value,
                MembershipRank = cboMembershipRank.SelectedItem?.ToString() ?? "Chuẩn"
            };

            try
            {
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var response = await ApiClientService.Client.PutAsJsonAsync($"customers/{id}", updatedCustomer);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCustomersPagedAsync();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Cập nhật thất bại: " + err, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa khách hàng
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(txtCustomerId.Text) && int.TryParse(txtCustomerId.Text, out int parsedId))
            {
                id = parsedId;
            }
            else if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.DataBoundItem is CustomerItemViewDto item)
            {
                id = item.CustomerId;
            }

            if (id <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCustomerName.Text.Trim();
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{name}' (ID = {id}) khỏi CSDL không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                    {
                        ApiClientService.AttachToken(SessionManager.JwtToken);
                    }

                    var response = await ApiClientService.Client.DeleteAsync($"customers/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                        await LoadCustomersPagedAsync();
                    }
                    else
                    {
                        var err = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Xóa thất bại: " + err, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm xóa trắng ô nhập liệu
        private void ClearInputFields()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            nudRewardPoints.Value = 0;
            if (cboMembershipRank.Items.Count > 0)
            {
                cboMembershipRank.SelectedIndex = 0;
            }
        }
    }
}