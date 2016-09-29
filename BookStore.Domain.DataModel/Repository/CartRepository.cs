using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartrepository
    {
        public CartRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


        public Cart getCart(string CartId,string BookId)
        {            
            return dataContext.Carts.SingleOrDefault(
               c => c.CartId == CartId
               && c.BookId == BookId);
        }

        public IEnumerable<Cart> getCartsById(string CartId)
        {
            return dataContext.Carts.Where(c => c.CartId == CartId);

        }

        public Cart GetByRecordId(int recordId)
        {
            return dataContext.Carts.Single(item => item.RecordId == recordId);

        }
    }

    public interface ICartrepository:IRepository<Cart>
    {
         IEnumerable<Cart> getCartsById(string CartId);
        Cart GetByRecordId(int recordId);
        Cart getCart(string CartId, string BookId);

    }
}
