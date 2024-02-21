using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;

namespace NavigationMVVM.Commands
{
    public class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel();
        }
    }
}
