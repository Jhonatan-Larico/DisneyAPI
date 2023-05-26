using Disney.API.Dtos.Authentication;
using Disney.API.IdentyEntities;

namespace Disney.API.Services
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser user, string role);

    }
}
