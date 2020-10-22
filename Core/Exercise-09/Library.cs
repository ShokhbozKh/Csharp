using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_09
{
    class Library
    {
        readonly Shelf[] shelves;

        public Library(Shelf[] shelves)
        {
            this.shelves = shelves;
        }

        public int CountAuthor(string author)
        {
            int counter = 0;

            foreach (Shelf shelf in shelves)
                foreach (Book book in shelf.GetBooks())
                    if (book.GetAuthor().Equals(author))
                        counter++;

            return counter;
        }
    }
}
