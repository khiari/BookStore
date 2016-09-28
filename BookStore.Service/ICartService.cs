using BookStore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
  public   interface ICartService
    {
        IEnumerable<Cart> GetCartsById(string cartId);
        //IEnumerable<Book> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Cart GetCart(string cartId,string bookId);
        Cart GetCartByRecordId(int id);
        void CreateCart(Cart cart);
        void SaveCart();
        void removeCart(Cart cart);
        void ModifyEntityState(Object obj);


    }
}
