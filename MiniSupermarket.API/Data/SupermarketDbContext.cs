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

            // 1. Seeding 15 Danh mục chủ đề Chill Stores
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Trà Chanh & Trà Trái Cây", Description = "Các loại trà chanh giã tay, trà đào cam sả, trà dầm giải nhiệt" },
                new Category { CategoryId = 2, CategoryName = "Trà Sữa & Đồ Uống Pha Chế", Description = "Trà sữa truyền thống, macchiato, cacao, cà phê pha máy" },
                new Category { CategoryId = 3, CategoryName = "Ăn Vặt Hot Trend (Nóng/Chiên)", Description = "Mẹt ăn vặt, cá viên chiên, khoai tây lắc, nem chua rán, gà rán" },
                new Category { CategoryId = 4, CategoryName = "Khô Đóng Gói & Đồ Nhắm Chill", Description = "Khô gà lá chanh, khô bò, khô mực, cơm cháy chà bông" },
                new Category { CategoryId = 5, CategoryName = "Topping & Trái Cây Thêm", Description = "Trân châu đen/trắng, thạch dừa, khúc bạch, pudding, sương sáo" },
                new Category { CategoryId = 6, CategoryName = "Bánh Tráng & Món Ăn Vặt Sài Gòn", Description = "Bánh tráng trộn, bánh tráng cuộn, bánh tráng phơi sương, xì xì" },
                new Category { CategoryId = 7, CategoryName = "Nước Ngọt & Nước Giải Khát Lon/Chai", Description = "Nước có gas, nước tăng lực, trà xanh đóng chai, nước suối" },
                new Category { CategoryId = 8, CategoryName = "Kem & Đồ Lạnh Giải Nhiệt", Description = "Kem que, kem ốc quế, đá bào tuyết, kem hộp các loại" },
                new Category { CategoryId = 9, CategoryName = "Mì Ăn Liền & Đồ Đóng Hộp Nhanh", Description = "Mì ly, mì trộn Hàn Quốc, xúc xích ăn liền, phô mai que" },
                new Category { CategoryId = 10, CategoryName = "Bánh Kẹo Tạp Hóa & Snack Import", Description = "Snack khoai tây, bánh quy, kẹo dẻo, kẹo ngậm thanh mát" },
                new Category { CategoryId = 11, CategoryName = "Sữa & Sản Phẩm Từ Sữa", Description = "Sữa tươi đóng hộp, sữa chua ăn/uống, phô mai con bò cười" },
                new Category { CategoryId = 12, CategoryName = "Hạt Dinh Dưỡng & Đồ Ăn Kiêng", Description = "Hạt hướng dương, hạt điều, hạt macca, ngũ cốc granola" },
                new Category { CategoryId = 13, CategoryName = "Gia Vị & Nước Chấm Ăn Vặt", Description = "Tương ớt, sốt mayonaise, muối tôm Tây Ninh, sốt me, sa tế" },
                new Category { CategoryId = 14, CategoryName = "Văn Phòng Phẩm & Đồ Dùng Học Sinh", Description = "Bút highlight, sổ tay Chill Store, khẩu trang, phụ kiện xinh" },
                new Category { CategoryId = 15, CategoryName = "Hóa Mỹ Phẩm & Đồ Tiện Lợi Cá Nhân", Description = "Khăn giấy khô/ướt, xịt thơm miệng, nước rửa tay khô" }
            );

            // 2. Seeding 30 Sản phẩm mẫu liên kết với 15 Danh mục (mỗi danh mục 2 sản phẩm)
            modelBuilder.Entity<Product>().HasData(
                // Category 1: Trà Chanh & Trà Trái Cây
                new Product { ProductId = 1, Barcode = "8931111001011", ProductName = "Trà Chanh Giã Tay Quảng Đông", Price = 20000, StockQuantity = 100, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "8931111001028", ProductName = "Trà Đào Cam Sả Chill", Price = 25000, StockQuantity = 120, CategoryId = 1 },

                // Category 2: Trà Sữa & Đồ Uống Pha Chế
                new Product { ProductId = 3, Barcode = "8931111002011", ProductName = "Trà Sữa Trân Châu Đường Đen", Price = 30000, StockQuantity = 150, CategoryId = 2 },
                new Product { ProductId = 4, Barcode = "8931111002028", ProductName = "Trà Ô Long Macchiato", Price = 32000, StockQuantity = 80, CategoryId = 2 },

                // Category 3: Ăn Vặt Hot Trend (Nóng/Chiên)
                new Product { ProductId = 5, Barcode = "8931111003011", ProductName = "Mẹt Ăn Vặt Thập Cẩm Khổng Lồ", Price = 65000, StockQuantity = 50, CategoryId = 3 },
                new Product { ProductId = 6, Barcode = "8931111003028", ProductName = "Nem Chua Rán Hà Nội (10 Cái)", Price = 40000, StockQuantity = 70, CategoryId = 3 },

                // Category 4: Khô Đóng Gói & Đồ Nhắm Chill
                new Product { ProductId = 7, Barcode = "8931111004011", ProductName = "Khô Gà Lá Chanh Hũ 250g", Price = 45000, StockQuantity = 85, CategoryId = 4 },
                new Product { ProductId = 8, Barcode = "8931111004028", ProductName = "Khô Bò Miếng Thượng Hạng 200g", Price = 85000, StockQuantity = 60, CategoryId = 4 },

                // Category 5: Topping & Trái Cây Thêm
                new Product { ProductId = 9, Barcode = "8931111005011", ProductName = "Topping Trân Châu Ô Long Đen", Price = 5000, StockQuantity = 200, CategoryId = 5 },
                new Product { ProductId = 10, Barcode = "8931111005028", ProductName = "Topping Pudding Phô Mai Trứng", Price = 8000, StockQuantity = 150, CategoryId = 5 },

                // Category 6: Bánh Tráng & Món Ăn Vặt Sài Gòn
                new Product { ProductId = 11, Barcode = "8931111006011", ProductName = "Bánh Tráng Trộn Sài Gòn Đặc Biệt", Price = 20000, StockQuantity = 110, CategoryId = 6 },
                new Product { ProductId = 12, Barcode = "8931111006028", ProductName = "Bánh Tráng Cuộn Bơ Sốt Me Cay", Price = 22000, StockQuantity = 95, CategoryId = 6 },

                // Category 7: Nước Ngọt & Nước Giải Khát Lon/Chai
                new Product { ProductId = 13, Barcode = "8931111007011", ProductName = "Nước Ngọt Coca Cola Lon 320ml", Price = 12000, StockQuantity = 180, CategoryId = 7 },
                new Product { ProductId = 14, Barcode = "8931111007028", ProductName = "Trà Xanh Không Độ Chai 455ml", Price = 10000, StockQuantity = 160, CategoryId = 7 },

                // Category 8: Kem & Đồ Lạnh Giải Nhiệt
                new Product { ProductId = 15, Barcode = "8931111008011", ProductName = "Kem Ốc Quế Cornetto Socola", Price = 18000, StockQuantity = 90, CategoryId = 8 },
                new Product { ProductId = 16, Barcode = "8931111008028", ProductName = "Kem Hộp Merino Dâu Vani 400ml", Price = 35000, StockQuantity = 65, CategoryId = 8 },

                // Category 9: Mì Ăn Liền & Đồ Đóng Hộp Nhanh
                new Product { ProductId = 17, Barcode = "8931111009011", ProductName = "Mì Trộn Samyang Phô Mai Hàn Quốc", Price = 28000, StockQuantity = 130, CategoryId = 9 },
                new Product { ProductId = 18, Barcode = "8931111009028", ProductName = "Xúc Xích Tiệt Trùng CP Heo 4 Cây", Price = 16000, StockQuantity = 140, CategoryId = 9 },

                // Category 10: Bánh Kẹo Tạp Hóa & Snack Import
                new Product { ProductId = 19, Barcode = "8931111010011", ProductName = "Snack Khoai Tây Lay's Tự Nhiên 95g", Price = 22000, StockQuantity = 105, CategoryId = 10 },
                new Product { ProductId = 20, Barcode = "8931111010028", ProductName = "Kẹo Dẻo Chupa Chups Trái Cây 90g", Price = 15000, StockQuantity = 115, CategoryId = 10 },

                // Category 11: Sữa & Sản Phẩm Từ Sữa
                new Product { ProductId = 21, Barcode = "8931111011011", ProductName = "Sữa Tươi Tiệt Trùng Vinamilk 1 Lít", Price = 36000, StockQuantity = 75, CategoryId = 11 },
                new Product { ProductId = 22, Barcode = "8931111011028", ProductName = "Sữa Chua Ăn Vinamilk Có Đường (Vỉ 4)", Price = 28000, StockQuantity = 80, CategoryId = 11 },

                // Category 12: Hạt Dinh Dưỡng & Đồ Ăn Kiêng
                new Product { ProductId = 23, Barcode = "8931111012011", ProductName = "Hạt Điều Rang Muối Vỏ Lụa 200g", Price = 55000, StockQuantity = 60, CategoryId = 12 },
                new Product { ProductId = 24, Barcode = "8931111012028", ProductName = "Ngũ Cốc Ăn Kiêng Granola Mật Ong 250g", Price = 68000, StockQuantity = 50, CategoryId = 12 },

                // Category 13: Gia Vị & Nước Chấm Ăn Vặt
                new Product { ProductId = 25, Barcode = "8931111013011", ProductName = "Tương Ớt Chin-Su Chai 250g", Price = 14000, StockQuantity = 120, CategoryId = 13 },
                new Product { ProductId = 26, Barcode = "8931111013028", ProductName = "Muối Tôm Tây Ninh Đặc Biệt Hũ 150g", Price = 18000, StockQuantity = 95, CategoryId = 13 },

                // Category 14: Văn Phòng Phẩm & Đồ Dùng Học Sinh
                new Product { ProductId = 27, Barcode = "8931111014011", ProductName = "Sổ Tay Bìa Cứng MiniMart A5 160 Trang", Price = 25000, StockQuantity = 85, CategoryId = 14 },
                new Product { ProductId = 28, Barcode = "8931111014028", ProductName = "Bộ Bút Highlight Pastel 6 Màu Dạ Quang", Price = 32000, StockQuantity = 70, CategoryId = 14 },

                // Category 15: Hóa Mỹ Phẩm & Đồ Tiện Lợi Cá Nhân
                new Product { ProductId = 29, Barcode = "8931111015011", ProductName = "Khăn Ướt Kháng Khuẩn Bỏ Túi 20 Tờ", Price = 12000, StockQuantity = 150, CategoryId = 15 },
                new Product { ProductId = 30, Barcode = "8931111015028", ProductName = "Chai Nước Rửa Tay Khô Diệt Khuẩn 100ml", Price = 25000, StockQuantity = 90, CategoryId = 15 }
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