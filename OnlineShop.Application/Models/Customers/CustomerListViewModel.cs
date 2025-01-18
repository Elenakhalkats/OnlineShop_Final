using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Models.Customers;

public class CustomerListViewModel
{
    [Required(ErrorMessage = "Customer ID is required.")]
    public int CustomerID { get; set; }

    [Required(ErrorMessage = "Name style is required.")]
    public bool NameStyle { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    public string LastName { get; set; }

    [StringLength(50, ErrorMessage = "Email address cannot be longer than 50 characters.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? EmailAddress { get; set; }

    [StringLength(25, ErrorMessage = "Phone number cannot be longer than 25 characters.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Modified date is required.")]
    public DateTime ModifiedDate { get; set; }
}
