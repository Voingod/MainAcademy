using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstDataAccess;
using CodeFirstModel;
using CodeFirstWebApp.Models;

namespace CodeFirstWebApp.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                //implementation of IDatabaseInitializer that will delete, recreate,
                //and optionally re-seed the database with data only if the model has changed since the database was created. 
                //This implementation require you to use the type of the Database Context because it’s a generic class. 

                // 5) Use BookEntityContext as type for DropCreateDatabaseIfModelChanges<>
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookEntityContext>());
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Get book details
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBookDetails()
        {
            // 6) Declare list of BookModel
            List<BookModel> books = new List<BookModel>();
            try
            {
                // 7) Declare new BookEntityContext in using block
                using (BookEntityContext bookEntity = new BookEntityContext())
                {
                    // 8) Use method ToList() for books from context;
                    // save result to variable value
                    var boooksList = bookEntity.Books.ToList();

                    // 9) In foreach loop 'in value' declare new BookModel
                    // and save Name (and other properties) of book (foreach variable) to declared new BookModel
                    foreach (var book in boooksList)
                    {
                        BookModel bookModel = new BookModel
                        {
                            Author = book.Author,
                            BookName = book.BookName,
                            Edition = book.Edition,
                            Publishing = book.Publishing
                        };

                        // 10) Invloke method Add() from list of BookModel with parameter object of BookModel
                        books.Add(bookModel);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            // model - list of BookModel
            return PartialView("_BookDetailView", books);
        }

        /// <summary>
        /// populate some hardcoded value in book table
        /// </summary>
        public ActionResult InsertBookDetail()
        {
            try
            {
                for (int counter = 0; counter < 5; counter++)
                {
                    // 11) Declare new Book with name of property as string value and concatenate it with counter
                    Book book = new Book()
                    {
                        Author = "Author_" + counter,
                        BookName = "BookName_" + counter,
                        Edition = "Edition_" + counter,
                        Publishing = "Publishing_"+ counter
                    };

                    // book - new declared Book
                    using (var context = new BookEntityContext())
                    {
                        context.Books.Add(book);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Json(true);
        }

    }
}
