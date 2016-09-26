using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Repository
{
  public  class GenreRepository :  RepositoryBase<Classes.Genre>, IGenreRepository
    {
        public GenreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

    }


        public interface IGenreRepository : IRepository<Genre>
        {
        }
}
