using System.Windows;
using System.Windows.Input;

namespace CMDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void AbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Collapsed;
            FecharMenu.Visibility = Visibility.Visible;
        }

        private void FecharMenu_Click(object sender, RoutedEventArgs e)
        {
            AbrirMenu.Visibility = Visibility.Visible;
            FecharMenu.Visibility = Visibility.Collapsed;
        }

    }
}
