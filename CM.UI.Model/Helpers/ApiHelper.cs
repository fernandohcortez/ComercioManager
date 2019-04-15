using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CM.UI.Model.Helpers
{
    public class ApiHelper : IApiHelper
    {
        #region Campos e Propriedades

        private readonly IUsuarioLogadoModel _usuarioLogadoModel;
        private HttpClient _apiClient;
        
        #endregion

        #region Contrutores

        public ApiHelper(IUsuarioLogadoModel usuarioLogadoModel)
        {
            IniciarClient();

            _usuarioLogadoModel = usuarioLogadoModel;
        }

        #endregion

        #region HTTP Client

        private void IniciarClient()
        {
            var api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient
            {
                BaseAddress = new Uri(api)
            };

            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        #region Autenticação Usuário

        public async Task<AutenticarUsuario> Autenticar(string usuario, string senha)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", usuario),
                new KeyValuePair<string, string>("password", senha)
            });

            using (var response = await _apiClient.PostAsync("/Token", data))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<AutenticarUsuario>();
            }
        }

        public async Task ObterInfoUsuarioLogado(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (var response = await _apiClient.GetAsync("api/Usuario/GetUsuarioCorrente/"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                var result = await response.Content.ReadAsAsync<UsuarioLogadoModel>();

                _usuarioLogadoModel.Id = result.Id;
                _usuarioLogadoModel.PrimeiroNome = result.PrimeiroNome;
                _usuarioLogadoModel.UltimoNome = result.UltimoNome;
                _usuarioLogadoModel.Email = result.Email;
                _usuarioLogadoModel.DataInclusao = result.DataInclusao;
                _usuarioLogadoModel.Token = token;
            }
        }

        #endregion

        #region Métodos CRUD Padrão

        private string ObterNomeUriPadraoModel<T>()
        {
            return typeof(T).Name.Replace("Model", string.Empty);
        }

        public async Task<T> Incluir<T>(T model, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            using (var response = await _apiClient.PostAsync($"api/{nomeUri}", model, new JsonMediaTypeFormatter()))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task<T> Alterar<T>(T model, object id, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            using (var response = await _apiClient.PutAsync($"api/{nomeUri}/{id}", model, new JsonMediaTypeFormatter()))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task Remover<T>(object id, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            using (var response = await _apiClient.DeleteAsync($"api/{nomeUri}/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                await response.Content.ReadAsAsync<object>();
            }
        }

        public async Task<T> Obter<T>(object id, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            using (var response = await _apiClient.GetAsync($"api/{nomeUri}/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task<ObservableCollection<T>> Listar<T>(string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            using (var response = await _apiClient.GetAsync($"api/{nomeUri}/"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<ObservableCollection<T>>();
            }
        }

        #endregion
    }
}
