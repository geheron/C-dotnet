using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Harry", "JK", "101", "Fiction");
            Book b2 = new Book("Science", "ABC", "102", "Education");
            Book b3 = new Book("Death", "Dean", "103", "Non-fiction");
            Book b4 = new Book("Life", "Geheron", "104", "Non-fiction");

            Library l = Library.Instance;
            l.AddBook(b1, 10);
            l.AddBook(b2, 13);
            l.AddBook(b3, 5);
            l.DisplayBooks();
            l.AddBook(b2, 15);
            l.DisplayBooks();

            User u1 = l.RegisterUser("geheron7", "Geheron");
            User u2 = l.RegisterUser("gauravmg", "Gaurav");
            User u3 = l.RegisterUser("sathwikc", "Sathwik");
            User u4 = l.RegisterUser("akp", "Avinash");

            l.LibraryDetails();

            l.BorrowBook(u1, b3, 3);
            l.UserBooks(u1);
            l.DisplayBooks();

            l.LibraryDetails();

            l.ReturnBook(u1, b3, 2);
            //l.ReturnBook(u1, b3);

            l.UserBooks(u1);
            l.DisplayBooks();
            l.LibraryDetails();
        }
    }
}
