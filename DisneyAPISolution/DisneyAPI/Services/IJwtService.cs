using DisneyAPI.Dtos.Authentication;
using DisneyAPI.IdentyEntities;

namespace DisneyAPI.Services
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser user, string role);

    }
}
