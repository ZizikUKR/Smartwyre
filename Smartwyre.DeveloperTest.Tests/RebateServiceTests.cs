using Moq;
using Smartwyre.DeveloperTest.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Entities.Enums;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Views;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests
{
    public class RebateServiceTests : IClassFixture<RebateServiceTestFixture>
    {
        private readonly RebateService _rebateService;
        private readonly RebateServiceTestFixture _fixture;

        public RebateServiceTests(RebateServiceTestFixture fixture)
        {
            _fixture = fixture;

            // Initialize the RebateService with mock dependencies
            _rebateService = new RebateService(
                _fixture.MockRebateRepository.Object,
                _fixture.MockProductRepository.Object,
                _fixture.MockCalculatorFactory.Object);
        }

        [Fact]
        public async Task CalculateAsync_ShouldReturn_SuccessfulResult_WhenValidRequest()
        {
            // Arrange
            var mockCalculator = new Mock<IIncentiveCalculator>();
            mockCalculator.Setup(m => m.IsValid(It.IsAny<Rebate>(), It.IsAny<Product>(), It.IsAny<CalculateRebateRequest>())).Returns(true);

            _fixture.MockCalculatorFactory.Setup(m => m.CreateCalculator(It.IsAny<IncentiveType>())).Returns(mockCalculator.Object);

            var rebateId = "123";
            var mockRebate = new Rebate
            {
                Id = rebateId,
                Amount = 2,
                Percentage = 10,
            };
            _fixture.MockRebateRepository.Setup(m => m.GetAsync(rebateId)).ReturnsAsync(mockRebate);

            var productId = "456";
            var mockProduct = new Product
            {
                Id = productId,
                Price = 10,
            };
            _fixture.MockProductRepository.Setup(m => m.GetAsync(productId)).ReturnsAsync(mockProduct);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = rebateId,
                ProductIdentifier = productId
            };

            // Act
            var result = await _rebateService.CalculateAsync(request);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task CalculateAsync_ShouldThrowException_WhenRebateNotFound()
        {
            // Arrange
            _fixture.MockRebateRepository.Setup(m => m.GetAsync(It.IsAny<string>())).ReturnsAsync((Rebate)null);

            var request = new CalculateRebateRequest { /* set properties as needed */ };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _rebateService.CalculateAsync(request));
        }
    }
}
