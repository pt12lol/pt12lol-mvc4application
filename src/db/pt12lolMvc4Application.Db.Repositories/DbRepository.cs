using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace pt12lolMvc4Application.Db.Repositories
{
    public class DbRepository<T> : IDbRepository<T> where T: class
    {
        readonly DbContext _dbContext;
        bool _disposed;
        
        public DbRepository()
        {
            _dbContext = new Entities();
            _disposed = false;
        }

        public DbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            T entity = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
