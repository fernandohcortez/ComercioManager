using CMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CM.Core;
using CMDesktopUI.ViewModels;

namespace CMDesktopUI.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;
        public UsuarioAutenticado UsuarioAutenticado;

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
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                UsuarioAutenticado = await response.Content.ReadAsAsync<UsuarioAutenticado>();

                _apiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + UsuarioAutenticado.Access_Token);

                var dadosUsuarioAutenticado = await ObterUsuario();

                if (dadosUsuarioAutenticado == null)
                {
                    _apiClient.DefaultRequestHeaders.Remove("Authorization");

                    throw new Exception("Dados do usuário não encontrado. Verifique se o mesmo foi cadastrado.");
                }

                UsuarioAutenticado.Email = dadosUsuarioAutenticado.Email;
                UsuarioAutenticado.PrimeiroNome = dadosUsuarioAutenticado.PrimeiroNome;
                UsuarioAutenticado.UltimoNome = dadosUsuarioAutenticado.UltimoNome;

                return UsuarioAutenticado;
            }
        }

        public Task IncluirCliente()
        {
            throw new NotImplementedException();
        }

        public Task IncluirFornecedor()
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioAutenticado> ObterUsuario()
        {
            using (var response = await _apiClient.GetAsync("api/Usuario/GetUsuarioCorrente/"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<UsuarioAutenticado>();
                }

                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task IncluirProduto(ProdutoViewModel produtoViewModel)
        {
            //var data = new FormUrlEncodedContent(new[]
            // {
            //    new KeyValuePair<string, string>("Nome", produtoDTO.Nome),
            //    new KeyValuePair<string, string>("Descricao", descricao),
            //    new KeyValuePair<string, string>("PrevoVenda", precoVenda.ToString(CultureInfo.CurrentCulture)),
            //    new KeyValuePair<string, string>("DataInclusao", DateTime.Now.ToString(CultureInfo.CurrentCulture)),
            //    new KeyValuePair<string, string>("DataAlteracao", DateTime.Now.ToString(CultureInfo.CurrentCulture))
            //});

            using (var response = await _apiClient.PostAsync("api/Produto", produtoViewModel, new JsonMediaTypeFormatter()))
            {
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsAsync<object>();
                }

                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            using (var response = await _apiClient.GetAsync($"api/Produto/"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Produto>>();
                }

                throw new Exception(response.ReasonPhrase);
            }
        }

        public Task IncluirDocumentoEntrada()
        {
            throw new NotImplementedException();
        }

        public Task IncluirPedidoVenda()
        {
            throw new NotImplementedException();
        }
    }
}
