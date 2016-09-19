using BookStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(BookService bookService)
        {
            this.bookService = bookService;

        }

        public ActionResult Index()
        {



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}