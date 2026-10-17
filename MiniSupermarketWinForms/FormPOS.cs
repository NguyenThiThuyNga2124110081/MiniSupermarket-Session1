using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms;

namespace MiniSupermarketWinForms
{
    public partial class FormPOS : Form
    {
        private readonly List<CartItemDto> _cart = new();

        // Designer components will create controls with these names
        private System.Windows.Forms.TextBox txtBarcode => (System.Windows.Forms.TextBox)this.Controls.Find("txtBarcode", true).FirstOrDefault();
        private System.Windows.Forms.DataGridView dgvCart => (System.Windows.Forms.DataGridView)this.Controls.Find("dgvCart", true).FirstOrDefault();
        private System.Windows.Forms.TextBox txtCustomerPhone => (System.Windows.Forms.TextBox)this.Controls.Find("txtCustomerPhone", true).FirstOrDefault();
        private System.Windows.Forms.Label lblCustomerName => (System.Windows.Forms.Label)this.Controls.Find("lblCustomerName", true).FirstOrDefault();
        private System.Windows.Forms.Label lblTotalAmount => (System.Windows.Forms.Label)this.Controls.Find("lblTotalAmount", true).FirstOrDefault();
        private System.Windows.Forms.TextBox txtCashReceived => (System.Windows.Forms.TextBox)this.Controls.Find("txtCashReceived", true).FirstOrDefault();
        private System.Windows.Forms.Label lblChange => (System.Windows.Forms.Label)this.Controls.Find("lblChange", true).FirstOrDefault();
        private System.Windows.Forms.Button btnCheckout => (System.Windows.Forms.Button)this.Controls.Find("btnCheckout", true).FirstOrDefault();

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();

            var btnClear = this.Controls.Find("btnClearCart", true).FirstOrDefault() as Button;
            if (btnClear != null)
            {
                btnClear.Click += (s, e) =>
                {
                    _cart.Clear();
                    UpdateCartDisplay();
                    if (txtCashReceived != null) txtCashReceived.Clear();
                };
            }
        }

        private void SetupCartGrid()
        {
            if (dgvCart == null) return;
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá", Width = 110 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 70 });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "Thành Tiền", Width = 120 });
        }

        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode?.Text))
            {
                string barcode = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                await AddProductToCartByBarcodeAsync(barcode);
            }
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode)
        {
            try
            {
                ProductDto? product = null;
                try
                {
                    // Ưu tiên tra cứu siêu tốc qua ADO.NET SqlDataReader (<100ms) của Buổi 5
                    product = await ApiClientService.Client.GetFromJsonAsync<ProductDto>($"ado-products/barcode/{barcode}");
                }
                catch
                {
                    // Fallback sang endpoint products thông thường
                    product = await ApiClientService.Client.GetFromJsonAsync<ProductDto>($"products/barcode/{barcode}");
                }

                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã vạch này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existing = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    _cart.Add(new CartItemDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay()
        {
            if (dgvCart == null) return;
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;

            decimal total = _cart.Sum(x => x.TotalPrice);
            if (lblTotalAmount != null) lblTotalAmount.Text = $"{total:N0} đ";
            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = _cart.Sum(x => x.TotalPrice);
            if (decimal.TryParse(txtCashReceived?.Text ?? "0", out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                if (lblChange != null)
                {
                    lblChange.Text = change >= 0 ? $"{change:N0} đ" : "Chưa đủ tiền!";
                    lblChange.ForeColor = change >= 0 ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                }
            }
            else
            {
                if (lblChange != null) lblChange.Text = "0 đ";
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orderRequest = new
            {
                CashierUsername = string.IsNullOrWhiteSpace(SessionManager.CurrentUsername) ? "cashier01" : SessionManager.CurrentUsername,
                CustomerId = (int?)null,
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            try
            {
                var response = await ApiClientService.Client.PostAsJsonAsync("checkout", orderRequest);
                if (response.IsSuccessStatusCode)
                {
                    string orderInfo = "Thanh toán thành công!";
                    try
                    {
                        var resJson = await response.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();
                        if (resJson.TryGetProperty("orderCode", out var oc))
                        {
                            orderInfo = $"Thanh toán hóa đơn [{oc.GetString()}] thành công và đã cập nhật tồn kho an toàn!";
                        }
                    }
                    catch { }

                    MessageBox.Show(orderInfo, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cart.Clear();
                    UpdateCartDisplay();
                    if (txtCashReceived != null) txtCashReceived.Clear();
                    if (txtCustomerPhone != null) txtCustomerPhone.Clear();
                    if (lblCustomerName != null) lblCustomerName.Text = "Khách vãng lai";
                }
                else
                {
                    string errorMsg = "Thanh toán thất bại từ máy chủ!";
                    try
                    {
                        var errorObj = await response.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();
                        if (errorObj.TryGetProperty("errorDetail", out var ed)) errorMsg = ed.GetString() ?? errorMsg;
                        else if (errorObj.TryGetProperty("message", out var m)) errorMsg = m.GetString() ?? errorMsg;
                    }
                    catch { }
                    MessageBox.Show(errorMsg, "Lỗi Giao Dịch POS (Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}

