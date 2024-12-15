using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

using places.data;

namespace places.web
{
    public class ApiKeyHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly PlacesDbContext _dbContext;
        private readonly string ApiKeyHeader = "Api-Key";

        public ApiKeyHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            PlacesDbContext dbContext)
            : base(options, logger, encoder)
        {
            _dbContext = dbContext;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeader, out var apiKeyHeaderValues))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing API Key"));
            }

            var providedApiKey = apiKeyHeaderValues.ToString();
            var possibleKeys = _dbContext.UserAccounts.ToList();

            if (!possibleKeys.Any(ua => ua.ApiKey == providedApiKey))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
            }

            var claims = new[] { new Claim(ClaimTypes.Name, "ApiKeyUser") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}