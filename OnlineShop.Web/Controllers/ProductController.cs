﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Models.Products;
using OnlineShop.Domain.Entites;

namespace OnlineShop.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var model = await _productService.GetPagedProductsAsync(page);
        return View(model);
    }
    public async Task<IActionResult> Create()
    {
        var categories = await _productService.GetAllProductCategoriesAsync();
        ViewBag.ProductCategories = new SelectList(categories, "ProductCategoryID", "Name");

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var isNameUnique = await _productService.IsUniqueName(model.Name);
            if (!isNameUnique)
            {
                ModelState.AddModelError("Name", "The product name must be unique.");
                return View(model);
            }

            var isProductNumberUnique = await _productService.IsUniqueProductNumber(model.ProductNumber);
            if (!isProductNumberUnique)
            {
                ModelState.AddModelError("ProductNumber", "The product number must be unique.");
                return View(model);
            }
            await _productService.AddProductAsync(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetProductDetailsByIdAsync(id);
        if (product == null) return NotFound();

        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();

        var categories = await _productService.GetAllProductCategoriesAsync();
        ViewBag.ProductCategories = new SelectList(categories, "ProductCategoryID", "Name", product.ProductCategoryID);

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductEditViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _productService.UpdateProductAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetProductDetailsByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
