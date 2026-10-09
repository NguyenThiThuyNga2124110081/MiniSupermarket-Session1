 🛒 HỆ THỐNG QUẢN LÝ BÁN LẺ & TỒN KHO SIÊU THỊ MINI (MINISUPERMARKET)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
Bài thực hành: Buổi 04 - Thiết kế Kiến trúc Giao diện WinForms Shell & Điều hướng Phân quyền (RBAC)

---

👤 THÔNG TIN SINH VIÊN
Họ và tên: Nguyễn Thị Thúy Nga  
Mã số sinh viên: 2124110081  
Lớp: CCQ2411C  

---

 📌 BÁO CÁO KẾT QUẢ THỰC HÀNH BUỔI 4

1. Mục tiêu & Tình huống Thực tế
Mục tiêu: 
  * Xây dựng giao diện đơn khung hiện đại (Single-Form Shell Architecture) trên Windows Forms (.NET Core/C#).
  * Làm chủ kỹ thuật nhúng động Form con (`TopLevel = false`, `Dock = Fill`, `FormBorderStyle = None`) vào vùng chứa mà không mở cửa sổ rời rạc.
  * Hiện thực hóa cơ chế phân quyền Role-Based Access Control (RBAC) trên WinForms Client cho 3 vai trò: **Admin**, **Cashier (Thu ngân)**, và **Warehouse (Thủ kho)**.
* **Tình huống bài toán**: Màn hình điều khiển trung tâm `FormMainShell` tự động ẩn/hiện chức năng và mở màn hình mặc định đúng chuyên môn theo vai trò tài khoản đăng nhập.

---

 2. Mô hình Kiến trúc Giao diện (`FormMainShell`)
Cấu trúc giao diện được phân chia thành 3 khu vực chính:
* **`panelSidebar`** (Width = 230, Dock = Left): Chứa logo, các nút chức năng điều hướng (`btnPOS`, `btnCategory`, `btnProduct`, `btnCustomer`, `btnReports`, `btnUserManage`) và nút Đăng xuất (`btnLogout`).
* **`panelTopHeader`** (Height = 60, Dock = Top): Hiển thị tiêu đề màn hình nghiệp vụ (`lblTitle`) và thông tin phiên làm việc (`lblUserInfo`).
* **`panelMainContent`** (Dock = Fill): Vùng làm việc trung tâm chứa các Form con được nhúng động.

---

3. Các Form Con Nghiệp Vụ Đã Triển Khai

1. **`FormPOS.cs` (Màn hình Bán hàng Quầy POS)**:
   * **Xử lý Mã vạch**: Tích hợp sự kiện `KeyDown` trên ô nhập mã vạch, tự động gọi API `GET /api/Products/barcode/{barcode}` để nạp sản phẩm vào giỏ hàng (`dgvCart`).
   * **Tính toán tiền**: Tự động cộng dồn số lượng, tính tổng tiền giỏ hàng, số tiền khách đưa và tiền thừa trả lại.
   * **Thanh toán**: Gửi request `POST /api/orders/checkout` để hoàn tất đơn hàng và làm sạch giỏ hàng.

2. **`FormProductManagement.cs` (Quản lý Sản phẩm & Tồn kho)**:
   * Hỗ trợ tìm kiếm theo mã vạch, lọc theo nhóm hàng và hiển thị danh sách sản phẩm.
   * Tích hợp các thao tác CRUD (Thêm, Sửa, Xóa) bất đồng bộ kết nối Web API.

3. **`FormUserManagement.cs` (Quản trị Tài khoản & Phân quyền)**:
   * Dành riêng cho Admin để xem danh sách nhân viên, tạo tài khoản mới và gán vai trò (`Admin`, `Cashier`, `Warehouse`).

4. **`FormQuickReport.cs` (Báo cáo Doanh thu Ca Bán)**:
   * Tích hợp bộ lọc ngày, hiển thị các chỉ số tóm tắt (Tổng số hóa đơn, Tổng doanh thu, Mặt hàng bán chạy).

---

4. Bảng Kiểm Thử & Ma Trận Phân Quyền (RBAC)

Hệ thống đã được thử nghiệm và vượt qua đầy đủ các kịch bản kiểm thử trên bộ dữ liệu 15 tài khoản mẫu:

| Vai trò (Role) | Tài khoản test mẫu | Màn hình khởi chạy mặc định | Màn hình được phép truy cập | Chức năng bị khóa tuyệt đối |
| :--- | :--- | :--- | :--- | :--- |
| 🛡 **Admin** | `admin01` / `123456` | `FormCategoryManagement` | Tất cả màn hình | *Không bị hạn chế (Toàn quyền)* |
| 🛒 **Cashier** | `cashier01` / `123456` | `FormCustomerManagement` / `FormPOS` | `FormPOS`, `FormCustomerManagement` | Quản lý kho, Sửa giá, Báo cáo tài chính, Quản lý tài khoản |
| 📦 **Warehouse** | `ware01` / `123456` | `FormProductManagement` | `FormProductManagement`, `FormCategoryManagement` | Bán hàng POS, Xem doanh thu, Tạo tài khoản, Quản lý khách hàng |
