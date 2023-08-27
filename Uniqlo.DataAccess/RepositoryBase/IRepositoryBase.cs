using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.DataAccess.RepositoryBase
{
    public interface IRepositoryBase<TEntity>
    where TEntity : class
    {
        void Add(TEntity Entity);
        void AddRange(List<TEntity> Entities);
        void Update(TEntity Entity);
        void DeleteBy<T>(T Id);
        void Delete(TEntity Entity);
        void DeleteRange(List<TEntity> Entities);
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> GetByIdAsync<T>(T Id);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> SaveAsync();

    }
}
