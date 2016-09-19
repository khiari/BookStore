using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.DataModel.Infrastructure
{
   public class DbFactory: Disposable,IDbFactory
    {

        BookStoreContext dbContext;

        public BookStoreContext Init()
        {
            return dbContext ?? (dbContext = new BookStoreContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
