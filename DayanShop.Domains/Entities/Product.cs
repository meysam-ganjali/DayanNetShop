using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    public int ShowCount { get; set; }
    public long? OldPrice { get; set; }
    public long Price { get; set; }
    public bool ShowDiscountLable { get; set; } = false;
    public int? Percentage { get; set; }
    public int ChildCategoryId { get; set; }
    public bool ProductSpecial { get; set; } = false;
    public int Count { get; set; }
    public int Rate { get; set; } = 0;
    [ForeignKey("ChildCategoryId")]
    public ChildCategory ChildCategory { get; set; }
    public string ModelName { get; set; }
    public string Description { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; }
    public ICollection<ProductReviw> ProductReviws { get; set; }
    public ICollection<ProductAttribute> ProductAttributes { get; set; }
}