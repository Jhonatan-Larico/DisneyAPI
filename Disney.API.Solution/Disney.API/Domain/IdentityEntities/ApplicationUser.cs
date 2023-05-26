using Microsoft.AspNetCore.Identity;

namespace Disney.API.IdentyEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }    
    }
}
