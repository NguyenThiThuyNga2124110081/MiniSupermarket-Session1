🛒 HỆ THỐNG QUẢN LÝ BÁN LẺ & TỒN KHO SIÊU THỊ MINI (MINISUPERMARKET)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
Bài thực hành: Buổi 05 - ADO.NET Nâng cao, Stored Procedure & Giao dịch POS Checkout (ACID)

---

👤 THÔNG TIN SINH VIÊN
Họ và tên: Nguyễn Thị Thúy Nga  
Mã số sinh viên: 2124110081  
Lớp: CCQ2411C  

---

📌 BÁO CÁO KẾT QUẢ THỰC HÀNH BUỔI 5
1. Mục tiêu bài học & Tình huống Thực tế
Mục tiêu:
  * Nắm vững kiến trúc ADO.NET thuần: Phân biệt 5 đối tượng cốt lõi (`SqlConnection`, `SqlCommand`, `SqlParameter`, `SqlDataReader`, `DataTable`) và 3 phương thức thực thi (`ExecuteScalar`, `ExecuteNonQuery`, `ExecuteReader`).
  * Xây dựng API tra cứu mã vạch siêu tốc cho quầy POS bằng `SqlDataReader` (Connected Mode) và thử nghiệm mô hình ngắt kết nối với `DataTable` & `SqlDataAdapter` (Disconnected Mode).
  * Tối ưu hóa truy vấn báo cáo doanh thu ca bán bằng **Stored Procedure** (`sp_GetRevenueByCashier`).
  * Thực thi giao dịch đa bảng an toàn với **`SqlTransaction`**, đảm bảo tuân thủ nghiêm ngặt 4 đặc tính **ACID** trong nghiệp vụ thanh toán hóa đơn POS.

---

2. Chi tiết các Tiết Thực hành & Kết quả Đạt được

🔹 Tiết 1: ADO.NET Căn bản & An toàn dữ liệu
Kết nối & Thực thi:
  * Sử dụng `using` bọc kín `SqlConnection` để tự động giải phóng tài nguyên kết nối.
  * Phân biệt chính xác các phương thức thực thi:
    * `ExecuteScalar()`: Đếm tổng số mặt hàng trong CSDL.
    * `ExecuteNonQuery()`: Cập nhật số lượng tồn kho sản phẩm.
    * `ExecuteReader()`: Duyệt luồng dữ liệu danh sách sản phẩm.
  Bảo mật: Áp dụng `SqlParameter` (như `@Stock`, `@Id`, `@Barcode`) trên toàn bộ câu lệnh SQL để triệt tiêu 100% lỗ hổng tấn công **SQL Injection**.

🔹 Tiết 2: API Tra cứu Barcode Siêu tốc & Mô hình Ngắt kết nối
Controller: `AdoProductController.cs` (`api/ado-products`)
Chức năng:
  * `GET /api/ado-products/barcode/{barcode}`: Tra cứu thông tin sản phẩm theo mã vạch phục vụ súng quét quầy POS, trả về kết quả cực nhanh với `SqlDataReader` (phản hồi < 100ms).
  * `GET /api/ado-products/disconnected-cache`: Tải toàn bộ danh sách sản phẩm đổ vào `DataTable` qua `SqlDataAdapter.Fill()` và đóng kết nối ngay lập tức để lưu đệm trên RAM.

🔹 Tiết 3: Tối ưu Truy vấn với Stored Procedure
Database: Khởi tạo thành công Stored Procedure `sp_GetRevenueByCashier` trên SQL Server để gom nhóm (`GROUP BY CashierUsername`) tính tổng số đơn, tổng doanh thu và điểm thưởng.
Controller: `ReportsController.cs` (`api/reports`)
Chức năng:
  * `GET /api/reports/revenue-by-cashier`: Kích hoạt Stored Procedure thông qua thiết lập `command.CommandType = CommandType.StoredProcedure` kết hợp `SqlDataReader` xuất báo cáo ca bán cho Admin.

🔹 Tiết 4 & 5: Chuẩn ACID & Giao dịch Thanh toán POS với `SqlTransaction`
Controller: `CheckoutController.cs` (`api/checkout`)
Chức năng:
  * `POST /api/checkout`: Thực hiện giao dịch thanh toán khép kín qua 4 bước liên hoàn bọc trong `SqlTransaction`:
    1. **Tạo Orders**: Sinh mã hóa đơn, tính tổng tiền và điểm thưởng. Lấy `OrderId` tự tăng bằng `OUTPUT INSERTED.OrderId` qua `ExecuteScalar()`.
    2. **Lưu OrderDetails**: Duyệt từng món hàng trong giỏ để lưu chi tiết hóa đơn.
    3. **Cập nhật Products**: Kiểm tra tồn kho thực tế và trừ số lượng sản phẩm.
    4. **Tích điểm Customers**: Cộng điểm thưởng cho khách hàng thân thiết.
 Kiểm thử Cơ chế Rollback (ACID)**:
  * Khi đặt hàng vượt quá tồn kho thực tế, hệ thống lập tức ném ngoại lệ (`InvalidOperationException`) và tự động kích hoạt `transaction.Rollback()`.
  * **Minh chứng toàn vẹn**: Dữ liệu không bị rác, không tạo hóa đơn "nửa vời" và số lượng tồn kho của các sản phẩm trước đó được giữ nguyên 100%.

---

 📊 MA TRẬN PHÂN QUYỀN HỆ THỐNG

| Vai trò (Role) | Màn hình mặc định | Màn hình được phép truy cập | Chức năng bị khóa tuyệt đối |
| :--- | :--- | :--- | :--- |
| 🛡 Admin | `FormCategoryManagement` | Tất cả màn hình | *Không bị hạn chế (Toàn quyền)* |
| 🛒 Cashier | `FormPOS` | `FormPOS`, `FormCustomerManagement` | Quản lý kho, Sửa giá, Báo cáo tài chính, Quản lý tài khoản |
| 📦 Warehouse| `FormProductManagement` | `FormProductManagement`, `FormCategoryManagement` | Bán hàng POS, Xem doanh thu, Tạo tài khoản, Quản lý khách hàng |

