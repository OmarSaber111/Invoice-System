using BussinesLayer.Interfaces.Token;
using Jose;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace BusinessLayer.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Create(Dictionary<string, string> claims)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new Exception("Jwt:Key is missing"));
            var expiryInMinutes = double.Parse(_configuration["Jwt:ExpiryInMinutes"]!);

            var egyptTimezone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            var localTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, egyptTimezone);

            var payload = new Dictionary<string, object>();

            foreach (var kvp in claims)
            {
                if (kvp.Key == ClaimTypes.Role && kvp.Value.Contains(","))
                    payload[kvp.Key] = kvp.Value.Split(','); // roles as array
                else
                    payload[kvp.Key] = kvp.Value;
            }

            payload["exp"] = ((DateTimeOffset)localTime.AddMinutes(expiryInMinutes)).ToUnixTimeSeconds();
            payload["iss"] = _configuration["Jwt:Issuer"]!;
            payload["aud"] = _configuration["Jwt:Audience"]!;

            return JWT.Encode(payload, key, JweAlgorithm.DIR, JweEncryption.A256GCM);
        }

        public ClaimsPrincipal Validate(string token, out bool isExpired)
        {
            isExpired = false;

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new Exception("Jwt:Key is missing"));
            string json;

            try
            {
                json = JWT.Decode(token, key);
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Invalid token", ex);
            }

            var payload = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;

            // Check expiration
            if (payload.TryGetValue("exp", out var expVal))
            {
                var expUnix = Convert.ToInt64(expVal);
                var exp = DateTimeOffset.FromUnixTimeSeconds(expUnix).UtcDateTime;
                isExpired = DateTime.UtcNow > exp;
                if (isExpired)
                    throw new SecurityTokenExpiredException("Token has expired");
            }

            // Check issuer and audience
            if (payload["iss"]?.ToString() != _configuration["Jwt:Issuer"] ||
                payload["aud"]?.ToString() != _configuration["Jwt:Audience"])
            {
                throw new SecurityTokenException("Invalid issuer or audience");
            }

            // Convert claims
            var claims = new List<Claim>();
            foreach (var kvp in payload)
            {
                if (kvp.Key is "exp" or "iss" or "aud") continue;

                if (kvp.Value is JsonElement el && el.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in el.EnumerateArray())
                    {
                        claims.Add(new Claim(kvp.Key, item.GetString() ?? ""));
                    }
                }
                else
                {
                    claims.Add(new Claim(kvp.Key, kvp.Value?.ToString() ?? ""));
                }
            }

            var identity = new ClaimsIdentity(claims, "JWE");
            return new ClaimsPrincipal(identity);
        }
        public DateTime GetExpiration(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.ValidTo;
        }

    }
}
