# 🛒 HỆ THỐNG QUẢN LÝ BÁN LẺ & TỒN KHO SIÊU THỊ MINI (MINISUPERMARKET)

> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)

 **Thông tin sinh viên:** 
> **Họ tên:** Nguyễn Thị Thúy Nga  
> **MSSV:** 2124110081  
> **Lớp:** CCQ2411C


> **Kiến trúc:** Client - Server (RESTful Web API + Windows Forms Client)

---

## 📌 1. TỔNG QUAN NỘI DUNG THỰC HIỆN ĐƯỢC TRONG ĐỒ ÁN

Đồ án xây dựng trọn vẹn giải pháp quản trị bán hàng và tồn kho cho chuỗi siêu thị/tiệm tạp hóa hiện đại, hoàn thành từ tầng Cơ sở dữ liệu, dịch vụ Web API đến ứng dụng WinForms Client:

### 1.1. Tầng Cơ Sở Dữ Liệu & Entity Framework Core (Backend)
- **Hệ quản trị CSDL:** Chuyển đổi thành công từ cơ chế tạm thời (In-Memory) sang **SQL Server LocalDB** (`Server=(localdb)\mssqllocaldb`).
- **EF Core Code-First:** Định nghĩa thực thể bằng C#, quản lý cấu trúc quan hệ 1-N giữa Danh mục (`Categories`) và Sản phẩm (`Products`).
- **EF Migrations:** Sử dụng `Add-Migration` và `Update-Database` đồng bộ hóa cấu trúc bảng xuống đĩa cứng, dữ liệu lưu trữ bền vững (Data Persistence) kể cả khi tắt hệ thống.
- **Data Seeding:** Tự động nạp sẵn dữ liệu chuẩn hóa: 5 nhóm hàng, 15 sản phẩm ăn vặt/đồ uống hot trend và 15 khách hàng thành viên có điểm thưởng và hạng thẻ.

### 1.2. Tầng Bảo Mật & Web API RESTful
- **Stateless Authentication:** Tích hợp JSON Web Token (**JWT Bearer Token**), không lưu session trên RAM máy chủ, mã hóa claims định danh: `Username`, `Role`.
- **Phân quyền truy cập (RBAC):** Bảo vệ các Endpoint bằng `[Authorize]` và `[Authorize(Roles = "...")]`.
- **Hệ thống API Controller:**
  - `AuthController`: Cấp phát token khi đăng nhập thành công.
  - `CategoriesController`: Toàn bộ thao tác CRUD và tìm kiếm danh mục bằng LINQ + `async/await`.
  - `ProductsController`: Tra cứu mã vạch (`/barcode/{barcode}`), lọc theo nhóm hàng, quản lý đơn giá và số lượng tồn kho.
  - `CustomersController`: Quản lý thông tin hội viên, tra cứu theo SĐT, tích lũy điểm thưởng.
  - `OrdersController`: Tiếp nhận thanh toán giỏ hàng và xử lý trừ kho.

### 1.3. Tầng Giao Diện Client (Windows Forms)
- **Kiến trúc Đơn Khung (Single-Form Shell):** Xây dựng `FormMainShell` hiện đại gồm Left Sidebar (`panelSidebar`), Top Header (`panelTopHeader`) và Vùng làm việc trung tâm (`panelMainContent`).
- **Kỹ thuật Dynamic Child Forms:** Nhúng động các Form con (`TopLevel = false`, `Dock = Fill`, `FormBorderStyle = None`) mượt mà, không mở cửa sổ độc lập rườm rà.
- **Phân quyền giao diện theo vai trò (RBAC):** Tự động ẩn/hiện menu và điều hướng màn hình mặc định theo 3 vai trò:
  - 🛡 **Admin:** Toàn quyền hệ thống, xem báo cáo doanh thu (`FormQuickReport`), quản trị tài khoản (`FormUserManagement`).
  - 🛒 **Cashier (Thu ngân):** Chỉ hiển thị Màn hình quầy bán lẻ (`FormPOS`) và Quản lý khách hàng (`FormCustomerManagement`).
  - 📦 **Warehouse (Thủ kho):** Chỉ hiển thị Quản lý nhóm hàng (`FormCategoryManagement`) và Sản phẩm tồn kho (`FormProductManagement`).
- **Quầy POS Bán hàng:** Hỗ trợ quét mã vạch qua ô tìm kiếm (bắt sự kiện `KeyDown: Enter`), tính toán giỏ hàng, tổng tiền, tiền khách đưa và tiền thừa thối lại theo thời gian thực.

---

## 👥 2. DANH SÁCH TÀI KHOẢN MẪU KIỂM THỬ (15 TÀI KHOẢN)

Hệ thống cung cấp sẵn danh sách tài khoản phân quyền để kiểm tra:

| STT | Tên tài khoản | Mật khẩu | Họ và tên nhân viên | Vai trò (Role) | Màn hình mở mặc định |
| :-: | :--- | :---: | :--- | :---: | :--- |
| 1 | `admin01` | `123456` | Nguyễn Quản Trị | **Admin** | `FormCategoryManagement` |
| 2 | `admin02` | `123456` | Trần Giám Đốc | **Admin** | `FormCategoryManagement` |
| 3 | `cashier01` | `123456` | Lê Thu Ngân | **Cashier** | `FormPOS` |
| 4 | `cashier02` | `123456` | Phạm Bán Hàng | **Cashier** | `FormPOS` |
| 5 | `cashier03` | `123456` | Hoàng Thu Ngân | **Cashier** | `FormPOS` |
| 6 | `cashier04` | `123456` | Vũ Thị Quầy | **Cashier** | `FormPOS` |
| 7 | `cashier05` | `123456` | Đỗ Bán Lẻ | **Cashier** | `FormPOS` |
| 8 | `ware01` | `123456` | Ngô Quản Kho | **Warehouse** | `FormProductManagement` |
| 9 | `ware02` | `123456` | Bùi Kiểm Kê | **Warehouse** | `FormProductManagement` |
| 10 | `ware03` | `123456` | Dương Thủ Kho | **Warehouse** | `FormProductManagement` |
| 11 | `ware04` | `123456` | Lý Nhập Hàng | **Warehouse** | `FormProductManagement` |
| 12 | `admin_backup` | `123456` | Đặng Hỗ Trợ | **Admin** | `FormCategoryManagement` |
| 13 | `cashier06` | `123456` | Hồ Ca Chiều | **Cashier** | `FormPOS` |
| 14 | `ware05` | `123456` | Trương Vận Chuyển | **Warehouse** | `FormProductManagement` |
| 15 | `supervisor` | `123456` | Mai Giám Sát | **Admin** | `FormCategoryManagement` |

---

## 🚀 3. HƯỚNG DẪN CÀI ĐẶT & CHẠY ỨNG DỤNG CHI TIẾT

### 3.1. Yêu Cầu Môi Trường
- Visual Studio 2022 (phiên bản 17.8 trở lên) có cài gói **.NET desktop development** và **ASP.NET and web development**.
- **.NET 8.0 SDK** (hoặc .NET 10.0).
- **SQL Server LocalDB** (tích hợp sẵn theo Visual Studio) hoặc Microsoft SQL Server Express.

---

### 3.2. Cấu Hình Cơ Sở Dữ Liệu (Migrations)
1. Mở file `MiniSupermarket.sln` bằng Visual Studio 2022.
2. Kiểm tra chuỗi kết nối trong file `MiniSupermarket.API/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
Mở cửa sổ Package Manager Console (Tools > NuGet Package Manager > Package Manager Console).

Tại mục Default project, chọn: MiniSupermarket.API.

Thực thi các lệnh sau để tự động tạo cơ sở dữ liệu và nạp dữ liệu mồi:

PowerShell
Update-Database
(Trường hợp clone về máy mới hoàn toàn chưa có mã Migration, chạy: Add-Migration InitialCreateDatabase rồi mới gõ Update-Database).

3.3. Hướng Dẫn Chạy Backend (MiniSupermarket.API)
Trong cửa sổ Solution Explorer, nhấp chuột phải vào dự án MiniSupermarket.API > Chọn Set as Startup Project.

Nhấn phím Ctrl + F5 (hoặc F5) để chạy Backend.

Trình duyệt sẽ tự động mở giao diện Swagger UI tại đường dẫn:https://localhost:7123/swagger/index.html (hoặc cổng PORT tương ứng trên máy của bạn).

Bạn có thể kiểm thử trực tiếp các endpoint GET /api/Categories, GET /api/Products ngay trên Swagger.

3.4. Hướng Dẫn Chạy Frontend (MiniSupermarket.WinForms)
Đảm bảo cổng Port trong file ApiClientService.cs (hoặc cấu hình HttpClient của WinForms) đã trùng khớp với Port của Backend đang chạy:

C#
BaseAddress = new Uri("https://localhost:7123/api/")
Chuột phải vào project MiniSupermarket.WinForms > Chọn Debug > Start New Instance (hoặc chọn Set as Startup Project rồi bấm F5).

Màn hình đăng nhập (FormLogin) sẽ xuất hiện:

Nhập thông tin tài khoản mẫu ở Mục 2 (Ví dụ: admin01 / 123456 hoặc cashier01 / 123456).

Bấm Đăng nhập hệ thống.

Hệ thống sẽ cấp token, lưu vào SessionManager, mở màn hình FormMainShell và tự động điều phối các chức năng tương ứng theo đúng vai trò.

3.5. Thiết Lập Chạy Đồng Thời Cả Backend & WinForms (Khuyên Dùng)
Để mỗi lần nhấn nút Start trên Visual Studio cả Web API và WinForms đều tự động chạy song song:

Nhấp chuột phải vào Solution 'MiniSupermarket' > Chọn Properties.

Chọn mục Common Properties > Startup Project.

Chọn tùy chọn Multiple startup projects:

MiniSupermarket.API: Chọn Action là Start.

MiniSupermarket.WinForms: Chọn Action là Start.

Nhấn Apply > OK. Giờ đây bạn chỉ cần nhấn F5 một lần duy nhất.

📂 4. CẤU TRÚC THƯ MỤC DỰ ÁN
Plaintext
MiniSupermarket/
├── .gitignore                         # Tệp cấu hình loại trừ file rác (bin, obj, node_modules)
├── README.md                          # Tài liệu hướng dẫn đồ án
├── MiniSupermarket.sln                # File Solution quản lý dự án
│
├── MiniSupermarket.API/               # BACKEND: RESTful Web API (.NET Core)
│   ├── Controllers/
│   │   ├── AuthController.cs          # Xác thực & Cấp phát JWT Token
│   │   ├── CategoriesController.cs    # Quản lý danh mục nhóm hàng
│   │   ├── CustomersController.cs     # Quản lý khách hàng thành viên & điểm thưởng
│   │   └── ProductsController.cs      # Quản lý sản phẩm, tồn kho & tra mã vạch
│   ├── Data/
│   │   └── SupermarketDbContext.cs    # DbContext, nạp dữ liệu mẫu (Seeding Data)
│   ├── Models/                        # Các thực thể CSDL (Category, Product, Customer)
│   ├── Migrations/                    # Lịch sử các phiên bản migration
│   ├── appsettings.json               # Cấu hình Connection String & JWT Secret Key
│   └── Program.cs                     # Đăng ký Middleware, DI Container & Authentication
│
└── MiniSupermarket.WinForms/          # FRONTEND: Ứng dụng Desktop Windows Forms
    ├── FormLogin.cs                   # Màn hình đăng nhập tài khoản
    ├── FormMainShell.cs               # Màn hình khung điều phối trung tâm (Sidebar + Dynamic Workspace)
    ├── FormPOS.cs                     # Nghiệp vụ bán hàng quầy thu ngân (Quét barcode, tính tiền)
    ├── FormCategoryManagement.cs      # Quản lý danh mục nhóm hàng
    ├── FormProductManagement.cs       # Quản lý danh mục sản phẩm, đơn giá & kho
    ├── FormCustomerManagement.cs      # Quản lý khách hàng thân thiết
    ├── FormQuickReport.cs             # Màn hình báo cáo doanh thu dành riêng cho Admin
    ├── FormUserManagement.cs          # Quản trị danh sách nhân sự & cấp quyền
    ├── SessionManager.cs              # Quản lý phiên làm việc, lưu trữ JwtToken và CurrentRole
    └── ApiClientService.cs            # Cấu hình HttpClient tập trung gọi sang Backend API
