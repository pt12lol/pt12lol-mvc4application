using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using pt12lolMvc4Application.Db.Models;

namespace pt12lolMvc4Application.Db.Repositories
{
    public class DbRepository<T> : IDbRepository<T> where T: class, IDbModel
    {
        readonly Entities _dbEntities;
        bool _disposed;
        
        public DbRepository()
        {
            _dbEntities = new Entities();
            _disposed = false;
        }

        public T Get(int id)
        {
            return _dbEntities.Set<T>().Find(id);
        }

        public IQueryable<T> Get()
        {
            return _dbEntities.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbEntities.Set<T>().Where(predicate);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbEntities.Set<T>().FindAsync(id);
        }

        public void Insert(T entity)
        {
            _dbEntities.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbEntities.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            T entity = _dbEntities.Set<T>().Find(id);
            _dbEntities.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _dbEntities.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbEntities.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbEntities.Dispose();
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
