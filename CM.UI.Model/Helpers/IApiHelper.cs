using System;
using CM.UI.Model.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CM.UI.Model.Helpers
{
    public interface IApiHelper
    {
        Task<AutenticarUsuario> Autenticar(string usuario, string senha);
        Task ObterInfoUsuarioLogado(string token, string usuario);

        Task<T> Incluir<T>(T model, string nomeUri = null);
        Task<T> Alterar<T>(T model, object id, string nomeUri = null);
        Task Remover<T>(object id, string nomeUri = null);
        Task<ObservableCollection<T>> Listar<T>(string nomeUri = null);
        Task<T> Obter<T>(object id, string nomeUri = null);
        Task CriarNovaContaUsuario(UsuarioModel usuarioModel);
        Task RemoverContaUsuario(string usuario);
    }
}