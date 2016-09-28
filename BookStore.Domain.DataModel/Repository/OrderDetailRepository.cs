using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Repository
{
    class OrderDetailRepository: RepositoryBase<OrderDetail>, IOrderDetailrepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

    }



        public interface IOrderDetailrepository : IRepository<OrderDetail>
        {
    

        }
}

