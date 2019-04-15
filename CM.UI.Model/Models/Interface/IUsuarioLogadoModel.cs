using System;

namespace CM.UI.Model.Models.Interface
{
    public interface IUsuarioLogadoModel
    {
        string Id { get; set; }
        string PrimeiroNome { get; set; }
        string UltimoNome { get; set; }
        string Email { get; set; }
        DateTime DataInclusao { get; set; }
        string Token { get; set; }
    }
}