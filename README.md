Markdown
BUỔI 3: KẾT NỐI CƠ SỞ DỮ LIỆU LOCALDB, EF CORE MIGRATION & KIỂM THỬ BỀN VỮNG DỮ LIỆU

## 1. Thông Tin Sinh Viên
* **Họ và tên:** Nguyễn Thị Thúy Nga
* **MSSV:** 2124110081
* **Lớp:** CCQ2411C
* **Tên môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)

---

## 2. Mục Tiêu Bài Thực Hành
* Chuyển đổi Cơ sở dữ liệu từ bộ nhớ tạm (InMemory Database) sang **SQL Server LocalDB**.
* Thực thi Entity Framework Core Migration để khởi tạo cấu trúc CSDL và nạp dữ liệu mẫu (Seeding Data) cho các bảng `Categories`, `Products` và `Customers`.
* Xây dựng Backend RESTful API (`CategoriesController`, `ProductsController`, `CustomersController`) tương tác trực tiếp với SQL Server LocalDB.
* Kiểm thử tính lưu trữ bền vững (Data Persistence) trên giao diện WinForms Client (`MiniSupermarket.WinForms`).

---

## 3. Kết Quả Đạt Được

### 3.1. Cấu hình Chuỗi Kết Nối (Connection String)
Cập nhật tệp `appsettings.json` kết nối tới SQL Server LocalDB:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
3.2. Entity Framework Core Migration & Seeding Dữ Liệu
Thực thi lệnh Add-Migration tạo mã khởi tạo cấu trúc các bảng: dbo.Categories, dbo.Products, và dbo.Customers.

Thiết lập OnModelCreating trong SupermarketDbContext nạp dữ liệu mẫu (Seeding Data) chuẩn hóa theo mô hình Tiệm Trà chanh & Tạp hóa vặt Chill Store:

5 Danh mục: Trà Chanh & Trà Trái Cây, Trà Sữa & Đồ Uống Pha Chế, Ăn Vặt Hot Trend, Khô Đóng Gói & Bánh Kẹo, Topping & Trái Cây Thêm.

15 Sản phẩm: Bao gồm các món hot trend (Trà chanh giã tay, Trà đào cam sả, Nem chua rán, Mẹt ăn vặt khổng lồ, Khô gà lá chanh...).

15 Khách hàng: Đầy đủ thông tin chi tiết (Họ tên, Số điện thoại, Địa chỉ cụ thể theo từng quận/thành phố, Hạng hội viên và Điểm tích lũy).

Chạy lệnh Update-Database đồng bộ hóa cấu trúc bảng và dữ liệu mẫu xuống đĩa cứng LocalDB.

3.3. Kiểm Thử API trên Swagger UI
Xây dựng và thực thi các thao tác CRUD bất đồng bộ (async/await) kết nối trực tiếp CSDL LocalDB.

Kiểm thử thành công các API:

GET /api/Categories, POST /api/Categories

GET /api/Products, POST /api/Products

GET /api/Customers, POST /api/Customers

Mã phản hồi trả về đúng chuẩn HTTP (200 OK, 201 Created tự động sinh ID tăng dần).

3.4. Kiểm Thử Bền Vững Dữ Liệu trên WinForms Client
Thiết lập Visual Studio khởi chạy đồng thời cả Backend API và WinForms Client (Multiple Startup Projects).

Thực hiện các thao tác Thêm / Sửa / Xóa danh mục và khách hàng trực tiếp từ màn hình quản lý FormCategoryManagement và FormCustomerManagement.

Đối soát CSDL: Sử dụng SQL Server Object Explorer / SSMS để kiểm tra trực tiếp dữ liệu trong các bảng dbo.Categories [Data], dbo.Products [Data], và dbo.Customers [Data].

Dữ liệu được lưu trữ nguyên vẹn trên đĩa cứng ngay cả khi tắt và khởi chạy lại toàn bộ ứng dụng.

4. Các Bước Triển Khai & Thực Thi Migrations
Mở cửa sổ Package Manager Console trong Visual Studio (Tools > NuGet Package Manager > Package Manager Console), chọn Default Project là MiniSupermarket.API và chạy tuần tự các lệnh:

Bước 1: Khởi tạo CSDL và bảng Categories, Products
PowerShell
Add-Migration InitialCreateDatabase
Update-Database
Bước 2: Cập nhật thêm bảng Customers (Bài tập mở rộng)
PowerShell
Add-Migration AddCustomersTable
Update-Database
(Mẹo: Nếu gặp sự cố cache gói NuGet, mở Terminal chạy lệnh: dotnet nuget locals all --clear rồi Build lại dự án).

5. Hướng Dẫn Kiểm Thử & Chạy Thực Nghiệm
5.1. Kiểm tra Backend trên Swagger UI
Nhấn F5 khởi chạy MiniSupermarket.API.

Mở Swagger UI, chạy GET /api/Categories: Xác nhận dữ liệu trả về 5 dòng mặc định được đọc trực tiếp từ LocalDB.

Thực thi POST /api/Categories để thêm nhóm hàng mới: Kiểm tra CategoryId tự sinh tăng dần (IDENTITY).

Mở SQL Server Object Explorer hoặc SSMS, thực hiện truy vấn SELECT * FROM dbo.Categories để đối soát dữ liệu trên đĩa cứng.

5.2. Kiểm thử trên WinForms Client (MiniSupermarket.WinForms)
Cập nhật BaseAddress trong cấu hình HttpClient nếu cổng port có thay đổi.

Khởi chạy ứng dụng WinForms.

Thao tác Thêm / Sửa / Xóa danh mục trên FormCategoryManagement và khách hàng trên FormCustomerManagement.

Đóng toàn bộ ứng dụng và Backend API, sau đó khởi động lại: Toàn bộ thay đổi vẫn còn nguyên vẹn.

6. Danh Sách Tệp Thay Đổi & Tạo Mới (Buổi 3)
MiniSupermarket.API

Models/Category.cs: Bổ sung Data Annotations, cấu hình khóa chính và quan hệ 1-N với Products.

Models/Product.cs: Định nghĩa thực thể Sản phẩm (ProductId, Barcode, Price, CategoryId,...).

Models/Customer.cs: Định nghĩa thực thể Khách hàng thân thiết (bài tập mở rộng).

Data/SupermarketDbContext.cs: Khai báo các DbSet<> và cấu hình nạp dữ liệu mồi (Data Seeding).

Controllers/CategoriesController.cs: Chuyển đổi logic sang dùng SupermarketDbContext và async/await.

Controllers/ProductsController.cs: Cung cấp API quản lý sản phẩm kết nối LocalDB.

Controllers/CustomersController.cs: Cung cấp các RESTful API quản lý danh sách khách hàng.

appsettings.json & Program.cs: Thiết lập chuỗi kết nối LocalDB và đăng ký AddDbContext qua Dependency Injection.

MiniSupermarket.WinForms

FormCategoryManagement.cs: Tích hợp gọi API lưu dữ liệu vĩnh viễn vào SQL Server LocalDB.

FormCustomerManagement.cs: Giao diện quản lý thông tin hội viên, tích điểm và hạng thẻ (bài tập mở rộng).
