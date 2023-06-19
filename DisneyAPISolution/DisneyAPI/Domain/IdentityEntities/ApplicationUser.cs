using Microsoft.AspNetCore.Identity;

namespace DisneyAPI.IdentyEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }    
    }
}
