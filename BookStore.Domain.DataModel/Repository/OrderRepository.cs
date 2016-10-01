using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Repository
{
   public  class OrderRepository:RepositoryBase<Classes.Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        
        public bool GetOrder(int orderId,string userName)
        {
           return  dataContext.Orders.Any(o => o.OrderId == orderId &&
                                   o.Username == userName);

        }


}

public interface IOrderRepository : IRepository<Order>
{

        bool GetOrder(int orderId, string userName);
}
}