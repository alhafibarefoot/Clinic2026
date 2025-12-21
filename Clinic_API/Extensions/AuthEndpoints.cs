using Clinic2026_API.Data;
using Clinic2026_API.Models.System;
using Clinic2026_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic2026_API.Extensions;

public static class AuthEndpoints
{
    public static WebApplication MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth/login", async (
            ClinicDbContext db,
            IEncryptionService encryptionService,
            IConfiguration configuration,
            LoginRequest loginRequest) =>
        {
            // 1. Find User
            var user = await db.TblUsers
                .Include(u => u.TblUserRoles)
                .ThenInclude(ur => ur.LfRole)
                .FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);

            if (user == null || user.IsActive != true)
            {
                return Results.Unauthorized();
            }

            // 2. Validate Password (Decrypt stored password)
            bool isValidPassword = false;
            try
            {
                var decryptedPassword = encryptionService.Decrypt(user.UserPassword);
                if (decryptedPassword == loginRequest.Password)
                {
                    isValidPassword = true;
                }
            }
            catch
            {
                // Decryption failed or invalid format
                isValidPassword = false;
            }

            if (!isValidPassword)
            {
                return Results.Unauthorized();
            }

            // 3. Generate JWT
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);

            var claims = new List<Claim>
            {
                new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new System.Security.Claims.Claim(ClaimTypes.Name, user.UserName),
                new System.Security.Claims.Claim("FullName", user.LfEmployeeCode ?? "User")
            };

            // Add Roles
            foreach (var userRole in user.TblUserRoles)
            {
                if (userRole.LfRole != null)
                {
                   claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, userRole.LfRole.RoleEn));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationMinutes"]!)),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Results.Ok(new { Token = jwt });
        })
        .WithTags("Auth")
        .WithOpenApi(operation =>
        {
            operation.Summary = "User Login / تسجيل دخول المستخدم";
            operation.Description = "Authenticate user and return JWT token using UserName and Password. / مصادقة المستخدم وإرجاع رمز JWT باستخدام اسم المستخدم وكلمة المرور.";
            return operation;
        })
        .AllowAnonymous(); // Explicitly allow anonymous for login

        app.MapPost("/api/auth/dev-token", (
             IConfiguration configuration,
             DevTokenRequest request) =>
        {
            // 1. Validate Secret
            if (request.Secret != "barefoot2020")
            {
                return Results.Unauthorized();
            }

            // 2. Generate JWT for SuperAdmin
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);

            var claims = new List<Claim>
            {
                new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, "dev-admin-id"),
                new System.Security.Claims.Claim(ClaimTypes.Name, "DevAdmin"),
                new System.Security.Claims.Claim("FullName", "Developer"),
                new System.Security.Claims.Claim(ClaimTypes.Role, "Admin")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationMinutes"]!)),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Results.Ok(new { Token = jwt });
        })
        .WithTags("Auth")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Dev Token (Admin) / الحصول على رمز المطور (أدمن)";
            operation.Description = "Get a super-admin token for development using a secret key. / الحصول على رمز مسؤول فائق للتطوير باستخدام مفتاح سري.";
            return operation;
        })
        .AllowAnonymous();

        return app;
    }
}

public class DevTokenRequest
{
    public string Secret { get; set; } = null!;
}

public class LoginRequest
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
