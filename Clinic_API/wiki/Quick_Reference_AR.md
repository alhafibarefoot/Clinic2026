# 📋 المرجع السريع - Clinic_API

دليل مرجعي سريع لأهم الأوامر والأكواد المستخدمة في مشروع Clinic_API.

---

## أوامر Git الأساسية 🌐

### إعداد Git لأول مرة
```bash
git config --global user.name "اسمك"
git config --global user.email "email@example.com"
```

### العمليات اليومية
```bash
# معرفة حالة الملفات
git status

# إضافة جميع الملفات المعدلة
git add .

# إضافة ملف محدد
git add filename.cs

# حفظ التغييرات
git commit -m "وصف التغيير"

# رفع التغييرات إلى GitHub
git push

# جلب آخر التحديثات
git pull

# عرض سجل التغييرات
git log --oneline
```

### التعامل مع Branches
```bash
# إنشاء فرع جديد
git branch feature-name

# الانتقال إلى فرع
git checkout feature-name

# إنشاء والانتقال في أمر واحد
git checkout -b feature-name

# دمج فرع في الفرع الحالي
git merge feature-name

# حذف فرع
git branch -d feature-name
```

---

## أوامر .NET CLI 🔧

### إدارة المشاريع
```bash
# إنشاء مشروع Web API جديد
dotnet new webapi -n ProjectName

# تشغيل المشروع
dotnet run

# تشغيل مع Hot Reload
dotnet watch run

# بناء المشروع
dotnet build

# تنظيف المشروع
dotnet clean

# استعادة الحزم
dotnet restore
```

### إدارة الحزم (NuGet)
```bash
# إضافة حزمة
dotnet add package PackageName

# إضافة حزمة بإصدار محدد
dotnet add package PackageName --version 9.0.0

# حذف حزمة
dotnet remove package PackageName

# عرض الحزم المثبتة
dotnet list package
```

### Entity Framework Core
```bash
# تثبيت أدوات EF Core (مرة واحدة)
dotnet tool install --global dotnet-ef

# تحديث أدوات EF Core
dotnet tool update --global dotnet-ef

# إنشاء DbContext من قاعدة بيانات موجودة
dotnet ef dbcontext scaffold "ConnectionString" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Data --context ClinicDbContext --force

# إنشاء Migration جديد
dotnet ef migrations add MigrationName

# تطبيق Migrations على قاعدة البيانات
dotnet ef database update

# التراجع عن Migration
dotnet ef database update PreviousMigrationName

# حذف آخر Migration (قبل التطبيق)
dotnet ef migrations remove

# عرض قائمة Migrations
dotnet ef migrations list

# إنشاء SQL Script من Migration
dotnet ef migrations script
```

---

## Connection Strings 🔌

### SQL Server - Windows Authentication
```json
"Server=localhost;Database=Clinic2026;Integrated Security=True;TrustServerCertificate=True"
```

### SQL Server - SQL Authentication
```json
"Server=localhost;Database=Clinic2026;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
```

### SQL Server Express
```json
"Server=.\\SQLEXPRESS;Database=Clinic2026;Integrated Security=True;TrustServerCertificate=True"
```

### LocalDB
```json
"Server=(localdb)\\mssqllocaldb;Database=Clinic2026;Trusted_Connection=True"
```

---

## أكواد شائعة 💻

### تسجيل DbContext
```csharp
builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
```

### إنشاء GET Endpoint
```csharp
app.MapGet("/api/resource", async (ClinicDbContext db) =>
{
    var items = await db.TableName.ToListAsync();
    return Results.Ok(items);
})
.WithName("GetAll")
.WithTags("Resource");
```

### إنشاء POST Endpoint
```csharp
app.MapPost("/api/resource", async (EntityDto dto, ClinicDbContext db) =>
{
    var entity = new Entity
    {
        // Mapping
    };

    db.TableName.Add(entity);
    await db.SaveChangesAsync();

    return Results.Created($"/api/resource/{entity.Id}", entity);
})
.WithName("Create")
.WithTags("Resource");
```

### إنشاء PUT Endpoint
```csharp
app.MapPut("/api/resource/{id}", async (int id, EntityDto dto, ClinicDbContext db) =>
{
    var entity = await db.TableName.FindAsync(id);
    if (entity == null) return Results.NotFound();

    // Update properties
    entity.Property = dto.Property;

    await db.SaveChangesAsync();
    return Results.Ok(entity);
})
.WithName("Update")
.WithTags("Resource");
```

### إنشاء DELETE Endpoint
```csharp
app.MapDelete("/api/resource/{id}", async (int id, ClinicDbContext db) =>
{
    var entity = await db.TableName.FindAsync(id);
    if (entity == null) return Results.NotFound();

    db.TableName.Remove(entity);
    await db.SaveChangesAsync();

    return Results.NoContent();
})
.WithName("Delete")
.WithTags("Resource");
```

### استخدام MapGroup
```csharp
var group = app.MapGroup("/api/resource")
    .WithTags("Resource");

group.MapGet("/", async (ClinicDbContext db) => { /* ... */ });
group.MapGet("/{id}", async (int id, ClinicDbContext db) => { /* ... */ });
group.MapPost("/", async (EntityDto dto, ClinicDbContext db) => { /* ... */ });
group.MapPut("/{id}", async (int id, EntityDto dto, ClinicDbContext db) => { /* ... */ });
group.MapDelete("/{id}", async (int id, ClinicDbContext db) => { /* ... */ });
```

---

## JWT Authentication 🔐

### إعدادات appsettings.json
```json
"JwtSettings": {
  "SecretKey": "YourSecretKey_MustBeAtLeast32Characters_Clinic2026",
  "Issuer": "Clinic2026_API",
  "Audience": "Clinic2026_Client",
  "ExpirationMinutes": 1440
}
```

### تسجيل JWT Authentication
```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!))
        };
    });

builder.Services.AddAuthorization();
```

### تفعيل Authentication
```csharp
app.UseAuthentication();
app.UseAuthorization();
```

### حماية Endpoint
```csharp
app.MapGet("/api/protected", () => "Protected data")
    .RequireAuthorization();
```

### توليد JWT Token
```csharp
private static string GenerateJwtToken(string username, IConfiguration config)
{
    var jwtSettings = config.GetSection("JwtSettings");
    var secretKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));
    var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var token = new JwtSecurityToken(
        issuer: jwtSettings["Issuer"],
        audience: jwtSettings["Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(
            int.Parse(jwtSettings["ExpirationMinutes"]!)),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}
```

---

## Swagger Configuration 📚

### إعداد أساسي
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clinic2026 API",
        Version = "v1",
        Description = "نظام إدارة العيادات الطبية"
    });
});
```

### إضافة JWT إلى Swagger
```csharp
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Description = "أدخل JWT Token",
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
```

### تفعيل Swagger
```csharp
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

---

## Output Caching ⚡

### إعداد Caching
```csharp
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromMinutes(5)));

    options.AddPolicy("LongCache", builder =>
        builder.Expire(TimeSpan.FromHours(1)));
});
```

### تفعيل Caching
```csharp
app.UseOutputCache();
```

### استخدام Cache Policy
```csharp
app.MapGet("/api/data", async (ClinicDbContext db) =>
{
    return await db.Data.ToListAsync();
})
.CacheOutput("LongCache");
```

---

## CORS Configuration 🌍

### إعداد CORS
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
```

### تفعيل CORS
```csharp
app.UseCors();
```

---

## Data Annotations للـ Validation ✅

```csharp
public class UserDto
{
    [Required(ErrorMessage = "الحقل مطلوب")]
    public string Name { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "الطول يجب أن يكون بين 3 و 100")]
    public string Username { get; set; }

    [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
    public string Email { get; set; }

    [Range(18, 100, ErrorMessage = "العمر يجب أن يكون بين 18 و 100")]
    public int Age { get; set; }

    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "رقم الهاتف يجب أن يكون 10 أرقام")]
    public string Phone { get; set; }
}
```

---

## أكواد SQL مفيدة 📊

### إنشاء قاعدة بيانات
```sql
CREATE DATABASE Clinic2026;
GO

USE Clinic2026;
GO
```

### إنشاء جدول
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
```

### إدراج بيانات
```sql
INSERT INTO TBL_Users (UserName, PasswordHash, FullName, Email)
VALUES ('admin', 'hashed_password', 'Administrator', 'admin@clinic.com');
GO
```

### استعلامات مفيدة
```sql
-- عرض جميع الجداول
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';

-- عرض أعمدة جدول
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'TBL_Users';

-- حذف جميع البيانات من جدول
TRUNCATE TABLE TableName;

-- حذف قاعدة البيانات
DROP DATABASE Clinic2026;
```

---

## اختصارات VS Code ⌨️

| الاختصار | الوظيفة |
|---------|---------|
| `Ctrl + Shift + P` | فتح Command Palette |
| `Ctrl + P` | البحث عن ملف |
| `Ctrl + Shift + F` | البحث في جميع الملفات |
| `Ctrl + /` | تعليق/إلغاء تعليق |
| `Alt + ↑/↓` | نقل السطر للأعلى/الأسفل |
| `Shift + Alt + ↓` | نسخ السطر |
| `Ctrl + D` | تحديد الكلمة التالية المطابقة |
| `Ctrl + Shift + L` | تحديد جميع الكلمات المطابقة |
| `F2` | إعادة تسمية |
| `F12` | الذهاب إلى التعريف |
| `Ctrl + .` | Quick Fix |

---

## حل المشاكل الشائعة 🔧

### خطأ: "Unable to connect to database"
```bash
# تحقق من Connection String
# تحقق من تشغيل SQL Server
# تحقق من اسم قاعدة البيانات
```

### خطأ: "dotnet command not found"
```bash
# أعد تشغيل الجهاز بعد تثبيت .NET SDK
# تحقق من PATH
```

### خطأ: "Migration already applied"
```bash
# استخدم
dotnet ef database update PreviousMigrationName
# ثم احذف Migration
dotnet ef migrations remove
```

### خطأ: "Port already in use"
```bash
# غيّر Port في launchSettings.json
# أو أوقف العملية التي تستخدم Port
```

---

## روابط مفيدة 🔗

- [.NET Documentation](https://learn.microsoft.com/dotnet/)
- [ASP.NET Core Minimal APIs](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [JWT.io](https://jwt.io/)
- [Swagger/OpenAPI](https://swagger.io/)
- [Git Documentation](https://git-scm.com/doc)

---

**استخدم هذا المرجع كدليل سريع أثناء التطوير! 📖**
