using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entites;

public class Product
{
    [Required]
    public int ProductID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(25)]
    public string ProductNumber { get; set; }

    [StringLength(15)]
    public string? Color { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal StandardCost { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal ListPrice { get; set; }

    [StringLength(5)]
    public string? Size { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? Weight { get; set; }

    public int? ProductCategoryID { get; set; }

    public int? ProductModelID { get; set; }

    [Required]
    public DateTime SellStartDate { get; set; }

    public DateTime? SellEndDate { get; set; }

    public DateTime? DiscontinuedDate { get; set; }

    public byte[]? ThumbNailPhoto { get; set; }

    [StringLength(50)]
    public string? ThumbnailPhotoFileName { get; set; }

    [Required]
    public Guid RowGuid { get; set; } = Guid.NewGuid();

    [Required]
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ProductCategory ProductCategory { get; set; }
}
