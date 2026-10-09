namespace MiniSupermarketWinForms
{
    partial class FormPOS
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
            // FormPOS
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Text = "POS";
            this.BackColor = System.Drawing.Color.White;

            // Left: cart area
            var panelLeft = new System.Windows.Forms.Panel();
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Width = (int)(this.ClientSize.Width * 0.65);

            var txtBarcode = new System.Windows.Forms.TextBox();
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            txtBarcode.Height = 30;
            txtBarcode.PlaceholderText = "Nhập hoặc quét mã vạch và nhấn Enter";
            txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            var dgvCart = new System.Windows.Forms.DataGridView();
            dgvCart.Name = "dgvCart";
            dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            panelLeft.Controls.Add(dgvCart);
            panelLeft.Controls.Add(txtBarcode);

            // Right: customer & payment
            var panelRight = new System.Windows.Forms.Panel();
            panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRight.Padding = new System.Windows.Forms.Padding(12);

            var lblCustomerName = new System.Windows.Forms.Label();
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Text = "Khách vãng lai";
            lblCustomerName.Dock = System.Windows.Forms.DockStyle.Top;
            lblCustomerName.Height = 30;

            var txtCustomerPhone = new System.Windows.Forms.TextBox();
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.PlaceholderText = "SĐT khách (nếu có)";
            txtCustomerPhone.Dock = System.Windows.Forms.DockStyle.Top;
            txtCustomerPhone.Height = 30;

            var lblTotalAmount = new System.Windows.Forms.Label();
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Text = "0 đ";
            lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Top;
            lblTotalAmount.Height = 50;

            var txtCashReceived = new System.Windows.Forms.TextBox();
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.PlaceholderText = "Tiền khách đưa";
            txtCashReceived.Dock = System.Windows.Forms.DockStyle.Top;
            txtCashReceived.Height = 30;
            txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            var lblChange = new System.Windows.Forms.Label();
            lblChange.Name = "lblChange";
            lblChange.Text = "0 đ";
            lblChange.Dock = System.Windows.Forms.DockStyle.Top;
            lblChange.Height = 30;

            var btnCheckout = new System.Windows.Forms.Button();
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Text = "THANH TOÁN";
            btnCheckout.Dock = System.Windows.Forms.DockStyle.Top;
            btnCheckout.Height = 40;
            btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            var btnClearCart = new System.Windows.Forms.Button();
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Text = "HỦY GIỎ HÀNG";
            btnClearCart.Dock = System.Windows.Forms.DockStyle.Top;
            btnClearCart.Height = 32;
            btnClearCart.Click += (s, e) => { /* clear handled in code-behind */ };

            panelRight.Controls.Add(btnClearCart);
            panelRight.Controls.Add(btnCheckout);
            panelRight.Controls.Add(lblChange);
            panelRight.Controls.Add(txtCashReceived);
            panelRight.Controls.Add(lblTotalAmount);
            panelRight.Controls.Add(txtCustomerPhone);
            panelRight.Controls.Add(lblCustomerName);

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.ResumeLayout(false);
        }
    }
}

