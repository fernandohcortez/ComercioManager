using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CM.DataAccess
{
    public class DbSetHelper
    {
        private readonly DbContext _context;

        public DbSetHelper(DbContext context)
        {
            _context = context;
        }

        public T Get<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public T Get<T>(string id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Add<T>(T entity, bool commit = false) where T : class
        {
            _context.Set<T>().Add(entity);

            if (commit)
                _context.SaveChanges();
        }

        public void AddRange<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            _context.Set<T>().AddRange(entities);

            if (commit)
                _context.SaveChanges();
        }

        public void Update<T>(T entity, bool commit = false) where T : class
        {
            //Ignorar
        }

        public void UpdateRange<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            //Ignorar
        }

        public void Remove<T>(T entity, bool commit = false) where T : class
        {
            _context.Set<T>().Remove(entity);

            if (commit)
                _context.SaveChanges();
        }

        public void Remove<T>(int id, bool commit = false) where T : class
        {
            Remove(Get<T>(id), commit);
        }

        public void Remove<T>(string id, bool commit = false) where T : class
        {
            Remove(Get<T>(id), commit);
        }

        public void RemoveRange<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            _context.Set<T>().RemoveRange(entities);

            if (commit)
                _context.SaveChanges();
        }
    }
}
