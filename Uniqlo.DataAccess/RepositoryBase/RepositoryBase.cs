using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Context;

namespace Uniqlo.DataAccess.RepositoryBase
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly UniqloContext _context;
        public RepositoryBase(UniqloContext context)
        {
            _context = context;
        }
        public void Add(TEntity Entity)
        {
            _context.Set<TEntity>().Add(Entity);
        }

        public void AddRange(List<TEntity> Entities)
        {
            _context.Set<TEntity>().AddRange(Entities);
        }

        public void DeleteBy<T>(T Id)
        {
            TEntity Entity = _context.Set<TEntity>().Find(Id);

            if (Entity != null)
            {
                _context.Set<TEntity>().Remove(Entity);
            }
        }

        public void Delete(TEntity Entity)
        {
            _context.Set<TEntity>().Remove(Entity);
        }

        public void DeleteRange(List<TEntity> Entities)
        {
            _context.Set<TEntity>().RemoveRange(Entities);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> GetByIdAsync<T>(T Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public void Update(TEntity Entity)
        {
            _context.Set<TEntity>().Update(Entity);
        }
    }
}
