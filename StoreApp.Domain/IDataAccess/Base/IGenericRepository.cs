using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.IDataAccess.Base
{
    public interface IGenericRepository<T> where T : AggregateEntity, IEntity
    {
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Update(T entity);
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAllWithDeleted();
        Task<T> GetById(Guid id);

        Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate);

    }
}
