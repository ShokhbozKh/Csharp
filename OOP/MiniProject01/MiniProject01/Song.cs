using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProject01
{
    [Serializable]
    public class Song : Audio
    {
        public Album Album { get; set; }
        public IEnumerable<MusicGenre> Genres { get; set; }

        public Song(string name, int duration, User owner, DateTime releaseDate) : base(name, duration, owner,
            releaseDate)
        {
        }

        public override string ToString()
        {
            return
                $"Song Name:\"{Name}\" Duration: {Duration} Owner: {Owner} Released: {ReleaseDate} ListenCount: {ListenCount}";
        }

        public static ICollection<Song> GetMostListenedSongs(int topCount)
        {
            return (ICollection<Song>) GetMostListenedAudios(typeof(Song), topCount);
        }

        public void AddToAlbum(Album album)
        {
            if (Album.Equals(album))
            {
                return;
            }

            Album = album;
            album.AddSong(this);
        }

        public void RemoveFromAlbum(Album album)
        {
            if (!Album.Equals(album))
            {
                return;
            }

            Album = null;
            album.RemoveSong(this);
        }
    }
}