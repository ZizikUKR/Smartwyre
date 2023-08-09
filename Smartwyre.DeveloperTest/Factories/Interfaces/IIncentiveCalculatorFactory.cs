using Smartwyre.DeveloperTest.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Entities.Enums;

namespace Smartwyre.DeveloperTest.Factories.Interfaces
{
    public interface IIncentiveCalculatorFactory
    {
        IIncentiveCalculator CreateCalculator(IncentiveType incentiveType);
    }
}
