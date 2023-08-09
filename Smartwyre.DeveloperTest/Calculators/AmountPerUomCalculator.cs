using Smartwyre.DeveloperTest.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Entities.Enums;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Views;

namespace Smartwyre.DeveloperTest.Calculators
{
    public class AmountPerUomCalculator : IIncentiveCalculator
    {
        public bool IsValid(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return rebate != null &&
                   product != null &&
                   product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom) &&
                   rebate.Amount != 0 &&
                   request.Volume != 0;
        }

        public decimal Calculate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return rebate.Amount * request.Volume;
        }
    }
}
