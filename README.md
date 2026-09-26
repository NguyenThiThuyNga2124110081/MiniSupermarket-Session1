 BUỔI 3: KẾT NỐI CƠ SỞ DỮ LIỆU LOCALDB, EF CORE MIGRATION & KIỂM THỬ BỀN VỮNG DỮ LIỆU

1. MỤC TIÊU BÀI THỰC HÀNH
- Chuyển đổi Cơ sở dữ liệu từ bộ nhớ tạm sang **SQL Server LocalDB**.
- Thực thi Entity Framework Core Migration để khởi tạo cấu trúc CSDL và nạp dữ liệu mẫu (Seeding Data).
- Xây dựng Backend API (`CategoriesController`) tương tác trực tiếp với SQL Server LocalDB.
- Kiểm thử tính lưu trữ bền vững (Data Persistence) trên giao diện Client WinForms (`MiniSupermarketWinForms`).

---

2. KẾT QUẢ ĐẠT ĐƯỢC

2.1. Cấu hình Chuỗi Kết Nối (Connection String)
Cập nhật file `appsettings.json` kết nối tới SQL Server LocalDB:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
2.2. Entity Framework Core Migration
Thực thi lệnh Add-Migration tạo mã khởi tạo các bảng dbo.Categories và dbo.Products.

Chạy lệnh Update-Database cập nhật cấu trúc bảng và 5 dòng dữ liệu danh mục mặc định xuống đĩa cứng LocalDB.

2.3. Kiểm thử API trên Swagger UI
Thực thi các thao tác CRUD bất đồng bộ (async/await) kết nối tới CSDL.

Gọi API POST /api/Categories tạo mới danh mục thành công (Mã HTTP 201 Created, tự động cấp CategoryId = 6).

2.4. Kiểm thử Bền vững Dữ liệu trên WinForms Client
Thiết lập Visual Studio khởi chạy đồng thời cả Backend API và WinForms Client (Multiple Startup Projects).

Thực hiện Thêm / Sửa / Xóa danh mục từ màn hình FormCategoryManagement.

Đối soát CSDL: Sử dụng SQL Server Object Explorer để kiểm tra dữ liệu trong bảng dbo.Categories [Data]. Dữ liệu được lưu trữ nguyên vẹn trên đĩa cứng ngay cả khi tắt và khởi chạy lại toàn bộ ứng dụng.


3. TÊN TÁC GIẢ
Họ và tên: Nguyễn Thị Thúy Nga
MSSV: 2124110081
Lớp: CCQ2411C
