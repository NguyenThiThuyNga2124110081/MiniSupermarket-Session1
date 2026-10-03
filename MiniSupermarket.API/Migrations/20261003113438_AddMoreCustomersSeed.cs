using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCustomersSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 4, "Cần Thơ", "Phạm Minh Đức", "Bạch Kim", "0971234567", 320 },
                    { 5, "Hải Phòng", "Hoàng Thu Thảo", "Vàng", "0934567890", 180 },
                    { 6, "Bình Dương", "Đỗ Quốc Anh", "Chuẩn", "0945678901", 25 },
                    { 7, "Đồng Nai", "Vũ Mỹ Linh", "Bạc", "0967890123", 75 },
                    { 8, "Quảng Ninh", "Bùi Tấn Phát", "Vàng", "0923456789", 210 },
                    { 9, "Huế", "Đặng Hồng Hạnh", "Chuẩn", "0956789012", 0 },
                    { 10, "Nha Trang", "Ngô Gia Bảo", "Bạch Kim", "0987654321", 500 },
                    { 11, "TP.HCM", "Dương Ngọc Trinh", "Bạc", "0912345678", 90 },
                    { 12, "Hà Nội", "Lý Khánh Vân", "Vàng", "0938765432", 160 },
                    { 13, "Vũng Tàu", "Mai Xuân Trường", "Chuẩn", "0941239876", 15 },
                    { 14, "Lâm Đồng", "Trịnh Kim Ngân", "Bạc", "0965432109", 85 },
                    { 15, "Kiên Giang", "Đoàn Hải Nam", "Bạch Kim", "0978901234", 410 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);
        }
    }
}
