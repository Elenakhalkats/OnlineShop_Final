using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Models.Products;

public abstract class BaseProductViewModel : IValidatableObject
{
    [Required]
    public DateTime SellStartDate { get; set; }

    public DateTime? SellEndDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SellEndDate.HasValue && SellEndDate.Value < SellStartDate)
        {
            yield return new ValidationResult(
                "SellEndDate must be greater than or equal to SellStartDate.",
                new[] { nameof(SellEndDate) }
            );
        }
    }
}