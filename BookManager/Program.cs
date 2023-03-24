using BookManager;

internal class Program
{
    private static void Main(string[] args)
    {
        int op;
        Shelf shelf = new();

        shelf.LoadData(shelf.Books, shelf.booksPath);
        shelf.LoadData(shelf.ReadingBooks, shelf.readingPath);
        shelf.LoadData(shelf.LoanedBooks, shelf.loanedPath);

        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    Console.WriteLine("-----ESTANTE DE LIVROS-----");
                    shelf.AddBook();
                    break;
                case 2:
                    Console.Write("Informe o nome do livro que está lendo: ");
                    string bookReading = Console.ReadLine();
                    shelf.Reading(bookReading, shelf.Books);
                    break;
                case 3:
                    Console.Write("Informe o nome do livro que você emprestou: ");
                    string bookLoaned = Console.ReadLine();
                    shelf.Loaned(bookLoaned, shelf.Books);
                    break;
                case 4:                
                    int opc = ListBookMenu();
                    switch (opc)
                    {
                        case 1:
                            shelf.PrintBooks(shelf.Books);
                            break;
                        case 2:
                            shelf.PrintBooks(shelf.ReadingBooks);
                            break;
                        case 3:
                            shelf.PrintBooks(shelf.LoanedBooks);
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Escolha uma opção valida!");
                            break;
                    }
                    break;
                case 5:
                    shelf.SaveData(shelf.Books, shelf.booksPath);
                    shelf.SaveData(shelf.ReadingBooks, shelf.readingPath);
                    shelf.SaveData(shelf.LoanedBooks, shelf.loanedPath);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Escolha uma opção valida!");
                    break;
            }
        } while (true);
    }

    private static int Menu()
    {
        Console.WriteLine($"----ESTANTE VIRTUAL----" +
                             $"\n1 - Adicionar livro" +
                             $"\n2 - Adicionar livro a lista de leitura" +
                             $"\n3 - Emprestar livro" +
                             $"\n4 - Listar livros" +
                             $"\n5 - Sair e salvar" +
                             "\n-----------------------");
        return int.Parse(Console.ReadLine());
    }

    public static int ListBookMenu()
    {
        Console.WriteLine($"----ESTANTE VIRTUAL----" +
                             $"\n1 - Estante virtual" +
                             $"\n2 - Estante de leitura" +
                             $"\n3 - Estante de emprestado" +
                             $"\n4 - Cancelar" +
                             "\n-----------------------");

        return int.Parse(Console.ReadLine());
    }
}