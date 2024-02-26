using System.Collections.ObjectModel;

namespace NavigationMVVM.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PersonViewModel> _people;

        public IEnumerable<PersonViewModel> People => _people;

        public PeopleListingViewModel()
        {
            _people = new ObservableCollection<PersonViewModel>();

            _people.Add(new PersonViewModel("George"));
            _people.Add(new PersonViewModel("Mary"));
            _people.Add(new PersonViewModel("Anna"));
        }
    }
}
