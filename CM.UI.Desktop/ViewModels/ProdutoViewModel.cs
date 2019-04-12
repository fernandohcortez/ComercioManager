using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProdutoViewModel : Conductor<object>.Collection.OneActive
    {
        #region Campos e Propriedades

        private readonly IApiHelper _apiHelper;
        private AcaoCrud _acaoCrud;
        private ProdutoListaViewModel _produtoListaViewModel;
        private ProdutoEdicaoViewModel _produtoEdicaoViewModel;

        private ObservableCollection<ProdutoModel> ListaRegistros
        {
            set
            {
                var idSelecionado = RegistroCorrente?.Id;

                _produtoListaViewModel.ListaRegistros = value;

                RegistroCorrente = idSelecionado == null
                    ? ListaRegistros.FirstOrDefault()
                    : ListaRegistros.FirstOrDefault(m => m.Id == idSelecionado);
            }
            get => _produtoListaViewModel?.ListaRegistros;
        }
        private ProdutoModel RegistroCorrente
        {
            set => _produtoListaViewModel.RegistroCorrente = value;
            get => _produtoListaViewModel?.RegistroCorrente;
        }

        public bool IsBotaoSalvarVisivel { get; set; }
        public bool IsBotoesModoListaVisivel { get; set; } = true;
        public bool IsWaiting { get; set; }

        #endregion

        #region Construtores

        public static ProdutoViewModel Create()
        {
            return IoC.Get<ProdutoViewModel>();
        }

        public ProdutoViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;

            CarregarViewLista();
        }

        #endregion

        #region Botões

        private void ControlarVisibilidadeBotoes()
        {
            IsBotoesModoListaVisivel = _acaoCrud == AcaoCrud.Nenhuma;
            IsBotaoSalvarVisivel = _acaoCrud == AcaoCrud.Incluir || _acaoCrud == AcaoCrud.Alterar;
        }

        public void Incluir()
        {
            CarregarViewEdicao(AcaoCrud.Incluir);
        }

        public void Alterar()
        {
            CarregarViewEdicao(AcaoCrud.Alterar);
        }

        public void Visualizar()
        {
            CarregarViewEdicao(AcaoCrud.Visualizar);
        }

        public async void Remover()
        {
            if (RegistroCorrente == null)
                return;

            if (Mensagem.Create().MostrarPergunta("Deseja remover o registro selecionado?") == MessageBoxResult.No)
                return;
            try
            {
                IsWaiting = true;

                await _apiHelper.RemoverProduto(RegistroCorrente);

                ListaRegistros.Remove(RegistroCorrente);
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro na remoção do registro.\r\n\r\n{e.Message}");
            }
            finally
            {
                IsWaiting = false;
            }
        }

        public async void Atualizar()
        {
            await AtualizarListaRegistros();
        }

        public async void Salvar()
        {
            try
            {
                IsWaiting = true;

                ProdutoModel registroInclusoAlterado = null;

                switch (_acaoCrud)
                {
                    case AcaoCrud.Incluir:
                        registroInclusoAlterado = await _apiHelper.IncluirProduto(RegistroCorrente);
                        break;
                    case AcaoCrud.Alterar:
                        registroInclusoAlterado = await _apiHelper.AlterarProduto(RegistroCorrente);
                        break;
                }

                Mapping.Mapper.Map(registroInclusoAlterado, RegistroCorrente);

                _acaoCrud = AcaoCrud.Nenhuma;

                Voltar();
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro ao salvar o registro.\r\n\r\n{e.Message}");
            }
            finally
            {
                IsWaiting = false;
            }
        }

        public async void Voltar()
        {
            if (!(ActiveItem is ProdutoEdicaoViewModel produtoEdicaoViewModel))
                return;

            try
            {
                IsWaiting = true;

                if (_acaoCrud == AcaoCrud.Incluir || _acaoCrud == AcaoCrud.Alterar)
                {
                    if (Mensagem.Create().MostrarPergunta("O registro ainda não foi salvo e as informações serão perdidas.\r\nDeseja continuar?") == MessageBoxResult.No)
                        return;

                    if (_acaoCrud == AcaoCrud.Incluir)
                        ListaRegistros.Remove(RegistroCorrente);
                    else
                        await AtualizarRegistroCorrente();
                }
                else
                    _acaoCrud = AcaoCrud.Nenhuma;

                ControlarVisibilidadeBotoes();

                produtoEdicaoViewModel.TryClose();
            }
            finally
            {
                IsWaiting = false;
            }
        }

        public void Fechar()
        {
            TryClose();
        }

        #endregion

        #region Manipulação Registros

        public async Task AtualizarListaRegistros()
        {
            try
            {
                IsWaiting = true;

                var listaRegistrosAtualizados = await _apiHelper.ListarProdutos();

                ListaRegistros = listaRegistrosAtualizados;
            }
            finally
            {
                IsWaiting = false;
            }
        }

        public async Task AtualizarRegistroCorrente()
        {
            try
            {
                IsWaiting = true;

                var registroAtualizado = await _apiHelper.ObterProduto(RegistroCorrente.Id);

                Mapping.Mapper.Map(registroAtualizado, RegistroCorrente);
            }
            catch (Exception e)
            {
                Mensagem.Create().MostrarErro($"Erro ao obter o registro do servidor.\r\n\r\n{e.Message}");
            }
            finally
            {
                IsWaiting = false;
            }
        }

        private void IncluirNovoRegistroListaRegistros()
        {
            var registro = new ProdutoModel();
            ListaRegistros.Add(registro);
            RegistroCorrente = registro;
        }

        #endregion

        #region Carregamento Views

        private async void CarregarViewLista()
        {
            try
            {
                IsWaiting = true;

                _produtoListaViewModel = ProdutoListaViewModel.Create(Visualizar);

                await AtualizarListaRegistros();

                ActivateItem(_produtoListaViewModel);
            }
            finally
            {
                IsWaiting = false;
            }
        }

        private void CarregarViewEdicao(AcaoCrud acaoCrud)
        {
            _acaoCrud = acaoCrud;

            ControlarVisibilidadeBotoes();

            if (acaoCrud == AcaoCrud.Incluir)
            {
                IncluirNovoRegistroListaRegistros();
            }

            var somenteLeitura = acaoCrud == AcaoCrud.Visualizar;

            _produtoEdicaoViewModel = ProdutoEdicaoViewModel.Create(somenteLeitura, RegistroCorrente);

            ActivateItem(_produtoEdicaoViewModel);
        }

        #endregion
    }
}
