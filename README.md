BUỔI 2: BẢO MẬT & PHÂN QUYỀN JWT CHO WEB API

Dự án mở rộng hệ thống **MiniSupermarket** với kiến trúc phân tầng Client - Server: tích hợp cơ chế xác thực không trạng thái (**Stateless Authentication**) bằng **JWT (JSON Web Token)**, bảo vệ các RESTful Web API và xây dựng luồng đăng nhập, phân quyền người dùng trên ứng dụng WinForms Client.

---
Thông tin sinh viên
* **Họ và tên:** Nguyễn Thị Thúy Nga
* **MSSV:** 2124110081
* **Lớp:** CCQ2411C

🎯 Mục Tiêu Đạt Được

- **Kiến trúc Stateless:** Sử dụng JWT để định danh người dùng qua các Claim (Username, Role) mà không tốn tài nguyên lưu Session trên RAM máy chủ.
- **Bảo mật Backend:** Thiết lập Middleware xác thực JWT Bearer, phân quyền truy cập endpoint bằng thuộc tính `[Authorize]` và `[Authorize(Roles = "...")]`.
- **Tích hợp Client:** Xây dựng màn hình đăng nhập `FormLogin`, lưu trữ phiên làm việc qua `SessionManager` và cấu hình `HttpClient` đính kèm Header `Authorization: Bearer <token>` khi gửi request.

---

🛠 Yêu Cầu & Thư Viện Sử Dụng

- **Môi trường:** .NET 8.0 SDK (hoặc .NET 10.0), Visual Studio 2022 trở lên.
- **Gói NuGet Backend (`MiniSupermarket.API`):**
  - `System.IdentityModel.Tokens.Jwt`
  - `Microsoft.AspNetCore.Authentication.JwtBearer`

---

👥 Danh Sách Tài Khoản Thử Nghiệm

Hệ thống mẫu cấp sẵn 2 tài khoản phân cấp vai trò:

| Tài khoản (Username) | Mật khẩu (Password) | Phân quyền (Role) | Phạm vi truy cập kiểm tra |
| :--- | :--- | :--- | :--- |
| `admin` | `123456` | **Admin** | Toàn quyền hệ thống, danh mục, màn POS và `admin-dashboard` |
| `cashier` | `123456` | **Cashier** | Xem danh mục, thao tác màn POS (`staff-pos`). Bị chặn (`403 Forbidden`) tại `admin-dashboard` |

---

🚀 Hướng Dẫn Cài Đặt & Chạy Ứng Dụng

Bước 1: Khởi động Backend (MiniSupermarket.API)

1. Mở Solution bằng Visual Studio.
2. Kiểm tra tệp cấu hình `appsettings.json` tại project `MiniSupermarket.API`, đảm bảo chuỗi Secret Key đã được khai báo:
   ```json
   "JwtSettings": {
     "Secret": "SupermarketSecretKeyDoAnMonHoc2026SecureString!!"
   }
Chuột phải vào MiniSupermarket.API > chọn Set as Startup Project.

Nhấn F5 hoặc Ctrl + F5 để khởi chạy.

Trình duyệt tự động mở giao diện Swagger UI tại địa chỉ: https://localhost:7123/swagger (Lưu ý kiểm tra đúng số cổng PORT máy bạn đang chạy).

Bước 2: Kiểm chứng bảo mật với Swagger UI
Thử nghiệm gọi API khi chưa đăng nhập (401 Unauthorized):

Chọn GET /api/categories > Bấm Try it out > Execute.

Phản hồi nhận được: Mã lỗi 401 Unauthorized.

Đăng nhập lấy Token:

Chọn POST /api/auth/login > Bấm Try it out.

Điền JSON đăng nhập (ví dụ tài khoản cashier):

JSON
{
  "username": "cashier",
  "password": "123456"
}
Nhấn Execute, copy toàn bộ chuỗi ký tự trong trường "token" ở khung kết quả.

Gắn Token vào Swagger:

Kéo lên đầu trang, bấm vào nút Authorize (biểu tượng ổ khóa màu xanh lá).

Nhập chuỗi theo cú pháp:

Plaintext
Bearer <chuỗi_token_vừa_copy>
Bấm Authorize > Close.

Kiểm tra phân quyền Role (403 Forbidden vs 200 OK):

Gọi GET /api/categories/staff-pos ➔ Trả về 200 OK (Cả Admin và Cashier đều có quyền).

Gọi GET /api/categories/admin-dashboard với token Cashier ➔ Trả về 403 Forbidden (Bị từ chối vì thiếu quyền Admin).

Bước 3: Cấu hình và chạy WinForms Client
Mở file FormLogin.cs và ApiClientService.cs (hoặc nơi cấu hình HttpClient), đối chiếu cổng BaseAddress khớp với cổng Backend API đang chạy:

C#
BaseAddress = new Uri("https://localhost:7099/api/")
Thiết lập cho phép chạy song song cả 2 project hoặc khởi chạy độc lập:

Cách 1: Chạy API trước bằng Ctrl + F5, sau đó chuột phải vào MiniSupermarket.WinForms > chọn Debug > Start New Instance.

Cách 2: Chuột phải vào Solution > Configure Startup Projects... > chọn Multiple startup projects > Chọn Action Start cho cả hai project MiniSupermarket.API và MiniSupermarket.WinForms.

Khi giao diện WinForms khởi chạy:

Màn hình FormLogin hiển thị đầu tiên.

Nhập tài khoản/mật khẩu tương ứng để đăng nhập.

Ứng dụng tự động lưu trữ Token vào SessionManager, giải phóng form đăng nhập và điều hướng sang form nghiệp vụ chính FormCategoryManagement.

📂 Cấu Trúc Các Thành Phần Mới (Buổi 2)
Plaintext
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   ├── AuthController.cs          # Endpoint xử lý đăng nhập & phát sinh JWT
│   │   └── CategoriesController.cs    # Thêm [Authorize] & endpoint phân quyền theo Role
│   └── Program.cs                     # Đăng ký dịch vụ xác thực JwtBearer Middleware
│
└── MiniSupermarket.WinForms/
    ├── FormLogin.cs                   # Giao diện đăng nhập Client
    ├── Program.cs                     # Cấu hình mở FormLogin đầu tiên
    └── SessionManager.cs              # Quản lý lưu trữ JwtToken và Role phiên hiện tại

