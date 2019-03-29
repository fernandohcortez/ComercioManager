using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMDataModel.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Get(string id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity, bool commit = false);
        void AddRange(IEnumerable<T> entities, bool commit = false);

        void Update(T entity, bool commit = false);
        void UpdateRange(IEnumerable<T> entities, bool commit = false);

        void Remove(T entity, bool commit = false);
        void Remove(int id, bool commit = false);
        void Remove(string id, bool commit = false);
        void RemoveRange(IEnumerable<T> entities, bool commit = false);
    }
}
