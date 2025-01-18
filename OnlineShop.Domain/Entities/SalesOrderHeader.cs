using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entites;

public class SalesOrderHeader
{
    [Required]
    [Key]
    public int SalesOrderID { get; set; }

    [Required]
    public byte RevisionNumber { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public DateTime? ShipDate { get; set; }

    [Required]
    public byte Status { get; set; }

    [Required]
    public bool OnlineOrderFlag { get; set; }

    [Required]
    [StringLength(50)]
    public string SalesOrderNumber { get; set; }

    [StringLength(25)]
    public string? PurchaseOrderNumber { get; set; }

    [StringLength(15)]
    public string? AccountNumber { get; set; }

    [Required]
    public int CustomerID { get; set; }

    public int? ShipToAddressID { get; set; }

    public int? BillToAddressID { get; set; }

    [StringLength(50)]
    public string ShipMethod { get; set; }

    [StringLength(15)]
    public string? CreditCardApprovalCode { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal SubTotal { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal TaxAmt { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Freight { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal TotalDue { get; set; }

    [StringLength(int.MaxValue)]
    public string? Comment { get; set; }

    [Required]
    public Guid RowGuid { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
