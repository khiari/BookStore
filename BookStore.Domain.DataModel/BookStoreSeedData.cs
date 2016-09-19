using BookStore.Domain.Classes;
using System.Collections.Generic;
using System.Data.Entity;


namespace BookStore.Domain.DataModel
{
    public class BookStoreSeedData: DropCreateDatabaseIfModelChanges<BookStoreContext> 
    {
        protected override void Seed(BookStoreContext context)
        {

            GetBooks().ForEach(c => context.Books.Add(c));
            context.Commit();
        }

        private static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    ISBN = "1",
                    name="Beginning ASP.NET 4.5 in C#",
                    genre="scientific",
                    description="good book to begin developping ASP.NET applications",
                    price=20.5F,
                    //reviews =GetReviews(),
                    //authors= getAuthors(),
                    editor="Apress"
                }

            };

        }

        private static List<Author> getAuthors()
        {
            return new List<Author>
            {
                 new Author {Id=1,name=" Matthew MacDonald",shortBio="good writer" }

            };
        }

        private static List<Review> GetReviews()
        {
            return new List<Review>
            {
                new Review {rating=4.5F,review="good book for beginners" }

            };
        }
    }
}
