/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Ngày tạo: 15/09/2026
 * Mô tả: BUỔI 5 - TIẾT 5: DTO yêu cầu và phản hồi cho API thanh toán POS
 */
using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Models
{
    // Chi tiết từng món hàng trong giỏ hàng thanh toán
    public class CartItemCheckoutDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng mua phải lớn hơn 0!")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá không thể âm!")]
        public decimal UnitPrice { get; set; }
    }

    // Yêu cầu thanh toán toàn bộ giỏ hàng từ máy POS
    public class CheckoutRequestDto
    {
        [Required(ErrorMessage = "Thiếu tên tài khoản nhân viên thu ngân!")]
        public string CashierUsername { get; set; } = string.Empty;

        // Khách hàng có thể null nếu là khách vãng lai
        public int? CustomerId { get; set; }

        [Required(ErrorMessage = "Giỏ hàng không được để trống!")]
        [MinLength(1, ErrorMessage = "Giỏ hàng phải có ít nhất 1 sản phẩm!")]
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }

    // Phản hồi thanh toán sau khi hoàn tất giao dịch
    public class CheckoutResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public int TotalItems { get; set; }
        public decimal FinalAmount { get; set; }
        public int RewardPointsAdded { get; set; }
    }
}
