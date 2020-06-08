using System;

namespace Exercise_09
{
    class Library
    {
        Shelf[] shelves;

        public Library(Shelf[] shelves)
        {
            SetShelves(shelves);
        }

        private void SetShelves(Shelf[] shelves)
        {
            if(shelves == null)
            {
                throw new ArgumentException();
            }
            else
            {
                this.shelves = shelves;
            }
        }

        public int CountAuthor(string author)
        {
            int count = 0;

            foreach(Shelf shelf in this.shelves)
            {
                foreach(Book book in shelf.GetBooks())
                {
                    if(book.GetAuthor() == author)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
