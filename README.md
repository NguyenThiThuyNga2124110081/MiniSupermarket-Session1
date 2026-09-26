\# BUỔI 2: BẢO MẬT \& PHÂN QUYỀN JWT CHO WEB API



\## Thông tin sinh viên

\- \*\*Họ và tên:\*\* Nguyễn Thị Thúy Nga

\- \*\*MSSV:\*\* 2124110081

\- \*\*Lớp:\*\* CCQ2411C



\---



\## 1. Mục tiêu

Buổi 2 nâng cấp dự án MiniSupermarket từ chức năng CRUD của Buổi 1 lên hệ thống có \*\*đăng nhập, xác thực và phân quyền bằng JWT\*\*.



\---



\## 2. Nội dung đã bổ sung



\### Backend - MiniSupermarket.API

\- Cài đặt package hỗ trợ JWT Authentication.

\- Tạo `AuthController` để xử lý đăng nhập và cấp JWT Token.

\- Cấu hình JWT Authentication trong `Program.cs`.

\- Sử dụng `\[Authorize]` để bảo vệ API.

\- Sử dụng `\[Authorize(Roles = "...")]` để phân quyền Admin và Cashier.

\- Kiểm tra API khi chưa đăng nhập và khi đăng nhập bằng các quyền khác nhau.



\### WinForms - MiniSupermarketWinForms

\- Tạo `FormLogin` để đăng nhập.

\- Tạo `SessionManager` để lưu JWT Token và Role của người dùng.

\- Cập nhật `ApiClientService` để gửi Bearer Token khi gọi API.

\- Cập nhật `FormCategoryManagement` để gọi API có xác thực.

\- Thay đổi màn hình khởi chạy thành `FormLogin`.



\---



\## 3. Tài khoản kiểm thử



| Tài khoản | Mật khẩu | Quyền |

| :--- | :--- | :--- |

| `admin` | `123` | Admin |

| `cashier` | `123` | Cashier |



\---



\## 4. Kết quả

Sau Buổi 2, hệ thống có thêm:

\- Đăng nhập bằng tài khoản.

\- Cấp và lưu JWT Token.

\- Xác thực người dùng bằng Bearer Token.

\- Phân quyền Admin và Cashier.

\- Bảo vệ các API bằng `\[Authorize]`.

\- WinForms có màn hình đăng nhập và gửi Token khi gọi API.



\---



\## 5. So với Buổi 1

\*\*Buổi 1:\*\* Tập trung xây dựng chức năng CRUD Nhóm hàng.



\*\*Buổi 2:\*\* Bổ sung bảo mật cho hệ thống gồm:

\- Đăng nhập.

\- JWT Authentication.

\- Authorization.

\- Phân quyền Admin/Cashier.



\---



\## 6. Công nghệ sử dụng

\- C#

\- .NET 8.0

\- ASP.NET Core Web API

\- Windows Forms

\- JWT Authentication

\- Visual Studio 2022

\- Git/GitHub

\- Swagger



\---



\## 7. API kiểm tra



Swagger:

```text

https://localhost:7099/swagger/index.html



\## 8. GitHub

Repository:



https://github.com/NguyenThiThuyNga2124110081/MiniSupermarket-Session1

