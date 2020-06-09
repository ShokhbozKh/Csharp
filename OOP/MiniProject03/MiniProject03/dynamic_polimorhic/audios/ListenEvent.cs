using System;
using System.Linq;

namespace MiniProject01
{
    public class ListenEvent : ObjectPlus
    {
        public User User { get; set; }
        public Audio Audio { get; set; }

        public DateTime DateTime { get; set; }

        private ListenEvent(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public static ListenEvent AddListenEvent(User user, Audio audio)
        {
            var listenEvent = new ListenEvent(DateTime.Now)
            {
                User = user ?? throw new ArgumentNullException(), 
                Audio = audio ?? throw new ArgumentNullException()
            };
            user.AddListenEvent(listenEvent);
            audio.AddListenEvent(listenEvent);

            return listenEvent;
        }

        public static void RemoveListenEvent(ListenEvent listenEvent)
        {
            listenEvent.User.RemoveListenEvent(listenEvent);
            listenEvent.Audio.RemoveListenEvent(listenEvent);
            listenEvent.User = null;
            listenEvent.Audio = null;
        }
    }
}