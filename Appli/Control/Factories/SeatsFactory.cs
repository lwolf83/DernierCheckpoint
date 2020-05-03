using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class SeatsFactory
    {
        public static List<Seat> CreateSeats(string cat, int quantity)
        {
            Category category = CategoriesLoader.Get(cat);
            List<Seat> seats = new List<Seat>();
            for (int i = 0; i < quantity; i++)
            {
                Seat seat = new Seat()
                {
                    Category = category
                };
                seats.Add(seat);
            }
            return seats;
        }

    }
}
