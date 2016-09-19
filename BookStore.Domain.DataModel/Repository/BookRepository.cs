using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;


namespace BookStore.Domain.DataModel.Repository
{
  public  class BookRepository : RepositoryBase<Classes.Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

      


    }

    public interface IBookRepository :IRepository<Book>
    {
    }
}
