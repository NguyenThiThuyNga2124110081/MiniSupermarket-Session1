using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seeding 5 Danh mục chủ đề Chill Store
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Trà Chanh & Trà Trái Cây", Description = "Các loại trà chanh, trà đào, trà dầm giải nhiệt" },
                new Category { CategoryId = 2, CategoryName = "Trà Sữa & Đồ Uống Pha Chế", Description = "Trà sữa, macchiato, cacao, cà phê pha máy" },
                new Category { CategoryId = 3, CategoryName = "Ăn Vặt Hot Trend", Description = "Mẹt ăn vặt, cá viên chiên, khoai tây, nem chua rán" },
                new Category { CategoryId = 4, CategoryName = "Khô Đóng Gói & Bánh Kẹo", Description = "Khô gà, khô bò, cơm cháy, bánh kẹo tạp hóa" },
                new Category { CategoryId = 5, CategoryName = "Topping & Trái Cây Thêm", Description = "Trân châu, thạch, khúc bạch, pudding" }
            );

            // 2. Seeding 15 Sản phẩm mẫu chủ đề Chill Store
            modelBuilder.Entity<Product>().HasData(
                // Category 1: Trà Chanh & Trà Trái Cây
                new Product { ProductId = 1, Barcode = "8931111001011", ProductName = "Trà Chanh Giã Tay Quảng Đông", Price = 20000, StockQuantity = 100, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "8931111001028", ProductName = "Trà Đào Cam Sả Chill", Price = 25000, StockQuantity = 120, CategoryId = 1 },
                new Product { ProductId = 3, Barcode = "8931111001035", ProductName = "Trà Tắc Xí Muội Đường Phèn", Price = 18000, StockQuantity = 90, CategoryId = 1 },

                // Category 2: Trà Sữa & Đồ Uống Pha Chế
                new Product { ProductId = 4, Barcode = "8931111002011", ProductName = "Trà Sữa Trân Châu Đường Đen", Price = 30000, StockQuantity = 150, CategoryId = 2 },
                new Product { ProductId = 5, Barcode = "8931111002028", ProductName = "Trà Ô Long Macchiato", Price = 32000, StockQuantity = 80, CategoryId = 2 },
                new Product { ProductId = 6, Barcode = "8931111002035", ProductName = "Cacao Đá Xay Nhúng Kem", Price = 35000, StockQuantity = 60, CategoryId = 2 },
                new Product { ProductId = 7, Barcode = "8931111002042", ProductName = "Bạc Xỉu Đá Sài Gòn", Price = 22000, StockQuantity = 110, CategoryId = 2 },

                // Category 3: Ăn Vặt Hot Trend
                new Product { ProductId = 8, Barcode = "8931111003011", ProductName = "Mẹt Ăn Vặt Thập Cẩm (Khổng Lồ)", Price = 65000, StockQuantity = 50, CategoryId = 3 },
                new Product { ProductId = 9, Barcode = "8931111003028", ProductName = "Nem Chua Rán Hà Nội (10 Cái)", Price = 40000, StockQuantity = 70, CategoryId = 3 },
                new Product { ProductId = 10, Barcode = "8931111003035", ProductName = "Khoai Tây Lắc Phô Mai Extra", Price = 25000, StockQuantity = 100, CategoryId = 3 },

                // Category 4: Khô Đóng Gói & Bánh Kẹo
                new Product { ProductId = 11, Barcode = "8931111004011", ProductName = "Khô Gá Lá Chanh Hũ 250g", Price = 45000, StockQuantity = 85, CategoryId = 4 },
                new Product { ProductId = 12, Barcode = "8931111004028", ProductName = "Cơm Cháy Sốt Mắm Hành 200g", Price = 35000, StockQuantity = 95, CategoryId = 4 },
                new Product { ProductId = 13, Barcode = "8931111004035", ProductName = "Bánh Gấu Nhân Cơm Sữa 150g", Price = 20000, StockQuantity = 130, CategoryId = 4 },

                // Category 5: Topping & Trái Cây Thêm
                new Product { ProductId = 14, Barcode = "8931111005011", ProductName = "Topping Trân Châu Ô Long", Price = 5000, StockQuantity = 200, CategoryId = 5 },
                new Product { ProductId = 15, Barcode = "8931111005028", ProductName = "Topping Pudding Phô Mai", Price = 8000, StockQuantity = 150, CategoryId = 5 }
            );

            // 3. Seeding dữ liệu cho 15 khách hàng
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn A", PhoneNumber = "0901122334", Address = "123 Nguyễn Trãi, Q. Thanh Xuân, Hà Nội", MembershipRank = "Vàng", RewardPoints = 150 },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị B", PhoneNumber = "0918877665", Address = "456 Lê Duẩn, Q. 1, TP.HCM", MembershipRank = "Bạc", RewardPoints = 50 },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn C", PhoneNumber = "0983344556", Address = "789 Điện Biên Phủ, Q. Thanh Khê, Đà Nẵng", MembershipRank = "Chuẩn", RewardPoints = 10 },
                new Customer { CustomerId = 4, CustomerName = "Phạm Minh Đức", PhoneNumber = "0971234567", Address = "12 Hòa Bình, Q. Ninh Kiều, Cần Thơ", MembershipRank = "Bạch Kim", RewardPoints = 320 },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Thu Thảo", PhoneNumber = "0934567890", Address = "34 Lạch Tray, Q. Ngô Quyền, Hải Phòng", MembershipRank = "Vàng", RewardPoints = 180 },
                new Customer { CustomerId = 6, CustomerName = "Đỗ Quốc Anh", PhoneNumber = "0945678901", Address = "56 Đại lộ Bình Dương, TP. Thủ Dầu Một, Bình Dương", MembershipRank = "Chuẩn", RewardPoints = 25 },
                new Customer { CustomerId = 7, CustomerName = "Vũ Mỹ Linh", PhoneNumber = "0967890123", Address = "89 Đồng Khởi, TP. Biên Hòa, Đồng Nai", MembershipRank = "Bạc", RewardPoints = 75 },
                new Customer { CustomerId = 8, CustomerName = "Bùi Tấn Phát", PhoneNumber = "0923456789", Address = "67 Trần Hưng Đạo, TP. Hạ Long, Quảng Ninh", MembershipRank = "Vàng", RewardPoints = 210 },
                new Customer { CustomerId = 9, CustomerName = "Đặng Hồng Hạnh", PhoneNumber = "0956789012", Address = "23 Hùng Vương, TP. Huế, Thừa Thiên Huế", MembershipRank = "Chuẩn", RewardPoints = 0 },
                new Customer { CustomerId = 10, CustomerName = "Ngô Gia Bảo", PhoneNumber = "0987654321", Address = "90 Trần Phú, TP. Nha Trang, Khánh Hòa", MembershipRank = "Bạch Kim", RewardPoints = 500 },
                new Customer { CustomerId = 11, CustomerName = "Dương Ngọc Trinh", PhoneNumber = "0912345678", Address = "15 Nguyễn Đình Chiểu, Q. 3, TP.HCM", MembershipRank = "Bạc", RewardPoints = 90 },
                new Customer { CustomerId = 12, CustomerName = "Lý Khánh Vân", PhoneNumber = "0938765432", Address = "88 Cầu Giấy, Q. Cầu Giấy, Hà Nội", MembershipRank = "Vàng", RewardPoints = 160 },
                new Customer { CustomerId = 13, CustomerName = "Mai Xuân Trường", PhoneNumber = "0941239876", Address = "102 Thùy Vân, TP. Vũng Tàu, Bà Rịa - Vũng Tàu", MembershipRank = "Chuẩn", RewardPoints = 15 },
                new Customer { CustomerId = 14, CustomerName = "Trịnh Kim Ngân", PhoneNumber = "0965432109", Address = "45 Phan Đình Phùng, TP. Đà Lạt, Lâm Đồng", MembershipRank = "Bạc", RewardPoints = 85 },
                new Customer { CustomerId = 15, CustomerName = "Đoàn Hải Nam", PhoneNumber = "0978901234", Address = "78 Nguyễn Trung Trực, TP. Rạch Giá, Kiên Giang", MembershipRank = "Bạch Kim", RewardPoints = 410 }
            );
        }
    }
}