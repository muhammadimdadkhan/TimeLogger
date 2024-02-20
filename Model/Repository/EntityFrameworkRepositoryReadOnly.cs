using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Database;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class EntityFrameworkRepositoryReadOnly : IRepositoryReadOnly
    {
        private readonly TimeLoggerContext _DbContext;

        public EntityFrameworkRepositoryReadOnly(TimeLoggerContext context)
        {
            _DbContext = context;
        }

        public async Task<IEnumerable<T>> GetMultipleResultAsync<T>(string[] includes = null) where T : class
        {

            IQueryable<T> result = _DbContext.Set<T>();

            if (includes != null)
                foreach (var item in includes)
                {
                    result = result.Include<T>(item);
                }

            var result2 = await result.ToListAsync().ConfigureAwait(false);

            return result2;
        }

        public virtual async Task<IEnumerable<T>> GetModelAsync<T>() where T : class
        {
            return await _DbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetModelAsync<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            if (filter != null)
                return await _DbContext.Set<T>().Where(filter).ToListAsync();
            return await _DbContext.Set<T>().ToListAsync();
        }
        public virtual IQueryable<T> GetQueryable<T>() where T : class
        {
            return _DbContext.Set<T>();
        }
        public virtual IQueryable<T> GetQueryableWithOutTracking<T>() where T : class
        {
            return _DbContext.Set<T>().AsNoTracking();
        }
        public virtual IQueryable<T> GetQueryableWithOutTracking<T>(IList<string> includes = null, Expression<Func<T, bool>> filter = null) where T : class
        {
            IQueryable<T> queryable = _DbContext.Set<T>().AsNoTracking();

            if (filter != null)
                queryable = queryable.Where(filter);
            if (includes != null && queryable.Any())
                foreach (var item in includes)
                {
                    queryable = queryable.Include(item);
                }
            return queryable;
        }


        public virtual async Task<T> GetModelByIdAsync<T>(int modelId) where T : class
        {
            return await _DbContext.Set<T>().FindAsync(modelId);
        }
        public virtual async Task<T> GetModelByIdAsync<T>(string modelId) where T : class
        {
            return await _DbContext.Set<T>().FindAsync(modelId);
        }
        public async Task<IEnumerable<T>> CheckNumber<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            if (filter != null)
            {
                return await _DbContext.Set<T>().Where(filter).ToListAsync();
            }
            return await _DbContext.Set<T>().ToListAsync();
        }
        public IQueryable<T> GetReportQueryable<T>(IList<string> includes = null, Expression<Func<T, bool>> filter = null) where T : class
        {
            IQueryable<T> queryable = _DbContext.Set<T>();

            if (filter != null)
                queryable = queryable.Where(filter);
            if (includes != null && queryable.Any())
                foreach (var item in includes)
                {
                    queryable = queryable.Include(item);
                }
            return queryable;
        }


    }
}
