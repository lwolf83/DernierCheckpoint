using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public partial class Reservation
    {
        public void Save()
        {
            var context = new WildCircusContext();
            context.Update(this);
            context.SaveChanges();
        }

        public int GetSeats(string cat)
        {
            int nbSeats = Seats.Where(s => s.Category.Name == cat).Count();
            return nbSeats;
        }

    }
}
