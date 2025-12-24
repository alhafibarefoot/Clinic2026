# 🔧 المشاكل الشائعة وحلولها

دليل شامل لحل المشاكل التي قد تواجهها أثناء تطوير مشروع Clinic_API.

---

## مشاكل قاعدة البيانات 🗄️

### 1. خطأ: "Cannot open database"

**الرسالة:**
```
Cannot open database "Clinic2026" requested by the login. The login failed.
```

**الأسباب المحتملة:**
- قاعدة البيانات غير موجودة
- اسم قاعدة البيانات خاطئ في Connection String
- المستخدم ليس لديه صلاحيات

**الحل:**

1. تحقق من وجود قاعدة البيانات:
```sql
SELECT name FROM sys.databases WHERE name = 'Clinic2026';
```

2. إذا لم تكن موجودة، أنشئها:
```sql
CREATE DATABASE Clinic2026;
```

3. تحقق من Connection String في `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=Clinic2026;Integrated Security=True;TrustServerCertificate=True"
}
```

---

### 2. خطأ: "Login failed for user"

**الرسالة:**
```
Login failed for user 'sa'
```

**الحل:**

**إذا كنت تستخدم SQL Authentication:**
```json
"Server=localhost;Database=Clinic2026;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
```

**إذا كنت تستخدم Windows Authentication:**
```json
"Server=localhost;Database=Clinic2026;Integrated Security=True;TrustServerCertificate=True"
```

**للتحقق من صلاحيات المستخدم:**
```sql
-- في SQL Server Management Studio
USE Clinic2026;
EXEC sp_helpuser;
```

---

### 3. خطأ: "String or binary data would be truncated"

**الرسالة:**
```
String or binary data would be truncated in table 'Clinic2026.dbo.TBL_Users', column 'UserName'. Truncated value: '...'
```

**السبب:**
البيانات المُدخلة أطول من الحد المسموح في قاعدة البيانات.

**الحل:**

**الخيار 1:** زيادة طول العمود في قاعدة البيانات:
```sql
ALTER TABLE TBL_Users
ALTER COLUMN UserName NVARCHAR(200);
```

**الخيار 2:** قص البيانات في الكود:
```csharp
user.UserName = dto.UserName.Length > 100
    ? dto.UserName.Substring(0, 100)
    : dto.UserName;
```

**الخيار 3:** إضافة Validation:
```csharp
[StringLength(100, ErrorMessage = "اسم المستخدم يجب ألا يتجاوز 100 حرف")]
public string UserName { get; set; }
```

---

### 4. خطأ: "A network-related or instance-specific error"

**الرسالة:**
```
A network-related or instance-specific error occurred while establishing a connection to SQL Server.
```

**الحل:**

1. **تحقق من تشغيل SQL Server:**
   - افتح **Services** (اضغط `Win + R` واكتب `services.msc`)
   - ابحث عن **SQL Server (MSSQLSERVER)** أو **SQL Server (SQLEXPRESS)**
   - تأكد أنها **Running**

2. **تحقق من اسم السيرفر:**
   - للـ SQL Server العادي: `localhost` أو `.`
   - للـ SQL Server Express: `.\SQLEXPRESS` أو `localhost\SQLEXPRESS`

3. **فعّل TCP/IP:**
   - افتح **SQL Server Configuration Manager**
   - اذهب إلى **SQL Server Network Configuration**
   - فعّل **TCP/IP**
   - أعد تشغيل SQL Server

---

## مشاكل Entity Framework Core ⚙️

### 5. خطأ: "No DbContext was found"

**الرسالة:**
```
No DbContext was found in assembly 'Clinic_API'
```

**السبب:**
لم يتم تسجيل DbContext في DI Container.

**الحل:**

في `Program.cs`:
```csharp
builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

### 6. خطأ: "Your target project doesn't match your migrations assembly"

**الرسالة:**
```
Your target project 'Clinic_API' doesn't match your migrations assembly 'AnotherProject'
```

**الحل:**

تأكد أنك في المجلد الصحيح:
```bash
cd Clinic_API
dotnet ef migrations add MigrationName
```

أو حدد المشروع:
```bash
dotnet ef migrations add MigrationName --project Clinic_API
```

---

### 7. خطأ: "There is already an object named 'TableName' in the database"

**الرسالة:**
```
There is already an object named 'TBL_Users' in the database
```

**السبب:**
الجدول موجود بالفعل في قاعدة البيانات.

**الحل:**

**الخيار 1:** احذف الجدول:
```sql
DROP TABLE TBL_Users;
```

**الخيار 2:** استخدم `--force` في Scaffold:
```bash
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer --force
```

**الخيار 3:** احذف Migration وأعد إنشاءه:
```bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
```

---

### 8. خطأ: "The entity type requires a primary key"

**الرسالة:**
```
The entity type 'TblUser' requires a primary key to be defined
```

**الحل:**

في DbContext:
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TblUser>(entity =>
    {
        entity.HasKey(e => e.UserName);
    });
}
```

أو في Model:
```csharp
public class TblUser
{
    [Key]
    public string UserName { get; set; }
}
```

---

## مشاكل JWT Authentication 🔐

### 9. خطأ: "401 Unauthorized"

**السبب:**
- Token غير صحيح
- Token منتهي الصلاحية
- لم يتم إضافة Token في Header

**الحل:**

1. **تحقق من Token في Swagger:**
   - اضغط **Authorize**
   - الصق Token (بدون كلمة "Bearer")

2. **تحقق من صلاحية Token:**
   - اذهب إلى [jwt.io](https://jwt.io)
   - الصق Token وتحقق من `exp` (Expiration)

3. **تحقق من Middleware Order:**
```csharp
app.UseAuthentication();  // يجب أن يكون قبل UseAuthorization
app.UseAuthorization();
```

---

### 10. خطأ: "IDX10503: Signature validation failed"

**الرسالة:**
```
IDX10503: Signature validation failed. Keys tried: 'Microsoft.IdentityModel.Tokens.SymmetricSecurityKey'
```

**السبب:**
SecretKey المستخدم في توليد Token مختلف عن المستخدم في التحقق.

**الحل:**

تأكد من استخدام نفس SecretKey في:
1. توليد Token
2. إعدادات JWT Authentication

```csharp
// يجب أن يكون نفس المفتاح في الحالتين
var secretKey = configuration["JwtSettings:SecretKey"];
```

---

### 11. خطأ: "The SecurityTokenDescriptor.Expires value is in the past"

**السبب:**
وقت انتهاء Token في الماضي.

**الحل:**

استخدم `DateTime.UtcNow`:
```csharp
expires: DateTime.UtcNow.AddMinutes(expirationMinutes)
// وليس DateTime.Now
```

---

## مشاكل Swagger 📚

### 12. Swagger لا يظهر

**الحل:**

1. **تحقق من Environment:**
```csharp
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

2. **تحقق من الرابط:**
   - `https://localhost:7001/swagger`
   - وليس `https://localhost:7001/swagger/index.html`

3. **تحقق من تثبيت الحزمة:**
```bash
dotnet add package Swashbuckle.AspNetCore
```

---

### 13. Endpoints لا تظهر في Swagger

**السبب:**
لم يتم إضافة `.WithOpenApi()` أو `.WithTags()`.

**الحل:**

```csharp
app.MapGet("/api/users", async (ClinicDbContext db) =>
{
    // ...
})
.WithName("GetUsers")
.WithTags("Users")
.WithOpenApi();
```

---

## مشاكل .NET و NuGet 📦

### 14. خطأ: "The framework 'Microsoft.NETCore.App', version '9.0.0' was not found"

**الحل:**

1. تثبيت .NET 9 SDK من: https://dotnet.microsoft.com/download
2. أعد تشغيل الجهاز
3. تحقق من التثبيت:
```bash
dotnet --version
```

---

### 15. خطأ: "NU1101: Unable to find package"

**الرسالة:**
```
NU1101: Unable to find package Microsoft.EntityFrameworkCore.SqlServer
```

**الحل:**

1. **استعد الحزم:**
```bash
dotnet restore
```

2. **امسح Cache:**
```bash
dotnet nuget locals all --clear
dotnet restore
```

3. **تحقق من اتصال الإنترنت**

---

### 16. خطأ: "The type or namespace name does not exist"

**الرسالة:**
```
The type or namespace name 'DbContext' could not be found
```

**الحل:**

أضف `using`:
```csharp
using Microsoft.EntityFrameworkCore;
```

أو تحقق من تثبيت الحزمة:
```bash
dotnet add package Microsoft.EntityFrameworkCore
```

---

## مشاكل Git 🌐

### 17. خطأ: "fatal: not a git repository"

**الحل:**

```bash
# تهيئة Git في المجلد
git init

# أو تأكد أنك في المجلد الصحيح
cd path/to/your/project
```

---

### 18. خطأ: "Updates were rejected because the remote contains work"

**الحل:**

```bash
# جلب التحديثات ودمجها
git pull origin main

# أو إجبار Push (احذر!)
git push --force
```

---

### 19. خطأ: "Please tell me who you are"

**الحل:**

```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
```

---

## مشاكل الأداء ⚡

### 20. API بطيء جداً

**الحلول:**

1. **استخدم Async/Await:**
```csharp
// ✅ صحيح
var users = await db.TblUsers.ToListAsync();

// ❌ خطأ
var users = db.TblUsers.ToList();
```

2. **استخدم Caching:**
```csharp
app.MapGet("/api/data", async (ClinicDbContext db) =>
{
    return await db.Data.ToListAsync();
})
.CacheOutput(policy => policy.Expire(TimeSpan.FromMinutes(5)));
```

3. **استخدم Pagination:**
```csharp
app.MapGet("/api/users", async (int page, int pageSize, ClinicDbContext db) =>
{
    var users = await db.TblUsers
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    return Results.Ok(users);
});
```

4. **استخدم Select بدل ToList:**
```csharp
// ✅ أفضل
var userNames = await db.TblUsers
    .Select(u => u.UserName)
    .ToListAsync();

// ❌ أبطأ
var userNames = (await db.TblUsers.ToListAsync())
    .Select(u => u.UserName)
    .ToList();
```

---

## مشاكل CORS 🌍

### 21. خطأ: "CORS policy: No 'Access-Control-Allow-Origin' header"

**الحل:**

في `Program.cs`:
```csharp
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors(); // قبل UseAuthorization
```

---

## نصائح عامة 💡

### استخدم Logging

```csharp
app.MapGet("/api/users", async (ClinicDbContext db, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching all users");
    var users = await db.TblUsers.ToListAsync();
    logger.LogInformation("Found {Count} users", users.Count);
    return Results.Ok(users);
});
```

### استخدم Try-Catch

```csharp
app.MapPost("/api/users", async (UserDto dto, ClinicDbContext db) =>
{
    try
    {
        // الكود هنا
    }
    catch (DbUpdateException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});
```

### تحقق من Null

```csharp
var user = await db.TblUsers.FindAsync(username);
if (user == null)
    return Results.NotFound(new { message = "المستخدم غير موجود" });
```

---

**إذا واجهت مشكلة غير موجودة هنا، ابحث عن رسالة الخطأ في Google أو Stack Overflow! 🔍**
