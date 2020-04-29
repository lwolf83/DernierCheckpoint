using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public partial class Performance
    {
        public Guid PerformanceId { get; set; }

        public int MaxVipSeat { get; set; } = 25;
        public int MaxNormalSeat { get; set; } = 50;
        public int MaxEcoSeat { get; set; } = 100;

        public Show Show { get; set; }

        public List<Reservation> Reservations { get; set; }

        public DateTime StartTime { get; set; }
        public string City { get; set; }

    }
}
