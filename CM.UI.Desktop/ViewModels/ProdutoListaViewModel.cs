using Caliburn.Micro;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using System.Collections.Generic;

namespace CM.UI.Desktop.ViewModels
{
    public class ProdutoListaViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public ProdutoListaViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;

            _apiHelper.ListarProdutos().ContinueWith((m) => Grid = m.Result);
        }

        public List<ProdutoModel> Grid { get; set; }



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
