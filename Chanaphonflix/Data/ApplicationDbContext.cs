using Chanaphonflix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chanaphonflix.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<StreamingProduct> StreamingProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed StreamingProduct data
        builder.Entity<StreamingProduct>().HasData(
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
                ImageUrl = "/images/bein.png",
                IsPopular = false
            }
        );
    }
}
