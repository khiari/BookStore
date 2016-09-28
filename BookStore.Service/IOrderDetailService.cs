using BookStore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
  public  interface IOrderDetailService
    {

         void Add(OrderDetail orderDetail);
        void SaveOrderDetail();
        void removeOrderDetail(OrderDetail orderDetail);
        void ModifyEntityState(Object obj);

    }
}
