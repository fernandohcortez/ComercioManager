using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMDataManager.Models
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}