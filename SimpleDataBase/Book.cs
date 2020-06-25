using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase
{
    class Book
    {
        string author;
        string title;
        ushort year;
        string genre;
        uint count;
        uint price;

        public Book(string author, string title, ushort year, 
            string genre, uint count, uint price)
        {
            this.author = author;
            this.title = title;
            this.year = year;
            this.genre = genre;
            this.count = count;
            this.price = price;
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public ushort Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public uint Count
        {
            get { return count; }
            set { count = value; }
        }

        public uint Price
        {
            get { return price; }
            set { price = value; }
        }

        public override string ToString()
        {
            return author + "|" + title + "|" + year + "|" +
                genre + "|" + count + "|" + price;
        }
    }
}
