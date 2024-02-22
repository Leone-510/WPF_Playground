using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Home - Welcome message.";

        public NavigationBarViewModel NavigationBarViewModel { get; set; }

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(NavigationBarViewModel navigationBarViewModel,
            NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
