using Microsoft.AspNetCore.Identity;

namespace AuthLib.Models
{
    public class User : IdentityUser
    {
        string Role { get; set; }
    }
}
