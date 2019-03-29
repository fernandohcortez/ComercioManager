using Caliburn.Micro;
using CMDesktopUI.Helpers;
using System;
using System.Threading.Tasks;

namespace CMDesktopUI.ViewModels
{
    public class ClienteViewModel : Conductor<object>
    {
        private readonly IApiHelper _apiHelper;

        public ClienteViewModel(IApiHelper apiHelper)
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

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set
            {
                _cpf = value;
                NotifyOfPropertyChange(() => Cpf);
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

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                _dataNascimento = value;
                NotifyOfPropertyChange(() => DataNascimento);
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
                await _apiHelper.IncluirCliente();
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
