using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    internal class Book
    {
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book(string name, string edition, string author, string isbn)
        {
            Name = name;    
            Edition = edition;
            Author = author;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"{Name};{Edition};{Author};{ISBN};";
        }

        public string PrintBook()
        {
            return $"Nome: {Name} | Edição: {Edition} | Autor(es): {Author} | ISBN: {ISBN}";
        }
    }
}
