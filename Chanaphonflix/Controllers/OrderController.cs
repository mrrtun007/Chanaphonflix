using Chanaphonflix.Models;
using Chanaphonflix.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chanaphonflix.Controllers;

[Authorize]
public class OrderController : Controller
{
    private readonly BYShopApiService _byshopApi;
    private readonly ILogger<OrderController> _logger;

    public OrderController(BYShopApiService byshopApi, ILogger<OrderController> logger)
    {
        _byshopApi = byshopApi;
        _logger = logger;
    }

    // GET: Order/Buy/5
    [HttpGet]
    public async Task<IActionResult> Buy(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Product ID is required");
        }

        // ดึงข้อมูลสินค้าจาก API
        var product = await _byshopApi.GetProductByIdAsync(id);

        if (product == null)
        {
            TempData["ErrorMessage"] = "ไม่พบสินค้าที่ต้องการ";
            return RedirectToAction("Index", "Home");
        }

        // ส่งข้อมูลสินค้าไปยัง View
        ViewBag.Product = product;
        ViewBag.ProductId = id;

        return View();
    }

    // POST: Order/Confirm
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Confirm(string productId, string customerInfo)
    {
        if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(customerInfo))
        {
            TempData["ErrorMessage"] = "กรุณากรอกข้อมูลให้ครบถ้วน";
            return RedirectToAction("Buy", new { id = productId });
        }

        try
        {
            // ดึงชื่อ user ที่ login
            var customerName = User.Identity?.Name ?? "Guest";

            // เรียก API สั่งซื้อ
            var result = await _byshopApi.BuyProductAsync(productId, customerName, customerInfo);

            if (result?.status == "success")
            {
                // บันทึกข้อมูลการสั่งซื้อลง TempData
                TempData["SuccessMessage"] = "สั่งซื้อสำเร็จ!";
                TempData["OrderData"] = System.Text.Json.JsonSerializer.Serialize(result.data);

                return RedirectToAction("Success");
            }
            else
            {
                TempData["ErrorMessage"] = result?.message ?? "เกิดข้อผิดพลาดในการสั่งซื้อ กรุณาลองใหม่อีกครั้ง";
                return RedirectToAction("Buy", new { id = productId });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during purchase");
            TempData["ErrorMessage"] = "เกิดข้อผิดพลาดในระบบ กรุณาติดต่อผู้ดูแลระบบ";
            return RedirectToAction("Buy", new { id = productId });
        }
    }

    // GET: Order/Success
    public IActionResult Success()
    {
        if (TempData["OrderData"] == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var orderDataJson = TempData["OrderData"]?.ToString();
        if (string.IsNullOrEmpty(orderDataJson))
        {
            return RedirectToAction("Index", "Home");
        }

        var orderData = System.Text.Json.JsonSerializer.Deserialize<BYShopBuyData>(orderDataJson);
        return View(orderData);
    }

    // GET: Order/History
    public async Task<IActionResult> History()
    {
        try
        {
            // ดึงประวัติการซื้อจาก API
            var history = await _byshopApi.GetPurchaseHistoryAsync();

            return View(history);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching purchase history");
            TempData["ErrorMessage"] = "ไม่สามารถดึงประวัติการสั่งซื้อได้";
            return View(new List<BYShopHistoryData>());
        }
    }
}
