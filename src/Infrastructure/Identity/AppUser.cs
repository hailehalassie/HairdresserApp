using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{ 
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}