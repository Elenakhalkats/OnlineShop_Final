using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entites;

public class ProductCategory
{
    [Required]
    [Key]
    public int ProductCategoryID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public Guid RowGuid { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }

    [Range(1, int.MaxValue)]
    public int? ParentProductCategoryID { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ProductCategory? ParentProductCategory { get; set; }
    public List<Product>? Products { get; set; }

}
