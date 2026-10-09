using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
        // Username được lưu để hiển thị thông tin người dùng trên Header
        public static string CurrentUsername { get; set; } = string.Empty;
    }

    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7099/api/")  // nhớ chỉnh port phù hợp
        };

        // Public accessor for HttpClient so forms can call API (and attach token when needed)
        public static HttpClient Client => _client;

        // Hàm gọi API đăng nhập lấy Token
        // Returns (success, errorMessage). On success JwtToken and CurrentRole are set.
        public static async Task<(bool Success, string? ErrorMessage)> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);
                SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                return (true, null);
            }

            // try to read error details from server
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
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            var response = await _client.GetAsync(endpoint);

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
