using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProject01
{
    [Serializable]
    public class Song : Audio
    {
        /*
         * basic association
         */
        private Album _album;

        public Album Album
        {
            get => _album;
            set
            {
                if (_album == null && value != null)
                {
                    _album = value;
                    _album.AddSong(this);
                }
                else if (_album != null && value == null)
                {
                    _album.RemoveSong(this);
                    _album = null;
                }
                else if (_album != null && value != null && _album != value)
                {
                    _album.RemoveSong(this);
                    _album = value;
                    _album.AddSong(this);
                }
            }
        }

        public IEnumerable<MusicGenre> Genres { get; set; }

        public Song(string name, int duration, User owner, DateTime releaseDate) : base(name, duration, owner,
            releaseDate)
        {
        }

        public static ICollection<Song> GetMostListenedSongs(int topCount)
        {
            return (ICollection<Song>) GetMostListenedAudios(typeof(Song), topCount);
        }

        #region Basic

        public void RemoveFromAlbum(Album album)
        {
            if (Album == null || !Album.Equals(album))
            {
                return;
            }

            Album = null;
            album.RemoveSong(this);
        }

        #endregion

        public override string ToString()
        {
            return
                $"Song Name:\"{Name}\" Duration: {Duration} Owner: {Owner} Released: {ReleaseDate} ListenCount: {ListenEvents.Count}";
        }
    }
}