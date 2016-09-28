using BookStore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.web.Models
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public float CartTotal { get; set; }
    }
}