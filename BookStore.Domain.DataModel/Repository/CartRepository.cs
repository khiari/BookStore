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
    }

    public interface ICartrepository:IRepository<Cart>
    {
    }
}
