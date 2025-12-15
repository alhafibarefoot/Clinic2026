using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Clinic2026_API.Extensions;

public class StaticTokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public const string SchemeName = "StaticToken";
    private const string ValidToken = "barefoot2020";

    public StaticTokenAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // 1. Check Authorization Header
        if (!Request.Headers.TryGetValue("Authorization", out var value))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        string token = value.ToString();

        // 2. Validate Token (handle "Bearer " prefix or raw token)
        bool isValid = false;
        if (token.Equals($"Bearer {ValidToken}", StringComparison.OrdinalIgnoreCase) ||
            token.Equals(ValidToken, StringComparison.OrdinalIgnoreCase))
        {
            isValid = true;
        }

        if (!isValid)
        {
            return Task.FromResult(AuthenticateResult.NoResult()); // Let other handlers (JWT) try, or fail if none work
        }

        // 3. Create Principal for Valid Token
        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, "static-admin"),
            new Claim(ClaimTypes.Name, "SuperAdmin"),
            new Claim(ClaimTypes.Role, "Admin")
        };
        var identity = new ClaimsIdentity(claims, SchemeName);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, SchemeName);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
