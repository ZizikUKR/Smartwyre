using Smartwyre.DeveloperTest.Calculators.Interfaces;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Factories.Interfaces;
using Smartwyre.DeveloperTest.Views;
using System;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateRepository _rebateRepository;
    private readonly IProductRepository _productRepository;
    private readonly IIncentiveCalculatorFactory _calculatorFactory;

    public RebateService(IRebateRepository rebateDataStore,
                         IProductRepository productDataStore,
                         IIncentiveCalculatorFactory calculatorFactory)
    {
        _rebateRepository = rebateDataStore;
        _productRepository = productDataStore;
        _calculatorFactory = calculatorFactory;
    }

    public async Task<CalculateRebateResult> CalculateAsync(CalculateRebateRequest request)
    {
        var rebate = await _rebateRepository.GetAsync(request.RebateIdentifier);
        if (rebate == null)
        {
            throw new ArgumentException($"Rebate with identifier {request.RebateIdentifier} not found.");
        }

        var product = await _productRepository.GetAsync(request.ProductIdentifier);
        if (product == null)
        {
            throw new ArgumentException($"Product with identifier {request.ProductIdentifier} not found.");
        }

        IIncentiveCalculator calculator = _calculatorFactory.CreateCalculator(rebate.Incentive);
        var result = new CalculateRebateResult();

        if (calculator.IsValid(rebate, product, request))
        {
            result.Success = true;
            result.RebateAmount = calculator.Calculate(rebate, product, request);
            await _rebateRepository.UpdateAsync(rebate);
        }
        else
        {
            result.Success = false;
        }

        return result;
    }
}
