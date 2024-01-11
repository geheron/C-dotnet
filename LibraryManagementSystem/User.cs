using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class User
    {
        public string userId;
        public string name;
        public List<KeyValuePair<Book, int>> borrowedBooks;

        public User(string userId, string name)
        {
            this.userId = userId;
            this.name = name;
            borrowedBooks = new List<KeyValuePair<Book, int>>();
        }
    }
}
