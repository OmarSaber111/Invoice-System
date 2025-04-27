using System.Security.Claims;
namespace BussinesLayer.Interfaces.Token;

public interface ITokenService
{
    string Create(Dictionary<string, string> Claims);
    ClaimsPrincipal Validate(string Token, out bool IsExpired);
    DateTime GetExpiration(string token);
}
