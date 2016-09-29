using BookStore.Service;
using BookStore.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IBookService bookService;
        private readonly ICartService cartService;
        private readonly IOrderDetailService orderDetailService;

        public ShoppingCartController(IBookService bookService, ICartService cartService, IOrderDetailService orderDetailService)
        {
            this.bookService = bookService;
            this.cartService = cartService;
            this.orderDetailService = orderDetailService;

        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart =    ShoppingCart.GetCart(this.HttpContext,cartService,orderDetailService);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);

           
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(string id)
        {
            // Retrieve the album from the database
            var addedBook = bookService.GetBook(id);
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext,cartService,orderDetailService);

            cart.AddToCart(addedBook);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int  id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext, cartService, orderDetailService);

            // Get the name of the album to display confirmation
            string bookName = cartService.GetCartByRecordId(id).Book.name;



            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(bookName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext, cartService, orderDetailService);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }



    }
}