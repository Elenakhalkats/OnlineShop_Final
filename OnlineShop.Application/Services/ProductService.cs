using AutoMapper;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Models.ProductCategories;
using OnlineShop.Application.Models.Products;
using OnlineShop.Domain.Entites;
using OnlineShop.Infrastructure.Interfaces;

namespace OnlineShop.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        var productViewModels = _mapper.Map<IEnumerable<ProductListViewModel>>(products);

        return productViewModels;
    }
    public async Task<IEnumerable<ProductCategoryViewModel>> GetAllProductCategoriesAsync()
    {
        var productCategories = await _productRepository.GetAllCategoriesAsync();
        var productCategoriesViewModels = _mapper.Map<IEnumerable<ProductCategoryViewModel>>(productCategories);

        return productCategoriesViewModels;
    }
    public async Task<ProductIndexPageViewModel> GetPagedProductsAsync(int page)
    {
        var pageSize = 8;

        var totalProducts = await _productRepository.GetTotalProductCountAsync();
        var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

        var products = await _productRepository.GetProductsPagedAsync(page, pageSize);
        var productViewModels = _mapper.Map<IEnumerable<ProductListViewModel>>(products).ToList();

        var viewModel = new ProductIndexPageViewModel
        {
            Products = productViewModels,
            CurrentPage = page,
            TotalPages = totalPages,
            PageSize = pageSize
        };

        return viewModel;
    }
    public async Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        var productViewModel = _mapper.Map<ProductDetailsViewModel>(product);

        return productViewModel;
    }
    public async Task<ProductEditViewModel?> GetProductByIdAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        var productViewModel = _mapper.Map<ProductEditViewModel>(product);

        return productViewModel;
    }
    public async Task UpdateProductAsync(ProductEditViewModel viewModel)
    {
        var product = await _productRepository.GetByIdAsync(viewModel.ProductID);

        product.Name = viewModel.Name;
        product.ProductNumber = viewModel.ProductNumber;
        product.Color = viewModel.Color ?? product.Color;
        product.StandardCost = viewModel.StandardCost;
        product.ListPrice = viewModel.ListPrice;
        product.Size = viewModel.Size ?? product.Size;
        product.Weight = viewModel.Weight ?? product.Weight;
        product.SellStartDate = viewModel.SellStartDate;
        product.SellEndDate = viewModel.SellEndDate ?? product.SellEndDate;
        product.DiscontinuedDate = viewModel.DiscontinuedDate ?? product.DiscontinuedDate;
        product.ModifiedDate = DateTime.Now;
        product.ProductCategoryID = viewModel.ProductCategoryID;

        await _productRepository.UpdateAsync(product);
    }
    public async Task DeleteProductAsync(int productId)
    {
        await _productRepository.DeleteAsync(productId);
    }
    public async Task AddProductAsync(ProductCreateViewModel model)
    {
        var product = new Product
        {
            Name = model.Name,
            ProductNumber = model.ProductNumber,
            Color = model.Color,
            StandardCost = model.StandardCost,
            ListPrice = model.ListPrice,
            Size = model.Size,
            Weight = model.Weight,
            SellStartDate = model.SellStartDate,
            SellEndDate = model.SellEndDate,
            DiscontinuedDate = model.DiscontinuedDate,
            ModifiedDate = DateTime.Now
        };

        await _productRepository.AddAsync(product);
    }
    public async Task<bool> IsUniqueName(string name)
    {
        var product = await _productRepository.GetByNameAsync(name);
        return product == null;
    }
    public async Task<bool> IsUniqueProductNumber(string productNumber)
    {
        var product = await _productRepository.GetByProductNumberAsync(productNumber);
        return product == null;
    }
}