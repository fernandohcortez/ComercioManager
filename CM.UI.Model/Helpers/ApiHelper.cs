﻿using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using CM.WebApi.Exceptions;
using Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UsuarioModel = CM.UI.Model.Models.UsuarioModel;

namespace CM.UI.Model.Helpers
{
    public class ApiHelper : IApiHelper
    {
        #region Campos e Propriedades

        private readonly IUsuarioModel _usuarioLogadoModel;
        private HttpClient _apiClient;

        #endregion

        #region Contrutores

        public ApiHelper(IUsuarioModel usuarioLogadoModel)
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
                    throw ApiException.CreateException(response);

                return await response.Content.ReadAsAsync<AutenticarUsuario>();
            }
        }

        public async Task ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("OldPassword", oldPassword),
                new KeyValuePair<string, string>("NewPassword", newPassword),
                new KeyValuePair<string, string>("ConfirmPassword", confirmPassword)
            });

            using (var response = await _apiClient.PostAsync("/api/Account/ChangePassword", data))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                await response.Content.ReadAsAsync<object>();
            }
        }

        public async Task SendEmailForgottenPassword(string username)
        {
            using (var response = await _apiClient.PostAsync($"/api/Account/SendEmailForgottenPassword/{username}", null))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                await response.Content.ReadAsAsync<object>();
            }
        }

        public async Task ResetPassword(string username, string token, string newPassword)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Username", username),
                new KeyValuePair<string, string>("Token", token),
                new KeyValuePair<string, string>("NewPassword", newPassword)
            });

            using (var response = await _apiClient.PostAsync("/api/Account/ResetPassword", data))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                await response.Content.ReadAsAsync<object>();
            }
        }

        public async Task CriarContaUsuario(UsuarioModel usuarioModel)
        {
            using (var response = await _apiClient.PostAsync("/api/Account/Register", usuarioModel, new JsonMediaTypeFormatter()))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                _ = response.Content.ReadAsAsync<object>();
            }
        }

        public async Task AlterarContaUsuario(UsuarioModel usuarioModel)
        {
            using (var response = await _apiClient.PostAsync("/api/Account/ChangeUser", usuarioModel, new JsonMediaTypeFormatter()))
            {
                try
                {
                    if (!response.IsSuccessStatusCode)
                        throw ApiException.CreateException(response);

                    _ = response.Content.ReadAsAsync<object>();
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.ToString());
                }
            }
        }

        public async Task RemoverContaUsuario(string usuario)
        {
            using (var response = await _apiClient.DeleteAsync($"/api/Account/RemoveUser/{usuario}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                _ = response.Content.ReadAsAsync<object>();
            }
        }

        public async Task ObterInfoUsuarioLogado(string token, string usuario)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (var response = await _apiClient.GetAsync($"api/Usuario/{usuario}/"))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                var result = await response.Content.ReadAsAsync<UsuarioModel>();

                _usuarioLogadoModel.Id = result.Id;
                _usuarioLogadoModel.PrimeiroNome = result.PrimeiroNome;
                _usuarioLogadoModel.UltimoNome = result.UltimoNome;
                _usuarioLogadoModel.Email = result.Email;
                _usuarioLogadoModel.DataInclusao = result.DataInclusao;
                _usuarioLogadoModel.Token = token;
                _usuarioLogadoModel.Foto = result.Foto;
                _usuarioLogadoModel.Administrador = result.Administrador;
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
                    throw ApiException.CreateException(response);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task<T> PostFromUri<T>(T value, string nomeUri = null)
        {
            using (var response = await _apiClient.PostAsync($"/api/{nomeUri}/{value}/", null))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task<T> Alterar<T>(T model, object id, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            id = AdicionarBarraStringQuandoEmail(id);

            using (var response = await _apiClient.PutAsync($"api/{nomeUri}/{id}", model, new JsonMediaTypeFormatter()))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task Remover<T>(object id, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            id = AdicionarBarraStringQuandoEmail(id);

            using (var response = await _apiClient.DeleteAsync($"api/{nomeUri}/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                await response.Content.ReadAsAsync<object>();
            }
        }

        public async Task<T> Obter<T>(object id, string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            id = AdicionarBarraStringQuandoEmail(id);

            using (var response = await _apiClient.GetAsync($"api/{nomeUri}/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task<ObservableCollection<T>> Listar<T>(string nomeUri = null)
        {
            nomeUri = nomeUri ?? ObterNomeUriPadraoModel<T>();

            using (var response = await _apiClient.GetAsync($"api/{nomeUri}/"))
            {
                if (!response.IsSuccessStatusCode)
                    throw ApiException.CreateException(response);

                return await response.Content.ReadAsAsync<ObservableCollection<T>>(); ;
            }
        }

        private object AdicionarBarraStringQuandoEmail(object id)
        {
            if (!(id is string idString))
                return id;

            if (idString.ValidateEmail() && !idString.EndsWith("/"))
                idString = $"{idString}/";

            id = idString;

            return id;
        }

        #endregion
    }
}
