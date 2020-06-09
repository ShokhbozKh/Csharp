using System;
using MiniProject04.ordered_bag_custom_attribute;

namespace MiniProject04
{
    public class Song : Audio
    {
        /*
         * ordered
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

        public Song(string name, int duration, User owner, DateTime releaseDate) : base(name, duration, owner,
            releaseDate)
        {
        }

        public void RemoveFromAlbum(Album album)
        {
            if (Album == null || !Album.Equals(album))
            {
                return;
            }

            Album = null;
            album.RemoveSong(this);
        }

        public override string ToString()
        {
            return
                $"Song Name:\"{Name}\" Duration: {Duration} Owner: {Owner} Released: {ReleaseDate}";
        }
    }
}