using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.ViewModels;
using System.Windows;

namespace Reservoom.Commands
{
    class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
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
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show("This room is already taken.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
