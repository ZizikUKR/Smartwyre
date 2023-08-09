using Smartwyre.DeveloperTest.Entities.Enums;

namespace Smartwyre.DeveloperTest.Types;

public class Product: BaseEntity
{
    public decimal Price { get; set; }
    public string Uom { get; set; }
    public SupportedIncentiveType SupportedIncentives { get; set; }
}
