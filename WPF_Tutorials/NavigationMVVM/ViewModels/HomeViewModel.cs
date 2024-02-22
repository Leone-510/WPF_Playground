using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Home - Welcome message.";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(AccountStore accountStore, NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(
                navigationStore, () => new LoginViewModel(accountStore, navigationStore)));
        }
    }
}
