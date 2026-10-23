🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

📚 Thông tin bài thực hành

Môn học: Lập trình ứng dụng với .NET

Mã môn học: 229162

Buổi thực hành: Buổi 1 – CRUD Nhóm hàng MiniSupermarket

Đề tài: Xây dựng hệ thống quản lý siêu thị mini

📝 Giới thiệu

MiniSupermarket System là hệ thống quản lý siêu thị mini được xây dựng bằng ngôn ngữ C# và nền tảng .NET.

Hệ thống hỗ trợ quản lý các nhóm hàng trong siêu thị, bao gồm:

Hiển thị danh sách nhóm hàng.

Thêm nhóm hàng mới.

Cập nhật thông tin nhóm hàng.

Xóa nhóm hàng.

Tìm kiếm nhóm hàng.

Kết nối giữa ứng dụng Windows Forms và Web API.

Dự án gồm hai phần chính: Backend Web API và Frontend Windows Forms.

🏗️ Kiến trúc hệ thống

Backend – MiniSupermarket.API
Backend được xây dựng bằng ASP.NET Core Web API, có nhiệm vụ:

Tiếp nhận yêu cầu từ ứng dụng giao diện.

Xử lý các chức năng CRUD nhóm hàng.

Cung cấp API lấy, thêm, sửa, xóa và tìm kiếm dữ liệu.

Quản lý và xử lý dữ liệu của hệ thống.

Frontend – MiniSupermarketWinForms
Frontend được xây dựng bằng Windows Forms, có nhiệm vụ:

Hiển thị giao diện quản lý nhóm hàng.

Gửi yêu cầu đến Backend Web API.

Hiển thị danh sách nhóm hàng.

Cho phép thêm, sửa, xóa và tìm kiếm nhóm hàng.

🛠️ Công nghệ sử dụng

Ngôn ngữ lập trình: C#

Nền tảng: .NET 8.0

Backend: ASP.NET Core Web API

Frontend: Windows Forms

Công cụ phát triển: Visual Studio

Kiểm tra API: Swagger

Quản lý mã nguồn: Git và GitHub

📂 Cấu trúc Solution

```text
MiniSupermarket.API/
├── MiniSupermarket.API/
│   ├── Controllers/
│   ├── Models/
│   └── Program.cs
├── MiniSupermarketWinForms/
│   ├── Properties/
│   ├── References/
│   ├── App.config
│   ├── FormCategoryManagement.cs
│   ├── FormCategoryManagement.Designer.cs
│   ├── FormCategoryManagement.resx
│   ├── packages.config
│   └── Program.cs
├── FormCategoryManagement/
├── packages/
├── MiniSupermarket.API.sln
└── README.md
```

Lưu ý: Cấu trúc trên được trình bày theo các thành phần chính của solution. Tên hoặc vị trí một số thư mục có thể khác tùy theo cấu hình project trong Visual Studio.

⚙️ Chức năng chính

Chức năng

Mô tả

Create

Thêm nhóm hàng mới

Read

Hiển thị danh sách nhóm hàng

Update

Cập nhật thông tin nhóm hàng

Delete

Xóa nhóm hàng

Search

Tìm kiếm nhóm hàng

▶️ Hướng dẫn chạy chương trình

Bước 1: Mở solution

Mở Visual Studio.

Chọn Open a project or solution.

Mở file MiniSupermarket.API.sln.

Bước 2: Chạy Backend

Trong Solution Explorer, chọn project MiniSupermarket.API.

Nhấn chuột phải và chọn Set as Startup Project.

Nhấn F5 hoặc Start.

Backend sẽ chạy tại cổng được cấu hình trong project.

Bước 3: Kiểm tra API bằng Swagger

Swagger UI của project:

Swagger UI

Có thể kiểm tra các API:

Lấy danh sách nhóm hàng.

Lấy thông tin một nhóm hàng.

Thêm nhóm hàng.

Cập nhật nhóm hàng.

Xóa nhóm hàng.

Tìm kiếm nhóm hàng.

Bước 4: Chạy Windows Forms

Chọn project MiniSupermarketWinForms.

Nhấn chuột phải và chọn Set as Startup Project.

Nhấn F5 để chạy giao diện.

Kiểm tra địa chỉ API trong phần cấu hình của ứng dụng.

Đảm bảo địa chỉ và cổng Backend trùng với địa chỉ API đang chạy.

Chạy đồng thời Backend và Windows Forms

Nhấn chuột phải vào Solution.

Chọn Set Startup Projects.

Chọn Multiple startup projects.

Đặt MiniSupermarket.API và MiniSupermarketWinForms ở chế độ Start.

Nhấn Apply và OK.

Nhấn F5.

🧪 Kiểm thử chức năng

Thêm nhóm hàng

Mở màn hình quản lý nhóm hàng.

Nhập thông tin nhóm hàng.

Nhấn nút Thêm.

Kiểm tra nhóm hàng mới trong danh sách.

Sửa nhóm hàng

Chọn nhóm hàng cần sửa.

Thay đổi thông tin.

Nhấn Sửa hoặc Cập nhật.

Kiểm tra dữ liệu sau khi cập nhật.

Xóa nhóm hàng

Chọn nhóm hàng cần xóa.

Nhấn Xóa.

Xác nhận thao tác nếu có thông báo.

Kiểm tra nhóm hàng đã được xóa.

Tìm kiếm nhóm hàng

Nhập từ khóa tìm kiếm.

Nhấn Tìm kiếm.

Kiểm tra danh sách kết quả.

📌 Kết quả đạt được

Tạo được solution MiniSupermarket bằng C# .NET.

Xây dựng được Backend ASP.NET Core Web API.

Xây dựng được giao diện Windows Forms.

Thực hiện được CRUD nhóm hàng.

Kiểm tra API bằng Swagger.

Kết nối Frontend với Backend.

Sử dụng Git để quản lý mã nguồn.

Đưa source code lên GitHub.

📦 Các lệnh Git đã sử dụng

git init git add . git commit -m "Hoàn thành bài thực hành Buổi 1: CRUD Nhóm hàng MiniSupermarket" git branch -M main git remote add origin https://github.com/NguyenThiThuyNga2124110081/MiniSupermarket-Session1.git git push -u origin main

Cập nhật README lên GitHub:

git add README.md git commit -m "Thêm README.md" git push

 GitHub

Repository:



https://github.com/NguyenThiThuyNga2124110081/MiniSupermarket-Session1


 TÊN TÁC GIẢ
* **Họ và tên:** Nguyễn Thị Thúy Nga
* **MSSV:** 2124110081
* **Lớp:** CCQ2411C
