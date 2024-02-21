using NavigationMVVM.Commands;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public string Name => "ViewModelName - Account";

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }
    }
}
