﻿using CM.Core.Base;
using System;
using System.Collections.Generic;
using System.Web.Http;
using CM.Domain.BLLs.Base;

namespace CM.WebApi.Controllers.Base
{
    [Authorize]
    public class ControllerBase<TDTO, TBLL, TIdType> : ApiController
        where TDTO : class, IBaseDTO
        where TBLL : class, IBaseBLL<TDTO>
    {
        protected TBLL BLL { get; }

        public ControllerBase()
        {
            BLL = Activator.CreateInstance<TBLL>();
        }

        public virtual IEnumerable<TDTO> Get()
        {
            return BLL.GetAll();
        }

        public virtual TDTO Get(TIdType id)
        {
            return BLL.Get(id);
        }

        public virtual TDTO Post(TDTO dto)
        {
            return BLL.Add(dto);
        }

        public virtual TDTO Put(int id, [FromBody]TDTO dto)
        {
            BLL.Update(dto);

            return dto;
        }

        public virtual void Delete(TIdType id)
        {
            BLL.Remove(id);
        }
    }
}