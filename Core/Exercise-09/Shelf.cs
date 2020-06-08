using System;

namespace Exercise_09
{
    class Shelf
    {
        private string id;
        private Book[] books;

        public Shelf(string id, Book[] books)
        {
            this.id = id;
            SetBooks(books);
        }

        public void SetBooks(Book[] books)
        {
            if(books == null)
            {
                throw new ArgumentException();
            }else
            {
                this.books = books;
            }
        }

        public Book[] GetBooks()
        {
            return this.books;
        }

        public override string ToString()
        {
            return $"Id: [{id}]";
        }
    }
}
