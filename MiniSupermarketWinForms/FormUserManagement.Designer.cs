namespace MiniSupermarketWinForms
{
    partial class FormUserManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // FormUserManagement
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Quản trị Tài khoản";
            this.BackColor = System.Drawing.Color.White;
            // Layout: left grid, right form
            var split = new System.Windows.Forms.SplitContainer();
            split.Dock = System.Windows.Forms.DockStyle.Fill;
            split.SplitterDistance = (int)(this.ClientSize.Width * 0.6);

            var dgvUsers = new System.Windows.Forms.DataGridView();
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            split.Panel1.Controls.Add(dgvUsers);

            var panelRight = new System.Windows.Forms.Panel();
            panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRight.Padding = new System.Windows.Forms.Padding(8);

            var txtUsername = new System.Windows.Forms.TextBox() { Name = "txtUsername", Dock = System.Windows.Forms.DockStyle.Top, PlaceholderText = "Tài khoản" };
            var txtPassword = new System.Windows.Forms.TextBox() { Name = "txtPassword", Dock = System.Windows.Forms.DockStyle.Top, PlaceholderText = "Mật khẩu" };
            var txtFullName = new System.Windows.Forms.TextBox() { Name = "txtFullName", Dock = System.Windows.Forms.DockStyle.Top, PlaceholderText = "Họ và tên" };
            var cboRole = new System.Windows.Forms.ComboBox() { Name = "cboRole", Dock = System.Windows.Forms.DockStyle.Top };

            var btnAddUser = new System.Windows.Forms.Button() { Name = "btnAddUser", Text = "Thêm người dùng", Dock = System.Windows.Forms.DockStyle.Top };
            var btnResetPassword = new System.Windows.Forms.Button() { Name = "btnResetPassword", Text = "Reset mật khẩu", Dock = System.Windows.Forms.DockStyle.Top };
            var btnToggleLock = new System.Windows.Forms.Button() { Name = "btnToggleLock", Text = "Khóa/Mở khóa", Dock = System.Windows.Forms.DockStyle.Top };

            panelRight.Controls.Add(btnToggleLock);
            panelRight.Controls.Add(btnResetPassword);
            panelRight.Controls.Add(btnAddUser);
            panelRight.Controls.Add(cboRole);
            panelRight.Controls.Add(txtFullName);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(txtUsername);

            split.Panel2.Controls.Add(panelRight);

            this.Controls.Add(split);
            this.ResumeLayout(false);
        }
    }
}
