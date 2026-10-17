/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Code-behind Quản trị Tài khoản & Phân quyền (RBAC) - Hỗ trợ phân trang LINQ, tìm kiếm, cập nhật, đổi mật khẩu và khóa/mở tài khoản đồng bộ SQL Server
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms;
using MiniSupermarket.WinForms.Services;

namespace MiniSupermarketWinForms
{
    public class UserItemViewDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class PagedUserViewResult
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<UserItemViewDto> Items { get; set; } = new();
    }

    public partial class FormUserManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 10;
        private int _totalPages = 1;

        public FormUserManagement()
        {
            InitializeComponent();

            this.Load += FormUserManagement_Load;
            this.Resize += (s, e) => AdjustSplitter();

            // Tìm kiếm và Phân trang
            this.btnSearch.Click += btnSearch_Click;
            this.btnLoad.Click += btnLoad_Click;
            this.btnPrev.Click += btnPrev_Click;
            this.btnNext.Click += btnNext_Click;

            // Thao tác Quản trị Tài khoản
            this.btnAddUser.Click += btnAddUser_Click;
            this.btnUpdateUser.Click += btnUpdateUser_Click;
            this.btnToggleLock.Click += btnToggleLock_Click;
            this.btnResetPassword.Click += btnResetPassword_Click;
            this.btnClearInputs.Click += (s, e) => ClearInputFields();

            // Lưới hiển thị & Tương tác
            this.dgvUsers.CellClick += dgvUsers_CellClick;
            this.dgvUsers.CellFormatting += dgvUsers_CellFormatting;
        }

        private async void FormUserManagement_Load(object? sender, EventArgs e)
        {
            AdjustSplitter();
            SetupGridColumns();

            cboRole.Items.Clear();
            cboRole.Items.AddRange(new object[] { "Admin", "Cashier", "Warehouse" });
            cboRole.SelectedIndex = 1;
            chkIsActive.Checked = true;

            await LoadUsersPagedAsync();
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
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.RowTemplate.Height = 34;
            dgvUsers.ColumnHeadersHeight = 38;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 248);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã ID",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "Tên Đăng Nhập",
                Width = 150
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và Tên Nhân Viên",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Vai Trò (Role)",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IsActive",
                HeaderText = "Trạng Thái",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void dgvUsers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvUsers.Columns[e.ColumnIndex].DataPropertyName;

            if (colName == "IsActive" && e.Value is bool isActive)
            {
                e.Value = isActive ? "🟢 Hoạt động" : "🔴 Đã khóa";
                e.FormattingApplied = true;
                if (e.CellStyle != null)
                {
                    if (!isActive)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(40, 167, 69);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }
            }
            else if (colName == "Role" && e.Value is string role)
            {
                if (e.CellStyle != null)
                {
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    if (role == "Admin")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(111, 66, 193);
                    }
                    else if (role == "Cashier")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(13, 110, 253);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(253, 126, 20);
                    }
                }
            }
        }

        // Tải danh sách tài khoản phân trang từ Web API
        private async Task LoadUsersPagedAsync()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string url = $"users/paged?keyword={Uri.EscapeDataString(search)}&pageNumber={_currentPage}&pageSize={_pageSize}";

                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.Client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
                }

                var res = await ApiClientService.Client.GetFromJsonAsync<PagedUserViewResult>(url);
                if (res != null)
                {
                    _totalPages = res.TotalPages < 1 ? 1 : res.TotalPages;
                    _currentPage = res.CurrentPage;

                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {res.TotalItems} tài khoản)";
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    dgvUsers.DataSource = res.Items;
                    dgvUsers.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối máy chủ khi nạp tài khoản: {ex.Message}", "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadUsersPagedAsync();
        }

        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            _currentPage = 1;
            await LoadUsersPagedAsync();
        }

        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadUsersPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadUsersPagedAsync();
            }
        }

        private void dgvUsers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].DataBoundItem is UserItemViewDto user)
            {
                txtId.Text = user.Id.ToString();
                txtUsername.Text = user.Username;
                txtUsername.ReadOnly = true;
                txtPassword.Text = string.Empty;
                txtPassword.PlaceholderText = "(Để trống nếu giữ nguyên)";
                txtFullName.Text = user.FullName;
                cboRole.SelectedItem = user.Role;
                chkIsActive.Checked = user.IsActive;

                btnToggleLock.Text = user.IsActive ? "🔒 Khóa TK" : "🔓 Mở Khóa";
                btnToggleLock.BackColor = user.IsActive ? Color.FromArgb(253, 126, 20) : Color.FromArgb(40, 167, 69);
            }
        }

        private void ClearInputFields()
        {
            txtId.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtUsername.ReadOnly = false;
            txtPassword.Text = string.Empty;
            txtPassword.PlaceholderText = "Nhập mật khẩu cho tài khoản mới";
            txtFullName.Text = string.Empty;
            cboRole.SelectedIndex = 1;
            chkIsActive.Checked = true;

            btnToggleLock.Text = "🔒 Khóa/Mở";
            btnToggleLock.BackColor = Color.FromArgb(253, 126, 20);
            dgvUsers.ClearSelection();
            txtUsername.Focus();
        }

        // Thêm tài khoản mới
        private async void btnAddUser_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu cho tài khoản mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            var newUser = new
            {
                Username = username,
                Password = password,
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier"
            };

            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("users", newUser);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                    await LoadUsersPagedAsync();
                }
                else
                {
                    var err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thêm tài khoản không thành công. Tên đăng nhập có thể đã tồn tại! ({err})", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối khi thêm tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa thông tin tài khoản
        private async void btnUpdateUser_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int userId) || userId <= 0)
            {
                MessageBox.Show("Vui lòng nhấp chọn một tài khoản trên danh sách trước khi sửa!", "Chưa chọn tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updateReq = new
            {
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier",
                IsActive = chkIsActive.Checked,
                Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text.Trim()
            };

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"users/{userId}", updateReq);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersPagedAsync();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật tài khoản trên hệ thống!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối khi cập nhật tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khóa hoặc Mở khóa tài khoản
        private async void btnToggleLock_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int userId) || userId <= 0)
            {
                MessageBox.Show("Vui lòng nhấp chọn một tài khoản trên danh sách để thực hiện Khóa / Mở khóa!", "Chưa chọn tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string actionText = chkIsActive.Checked ? "KHÓA" : "MỞ KHÓA";
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn {actionText} tài khoản '{txtUsername.Text}' không?", "Xác nhận thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var res = await ApiClientService.Client.PutAsync($"users/{userId}/toggle-lock", null);
                if (res.IsSuccessStatusCode)
                {
                    chkIsActive.Checked = !chkIsActive.Checked;
                    btnToggleLock.Text = chkIsActive.Checked ? "🔒 Khóa TK" : "🔓 Mở Khóa";
                    btnToggleLock.BackColor = chkIsActive.Checked ? Color.FromArgb(253, 126, 20) : Color.FromArgb(40, 167, 69);
                    MessageBox.Show($"Đã {actionText.ToLower()} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersPagedAsync();
                }
                else
                {
                    MessageBox.Show("Không thể thay đổi trạng thái tài khoản!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối khi thay đổi trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đổi mật khẩu
        private async void btnResetPassword_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int userId) || userId <= 0)
            {
                MessageBox.Show("Vui lòng nhấp chọn một tài khoản trên danh sách trước khi đổi mật khẩu!", "Chưa chọn tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPass = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(newPass))
            {
                var confirm = MessageBox.Show("Ô mật khẩu đang để trống. Bạn có muốn đặt lại mật khẩu về mặc định là '123456' cho tài khoản này không?", "Xác nhận đặt lại mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    txtPassword.Focus();
                    return;
                }
                newPass = "123456";
            }

            var resetReq = new { NewPassword = newPass };

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"users/{userId}/reset-password", resetReq);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Đổi mật khẩu cho tài khoản '{txtUsername.Text}' thành công! Mật khẩu mới là: {newPass}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Clear();
                    await LoadUsersPagedAsync();
                }
                else
                {
                    MessageBox.Show("Không thể đổi mật khẩu tài khoản!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối khi đổi mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
