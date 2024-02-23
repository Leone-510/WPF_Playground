using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public string? Username => _accountStore.CurrentAccount?.Username;
        public string? Email => _accountStore.CurrentAccount?.Email;
        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(AccountStore accountStore, INavigationService homeNavigationService)
        {
            _accountStore = accountStore;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);

            // AccountStore references AccountViewModel.OnCurrentAccountChanged, so the
            // Garbage Colector can't clean up the view model (unsubscribe is required)
            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(Email));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }

        ~AccountViewModel()
        {
            
        }
    }
}
