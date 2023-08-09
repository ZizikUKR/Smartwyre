using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Views;

namespace Smartwyre.DeveloperTest.Calculators.Interfaces
{
    public interface IIncentiveCalculator
    {
        bool IsValid(Rebate rebate, Product product, CalculateRebateRequest request);
        decimal Calculate(Rebate rebate, Product product, CalculateRebateRequest request);
    }
}
