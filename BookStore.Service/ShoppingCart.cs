using BookStore.Domain.Classes;
using BookStore.Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Service
{
    public class ShoppingCart
    {
        #region attributes 
        private readonly ICartService cartService;
        private readonly IOrderDetailService orderDetailService;
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        #endregion

        #region implementation
        public ShoppingCart()
        {

        }
        public ShoppingCart(ICartService cartService)
        {
            this.cartService = cartService;

        }

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Book book)
        {
            // Get the matching cart and book instances
            var cartItem = cartService.GetCart(ShoppingCartId, book.ISBN);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    BookId = book.ISBN,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                cartService.CreateCart(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            cartService.SaveCart();
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public int RemoveFromCart(int recordId)
        {
            // Get the cart
            var cartItem = cartService.GetCartByRecordId(recordId);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    cartService.removeCart(cartItem);
                }
                // Save changes
                cartService.SaveCart();
            }
            return itemCount;
        }


        public void EmptyCart()
        {
            var cartItems = cartService.GetCartsById(ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                cartService.removeCart(cartItem);
            }
            // Save changes
            cartService.SaveCart();
        }

        public List<Cart> GetCartItems()
        {
            return cartService.GetCartsById(ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in GetCartItems()
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        public float GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            float? total = (from cartItems in GetCartItems()
                              select (int?)cartItems.Count *
                              cartItems.Book.price).Sum();

            return total ?? 0;
        }

        public int CreateOrder(Order order)
        {
            float orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    BookId = item.BookId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Book.price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Book.price);

                orderDetailService.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            orderDetailService.SaveOrderDetail();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

    }
}

