using Smartwyre.DeveloperTest.Repositories.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Repositories
{
    //TODO Implement EF or Dapper here to access DB
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _store = new List<T>();

        public async Task<T> GetAsync(string id)
        {
            return await Task.FromResult(_store.FirstOrDefault(e => e.Id == id));
        }

        public async Task AddAsync(T entity)
        {
            _store.Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            var existing = await GetAsync(entity.Id);
            if (existing != null)
            {
                _store.Remove(existing);
                _store.Add(entity);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _store.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
