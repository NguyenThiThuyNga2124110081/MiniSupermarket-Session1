 🛒 HỆ THỐNG QUẢN LÝ BÁN LẺ & TỒN KHO SIÊU THỊ MINI (MINISUPERMARKET)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
Bài thực hành: BUỔI 6: ENTITY FRAMEWORK CORE NÂNG CAO, PHÂN TRANG LINQ & TÍCH HỢP TOÀN DIỆN HỆ THỐNG POS CLIENT - SERVER


---

👤 THÔNG TIN SINH VIÊN

Họ và tên: Nguyễn Thị Thúy Nga  
Mã số sinh viên: 2124110081  
Lớp: CCQ2411C  
Đề tài: Tiệm Trà chanh & Tạp hóa vặt Chill Store

---
BUỔI 6: ENTITY FRAMEWORK CORE NÂNG CAO, PHÂN TRANG LINQ & TÍCH HỢP TOÀN DIỆN HỆ THỐNG POS CLIENT - SERVER
 📌 BÁO CÁO KẾT QUẢ THỰC HÀNH BUỔI 6

🎯 Mục tiêu bài học

| # | Kỹ năng | Kết quả đạt được |
|---|---------|-----------------|
| 1 | **Eager Loading** | Dùng `.Include()` để load dữ liệu quan hệ Products ↔ Categories, tránh lỗi N+1 Query |
| 2 | **Server-side Pagination** | Dùng `.Skip()` + `.Take()` + `.AsNoTracking()` để phân trang tại tầng máy chủ |
| 3 | **Tìm kiếm gần đúng** | Dùng `.Contains()` tìm theo từ khóa trên nhiều trường dữ liệu |
| 4 | **Kết nối WinForms ↔ Web API** | Xây dựng `ApiClientService` dùng `HttpClient` + JWT Bearer Token |
| 5 | **Giao diện quản trị hiện đại** | Hoàn thiện các Form WinForms: phân trang, tìm kiếm, CRUD đầy đủ |

---

🏗️ Kiến trúc hệ thống

```
┌──────────────────────────────┐        HTTPS / JWT        ┌─────────────────────────────┐
│  MiniSupermarketWinForms     │ ◄────────────────────────► │  MiniSupermarket.API        │
│  (.NET 8 WinForms Client)    │    HttpClient + Bearer     │  (ASP.NET Core Web API)     │
│                              │                            │                             │
│  ┌─────────────────────────┐ │                            │  ┌─────────────────────────┐│
│  │ ApiClientService        │ │                            │  │ EF Core DbContext       ││
│  │ SessionManager (JWT)    │ │                            │  │ LINQ Pagination         ││
│  │ FormProductManagement   │ │                            │  │ Eager Loading (.Include)││
│  │ FormCustomerManagement  │ │                            │  └──────────┬──────────────┘│
│  │ FormCategoryManagement  │ │                            │             │               │
│  │ FormUserManagement      │ │                            │             ▼               │
│  └─────────────────────────┘ │                            │  ┌─────────────────────────┐│
└──────────────────────────────┘                            │  │ SQL Server LocalDB      ││
                                                            │  │ MiniSupermarketDb       ││
                                                            │  └─────────────────────────┘│
                                                            └─────────────────────────────┘
```

---

📂 Cấu trúc thư mục

```
MiniSupermarket.API/
├── MiniSupermarket.API/                   ← Web API Backend
│   ├── Controllers/
│   │   ├── AuthController.cs              ← Đăng nhập, phát hành JWT Token
│   │   ├── ProductsController.cs          ← GET /api/products/paged  [Bài 6.2]
│   │   ├── CustomersController.cs         ← GET /api/customers/paged [Bài 6.1]
│   │   ├── CategoriesController.cs        ← GET /api/categories/paged
│   │   ├── UsersController.cs             ← GET /api/users/paged + RBAC
│   │   └── CheckoutController.cs          ← Giao dịch POS Checkout
│   ├── Models/
│   │   ├── Product.cs / Category.cs / Customer.cs / User.cs
│   │   └── PagedResponseDto.cs            ← DTO phân trang dùng chung (Generic)
│   └── Data/
│       └── SupermarketDbContext.cs        ← EF Core DbContext
│
└── MiniSupermarketWinForms/               ← WinForms Desktop Client
    ├── Services/
    │   └── ApiClientService.cs            ← HttpClient dùng chung + JWT
    ├── SessionManager.cs                  ← Lưu trữ JWT Token phiên làm việc
    ├── FormLogin.cs                       ← Đăng nhập & xác thực JWT
    ├── FormMainShell.cs                   ← Shell chứa Form con + RBAC sidebar
    ├── FormProductManagement.cs           ← Quản lý Sản phẩm [Bài 6.2]
    ├── FormCustomerManagement.cs.cs       ← Quản lý Khách hàng [Bài 6.1]
    ├── FormCategoryManagement.cs          ← Quản lý Danh mục
    └── FormUserManagement.cs              ← Quản trị Tài khoản & Phân quyền
```

---

✅ Bài tập 6.1 — Phân trang Khách hàng (`CustomersController`)

File: `MiniSupermarket.API/Controllers/CustomersController.cs`

Endpoint

```
GET /api/customers/paged?keyword=nguyen&sortBy=id&pageNumber=1&pageSize=10
```
Code chính

```csharp
// Tìm kiếm gần đúng theo tên hoặc số điện thoại
var query = _context.Customers
    .AsNoTracking()
    .Where(c => c.CustomerName.ToLower().Contains(search)
             || c.PhoneNumber.Contains(search));

// Sắp xếp theo CustomerId tăng dần (mặc định)
query = query.OrderBy(c => c.CustomerId);

// Phân trang với Skip + Take
var items = await query
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

Response mẫu

```json
{
  "currentPage": 1,
  "pageSize": 10,
  "totalItems": 10,
  "totalPages": 1,
  "items": [
    { "customerId": 1, "customerName": "Nguyễn Văn An", "phoneNumber": "0901234001", "rewardPoints": 250, "membershipRank": "Bạc" },
    { "customerId": 2, "customerName": "Trần Thị Bích", "phoneNumber": "0901234002", "rewardPoints": 1500, "membershipRank": "Vàng" }
  ]
}
```

---
✅ Bài tập 6.2 — Phân trang Sản phẩm với Eager Loading (`ProductsController`)

**File:** `MiniSupermarket.API/Controllers/ProductsController.cs`

Endpoint

```
GET /api/products/paged?keyword=sua&categoryId=2&pageNumber=1&pageSize=5
```

Code chính

```csharp
// Eager Loading: Load dữ liệu liên kết Category cùng một lần (tránh N+1 Query)
var query = _context.Products
    .Include(p => p.Category)   // ← Eager Loading với .Include()
    .AsNoTracking()             // ← Tối ưu RAM cho truy vấn chỉ đọc
    .AsQueryable();

// Lọc theo nhóm hàng (categoryId)
if (categoryId.HasValue && categoryId.Value > 0)
    query = query.Where(p => p.CategoryId == categoryId.Value);

// Tìm kiếm theo tên sản phẩm hoặc mã barcode
if (!string.IsNullOrWhiteSpace(keyword))
    query = query.Where(p => p.ProductName.ToLower().Contains(search)
                          || p.Barcode.Contains(search));

// Phân trang
var items = await query
    .OrderBy(p => p.ProductId)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .Select(p => new { p.ProductId, p.ProductName, p.Price, CategoryName = p.Category.CategoryName })
    .ToListAsync();
```

 Response mẫu

```json
{
  "currentPage": 1,
  "pageSize": 5,
  "totalItems": 15,
  "totalPages": 3,
  "items": [
    { "productId": 1, "barcode": "8934561234001", "productName": "Sữa Vinamilk 1L", "price": 32000, "stockQuantity": 100, "categoryName": "Sữa & Sản phẩm từ sữa" }
  ]
}
```

---

 ✅ Tích hợp WinForms Client ↔ Web API

Lớp `ApiClientService` — HttpClient dùng chung + JWT tự động

**File:** `MiniSupermarketWinForms/Services/ApiClientService.cs`

```csharp
public static class ApiClientService
{
    // 1 phiên bản HttpClient dùng chung (Singleton pattern)
    public static readonly HttpClient Client = new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7099/api/")
    };

    // Gắn Bearer Token sau khi đăng nhập thành công
    public static void AttachToken(string token)
    {
        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }
}
```

 Gọi API phân trang bất đồng bộ (async/await)

```csharp
// FormProductManagement.cs — LoadProductsPagedAsync()
string url = $"products/paged?keyword={Uri.EscapeDataString(search)}" +
             $"&categoryId={categoryId}" +
             $"&pageNumber={_currentPage}&pageSize={_pageSize}";

var res = await ApiClientService.Client
    .GetFromJsonAsync<PagedViewResult<ProductItemViewDto>>(url);

if (res != null)
{
    _totalPages = res.TotalPages;
    lblPaging.Text = $"Trang {res.CurrentPage} / {res.TotalPages} (Tổng: {res.TotalItems} sản phẩm)";
    dgvProducts.DataSource = res.Items;
}
```

---

🖥️ Màn hình WinForms đã hoàn thiện

| Form | Chức năng | Phân trang | CRUD | JWT |
|------|-----------|:----------:|:----:|:---:|
| `FormLogin` | Đăng nhập, nhận JWT Token | — | — | ✅ |
| `FormMainShell` | Shell điều hướng, RBAC sidebar | — | — | ✅ |
| `FormProductManagement` | Quản lý Sản phẩm, lọc nhóm hàng | ✅ | ✅ | ✅ |
| `FormCustomerManagement` | Quản lý Khách hàng, tích điểm | ✅ | ✅ | ✅ |
| `FormCategoryManagement` | Quản lý Danh mục Nhóm hàng | ✅ | ✅ | ✅ |
| `FormUserManagement` | Quản trị Tài khoản & Phân quyền | ✅ | ✅ | ✅ |
| `FormPOS` | Quầy bán hàng & Tính tiền | — | — | ✅ |
| `FormQuickReport` | Báo cáo doanh thu ca bán | — | — | ✅ |

---

 🔐 Phân quyền theo Vai trò (RBAC)
| Vai trò | Màn hình có quyền truy cập |
|---------|---------------------------|
| **Admin** | Tất cả màn hình (Sản phẩm, Khách hàng, Danh mục, Báo cáo, Tài khoản) |
| **Cashier** | POS Bán hàng + Quản lý Khách hàng |
| **Warehouse** | Quản lý Danh mục + Quản lý Sản phẩm |

---

 🚀 Hướng dẫn chạy dự án

 Yêu cầu môi trường

- .NET 8 SDK
- SQL Server LocalDB (đi kèm Visual Studio 2022)

Bước 1 — Tạo cơ sở dữ liệu

```powershell
cd MiniSupermarket.API
dotnet ef database update
```

Bước 2 — Khởi động Web API Backend

```powershell
dotnet run --project MiniSupermarket.API
# API chạy tại: https://localhost:7099
```

Bước 3 — Khởi động WinForms Client

```powershell
dotnet run --project MiniSupermarketWinForms
```

Bước 4 — Tài khoản thử nghiệm

| Tài khoản | Mật khẩu | Vai trò |
|-----------|----------|---------|
| `admin` | `123456` | Admin |
| `cashier1` | `123456` | Cashier |
| `warehouse1` | `123456` | Warehouse |

---

📡 Danh sách API Endpoints (Buổi 6)

| Method | Endpoint | Mô tả | Bài tập |
|--------|----------|-------|---------|
| `GET` | `/api/customers/paged` | Phân trang khách hàng, tìm kiếm, sắp xếp | **6.1** |
| `GET` | `/api/products/paged` | Phân trang sản phẩm + Eager Loading + lọc nhóm | **6.2** |
| `GET` | `/api/categories/paged` | Phân trang danh mục nhóm hàng | Bổ sung |
| `GET` | `/api/users/paged` | Phân trang tài khoản người dùng | Bổ sung |
| `PUT` | `/api/users/{id}` | Cập nhật thông tin tài khoản | Bổ sung |
| `PUT` | `/api/users/{id}/toggle-lock` | Khóa / Mở khóa tài khoản | Bổ sung |
| `PUT` | `/api/users/{id}/reset-password` | Đặt lại mật khẩu | Bổ sung |

Query Parameters chung cho các endpoint phân trang

| Tham số | Kiểu | Mô tả | Mặc định |
|---------|------|-------|----------|
| `keyword` | string | Từ khóa tìm kiếm gần đúng | _(trống)_ |
| `pageNumber` | int | Số trang hiện tại | `1` |
| `pageSize` | int | Số dòng mỗi trang | `5` hoặc `10` |
| `categoryId` | int | Lọc theo nhóm hàng _(chỉ products)_ | _(tất cả)_ |
| `sortBy` | string | Sắp xếp: `id` hoặc `points` _(chỉ customers)_ | `id` |

---

📊 Cấu trúc DTO phân trang dùng chung

**File:** `MiniSupermarket.API/Models/PagedResponseDto.cs`

```csharp
// Generic class dùng cho mọi endpoint phân trang
public class PagedResult<T>
{
    public int CurrentPage { get; set; }   // Trang hiện tại
    public int PageSize    { get; set; }   // Số dòng mỗi trang
    public int TotalItems  { get; set; }   // Tổng số bản ghi
    public int TotalPages  { get; set; }   // Tổng số trang
    public List<T> Items   { get; set; } = new();  // Dữ liệu trang hiện tại
}
```

---

🔗 Chuỗi kết nối CSDL

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

---

📝 Ghi chú kỹ thuật

| Kỹ thuật | Lý do sử dụng |
|----------|--------------|
| `AsNoTracking()` | Bỏ qua Change Tracker của EF Core, giảm đáng kể RAM khi chỉ đọc dữ liệu hiển thị |
| `HttpClient` Singleton | Một instance dùng chung toàn ứng dụng WinForms, tránh lỗi socket exhaustion |
| `async/await` | Toàn bộ lệnh gọi API đều bất đồng bộ, giao diện không bị đơ khi tải dữ liệu |
| `Uri.EscapeDataString()` | Mã hóa ký tự đặc biệt trong từ khóa tìm kiếm trước khi đưa vào URL |
| JWT Bearer | Token lưu trong `SessionManager.JwtToken`, tự động gắn vào mọi request HTTP |
