using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_09
{
    class Book
    {
        readonly string author;
        readonly string title;
        readonly string body;

        public Book(string author, string title, string body)
        {
            this.author = author;
            this.title = title;
            this.body = body;
        }

        public string GetAuthor()
        {
            return this.author;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public string GetBody()
        {
            return this.body;
        }
    }
}
