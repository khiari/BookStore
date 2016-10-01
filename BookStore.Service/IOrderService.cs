using BookStore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
   public  interface IOrderService
    {

        void CreateOrder(Order order);
        bool GetOrder(int orderId, string userName);
        void SaveOrder();
    }
}
