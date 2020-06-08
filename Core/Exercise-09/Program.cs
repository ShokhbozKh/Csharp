using static System.Console;

namespace Exercise_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Shelf shelf1 = new Shelf("Shelf1", new Book[]
            {
               new Book("Babel", "Odessa Tales", "babelode"),
               new Book("Joyce", "Ulisses", "joyceuli")
            });

            Shelf shelf2 = new Shelf("Shelf2", new Book[]
            {
                new Book("Mann", "Dr Faustus", "manff au"),
                new Book("Babel", "Red Cavalry", "babelred")
            });

            Library lib = new Library(
                new Shelf[] { shelf1, shelf2 });

            WriteLine($"# of books by this author is: {lib.CountAuthor("Babel")}");
        }
    }
}
