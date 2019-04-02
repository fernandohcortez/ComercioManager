using System;

namespace CM.UI.Model.Models.Interface
{
    public interface IUsuarioLogadoModel
    {
        DateTime DataInclusao { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        string PrimeiroNome { get; set; }
        string Token { get; set; }
        string UltimoNome { get; set; }
    }
}