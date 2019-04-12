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
        private readonly IUsuarioLogadoModel _usuarioLogadoModel;
        private HttpClient _apiClient;

        public ApiHelper(IUsuarioLogadoModel usuarioLogadoModel)
        {
            InitializeClient();

            _usuarioLogadoModel = usuarioLogadoModel;
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

        public Task IncluirCliente()
        {
            throw new NotImplementedException();
        }

        public Task IncluirFornecedor()
        {
            throw new NotImplementedException();
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

        public async Task<ProdutoModel> IncluirProduto(ProdutoModel produtoModel)
        {
            using (var response = await _apiClient.PostAsync("api/Produto", produtoModel, new JsonMediaTypeFormatter()))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<ProdutoModel>();
            }
        }

        public async Task<ProdutoModel> AlterarProduto(ProdutoModel produtoModel)
        {
            using (var response = await _apiClient.PutAsync($"api/Produto/{produtoModel.Id}", produtoModel, new JsonMediaTypeFormatter()))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<ProdutoModel>();
            }
        }

        public async Task RemoverProduto(ProdutoModel produtoModel)
        {
            using (var response = await _apiClient.DeleteAsync($"api/Produto/{produtoModel.Id}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                await response.Content.ReadAsAsync<object>();
            }
        }

        public async Task<ProdutoModel> ObterProduto(int id)
        {
            using (var response = await _apiClient.GetAsync($"api/Produto/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<ProdutoModel>();
            }
        }

        public async Task<ObservableCollection<ProdutoModel>> ListarProdutos()
        {
            using (var response = await _apiClient.GetAsync("api/Produto/"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<ObservableCollection<ProdutoModel>>();
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
