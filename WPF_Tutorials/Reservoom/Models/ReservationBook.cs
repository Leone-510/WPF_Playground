using Reservoom.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }

        /// <summary>
        /// Get all reservations for a User.
        /// </summary>
        /// <returns>All reservations in the reservation book for a User</returns>
        public IEnumerable<Reservation> GetAllReservationsForUser(string username)
        {
            return _reservations.Where(r => r.Username == username);
        }

        /// <summary>
        /// Add a reservation to the reservation book.
        /// </summary>
        /// <param name="reservation">The incoming reservation</param>
        /// <exception cref="ReservationConflictException">Thrown if incoming reservation conflicts with existing reservation.</exception>
        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in _reservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(
                        existingReservation: existingReservation,
                        incomingReservation: reservation);
                }
            }

            _reservations.Add(reservation);
        }
    }
}
