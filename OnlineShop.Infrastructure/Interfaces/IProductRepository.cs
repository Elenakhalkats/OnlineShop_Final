using OnlineShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync();
    Task<List<Product>> GetProductsPagedAsync(int page, int pageSize);
    Task<int> GetTotalProductCountAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> GetByNameAsync(string name);
    Task<Product> GetByProductNumberAsync(string name);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
