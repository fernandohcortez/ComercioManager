using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using System.Collections.Generic;

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

        public override ClienteDTO Add(ClienteDTO dto)
        {
            return Add<Cliente>(dto, true);
        }

        public override void Update(ClienteDTO dto)
        {
            Update<Cliente>(dto, true);
        }

        public override void Remove(object id)
        {
            Remove<Cliente>(id.ToString(), true);
        }
    }
}
