using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMDataModel.Repository.Base
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : class
    {
        private readonly DbContext _context;

        protected TContext Context => _context as TContext;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Get(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            //eee/EntityState ocorrendo erro no get all, provavelmente// ao carregar as tabelas relacionadas.
            //_context.Configuration.LazyLoadingEnabled = true;

            
            // aqui está a arquitetura que devo implementar. renomeie tudo da formaque está ali... 
            //Tb considere deixar de lado o padrao repositorio e unitofwork, pois o EF já implementa eles. 
            https://stackoverflow.com/questions/48052686/should-i-use-dto-interfaces-in-a-web-api
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Add(TEntity entity, bool commit = false)
        {
            _context.Set<TEntity>().Add(entity);

            if (commit)
                _context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities, bool commit = false)
        {
            _context.Set<TEntity>().AddRange(entities);

            if (commit)
                _context.SaveChanges();
        }

        public void Update(TEntity entity, bool commit = false)
        {
            //Ignorar
        }

        public void UpdateRange(IEnumerable<TEntity> entities, bool commit = false)
        {
            //Ignorar
        }

        public void Remove(TEntity entity, bool commit = false)
        {
            _context.Set<TEntity>().Remove(entity);

            if (commit)
                _context.SaveChanges();
        }

        public void Remove(int id, bool commit = false)
        {
            Remove(Get(id), commit);
        }

        public void Remove(string id, bool commit = false)
        {
            Remove(Get(id), commit);
        }

        public void RemoveRange(IEnumerable<TEntity> entities, bool commit = false)
        {
            _context.Set<TEntity>().RemoveRange(entities);

            if (commit)
                _context.SaveChanges();
        }
    }
}
