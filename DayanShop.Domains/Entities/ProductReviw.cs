using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class ProductReviw 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImagePath { get; set; }
    public int? Height { get; set; }
    public int? width { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}