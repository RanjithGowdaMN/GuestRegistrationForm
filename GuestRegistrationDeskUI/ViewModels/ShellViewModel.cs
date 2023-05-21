using Caliburn.Micro;
using GuestRegistrationDeskUI.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private LoginViewModel _loginVM;
        private SimpleContainer _container;
        private MainScreenViewModel _mainScreenVM;
        private IEventAggregator _events;
        public ShellViewModel(LoginViewModel loginVM, IEventAggregator events, MainScreenViewModel mainScreenVM, SimpleContainer container)
        {
            _loginVM = loginVM;
            _events = events;
            _mainScreenVM = mainScreenVM;
            _container = container;
            _events.Subscribe(this);
            //ActivateItemAsync(_loginVM);
            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken) => ActivateItemAsync(_mainScreenVM);
    }
}
