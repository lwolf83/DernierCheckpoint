using System;
using System.Collections.Generic;
using System.Text;
using WildCircus;

namespace C3Server
{
    public class ReservationData
    {
        public string Login { get; set; }
        public string Show { get; set; }
        public string City { get; set; }

        public DateTime Date { get; set; }

        public int VipSeats { get; set; }
        public int NormalSeats { get; set; }
        public int EcoSeats { get; set; }

        public ReservationData()
        {

        }

        public ReservationData(string login)
        {
            Reservation reservation = ReservationLoader.GetFromLogin(login);
            Login = login;
            Show = reservation.Performance.Show.Name;
            City = reservation.Performance.City;
            Date = reservation.Performance.StartTime;
            VipSeats = reservation.GetSeats("VIP");
            NormalSeats = reservation.GetSeats("Normal");
            EcoSeats = reservation.GetSeats("Eco");
        }

    }
}
