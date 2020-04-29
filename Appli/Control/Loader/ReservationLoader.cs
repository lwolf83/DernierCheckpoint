using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public class ReservationLoader
    {
        public static Reservation GetFromLogin(string login)
        {
            var context = new WildCircusContext();
            List<Show> shows = context.Shows.ToList();
            List<Category> categories = context.Categories.ToList();
            List<Performance> performances = context.Performances.ToList();
            List<Seat> seats = context.Seats.ToList();
            List<User> users = context.Users.ToList();
            Reservation currentReservation  = context.Reservations.Where(r => r.User.Login == login).FirstOrDefault();
            
            return currentReservation;
        }
    }
}
