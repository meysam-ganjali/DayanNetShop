using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class ChildCategory
{
    public int Id { get; set; }

    [Display(Name = "عنوان دسته فرزند")]
    [Required(ErrorMessage = "عنوان دسته بندی مشخص نشده است")]
    [MaxLength(300)]
    public string ChildTitle { get; set; }
    [Display(Name = "عنوان دسته فرزند لاتین")]
    [MaxLength(300)]
    public string? ChildTitleSlug { get; set; }
    [Range(1, 100)]
    public int DisplayOrder { get; set; }
    public int ParentCategoryId { get; set; }
    [ForeignKey("ParentCategoryId")]
    public ParentCategory ParentCategory { get; set; }

    public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    public ICollection<Product> Products { get; set; }
}