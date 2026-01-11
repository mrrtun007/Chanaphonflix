using Chanaphonflix.Models;
using System.Text;
using System.Text.Json;

namespace Chanaphonflix.Services;

public class BYShopApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl = "https://byshop.me/api";

    public BYShopApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["BYShop:ApiKey"] ?? "";
    }

    // ดึงสินค้าทั้งหมด
    public async Task<List<BYShopProduct>> GetAllProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/product");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Log the raw JSON for debugging
            Console.WriteLine($"API Response: {content.Substring(0, Math.Min(500, content.Length))}...");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<BYShopProductResponse>(content, options);

            return result?.data ?? new List<BYShopProduct>();
        }
        catch (Exception ex)
        {
            // Log detailed error
            Console.WriteLine($"Error fetching products: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            return new List<BYShopProduct>();
        }
    }

    // ดึงสินค้าตาม Category
    public async Task<List<BYShopProduct>> GetProductsByCategoryAsync(string category)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/product?category={category}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BYShopProductResponse>(content);

            return result?.data ?? new List<BYShopProduct>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products by category: {ex.Message}");
            return new List<BYShopProduct>();
        }
    }

    // ดึงสินค้าตาม ID
    public async Task<BYShopProduct?> GetProductByIdAsync(string productId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/product?id={productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BYShopProductResponse>(content);

            return result?.data?.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching product by ID: {ex.Message}");
            return null;
        }
    }

    // เช็คยอดเงินคงเหลือ
    public async Task<decimal> GetBalanceAsync()
    {
        try
        {
            var requestData = new Dictionary<string, string>
            {
                { "keyapi", _apiKey }
            };

            var content = new FormUrlEncodedContent(requestData);
            var response = await _httpClient.PostAsync($"{_baseUrl}/money", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BYShopMoneyResponse>(responseContent);

            if (decimal.TryParse(result?.money, out decimal balance))
            {
                return balance;
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking balance: {ex.Message}");
            return 0;
        }
    }

    // สั่งซื้อสินค้า
    public async Task<BYShopBuyResponse?> BuyProductAsync(string productId, string customerName, string customerInfo)
    {
        try
        {
            var requestData = new Dictionary<string, string>
            {
                { "keyapi", _apiKey },
                { "id", productId },
                { "name", customerName },
                { "info", customerInfo }
            };

            var content = new FormUrlEncodedContent(requestData);
            var response = await _httpClient.PostAsync($"{_baseUrl}/buy", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BYShopBuyResponse>(responseContent);

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error buying product: {ex.Message}");
            return new BYShopBuyResponse
            {
                status = "error",
                message = ex.Message
            };
        }
    }

    // ดึงประวัติการซื้อ (10 รายการล่าสุด)
    public async Task<List<BYShopHistoryData>> GetPurchaseHistoryAsync()
    {
        try
        {
            var requestData = new Dictionary<string, string>
            {
                { "keyapi", _apiKey }
            };

            var content = new FormUrlEncodedContent(requestData);
            var response = await _httpClient.PostAsync($"{_baseUrl}/history", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BYShopHistoryResponse>(responseContent);

            return result?.data ?? new List<BYShopHistoryData>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching history: {ex.Message}");
            return new List<BYShopHistoryData>();
        }
    }

    // ดึงประวัติการซื้อทั้งหมด
    public async Task<List<BYShopHistoryData>> GetAllPurchaseHistoryAsync()
    {
        try
        {
            var requestData = new Dictionary<string, string>
            {
                { "keyapi", _apiKey }
            };

            var content = new FormUrlEncodedContent(requestData);
            var response = await _httpClient.PostAsync($"{_baseUrl}/history-all", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<BYShopHistoryResponse>(responseContent);

            return result?.data ?? new List<BYShopHistoryData>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching all history: {ex.Message}");
            return new List<BYShopHistoryData>();
        }
    }
}
