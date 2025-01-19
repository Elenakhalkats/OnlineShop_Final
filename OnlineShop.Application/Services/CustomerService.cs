using AutoMapper;
using OnlineShop.Application.Helpers;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Models.Customers;
using OnlineShop.Application.Models.Products;
using OnlineShop.Domain.Entites;
using OnlineShop.Infrastructure.Interfaces;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CustomerListViewModel>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        var customerViewModels = _mapper.Map<IEnumerable<CustomerListViewModel>>(customers);

        return customerViewModels;
    }
    public async Task<CustomerIndexPageViewModel> GetPagedCustomersAsync(int page)
    {
        var pageSize = 8;

        var totalCustomers = await _customerRepository.GetTotalCustomerCountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCustomers / pageSize);

        var cutomers = await _customerRepository.GetCustomersPagedAsync(page, pageSize);
        var cutomerViewModels = _mapper.Map<IEnumerable<CustomerListViewModel>>(cutomers).ToList();

        var viewModel = new CustomerIndexPageViewModel
        {
            Customers = cutomerViewModels,
            CurrentPage = page,
            TotalPages = totalPages,
            PageSize = pageSize
        };

        return viewModel;
    }
    public async Task<CustomerDetailsViewModel?> GetCustomerDetailsByIdAsync(int customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        var customerViewModel = _mapper.Map<CustomerDetailsViewModel>(customer);

        return customerViewModel;
    }
    public async Task<CustomerEditViewModel?> GetCustomerByIdAsync(int customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        var customerViewModel = _mapper.Map<CustomerEditViewModel>(customer);

        return customerViewModel;
    }
    public async Task UpdateCustomerAsync(CustomerEditViewModel model)
    {
        var customer = await _customerRepository.GetByIdAsync(model.CustomerID);

        customer.FirstName = model.FirstName;
        customer.MiddleName = model.MiddleName;
        customer.LastName = model.LastName;
        customer.Suffix = model.Suffix;
        customer.EmailAddress = model.EmailAddress;
        customer.Phone = model.Phone;
        customer.ModifiedDate = DateTime.Now;

        await _customerRepository.UpdateAsync(customer);
    }
    public async Task DeleteCustomerAsync(int customerId)
    {
        await _customerRepository.DeleteAsync(customerId);
    }
    public async Task AddCustomerAsync(CustomerCreateViewModel model)
    {
        var (hashedPassword, salt) = PasswordHelper.CreatePasswordHashAndSalt(model.Password);

        var customer = new Customer
        {
            CustomerID = model.CustomerID,
            NameStyle = model.NameStyle,
            Title = model.Title,
            FirstName = model.FirstName,
            MiddleName = model.MiddleName,
            LastName = model.LastName,
            Suffix = model.Suffix,
            CompanyName = model.CompanyName,
            SalesPerson = model.SalesPerson,
            EmailAddress = model.EmailAddress,
            Phone = model.Phone,
            PasswordHash = hashedPassword,
            PasswordSalt = salt,
            RowGuid = Guid.NewGuid(),
            ModifiedDate = DateTime.Now
        };

        await _customerRepository.AddAsync(customer);
    }
}
