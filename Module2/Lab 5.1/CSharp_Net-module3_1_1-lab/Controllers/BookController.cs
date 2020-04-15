using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp_Net_module3_1_1_lab.Models;

namespace CSharp_Net_module3_1_1_lab.Controllers
{
    public class BookController : Controller
    {
        // 8) Declate public static object of Books
        public static Books books = new Books();

        // 9) Add view Index.cshtml to action method Index();
        // add new folder 'Book' to 'View';
        // use context menu on Index() -> Add View...;
        // select "List" template and BookModels as model

        // Note: Don't use DBContext
        //
        // GET: /Book/
        public ActionResult Index()
        {
            ViewBag.Books = books.books;
            // 10) Add parameter of View(); it must be the list of books
            return View();
        }

       [HttpPost]
        public ActionResult UpdateBook(int bookId)
        {
            books.UpdateBook(books.books[bookId]);
            return RedirectToAction("Index");
        }

        // 11) Change parameters if it is necessary
        public ActionResult AddBook()
        {
            return View();
        }

        // 12) Add HttpPost attribute
        [HttpPost]
        // 13) Add parameter - object of BookModels
        public ActionResult AddBook(BookModels bookModels)
        {
            books.CreateBook(bookModels);
            ViewBag.Books = books.books;
            AddBook();
            // 14) Invoke AddBook() method of book list
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(BookModels bookModels, int id)
        {
            books.books[id] = bookModels;
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(BookModels bookModels)
        {
            bookModels.Author = books.books[bookModels.Id].Author;
            bookModels.BookName = books.books[bookModels.Id].BookName;
            bookModels.Edition = books.books[bookModels.Id].Edition;
            bookModels.Publishing = books.books[bookModels.Id].Publishing;

            return View(bookModels);
        }
        public ActionResult Delete(int id)
        {
            books.books.RemoveAt(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int id)
        {
            return View(books.books[id]);
        }
    }
}