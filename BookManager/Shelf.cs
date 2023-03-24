using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    internal class Shelf
    {
        public List<Book> Books { get; set; }
        public List<Book> ReadingBooks { get; set; }
        public List<Book> LoanedBooks { get; set; }

        private FileSave fs;

        public string booksPath = @"C:\Users\adm\Documents\Books\books.txt";
        public string readingPath = @"C:\Users\adm\Documents\Books\reading.txt";
        public string loanedPath = @"C:\Users\adm\Documents\Books\loaned.txt";

        public Shelf()
        {
            Books = new();
            ReadingBooks = new();
            LoanedBooks = new();
            fs = new FileSave();
        }

        public void SaveData(List<Book> bookList, string path)
        {
            fs.AddOnBookShelf(bookList, path);
        }

        public void LoadData(List<Book> bookList, string path)
        {
            fs.LoadData(bookList, path);
        }

        public Book FindBook(string bookName, List<Book> books)
        {
            foreach (var book in books)
            {
                if (book.Name.Equals(bookName))
                {
                    return book;
                }
            }

            return null;
        }

        public Book CreateBook()
        {
            Console.WriteLine("Informe o nome do livro: ");
            string nameBook = Console.ReadLine();
            Console.WriteLine("Informe a edição do livro: ");
            string editionBook = Console.ReadLine();
            Console.WriteLine("Informe o autor ou autores do livro separados por virgula: ");
            string authorBook = Console.ReadLine();
            Console.WriteLine("Informe o ISBN do livro: ");
            string isbnBook = Console.ReadLine();

            return new Book(nameBook, editionBook, authorBook, isbnBook);
        }

        public void AddBook()
        {
            Book newBook = CreateBook();
            Books.Add(newBook);
        }

        public void Reading(string bookName, List<Book> books)
        {
            Book readingBook = FindBook(bookName, books);

            if(readingBook == null)
            {
                Console.WriteLine("Você não possui esse livro na estante!");
                return;
            }

            ReadingBooks.Add(readingBook);
            Books.Remove(readingBook);
        }

        public void Loaned(string bookName, List<Book> books)
        {
            Book loanedBook = FindBook(bookName, books);

            if (loanedBook == null)
            {
                Console.WriteLine("Você não possui esse livro na estante!");
                return;
            }

            LoanedBooks.Add(loanedBook);
            books.Remove(loanedBook);
        }

        public void PrintBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.PrintBook());
            }
        }
    }
}
