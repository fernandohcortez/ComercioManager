using Caliburn.Micro;
using CM.UI.Desktop.Components;
using CM.UI.Desktop.Helpers;
using CM.UI.Desktop.ViewModels;
using CM.UI.Model.Helpers;
using CM.UI.Model.Models;
using CM.UI.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CM.UI.Desktop
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(PasswordBoxHelper.BoundPasswordProperty, "Password", "PasswordChanged");
        }

        protected override void Configure()
        {
            void RegisterInContainerAllViewModels()
            {
                GetType().Assembly.GetTypes()
                    .Where(type => type.IsClass)
                    .Where(type => type.Name.EndsWith("ViewModel"))
                    .ToList()
                    .ForEach(viewModelType =>
                        _container.RegisterSingleton(viewModelType, viewModelType.ToString(), viewModelType));
            }

            void RegisterInContainerAllOtherClasses()
            {
                _container.PerRequest<IMensagem, Mensagem>();
            }

            void RegisterAllSingletons()
            {
                _container
                    .Singleton<IWindowManager, CortezWindowManager>()
                    .Singleton<IEventAggregator, EventAggregator>()
                    .Singleton<IApiHelper, ApiHelper>()
                    .Singleton<IUsuarioLogadoModel, UsuarioLogadoModel>();
            }

            _container.Instance(_container);

            RegisterAllSingletons();

            RegisterInContainerAllViewModels();

            RegisterInContainerAllOtherClasses();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
