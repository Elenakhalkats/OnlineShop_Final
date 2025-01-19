namespace OnlineShop.Application.Models.Customers;

public class CustomerIndexPageViewModel
{
    public List<CustomerListViewModel> Customers { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
}
