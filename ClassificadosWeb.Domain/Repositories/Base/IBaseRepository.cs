using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ClassificadosWeb.Domain.Entities;

namespace ClassificadosWeb.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<TEntity> FindOneBy(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> ListBy(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy = null, bool asc = true, int limit = 0);
        Task<List<TEntity>> ListByArray(Expression<Func<TEntity, IEnumerable<string>>> where, string field, Expression<Func<TEntity, object>> orderBy = null, bool asc = true, int limit = 0);
    }
}