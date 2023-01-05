using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class Cart
{
    public long Id { get; set; }
    public string? UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public ICollection<CartItem> CartItems { get; set; }
    public long SumAmount { get; set; }
}


public class CartItem
{
    public long Id { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    public int Count { get; set; }
    public long Price { get; set; }
    public long CartId { get; set; }
    [ForeignKey("CartId")]
    public Cart Cart { get; set; }
}