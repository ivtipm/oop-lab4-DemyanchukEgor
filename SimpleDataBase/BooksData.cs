using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleDataBase
{
    public class BooksData
    {
        ArrayList book = new ArrayList();

        public ArrayList Book
        {
            get { return book; }
        }
        public void AddBook(string author, string title, ushort year,
            string genre, uint count, uint price)
        {
            Book newBook = new Book(author, title, year, genre, count, price);
            book.Add(newBook);
        }
        public void DeleteBooks() => book.Clear();
        public void DeleteBook(int index) => book.RemoveAt(index);
        public void ChangeAuthor(string author, int index)
        {
            Book bk = (Book)book[index];
            bk.Author = author;
        }
        public void ChangeTitle(string title, int index)
        {
            Book bk = (Book)book[index];
            bk.Title = title;
        }
        public void ChangeYear(ushort year, int index)
        {
            Book bk = (Book)book[index];
            bk.Year = year;
        }
        public void ChangeGenre(string genre, int index)
        {
            Book bk = (Book)book[index];
            bk.Genre = genre;
        }
        public void ChangeCount(uint count, int index)
        {
            Book bk = (Book)book[index];
            bk.Count = count;
        }
        public void ChangePrice(uint price, int index)
        {
            Book bk = (Book)book[index];
            bk.Price = price;
        }
        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Unicode))
            {
                foreach (Book s in book)
                {
                    sw.WriteLine(s.ToString());
                }
            }
        }
        public void OpenFile(string filename)
        {
            if (!System.IO.File.Exists(filename))
                throw new Exception("Файл не существует");

            if (book.Count != 0)
                DeleteBooks();

            using (StreamReader sw = new StreamReader(filename))
            {
                while (!sw.EndOfStream)
                {
                    string str = sw.ReadLine();
                    String[] dataFromFile = str.Split(new String[] { "|" },
                        StringSplitOptions.RemoveEmptyEntries);

                    string author = dataFromFile[0];
                    string title = dataFromFile[1];
                    ushort year = (ushort)Convert.ToUInt64(dataFromFile[2]);
                    string genre = dataFromFile[3];
                    uint count = (uint)Convert.ToUInt64(dataFromFile[4]);
                    uint price = (uint)Convert.ToUInt64(dataFromFile[5]);

                    AddBook(author, title, year, genre, count, price);
                }
            }
        }
        public List<int> SearchFile(string query)
        {
            List<int> cnt = new List<int>();
            query = query.ToLower();
            query = query.Replace(" ", "");
            for (int i = 0; i < book.Count; i++)
            {
                Book bk = (Book)book[i];

                if (bk.Author.ToLower().Replace(" ", "").Contains(query))
                {
                    cnt.Add(i);
                    break; 
                }
                else if (bk.Title.ToLower().Replace(" ", "").Contains(query))
                {
                    cnt.Add(i);
                    break;
                }
            }

            if (cnt.Count == 0) cnt.Add(-1);
            return cnt;
        }
        public void Sort(SortDirection direction)
        {
            book.Sort(new AuthorComparer(direction));
        }
    }
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public class AuthorComparer : IComparer
    {
        private SortDirection m_direction = SortDirection.Ascending;

        public AuthorComparer() : base() { }

        public AuthorComparer(SortDirection direction)
        {
            this.m_direction = direction;
        }

        int IComparer.Compare(object x, object y)
        {
            Book book1 = (Book)x;
            Book book2 = (Book)y;

            return (this.m_direction == SortDirection.Ascending) ?
               book1.Author.CompareTo(book2.Author) :
                book2.Author.CompareTo(book1.Author);
        }
    }
}
