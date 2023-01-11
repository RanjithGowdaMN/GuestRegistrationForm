using Caliburn.Micro;
using Fi800ScanLibrary.Scanner;
using GuestRegistrationDesktopUI.ViewModels;
using OCRLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GuestRegistrationDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IExtractTextFromImage, ExtractTextFromImage>();
            //.Singleton<IScanDocument, ScanDocument>();
            //.Singleton<ILoggedInUserModel, LoggedInUserModel>()
            //.Singleton<IAPIHelper, APIHelper>();

            _container
                .PerRequest<IScanDocument, ScanDocument>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

            //base.Configure();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<ShellViewModel>();
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
            //base.BuildUp(instance);
        }
    }
}
