using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        T Add(T entity);
        void Delete(T entity);
        Task<T> Search(Expression<Func<T, bool>> predicate);
        Task<bool> SaveAllAsync();
    }
}