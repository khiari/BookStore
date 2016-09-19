using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Infrastructure
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private BookStoreContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public BookStoreContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

        public void ModifyEntityState(Object obj)
        {
            DbContext.SetModified(obj);

        }
    }
}
