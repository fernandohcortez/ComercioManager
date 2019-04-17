using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models.Base;
using FluentValidation;
using PropertyChanged;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CM.UI.Desktop.ViewModels.Base
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase<TListaViewModel, TEdicaoViewModel, TModel, TModelValidator> : Conductor<object>.Collection.OneActive where TModel : ModelBase where TListaViewModel : ListaViewModelBase<TModel> where TEdicaoViewModel : EdicaoViewModelBase<TModel> where TModelValidator : AbstractValidator<TModel>
    {
        #region Campos e Propriedades

        protected readonly IApiHelper ApiHelper;
        protected AcaoCrud AcaoCrud;
        protected TListaViewModel ListaViewModel;
        protected TEdicaoViewModel EdicaoViewModel;
        protected TModelValidator ModelValidator;

        private ObservableCollection<TModel> ListaRegistros
        {
            set
            {
                var idSelecionado = RegistroCorrente?.Id;

                ListaViewModel.ListaRegistros = value;

                RegistroCorrente = idSelecionado == null
                    ? ListaRegistros.FirstOrDefault()
                    : ListaRegistros.FirstOrDefault(m => m.Id == idSelecionado);
            }
            get => ListaViewModel?.ListaRegistros;
        }
        private TModel RegistroCorrente
        {
            set => ListaViewModel.RegistroCorrente = value;
            get => ListaViewModel?.RegistroCorrente;
        }

        public bool IsBotaoSalvarVisivel { get; set; }
        public bool IsBotoesModoListaVisivel { get; set; } = true;
        public bool IsWaiting { get; set; }

        #endregion

        #region Construtores

        public ViewModelBase(IApiHelper apiHelper)
        {
            ApiHelper = apiHelper;

            ModelValidator = Activator.CreateInstance<TModelValidator>();

            CarregarViewLista();
        }

        public static T Create<T>() where T : ViewModelBase<TListaViewModel, TEdicaoViewModel, TModel, TModelValidator>
        {
            return IoC.Get<T>();
        }

        #endregion

        #region Botões

        private void ControlarVisibilidadeBotoes()
        {
            IsBotoesModoListaVisivel = AcaoCrud == AcaoCrud.Nenhuma;
            IsBotaoSalvarVisivel = AcaoCrud == AcaoCrud.Incluir || AcaoCrud == AcaoCrud.Alterar;
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

                await ApiHelper.Remover<TModel>(RegistroCorrente.Id);

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

                Validar();
                
                TModel registroInclusoAlterado = null;

                switch (AcaoCrud)
                {
                    case AcaoCrud.Incluir:
                        registroInclusoAlterado = await ApiHelper.Incluir(RegistroCorrente);
                        break;
                    case AcaoCrud.Alterar:
                        registroInclusoAlterado = await ApiHelper.Alterar(RegistroCorrente, RegistroCorrente.Id);
                        break;
                }

                Mapping.Mapper.Map(registroInclusoAlterado, RegistroCorrente);

                if (RegistroCorrente.Id == null)
                    throw new Exception($"Não foi possível obter o registro atualizado.\r\nCertifique-se que model [{RegistroCorrente.GetType().Name}] foi configurado na classe Mapping.");

                AcaoCrud = AcaoCrud.Nenhuma;

                Voltar();
            }

            catch (ValidationException e)
            {
                Mensagem.Create().MostrarAlerta(e.Message);
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

        private void Validar()
        {
            RegistroCorrente.ClearAllErrors();

            var resultValidator = ModelValidator.Validate(RegistroCorrente);

            foreach (var error in resultValidator.Errors)
            {
                RegistroCorrente.SetError(error.PropertyName, error.ErrorMessage);
            }

            if (!resultValidator.IsValid)
                throw new ValidationException(resultValidator.ToString());
        }

        public async void Voltar()
        {
            if (!(ActiveItem is TEdicaoViewModel edicaoViewModel))
                return;

            void FecharViewEdicao()
            {
                AcaoCrud = AcaoCrud.Nenhuma;

                ControlarVisibilidadeBotoes();

                edicaoViewModel.TryClose();
            }

            if (AcaoCrud == AcaoCrud.Incluir || AcaoCrud == AcaoCrud.Alterar)
            {
                if (Mensagem.Create().MostrarPergunta("O registro ainda não foi salvo e as informações serão perdidas.\r\nDeseja continuar?") == MessageBoxResult.No)
                    return;

                try
                {
                    IsWaiting = true;

                    if (AcaoCrud == AcaoCrud.Incluir)
                        ListaRegistros.Remove(RegistroCorrente);
                    else
                        await AtualizarRegistroCorrente();
                }
                finally
                {
                    FecharViewEdicao();

                    IsWaiting = false;
                }
            }
            else
            {
                FecharViewEdicao();
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

                var listaRegistrosAtualizados = await ApiHelper.Listar<TModel>();

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

                var registroAtualizado = await ApiHelper.Obter<TModel>(RegistroCorrente.Id);

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
            var registro = Activator.CreateInstance<TModel>();
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

                ListaViewModel = IoC.Get<TListaViewModel>();
                ListaViewModel.ActionVisualizarRegistro = Visualizar;

                await AtualizarListaRegistros();

                ActivateItem(ListaViewModel);
            }
            finally
            {
                IsWaiting = false;
            }
        }

        private void CarregarViewEdicao(AcaoCrud acaoCrud)
        {
            AcaoCrud = acaoCrud;

            ControlarVisibilidadeBotoes();

            if (acaoCrud == AcaoCrud.Incluir)
            {
                IncluirNovoRegistroListaRegistros();
            }

            EdicaoViewModel = IoC.Get<TEdicaoViewModel>();

            EdicaoViewModel.IsViewSomenteLeitura = acaoCrud == AcaoCrud.Visualizar;
            EdicaoViewModel.Model = RegistroCorrente;

            ActivateItem(EdicaoViewModel);
        }

        #endregion
    }
}
