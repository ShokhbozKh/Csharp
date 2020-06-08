using System;

namespace Exercise_09
{
    class Book
    {
        private string author, title, body;

        public Book(string author, string title, string body)
        {
            SetAuthor(author);
            SetTitle(title);
            SetBody(body);
        }

        public string GetAuthor()
        {
            return this.author;
        }

        private void SetAuthor(string author)
        {
            if(string.IsNullOrEmpty(author))
            {
                throw new ArgumentException();
            }
            else
            {
                this.author = author;
            }
        }

        public string GetTitle()
        {
            return this.title;
        }

        private void SetTitle(string title)
        {
            if(string.IsNullOrEmpty(title))
            {
                throw new AggregateException();
            }
            else
            {
                this.title = title;
            }
        }

        public string GetBody()
        {
            return this.body;
        }

        private void SetBody(string body)
        {
            if (string.IsNullOrEmpty(body))
            {
                throw new AggregateException();
            }
            else
            {
                this.body = body;
            }
        }
    }
}
