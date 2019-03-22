using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDesktopUI.Models
{
    public class UsuarioAutenticado : IUsuarioAutenticado
    {
        public string Access_Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }
}
