 BUỔI 3: KẾT NỐI CƠ SỞ DỮ LIỆU LOCALDB, EF CORE MIGRATION & KIỂM THỬ BỀN VỮNG DỮ LIỆU
 1. TÊN TÁC GIẢ
  Họ và tên: Nguyễn Thị Thúy Nga
  MSSV: 2124110081
  Lớp: CCQ2411C
  Tên môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)

---

 2. MỤC TIÊU BÀI THỰC HÀNH
* Chuyển đổi Cơ sở dữ liệu từ bộ nhớ tạm (InMemory Database) sang **SQL Server LocalDB**.
* Thực thi Entity Framework Core Migration để khởi tạo cấu trúc CSDL và nạp dữ liệu mẫu (Seeding Data) cho các bảng `Categories`, `Products` và `Customers`.
* Xây dựng Backend RESTful API (`CategoriesController`, `ProductsController`, `CustomersController`) tương tác trực tiếp với SQL Server LocalDB.
* Kiểm thử tính lưu trữ bền vững (Data Persistence) trên giao diện WinForms Client (`MiniSupermarketWinForms`).

---

 3. KẾT QUẢ ĐẠT ĐƯỢC

 3.1. Cấu hình Chuỗi Kết Nối (Connection String)
Cập nhật file `appsettings.json` kết nối tới SQL Server LocalDB:
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

3.3. Kiểm thử API trên Swagger UI
Xây dựng và thực thi các thao tác CRUD bất đồng bộ (async/await) kết nối trực tiếp CSDL LocalDB.

Kiểm thử thành công các API:

GET /api/Categories, POST /api/Categories

GET /api/Products, POST /api/Products

GET /api/Customers, POST /api/Customers

Mã phản hồi trả về đúng chuẩn HTTP (200 OK, 201 Created tự động sinh ID tăng tự động).

3.4. Kiểm thử Bền vững Dữ liệu trên WinForms Client
Thiết lập Visual Studio khởi chạy đồng thời cả Backend API và WinForms Client (Multiple Startup Projects).

Thực hiện các thao tác Thêm / Sửa / Xóa danh mục và khách hàng trực tiếp từ màn hình quản lý FormCategoryManagement và FormCustomerManagement.

Đối soát CSDL: Sử dụng SQL Server Object Explorer để kiểm tra trực tiếp dữ liệu trong các bảng dbo.Categories [Data], dbo.Products [Data], và dbo.Customers [Data].

Dữ liệu được lưu trữ nguyên vẹn trên đĩa cứng ngay cả khi tắt và khởi chạy lại toàn bộ ứng dụng.


3. TÊN TÁC GIẢ
Họ và tên: Nguyễn Thị Thúy Nga
MSSV: 2124110081
Lớp: CCQ2411C
