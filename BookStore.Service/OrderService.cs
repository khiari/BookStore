using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;
using BookStore.Domain.DataModel.Repository;

namespace BookStore.Service
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;

        }

        public void CreateOrder(Order order)
        {
            orderRepository.Add(order);
        }

        public bool GetOrder(int orderId, string userName)
        {
            return orderRepository.GetOrder(orderId, userName);
        }

        public void SaveOrder()
        {
            unitOfWork.Commit();
        }
    }
}
