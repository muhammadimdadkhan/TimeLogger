using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IRepositoryReadOnly
    {
        Task<IEnumerable<T>> GetModelAsync<T>() where T : class;
        Task<IEnumerable<T>> GetModelAsync<T>(Expression<Func<T, bool>> filter = null) where T : class;
        IQueryable<T> GetQueryable<T>() where T : class;
        IQueryable<T> GetQueryableWithOutTracking<T>() where T : class;
        IQueryable<T> GetQueryableWithOutTracking<T>(IList<string> includes = null, Expression<Func<T, bool>> filter = null) where T : class;
        Task<IEnumerable<T>> GetMultipleResultAsync<T>(string[] includes = null) where T : class;
        Task<T> GetModelByIdAsync<T>(int modelId) where T : class;
        Task<T> GetModelByIdAsync<T>(string modelId) where T : class;
    }
}
