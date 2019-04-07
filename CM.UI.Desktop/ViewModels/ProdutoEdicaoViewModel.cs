using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoEdicaoViewModel : Screen
    {
        public bool IsViewSomenteLeitura { get; set; }

        public ProdutoModel ProdutoModel { get; set; }

        public static ProdutoEdicaoViewModel Create(bool somenteLeitura, ProdutoModel produtoModel)
        {
            var instancia = IoC.Get<ProdutoEdicaoViewModel>();

            instancia.ProdutoModel = produtoModel;
            instancia.IsViewSomenteLeitura = somenteLeitura;

            return instancia;
        }

        public ProdutoEdicaoViewModel()
        {
            
        }

        //public async Task Salvar()
        //{
        //    try
        //    {
        //        switch (_acaoCrud)
        //        {
        //            case AcaoCrud.Incluir:
        //                await _apiHelper.IncluirProduto(ProdutoModel);
        //                break;
        //            case AcaoCrud.Alterar:
        //                await _apiHelper.AlterarProduto(ProdutoModel);
        //                break;
        //        }

        //        TryClose(true);
        //    }
        //    catch (Exception e)
        //    {
        //        Mensagem.Create().MostrarErro($"Erro na inclusão do registro.\r\n\r\n{e.Message}");
        //    }
        //}

        //public void Fechar()
        //{
        //    if (_acaoCrud == AcaoCrud.Incluir || _acaoCrud == AcaoCrud.Alterar)
        //    {
        //        if (Mensagem.Create().MostrarPergunta("O registro ainda não foi salvo.\r\nDeseja sair mesmo assim?") == MessageBoxResult.No)
        //            return;
        //    }

        //    TryClose(false);
        //}
    }
}
