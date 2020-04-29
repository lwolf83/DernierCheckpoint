using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public class ArtistsLoader
    {
        public static List<Artist> All()
        {
            var context = new WildCircusContext();
            List<Artist> artists = context.Artists.ToList();
            return artists;
        }

        public static List<Artist> Get(int n)
        {
            var context = new WildCircusContext();
            List<Artist> artists = context.Artists.ToList().Take(n).ToList();
            return artists;
        }


    }
}
