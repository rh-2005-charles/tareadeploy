using Microsoft.AspNetCore.Identity;

namespace ic_tienda_data.Sources.Data.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Provider { get; set; } // "Google", "Facebook", etc.
        public string? ProviderUserId { get; set; }
    }
}