using System.Collections.Generic;
using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;


namespace BookStore.Domain.DataModel.Repository
{
  public  class BookRepository : RepositoryBase<Classes.Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override IEnumerable<Book> GetAll()
        {
            
            return dataContext.Books.Include("authors").Include("reviews");
        }

        public override Book GetById(string id)
        {
            Book book = base.GetById(id);
            dataContext.Entry(book).Collection(n => n.reviews).Load();
            dataContext.Entry(book).Collection(n => n.authors).Load();
            return book;
        }



    }

    public interface IBookRepository :IRepository<Book>
    {
    }
}
