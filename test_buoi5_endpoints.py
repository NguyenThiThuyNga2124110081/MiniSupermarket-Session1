import requests
import json
import sys

sys.stdout.reconfigure(encoding='utf-8')

BASE_URL = "http://localhost:5266/api"

print("=========================================================")
print("KIỂM THỬ TỔNG HỢP CÁC ENDPOINT BUỔI 5 (TIẾT 2, 3, 5)")
print("Sinh viên: NGUYỄN THỊ THÚY NGA - MSSV: 2124110081")
print("=========================================================\n")

# 1. TIẾT 2: Tra cứu barcode bằng SqlDataReader
print(">>> 1. TIẾT 2: GET /api/ado-products/barcode/8931111001011")
r = requests.get(f"{BASE_URL}/ado-products/barcode/8931111001011")
print(f"Status: {r.status_code}")
print("Response:", r.json())
assert r.status_code == 200

# 2. TIẾT 2: Tra cứu barcode không tồn tại (404)
print("\n>>> 2. TIẾT 2: GET /api/ado-products/barcode/9999999999999 (Kỳ vọng 404)")
r = requests.get(f"{BASE_URL}/ado-products/barcode/9999999999999")
print(f"Status: {r.status_code}")
print("Response:", r.json())
assert r.status_code == 404

# 3. TIẾT 2: Mô hình ngắt kết nối DataTable
print("\n>>> 3. TIẾT 2: GET /api/ado-products/disconnected-cache")
r = requests.get(f"{BASE_URL}/ado-products/disconnected-cache")
print(f"Status: {r.status_code}")
data = r.json()
print(f"TotalLoaded: {data['totalLoaded']}, CachedAt: {data['cachedAt']}")
assert r.status_code == 200
assert data['totalLoaded'] > 0

# 4. TIẾT 2 (Bài tập 2.1): Lọc theo tồn kho
print("\n>>> 4. TIẾT 2 - BÀI TẬP 2.1: GET /api/ado-products/filter-stock?minStock=60")
r = requests.get(f"{BASE_URL}/ado-products/filter-stock?minStock=60")
print(f"Status: {r.status_code}")
data = r.json()
print(f"TotalFound: {data['totalFound']}")
assert r.status_code == 200

# 5. TIẾT 2 (Bài tập 2.2): Đếm theo danh mục
print("\n>>> 5. TIẾT 2 - BÀI TẬP 2.2: GET /api/ado-products/category-count")
r = requests.get(f"{BASE_URL}/ado-products/category-count")
print(f"Status: {r.status_code}")
data = r.json()
print(f"TotalCategoriesWithProducts: {data['totalCategoriesWithProducts']}")
assert r.status_code == 200

# 6. TIẾT 3: Stored Procedure sp_GetRevenueByCashier
print("\n>>> 6. TIẾT 3: GET /api/reports/revenue-by-cashier")
r = requests.get(f"{BASE_URL}/reports/revenue-by-cashier")
print(f"Status: {r.status_code}")
data = r.json()
print(f"Success: {data['success']}, GrandTotalRevenue: {data['grandTotalRevenue']}, TotalCashiers: {data['totalCashiers']}")
for item in data['data']:
    print(f"   - {item['cashierUsername']}: {item['totalOrders']} đơn | {item['totalRevenue']:,.0f} đ | {item['totalPointsAwarded']} điểm")
assert r.status_code == 200
assert data['totalCashiers'] == 5

# 7. TIẾT 3 (Bài tập 3.1): sp_GetRevenueByDateRange
print("\n>>> 7. TIẾT 3 - BÀI TẬP 3.1: GET /api/reports/revenue-by-date-range")
r = requests.get(f"{BASE_URL}/reports/revenue-by-date-range?fromDate=2026-09-01&toDate=2026-09-30")
print(f"Status: {r.status_code}")
data = r.json()
print(f"TotalCashiers: {data['totalCashiers']}, GrandTotalRevenue: {data['grandTotalRevenue']}")
assert r.status_code == 200

# 8. TIẾT 3 (Bài tập 3.2): sp_GetTop5SellingProducts
print("\n>>> 8. TIẾT 3 - BÀI TẬP 3.2: GET /api/reports/top-selling")
r = requests.get(f"{BASE_URL}/reports/top-selling")
print(f"Status: {r.status_code}")
data = r.json()
for p in data['data']:
    print(f"   - #{p['productId']} {p['productName']}: {p['totalQuantitySold']} cái | {p['totalSalesRevenue']:,.0f} đ")
assert r.status_code == 200

# 9. TIẾT 5: Checkout thành công có Commit
print("\n>>> 9. TIẾT 5: POST /api/checkout (Giao dịch thành công - COMMIT)")
checkout_payload = {
    "cashierUsername": "cashier01",
    "customerId": 1,
    "items": [
        {"productId": 1, "quantity": 2, "unitPrice": 20000},
        {"productId": 2, "quantity": 1, "unitPrice": 25000}
    ]
}
r = requests.post(f"{BASE_URL}/checkout", json=checkout_payload)
print(f"Status: {r.status_code}")
data = r.json()
print("Response:", data)
assert r.status_code == 200
assert data['success'] == True
created_order_id = data['orderId']

# 10. TIẾT 5: Mua vượt tồn kho kích hoạt ROLLBACK
print("\n>>> 10. TIẾT 5: POST /api/checkout (Mua vượt tồn kho - KÍCH HOẠT ROLLBACK)")
insufficient_payload = {
    "cashierUsername": "cashier01",
    "customerId": 1,
    "items": [
        {"productId": 1, "quantity": 1, "unitPrice": 20000},
        {"productId": 2, "quantity": 99999, "unitPrice": 25000}
    ]
}
r = requests.post(f"{BASE_URL}/checkout", json=insufficient_payload)
print(f"Status: {r.status_code} (Kỳ vọng 400 BadRequest)")
data = r.json()
print("Response:", data)
assert r.status_code == 400
assert "không đủ tồn kho" in data.get("errorDetail", "") or "không đủ tồn kho" in data.get("message", "")

# 11. TIẾT 5 (Bài tập mở rộng): Hủy đơn hàng và hoàn trả tồn kho
print(f"\n>>> 11. TIẾT 5 - BÀI TẬP MỞ RỘNG: DELETE /api/checkout/cancel/{created_order_id}")
r = requests.delete(f"{BASE_URL}/checkout/cancel/{created_order_id}")
print(f"Status: {r.status_code}")
data = r.json()
print("Response:", data)
assert r.status_code == 200
assert data['success'] == True

print("\n=========================================================")
print(">>> TẤT CẢ 11 TEST CASES ĐỀU ĐẠT CHUẨN XUẤT SẮC 100%! <<<")
print("=========================================================")
