using CSharp_Net_module3_1_5_lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace CSharp_Net_module3_1_5_lab.Controllers
{
    public class TestAjaxController : Controller
    {
        //
        // GET: /TestAjax/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestHtmlView()
        {
            //add some code 
            return View();
        }
        [HttpPost]

        // add public ActionResult TestHtmlRedirect()
        public ActionResult TestHtmlRedirect()
        {
            return Redirect("TestHtml");
        }

        public ActionResult TestAjaxView()
        {
            //add some code 
            return View();
        }
        //[HttpPost]
        //  add public ActionResult TestAjaxRedirect()
        [HttpPost]
        public ActionResult TestAjaxRedirect()
        {
            return Redirect("TestAjax");
        }

        public ActionResult HtmlViewModel()
        {
            return View();
        }

        public ActionResult AjaxViewModel()
        {
            return View(new BookModel());
        }

        //HTML Form Method
        //[HttpPost]
        //add public ActionResult HtmlViewModel(BookModel bookModel)
        //return PartialView("PartialAjax");
        [HttpPost]
        public ActionResult HtmlViewModel(BookModel bookModel)
        {
            return PartialView("PartialAjax");
        }

        //AJAX Form Method
        //[HttpPost]
        //add public ActionResult AjaxViewModel(BookModel bookModel)
        [HttpPost]
        public ActionResult AjaxViewModel(BookModel bookModel)
        {
            return View();
        }

    }
}