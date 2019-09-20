using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {
        private readonly CareHomeContext _dbContext;

        public AppRepository(CareHomeContext context)
        {
            _dbContext = context;
        }
        
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        
        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

         public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return entity;
        }
        
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> Search(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}