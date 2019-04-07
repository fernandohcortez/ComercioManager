using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Caliburn.Micro;

namespace CM.UI.Desktop
{
    public class CortezWindowManager : WindowManager
    {
        readonly IDictionary<WeakReference, WeakReference> _windows = new Dictionary<WeakReference, WeakReference>();

        public override void ShowWindow(object rootModel, object context = null, IDictionary<string, object> settings = null)
        {
            NavigationWindow navWindow = null;

            if (Application.Current != null && Application.Current.MainWindow != null)
            {
                navWindow = Application.Current.MainWindow as NavigationWindow;
            }

            if (navWindow != null)
            {
                var window = CreatePage(rootModel, context, settings);
                navWindow.Navigate(window);
            }
            else
            {
                var window = GetExistingWindow(rootModel);
                if (window == null)
                {
                    window = CreateWindow(rootModel, false, context, settings);
                    _windows.Add(new WeakReference(rootModel), new WeakReference(window));
                    window.Show();
                }
                else
                {
                    window.Focus();
                }
            }
        }

        protected virtual Window GetExistingWindow(object model)
        {
            if (!_windows.Any(d => d.Key.IsAlive && d.Key.Target == model))
                return null;

            var existingWindow = _windows.Single(d => d.Key.Target == model).Value;
            return existingWindow.IsAlive ? existingWindow.Target as Window : null;
        }
    }
}
