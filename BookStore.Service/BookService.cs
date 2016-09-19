using System;
using System.Collections.Generic;
using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Repository;
using BookStore.Domain.DataModel.Infrastructure;

namespace BookStore.Service
{
   public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IUnitOfWork unitOfWork;
        

        public BookService()
        {
        }

        public BookService(IBookRepository bookRepository,IUnitOfWork unitOfWork)
        {
            this.bookRepository = bookRepository;
            this.unitOfWork = unitOfWork;
        }




        public void CreateBook(Book book)
        {
            bookRepository.Add(book);
        }

        public Book GetBook(string ISBN)
        {
            return bookRepository.GetById(ISBN);
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetAll();
        }

        public void SaveBook()
        {
            unitOfWork.Commit();
        }

        public void ModifyEntityState(Object obj)
        {
            unitOfWork.ModifyEntityState(obj);
        }

        public void removeBook(Book book)
        {
            bookRepository.Delete(book);
        }
    }
}
