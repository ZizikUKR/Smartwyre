using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(string id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
