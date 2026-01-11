using Chanaphonflix.Models;
using Chanaphonflix.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chanaphonflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BYShopApiService _byshopApi;

        public HomeController(ILogger<HomeController> logger, BYShopApiService byshopApi)
        {
            _logger = logger;
            _byshopApi = byshopApi;
        }

        public async Task<IActionResult> Index()
        {
            // ดึงสินค้าจาก BYShop API
            var byshopProducts = await _byshopApi.GetAllProductsAsync();

            // แปลงข้อมูลจาก BYShop เป็น StreamingProduct
            var products = ConvertBYShopToStreamingProducts(byshopProducts);

            // ถ้าไม่มีข้อมูลจาก API ให้ใช้ข้อมูลสำรอง
            if (!products.Any())
            {
                products = GetStreamingProducts();
            }

            return View(products);
        }

        private List<StreamingProduct> ConvertBYShopToStreamingProducts(List<BYShopProduct> byshopProducts)
        {
            var streamingProducts = new List<StreamingProduct>();

            foreach (var product in byshopProducts)
            {
                // แปลงเฉพาะสินค้า Streaming categories
                if (IsStreamingCategory(product.category))
                {
                    streamingProducts.Add(new StreamingProduct
                    {
                        Id = int.TryParse(product.id, out int id) ? id : 0,
                        ServiceName = ExtractServiceName(product.name ?? ""),
                        PackageType = ExtractPackageType(product.name ?? ""),
                        ScreenType = ExtractScreenType(product.name ?? ""),
                        Quality = ExtractQuality(product.name ?? ""),
                        OriginalPrice = decimal.TryParse(product.price, out decimal price) ? price : 0,
                        DiscountedPrice = decimal.TryParse(product.price_vip, out decimal priceVip) ? priceVip : 0,
                        Stock = int.TryParse(product.stock, out int stock) ? stock : 0,
                        Description = product.product_info ?? "",
                        Features = new List<string>(),
                        ImageUrl = product.img ?? "/images/default.png",
                        IsPopular = false
                    });
                }
            }

            return streamingProducts;
        }

        private bool IsStreamingCategory(string? category)
        {
            if (string.IsNullOrEmpty(category)) return false;

            var streamingCategories = new[] { "netflix", "youtube", "disney", "hbo", "viu", "iqiyi", "bein", "spotify", "trueid", "aisplay" };
            return streamingCategories.Any(c => category.ToLower().Contains(c));
        }

        private string ExtractServiceName(string productName)
        {
            if (productName.Contains("Netflix", StringComparison.OrdinalIgnoreCase)) return "Netflix";
            if (productName.Contains("YouTube", StringComparison.OrdinalIgnoreCase)) return "YouTube Premium";
            if (productName.Contains("Disney", StringComparison.OrdinalIgnoreCase)) return "Disney+";
            if (productName.Contains("HBO", StringComparison.OrdinalIgnoreCase)) return "HBO GO";
            if (productName.Contains("VIU", StringComparison.OrdinalIgnoreCase)) return "VIU Premium";
            if (productName.Contains("iQIYI", StringComparison.OrdinalIgnoreCase)) return "iQIYI VIP";
            if (productName.Contains("Bein", StringComparison.OrdinalIgnoreCase)) return "BeinSports";
            return productName;
        }

        private string ExtractPackageType(string productName)
        {
            if (productName.Contains("รายวัน") || productName.Contains("1 วัน")) return "รายวัน";
            if (productName.Contains("รายเดือน") || productName.Contains("1 เดือน")) return "รายเดือน";
            if (productName.Contains("รายปี") || productName.Contains("1 ปี")) return "รายปี";
            return "รายเดือน";
        }

        private string ExtractScreenType(string productName)
        {
            if (productName.Contains("จอส่วนตัว") || productName.Contains("Private")) return "จอส่วนตัว";
            if (productName.Contains("จอแชร์") || productName.Contains("Share")) return "จอแชร์";
            return "จอส่วนตัว";
        }

        private string ExtractQuality(string productName)
        {
            if (productName.Contains("4K") || productName.Contains("UHD")) return "4K UltraHD";
            if (productName.Contains("Full HD") || productName.Contains("FHD")) return "Full HD";
            if (productName.Contains("HD")) return "HD";
            return "HD";
        }

        private List<StreamingProduct> GetStreamingProducts()
        {
            return new List<StreamingProduct>
            {
                new StreamingProduct
                {
                    Id = 1,
                    ServiceName = "Netflix",
                    PackageType = "รายเดือน",
                    ScreenType = "จอส่วนตัว",
                    Quality = "4K UltraHD",
                    OriginalPrice = 199,
                    DiscountedPrice = 179,
                    Stock = 10,
                    Description = "Netflix Premium 4K บัญชีไทยแท้ 100%",
                    Features = new List<string> { "รองรับ 4K UltraHD", "พากย์ไทย/ซับไทย", "รับชมพร้อมกัน 4 จอ", "ไม่มีโฆษณา" },
                    ImageUrl = "/images/netflix.png",
                    IsPopular = true
                },
                new StreamingProduct
                {
                    Id = 2,
                    ServiceName = "Netflix",
                    PackageType = "รายวัน",
                    ScreenType = "จอส่วนตัว",
                    Quality = "4K UltraHD",
                    OriginalPrice = 10,
                    DiscountedPrice = 7,
                    Stock = 15,
                    Description = "Netflix Premium 4K รายวัน จอส่วนตัว",
                    Features = new List<string> { "รองรับ 4K UltraHD", "พากย์ไทย/ซับไทย", "จอส่วนตัว 24 ชั่วโมง" },
                    ImageUrl = "/images/netflix.png",
                    IsPopular = true
                },
                new StreamingProduct
                {
                    Id = 3,
                    ServiceName = "YouTube Premium",
                    PackageType = "รายเดือน",
                    ScreenType = "จอส่วนตัว",
                    Quality = "HD",
                    OriginalPrice = 99,
                    DiscountedPrice = 89,
                    Stock = 20,
                    Description = "YouTube Premium บัญชีไทยแท้",
                    Features = new List<string> { "ดูแบบไม่มีโฆษณา", "เล่นเพลงแบบปิดหน้าจอได้", "ดาวน์โหลดเพื่อชมออฟไลน์", "รวม YouTube Music" },
                    ImageUrl = "/images/youtube.png",
                    IsPopular = true
                },
                new StreamingProduct
                {
                    Id = 4,
                    ServiceName = "Disney+",
                    PackageType = "รายเดือน",
                    ScreenType = "จอแชร์",
                    Quality = "4K",
                    OriginalPrice = 79,
                    DiscountedPrice = 69,
                    Stock = 8,
                    Description = "Disney+ Hotstar บัญชีไทยแท้",
                    Features = new List<string> { "รองรับ 4K", "ดูคอนเทนต์ Disney, Marvel, Star Wars", "พากย์ไทย/ซับไทย" },
                    ImageUrl = "/images/disney.png",
                    IsPopular = false
                },
                new StreamingProduct
                {
                    Id = 5,
                    ServiceName = "HBO GO",
                    PackageType = "รายเดือน",
                    ScreenType = "จอส่วนตัว",
                    Quality = "HD",
                    OriginalPrice = 149,
                    DiscountedPrice = 129,
                    Stock = 5,
                    Description = "HBO GO บัญชีไทยแท้",
                    Features = new List<string> { "ซีรีส์ HBO ดังทั้งหมด", "รองรับ Full HD", "พากย์ไทย/ซับไทย" },
                    ImageUrl = "/images/hbo.png",
                    IsPopular = false
                },
                new StreamingProduct
                {
                    Id = 6,
                    ServiceName = "VIU Premium",
                    PackageType = "รายเดือน",
                    ScreenType = "จอส่วนตัว",
                    Quality = "HD",
                    OriginalPrice = 59,
                    DiscountedPrice = 49,
                    Stock = 12,
                    Description = "VIU Premium บัญชีไทยแท้",
                    Features = new List<string> { "ซีรีส์เกาหลี จีน ไทย", "ไม่มีโฆษณา", "ดูก่อนใครทั่วโลก" },
                    ImageUrl = "/images/viu.png",
                    IsPopular = false
                },
                new StreamingProduct
                {
                    Id = 7,
                    ServiceName = "iQIYI VIP",
                    PackageType = "รายเดือน",
                    ScreenType = "จอส่วนตัว",
                    Quality = "HD",
                    OriginalPrice = 79,
                    DiscountedPrice = 69,
                    Stock = 10,
                    Description = "iQIYI VIP บัญชีไทยแท้",
                    Features = new List<string> { "ซีรีส์จีน ซีรีส์เกาหลี", "ไม่มีโฆษณา", "คุณภาพ HD" },
                    ImageUrl = "/images/iqiyi.png",
                    IsPopular = false
                },
                new StreamingProduct
                {
                    Id = 8,
                    ServiceName = "BeinSports",
                    PackageType = "รายเดือน",
                    ScreenType = "จอแชร์",
                    Quality = "HD",
                    OriginalPrice = 99,
                    DiscountedPrice = 89,
                    Stock = 0,
                    Description = "BeinSports ดูกีฬาสด",
                    Features = new List<string> { "ดูฟุตบอลสด", "พรีเมียร์ลีก ลาลีกา", "คุณภาพ HD" },
                    ImageUrl = "/images/bein.png",
                    IsPopular = false
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
