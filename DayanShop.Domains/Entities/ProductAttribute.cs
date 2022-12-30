using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class ProductAttribute
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    public int CategoryAttributeId { get; set; }
    [ForeignKey("CategoryAttributeId")]
    public CategoryAttribute CategoryAttribute { get; set; }


    public string AttrVal { get; set; }
}