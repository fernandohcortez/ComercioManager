using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace CM.UI.Desktop.Components
{
    public class Mensagem : IMensagem
    {
        public static IMensagem Create()
        {
            return IoC.Get<IMensagem>();
        }

        public MessageBoxResult MostrarErro(string mensagem)
        {
            return MessageBox.Show(mensagem, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public MessageBoxResult MostrarAlerta(string mensagem)
        {
            return MessageBox.Show(mensagem, "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            //var windowManager = new WindowManager();

            //dynamic settings = new ExpandoObject();
            //settings.WindowStyle = WindowStyle.ThreeDBorderWindow;
            //settings.ShowInTaskbar = true;
            //settings.Title = "Alerta";
            //settings.WindowState = WindowState.Normal;
            //settings.ResizeMode = ResizeMode.CanMinimize;

            //windowManager.ShowDialog(viewModelOwner, null, settings);
        }

        public MessageBoxResult MostrarInformacao(string mensagem)
        {
            return MessageBox.Show(mensagem, "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult MostrarPergunta(string mensagem)
        {
            return MessageBox.Show(mensagem, "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
