-- ==============================================================
-- BUỔI 5: TẠO BẢNG Orders, OrderDetails, 15 HÓA ĐƠN MẪU VÀ STORED PROCEDURES
-- Sinh viên: Nguyễn Thị Thúy Nga - MSSV: 2124110081 - Lớp: CCQ2411C
-- ==============================================================

USE MiniSupermarketDb;
GO

-- 0. TẠO BẢNG Users NẾU CHƯA CÓ
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(100) NOT NULL,
        FullName NVARCHAR(100) NOT NULL,
        Role NVARCHAR(30) NOT NULL,
        IsActive BIT NOT NULL DEFAULT 1
    );

    SET IDENTITY_INSERT dbo.Users ON;
    INSERT INTO dbo.Users (Id, Username, Password, FullName, Role, IsActive) VALUES
    (1, N'admin01', N'123456', N'Nguyễn Quản Trị', N'Admin', 1),
    (2, N'admin02', N'123456', N'Trần Giám Đốc', N'Admin', 1),
    (3, N'cashier01', N'123456', N'Lê Thu Ngân', N'Cashier', 1),
    (4, N'cashier02', N'123456', N'Phạm Bán Hàng', N'Cashier', 1),
    (5, N'cashier03', N'123456', N'Hoàng Thu Ngân', N'Cashier', 1),
    (6, N'cashier04', N'123456', N'Vũ Thị Quầy', N'Cashier', 1),
    (7, N'cashier05', N'123456', N'Đỗ Bán Lẻ', N'Cashier', 1),
    (8, N'ware01', N'123456', N'Ngô Quản Kho', N'Warehouse', 1),
    (9, N'ware02', N'123456', N'Bùi Kiểm Kê', N'Warehouse', 1),
    (10, N'ware03', N'123456', N'Dương Thủ Kho', N'Warehouse', 1),
    (11, N'ware04', N'123456', N'Lý Nhập Hàng', N'Warehouse', 1),
    (12, N'admin_backup', N'123456', N'Đặng Hỗ Trợ', N'Admin', 1),
    (13, N'cashier06', N'123456', N'Hồ Ca Chiều', N'Cashier', 1),
    (14, N'ware05', N'123456', N'Trương Vận Chuyển', N'Warehouse', 1),
    (15, N'supervisor', N'123456', N'Mai Giám Sát', N'Admin', 1),
    (16, N'admin', N'123456', N'Administrator', N'Admin', 1),
    (17, N'cashier', N'123456', N'Thu Ngân Viên', N'Cashier', 1),
    (18, N'warehouse', N'123456', N'Thủ Kho Viên', N'Warehouse', 1);
    SET IDENTITY_INSERT dbo.Users OFF;
END;
GO

-- 1. TẠO BẢNG Orders NẾU CHƯA CÓ
IF OBJECT_ID('dbo.Orders', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Orders (
        OrderId INT IDENTITY(1,1) PRIMARY KEY,
        OrderCode VARCHAR(30) NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        CashierUsername VARCHAR(50) NOT NULL,
        CustomerId INT NULL,
        TotalItems INT NOT NULL,
        FinalAmount DECIMAL(18,2) NOT NULL,
        RewardPoints INT NOT NULL DEFAULT 0
    );
END;
GO

-- 2. TẠO BẢNG OrderDetails NẾU CHƯA CÓ
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.OrderDetails (
        OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
        OrderId INT NOT NULL FOREIGN KEY REFERENCES dbo.Orders(OrderId),
        ProductId INT NOT NULL FOREIGN KEY REFERENCES dbo.Products(ProductId),
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(18,2) NOT NULL,
        LineTotal DECIMAL(18,2) NOT NULL
    );
END;
GO

-- 3. SEED 15 HÓA ĐƠN MẪU KHỚP VỚI SỐ LIỆU BÁO CÁO TIẾT 3
-- Tổng số: 15 đơn, 5 thu ngân, tổng doanh thu = 4,822,000 đ
IF NOT EXISTS (SELECT 1 FROM dbo.Orders)
BEGIN
    SET IDENTITY_INSERT dbo.Orders ON;

    -- cashier03: 2 đơn | 1,435,000 đ | 143 điểm
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
    VALUES 
    (1, 'HD-20260915-0001', '2026-09-15 08:15:00', 'cashier03', 1, 8, 850000.00, 85),
    (2, 'HD-20260915-0002', '2026-09-15 09:30:00', 'cashier03', 2, 6, 585000.00, 58);

    -- cashier05: 3 đơn | 1,328,000 đ | 132 điểm
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
    VALUES 
    (3, 'HD-20260915-0003', '2026-09-15 10:00:00', 'cashier05', 3, 5, 450000.00, 45),
    (4, 'HD-20260915-0004', '2026-09-15 11:15:00', 'cashier05', 4, 7, 520000.00, 52),
    (5, 'HD-20260915-0005', '2026-09-15 12:45:00', 'cashier05', 5, 4, 358000.00, 35);

    -- cashier01: 4 đơn | 1,322,000 đ | 131 điểm
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
    VALUES 
    (6, 'HD-20260915-0006', '2026-09-15 13:20:00', 'cashier01', 6, 3, 280000.00, 28),
    (7, 'HD-20260915-0007', '2026-09-15 14:10:00', 'cashier01', 7, 5, 395000.00, 39),
    (8, 'HD-20260915-0008', '2026-09-15 15:00:00', 'cashier01', 8, 4, 347000.00, 34),
    (9, 'HD-20260915-0009', '2026-09-15 15:45:00', 'cashier01', 9, 3, 300000.00, 30);

    -- cashier04: 3 đơn | 484,000 đ | 48 điểm
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
    VALUES 
    (10, 'HD-20260915-0010', '2026-09-15 16:30:00', 'cashier04', 10, 2, 160000.00, 16),
    (11, 'HD-20260915-0011', '2026-09-15 17:15:00', 'cashier04', 11, 2, 154000.00, 15),
    (12, 'HD-20260915-0012', '2026-09-15 18:00:00', 'cashier04', 12, 2, 170000.00, 17);

    -- cashier02: 3 đơn | 253,000 đ | 24 điểm
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
    VALUES 
    (13, 'HD-20260915-0013', '2026-09-15 18:45:00', 'cashier02', 13, 1, 85000.00, 8),
    (14, 'HD-20260915-0014', '2026-09-15 19:30:00', 'cashier02', 14, 1, 78000.00, 7),
    (15, 'HD-20260915-0015', '2026-09-15 20:15:00', 'cashier02', 15, 1, 90000.00, 9);

    SET IDENTITY_INSERT dbo.Orders OFF;

    -- Thêm chi tiết mẫu cho bảng OrderDetails
    INSERT INTO dbo.OrderDetails (OrderId, ProductId, Quantity, UnitPrice, LineTotal)
    VALUES 
    (1, 1, 4, 20000, 80000),
    (1, 8, 9, 85000, 765000),
    (2, 4, 10, 32000, 320000),
    (2, 7, 5, 45000, 225000),
    (3, 5, 5, 65000, 325000),
    (4, 3, 10, 30000, 300000),
    (5, 6, 8, 40000, 32000),
    (6, 11, 10, 20000, 200000),
    (7, 13, 20, 12000, 240000),
    (8, 15, 15, 18000, 270000),
    (9, 17, 10, 28000, 280000),
    (10, 2, 4, 25000, 100000),
    (11, 21, 4, 36000, 144000),
    (12, 23, 3, 55000, 165000),
    (13, 8, 1, 85000, 85000),
    (14, 17, 2, 35000, 70000),
    (15, 15, 5, 18000, 90000);
END;
GO

-- 4. TẠO STORED PROCEDURE CHÍNH: sp_GetRevenueByCashier (TIẾT 3)
IF OBJECT_ID('sp_GetRevenueByCashier', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByCashier;
GO

CREATE PROCEDURE sp_GetRevenueByCashier
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END;
GO

-- 5. TẠO STORED PROCEDURE MỞ RỘNG 3.1: sp_GetRevenueByDateRange
IF OBJECT_ID('sp_GetRevenueByDateRange', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByDateRange;
GO

CREATE PROCEDURE sp_GetRevenueByDateRange
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    WHERE CreatedDate >= @FromDate AND CreatedDate <= @ToDate
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END;
GO

-- 6. TẠO STORED PROCEDURE MỞ RỘNG 3.2: sp_GetTop5SellingProducts
IF OBJECT_ID('sp_GetTop5SellingProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTop5SellingProducts;
GO

CREATE PROCEDURE sp_GetTop5SellingProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 5
        p.ProductId,
        p.ProductName,
        p.Barcode,
        SUM(od.Quantity) AS TotalQuantitySold,
        SUM(od.LineTotal) AS TotalSalesRevenue
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductId = p.ProductId
    GROUP BY p.ProductId, p.ProductName, p.Barcode
    ORDER BY TotalQuantitySold DESC;
END;
GO
