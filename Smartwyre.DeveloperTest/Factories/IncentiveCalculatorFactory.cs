using Smartwyre.DeveloperTest.Calculators;
using Smartwyre.DeveloperTest.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Entities.Enums;
using Smartwyre.DeveloperTest.Factories.Interfaces;
using System;

namespace Smartwyre.DeveloperTest.Factories
{
    public class IncentiveCalculatorFactory : IIncentiveCalculatorFactory
    {
        public IIncentiveCalculator CreateCalculator(IncentiveType incentiveType)
        {
            return incentiveType switch
            {
                IncentiveType.FixedCashAmount => new FixedCashAmountCalculator(),
                IncentiveType.FixedRateRebate => new FixedRateRebateCalculator(),
                IncentiveType.AmountPerUom => new AmountPerUomCalculator(),
                _ => throw new ArgumentException($"Unsupported incentive type: {incentiveType}")
            };
        }
    }
}
