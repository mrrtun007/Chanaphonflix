using Chanaphonflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chanaphonflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = GetStreamingProducts();
            return View(products);
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
