using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_1_lab
{
    interface ILibraryUser
    {
        void AddBook(string addBook);
        void RemoveBook(string removeBook);
        void BookInfo(int booksIndex);
        string BooksCount();
    }
}
