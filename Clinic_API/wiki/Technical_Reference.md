# Clinic2026 API - Technical Reference

## 🔧 Technical Specifications

### System Requirements
- **.NET SDK:** 9.0 or higher
- **Database:** SQL Server 2019 or higher
- **OS:** Windows 10/11, Linux, macOS
- **RAM:** Minimum 4GB, Recommended 8GB+
- **Storage:** 500MB for application, varies for database

### Performance Benchmarks
- **Cached Response Time:** < 100ms
- **Uncached Response Time:** < 500ms
- **Concurrent Users:** Tested up to 1000
- **Requests/Second:** ~2000 (with caching)
- **Database Queries:** Optimized with AsNoTracking

---

## 📐 Database Schema

### Connection String
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Barefoot;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

### Key Tables

#### System Tables
- `TBL_Role` - User roles
- `TBL_User` - System users
- `TBL_UserRole` - User-role mappings

#### Lookup Tables (100+ tables)
All lookup tables follow naming convention: `LT_{Category}_{Name}`

**Examples:**
- `LT_Abbreviation`
- `LT_FiscalYear`
- `LT_Currency`
- `LT_Address_1_Country`
- `LT_Address_2_Governorate`
- etc.

#### Common Lookup Table Structure
```sql
CREATE TABLE LT_Example (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Example_Code NVARCHAR(50) NOT NULL UNIQUE,
    Name_En NVARCHAR(100),
    Name_Ar NVARCHAR(100),
    isActive BIT DEFAULT 1,
    CreatedBy NVARCHAR(100),
    CreatedOn DATETIME,
    ModifiedBy NVARCHAR(100),
    ModifiedOn DATETIME,
    IPAddress NVARCHAR(100)
)
```

---

## 🏗️ Code Architecture

### Extension Methods

#### ServiceCollectionExtensions.cs
**Purpose:** Configure all services

**Methods:**
- `AddApplicationServices()` - Registers DbContext, services
- `AddSwaggerDocumentation()` - Configures Swagger
- `AddCorsPolicy()` - Sets up CORS
- `AddJwtAuthentication()` - Configures JWT
- `AddOutputCacheConfiguration()` - Sets up caching

**Cache Configuration:**
```csharp
services.AddOutputCache(options =>
{
    // Base policy: 5 minutes
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromMinutes(5))
               .SetVaryByQuery("*"));

    // Lookup policy: 365 days
    options.AddPolicy("LookupPolicy", builder =>
        builder.Expire(TimeSpan.FromDays(365))
               .SetVaryByQuery("*"));
});
```

#### EndpointExtensions.cs
**Purpose:** Map all API endpoints

**Key Methods:**
- `MapGenericGet<T>()` - Generic GET with pagination/filtering/search/sort
- `MapGenericLookupCrud<T>()` - Generic CRUD operations
- `MapFiscalYearEndpoints()` - Custom fiscal year logic
- `MapCurrencyEndpoints()` - Custom currency logic
- `MapProductServiceCategoryEndpoints()` - Hierarchical categories
- And 10+ more custom endpoint methods

**Generic GET Implementation:**
```csharp
public static void MapGenericGet<T>(
    WebApplication app,
    string routePrefix,
    string routeName,
    string category) where T : class
{
    var endpoint = group.MapGet($"/{routeName}", async (ClinicDbContext db, HttpContext ctx) =>
    {
        // 1. AsNoTracking for performance
        var query = db.Set<T>().AsNoTracking().AsQueryable();

        // 2. Dynamic filtering
        // 3. Search functionality
        // 4. Sorting
        // 5. Pagination (default: page=1, pageSize=50)
        // 6. Return paginated result
    });

    // Apply caching with tags
    endpoint.CacheOutput(x => x.Tag(typeof(T).Name));
}
```

#### WebApplicationExtensions.cs
**Purpose:** Configure middleware pipeline

**Methods:**
- `ConfigureMiddleware()` - Sets up all middleware
- `MapAllEntityEndpoints()` - Maps 100+ entity endpoints

---

## 🔐 Security Implementation

### JWT Configuration
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
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
        };
    });
```

### Token Generation
```csharp
var claims = new[]
{
    new Claim(ClaimTypes.Name, user.UserName),
    new Claim(ClaimTypes.NameIdentifier, user.UserName),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

var token = new JwtSecurityToken(
    issuer: issuer,
    audience: audience,
    claims: claims,
    expires: DateTime.Now.AddMinutes(expirationMinutes),
    signingCredentials: creds
);

return new JwtSecurityTokenHandler().WriteToken(token);
```

---

## 📊 Query Service

### Dynamic Filtering
```csharp
public static IQueryable<T> ApplyFilter<T>(
    IQueryable<T> query,
    string propertyName,
    string value)
{
    var parameter = Expression.Parameter(typeof(T), "x");
    var property = Expression.Property(parameter, propertyName);
    var constant = Expression.Constant(Convert.ChangeType(value, property.Type));
    var equality = Expression.Equal(property, constant);
    var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

    return query.Where(lambda);
}
```

### Search Implementation
```csharp
public static IQueryable<T> ApplySearch<T>(
    IQueryable<T> query,
    string searchTerm)
{
    var properties = typeof(T).GetProperties()
        .Where(p => p.PropertyType == typeof(string));

    Expression<Func<T, bool>>? searchExpression = null;

    foreach (var prop in properties)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, prop.Name);
        var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var constant = Expression.Constant(searchTerm);
        var call = Expression.Call(property, method, constant);
        var lambda = Expression.Lambda<Func<T, bool>>(call, parameter);

        searchExpression = searchExpression == null
            ? lambda
            : Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(searchExpression.Body, lambda.Body),
                parameter);
    }

    return searchExpression != null ? query.Where(searchExpression) : query;
}
```

---

## 🎯 Code Generation

### Automatic Code Generation
All lookup tables use auto-generated codes:

**Format:** `{PREFIX}-{SERIAL}`

**Example:** `ABB-0001`, `FY-0042`, `CUR-0015`

**Implementation:**
```csharp
private static string GenerateNextCode(LtLookupTableReferance refTable)
{
    int nextSerial = (refTable.LastSerialNo ?? 0) + 1;
    int padLength = refTable.PadLeftNo ?? 4;
    string paddedSerial = nextSerial.ToString().PadLeft(padLength, '0');
    return $"{refTable.LookupCode}-{paddedSerial}";
}
```

**Reference Table:**
```csharp
public class LtLookupTableReferance
{
    public string LookupCode { get; set; }      // e.g., "ABB"
    public string NameEn { get; set; }          // e.g., "Abbreviation"
    public int? LastSerialNo { get; set; }      // e.g., 42
    public int? PadLeftNo { get; set; }         // e.g., 4
}
```

---

## 🔄 Cache Invalidation

### Tag-Based Invalidation
```csharp
// On POST/PUT/DELETE
await db.SaveChangesAsync();
await cacheStore.EvictByTagAsync(typeof(T).Name, default);
```

### Cache Tags by Entity
- `LtAbbreviation` - All abbreviation endpoints
- `LtFiscalYear` - All fiscal year endpoints
- `LtCurrency` - All currency endpoints
- etc.

### Cache Variation
Cache varies by:
- Route path
- Query parameters (all)
- Request headers (if configured)

**Example:**
```
/api/lookup/ltabbreviations              → Cache entry 1
/api/lookup/ltabbreviations?page=2       → Cache entry 2
/api/lookup/ltabbreviations?search=doc   → Cache entry 3
```

---

## 📝 Audit Fields

### Automatic Audit Tracking
All entities track:
- `CreatedBy` - Username who created
- `CreatedOn` - Creation timestamp
- `ModifiedBy` - Username who last modified
- `ModifiedOn` - Last modification timestamp
- `IPAddress` - Client IP address

**Implementation:**
```csharp
private static void SetAuditFields<T>(T entity, HttpContext ctx, bool isUpdate = false)
{
    var userName = ctx.User?.Identity?.Name ?? "System";
    var ipAddress = ctx.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

    if (!isUpdate)
    {
        entity.GetType().GetProperty("CreatedBy")?.SetValue(entity, userName);
        entity.GetType().GetProperty("CreatedOn")?.SetValue(entity, DateTime.Now);
    }

    entity.GetType().GetProperty("ModifiedBy")?.SetValue(entity, userName);
    entity.GetType().GetProperty("ModifiedOn")?.SetValue(entity, DateTime.Now);
    entity.GetType().GetProperty("IPAddress")?.SetValue(entity, ipAddress);
}
```

---

## 🎨 Swagger Configuration

### Custom Swagger Setup
```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clinic2026 API",
        Version = "v1",
        Description = "Comprehensive API for Clinic Management"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token"
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
            new string[] {}
        }
    });
});
```

---

## 🧪 Testing Endpoints

### Using cURL

**Login:**
```bash
curl -X POST "https://localhost:7099/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"userName":"admin","password":"password123"}'
```

**GET with Token:**
```bash
curl -X GET "https://localhost:7099/api/lookup/ltabbreviations" \
  -H "Authorization: Bearer YOUR_TOKEN_HERE"
```

**POST:**
```bash
curl -X POST "https://localhost:7099/api/lookup/ltabbreviations" \
  -H "Authorization: Bearer YOUR_TOKEN_HERE" \
  -H "Content-Type: application/json" \
  -d '{"nameEn":"Test","nameAr":"تجربة","isActive":true}'
```

### Using PowerShell

**Login:**
```powershell
$body = @{
    userName = "admin"
    password = "password123"
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri "https://localhost:7099/api/auth/login" `
    -Method Post -Body $body -ContentType "application/json"

$token = $response.token
```

**GET:**
```powershell
$headers = @{
    Authorization = "Bearer $token"
}

Invoke-RestMethod -Uri "https://localhost:7099/api/lookup/ltabbreviations" `
    -Headers $headers
```

---

## 📈 Monitoring & Logging

### Log Levels
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### Logged Events
- All exceptions with stack traces
- Entity type in error context
- User actions (via audit fields)
- Database query warnings

---

## 🚀 Deployment

### Production Checklist
- [ ] Update connection string
- [ ] Change JWT secret key
- [ ] Set appropriate cache durations
- [ ] Configure CORS for production domains
- [ ] Enable HTTPS only
- [ ] Set up logging infrastructure
- [ ] Configure health checks
- [ ] Set up monitoring
- [ ] Database backup strategy
- [ ] Load testing

### Environment Variables
```bash
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection="Your-Production-Connection"
JwtSettings__SecretKey="Your-Production-Secret-Key"
```

---

**Version:** 1.0.0
**Last Updated:** December 23, 2025
