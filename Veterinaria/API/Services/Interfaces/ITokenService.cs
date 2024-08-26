using API.Model;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Interfaces
{
    public interface ITokenService
    {
        TokenModel CreateToken(IdentityUser user, List<string> roles);
    }
}
