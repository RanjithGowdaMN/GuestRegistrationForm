using Caliburn.Micro;
using GenerateDocument.Library;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.FiScanner;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationDesktopUI.Library.PhotoHandler;
using GuestRegistrationDeskUI.Helpers;
using GuestRegistrationDeskUI.ViewModels;
using IronOCR.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tesseract.Library;

namespace GuestRegistrationDeskUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();


        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);
            _container
                .Singleton<IAPIconnector, APIconnector>()
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedInUserModel, LoggedInUserModel>()
                //.Singleton<IOCRhelper, OCRhelper>()
                .Singleton<ITesseractLib, TesseractLib>()
                .Singleton<IIronOCR, TessereactIronOCR>()
                .Singleton<ICentralHub, CentralHub>()
                .Singleton<ICanonSDKHelper, CanonSDKHelper>()
                .Singleton<IGenerateWordDocument, GenerateWordDocument>()
                .Singleton<IGeneratePDFdocument, GeneratePDFdocument>();

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
            //base.OnStartup(sender, e);
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
