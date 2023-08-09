using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Views;
using System;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter Rebate Identifier:");
            string rebateId = Console.ReadLine();

            Console.WriteLine("Enter Product Identifier:");
            string productId = Console.ReadLine();

            var rebateRepo = new RebateRepository();
            var productRepo = new ProductRepository();
            var calculatorFactory = new IncentiveCalculatorFactory();

            var rebateService = new RebateService(rebateRepo, productRepo, calculatorFactory);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = rebateId,
                ProductIdentifier = productId
            };

            var result = await rebateService.CalculateAsync(request);

            if (result.Success)
            {
                Console.WriteLine($"Rebate calculation successful! Amount: {result.RebateAmount}");
            }
            else
            {
                Console.WriteLine("Rebate calculation failed.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.ReadKey();
    }
}
