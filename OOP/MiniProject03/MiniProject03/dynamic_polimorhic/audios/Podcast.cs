using System;
using System.Collections.Generic;

namespace MiniProject01
{
    [Serializable]
    public class Podcast : Audio
    {
        public IEnumerable<PodcastGenre> Genres { get; set; }
        public Dictionary<User, int> PausedAt { get; set; }

        public Podcast(string name, int duration, User owner, DateTime releaseDate) : base(name, duration, owner,
            releaseDate)
        {
        }

        public override void Play(User user)
        {
            if (!PausedAt.ContainsKey(user))
            {
                base.Play(user);
            }
            else
            {
                Play(user, PausedAt[user]);
            }
        }

        public virtual void Play(User user, int startSecond)
        {
            ListenEvent.AddListenEvent(user, this);
            Console.WriteLine($"Podcast {Name} started playing from {startSecond} second");
        }

        public override void Stop(User user)
        {
            PausedAt[user] = PlayingAt();
            base.Stop(user);
            Console.WriteLine($"Podcast {Name} stopped playing at {PausedAt} second");
        }

        public override string ToString()
        {
            return
                $"Podcast Name:\"{Name}\" Duration: {Duration} Owner: {Owner} Released: {ReleaseDate} ListenCount: {ListenEvents.Count}";
        }

        public static ICollection<Podcast> GetMostListenedPodcasts(int topCount)
        {
            return (ICollection<Podcast>) GetMostListenedAudios(typeof(Podcast), topCount);
        }
    }
}