/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Code-behind xử lý hiển thị danh sách phân trang LINQ, tìm kiếm, lọc nhóm hàng (Bài 6.2) và CRUD sản phẩm trực tiếp về SQL Server
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
    // Lớp nhận dữ liệu DTO từ API về Client
    public class ProductItemViewDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CategoryComboDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class PagedViewResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }

    public partial class FormProductManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 5;
        private int _totalPages = 1;

        public FormProductManagement()
        {
            InitializeComponent();

            this.Load += FormProductManagement_Load;
            this.Resize += (s, e) => AdjustSplitter();

            // Nút tìm kiếm và phân trang
            this.btnSearch.Click += btnSearch_Click;
            this.btnLoad.Click += btnLoad_Click;
            this.btnPrev.Click += btnPrev_Click;
            this.btnNext.Click += btnNext_Click;

            // Nút Thao tác Thêm / Sửa / Xóa
            this.btnAdd.Click += btnCreate_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnClearInputs.Click += (s, e) => ClearInputs();

            // Lưới và Bộ lọc nhóm hàng
            this.dgvProducts.CellClick += dgvProducts_CellClick;
            this.cboFilterCategory.SelectedIndexChanged += cboFilterCategory_SelectedIndexChanged;
        }

        private async void FormProductManagement_Load(object? sender, EventArgs e)
        {
            AdjustSplitter();
            SetupGridColumns();
            await LoadCategoriesComboAsync(); // Nạp nhóm hàng vào ComboBox
            await LoadProductsPagedAsync();   // Nạp bảng sản phẩm phân trang
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
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 248);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

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

        // 1. Tải danh sách nhóm hàng lên ComboBox (cả ô nhập chi tiết và ô lọc phân trang)
        private async Task LoadCategoriesComboAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryComboDto>>("categories");
                if (categories != null)
                {
                    // ComboBox cho chi tiết sản phẩm
                    cboCategory.DataSource = new List<CategoryComboDto>(categories);
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";

                    // ComboBox bộ lọc nhóm hàng (Bài tập 6.2)
                    var filterList = new List<CategoryComboDto>
                    {
                        new CategoryComboDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" }
                    };
                    filterList.AddRange(categories);
                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Gọi API phân trang và hiển thị dữ liệu lên DataGridView
        private async Task LoadProductsPagedAsync()
        {
            try
            {
                string search = txtSearchBarcode.Text.Trim();
                int? categoryId = null;
                if (cboFilterCategory.SelectedValue is int catId && catId > 0)
                {
                    categoryId = catId;
                }

                string url = $"products/paged?keyword={Uri.EscapeDataString(search)}&pageNumber={_currentPage}&pageSize={_pageSize}";
                if (categoryId.HasValue)
                {
                    url += $"&categoryId={categoryId.Value}";
                }

                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<ProductItemViewDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    // Hiển thị dữ liệu lên bảng
                    dgvProducts.DataSource = result.Items;

                    // Cập nhật nhãn phân trang
                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} SP)";

                    // Bật/tắt nút điều hướng
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Sự kiện chuyển trang
        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadProductsPagedAsync();
            }
        }

        // 4. Sự kiện tìm kiếm & lọc danh mục
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1; // Khi tìm kiếm từ khóa mới, luôn quay về trang 1
            await LoadProductsPagedAsync();
        }

        private async void cboFilterCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Chỉ kích hoạt lọc khi ComboBox đã bind xong DataSource
            if (cboFilterCategory.SelectedValue is int)
            {
                _currentPage = 1;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtSearchBarcode.Clear();
            if (cboFilterCategory.Items.Count > 0)
            {
                cboFilterCategory.SelectedIndex = 0;
            }
            _currentPage = 1;
            await LoadProductsPagedAsync();
            ClearInputs();
        }

        // 5. Thêm mới sản phẩm qua API
        private async void btnCreate_Click(object? sender, EventArgs e)
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
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var res = await ApiClientService.Client.PostAsJsonAsync("products", newProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsPagedAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Mã lỗi: " + res.StatusCode, "Cảnh báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Alias tương thích btnAdd_Click
        private void btnAdd_Click(object? sender, EventArgs e) => btnCreate_Click(sender, e);

        // 6. Cập nhật sản phẩm qua API
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
                if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                {
                    ApiClientService.AttachToken(SessionManager.JwtToken);
                }

                var res = await ApiClientService.Client.PutAsJsonAsync($"products/{id}", updateProd);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsPagedAsync();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Mã lỗi: " + res.StatusCode, "Lỗi từ Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7. Xóa sản phẩm qua API
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(txtId.Text) && int.TryParse(txtId.Text, out int parsedId))
            {
                id = parsedId;
            }
            else if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is ProductItemViewDto item)
            {
                id = item.ProductId;
            }

            if (id <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm #{id}?", 
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (!string.IsNullOrEmpty(SessionManager.JwtToken))
                    {
                        ApiClientService.AttachToken(SessionManager.JwtToken);
                    }

                    var res = await ApiClientService.Client.DeleteAsync($"products/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductsPagedAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Mã lỗi: " + res.StatusCode, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 8. Chọn dòng trên DataGridView để hiển thị chi tiết lên panel bên phải
        private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].DataBoundItem is ProductItemViewDto prod)
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