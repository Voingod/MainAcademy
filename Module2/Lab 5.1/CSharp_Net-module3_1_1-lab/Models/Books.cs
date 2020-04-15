using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CSharp_Net_module3_1_1_lab.Models
{
    public class Books
    {
        // 2) Declare list of BookModels
        public List<BookModels> books = new List<BookModels>();

        public Books()
        {
            // 3) Add several books to list
            books.Add(new BookModels
            {
                Id = books.Count,
                Author = "Gogol",
                BookName = "Death Soul",
                Edition = "234.n",
                Publishing = "Moscow Print"
            }) ;

            books.Add(new BookModels
            {
                Id = books.Count,
                Author = "Jack London",
                BookName = "Martin Iden",
                Edition = "43.t",
                Publishing = "GB Print"
            });

            books.Add(new BookModels
            {
                Id = books.Count,
                Author = "Daniel Keyes",
                BookName = "Flowers for Algernon",
                Edition = "uu.12",
                Publishing = "Harcourt, Brace & World"
            });
        }

        // 4) Change parameters and return type of CreateBook()
        public void CreateBook(BookModels bookModels)
        {
            // 5) Add new book to list
            bookModels.Id = books.Count;
            books.Add(bookModels);
            

        }
        // 6) Change parameters and return type of UpdateBook()
        public void UpdateBook(BookModels bookModel)
        {
            int length = books.Count;
            for (int i = 0; i < length; i++)
            {
                if (books[i].BookName == bookModel.BookName)
                {
                    books.RemoveAt(i);
                    books.Add(bookModel);
                }
            }

            // 7) use foreach to move through all books in list;
            // if book is find: remove it and add new from parameter

        }

    }
}