using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll();
        Task <T> GetByIdAsync(T id,params Expression<Func<T, object>>[] includes);
        Task <T> GetAsync(T id);
        Task AddAsync(T entity);
        Task UpdateAsync(T id, T entity);
        Task DeleteAsync(T id);
        
    }
}
