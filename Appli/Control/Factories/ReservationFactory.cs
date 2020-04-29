using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public static class ReservationFactory
    {
        public static Reservation Create(Performance performance, List<Seat> seats)
        {
            Reservation reservation = new Reservation();
            reservation.User = UserSingleton.GetInstance.user;
            reservation.Performance = performance;
            reservation.State = "In Progress";
            reservation.Seats = seats;
            return reservation;
        }

    }
}
