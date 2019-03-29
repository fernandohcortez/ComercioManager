using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Navigation;
using CMDesktopUI.Models;

namespace CMDesktopUI.ViewModels
{
    public class ProdutoListaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public ProdutoListaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;

            _apiHelper.ListarProdutos().ContinueWith((m) => Grid = m.Result);
        }

        public List<Produto> Grid { get; set; }
        

        
        //public bool CanIncluir()
        //{
        //    return Nome?.Length > 0 && Descricao?.Length > 0 && PrecoVenda > 0;
        //}

        public void Fechar()
        {
            TryClose();
        }
    }
}
