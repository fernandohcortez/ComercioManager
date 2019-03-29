using CMDataModel.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CM.DataAccess.Repository.Base;
using CM.DataAccess.Repository.UnitOfWork;

namespace CM.WebApi.Controllers.Base
{
    [Authorize]
    public class ControllerBase<TEntity, TRepository, TIdType> : ApiController
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly IUnitOfWork UoW;

        protected TRepository Repository => (TRepository)UoW
            .GetType()
            .GetProperties()
            .First(m => m.PropertyType == typeof(TRepository))
            .GetValue(UoW);

        public ControllerBase()
        {
            UoW = UnitOfWork.CriarInstancia();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return Repository.GetAll();
        }

        public virtual TEntity Get(TIdType id)
        {
            if (typeof(TIdType) != typeof(string))
                return Repository.Get(int.Parse(id.ToString()));
            if (typeof(TIdType) != typeof(int))
                return Repository.Get(id.ToString());

            throw new Exception("Id deve ser do tipo [int] ou [string]");
        }

        public virtual void Post([FromBody]TEntity entity)
        {
            Repository.Add(entity, true);
        }

        public virtual void Put(int id, [FromBody]TEntity entity)
        {
            Repository.Update(entity, true);
        }

        public virtual void Delete(int id)
        {
            Repository.Remove(id, true);
        }
    }
}