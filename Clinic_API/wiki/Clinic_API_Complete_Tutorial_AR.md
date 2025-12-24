# 🎓 الدليل الشامل لبناء نظام Clinic_API من الصفر إلى الاحتراف

## مقدمة

مرحباً بك في رحلة تعليمية شاملة لبناء نظام **Clinic_API** باستخدام تقنية **Minimal API** في **.NET 9**. هذا الدليل مصمم خصيصاً للطلاب والمطورين المبتدئين الذين يريدون تعلم بناء واجهات برمجية احترافية خطوة بخطوة.

### ما الذي ستتعلمه؟

- ✅ إنشاء مشروع على GitHub وإدارته
- ✅ بناء Minimal API من الصفر
- ✅ الاتصال بقاعدة بيانات SQL Server
- ✅ استخدام Entity Framework Core
- ✅ تطبيق JWT Authentication
- ✅ تنظيم الكود بشكل احترافي
- ✅ أفضل الممارسات في تطوير APIs

---

## الفصل الأول: إعداد البيئة والأدوات 🛠️

قبل البدء في البرمجة، نحتاج إلى تجهيز بيئة العمل بجميع الأدوات اللازمة.

### 1.1 المتطلبات الأساسية

#### تثبيت .NET 9 SDK

**.NET SDK** هو مجموعة الأدوات التي تحتاجها لبناء وتشغيل تطبيقات .NET.

**الخطوات:**
1. افتح المتصفح واذهب إلى: https://dotnet.microsoft.com/download
2. حمّل **.NET 9 SDK** (وليس Runtime فقط)
3. شغّل ملف التثبيت واتبع التعليمات
4. بعد التثبيت، افتح **Command Prompt** أو **PowerShell** واكتب:

```bash
dotnet --version
```

**النتيجة المتوقعة:** سترى رقم الإصدار مثل `9.0.0`

> [!TIP]
> إذا لم يعمل الأمر، أعد تشغيل الجهاز وحاول مرة أخرى.

#### تثبيت Visual Studio Code

**VS Code** هو محرر نصوص قوي ومجاني، مثالي لتطوير .NET.

**الخطوات:**
1. اذهب إلى: https://code.visualstudio.com
2. حمّل النسخة المناسبة لنظام التشغيل لديك
3. ثبّت البرنامج

**الإضافات المطلوبة (Extensions):**

بعد تثبيت VS Code، افتحه واضغط `Ctrl+Shift+X` لفتح قائمة الإضافات، ثم ثبّت:

1. **C# Dev Kit** - للدعم الكامل للغة C#
2. **C#** - من Microsoft
3. **NuGet Package Manager** - لإدارة الحزم
4. **REST Client** أو **Thunder Client** - لاختبار APIs

#### تثبيت SQL Server

نحتاج قاعدة بيانات لحفظ البيانات.

**الخيار 1: SQL Server Express (مجاني)**
1. اذهب إلى: https://www.microsoft.com/sql-server/sql-server-downloads
2. حمّل **SQL Server Express**
3. ثبّت البرنامج مع الإعدادات الافتراضية

**الخيار 2: SQL Server Management Studio (SSMS)**
- أداة رسومية لإدارة قواعد البيانات
- حمّله من: https://aka.ms/ssmsfullsetup

#### تثبيت Git

**Git** هو نظام التحكم في الإصدارات.

**الخطوات:**
1. اذهب إلى: https://git-scm.com
2. حمّل Git لنظام التشغيل لديك
3. ثبّت البرنامج مع الإعدادات الافتراضية
4. تحقق من التثبيت:

```bash
git --version
```

**إعداد Git:**

```bash
git config --global user.name "اسمك"
git config --global user.email "بريدك@example.com"
```

#### إنشاء حساب GitHub

1. اذهب إلى: https://github.com
2. اضغط **Sign Up**
3. أكمل التسجيل

---

## الفصل الثاني: إنشاء المشروع على GitHub 🌐

الآن سننشئ مستودع (Repository) على GitHub لحفظ الكود.

### 2.1 إنشاء Repository جديد

**الخطوات:**

1. سجّل دخولك إلى GitHub
2. اضغط على زر **+** في الأعلى ثم **New repository**
3. املأ المعلومات:
   - **Repository name:** `Clinic2026`
   - **Description:** `Clinic Management API using .NET 9 Minimal API`
   - اختر **Public** أو **Private**
   - ✅ ضع علامة على **Add a README file**
   - اختر **.gitignore template:** `VisualStudio`
   - اختر **License:** `MIT` (اختياري)
4. اضغط **Create repository**

### 2.2 استنساخ المشروع محلياً

الآن سننسخ المشروع من GitHub إلى جهازك.

**الخطوات:**

1. في صفحة المشروع على GitHub، اضغط الزر الأخضر **Code**
2. انسخ الرابط (HTTPS)
3. افتح **Command Prompt** أو **PowerShell**
4. اذهب إلى المجلد الذي تريد العمل فيه:

```bash
cd D:\VisualCode
```

5. استنسخ المشروع:

```bash
git clone https://github.com/username/Clinic2026.git
```

6. ادخل إلى مجلد المشروع:

```bash
cd Clinic2026
```

### 2.3 فهم Git Workflow الأساسي

**الأوامر الأساسية التي ستستخدمها:**

```bash
# 1. معرفة حالة الملفات
git status

# 2. إضافة ملفات للتتبع
git add .

# 3. حفظ التغييرات (Commit)
git commit -m "وصف التغيير"

# 4. رفع التغييرات إلى GitHub
git push

# 5. جلب آخر التحديثات من GitHub
git pull
```

> [!IMPORTANT]
> احفظ عملك بانتظام باستخدام `git add .` ثم `git commit` ثم `git push`

---

## الفصل الثالث: إنشاء مشروع Clinic_API 🚀

الآن سننشئ مشروع Minimal API داخل المستودع.

### 3.1 إنشاء المشروع

**الخطوات:**

1. تأكد أنك داخل مجلد `Clinic2026`
2. أنشئ مشروع API جديد:

```bash
dotnet new webapi -n Clinic_API
```

**شرح الأمر:**
- `dotnet new` - أمر إنشاء مشروع جديد
- `webapi` - نوع المشروع (Web API)
- `-n Clinic_API` - اسم المشروع

3. ادخل إلى مجلد المشروع:

```bash
cd Clinic_API
```

### 3.2 فهم هيكل المشروع

بعد إنشاء المشروع، ستجد الملفات التالية:

```
Clinic_API/
├── Properties/
│   └── launchSettings.json    # إعدادات التشغيل
├── appsettings.json            # ملف الإعدادات الرئيسي
├── appsettings.Development.json # إعدادات بيئة التطوير
├── Clinic_API.csproj           # ملف المشروع
└── Program.cs                  # نقطة البداية الرئيسية
```

### 3.3 شرح ملف Program.cs

افتح ملف `Program.cs` - هذا هو قلب التطبيق:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
```

**شرح الكود:**

1. **`var builder = WebApplication.CreateBuilder(args);`**
   - ينشئ "بناء" التطبيق

2. **`builder.Services.AddEndpointsApiExplorer();`**
   - يضيف خدمة لاستكشاف Endpoints

3. **`builder.Services.AddSwaggerGen();`**
   - يضيف Swagger للتوثيق

4. **`var app = builder.Build();`**
   - يبني التطبيق

5. **`app.UseSwagger();` و `app.UseSwaggerUI();`**
   - يفعّل واجهة Swagger

6. **`app.MapGet("/weatherforecast", ...)`**
   - ينشئ endpoint للطقس (مثال افتراضي)

### 3.4 تشغيل المشروع لأول مرة

```bash
dotnet run
```

أو للتشغيل مع المراقبة التلقائية (Hot Reload):

```bash
dotnet watch run
```

**النتيجة المتوقعة:**

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7001
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
```

افتح المتصفح واذهب إلى: `https://localhost:7001/swagger`

### 3.5 فهم Swagger UI

**Swagger** هو واجهة تفاعلية لتوثيق واختبار API.

**المكونات الرئيسية:**
- **Endpoints List** - قائمة بجميع نقاط النهاية
- **Try it out** - زر لتجربة الـ endpoint
- **Execute** - تنفيذ الطلب
- **Response** - عرض النتيجة

جرّب الآن:
1. اضغط على `/weatherforecast`
2. اضغط **Try it out**
3. اضغط **Execute**
4. شاهد النتيجة

---

## الفصل الرابع: تثبيت حزم NuGet 📦

**NuGet** هو مدير الحزم لـ .NET. سنثبت الحزم اللازمة لمشروعنا.

### 4.1 الحزم المطلوبة

#### Entity Framework Core - SQL Server

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0
```

**الغرض:** الاتصال بقاعدة بيانات SQL Server

#### Entity Framework Core - Tools

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
```

**الغرض:** أدوات Migrations و Scaffolding

#### JWT Authentication

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 9.0.0
```

**الغرض:** المصادقة باستخدام JWT Tokens

#### Swagger/OpenAPI

```bash
dotnet add package Swashbuckle.AspNetCore --version 7.2.0
```

```bash
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.0
```

**الغرض:** توثيق API

### 4.2 التحقق من التثبيت

افتح ملف `Clinic_API.csproj` وتأكد من وجود الحزم:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="9.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="7.2.0" />
  </ItemGroup>
</Project>
```

---

## الفصل الخامس: إنشاء قاعدة البيانات والاتصال بها 🗄️

### 5.1 إنشاء قاعدة البيانات

**باستخدام SSMS:**

1. افتح **SQL Server Management Studio**
2. اتصل بالسيرفر (عادة `localhost` أو `.\SQLEXPRESS`)
3. انقر بالزر الأيمن على **Databases**
4. اختر **New Database**
5. اسم القاعدة: `Clinic2026`
6. اضغط **OK**

**باستخدام SQL Query:**

```sql
CREATE DATABASE Clinic2026;
GO

USE Clinic2026;
GO
```

### 5.2 إنشاء جدول تجريبي

لنبدأ بجدول بسيط للمستخدمين:

```sql
CREATE TABLE TBL_Users (
    UserName NVARCHAR(100) PRIMARY KEY,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(150),
    Email NVARCHAR(120),
    IsActive BIT DEFAULT 1,
    CreatedOn SMALLDATETIME DEFAULT GETUTCDATE()
);
GO

-- إدراج مستخدم تجريبي
INSERT INTO TBL_Users (UserName, PasswordHash, FullName, Email)
VALUES ('admin', 'hashed_password_here', 'System Administrator', 'admin@clinic.com');
GO
```

### 5.3 إعداد Connection String

افتح ملف `appsettings.json` وأضف:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Clinic2026;Integrated Security=True;TrustServerCertificate=True"
  },
  "AllowedHosts": "*"
}
```

**شرح Connection String:**

- `Server=localhost` - عنوان السيرفر
- `Database=Clinic2026` - اسم قاعدة البيانات
- `Integrated Security=True` - استخدام Windows Authentication
- `TrustServerCertificate=True` - الثقة بشهادة السيرفر (للتطوير)

> [!NOTE]
> إذا كنت تستخدم SQL Server Express، قد تحتاج: `Server=.\\SQLEXPRESS`

**للاتصال بـ Username/Password:**

```json
"DefaultConnection": "Server=localhost;Database=Clinic2026;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
```

---

## الفصل السادس: Entity Framework Core - Database First 🏗️

### 6.1 مفهوم Database First

في نهج **Database First**:
1. ✅ قاعدة البيانات موجودة بالفعل
2. ✅ نستخدم أدوات EF Core لإنشاء Models من الجداول
3. ✅ مناسب عندما يكون لديك قاعدة بيانات قديمة

**البديل:** Code First (تكتب Models أولاً ثم تنشئ قاعدة البيانات)

### 6.2 Scaffold من قاعدة البيانات

**الأمر الكامل:**

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=Clinic2026;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context ClinicDbContext --force
```

**شرح الأمر:**

- `dotnet ef dbcontext scaffold` - أمر إنشاء DbContext و Models
- `"Server=..."` - Connection String
- `Microsoft.EntityFrameworkCore.SqlServer` - Provider المستخدم
- `--output-dir Models` - مجلد Models
- `--context-dir Data` - مجلد DbContext
- `--context ClinicDbContext` - اسم DbContext
- `--force` - استبدال الملفات الموجودة

**النتيجة:**

```
Clinic_API/
├── Data/
│   └── ClinicDbContext.cs
└── Models/
    └── TblUser.cs
```

### 6.3 فهم DbContext

افتح `Data/ClinicDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Clinic_API.Data;

public partial class ClinicDbContext : DbContext
{
    public ClinicDbContext()
    {
    }

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserName);
            entity.ToTable("TBL_Users");

            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            // ... المزيد من الإعدادات
        });
    }
}
```

**شرح:**
- `DbSet<TblUser>` - يمثل جدول المستخدمين
- `OnModelCreating` - إعدادات الجداول والعلاقات

### 6.4 فهم Model

افتح `Models/TblUser.cs`:

```csharp
namespace Clinic_API.Models;

public partial class TblUser
{
    public string UserName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedOn { get; set; }
}
```

**شرح:**
- كل خاصية (Property) تمثل عمود في الجدول
- `?` تعني nullable (يمكن أن يكون null)
- `= null!` تعني non-nullable

### 6.5 تسجيل DbContext في DI Container

افتح `Program.cs` وأضف قبل `var app = builder.Build();`:

```csharp
using Clinic_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// إضافة DbContext
builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// باقي الخدمات...
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
```

---

## الفصل السابع: تنظيم المشروع 📁

مع نمو المشروع، يصبح التنظيم ضرورياً.

### 7.1 الهيكل المقترح

```
Clinic_API/
├── Data/                    # DbContext
│   └── ClinicDbContext.cs
├── Models/                  # Entity Models
│   ├── TblUser.cs
│   ├── TblRole.cs
│   └── ...
├── DTOs/                    # Data Transfer Objects
│   ├── UserDto.cs
│   └── LoginDto.cs
├── Extensions/              # Extension Methods
│   ├── ServiceCollectionExtensions.cs
│   ├── EndpointExtensions.cs
│   └── WebApplicationExtensions.cs
├── Services/                # Business Logic
│   └── IEncryptionService.cs
├── Middleware/              # Custom Middleware
│   └── GlobalExceptionMiddleware.cs
├── wwwroot/                 # Static Files
│   ├── css/
│   └── images/
├── Program.cs
└── appsettings.json
```

### 7.2 إنشاء المجلدات

```bash
mkdir Extensions
mkdir DTOs
mkdir Services
mkdir Middleware
mkdir wwwroot
mkdir wwwroot\css
mkdir wwwroot\images
```

### 7.3 مبدأ Separation of Concerns

**الفكرة:** كل جزء من الكود له مسؤولية واحدة فقط.

- **Models** - تمثيل البيانات فقط
- **DTOs** - نقل البيانات بين الطبقات
- **Services** - منطق الأعمال
- **Extensions** - تنظيم الكود
- **Middleware** - معالجة الطلبات

---

## الفصل الثامن: إنشاء أول Endpoint 🎯

### 8.1 فهم Minimal API Syntax

في Minimal API، ننشئ endpoints مباشرة بدون Controllers:

```csharp
app.MapGet("/path", () => {
    // الكود هنا
});
```

### 8.2 إنشاء GET Endpoint بسيط

في `Program.cs`، أضف قبل `app.Run();`:

```csharp
// GET: جلب جميع المستخدمين
app.MapGet("/api/users", async (ClinicDbContext db) =>
{
    var users = await db.TblUsers.ToListAsync();
    return Results.Ok(users);
})
.WithName("GetAllUsers")
.WithTags("Users");
```

**شرح الكود:**

1. **`app.MapGet("/api/users", ...)`** - ينشئ GET endpoint على المسار `/api/users`
2. **`async (ClinicDbContext db)`** - Dependency Injection للـ DbContext
3. **`await db.TblUsers.ToListAsync()`** - جلب جميع المستخدمين
4. **`Results.Ok(users)`** - إرجاع نتيجة 200 OK
5. **`.WithName("GetAllUsers")`** - اسم للـ endpoint
6. **`.WithTags("Users")`** - تصنيف في Swagger

**اختبار:**
1. شغّل المشروع: `dotnet run`
2. افتح Swagger: `https://localhost:7001/swagger`
3. جرّب endpoint `/api/users`

### 8.3 إنشاء GET By ID

```csharp
// GET: جلب مستخدم واحد
app.MapGet("/api/users/{username}", async (string username, ClinicDbContext db) =>
{
    var user = await db.TblUsers.FindAsync(username);

    if (user == null)
        return Results.NotFound(new { message = "المستخدم غير موجود" });

    return Results.Ok(user);
})
.WithName("GetUserByUsername")
.WithTags("Users");
```

**شرح:**
- `{username}` - Route Parameter
- `FindAsync(username)` - البحث بالمفتاح الأساسي
- `Results.NotFound()` - إرجاع 404 إذا لم يوجد

### 8.4 إنشاء POST Endpoint

```csharp
// POST: إضافة مستخدم جديد
app.MapPost("/api/users", async (TblUser user, ClinicDbContext db) =>
{
    // التحقق من عدم وجود المستخدم
    var exists = await db.TblUsers.AnyAsync(u => u.UserName == user.UserName);
    if (exists)
        return Results.BadRequest(new { message = "اسم المستخدم موجود بالفعل" });

    // إضافة المستخدم
    db.TblUsers.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/api/users/{user.UserName}", user);
})
.WithName("CreateUser")
.WithTags("Users");
```

**شرح:**
- `MapPost` - لإنشاء POST endpoint
- `TblUser user` - الكائن يأتي من Body
- `db.TblUsers.Add(user)` - إضافة للذاكرة
- `await db.SaveChangesAsync()` - حفظ في قاعدة البيانات
- `Results.Created()` - إرجاع 201 Created

### 8.5 إنشاء PUT Endpoint

```csharp
// PUT: تحديث مستخدم
app.MapPut("/api/users/{username}", async (string username, TblUser updatedUser, ClinicDbContext db) =>
{
    var user = await db.TblUsers.FindAsync(username);
    if (user == null)
        return Results.NotFound();

    // تحديث البيانات
    user.FullName = updatedUser.FullName;
    user.Email = updatedUser.Email;
    user.IsActive = updatedUser.IsActive;

    await db.SaveChangesAsync();

    return Results.Ok(user);
})
.WithName("UpdateUser")
.WithTags("Users");
```

### 8.6 إنشاء DELETE Endpoint

```csharp
// DELETE: حذف مستخدم
app.MapDelete("/api/users/{username}", async (string username, ClinicDbContext db) =>
{
    var user = await db.TblUsers.FindAsync(username);
    if (user == null)
        return Results.NotFound();

    db.TblUsers.Remove(user);
    await db.SaveChangesAsync();

    return Results.NoContent();
})
.WithName("DeleteUser")
.WithTags("Users");
```

**شرح:**
- `db.TblUsers.Remove(user)` - حذف من الذاكرة
- `Results.NoContent()` - إرجاع 204 (نجح بدون محتوى)

---

## الفصل التاسع: Extension Methods والتنظيم 🧩

الآن `Program.cs` أصبح مزدحماً. لننظم الكود!

### 9.1 إنشاء ServiceCollectionExtensions

أنشئ ملف `Extensions/ServiceCollectionExtensions.cs`:

```csharp
using Clinic_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic_API.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// إضافة خدمات التطبيق
    /// </summary>
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // قاعدة البيانات
        services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
```

**شرح:**
- `this IServiceCollection services` - Extension Method
- نجمع كل إعدادات الخدمات في مكان واحد

### 9.2 إنشاء EndpointExtensions

أنشئ ملف `Extensions/EndpointExtensions.cs`:

```csharp
using Clinic_API.Data;
using Clinic_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic_API.Extensions;

public static class EndpointExtensions
{
    /// <summary>
    /// تسجيل endpoints المستخدمين
    /// </summary>
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users");

        // GET All
        group.MapGet("/", async (ClinicDbContext db) =>
        {
            var users = await db.TblUsers.ToListAsync();
            return Results.Ok(users);
        })
        .WithName("GetAllUsers");

        // GET By ID
        group.MapGet("/{username}", async (string username, ClinicDbContext db) =>
        {
            var user = await db.TblUsers.FindAsync(username);
            return user == null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserByUsername");

        // POST
        group.MapPost("/", async (TblUser user, ClinicDbContext db) =>
        {
            var exists = await db.TblUsers.AnyAsync(u => u.UserName == user.UserName);
            if (exists)
                return Results.BadRequest(new { message = "اسم المستخدم موجود" });

            db.TblUsers.Add(user);
            await db.SaveChangesAsync();
            return Results.Created($"/api/users/{user.UserName}", user);
        })
        .WithName("CreateUser");

        // PUT
        group.MapPut("/{username}", async (string username, TblUser updatedUser, ClinicDbContext db) =>
        {
            var user = await db.TblUsers.FindAsync(username);
            if (user == null) return Results.NotFound();

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            user.IsActive = updatedUser.IsActive;

            await db.SaveChangesAsync();
            return Results.Ok(user);
        })
        .WithName("UpdateUser");

        // DELETE
        group.MapDelete("/{username}", async (string username, ClinicDbContext db) =>
        {
            var user = await db.TblUsers.FindAsync(username);
            if (user == null) return Results.NotFound();

            db.TblUsers.Remove(user);
            await db.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithName("DeleteUser");
    }
}
```

**شرح:**
- `MapGroup("/api/users")` - تجميع endpoints تحت مسار واحد
- كل الكود الخاص بالمستخدمين في ملف واحد

### 9.3 تبسيط Program.cs

الآن `Program.cs` يصبح نظيفاً:

```csharp
using Clinic_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// إضافة الخدمات
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// تسجيل Endpoints
app.MapUserEndpoints();

app.Run();
```

**أنظف وأوضح! ✨**

---

## الفصل العاشر: Data Transfer Objects (DTOs) 📋

### 10.1 لماذا DTOs؟

**المشكلة:** عند إرجاع Entity مباشرة:
- ❌ نكشف كلمات المرور
- ❌ نكشف بيانات حساسة
- ❌ نرسل بيانات غير ضرورية

**الحل:** DTOs - كائنات مخصصة لنقل البيانات

### 10.2 إنشاء UserDto

أنشئ ملف `DTOs/UserDto.cs`:

```csharp
namespace Clinic_API.DTOs;

public class UserDto
{
    public string UserName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
```

**لاحظ:** لا يوجد `PasswordHash`!

### 10.3 إنشاء CreateUserDto

```csharp
namespace Clinic_API.DTOs;

public class CreateUserDto
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
```

### 10.4 استخدام DTOs في Endpoints

عدّل `EndpointExtensions.cs`:

```csharp
using Clinic_API.DTOs;

// GET All - إرجاع DTOs
group.MapGet("/", async (ClinicDbContext db) =>
{
    var users = await db.TblUsers
        .Select(u => new UserDto
        {
            UserName = u.UserName,
            FullName = u.FullName ?? "",
            Email = u.Email ?? "",
            IsActive = u.IsActive ?? true
        })
        .ToListAsync();

    return Results.Ok(users);
});

// POST - استقبال CreateUserDto
group.MapPost("/", async (CreateUserDto dto, ClinicDbContext db) =>
{
    var exists = await db.TblUsers.AnyAsync(u => u.UserName == dto.UserName);
    if (exists)
        return Results.BadRequest(new { message = "اسم المستخدم موجود" });

    var user = new TblUser
    {
        UserName = dto.UserName,
        PasswordHash = HashPassword(dto.Password), // دالة تشفير
        FullName = dto.FullName,
        Email = dto.Email,
        IsActive = true,
        CreatedOn = DateTime.UtcNow
    };

    db.TblUsers.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/api/users/{user.UserName}", new UserDto
    {
        UserName = user.UserName,
        FullName = user.FullName ?? "",
        Email = user.Email ?? "",
        IsActive = user.IsActive ?? true
    });
});

// دالة مساعدة للتشفير (مبسطة)
static string HashPassword(string password)
{
    // في الواقع، استخدم BCrypt أو Identity
    return Convert.ToBase64String(
        System.Text.Encoding.UTF8.GetBytes(password));
}
```

---

## الفصل الحادي عشر: Validation والتحقق

### 11.1 Data Annotations

أضف Validation إلى DTOs:

```csharp
using System.ComponentModel.DataAnnotations;

namespace Clinic_API.DTOs;

public class CreateUserDto
{
    [Required(ErrorMessage = "اسم المستخدم مطلوب")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "اسم المستخدم يجب أن يكون بين 3 و 100 حرف")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [StringLength(255, MinimumLength = 6, ErrorMessage = "كلمة المرور يجب أن تكون 6 أحرف على الأقل")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "الاسم الكامل مطلوب")]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
    public string Email { get; set; } = string.Empty;
}
```

### 11.2 Custom Validation في Endpoint

```csharp
group.MapPost("/", async (CreateUserDto dto, ClinicDbContext db) =>
{
    // التحقق اليدوي
    if (string.IsNullOrWhiteSpace(dto.UserName))
        return Results.BadRequest(new { message = "اسم المستخدم مطلوب" });

    if (dto.Password.Length < 6)
        return Results.BadRequest(new { message = "كلمة المرور قصيرة جداً" });

    // باقي الكود...
});
```

---

## الفصل الثاني عشر: JWT Authentication 🔐

### 12.1 مفهوم JWT

**JWT (JSON Web Token)** هو رمز مشفر يحتوي على معلومات المستخدم.

**المكونات:**
1. **Header** - نوع الرمز والخوارزمية
2. **Payload** - البيانات (Username, Roles, etc.)
3. **Signature** - التوقيع للتحقق

### 12.2 إعداد JWT في appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "..."
  },
  "JwtSettings": {
    "SecretKey": "YourSecretKey_MustBeAtLeast32Characters_Clinic2026",
    "Issuer": "Clinic2026_API",
    "Audience": "Clinic2026_Client",
    "ExpirationMinutes": 1440
  }
}
```

### 12.3 إضافة JWT Authentication

في `ServiceCollectionExtensions.cs`:

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public static IServiceCollection AddJwtAuthentication(
    this IServiceCollection services,
    IConfiguration configuration)
{
    var jwtSettings = configuration.GetSection("JwtSettings");
    var secretKey = jwtSettings["SecretKey"];

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(secretKey!))
            };
        });

    services.AddAuthorization();

    return services;
}
```

في `Program.cs`:

```csharp
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// بعد UseHttpsRedirection
app.UseAuthentication();
app.UseAuthorization();
```

### 12.4 إنشاء Login Endpoint

أنشئ `DTOs/LoginDto.cs`:

```csharp
namespace Clinic_API.DTOs;

public class LoginDto
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
```

أنشئ `Extensions/AuthEndpoints.cs`:

```csharp
using Clinic_API.Data;
using Clinic_API.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic_API.Extensions;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth/login", async (
            LoginDto loginDto,
            ClinicDbContext db,
            IConfiguration config) =>
        {
            // التحقق من المستخدم
            var user = await db.TblUsers
                .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

            if (user == null)
                return Results.Unauthorized();

            // التحقق من كلمة المرور (مبسط)
            var hashedPassword = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(loginDto.Password));

            if (user.PasswordHash != hashedPassword)
                return Results.Unauthorized();

            // إنشاء Token
            var token = GenerateJwtToken(user.UserName, config);

            return Results.Ok(new { token });
        })
        .WithName("Login")
        .WithTags("Authentication")
        .AllowAnonymous();
    }

    private static string GenerateJwtToken(string username, IConfiguration config)
    {
        var jwtSettings = config.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];
        var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"]!);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
```

في `Program.cs`:

```csharp
app.MapAuthEndpoints();
app.MapUserEndpoints();
```

### 12.5 حماية Endpoints

```csharp
// في EndpointExtensions.cs
group.MapGet("/", async (ClinicDbContext db) =>
{
    // ...
})
.RequireAuthorization(); // يتطلب تسجيل دخول
```

### 12.6 اختبار في Swagger

1. شغّل المشروع
2. اذهب إلى `/api/auth/login`
3. أدخل username و password
4. انسخ الـ Token
5. اضغط زر **Authorize** في Swagger
6. الصق الـ Token
7. جرّب endpoints المحمية

---

## الفصل الثالث عشر: إعداد Swagger المتقدم 📚

### 13.1 تخصيص معلومات API

في `ServiceCollectionExtensions.cs`:

```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clinic2026 API",
        Version = "v1",
        Description = "نظام إدارة العيادات الطبية - Minimal API",
        TermsOfService = new Uri("https://www.clinic2026.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "فريق التطوير",
            Email = "dev@clinic2026.com",
            Url = new Uri("https://www.clinic2026.com")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // إضافة JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "أدخل JWT Token (بدون كلمة Bearer)",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
```

### 13.2 إضافة شعار مخصص

1. ضع شعارك في `wwwroot/images/logo.png`

2. أنشئ `wwwroot/css/swagger-custom.css`:

```css
.swagger-ui .topbar {
    background-color: #2c3e50;
}

.swagger-ui .topbar-wrapper::before {
    content: "";
    display: inline-block;
    width: 50px;
    height: 50px;
    background-image: url('/images/logo.png');
    background-size: contain;
    background-repeat: no-repeat;
    margin-right: 10px;
    vertical-align: middle;
}

.swagger-ui .info .title {
    color: #2c3e50;
    font-size: 36px;
}
```

3. في `Program.cs`:

```csharp
app.UseStaticFiles(); // قبل UseSwagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic2026 API v1");
        c.DocumentTitle = "Clinic2026 API Documentation";
        c.InjectStylesheet("/css/swagger-custom.css");
    });
}
```

---

## الفصل الرابع عشر: Error Handling المتقدم ⚠️

### 14.1 Global Exception Middleware

أنشئ `Middleware/GlobalExceptionMiddleware.cs`:

```csharp
using System.Net;
using System.Text.Json;

namespace Clinic_API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "حدث خطأ غير متوقع");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            statusCode = context.Response.StatusCode,
            message = "حدث خطأ في السيرفر",
            detailed = exception.Message
        };

        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}
```

في `Program.cs`:

```csharp
app.UseMiddleware<GlobalExceptionMiddleware>();
```

---

## الفصل الخامس عشر: Output Caching ⚡

### 15.1 إعداد Caching

في `ServiceCollectionExtensions.cs`:

```csharp
services.AddOutputCache(options =>
{
    // سياسة افتراضية
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromMinutes(5)));

    // سياسة للجداول المرجعية (Lookup)
    options.AddPolicy("LookupPolicy", builder =>
        builder.Expire(TimeSpan.FromDays(1)));
});
```

في `Program.cs`:

```csharp
app.UseOutputCache(); // بعد UseAuthorization
```

### 15.2 استخدام Cache

```csharp
group.MapGet("/", async (ClinicDbContext db) =>
{
    // ...
})
.CacheOutput("LookupPolicy");
```

---

## الخاتمة والخطوات التالية 🎯

### ما تعلمناه

✅ إنشاء مشروع Minimal API من الصفر
✅ الاتصال بقاعدة بيانات SQL Server
✅ استخدام Entity Framework Core
✅ بناء CRUD Operations كاملة
✅ تنظيم الكود باستخدام Extensions
✅ استخدام DTOs
✅ تطبيق JWT Authentication
✅ تخصيص Swagger
✅ معالجة الأخطاء
✅ تحسين الأداء بـ Caching

### الخطوات التالية

1. **Testing** - تعلم Unit Testing و Integration Testing
2. **Logging** - استخدام Serilog للتسجيل المتقدم
3. **Docker** - نشر التطبيق في Containers
4. **CI/CD** - أتمتة النشر باستخدام GitHub Actions
5. **Microservices** - تقسيم التطبيق إلى خدمات صغيرة

### مصادر إضافية

- [Microsoft Docs - Minimal APIs](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [JWT.io](https://jwt.io/)

---

**تهانينا! 🎉 أنت الآن مطور Minimal API محترف!**
