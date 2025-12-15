# 03 - الحزم وقاعدة البيانات (Packages & Database)

## الحزم المستخدمة (NuGet Packages)
يعتمد المشروع على مجموعة من مكتبات مايكروسوفت الأساسية:

1.  **Entity Framework Core (Sqlite & SqlServer)**:
    - `Microsoft.EntityFrameworkCore.Sqlite`: لدعم قاعدة بيانات SQLite الحالية.
    - `Microsoft.EntityFrameworkCore.SqlServer`: لدعم SQL Server مستقبلاً إذا لزم الأمر.
    - `Microsoft.EntityFrameworkCore.Tools`: لتفيذ أوامر الـ Migrations.

2.  **ASP.NET Core Identity**:
    - `Microsoft.AspNetCore.Identity.EntityFrameworkCore`: لإدارة المستخدمين والصلاحيات.

3.  **Tootls & Documentation**:
    - `Swashbuckle.AspNetCore`: لتوثيق الـ API وإنشاء واجهة Swagger.

## قاعدة البيانات (Database)
- **النوع الحالي**: SQLite.
- **السبب**: خفيفة، لا تتطلب تثبيت خادم، ومناسبة جداً للتطوير والبيئات الصغيرة إلى المتوسطة.
- **ملف الإعدادات (`appsettings.json`)**: يحتوي على جملة الاتصال (Connection String) باسم `DefaultConnection`.

## الترحيل (Migrations)
نعتمد على نظام Code-First، حيث نكتب الأكواد (Models) ثم نطلب من EF Core إنشاء قاعدة البيانات بناءً عليها باستخدام أوامر:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
