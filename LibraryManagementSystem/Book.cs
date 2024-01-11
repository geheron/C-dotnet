using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Book
    {
        public string title;
        public string author;
        public string isbn;
        public string genre;
        public int quantity;

        public Book(string title, string author, string isbn, string genre)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.genre = genre;
            this.quantity = 0;
        }
    }
}
