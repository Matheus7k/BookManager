using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    internal class FileSave
    {
        private StreamWriter sw;
        private StreamReader sr;

        public void AddOnBookShelf(List<Book> books, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    sw = new(path);

                    foreach (var book in books)
                    {
                        sw.WriteLine(book.ToString());
                    }

                    sw.Close();
                }
                else
                {
                    sw = new(path);
                    sw.WriteLine();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void LoadData(List<Book> bookList, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    if (new FileInfo(path).Length > 1)
                    {
                        sr = new(path);

                        do
                        {
                            string[] data = sr.ReadLine().Split(";");

                            string name = data[0];
                            string edition = data[1];
                            string author = data[2];
                            string isbn = data[3];

                            bookList.Add(new Book(name, edition, author, isbn));
                        } while (!sr.EndOfStream);
                        sr.Close();
                    }
                }
                else
                {
                    sw = new(path);
                    sw.WriteLine();
                    sw.Close();
                }
            }catch (Exception e) { throw e; }
        }
    }
}
