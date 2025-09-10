using Microsoft.AspNetCore.Identity;

namespace TravelApp_DotnetMVC.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Comment>? Comments { get; private set; }
}