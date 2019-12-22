using System;

namespace CSharp_Net_module1_2_1_lab
{

    class LibraryUser : ILibraryUser
    {
        private const int bookLimit = 5;
        public string FirstName {get;}
        public string LastName { get; }
        public int Id { get; }
        public string Phone { get; set; }
        static public int BookLimit 
        {
            get => bookLimit;
        }

        private string[] bookList = new string[BookLimit];

        private bool LimitCheck(int BookList)
        {
            return BookList >= 0 && BookList <= BookLimit - 1;
        }
        public string this[int BookList]
        {
            get
            {
                if (LimitCheck(BookList))  
                {
                    return bookList[BookList];
                }
                else
                {
                    throw new IndexOutOfRangeException($"Book with index {BookList} not found");
                }
                
            }
            set
            {
                if (LimitCheck(BookList))
                {
                    bookList[BookList] = value;
                }
                else
                {
                     throw new IndexOutOfRangeException($"You can have only {BookLimit} books");
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
            Id = -1;
        }

        public void AddBook(string addBook)
        {
            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] == null)
                {
                    bookList[i] = addBook;
                    break;
                }
                else if (i == bookList.Length - 1) 
                {
                    Console.WriteLine($"You can have only {BookLimit} books");
                }
            }
        }

        public void RemoveBook(string removeBook)
        {

            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] == removeBook)
                {
                    bookList[i] = null;
                    break;
                }
            }
        }

        public void BookInfo(int booksIndex)
        {
            if (booksIndex < BookLimit) 
                Console.WriteLine(bookList[booksIndex]);
            else
                Console.WriteLine($"Book with index {booksIndex} not found");
        }

        public string BooksCount()
        {
            int currentBooksCount = 0;
            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] != null)
                {
                    currentBooksCount++;
                }
            }
            return currentBooksCount.ToString();
           // Console.WriteLine($"You have {currentBooksCount} books out of {BookLimit}");
        }
    }

}
