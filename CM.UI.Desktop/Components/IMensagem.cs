using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace CM.UI.Desktop.Components
{
    public interface IMensagem
    {
        MessageBoxResult MostrarErro(string mensagem);
        MessageBoxResult MostrarAlerta(string mensagem);
        MessageBoxResult MostrarPergunta(string mensagem);
        MessageBoxResult MostrarInformacao(string mensagem);
    }
}
