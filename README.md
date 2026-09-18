🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)



Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)



Buổi thực hành: Buổi 1 - Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)



🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)



Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:



MiniSupermarket.API (Backend): Dự án ASP.NET Core Web API chịu trách nhiệm xử lý logic nghiệp vụ, quản lý dữ liệu và cung cấp các RESTful API.



MiniSupermarketWinForms (Frontend Client): Ứng dụng Windows Forms đóng vai trò là máy trạm, sử dụng HttpClient để gọi dữ liệu từ API và hiển thị lên DataGridView.



🛠️ 2. Công nghệ Sử dụng



Ngôn ngữ: C# (.NET 8.0)



Backend: ASP.NET Core Web API, Controllers, In-Memory Data, LINQ



Frontend: Windows Forms (.NET 8.0), System.Net.Http.Json



Công cụ kiểm thử: Swagger UI



📂 3. Cấu trúc Solution



MiniSupermarket.API/

│

├── MiniSupermarket.API/

│   ├── Controllers/

│   ├── Models/

│   └── Program.cs

│

├── MiniSupermarketWinForms/

│   └── FormCategoryManagement/

│

├── FormCategoryManagement/

├── packages/

├── MiniSupermarket.API.sln

└── README.md


## 4. Thông tin Tác giả
* **Họ tên sinh viên:** Nguyễn Thị Thúy Nga
* **Mã sinh viên:** 2124110081
* **Lớp học phần:** CCQ2411C
