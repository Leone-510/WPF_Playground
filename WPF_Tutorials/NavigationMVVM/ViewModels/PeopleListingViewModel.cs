using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PersonViewModel> _people;

        public IEnumerable<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get; }

        public PeopleListingViewModel(INavigationService addPersonNavigationService)
        {
            AddPersonCommand = new NavigateCommand(addPersonNavigationService);

            _people = new ObservableCollection<PersonViewModel>();

            _people.Add(new PersonViewModel("George"));
            _people.Add(new PersonViewModel("Mary"));
            _people.Add(new PersonViewModel("Anna"));
        }
    }
}
