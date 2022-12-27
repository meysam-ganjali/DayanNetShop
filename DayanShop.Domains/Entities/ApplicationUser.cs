using Microsoft.AspNetCore.Identity;

namespace DayanShop.Domains.Entities;

public class ApplicationUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserPhone { get; set; }
}