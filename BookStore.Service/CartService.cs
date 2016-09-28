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
    class CartService : ICartService
    {

        private readonly ICartrepository cartRepository;
        private readonly IUnitOfWork unitOfWork;

        public CartService(ICartrepository cartRepository, IUnitOfWork unitOfWork)
        {
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateCart(Cart cart)
        {
            cartRepository.Add(cart);
        }

        public Cart GetCart(string cartId,string bookId)
        {
            throw new NotImplementedException();
        }

        public Cart GetCartByRecordId(int recordId)
        {
            return cartRepository.GetByRecordId(recordId);
        }

        public IEnumerable<Cart> GetCartsById(string cartId)
        {
            return cartRepository.getCartsById(cartId);
        }

        public void ModifyEntityState(object obj)
        {
            throw new NotImplementedException();
        }

        public void removeCart(Cart cart)
        {
            cartRepository.Delete(cart);
        }

        public void SaveCart()
        {
            unitOfWork.Commit();
        }

        
    }
}
