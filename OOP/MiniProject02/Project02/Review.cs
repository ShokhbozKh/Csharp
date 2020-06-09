using System;

namespace MiniProject01
{
    [Serializable]
    public class Review : ObjectPlus
    {
        public User Author { get; set; }
        /*
         * composition
         */
        private Audio _subject;
        private string _text;

        public string Text
        {
            get => _text;
            set => _text = value ?? throw new ArgumentNullException();
        }

        public int Rate { get; set; }
        public DateTime PublishDateTime { get; set; }

        public Review(Audio subject, User author, string text, int rate)
        {
            _subject = subject;
            Author = author;
            Text = text;
            Rate = rate;
        }

        public static Review CreateReview(Audio subject, User author, string text, int rate)
        {
            if (subject == null || author == null)
            {
                throw new ArgumentNullException();
            }

            var result = new Review(subject, author, text, rate);
            subject.AddReview(result);
            return result;
        }
    }
}