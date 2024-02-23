using NavigationMVVM.ViewModels;

namespace NavigationMVVM.Stores
{
    public class ModalNavigationStore
    {
        public bool IsOpen => CurrentViewModel != null; // If CurrentViewModel is null, then modal should not be open

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
