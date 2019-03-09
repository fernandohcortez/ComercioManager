using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CMDesktopUI.Models;

namespace CMDesktopUI.ViewModels
{
    public class ProdutoViewModel : Screen
    {
        private readonly IApiHelper _apiHelper;

        public ProdutoViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                NotifyOfPropertyChange(() => Nome);
            }
        }

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set
            {
                _descricao = value;
                NotifyOfPropertyChange(() => Descricao);
            }
        }

        private decimal _precoVenda;
        public decimal PrecoVenda
        {
            get => _precoVenda;
            set
            {
                _precoVenda = value;
                NotifyOfPropertyChange(() => PrecoVenda);
            }
        }

        //public bool CanIncluir()
        //{
        //    return Nome?.Length > 0 && Descricao?.Length > 0 && PrecoVenda > 0;
        //}

        public async Task Incluir()
        {
            try
            {
                await _apiHelper.IncluirProduto(Nome, Descricao, PrecoVenda);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
