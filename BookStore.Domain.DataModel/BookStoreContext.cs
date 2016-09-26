using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookStore.Domain.Classes;


namespace BookStore.Domain.DataModel
{
    interface IBookStoreContext
    {
        void SetModified(Object entity);
    }
  public   class BookStoreContext: DbContext,IBookStoreContext
    {
        public BookStoreContext():base("name=DefaultConnection")
        {


        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Review> Reviews { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
