using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Repository
{
    class CartRepository : RepositoryBase<Cart>, ICartrepository
    {
        public CartRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


        public Cart getCart(string cartId,string bookId=null)
        {            
            return dataContext.Carts.SingleOrDefault(
               c => c.CartId == cartId
               && c.BookId == bookId);
        }

        public IEnumerable<Cart> getCartsById(string cartId)
        {
            return dataContext.Carts.Where(c => c.CartId == cartId);

        }

        public Cart GetByRecordId(int recordId)
        {
            return dataContext.Carts.Single(item => item.RecordId == recordId);

        }
    }

    public interface ICartrepository:IRepository<Cart>
    {
         IEnumerable<Cart> getCartsById(string cartId);
        Cart GetByRecordId(int recordId);
    }
}
