using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.ViewModels;

namespace NavigationMVVM.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly ParameterNavigationService<Account, AccountViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, ParameterNavigationService<Account, AccountViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            Account account = new Account()
            {
                Email = $"{_viewModel.Username}@test.com",
                Username = _viewModel.Username
            };

            _navigationService.Navigate(account);   // Navigate using the service, passing the account as parameter
        }
    }
}
