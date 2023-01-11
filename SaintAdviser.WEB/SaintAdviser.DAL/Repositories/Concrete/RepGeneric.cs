using Microsoft.EntityFrameworkCore;
using SaintAdviser.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.DAL.Repositories.Concrete
{
    public class RepGeneric<TEntity> : IRepGeneric<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public RepGeneric(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        protected DbContext DbContext
        {
            get { return _dbContext; }
        }

        public TEntity Get(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAllQueryable(int timeout = 60)
        {
            //DbContext.Database.CommandTimeout = timeout;
            return DbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbContext.Set<TEntity>().FindAsync(filter);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            Save();
        }

        public TEntity Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            Save();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
            Save();
            return entity;
        }
        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
