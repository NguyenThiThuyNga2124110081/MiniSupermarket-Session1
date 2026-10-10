-- ==============================================================
-- TRUY VẤN XEM DỮ LIỆU ĐẦY ĐỦ CÁC BẢNG TRONG MINISUPERMARKETDB
-- Nhấn phím Ctrl + Shift + E hoặc nút Execute (tam giác xanh) để xem bảng
-- ==============================================================

USE MiniSupermarketDb;
GO

-- 1. BẢNG DANH MỤC NHÓM HÀNG (15 DANH MỤC)
SELECT 
    CategoryId AS [Mã ID],
    CategoryName AS [Tên Nhóm Hàng],
    Description AS [Mô Tả Nhóm Hàng]
FROM Categories
ORDER BY CategoryId;
GO

-- 2. BẢNG THÔNG TIN SẢN PHẨM (30 SẢN PHẨM LIÊN KẾT 15 DANH MỤC)
SELECT 
    p.ProductId AS [Mã SP],
    p.Barcode AS [Mã Vạch],
    p.ProductName AS [Tên Sản Phẩm],
    FORMAT(p.Price, 'N0') + N' đ' AS [Đơn Giá (VNĐ)],
    p.StockQuantity AS [Tồn Kho],
    p.CategoryId AS [Mã Danh Mục],
    c.CategoryName AS [Tên Nhóm Hàng]
FROM Products p
LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
ORDER BY p.CategoryId, p.ProductId;
GO
