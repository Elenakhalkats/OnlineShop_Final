using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Models.Products;

public class ProductEditViewModel : BaseProductViewModel
{
    [Required(ErrorMessage = "Product ID is required.")]
    public int ProductID { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    [StringLength(50, ErrorMessage = "Product Name cannot be longer than 50 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product Number is required.")]
    [StringLength(25, ErrorMessage = "Product Number cannot be longer than 25 characters.")]
    public string ProductNumber { get; set; }

    [StringLength(15, ErrorMessage = "Color cannot be longer than 15 characters.")]
    public string? Color { get; set; }

    [Required(ErrorMessage = "Standard Cost is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Standard Cost must be a positive value.")]
    public decimal StandardCost { get; set; }

    [Required(ErrorMessage = "List Price is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "List Price must be a positive value.")]
    public decimal ListPrice { get; set; }

    [StringLength(5, ErrorMessage = "Size cannot be longer than 5 characters.")]
    public string? Size { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Weight must be a positive value.")]
    public decimal? Weight { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
}