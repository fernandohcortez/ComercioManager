using CM.UI.Model.Validators.Language;
using FluentValidation;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;


namespace CM.UI.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));

            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotFocusEvent, new RoutedEventHandler(InputBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(PasswordBox), UIElement.GotFocusEvent, new RoutedEventHandler(InputBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(Window), UIElement.GotMouseCaptureEvent, new RoutedEventHandler(Window_MouseCapture));

            ValidatorOptions.LanguageManager = new CustomLanguageManager
            {
                Culture = new CultureInfo("pt")
            };

            base.OnStartup(e);
        }

        private void InputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            switch (sender)
            {
                case TextBox textBox:
                    textBox.SelectAll();
                    break;
                case PasswordBox passwordBox:
                    passwordBox.SelectAll();
                    break;
            }
        }

        private void Window_MouseCapture(object sender, RoutedEventArgs e)
        {
            switch (e.OriginalSource)
            {
                case TextBox textBox:
                    textBox.SelectAll();
                    break;
                case PasswordBox passwordBox:
                    passwordBox.SelectAll();
                    break;
            }
        }
    }
}
