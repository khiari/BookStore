using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Classes;
using BookStore.Domain.DataModel.Repository;
using BookStore.Domain.DataModel.Infrastructure;
using GenreStore.Domain.DataModel.Infrastructure;
using GenreStore.Domain.Classes;

namespace BookStore.Service
{
   public  class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenreService()
        {
        }

        public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            this.genreRepository = genreRepository;
            this.unitOfWork = unitOfWork;
        }



       IEnumerable<Genre> getGenres()
        {
            return genreRepository.GetAll();
        }

      
    }
}
