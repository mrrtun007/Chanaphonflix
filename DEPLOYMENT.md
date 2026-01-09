# 🚀 คู่มือการ Deploy Chanaphonflix

เอกสารนี้อธิบายวิธีการ Deploy เว็บไซต์ Chanaphonflix ไปยัง Platform ต่างๆ

---

## 📋 ข้อกำหนดก่อน Deploy

- บัญชี GitHub (สำหรับเก็บโค้ด)
- โค้ดถูก Push ไปยัง GitHub Repository แล้ว
- Git ติดตั้งในเครื่อง

---

## 🌐 Platform สำหรับ Deploy (เลือก 1 อย่าง)

### ⭐ ตัวเลือก 1: Railway (แนะนำ - ง่ายที่สุด)

**ข้อดี:**
- Setup ง่าย 5 นาที
- Deploy อัตโนมัติจาก GitHub
- ฟรี $5 credit/เดือน
- รองรับ .NET 8

**ขั้นตอน:**

1. **สมัครและเชื่อมต่อ GitHub:**
   - ไปที่ https://railway.app
   - คลิก "Login with GitHub"
   - อนุญาตให้ Railway เข้าถึง GitHub

2. **สร้าง Project ใหม่:**
   - คลิก "New Project"
   - เลือก "Deploy from GitHub repo"
   - เลือก repository: `Chanaphonflix`

3. **Railway จะ Deploy อัตโนมัติ:**
   - ตรวจจับ .NET project
   - Build และ Deploy
   - ใช้เวลาประมาณ 2-3 นาที

4. **เปิดเว็บไซต์:**
   - คลิกที่ Service
   - ไปที่ "Settings" → "Generate Domain"
   - จะได้ URL แบบ: `chanaphonflix.up.railway.app`

**ตั้งค่า Environment Variables (ถ้าจำเป็น):**
```
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:8080
```

---

### ☁️ ตัวเลือก 2: Azure App Service (Professional)

**ข้อดี:**
- Performance ดีที่สุด
- รองรับ .NET อย่างเต็มรูปแบบ
- ฟรี 60 วัน ($200 credit)
- Scaling ได้ดี

**ขั้นตอน:**

1. **สร้าง Azure Account:**
   - ไปที่ https://portal.azure.com
   - สมัครใหม่ (ฟรี 60 วัน)

2. **สร้าง App Service:**
   - คลิก "Create a resource"
   - เลือก "Web App"
   - ตั้งค่า:
     - **Name:** chanaphonflix
     - **Runtime stack:** .NET 8 (LTS)
     - **Operating System:** Linux
     - **Region:** Southeast Asia (ถ้ามี) หรือ East Asia
     - **Pricing:** Free F1

3. **Deploy จาก GitHub:**
   - ไปที่ "Deployment Center"
   - เลือก "GitHub"
   - เชื่อมต่อและเลือก repository
   - เลือก branch: `main`
   - Azure จะ Deploy อัตโนมัติ

4. **URL:** `chanaphonflix.azurewebsites.net`

**หรือ Deploy ด้วย Azure CLI:**
```bash
# Login to Azure
az login

# Create resource group
az group create --name ChanaphonflixRG --location southeastasia

# Create App Service plan
az appservice plan create --name ChanaphonflixPlan --resource-group ChanaphonflixRG --sku F1 --is-linux

# Create web app
az webapp create --resource-group ChanaphonflixRG --plan ChanaphonflixPlan --name chanaphonflix --runtime "DOTNET|8.0"

# Deploy from GitHub
az webapp deployment source config --name chanaphonflix --resource-group ChanaphonflixRG --repo-url https://github.com/YOUR_USERNAME/Chanaphonflix --branch main --manual-integration
```

---

### 🆓 ตัวเลือก 3: Render (ฟรีตลอดไป)

**ข้อดี:**
- ฟรี 100% (มีข้อจำกัดเล็กน้อย)
- Deploy จาก GitHub อัตโนมัติ
- รองรับ Docker

**ข้อจำกัด:**
- Sleep หลัง 15 นาทีไม่มีการใช้งาน
- Startup ช้า (cold start ~30 วินาที)

**ขั้นตอน:**

1. **สมัครและเชื่อมต่อ:**
   - ไปที่ https://render.com
   - คลิก "Get Started for Free"
   - Login ด้วย GitHub

2. **สร้าง Web Service:**
   - คลิก "New" → "Web Service"
   - เลือก repository: `Chanaphonflix`
   - ตั้งค่า:
     - **Name:** chanaphonflix
     - **Environment:** Docker
     - **Region:** Singapore (ใกล้ไทยที่สุด)
     - **Instance Type:** Free

3. **ตั้งค่า Build:**
   - Render จะใช้ Dockerfile อัตโนมัติ
   - ไม่ต้องตั้งค่าเพิ่มเติม

4. **Deploy:**
   - คลิก "Create Web Service"
   - รอ build 5-10 นาที

5. **URL:** `chanaphonflix.onrender.com`

---

### 🐳 ตัวเลือก 4: DigitalOcean App Platform

**ข้อดี:**
- ฟรี Static Site
- $5/เดือน สำหรับ Web Service
- Performance ดี

**ขั้นตอน:**

1. ไปที่ https://cloud.digitalocean.com
2. สร้าง App
3. เชื่อมต่อ GitHub repository
4. เลือก plan ($5/เดือน)
5. Deploy

---

## 🔧 การตั้งค่า Production

### 1. Environment Variables ที่ควรตั้ง

```bash
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:8080
ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
```

### 2. appsettings.Production.json (สร้างใหม่ถ้าต้องการ)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 3. เปิด HTTPS Redirect

แก้ไข `Program.cs` (เราทำแล้ว):
```csharp
app.UseHttpsRedirection();
app.UseHsts();
```

---

## 📝 Checklist ก่อน Deploy

- ✅ โค้ดผ่าน Build สำเร็จ (`dotnet build`)
- ✅ Push โค้ดขึ้น GitHub แล้ว
- ✅ มี Dockerfile และ .dockerignore
- ✅ ตรวจสอบ .gitignore (ไม่ commit bin/, obj/)
- ✅ ไม่มี sensitive data (password, API keys) ใน code
- ✅ README.md มีคำอธิบายโปรเจกต์

---

## 🛠️ การแก้ปัญหา

### ปัญหา: Build ล้มเหลว
**แก้ไข:** ตรวจสอบว่ามี .NET 8 SDK

### ปัญหา: Web ไม่แสดงผล
**แก้ไข:** ตรวจสอบ PORT environment variable

### ปัญหา: CSS/JS ไม่โหลด
**แก้ไข:** ตรวจสอบ `app.UseStaticFiles()` ใน Program.cs

---

## 📊 เปรียบเทียบ Platform

| Platform | ราคา | Performance | Setup | Deploy Time |
|----------|------|-------------|-------|-------------|
| Railway | ฟรี $5/เดือน | ⭐⭐⭐⭐ | 5 นาที | 2-3 นาที |
| Azure | ฟรี 60 วัน | ⭐⭐⭐⭐⭐ | 15 นาที | 5-10 นาที |
| Render | ฟรี (มีข้อจำกัด) | ⭐⭐⭐ | 10 นาที | 5-10 นาที |
| DigitalOcean | $5/เดือน | ⭐⭐⭐⭐ | 10 นาที | 5-8 นาที |

---

## 🎯 คำแนะนำ

- **เริ่มต้น:** ใช้ Railway (ง่าย ฟรี ดี)
- **Production จริง:** ใช้ Azure App Service
- **ฟรีถาวร:** ใช้ Render (ยอมรับ cold start)

---

## 📞 ติดปัญหา?

ถ้ามีปัญหาในการ Deploy สามารถ:
1. เช็ค Logs ใน Platform
2. ดู GitHub Issues
3. อ่าน Documentation ของแต่ละ Platform

**Happy Deploying! 🚀**
