using System;
using System.Collections.Generic;

namespace MiniProject01
{
    [Serializable]
    public class Podcast : Audio
    {
        public IEnumerable<PodcastGenre> Genres { get; set; }
        public int? PausedAt { get; set; }

        public Podcast(string name, int duration, User owner, DateTime releaseDate) : base(name, duration, owner,
            releaseDate)
        {
        }

        public override void Play()
        {
            if (PausedAt == null)
            {
                base.Play();
            }
            else
            {
                Play(PausedAt.Value);
            }
        }

        public virtual void Play(int startSecond)
        {
            Console.WriteLine($"Podcast {Name} started playing from {startSecond} second");
        }

        public override void Stop()
        {
            PausedAt = PlayingAt();
            base.Stop();
            Console.WriteLine($"Podcast {Name} stopped playing at {PausedAt} second");
        }

        public override string ToString()
        {
            return
                $"Podcast Name:\"{Name}\" Duration: {Duration} Owner: {Owner} Released: {ReleaseDate} ListenCount: {ListenCount}";
        }

        public static ICollection<Podcast> GetMostListenedPodcasts(int topCount)
        {
            return (ICollection<Podcast>) GetMostListenedAudios(typeof(Podcast), topCount);
        }
    }
}