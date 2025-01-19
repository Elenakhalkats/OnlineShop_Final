using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Models.Products;

public class ProductCreateViewModel : BaseProductViewModel
{
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; }

    [Required]
    [StringLength(25, ErrorMessage = "Product number cannot be longer than 25 characters.")]
    public string ProductNumber { get; set; }

    [StringLength(15, ErrorMessage = "Color cannot be longer than 15 characters.")]
    public string? Color { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Standard cost must be a positive value.")]
    public decimal StandardCost { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "List price must be a positive value.")]
    public decimal ListPrice { get; set; }

    [StringLength(5, ErrorMessage = "Size cannot be longer than 5 characters.")]
    public string? Size { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Weight must be a positive value.")]
    public decimal? Weight { get; set; }

    public DateTime? DiscontinuedDate { get; set; }
    public int? ProductCategoryID { get; set; }
}
