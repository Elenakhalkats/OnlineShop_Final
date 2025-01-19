using OnlineShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Models.ProductCategories;

public class ProductCategoryViewModel
{
    [Required]
    public int ProductCategoryID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
}