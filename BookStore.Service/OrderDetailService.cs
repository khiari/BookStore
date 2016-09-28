using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Repository;
using BookStore.Domain.DataModel.Infrastructure;

namespace BookStore.Service
{
    class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailrepository orderDetailRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderDetailService(IOrderDetailrepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }


        public void Add(OrderDetail orderDetail)
        {
            orderDetailRepository.Add(orderDetail); 
        }

        public void ModifyEntityState(object obj)
        {
            throw new NotImplementedException();
        }

        public void removeOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public void SaveOrderDetail()
        {
            unitOfWork.Commit();
        }
    }
}
