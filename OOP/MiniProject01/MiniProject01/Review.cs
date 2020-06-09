using System;

namespace MiniProject01
{
    [Serializable]
    public class Review : ObjectPlus
    {
        public User Author { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}