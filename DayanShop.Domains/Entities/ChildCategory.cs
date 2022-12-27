using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayanShop.Domains.Entities;

public class ChildCategory
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "عنوان دسته فرزند")]
    [Required(ErrorMessage = "عنوان دسته بندی مشخص نشده است")]
    [MaxLength(300)]
    public string ParentTitle { get; set; }
    [Display(Name = "عنوان دسته فرزند لاتین")]
    [MaxLength(300)]
    public string? ParentTitleSlug { get; set; }
    [Range(1, 100)]
    public int DisplayOrder { get; set; }
    public int ParentCategoryId { get; set; }
    [ForeignKey("ParentCategoryId")]
    public ParentCategory ParentCategory { get; set; }
}