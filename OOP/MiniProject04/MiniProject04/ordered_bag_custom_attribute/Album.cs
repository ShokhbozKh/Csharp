using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject04
{
    public class Album
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }

        /*
         * ordered
         */
        private IList<Song> _songList = new List<Song>();

        public IList<Song> SongList
        {
            get => _songList.ToImmutableList();
            set => _songList = value ?? throw new ArgumentNullException();
        }

        public Album(string name)
        {
            Name = name;
        }

        #region basic_association

        public void AddSongAtIndex(int index, Song song)
        {
            if (index >= _songList.Count)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (song == null || _songList.Contains(song))
            {
                return;
            }

            _songList.Insert(index, song);
            song.Album = this;
        }

        public void AddSong(Song song)
        {
            AddSongAtIndex(_songList.Count - 1, song);
        }

        public void RemoveSong(Song song)
        {
            if (song == null || !_songList.Contains(song))
            {
                return;
            }

            _songList.Remove(song);
            song.RemoveFromAlbum(this);
        }

        #endregion

        public override string ToString()
        {
            var result = $"Album \"{_name}\", {_songList.Count} songs\n";

            foreach (var song in _songList)
            {
                result += "    " + song + "\n";
            }

            return result;
        }
    }
}