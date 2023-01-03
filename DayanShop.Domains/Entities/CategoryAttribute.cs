using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class CategoryAttribute
{
    public int Id { get; set; }
    public int ChildCategoryId { get; set; }
    [ForeignKey("ChildCategoryId")]
    public ChildCategory ChildCategory { get; set; }
    [Required(ErrorMessage ="وارد کردن عنوان ویژگی اجباری است")]
    [MaxLength(500,ErrorMessage = "تعداد حروف مجاز 500 کاراکتر کی باشد")]
    public string AttributeTitle { get; set; }

    public ICollection<ProductAttribute> ProductAttributes { get; set; }
}