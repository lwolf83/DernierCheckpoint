using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class Artist
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string PicturesURIBig { get; set; }
        public string PicturesURISmall { get; set; }

    }
}
