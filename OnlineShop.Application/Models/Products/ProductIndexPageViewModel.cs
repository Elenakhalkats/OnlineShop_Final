namespace OnlineShop.Application.Models.Products;

public class ProductIndexPageViewModel
{
    public List<ProductListViewModel> Products { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
}
