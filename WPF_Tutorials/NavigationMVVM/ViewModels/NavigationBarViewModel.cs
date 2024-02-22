using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateAccountCommand { get; set; }
        public ICommand NavigateLoginCommand { get; set; }

        public NavigationBarViewModel(
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<AccountViewModel> accountNavigationService,
            NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }

    }
}
