/*
 * Họ tên sinh viên: Nguyễn Thị Thúy Nga
 * Mã sinh viên: 2124110081
 * Lớp: CCQ2411C
 * Mô tả: Lớp tĩnh quản lý HttpClient kết nối Web API, tự động gắn JWT Bearer Token
 */
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniSupermarket.WinForms.Services
{
    public static class ApiClientService
    {
        private static readonly HttpClientHandler _handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        // Khởi tạo một phiên bản HttpClient dùng chung cho toàn ứng dụng
        public static readonly HttpClient Client = new HttpClient(_handler)
        {
            // Đảm bảo số cổng Port trùng khớp với số Port đang chạy của Web API Backend (7099)
            BaseAddress = new Uri("https://localhost:7099/api/")
        };

        // Phương thức cập nhật Bearer Token sau khi đăng nhập thành công
        public static void AttachToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = null; // Xóa token cũ
            if (!string.IsNullOrEmpty(token))
            {
                Client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // Hàm gọi API đăng nhập lấy Token
        public static async Task<(bool Success, string? ErrorMessage)> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await Client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);
                string token = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                string role = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                SessionManager.JwtToken = token;
                SessionManager.CurrentRole = role;
                SessionManager.CurrentUsername = username;
                AttachToken(token);
                return (true, null);
            }

            string error = string.Empty;
            try
            {
                error = await response.Content.ReadAsStringAsync();
            }
            catch { }

            string message = !string.IsNullOrWhiteSpace(error) ? error : $"HTTP {(int)response.StatusCode} {response.ReasonPhrase}";
            return (false, message);
        }

        // Hàm gọi API lấy dữ liệu có gắn kèm Bearer Token bảo mật
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                AttachToken(SessionManager.JwtToken);
            }
            var response = await Client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập!");
            }
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }
    }
}
