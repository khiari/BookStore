using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Classes;
using BookStore.Domain.DataModel;
using BookStore.Service;

namespace BookStore.web.Controllers
{
    public class BooksController : Controller
    {
        //private BookStoreContext db = new BookStoreContext();
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;

        }

        // GET: Books
        public ActionResult Index()
        {

            IEnumerable<Book> books;
            books = bookService.GetBooks().ToList();          
            ViewBag.genres = books.Select(b => b.genre).Distinct();
            return View(books);
        }
        [ActionName("BestSellers")]
        public ActionResult BestSellers()
        {

            return View();
        }

        [ActionName("NewArrivals")]
        public ActionResult NewArrivals()
        {

            return View();
        }



        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,name,genre,description,price,editor")] Book book)
        {
            if (ModelState.IsValid)
            {         
                bookService.CreateBook(book);
                bookService.SaveBook();
                //IEnumerable<Book> books;
                //books = bookService.GetBooks().ToList();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,name,genre,description,price,editor")] Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.ModifyEntityState(book);
                bookService.SaveBook();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //    // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //    // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = bookService.GetBook(id);
            bookService.removeBook(book);
            bookService.SaveBook();
            return RedirectToAction("Index");
        }

        public ActionResult SearchBooks(string searchString)
        {
            IEnumerable<Book> books;
            books = bookService.GetBooks().ToList();
            books = books.Where(b => b.name.Contains(searchString));

            ViewBag.books = books;

            return View();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
    }

