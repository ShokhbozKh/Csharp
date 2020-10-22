using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_09
{
    class Shelf
    {
        readonly string id;
        readonly Book[] books;

        public Shelf(string id, Book[] books)
        {
            this.id = id;
            this.books = books;
        }

        public string GetId()
        {
            return this.id;
        }

        public Book[] GetBooks()
        {
            return this.books;
        }
    }
}
