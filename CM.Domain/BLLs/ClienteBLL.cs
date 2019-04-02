using System.Collections.Generic;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;

namespace CM.Domain.BLLs
{
    public class ClienteBLL : BaseBLL<ClienteDTO>
    {
        public override ClienteDTO Get(object id)
        {
            return Get<Cliente>(id.ToString());
        }

        public override IEnumerable<ClienteDTO> GetAll()
        {
            return GetAll<Cliente>();
        }

        public override void Add(ClienteDTO dto)
        {
            Add<Cliente>(dto);
        }

        public override void Update(ClienteDTO dto)
        {
            Update<Cliente>(dto);
        }

        public override void Remove(object id)
        {
            Remove<Cliente>(id.ToString());
        }
    }
}
