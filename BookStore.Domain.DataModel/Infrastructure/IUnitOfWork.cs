﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Infrastructure
{
  public interface IUnitOfWork
    {

        void Commit();
        void ModifyEntityState(Object obj);
    }
}
