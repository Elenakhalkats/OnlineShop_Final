using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Models.Products;

public class ProductListViewModel
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
    public decimal ListPrice { get; set; }
    [Required]
    public DateTime ModifiedDate { get; set; }
}