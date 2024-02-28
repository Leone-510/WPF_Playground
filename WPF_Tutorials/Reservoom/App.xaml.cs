using Reservoom.Exceptions;
using Reservoom.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Leone Suites Hotel");

            try
            {
                hotel.MakeReservation(new Reservation(
                        new RoomID(1, 3),
                        "Leone",
                        new DateTime(2015, 1, 1),
                        new DateTime(2015, 1, 2)));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 2),
                    "Leone",
                    new DateTime(2015, 1, 3),
                    new DateTime(2015, 1, 4)));
            }
            catch (ReservationConflictException ex)
            {
                string exMessage = ex.Message;
            }

            IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("Leone");

            base.OnStartup(e);
        }
    }
}
