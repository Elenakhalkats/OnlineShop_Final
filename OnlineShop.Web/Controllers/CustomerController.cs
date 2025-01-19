using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Models.Customers;

namespace OnlineShop.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var model = await _customerService.GetPagedCustomersAsync(page);
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _customerService.AddCustomerAsync(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    public async Task<IActionResult> Details(int id)
    {
        var customer = await _customerService.GetCustomerDetailsByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CustomerEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _customerService.UpdateCustomerAsync(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerService.GetCustomerDetailsByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
