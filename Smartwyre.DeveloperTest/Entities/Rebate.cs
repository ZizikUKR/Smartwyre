using Smartwyre.DeveloperTest.Entities.Enums;

namespace Smartwyre.DeveloperTest.Types;

public class Rebate: BaseEntity
{
    public IncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
}
