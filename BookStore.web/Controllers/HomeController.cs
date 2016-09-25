using BookStore.Domain.Classes;
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
        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;

        }


        public ActionResult Index(String searchString)
        {
            
            IEnumerable<Book> books;
            books = bookService.GetBooks().ToList();
            ViewBag.genres = books.Select(b => b.genre).Distinct();
            //books = books.Where(b => b.name.Contains(searchString));

            if (Request.IsAjaxRequest())
            {
                books = books.Where(b => b.name.Contains(searchString));
                return PartialView("BookPartial", books);
            }
            return View(books);
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