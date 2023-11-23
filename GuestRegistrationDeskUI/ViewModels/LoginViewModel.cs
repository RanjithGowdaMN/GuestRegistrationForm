using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDeskUI.EventModel;
using GuestRegistrationDeskUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IAPIconnector _apiHelper;
        private SimpleContainer _container;
        private IEventAggregator _events;

        private ILoggedInUserModel _loggedInUserModel;

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public LoginViewModel(IAPIconnector apiHelper, SimpleContainer container, IEventAggregator events, ILoggedInUserModel loggedInUserModel)
        {
            _apiHelper = apiHelper;
            _loggedInUserModel = loggedInUserModel;
            //APIHelper aPIHelper = new APIHelper(_loggedInUserModel);
            //_apiHelper = aPIHelper;
             
            _events = events;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                //NotifyOfPropertyChange(() => UserName);
                //NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                //NotifyOfPropertyChange(() => Password);
                //NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                //bool output = false;
                bool output = true;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = string.Empty;
                
                var result = await _apiHelper.Authenticate(UserName, Password);

                //capture more information about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                await _events.PublishOnUIThreadAsync(new LogOnEvent());

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
