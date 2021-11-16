using Microsoft.EntityFrameworkCore;
using StoreApp.Domain.Entities;
using StoreApp.Domain.IDataAccess;
using StoreApp.Domain.IDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Repositories.Base
{
   
    public abstract class EntityRepository<T> : IGenericRepository<T> where T : AggregateEntity, IEntity
    {
        protected DbContext _dbContext;
        public EntityRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Add(T entity)
        {
            var saved = await _dbContext.AddAsync(entity);
            return saved != null;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null && !entity.IsDeleted)
            {
                entity.IsDeleted = true;
                return true;
            }
            return false;
        }


        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            var entities = await Task.Run(() => _dbContext.Set<T>().AsNoTracking().Where(d => !d.IsDeleted).Where(predicate));
            return entities;
        }

        public async Task<IQueryable<T>> GetAllWithDeleted()
        {
            var queryable = await Find(d => d.IsDeleted || !d.IsDeleted);
            return queryable;
        }
        public async Task<IQueryable<T>> GetAll()
        {
            var queryable = await Find(d => !d.IsDeleted);
            return queryable;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(d => !d.IsDeleted && d.Id == id);
        }


        public async Task<bool> Update(T entity)
        {
            var updatedentity = _dbContext.Set<T>().Update(entity);
            return updatedentity != null;
        }
    }
}
