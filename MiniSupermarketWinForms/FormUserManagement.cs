using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms;

namespace MiniSupermarketWinForms
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();

            // wire events
            this.Load += FormUserManagement_Load;
            var btnAdd = this.Controls.Find("btnAddUser", true)[0] as Button;
            if (btnAdd != null) btnAdd.Click += btnAddUser_Click;
        }

        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            var cbo = this.Controls.Find("cboRole", true)[0] as ComboBox;
            if (cbo != null)
            {
                cbo.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
                cbo.SelectedIndex = 1;
            }

            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await ApiClientService.Client.GetFromJsonAsync<List<UserDto>>("users");
                var dgv = this.Controls.Find("dgvUsers", true)[0] as DataGridView;
                if (dgv != null) dgv.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var txtUsername = this.Controls.Find("txtUsername", true)[0] as TextBox;
            var txtPassword = this.Controls.Find("txtPassword", true)[0] as TextBox;
            var txtFullName = this.Controls.Find("txtFullName", true)[0] as TextBox;
            var cboRole = this.Controls.Find("cboRole", true)[0] as ComboBox;

            if (string.IsNullOrWhiteSpace(txtUsername?.Text) || string.IsNullOrWhiteSpace(txtPassword?.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName?.Text.Trim(),
                Role = cboRole?.SelectedItem?.ToString() ?? "Cashier"
            };

            var res = await ApiClientService.Client.PostAsJsonAsync("users", newUser);
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
                if (txtUsername != null) txtUsername.Clear();
                if (txtPassword != null) txtPassword.Clear();
                if (txtFullName != null) txtFullName.Clear();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
