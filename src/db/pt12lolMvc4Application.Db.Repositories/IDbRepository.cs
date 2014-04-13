using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace pt12lolMvc4Application.Db.Repositories
{
    public interface IDbRepository<T> : IDisposable where T: class
    {
        T Get(int id);
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(int id);
        void Save();
        Task SaveAsync();
    }
}
