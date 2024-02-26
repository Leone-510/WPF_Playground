using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PersonViewModel> _people;
        private readonly PeopleStore _peopleStore;

        public IEnumerable<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get; }

        public PeopleListingViewModel(PeopleStore peopleStore, INavigationService addPersonNavigationService)
        {
            _peopleStore = peopleStore;

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);

            _people = new ObservableCollection<PersonViewModel>();
            _people.Add(new PersonViewModel("George"));
            _people.Add(new PersonViewModel("Mary"));
            _people.Add(new PersonViewModel("Anna"));
            
            _peopleStore.PersonAdded += OnPersonAdded;
        }

        private void OnPersonAdded(string name)
        {
            _people.Add(new PersonViewModel(name));
        }

        public override void Dispose()
        {
            _peopleStore.PersonAdded -= OnPersonAdded;

            base.Dispose();
        }
    }
}
