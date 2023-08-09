using Moq;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Factories.Interfaces;

namespace Smartwyre.DeveloperTest.Tests
{
    public class RebateServiceTestFixture
    {
        public Mock<IRebateRepository> MockRebateRepository { get; }
        public Mock<IProductRepository> MockProductRepository { get; }
        public Mock<IIncentiveCalculatorFactory> MockCalculatorFactory { get; }

        public RebateServiceTestFixture()
        {
            MockRebateRepository = new Mock<IRebateRepository>();
            MockProductRepository = new Mock<IProductRepository>();
            MockCalculatorFactory = new Mock<IIncentiveCalculatorFactory>();
        }
    }
}
