using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public partial class Reservation
    {
        public int GetVip
        {
            get { return GetSeats("Vip"); }
        }
        public int GetNormal
        {
            get { return GetSeats("Normal"); }
        }
        public int GetEco
        {
            get { return GetSeats("Eco"); }
        }

        public void Save()
        {
            var context = new WildCircusContext();
            context.Update(this);
            context.SaveChanges();
        }

        public int GetSeats(string cat)
        {
            cat = cat.ToUpper();
            int nbSeats = Seats.Where(s => s.Category.Name == cat).Count();
            return nbSeats;
        }

    }
}
