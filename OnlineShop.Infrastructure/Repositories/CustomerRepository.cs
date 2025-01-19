using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entites;
using OnlineShop.Infrastructure.Interfaces;

namespace OnlineShop.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customer.Where(p => !p.IsDeleted).ToListAsync();
    }
    public async Task<List<Customer>> GetCustomersPagedAsync(int page, int pageSize)
    {
        return await _context.Customer
                             .Where(p => !p.IsDeleted)
                             .OrderBy(p => p.FirstName)
                             .Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }
    public async Task<int> GetTotalCustomerCountAsync()
    {
        return await _context.Customer.Where(p => !p.IsDeleted).CountAsync();
    }
    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customer.FirstOrDefaultAsync(p => p.CustomerID == id && !p.IsDeleted);
    }
    public async Task AddAsync(Customer customer)
    {
        await _context.Customer.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customer.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await _context.Customer.FindAsync(id);
        if (customer != null)
        {
            customer.IsDeleted = true;
            await UpdateAsync(customer);
        }
    }
}
