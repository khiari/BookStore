﻿using BookStore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
   public  interface IGenreService
    {

       IEnumerable<Genre> getGenres();

    }
}
