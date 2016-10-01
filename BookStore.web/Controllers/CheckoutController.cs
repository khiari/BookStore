using BookStore.Domain.Classes;
using BookStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {

        #region attribures
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IOrderDetailService orderDetailService;

        const string PromoCode = "FREE";

        #endregion

        public CheckoutController(IOrderService orderService, ICartService cartService, IOrderDetailService orderDetailService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.orderDetailService = orderDetailService;
        }
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }


        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    orderService.CreateOrder(order);
                    orderService.SaveOrder();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext, cartService, orderDetailService);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }


        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = orderService.GetOrder(id, User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}