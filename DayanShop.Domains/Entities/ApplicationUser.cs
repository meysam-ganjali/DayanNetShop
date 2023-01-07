using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DayanShop.Domains.Entities;

public class ApplicationUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserPhone { get; set; }
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<UserAddress> UserAddresses { get; set; }
}

public class UserAddress
{
    public int Id { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }
    public string Address { get; set; }
}