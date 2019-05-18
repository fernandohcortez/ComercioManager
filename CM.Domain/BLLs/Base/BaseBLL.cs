using CM.Core.Base;
using CM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CM.Domain.BLLs.Base
{
    public abstract class BaseBLL<TDTO> : IBaseBLL<TDTO> where TDTO : class, IBaseDTO
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

            return Mapping.Mapper.Map<TDTO>(entity);
        }

        protected async Task<TDTO> GetAsync<TEntity>(int id) where TEntity : class
        {
            var entity = await ContextHelper.DbSet.GetAsync<TEntity>(id);

            return Mapping.Mapper.Map<TDTO>(entity);
        }

        protected TDTO Get<TEntity>(string id) where TEntity : class
        {
            var entity = ContextHelper.DbSet.Get<TEntity>(id);

            return Mapping.Mapper.Map<TDTO>(entity);
        }

        protected async Task<TDTO> GetAsync<TEntity>(string id) where TEntity : class
        {
            var entity = await ContextHelper.DbSet.GetAsync<TEntity>(id);

            return Mapping.Mapper.Map<TDTO>(entity);
        }

        protected IEnumerable<TDTO> GetAll<TEntity>() where TEntity : class
        {
            var listEntity = ContextHelper.DbSet.GetAll<TEntity>();

            return Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected async Task<IEnumerable<TDTO>> GetAllAsync<TEntity>() where TEntity : class
        {
            var listEntity = await ContextHelper.DbSet.GetAllAsync<TEntity>();

            return Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected IEnumerable<TDTO> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var listEntity = ContextHelper.DbSet.Find(predicate);

            return Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected async Task<IEnumerable<TDTO>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var listEntity = await ContextHelper.DbSet.FindAsync(predicate);

            return Mapping.Mapper.Map<IEnumerable<TDTO>>(listEntity);
        }

        protected TDTO Add<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            dto.DataInclusao = DateTime.Now;
            dto.DataAlteracao = DateTime.Now;

            var entity = Mapping.Mapper.Map<TEntity>(dto);

            ContextHelper.DbSet.Add(entity, commit);

            dto = Mapping.Mapper.Map<TDTO>(entity);

            return dto;
        }

        protected async Task<TDTO> AddAsync<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            dto.DataInclusao = DateTime.Now;
            dto.DataAlteracao = DateTime.Now;

            var entity = Mapping.Mapper.Map<TEntity>(dto);

            await ContextHelper.DbSet.AddAsync(entity, commit);

            dto = Mapping.Mapper.Map<TDTO>(entity);

            return dto;
        }

        protected internal void Add<TEntity>(TEntity entity, bool commit = false) where TEntity : class
        {
            var tipoEntity = entity.GetType();

            foreach (var propertyInfo in tipoEntity.GetProperties())
            {
                if (propertyInfo.Name == "DataInclusao" || propertyInfo.Name == "DataAlteracao")
                {
                    propertyInfo.SetValue(entity, DateTime.Now);
                }
            }

            ContextHelper.DbSet.Add(entity, commit);
        }

        protected void AddRange<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var lista = listDto.ToList();

            foreach (var dto in lista)
            {
                dto.DataInclusao = DateTime.Now;
                dto.DataAlteracao = DateTime.Now;
            }

            var listEntity = Mapping.Mapper.ProjectTo<TEntity>(lista.AsQueryable());

            ContextHelper.DbSet.AddRange(listEntity, commit);
        }

        protected async Task AddRangeAsync<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var lista = listDto.ToList();

            foreach (var dto in lista)
            {
                dto.DataInclusao = DateTime.Now;
                dto.DataAlteracao = DateTime.Now;
            }

            var listEntity = Mapping.Mapper.ProjectTo<TEntity>(lista.AsQueryable());

            await ContextHelper.DbSet.AddRangeAsync(listEntity, commit);
        }

        protected void Update<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            dto.DataAlteracao = DateTime.Now;

            var entity = Mapping.Mapper.Map<TEntity>(dto);

            ContextHelper.DbSet.Update(entity, commit);
        }

        protected async Task UpdateAsync<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            dto.DataAlteracao = DateTime.Now;

            var entity = Mapping.Mapper.Map<TEntity>(dto);

            await ContextHelper.DbSet.UpdateAsync(entity, commit);
        }

        protected void UpdateRange<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var lista = listDto.ToList();

            foreach (var dto in lista)
            {
                dto.DataAlteracao = DateTime.Now;
            }

            var listEntity = Mapping.Mapper.ProjectTo<TEntity>(lista.AsQueryable());

            ContextHelper.DbSet.UpdateRange(listEntity, commit);
        }

        protected async Task UpdateRangeAsync<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var lista = listDto.ToList();

            foreach (var dto in lista)
            {
                dto.DataAlteracao = DateTime.Now;
            }

            var listEntity = Mapping.Mapper.ProjectTo<TEntity>(lista.AsQueryable());

            await ContextHelper.DbSet.UpdateRangeAsync(listEntity, commit);
        }

        protected void Remove<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            var entity = Mapping.Mapper.Map<TEntity>(dto);

            ContextHelper.DbSet.Remove(entity, commit);
        }

        protected async Task RemoveAsync<TEntity>(TDTO dto, bool commit = false) where TEntity : class
        {
            var entity = Mapping.Mapper.Map<TEntity>(dto);

            await ContextHelper.DbSet.RemoveAsync(entity, commit);
        }

        protected void Remove<TEntity>(int id, bool commit = false) where TEntity : class
        {
            ContextHelper.DbSet.Remove<TEntity>(id, commit);
        }

        protected async Task RemoveAsync<TEntity>(int id, bool commit = false) where TEntity : class
        {
            await ContextHelper.DbSet.RemoveAsync<TEntity>(id, commit);
        }

        protected void Remove<TEntity>(string id, bool commit = false) where TEntity : class
        {
            ContextHelper.DbSet.Remove<TEntity>(id, commit);
        }

        protected async Task RemoveAsync<TEntity>(string id, bool commit = false) where TEntity : class
        {
            await ContextHelper.DbSet.RemoveAsync<TEntity>(id, commit);
        }

        protected void RemoveRange<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var listEntity = Mapping.Mapper.ProjectTo<TEntity>(listDto.AsQueryable());

            ContextHelper.DbSet.RemoveRange(listEntity, commit);
        }

        protected async Task RemoveRangeAsync<TEntity>(IEnumerable<TDTO> listDto, bool commit = false) where TEntity : class
        {
            var listEntity = Mapping.Mapper.ProjectTo<TEntity>(listDto.AsQueryable());

            await ContextHelper.DbSet.RemoveRangeAsync(listEntity, commit);
        }

        public abstract Task<TDTO> AddAsync(TDTO dto);

        public abstract Task<TDTO> GetAsync(object id);

        public abstract Task<IEnumerable<TDTO>> GetAllAsync();

        public abstract Task RemoveAsync(object id);

        public abstract Task UpdateAsync(TDTO dto);
    }
}
