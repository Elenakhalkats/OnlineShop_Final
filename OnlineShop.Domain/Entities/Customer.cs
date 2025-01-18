using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entites;

public class Customer
{
    [Required]
    public int CustomerID { get; set; }

    [Required]
    public bool NameStyle { get; set; }

    [StringLength(8)]
    public string? Title { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(10)]
    public string? Suffix { get; set; }

    [StringLength(128)]
    public string? CompanyName { get; set; }

    [StringLength(256)]
    public string? SalesPerson { get; set; }

    [StringLength(50)]
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [StringLength(25)]
    [Phone]
    public string? Phone { get; set; }

    [Required]
    [StringLength(128)]
    public string PasswordHash { get; set; }

    [Required]
    [StringLength(10)]
    public string PasswordSalt { get; set; }

    [Required]
    public Guid RowGuid { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
