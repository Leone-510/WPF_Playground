using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Private Fields & Public Properties
        private string _userName;

        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        #endregion


        public ICommand LoginCommand { get; }

        public LoginViewModel(AccountStore accountStore, NavigationService<AccountViewModel> accountNavigationService)
        {
            LoginCommand = new LoginCommand(this, accountStore, accountNavigationService);
        }
    }
}
