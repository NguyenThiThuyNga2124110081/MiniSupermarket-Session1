using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms;

namespace MiniSupermarketWinForms
{
    public partial class FormProductManagement : Form
    {
        private List<ProductDto> _allProducts = new List<ProductDto>();

        public FormProductManagement()
        {
            InitializeComponent();

            this.Load += FormProductManagement_Load;
            this.Resize += (s, e) => AdjustSplitter();
            this.btnLoad.Click += async (s, e) =>
            {
                txtSearchBarcode.Clear();
                await LoadProductsAsync();
                ClearInputs();
            };
            this.btnAdd.Click += btnAdd_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnSearch.Click += btnSearch_Click;
            this.btnClearInputs.Click += (s, e) => ClearInputs();
            this.dgvProducts.CellClick += dgvProducts_CellClick;
            this.cboFilterCategory.SelectedIndexChanged += cboFilterCategory_SelectedIndexChanged;
        }

        private async void FormProductManagement_Load(object? sender, EventArgs e)
        {
            AdjustSplitter();
            SetupGridColumns();
            await LoadCategoriesToComboAsync();
            await LoadProductsAsync();
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
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.RowTemplate.Height = 32;
            dgvProducts.ColumnHeadersHeight = 36;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvProducts.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barcode",
                HeaderText = "Mã Vạch",
                Width = 135
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên Sản Phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Đơn Giá",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StockQuantity",
                HeaderText = "Tồn Kho",
                Width = 85,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoryName",
                HeaderText = "Nhóm Hàng",
                Width = 160
            });
        }

        private async Task LoadCategoriesToComboAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
                }

                var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories");
                if (categories != null)
                {
                    cboCategory.DataSource = new List<CategoryDto>(categories);
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";

                    var filterList = new List<CategoryDto>
                    {
                        new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả danh mục --" }
                    };
                    filterList.AddRange(categories);
                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
                }

                var products = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>("products");
                _allProducts = products ?? new List<ProductDto>();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _allProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp sản phẩm từ CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilterCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboFilterCategory.SelectedValue is int catId)
            {
                if (catId == 0)
                {
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = _allProducts;
                }
                else
                {
                    var filtered = _allProducts.Where(p => p.CategoryId == catId).ToList();
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = filtered;
                }
            }
        }

        private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].DataBoundItem is ProductDto prod)
            {
                txtId.Text = prod.ProductId.ToString();
                txtBarcode.Text = prod.Barcode;
                txtProductName.Text = prod.ProductName;

                if (prod.Price > nudPrice.Maximum) nudPrice.Maximum = prod.Price;
                nudPrice.Value = prod.Price;

                if (prod.StockQuantity > nudStock.Maximum) nudStock.Maximum = prod.StockQuantity;
                nudStock.Value = prod.StockQuantity;

                if (prod.CategoryId > 0)
                {
                    cboCategory.SelectedValue = prod.CategoryId;
                }
            }
        }

        // ================= XỬ LÝ THÊM MỚI SẢN PHẨM =================
        private async void btnAdd_Click(object? sender, EventArgs e)
        {
            string barcode = txtBarcode.Text.Trim();
            string name = txtProductName.Text.Trim();

            if (string.IsNullOrEmpty(barcode))
            {
                MessageBox.Show("Vui lòng nhập mã vạch sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            int catId = cboCategory.SelectedValue is int cId ? cId : 1;

            var newProd = new
            {
                Barcode = barcode,
                ProductName = name,
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = catId
            };

            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("products", newProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công và đã lưu vào CSDL SQL Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    var err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show("Thêm mới thất bại: " + err, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= XỬ LÝ CẬP NHẬT (SỬA) SẢN PHẨM =================
        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string barcode = txtBarcode.Text.Trim();
            string name = txtProductName.Text.Trim();

            if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Mã vạch và tên sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int catId = cboCategory.SelectedValue is int cId ? cId : 1;

            var updateProd = new
            {
                ProductId = id,
                Barcode = barcode,
                ProductName = name,
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = catId
            };

            try
            {
                var res = await ApiClientService.Client.PutAsJsonAsync($"products/{id}", updateProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật sản phẩm vào CSDL SQL Server thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                }
                else
                {
                    var err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show("Cập nhật thất bại: " + err, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= XỬ LÝ XÓA SẢN PHẨM =================
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtProductName.Text.Trim();
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{name}' (ID = {id}) khỏi CSDL SQL Server không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var res = await ApiClientService.Client.DeleteAsync($"products/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công khỏi CSDL SQL Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductsAsync();
                        ClearInputs();
                    }
                    else
                    {
                        var err = await res.Content.ReadAsStringAsync();
                        MessageBox.Show("Xóa thất bại: " + err, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ================= TÌM KIẾM SẢN PHẨM =================
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            string keyword = txtSearchBarcode.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadProductsAsync();
                return;
            }

            try
            {
                var result = await ApiClientService.Client.GetFromJsonAsync<List<ProductDto>>($"products/search?keyword={Uri.EscapeDataString(keyword)}");
                _allProducts = result ?? new List<ProductDto>();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _allProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            nudPrice.Value = 0;
            nudStock.Value = 0;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
        }
    }
}