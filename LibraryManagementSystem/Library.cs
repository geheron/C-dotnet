using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Library
    {
        private static Library instance = null;
        public static Library Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Library();
                }
                return instance;
            }
        }

        List<Book> bookList;
        int totalRegBookCount;
        int totalCountBooks;
        List<User> userList;

        private Library()
        {
            bookList = new List<Book>();
            userList = new List<User>();
            totalRegBookCount = 0;
            totalCountBooks = 0;
        }

        public void AddBook(Book b, int quantity)
        {
            if (bookList.Contains(b))
            {
                b.quantity += quantity;
                totalCountBooks += quantity;
                totalRegBookCount += quantity;
                Console.WriteLine("Book added");
            }
            else
            {
                b.quantity = quantity;
                totalCountBooks += quantity;
                totalRegBookCount += quantity;
                bookList.Add(b);
                Console.WriteLine("A new book has been added to the library");
            }
        }

        public void DisplayBooks()
        {
            Console.WriteLine($"Available Books:");
            int serial = 0;
            foreach (Book b in bookList)
            {
                serial++;
                Console.WriteLine($"{serial}> Title: {b.title} -- Author: {b.author} -- ISBN: {b.isbn} -- Genre: {b.genre} -- Quantity: {b.quantity}");
            }
        }

        public User RegisterUser(string userId, string name)
        {
            User u = new User(userId, name);
            userList.Add(u);
            Console.WriteLine("New user created");
            Console.WriteLine($"UserID: {u.userId} -- Name: {u.name}");
            return u;
        }

        public void LibraryDetails()
        {
            Console.WriteLine("Showing library details");
            Console.WriteLine($"Number of different books: {bookList.Count()}");
            Console.WriteLine($"Total number of registered books available: {totalRegBookCount}");
            Console.WriteLine($"Total number of books currently available: {totalCountBooks}");
            Console.WriteLine($"Total number of users available: {userList.Count()}");
        }

        public void BorrowBook(User u, Book b, int quantity)
        {
            if (userList.Contains(u))
            {
                if (bookList.Contains(b))
                {
                    if (b.quantity >= quantity)
                    {
                        b.quantity -= quantity;
                        totalCountBooks -= quantity;
                        u.borrowedBooks.Add(new KeyValuePair<Book, int>(b, quantity));
                        Console.WriteLine($"{quantity} copies of Book {b.title} borrowed by {u.name}");
                    }
                    else
                    {
                        Console.WriteLine($"Only {b.quantity} copies of {b.title} is available");
                    }
                }
                else
                {
                    Console.WriteLine("Book not available");
                }
            }
            else
            {
                Console.WriteLine("Please register as our user");
            }
        }

        public void ReturnBook(User u, Book b, int quantity)
        {
            if (userList.Contains(u))
            {
                foreach (KeyValuePair<Book, int> bk in u.borrowedBooks)
                {
                    if (bk.Key == b)
                    {
                        if (quantity <= bk.Value)
                        {
                            b.quantity += quantity;
                            totalCountBooks += quantity;
                            int tempValue = bk.Value - quantity;
                            if (tempValue == 0)
                            {
                                u.borrowedBooks.Remove(bk);
                            }
                            else
                            {
                                u.borrowedBooks.Remove(bk);
                                u.borrowedBooks.Add(new KeyValuePair<Book, int>(b, tempValue));
                            }
                            //u.borrowedBooks.Remove(b);
                            Console.WriteLine($"{quantity} Book(s) of {b.title} returned to library by {u.name}");
                            return;
                        }
                    }
                }

                Console.WriteLine($"User {u.name} has not borrowed this book from our library");
            }
            else
            {
                Console.WriteLine("User does not exist");
            }
        }

        public void UserBooks(User u)
        {
            if (u.borrowedBooks.Count() == 0)
            {
                Console.WriteLine($"{u.name} has not borrowed any books");
                return;
            }
            int serial = 0;
            Console.WriteLine($"{u.name} has borrowed the following books:");
            foreach (KeyValuePair<Book, int> b in u.borrowedBooks)
            {
                serial++;
                Console.WriteLine($"{serial}> Book name: {b.Key.title} -- Borrowed count: {b.Value}");
            }
        }
    }
}
