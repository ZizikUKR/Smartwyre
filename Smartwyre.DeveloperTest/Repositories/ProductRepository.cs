using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Repositories;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
}
