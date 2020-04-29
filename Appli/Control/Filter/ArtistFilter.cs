using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public class ArtistFilter
    {
        private List<Artist> _artists;
        private int _numberOfElement;

        private int _begin = 0;
        private int _end;

        public ArtistFilter(List<Artist> artists)
        {
            _artists = artists;
            _end = _artists.Count;
            _numberOfElement = _end;
        }

        public void SetElementNumber(int n)
        {
            if (n > _artists.Count)
            {
               _numberOfElement = _artists.Count;
                
            }
            else
            {
                _numberOfElement = n;
            }

            _end = _begin + n;
        }

        public List<Artist> Get()
        {
            return _artists.Skip(_begin).Take(_numberOfElement).ToList();
        }

        public List<Artist> MoveLeft()
        {
            if(_begin != 0)
            {
                _begin = _begin - 1;
                _end = _end - 1;
            }

            return Get();
        }

        public List<Artist> MoveRight()
        {
            if (_end < _artists.Count)
            {
                _begin = _begin + 1;
                _end = _end + 1;
            }

            return Get();
        }

        public bool isFullLeft()
        {
            return (_begin == 0);
        }

        public bool isFullRight()
        {
            return (_end == _artists.Count);
        }

    }
}
