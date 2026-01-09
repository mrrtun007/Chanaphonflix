namespace Chanaphonflix.Models
{
    public class StreamingProduct
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string PackageType { get; set; } = string.Empty; // รายวัน, รายเดือน
        public string ScreenType { get; set; } = string.Empty; // จอส่วนตัว, จอแชร์
        public string Quality { get; set; } = string.Empty; // 4K, HD, UltraHD
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new List<string>();
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPopular { get; set; }
    }
}
