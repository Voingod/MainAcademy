using System;

namespace CSharp_Net_module1_2_1_lab
{

    class LibraryUser : ILibraryUser
    {
        
        public string FirstName {get;}
        public string LastName { get; }
        public int Id { get; }
        public string Phone { get; set; }
        public int BookLimit { get; }
      

        private string[] bookList = new string[5];//
        public string this[int BookList]
        {
            get
            {
                if (BookList >= 0 && BookList <= BookLimit - 1) 
                {
                    return bookList[BookList];
                }
                else
                {
                    return null;
                }
                
            }
            set
            {
                if (BookList >= 0 && BookList <= BookLimit - 1)
                {
                    bookList[BookList] = value;
                }
            }
        }
        public LibraryUser(string firstName, string lastName, string phone, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Id = id;
        }
        public LibraryUser()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            Phone = "None";
        }

        public void AddBook(string addBook)
        {
            bookList[0] = "11";
        }

        public void RemoveBook(string removeBook)
        {
            throw new NotImplementedException();
        }

        public void BookInfo(int booksIndex)
        {
            throw new NotImplementedException();
        }

        public string BooksCount()
        {
            throw new NotImplementedException();
        }
    }

}
