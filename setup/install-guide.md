# INSTALLATION GUIDE  
Hướng dẫn cài đặt hệ thống Website Mua Bán Bất Động Sản  
Sinh viên: Trần Thị Mỹ Duyên – Lớp DK24TTC2  

---

## 1. YÊU CẦU MÔI TRƯỜNG
- Windows 10  
- Microsoft SQL Server Management Studio 21 
- Visual Studio 2022  
- .NET Framework 4.8  
- Trình duyệt Chrome   

---

## 2. CÀI ĐẶT DATABASE

### 2.1. Restore file BDS.bak (khuyên dùng)
1. Mở SQL Server Management Studio  
2. Chuột phải vào **Databases → Restore Database…**  
3. Chọn **Device → Add → BDS.bak**  
4. Nhấn **OK** để restore  
5. Sau khi restore xong, database sẽ có tên: **BDS**

### 2.2. (Tùy chọn) Import database bằng script .SQL
1. Mở **New Query**  
2. Mở file: `BDS-full.sql`  
3. Nhấn **Execute** để tạo bảng + dữ liệu

---

## 3. CẤU HÌNH CONNECTION STRING
Mở file web.config:

```xml
<connectionStrings>
  <add name="WebBDS" 
       connectionString="Data Source=DESKTOP-xxx\SQLEXPRESS;Initial Catalog=BDS;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
**nhớ thay cấu hình máy tính DESKTOP-xxx