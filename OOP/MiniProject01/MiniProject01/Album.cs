using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject01
{
    [Serializable]
    public class Album : ObjectPlus
    {
        
        private ICollection<Song> _songList = new List<Song>();
        public ICollection<Song> SongList => _songList.ToImmutableList();

        public void AddSong(Song song)
        {
            if (_songList.Contains(song))
            {
                return;
            }

            _songList.Add(song);
        }

        public void RemoveSong(Song song)
        {
            if (!_songList.Contains(song))
            {
                return;
            }

            _songList.Remove(song);
        }
    }
}