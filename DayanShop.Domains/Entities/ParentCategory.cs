using System.ComponentModel.DataAnnotations;

namespace DayanShop.Domains.Entities;

public class ParentCategory 
{
    public int Id { get; set; }
    [Display(Name = "عنوان دسته پدر")]
    [Required(ErrorMessage = "عنوان دسته بندی مشخص نشده است")]
    [MaxLength(300)]
    public string ParentTitle { get; set; }
    [Display(Name = "عنوان دسته پدر لاتین")]
    [MaxLength(300)]
    public string? ParentTitleSlug { get; set; }
    [Range(1,100)]
    public int DisplayOrder { get; set; }
    public ICollection<ChildCategory> ChildCategories { get; set; }
}