using NavigationMVVM.Commands;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Home - Welcome message.";

        public ICommand NavigateAccountCommand { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateAccountCommand = new NavigateAccountCommand(navigationStore);
        }
    }
}
