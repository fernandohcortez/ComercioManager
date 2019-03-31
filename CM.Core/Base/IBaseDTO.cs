using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Base
{
    public interface IBaseDTO
    {
        DateTime DataInclusao { get; set; }
        DateTime DataAlteracao { get; set; }
    }
}
