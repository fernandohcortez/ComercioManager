using CMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CMDesktopUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;
        private UsuarioAutenticado _usuarioAutenticado;

        public ApiHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            var api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient
            {
                BaseAddress = new Uri(api)
            };

            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UsuarioAutenticado> Autenticar(string usuario, string senha)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", usuario),
                new KeyValuePair<string, string>("password", senha)
            });

            using (var response = await _apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    _usuarioAutenticado = await response.Content.ReadAsAsync<UsuarioAutenticado>();

                    return _usuarioAutenticado;
                }

                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task IncluirProduto(string nome, string descricao, decimal precoVenda)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Authorization", "Bearer " + _usuarioAutenticado.Access_Token),
                new KeyValuePair<string, string>("Nome", nome),
                new KeyValuePair<string, string>("Descricao", descricao),
                new KeyValuePair<string, string>("PrevoVenda", precoVenda.ToString(CultureInfo.CurrentCulture)),
                new KeyValuePair<string, string>("DataInclusao", DateTime.Now.ToString(CultureInfo.CurrentCulture)),
                new KeyValuePair<string, string>("DataAlteracao", DateTime.Now.ToString(CultureInfo.CurrentCulture))
            });

            using (var response = await _apiClient.PostAsync("api/Produto", data))
            {
                if (response.IsSuccessStatusCode)
                {
                   await response.Content.ReadAsAsync<object>();
                }

                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
