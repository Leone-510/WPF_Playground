using Reservoom.Commands;
using Reservoom.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;


        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            MakeReservationCommand = new NavigateCommand();

            #region Adding dummy data
            _reservations.Add(
                new ReservationViewModel(
                    new Reservation(
                        new RoomID(1, 2),
                            "Leone",
                            DateTime.Now,
                            DateTime.Now.AddDays(5))));

            _reservations.Add(
                new ReservationViewModel(
                    new Reservation(
                        new RoomID(3, 2),
                            "Joe",
                            DateTime.Now,
                            DateTime.Now)));

            _reservations.Add(
                new ReservationViewModel(
                    new Reservation(
                        new RoomID(2, 4),
                            "May",
                            DateTime.Now,
                            DateTime.Now)));
            #endregion
        }
    }
}
