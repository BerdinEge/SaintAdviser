using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.DAL.Repositories.Abstract
{
    public interface IRepGeneric<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetAllQueryable(int timeout = 60);
        public TEntity Get(int id);
        public TEntity Insert(TEntity entity);
        public TEntity Update(TEntity entity);

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        public Task InsertAsync(TEntity entity);
    }
}
