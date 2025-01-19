using OnlineShop.Application.Models.ProductCategories;
using OnlineShop.Application.Models.Products;
using OnlineShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync();
    Task<IEnumerable<ProductCategoryViewModel>> GetAllProductCategoriesAsync();
    Task<ProductIndexPageViewModel> GetPagedProductsAsync(int page);
    Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(int productId);
    Task<ProductEditViewModel?> GetProductByIdAsync(int productId);
    Task UpdateProductAsync(ProductEditViewModel product);
    Task DeleteProductAsync(int productId);
    Task AddProductAsync(ProductCreateViewModel product);
    Task<bool> IsUniqueName(string name);
    Task<bool> IsUniqueProductNumber(string ProductNumbername);
}
