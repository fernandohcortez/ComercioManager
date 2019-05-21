using System;

namespace CM.UI.Model.Models.Interface
{
    public interface IUsuarioModel
    {
        string Token { get; set; }
        string Id { get; set; }
        string PrimeiroNome { get; set; }
        string UltimoNome { get; set; }
        string Email { get; set; }
        DateTime DataInclusao { get; set; }
        byte[] Foto { get; set; }
        bool Administrador { get; set; }
        bool UsuarioLogado { get;}
    }
}