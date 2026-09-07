using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T> where T:class,IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> GetByQuery(Expression<Func<T,bool>>expression);

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
