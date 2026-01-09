# 🎬 Chanaphonflix - ร้านขายบัญชีสตรีมมิ่งคุณภาพ

เว็บไซต์ E-commerce สำหรับขายบัญชีสตรีมมิ่ง Netflix, YouTube Premium, Disney+, HBO, VIU, iQIYI และ BeinSports

## ✨ คุณสมบัติหลัก

- 🛒 **Product Showcase** - แสดงสินค้าแบบ Card พร้อม Blur Effect และ Gradient
- 💰 **ระบบแสดงราคา** - ราคาเต็มและราคาส่วนลด
- 📦 **Stock Management** - แสดงสถานะสินค้าคงเหลือแบบเรียลไทม์
- 🔍 **Product Details Modal** - แสดงรายละเอียดสินค้าครบถ้วน
- 📋 **Terms of Service** - เงื่อนไขการใช้บริการแบบ Modal
- 📱 **Responsive Design** - รองรับทุกขนาดหน้าจอ
- 🎨 **Modern UI/UX** - ใช้ Google Font Sarabun, Gradient Effects, Blur Backdrop

## 🛠️ เทคโนโลยีที่ใช้

- **Backend:** ASP.NET Core 8.0 MVC
- **Frontend:** HTML5, CSS3, JavaScript
- **CSS Framework:** Bootstrap 5
- **Font:** Google Font Sarabun
- **Icons:** Emoji

## 📦 สินค้าที่มีในระบบ

1. **Netflix 4K** - รายวัน/รายเดือน (7-179 บาท)
2. **YouTube Premium** - รายเดือน (89 บาท)
3. **Disney+** - รายเดือน (69 บาท)
4. **HBO GO** - รายเดือน (129 บาท)
5. **VIU Premium** - รายเดือน (49 บาท)
6. **iQIYI VIP** - รายเดือน (69 บาท)
7. **BeinSports** - รายเดือน (89 บาท)

## 🚀 วิธีการติดตั้งและรัน

### ความต้องการของระบบ
- .NET 8.0 SDK หรือสูงกว่า
- Git

### ขั้นตอนการติดตั้ง

1. Clone repository
```bash
git clone https://github.com/yourusername/Chanaphonflix.git
cd Chanaphonflix
```

2. Restore dependencies
```bash
dotnet restore
```

3. Build project
```bash
dotnet build
```

4. Run application
```bash
cd Chanaphonflix
dotnet run
```

5. เปิดเว็บเบราว์เซอร์ไปที่
```
https://localhost:5001
หรือ
http://localhost:5000
```

## 📁 โครงสร้างโปรเจกต์

```
Chanaphonflix/
├── Controllers/
│   └── HomeController.cs          # Controller หลักพร้อมข้อมูลสินค้า
├── Models/
│   ├── StreamingProduct.cs        # Model สินค้า
│   └── ErrorViewModel.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml           # หน้าหลักแสดงสินค้า
│   └── Shared/
│       └── _Layout.cshtml          # Layout หลัก + Modals
├── wwwroot/
│   ├── css/
│   │   └── site.css               # Custom CSS
│   ├── js/
│   │   └── site.js
│   └── lib/                       # Bootstrap, jQuery
└── Program.cs                      # Entry point
```

## 🎨 Design Features

- **Color Scheme:** Dark theme พื้นหลังไล่เฉดสี
- **Primary Color:** Gradient แดง-ส้ม (#ff6b6b - #ff8e53)
- **Typography:** Google Font Sarabun
- **Effects:** Backdrop blur, Box shadows, Hover animations
- **Badges:** สีต่างกันตามประเภท (รายวัน/รายเดือน, จอส่วนตัว/จอแชร์)

## 📞 ช่องทางติดต่อ

- **Line:** @chanaphonflix
- **เวลาทำการ:**
  - จันทร์ - ศุกร์: 12:00 - 22:00 น.
  - เสาร์ - อาทิตย์: 10:00 - 22:00 น.

## 📝 License

This project is licensed under the MIT License.

## 👨‍💻 Developer

สร้างด้วย ❤️ โดย Claude & Chanaphonflix Team

---

**Note:** นี่เป็นเว็บไซต์ Demo สำหรับการเรียนรู้และฝึกฝน ASP.NET Core MVC
