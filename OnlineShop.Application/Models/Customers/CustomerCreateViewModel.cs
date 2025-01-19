using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Models.Customers;

public class CustomerCreateViewModel
{
    [Required(ErrorMessage = "Customer ID is required.")]
    public int CustomerID { get; set; }

    [Required(ErrorMessage = "Name style is required.")]
    public bool NameStyle { get; set; }

    [StringLength(8, ErrorMessage = "Title cannot be longer than 8 characters.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    public string FirstName { get; set; }

    [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    public string LastName { get; set; }

    [StringLength(10, ErrorMessage = "Suffix cannot be longer than 10 characters.")]
    public string? Suffix { get; set; }

    [StringLength(128, ErrorMessage = "Company name cannot be longer than 128 characters.")]
    public string? CompanyName { get; set; }

    [StringLength(256, ErrorMessage = "Sales person name cannot be longer than 256 characters.")]
    public string? SalesPerson { get; set; }

    [StringLength(50, ErrorMessage = "Email address cannot be longer than 50 characters.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? EmailAddress { get; set; }

    [StringLength(25, ErrorMessage = "Phone number cannot be longer than 25 characters.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }

    //[Required(ErrorMessage = "Password hash is required.")]
    //[StringLength(128, ErrorMessage = "Password hash cannot be longer than 128 characters.")]
    //public string PasswordHash { get; set; }

    //[Required(ErrorMessage = "Password salt is required.")]
    //[StringLength(10, ErrorMessage = "Password salt cannot be longer than 10 characters.")]
    //public string PasswordSalt { get; set; }
}
