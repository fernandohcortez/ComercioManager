using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using CM.UI.Desktop.Helpers;
using CM.UI.Model.Validators;
using CM.UI.Model.Validators.Language;
using FluentValidation;


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

            EventManager.RegisterClassHandler(typeof(TextBox),UIElement.GotFocusEvent,new RoutedEventHandler(TextBox_GotFocus));
            EventManager.RegisterClassHandler(typeof(Window), UIElement.GotMouseCaptureEvent,new RoutedEventHandler(Window_MouseCapture));

            ValidatorOptions.LanguageManager = new CustomLanguageManager
            {
                Culture = new CultureInfo("pt")
            };

            base.OnStartup(e);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox)?.SelectAll();
        }

        private void Window_MouseCapture(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
                textBox.SelectAll();
        }
    }
}
