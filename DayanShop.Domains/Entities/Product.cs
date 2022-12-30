using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ShowCount { get; set; }
    public long? OldPrice { get; set; }
    public long Price { get; set; }
    public int ChildCategoryId { get; set; }
    [ForeignKey("ChildCategoryId")]
    public ChildCategory ChildCategory { get; set; }
    public string ModelName { get; set; }
}