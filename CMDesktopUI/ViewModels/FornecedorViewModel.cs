using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.Threading.Tasks;

namespace CMDesktopUI.ViewModels
{
    public class FornecedorViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public FornecedorViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private string _razaoSocial;
        public string RazaoSocial
        {
            get => _razaoSocial;
            set
            {
                _razaoSocial = value;
                NotifyOfPropertyChange(() => RazaoSocial);
            }
        }

        private string _nomeFantasia;
        public string NomeFantasia
        {
            get => _nomeFantasia;
            set
            {
                _nomeFantasia = value;
                NotifyOfPropertyChange(() => NomeFantasia);
            }
        }

        private string _cnpj;
        public string Cnpj
        {
            get => _cnpj;
            set
            {
                _cnpj = value;
                NotifyOfPropertyChange(() => Cnpj);
            }
        }

        private string _inscricaoEstadual;
        public string InscricaoEstadual
        {
            get => _cnpj;
            set
            {
                _inscricaoEstadual = value;
                NotifyOfPropertyChange(() => InscricaoEstadual);
            }
        }

        private string _fone1;
        public string Fone1
        {
            get => _fone1;
            set
            {
                _fone1 = value;
                NotifyOfPropertyChange(() => Fone1);
            }
        }

        private string _fone2;
        public string Fone2
        {
            get => _fone2;
            set
            {
                _fone2 = value;
                NotifyOfPropertyChange(() => Fone2);
            }
        }

        private string _endereco;
        public string Endereco
        {
            get => _endereco;
            set
            {
                _endereco = value;
                NotifyOfPropertyChange(() => Endereco);
            }
        }

        private string _complemento;
        public string Complemento
        {
            get => _complemento;
            set
            {
                _complemento = value;
                NotifyOfPropertyChange(() => Complemento);
            }
        }

        private string _bairro;
        public string Bairro
        {
            get => _bairro;
            set
            {
                _bairro = value;
                NotifyOfPropertyChange(() => Bairro);
            }
        }

        private string _cidade;
        public string Cidade
        {
            get => _cidade;
            set
            {
                _cidade = value;
                NotifyOfPropertyChange(() => Cidade);
            }
        }

        private string _estado;
        public string Estado
        {
            get => _estado;
            set
            {
                _estado = value;
                NotifyOfPropertyChange(() => Estado);
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        public async Task Incluir()
        {
            try
            {
                await _apiHelper.IncluirFornecedor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Fechar()
        {
            TryClose();
        }
    }
}
