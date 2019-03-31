using CM.Core.Base;
using CM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CM.Domain.BLL.Base
{
    public abstract class BaseBLL<TDTO> : IBaseBLL<TDTO> where TDTO : IBaseDTO
    {
        protected readonly ContextHelper ContextHelper;

        protected BaseBLL(ContextHelper contextHelper)
        {
            ContextHelper = contextHelper;
        }

        protected BaseBLL()
        {
            ContextHelper = ContextHelper.CriarInstancia();
        }

        protected TDTO Get<TEntity>(int id) where TEntity : class
        {
            var entity = ContextHelper.DbSet.Get<TEntity>(id);

            return Mapping.Mapping.Mapper.Map<TDTO>(entity);
        }

        protected TDTO Get<TEntity>(string id) where TEntity : class
        {
            var entity = ContextHelper.DbSet.Get<TEntity>(id);

            return Mapping.Mapping.Mapper.Map<TDTO>(entity);
        }

        protected IEnumerable<TDTO> GetAll<TEntity>() where TEntity : class
        {
            var listEntity = ContextHelper.DbSet.GetAll<TEntity>();

            return Mapping.Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected async Task<IEnumerable<TDTO>> GetAllAsync<TEntity>() where TEntity : class
        {
            var listEntity = await ContextHelper.DbSet.GetAllAsync<TEntity>();

            return Mapping.Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected IEnumerable<TDTO> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var listEntity = ContextHelper.DbSet.Find(predicate);

            return Mapping.Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected async Task<IEnumerable<TDTO>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var listEntity = await ContextHelper.DbSet.FindAsync(predicate);

            return Mapping.Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected void Add<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            dto.DataInclusao = DateTime.Now;
            dto.DataAlteracao = DateTime.Now;

            var entity = Mapping.Mapping.Mapper.Map<TEntity>(dto);

            ContextHelper.DbSet.Add(entity, commit);
        }

        protected void AddRange<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var listEntity = Mapping.Mapping.Mapper.ProjectTo<TEntity>(listDto.AsQueryable());

            ContextHelper.DbSet.AddRange(listEntity, commit);
        }

        protected void Update<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            var entity = Mapping.Mapping.Mapper.Map<TEntity>(dto);

            ContextHelper.DbSet.Update(entity, commit);
        }

        protected void UpdateRange<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var listEntity = Mapping.Mapping.Mapper.ProjectTo<TEntity>(listDto.AsQueryable());

            ContextHelper.DbSet.UpdateRange(listEntity, commit);
        }

        protected void Remove<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            var entity = Mapping.Mapping.Mapper.Map<TEntity>(dto);

            ContextHelper.DbSet.Remove(entity, commit);
        }

        protected void Remove<TEntity>(int id, bool commit = false) where TEntity : class
        {
            ContextHelper.DbSet.Remove<TEntity>(id, commit);
        }

        protected void Remove<TEntity>(string id, bool commit = false) where TEntity : class
        {
            ContextHelper.DbSet.Remove<TEntity>(id, commit);
        }

        protected void RemoveRange<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var listEntity = Mapping.Mapping.Mapper.ProjectTo<TEntity>(listDto.AsQueryable());

            ContextHelper.DbSet.RemoveRange(listEntity, commit);
        }

        public abstract void Add(TDTO dto);

        public abstract TDTO Get(object id);

        public abstract IEnumerable<TDTO> GetAll();

        public abstract void Remove(object id);

        public abstract void Update(TDTO dto);
    }
}
