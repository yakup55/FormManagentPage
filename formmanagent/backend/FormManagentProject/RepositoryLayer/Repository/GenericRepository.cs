using CoreLayer.Repository;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;
        private DbSet<TEntity> entities;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
          await entities.AddAsync(entity);
        }

        public  void DeleteAsync(TEntity entity)
        {
            entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {                                                                                       
        return await entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var one=await entities.FindAsync(id);
            if (one == null)
            {
              context.Entry(one).State= EntityState.Detached;
            }
            return one;
        }

        public TEntity UpdateAsync(TEntity entity)
        {
          context.Entry(entity).State= EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate);
        }
    }
}
