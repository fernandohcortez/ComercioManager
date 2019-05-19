using CM.Core.Base;
using System;

namespace CM.Core
{
    public class UsuarioDTO : IBaseDTO
    {
        public string Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public byte[] Foto { get; set; }
        public bool Administrador { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
