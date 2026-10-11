using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetBibliothek
{
    public class Bibliothek
    {
        HashSet<Buch> books = new HashSet<Buch>();
        HashSet<Buch> borrowedBooks = new HashSet<Buch>();

        HashSet<Buch> books2 = new HashSet<Buch>(new BookComparer());


        public bool AddBook(Buch buch)
        {
            return books.Add(buch);
        }

        public bool AddBook2(Buch buch)
        {
            return books2.Add(buch);
        }

        public bool AvailableBooks()
        {
            Console.WriteLine("Available Books:");
            foreach (var buch in books)
            {
                Console.WriteLine($"\t {buch}");
            }
            return true;
        }

        public bool AvailableBooks2()
        {
            Console.WriteLine("Available Books (Comparer):");
            foreach (var buch in books2)
            {
                Console.WriteLine($"\t {buch}");
            }
            return true;
        }

        public bool BorrowBook(string isbn)
        {
            if (isbn == null) return false;

            if (books.Contains(new Buch(isbn, "", "")) && !borrowedBooks.Contains(new Buch(isbn, "", "")))
            {
                foreach (var book in books)
                {
                    if (book.ISBN == isbn)
                    {
                        borrowedBooks.Add(book);
                        books.Remove(book);
                        Console.WriteLine($"You have borrowed: {book}");
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book not available or already borrowed.");
                return false;
            }
            return false;
        }

        public bool ReturnBook(string isbn)
        {
            if (isbn == null) return false;
            if (borrowedBooks.Contains(new Buch(isbn, "", "")))
            {
                foreach (var book in borrowedBooks)
                {
                    if (book.ISBN == isbn)
                    {
                        books.Add(book);
                        borrowedBooks.Remove(book);
                        Console.WriteLine($"You have returned: {book}");
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("This book was not borrowed from this library.");
                return false;
            }
            return false;
        }

        public bool CheckStatus(string isbn)
        {
            if(isbn == null) return false;

            var newBook = new Buch(isbn, "", "");

            foreach (var book in borrowedBooks)
            {
                if (book.Equals(newBook))
                {
                    Console.WriteLine($"The book with ISBN {isbn} is already borrowed.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"The book isnt borrowed.");
                    return false;
                }
            }
            return false;
        }

        public void ViewOverwiew()
        {
            Console.WriteLine($"Current borrowed books:");
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine($"\t{book}");
            }
            Console.WriteLine($"Count:\n\t{borrowedBooks.Count}");
        }

        public void IntersectWith()
        {
            books.IntersectWith(books2);
        }

    }
}
