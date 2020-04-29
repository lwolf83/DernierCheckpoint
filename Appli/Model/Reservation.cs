using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public partial class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public User User { get; set; }
        public string State { get; set; }
        public List<Seat> Seats { get; set; }


    }
}
