using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Reservoom.Commands
{
    class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly NavigationService _reservationViewNavigationService;
        private readonly Hotel _hotel;

        public MakeReservationCommand(
            MakeReservationViewModel makeReservationViewModel, 
            NavigationService reservationViewNavigationService,
            Hotel hotel)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _reservationViewNavigationService = reservationViewNavigationService;
            _hotel = hotel;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                roomID: new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                username: _makeReservationViewModel.Username,
                startTime: _makeReservationViewModel.StartDate,
                endTime: _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Successfully reserved room.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show("This room is already taken.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
