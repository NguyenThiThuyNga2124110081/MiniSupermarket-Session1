using Microsoft.AspNetCore.Mvc;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost("checkout")]
        public IActionResult Checkout([FromBody] object orderRequest)
        {
            if (orderRequest == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu đơn hàng không hợp lệ." });
            }

            return Ok(new
            {
                success = true,
                message = "Thanh toán thành công và đã in hóa đơn!",
                orderId = System.Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()
            });
        }
    }
}
