using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<T> GetAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Get<T>(string id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync<T>(string id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
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
            return _context.Set<T>().Where(predicate).ToList();
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

        public async Task AddAsync<T>(T entity, bool commit = false) where T : class
        {
            await Task.Run(() => { Add<T>(entity, commit); });
        }

        public void AddRange<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            _context.Set<T>().AddRange(entities);

            if (commit)
                _context.SaveChanges();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            await Task.Run(() => { AddRange<T>(entities, commit); });
        }

        public void Update<T>(T entity, bool commit = false) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;

            _context.Entry(entity).Property("DataInclusao").IsModified = false;

            if (commit)
                _context.SaveChanges();
        }

        public async Task UpdateAsync<T>(T entity, bool commit = false) where T : class
        {
            await Task.Run(() => { Update<T>(entity, commit); });
        }

        public void UpdateRange<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).CurrentValues.SetValues(entity);

                _context.Entry(entity).Property("DataInclusao").IsModified = false;
            }

            if (commit)
                _context.SaveChanges();
        }

        public async Task UpdateRangeAsync<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            await Task.Run(() => { UpdateRange<T>(entities, commit); });
        }

        public void Remove<T>(T entity, bool commit = false) where T : class
        {
            _context.Set<T>().Remove(entity);

            if (commit)
                _context.SaveChanges();
        }

        public async Task RemoveAsync<T>(T entity, bool commit = false) where T : class
        {
            await Task.Run(() => { Remove<T>(entity, commit); });
        }

        public void Remove<T>(int id, bool commit = false) where T : class
        {
            Remove(Get<T>(id), commit);
        }

        public async Task RemoveAsync<T>(int id, bool commit = false) where T : class
        {
            await Task.Run(() => { Remove<T>(id, commit); });
        }

        public void Remove<T>(string id, bool commit = false) where T : class
        {
            Remove(Get<T>(id), commit);
        }

        public async Task RemoveAsync<T>(string id, bool commit = false) where T : class
        {
            await Task.Run(() => { Remove<T>(id, commit); });
        }

        public void RemoveRange<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            _context.Set<T>().RemoveRange(entities);

            if (commit)
                _context.SaveChanges();
        }

        public async Task RemoveRangeAsync<T>(IEnumerable<T> entities, bool commit = false) where T : class
        {
            await Task.Run(() => { RemoveRange<T>(entities, commit); });
        }

        public void RemoveAll<T>(Expression<Func<T, bool>> predicate, bool commit = false) where T : class
        {
            var recordsToRemove = _context.Set<T>().Where(predicate);

            RemoveRange(recordsToRemove, commit);
        }

        public async Task RemoveAllAsync<T>(Expression<Func<T, bool>> predicate, bool commit = false) where T : class
        {
            await Task.Run(() => { RemoveAll<T>(predicate, commit); });
        }
    }
}
