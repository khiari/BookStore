using BookStore.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        //IEnumerable<Book> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Book GetBook(string ISBN);
        void CreateBook(Book book);
        void SaveBook();
        void removeBook(Book book);
        void ModifyEntityState(Object obj);

    }
}
