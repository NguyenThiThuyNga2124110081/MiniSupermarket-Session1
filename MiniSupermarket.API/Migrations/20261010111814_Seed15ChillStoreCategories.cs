using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class Seed15ChillStoreCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Trà Chanh & Trà Trái Cây", "Các loại trà chanh giã tay, trà đào cam sả, trà dầm giải nhiệt" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Trà Sữa & Đồ Uống Pha Chế", "Trà sữa truyền thống, macchiato, cacao, cà phê pha máy" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Ăn Vặt Hot Trend (Nóng/Chiên)", "Mẹt ăn vặt, cá viên chiên, khoai tây lắc, nem chua rán, gà rán" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Khô Đóng Gói & Đồ Nhắm Chill", "Khô gà lá chanh, khô bò, khô mực, cơm cháy chà bông" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Bánh Tráng & Món Ăn Vặt Sài Gòn", "Bánh tráng trộn, bánh tráng cuộn, bánh tráng phơi sương, xì xì" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Topping & Trái Cây Thêm", "Trân châu đen/trắng, thạch dừa, khúc bạch, pudding, sương sáo" },
                    { 7, "Nước Ngọt & Nước Giải Khát Lon/Chai", "Nước có gas, nước tăng lực, trà xanh đóng chai, nước suối" },
                    { 8, "Kem & Đồ Lạnh Giải Nhiệt", "Kem que, kem ốc quế, đá bào tuyết, kem hộp các loại" },
                    { 9, "Mì Ăn Liền & Đồ Đóng Hộp Nhanh", "Mì ly, mì trộn Hàn Quốc, xúc xích ăn liền, phô mai que" },
                    { 10, "Bánh Kẹo Tạp Hóa & Snack Import", "Snack khoai tây, bánh quy, kẹo dẻo, kẹo ngậm thanh mát" },
                    { 11, "Sữa & Sản Phẩm Từ Sữa", "Sữa tươi đóng hộp, sữa chua ăn/uống, phô mai con bò cười" },
                    { 12, "Hạt Dinh Dưỡng & Đồ Ăn Kiêng", "Hạt hướng dương, hạt điều, hạt macca, ngũ cốc granola" },
                    { 13, "Gia Vị & Nước Chấm Ăn Vặt", "Tương ớt, sốt mayonaise, muối tôm Tây Ninh, sốt me, sa tế" },
                    { 14, "Văn Phòng Phẩm & Đồ Dùng Học Sinh", "Bút highlight, sổ tay Chill Store, khẩu trang, phụ kiện xinh" },
                    { 15, "Hóa Mỹ Phẩm & Đồ Tiện Lợi Cá Nhân", "Khăn giấy khô/ướt, xịt thơm miệng, nước rửa tay khô" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "123 Nguyễn Trãi, Q. Thanh Xuân, Hà Nội");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "456 Lê Duẩn, Q. 1, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "789 Điện Biên Phủ, Q. Thanh Khê, Đà Nẵng");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "Address",
                value: "12 Hòa Bình, Q. Ninh Kiều, Cần Thơ");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "Address",
                value: "34 Lạch Tray, Q. Ngô Quyền, Hải Phòng");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                column: "Address",
                value: "56 Đại lộ Bình Dương, TP. Thủ Dầu Một, Bình Dương");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                column: "Address",
                value: "89 Đồng Khởi, TP. Biên Hòa, Đồng Nai");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                column: "Address",
                value: "67 Trần Hưng Đạo, TP. Hạ Long, Quảng Ninh");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                column: "Address",
                value: "23 Hùng Vương, TP. Huế, Thừa Thiên Huế");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                column: "Address",
                value: "90 Trần Phú, TP. Nha Trang, Khánh Hòa");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                column: "Address",
                value: "15 Nguyễn Đình Chiểu, Q. 3, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                column: "Address",
                value: "88 Cầu Giấy, Q. Cầu Giấy, Hà Nội");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                column: "Address",
                value: "102 Thùy Vân, TP. Vũng Tàu, Bà Rịa - Vũng Tàu");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                column: "Address",
                value: "45 Phan Đình Phùng, TP. Đà Lạt, Lâm Đồng");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                column: "Address",
                value: "78 Nguyễn Trung Trực, TP. Rạch Giá, Kiên Giang");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8931111001011", 1, 20000m, "Trà Chanh Giã Tay Quảng Đông", 100 },
                    { 2, "8931111001028", 1, 25000m, "Trà Đào Cam Sả Chill", 120 },
                    { 3, "8931111001035", 1, 18000m, "Trà Tắc Xí Muội Đường Phèn", 90 },
                    { 4, "8931111002011", 2, 30000m, "Trà Sữa Trân Châu Đường Đen", 150 },
                    { 5, "8931111002028", 2, 32000m, "Trà Ô Long Macchiato", 80 },
                    { 6, "8931111002035", 2, 35000m, "Cacao Đá Xay Nhúng Kem", 60 },
                    { 7, "8931111002042", 2, 22000m, "Bạc Xỉu Đá Sài Gòn", 110 },
                    { 8, "8931111003011", 3, 65000m, "Mẹt Ăn Vặt Thập Cẩm (Khổng Lồ)", 50 },
                    { 9, "8931111003028", 3, 40000m, "Nem Chua Rán Hà Nội (10 Cái)", 70 },
                    { 10, "8931111003035", 3, 25000m, "Khoai Tây Lắc Phô Mai Extra", 100 },
                    { 11, "8931111004011", 4, 45000m, "Khô Gá Lá Chanh Hũ 250g", 85 },
                    { 12, "8931111004028", 4, 35000m, "Cơm Cháy Sốt Mắm Hành 200g", 95 },
                    { 13, "8931111004035", 4, 20000m, "Bánh Gấu Nhân Cơm Sữa 150g", 130 },
                    { 14, "8931111005011", 5, 5000m, "Topping Trân Châu Ô Long", 200 },
                    { 15, "8931111005028", 5, 8000m, "Topping Pudding Phô Mai", 150 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Bánh kẹo & Đồ ăn vặt", "Snack, bánh quy, kẹo dẻo" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Nước giải khát & Trà", "Nước ngọt, nước khoáng, trà" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Sữa & Sản phẩm từ sữa", "Sữa tươi, sữa chua, phô mai" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Mì gói & Thực phẩm ăn liền", "Mì ăn liền, phở khô, cháo gói" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Gia vị & Dầu ăn", "Nước mắm, hạt nêm, dầu thực vật" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "Hà Nội");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "Đà Nẵng");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "Address",
                value: "Cần Thơ");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "Address",
                value: "Hải Phòng");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                column: "Address",
                value: "Bình Dương");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                column: "Address",
                value: "Đồng Nai");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                column: "Address",
                value: "Quảng Ninh");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                column: "Address",
                value: "Huế");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                column: "Address",
                value: "Nha Trang");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                column: "Address",
                value: "TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                column: "Address",
                value: "Hà Nội");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                column: "Address",
                value: "Vũng Tàu");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                column: "Address",
                value: "Lâm Đồng");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                column: "Address",
                value: "Kiên Giang");
        }
    }
}
