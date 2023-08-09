using Smartwyre.DeveloperTest.Calculators;
using Smartwyre.DeveloperTest.Entities.Enums;
using Smartwyre.DeveloperTest.Factories;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class IncentiveCalculatorFactoryTests
    {
        [Fact]
        public void ShouldReturn_FixedCashAmountCalculator_WhenIncentiveTypeIs_FixedCashAmount()
        {
            // Arrange
            var factory = new IncentiveCalculatorFactory();

            // Act
            var calculator = factory.CreateCalculator(IncentiveType.FixedCashAmount);

            // Assert
            Assert.IsType<FixedCashAmountCalculator>(calculator);
        }

        [Fact]
        public void ShouldReturn_FixedRateRebateCalculator_WhenIncentiveTypeIs_FixedRateRebate()
        {
            // Arrange
            var factory = new IncentiveCalculatorFactory();

            // Act
            var calculator = factory.CreateCalculator(IncentiveType.FixedRateRebate);

            // Assert
            Assert.IsType<FixedRateRebateCalculator>(calculator);
        }

        [Fact]
        public void ShouldThrowArgumentException_WhenIncentiveTypeIs_Unknown()
        {
            // Arrange
            var factory = new IncentiveCalculatorFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateCalculator((IncentiveType)999));
        }
    }
}
