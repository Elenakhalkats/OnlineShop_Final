using OnlineShop.Application.Models.Customers;
using OnlineShop.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerListViewModel>> GetAllCustomersAsync();
    Task<CustomerDetailsViewModel?> GetCustomerDetailsByIdAsync(int customerId);
    Task<CustomerEditViewModel?> GetCustomerByIdAsync(int customerId);
    Task UpdateCustomerAsync(CustomerEditViewModel customer);
    Task DeleteCustomerAsync(int customerId);
    Task AddCustomerAsync(CustomerCreateViewModel customer);
}
