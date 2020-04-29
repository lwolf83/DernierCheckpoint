using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class ArtistFactory
    {
        public static Artist Create(string name, string description)
        {
            Artist currentArtist = new Artist()
            {
                Name = name,
                Description = description
            };
            return currentArtist;
        }
    }
}
