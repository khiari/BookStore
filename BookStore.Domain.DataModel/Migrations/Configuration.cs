namespace BookStore.Domain.DataModel.Migrations
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<BookStore.Domain.DataModel.BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
           // AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookStore.Domain.DataModel.BookStoreContext context)
        {

            GetBooks().ForEach(c => context.Books.Add(c));
            context.Commit();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
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
                    reviews =GetReviews(),
                    authors= getAuthors(),
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
                new Review {Id=1,rating=4.5F,review="good book for beginners" }

            };
        }
    }
}
