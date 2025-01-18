using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entites;
using OnlineShop.Infrastructure.Interfaces;

namespace OnlineShop.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Product.Where(p => !p.IsDeleted).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Product.FirstOrDefaultAsync(p => p.ProductID == id && !p.IsDeleted);
    }
    public async Task<Product> GetByNameAsync(string name)
    {
        return await _context.Product.FirstOrDefaultAsync(p => p.Name.Trim() == name.Trim());
    }
    public async Task AddAsync(Product product)
    {
        await _context.Product.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product != null)
        {
            product.IsDeleted = true;
            await UpdateAsync(product);
        }
    }
}
