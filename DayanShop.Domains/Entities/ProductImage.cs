using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public string ImagePath { get; set; }
    public string? AltAttr { get; set; }
    public string? TitleAttr { get; set; }
    public int? Height { get; set; }
    public int? width{ get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}