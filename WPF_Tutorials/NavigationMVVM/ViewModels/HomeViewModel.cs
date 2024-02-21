using NavigationMVVM.Commands;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Home - Welcome message.";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, 
                () => new LoginViewModel(navigationStore));
        }
    }
}
