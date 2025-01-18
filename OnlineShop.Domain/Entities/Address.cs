using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entites;

public class Address
{
    [Required]
    public int AddressID { get; set; }

    [Required]
    [StringLength(60)]
    public string AddressLine1 { get; set; }

    [StringLength(60)]
    public string? AddressLine2 { get; set; }

    [Required]
    [StringLength(30)]
    public string City { get; set; }

    [Required]
    [StringLength(50)]
    public string StateProvince { get; set; }

    [Required]
    [StringLength(50)]
    public string CountryRegion { get; set; }

    [Required]
    [StringLength(15)]
    public string PostalCode { get; set; }

    [Required]
    public Guid RowGuid { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
