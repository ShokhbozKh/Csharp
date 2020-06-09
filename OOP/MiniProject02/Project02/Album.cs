using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MiniProject01
{
    public class Album : ObjectPlus
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }

        private ICollection<Song> _songList = new List<Song>();

        public ICollection<Song> SongList
        {
            get => _songList.ToImmutableList();
            set => _songList = value ?? throw new ArgumentNullException();
        }

        public Album(string name)
        {
            Name = name;
        }

        #region basic_association

        public void AddSong(Song song)
        {
            if (song == null || _songList.Contains(song))
            {
                return;
            }

            _songList.Add(song);

            song.Album = this;
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