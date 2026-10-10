using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiniSupermarket.API.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Lấy chuỗi kết nối và Đăng ký DbContext (EF Core SQL Server)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Lấy secret key từ appsettings.json
var jwtSecret = builder.Configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!";

// 3. Cấu hình JwtBearer Authentication
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 4. Cấu hình Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniSupermarket API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập theo định dạng: Bearer <chuỗi_token_của_bạn>"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Chỉ gọi duy nhất 1 lần builder.Build() sau khi đã đăng ký hết Services
var app = builder.Build();

// Cấu hình HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 5. Đồng bộ và cập nhật chuẩn font tiếng Việt Unicode cho 15 Nhóm hàng trong CSDL
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SupermarketDbContext>();
    var sampleCategories = new[]
    {
        new { Id = 1, Name = "Trà Chanh & Trà Trái Cây", Desc = "Các loại trà chanh giã tay, trà đào cam sả, trà dầm giải nhiệt" },
        new { Id = 2, Name = "Trà Sữa & Đồ Uống Pha Chế", Desc = "Trà sữa truyền thống, macchiato, cacao, cà phê pha máy" },
        new { Id = 3, Name = "Ăn Vặt Hot Trend (Nóng/Chiên)", Desc = "Mẹt ăn vặt, cá viên chiên, khoai tây lắc, nem chua rán, gà rán" },
        new { Id = 4, Name = "Khô Đóng Gói & Đồ Nhắm Chill", Desc = "Khô gà lá chanh, khô bò, khô mực, cơm cháy chà bông" },
        new { Id = 5, Name = "Topping & Trái Cây Thêm", Desc = "Trân châu đen/trắng, thạch dừa, khúc bạch, pudding, sương sáo" },
        new { Id = 6, Name = "Bánh Tráng & Món Ăn Vặt Sài Gòn", Desc = "Bánh tráng trộn, bánh tráng cuộn, bánh tráng phơi sương, xì xì" },
        new { Id = 7, Name = "Nước Ngọt & Nước Giải Khát Lon/Chai", Desc = "Nước có gas, nước tăng lực, trà xanh đóng chai, nước suối" },
        new { Id = 8, Name = "Kem & Đồ Lạnh Giải Nhiệt", Desc = "Kem que, kem ốc quế, đá bào tuyết, kem hộp các loại" },
        new { Id = 9, Name = "Mì Ăn Liền & Đồ Đóng Hộp Nhanh", Desc = "Mì ly, mì trộn Hàn Quốc, xúc xích ăn liền, phô mai que" },
        new { Id = 10, Name = "Bánh Kẹo Tạp Hóa & Snack Import", Desc = "Snack khoai tây, bánh quy, kẹo dẻo, kẹo ngậm thanh mát" },
        new { Id = 11, Name = "Sữa & Sản Phẩm Từ Sữa", Desc = "Sữa tươi đóng hộp, sữa chua ăn/uống, phô mai con bò cười" },
        new { Id = 12, Name = "Hạt Dinh Dưỡng & Đồ Ăn Kiêng", Desc = "Hạt hướng dương, hạt điều, hạt macca, ngũ cốc granola" },
        new { Id = 13, Name = "Gia Vị & Nước Chấm Ăn Vặt", Desc = "Tương ớt, sốt mayonaise, muối tôm Tây Ninh, sốt me, sa tế" },
        new { Id = 14, Name = "Văn Phòng Phẩm & Đồ Dùng Học Sinh", Desc = "Bút highlight, sổ tay Chill Store, khẩu trang, phụ kiện xinh" },
        new { Id = 15, Name = "Hóa Mỹ Phẩm & Đồ Tiện Lợi Cá Nhân", Desc = "Khăn giấy khô/ướt, xịt thơm miệng, nước rửa tay khô" }
    };

    foreach (var item in sampleCategories)
    {
        var existing = db.Categories.Find(item.Id);
        if (existing != null)
        {
            existing.CategoryName = item.Name;
            existing.Description = item.Desc;
        }
    }
    db.SaveChanges();

    // 6. Đồng bộ 30 Sản phẩm chuẩn kết nối với 15 Nhóm hàng (Mỗi nhóm hàng 2 sản phẩm)
    var sampleProducts = new[]
    {
        // Category 1: Trà Chanh & Trà Trái Cây
        new { Id = 1, Barcode = "8931111001011", Name = "Trà Chanh Giã Tay Quảng Đông", Price = 20000m, Stock = 100, CatId = 1 },
        new { Id = 2, Barcode = "8931111001028", Name = "Trà Đào Cam Sả Chill", Price = 25000m, Stock = 120, CatId = 1 },

        // Category 2: Trà Sữa & Đồ Uống Pha Chế
        new { Id = 3, Barcode = "8931111002011", Name = "Trà Sữa Trân Châu Đường Đen", Price = 30000m, Stock = 150, CatId = 2 },
        new { Id = 4, Barcode = "8931111002028", Name = "Trà Ô Long Macchiato", Price = 32000m, Stock = 80, CatId = 2 },

        // Category 3: Ăn Vặt Hot Trend (Nóng/Chiên)
        new { Id = 5, Barcode = "8931111003011", Name = "Mẹt Ăn Vặt Thập Cẩm Khổng Lồ", Price = 65000m, Stock = 50, CatId = 3 },
        new { Id = 6, Barcode = "8931111003028", Name = "Nem Chua Rán Hà Nội (10 Cái)", Price = 40000m, Stock = 70, CatId = 3 },

        // Category 4: Khô Đóng Gói & Đồ Nhắm Chill
        new { Id = 7, Barcode = "8931111004011", Name = "Khô Gà Lá Chanh Hũ 250g", Price = 45000m, Stock = 85, CatId = 4 },
        new { Id = 8, Barcode = "8931111004028", Name = "Khô Bò Miếng Thượng Hạng 200g", Price = 85000m, Stock = 60, CatId = 4 },

        // Category 5: Topping & Trái Cây Thêm
        new { Id = 9, Barcode = "8931111005011", Name = "Topping Trân Châu Ô Long Đen", Price = 5000m, Stock = 200, CatId = 5 },
        new { Id = 10, Barcode = "8931111005028", Name = "Topping Pudding Phô Mai Trứng", Price = 8000m, Stock = 150, CatId = 5 },

        // Category 6: Bánh Tráng & Món Ăn Vặt Sài Gòn
        new { Id = 11, Barcode = "8931111006011", Name = "Bánh Tráng Trộn Sài Gòn Đặc Biệt", Price = 20000m, Stock = 110, CatId = 6 },
        new { Id = 12, Barcode = "8931111006028", Name = "Bánh Tráng Cuộn Bơ Sốt Me Cay", Price = 22000m, Stock = 95, CatId = 6 },

        // Category 7: Nước Ngọt & Nước Giải Khát Lon/Chai
        new { Id = 13, Barcode = "8931111007011", Name = "Nước Ngọt Coca Cola Lon 320ml", Price = 12000m, Stock = 180, CatId = 7 },
        new { Id = 14, Barcode = "8931111007028", Name = "Trà Xanh Không Độ Chai 455ml", Price = 10000m, Stock = 160, CatId = 7 },

        // Category 8: Kem & Đồ Lạnh Giải Nhiệt
        new { Id = 15, Barcode = "8931111008011", Name = "Kem Ốc Quế Cornetto Socola", Price = 18000m, Stock = 90, CatId = 8 },
        new { Id = 16, Barcode = "8931111008028", Name = "Kem Hộp Merino Dâu Vani 400ml", Price = 35000m, Stock = 65, CatId = 8 },

        // Category 9: Mì Ăn Liền & Đồ Đóng Hộp Nhanh
        new { Id = 17, Barcode = "8931111009011", Name = "Mì Trộn Samyang Phô Mai Hàn Quốc", Price = 28000m, Stock = 130, CatId = 9 },
        new { Id = 18, Barcode = "8931111009028", Name = "Xúc Xích Tiệt Trùng CP Heo 4 Cây", Price = 16000m, Stock = 140, CatId = 9 },

        // Category 10: Bánh Kẹo Tạp Hóa & Snack Import
        new { Id = 19, Barcode = "8931111010011", Name = "Snack Khoai Tây Lay's Tự Nhiên 95g", Price = 22000m, Stock = 105, CatId = 10 },
        new { Id = 20, Barcode = "8931111010028", Name = "Kẹo Dẻo Chupa Chups Trái Cây 90g", Price = 15000m, Stock = 115, CatId = 10 },

        // Category 11: Sữa & Sản Phẩm Từ Sữa
        new { Id = 21, Barcode = "8931111011011", Name = "Sữa Tươi Tiệt Trùng Vinamilk 1 Lít", Price = 36000m, Stock = 75, CatId = 11 },
        new { Id = 22, Barcode = "8931111011028", Name = "Sữa Chua Ăn Vinamilk Có Đường (Vỉ 4)", Price = 28000m, Stock = 80, CatId = 11 },

        // Category 12: Hạt Dinh Dưỡng & Đồ Ăn Kiêng
        new { Id = 23, Barcode = "8931111012011", Name = "Hạt Điều Rang Muối Vỏ Lụa 200g", Price = 55000m, Stock = 60, CatId = 12 },
        new { Id = 24, Barcode = "8931111012028", Name = "Ngũ Cốc Ăn Kiêng Granola Mật Ong 250g", Price = 68000m, Stock = 50, CatId = 12 },

        // Category 13: Gia Vị & Nước Chấm Ăn Vặt
        new { Id = 25, Barcode = "8931111013011", Name = "Tương Ớt Chin-Su Chai 250g", Price = 14000m, Stock = 120, CatId = 13 },
        new { Id = 26, Barcode = "8931111013028", Name = "Muối Tôm Tây Ninh Đặc Biệt Hũ 150g", Price = 18000m, Stock = 95, CatId = 13 },

        // Category 14: Văn Phòng Phẩm & Đồ Dùng Học Sinh
        new { Id = 27, Barcode = "8931111014011", Name = "Sổ Tay Bìa Cứng MiniMart A5 160 Trang", Price = 25000m, Stock = 85, CatId = 14 },
        new { Id = 28, Barcode = "8931111014028", Name = "Bộ Bút Highlight Pastel 6 Màu Dạ Quang", Price = 32000m, Stock = 70, CatId = 14 },

        // Category 15: Hóa Mỹ Phẩm & Đồ Tiện Lợi Cá Nhân
        new { Id = 29, Barcode = "8931111015011", Name = "Khăn Ướt Kháng Khuẩn Bỏ Túi 20 Tờ", Price = 12000m, Stock = 150, CatId = 15 },
        new { Id = 30, Barcode = "8931111015028", Name = "Chai Nước Rửa Tay Khô Diệt Khuẩn 100ml", Price = 25000m, Stock = 90, CatId = 15 }
    };

    foreach (var p in sampleProducts)
    {
        var existingProd = db.Products.FirstOrDefault(prod => prod.ProductId == p.Id || prod.Barcode == p.Barcode);
        if (existingProd != null)
        {
            existingProd.Barcode = p.Barcode;
            existingProd.ProductName = p.Name;
            existingProd.Price = p.Price;
            existingProd.StockQuantity = p.Stock;
            existingProd.CategoryId = p.CatId;
        }
        else
        {
            db.Products.Add(new MiniSupermarket.API.Models.Product
            {
                Barcode = p.Barcode,
                ProductName = p.Name,
                Price = p.Price,
                StockQuantity = p.Stock,
                CategoryId = p.CatId
            });
        }
    }
    db.SaveChanges();
}

app.Run();